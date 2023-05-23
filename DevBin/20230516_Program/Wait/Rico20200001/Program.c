#include <stdio.h>
#include <conio.h>
#include <windows.h>

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

static int GetMin(int a, int b)
{
	return a < b ? a : b;
}
static int GetMax(int a, int b)
{
	return a < b ? b : a;
}

#define WAIT_SEC_MIN 3
#define WAIT_SEC_MAX 999999

#define SLEEP_MILLIS 250

void main(int argc, char **argv)
{
	int waitSec;
	int millis;
	int lastPrintRemSec = -1;

	if (argc != 2)
		Error();

	waitSec = atoi(argv[1]);

	if (waitSec < 0 || WAIT_SEC_MAX < waitSec)
		Error();

	millis = waitSec * 1000;

	for (; ; )
	{
		waitSec = millis / 1000;

		if (lastPrintRemSec != waitSec)
		{
			lastPrintRemSec = waitSec;
			printf("\r%d 秒待っています。中止するには ESC 続行するには ENTER を押して下さい ... ", lastPrintRemSec);
		}

		while (_kbhit())
		{
			int key = _getch();

			if (key == 0x1b) // ? ESC
			{
				printf("\n中止します。\n");
				exit(1);
			}
			if (key == 0x0d) // ? ENTER
			{
				printf("\n続行します。\n");
				exit(0);
			}

			if (key == '+') // プラス 1 分
			{
				millis += 60000;
			}
			else if (key == '-') // マイナス 1 分
			{
				millis -= 60000;
			}
			else if (key == '*') // プラス 1 時間
			{
				millis += 3600000;
			}
			else if (key == '/') // 残り時間クリア
			{
				millis = 0;
			}

			millis = GetMax(millis, WAIT_SEC_MIN * 1000);
			millis = GetMin(millis, WAIT_SEC_MAX * 1000);
		}

		if (millis <= 0)
		{
			printf("\nタイムアウトにより続行します。\n");
			exit(0);
		}

		Sleep(SLEEP_MILLIS);
		millis -= SLEEP_MILLIS;
	}
}
