#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <windows.h>

// ---- error

#define Error() \
	Error_LN(__LINE__)

static void Error_LN(int lineno)
{
	char command[32]; // rough size

	printf("FATAL %d\n", lineno);
	sprintf(command, "START *[ERROR]-%d", lineno);
	system(command);
	exit(1);
}

// ---- utils

static int IsValidBatchFile(char *file)
{
	FILE *fp = fopen(file, "rb");
	int ret = 0;

	if (fp)
	{
		ret = fgetc(fp) != EOF; // ? not empty file

		if (fclose(fp) != 0)
			Error();
	}
	return ret;
}
static char *GetStrDateTime(time_t t)
{
	static char str[26]; // size: ctime ret

	strcpy(str, ctime(&t));

	if (str[8] == ' ')
		str[8] = '0';

	str[24] = '\0';
	return str;
}

// ---- main

#define STOP_EV_NAME "Cron_STOP_{baf19612-401e-4417-9b1f-48b0b8b72501}"
#define BATCH_NAME_MAX 12
#define BATCH_MAX 100

typedef struct Batch_st
{
	char Name[BATCH_NAME_MAX];
	int PeriodSec;
	int RemainingSec;
}
Batch_t;

static Batch_t Batches[BATCH_MAX];
static int BatchCount;

static void CollectBatch_SS(int suffix, int scale)
{
	char name[BATCH_NAME_MAX];
	int count;
	Batch_t *i;

	for (count = 1; count <= 99; count++)
	{
		sprintf(name, "Cron%d%c.bat", count, suffix);

		if (IsValidBatchFile(name))
		{
			if (BATCH_MAX <= BatchCount)
				Error();

			i = Batches + BatchCount++;
			strcpy(i->Name, name);
			i->PeriodSec = count * scale;
			i->RemainingSec = 0;
		}
	}
}
static void CollectBatch(void)
{
	CollectBatch_SS('s', 1);
	CollectBatch_SS('m', 60);
	CollectBatch_SS('h', 3600);
	CollectBatch_SS('d', 86400);
}
static void ExecuteAllBatchIfTimeout(int elapsedSec)
{
	int index;

	for (index = 0; index < BatchCount; index++)
	{
		Batch_t *i = Batches + index;

		i->RemainingSec -= elapsedSec;

		if (i->RemainingSec <= 0)
		{
			printf("# %s %s\n", GetStrDateTime(time(NULL)), i->Name);

			system(i->Name);

			printf("\n");

			i->RemainingSec = i->PeriodSec;
		}
	}
}
static int GetNextWaitSec(void)
{
	int nextWaitSec = 300; // rough limit
	int index;

	for (index = 0; index < BatchCount; index++)
	{
		Batch_t *i = Batches + index;

		if (nextWaitSec > i->RemainingSec)
			nextWaitSec = i->RemainingSec;
	}
	return nextWaitSec;
}
void main(int argc, char **argv)
{
	HANDLE evStop = CreateEventA(NULL, 0, 0, STOP_EV_NAME);

	if (evStop == NULL)
		Error();

	if (argc == 2 && !_stricmp(argv[1], "/S"))
	{
		printf("Cron-STOP\n");

		SetEvent(evStop);
	}
	else
	{
		int waitSec = 0;

		if (argc != 1) // ? �s���ȃR�}���h�������w�肳��Ă���B
			Error();

		CollectBatch();

		printf("Cron-START\n");

		while (WaitForSingleObject(evStop, waitSec * 1000) == WAIT_TIMEOUT)
		{
			ExecuteAllBatchIfTimeout(waitSec);
			waitSec = GetNextWaitSec();
		}
		printf("Cron-END\n");
	}
	CloseHandle(evStop);
}
