#pragma comment(lib, "user32.lib")

#include <windows.h>
#include <stdio.h>
#include <math.h>

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

static int DoubleToInt(double value)
{
	if (value < 0.0)
	{
		return (int)(value - 0.5);
	}
	else
	{
		return (int)(value + 0.5);
	}
}

static void DoMouseCursor(int x, int y)
{
	INPUT i = { 0 };

	i.type = INPUT_MOUSE;
	i.mi.dx = DoubleToInt(x * (65536.0 / GetSystemMetrics(SM_CXSCREEN)));
	i.mi.dy = DoubleToInt(y * (65536.0 / GetSystemMetrics(SM_CYSCREEN)));
	i.mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
	i.mi.dwExtraInfo = GetMessageExtraInfo();

	SendInput(1, &i, sizeof(INPUT));
}

/*
	button:
		1 == left button
		2 == middle button
		3 == right button

	down:
		TRUE == down
		FALSE == up
*/
static void DoMouseButton(int button, int down)
{
	int flag;
	INPUT i = { 0 };

	switch (button)
	{
	case 1: flag = down ? MOUSEEVENTF_LEFTDOWN   : MOUSEEVENTF_LEFTUP;   break;
	case 2: flag = down ? MOUSEEVENTF_MIDDLEDOWN : MOUSEEVENTF_MIDDLEUP; break;
	case 3: flag = down ? MOUSEEVENTF_RIGHTDOWN  : MOUSEEVENTF_RIGHTUP;  break;

	default:
		Error();
	}

	i.type = INPUT_MOUSE;
	i.mi.dwFlags = flag;
	i.mi.dwExtraInfo = GetMessageExtraInfo();

	SendInput(1, &i, sizeof(INPUT));
}

/*
	level:
		���̒l == ��O�ɓ]����
		���̒l == ���֓]����
*/
static void DoMouseWheel(int level)
{
	INPUT i = { 0 };

	i.type = INPUT_MOUSE;
	i.mi.mouseData = level * WHEEL_DELTA;
	i.mi.dwFlags = MOUSEEVENTF_WHEEL;
	i.mi.dwExtraInfo = GetMessageExtraInfo();

	SendInput(1, &i, sizeof(INPUT));
}

static char Keys[0x100]; // �Ō�̃L�[������ԃ}�b�v

static void CheckKeyEach(void)
{
	int vk;

	for (vk = 0; vk <= 0xff; vk++)
	{
		Keys[vk] = GetAsyncKeyState(vk) ? 1 : 0;
	}
}

static int IsPressKey(unsigned __int16 vk)
{
	return Keys[vk] != 0;
}

static int IsPressLShift(void)
{
	return IsPressKey(VK_LSHIFT);
}

static int IsPressLControl(void)
{
	return IsPressKey(VK_LCONTROL);
}

static int IsPressRShift(void)
{
	return IsPressKey(VK_RSHIFT);
}

static int IsPressRControl(void)
{
	return IsPressKey(VK_RCONTROL);
}

static void DoKeyboard(unsigned __int16 vk, int down)
{
	INPUT i = { 0 };

	i.type = INPUT_KEYBOARD;
	i.ki.wVk = vk;
	i.ki.wScan = MapVirtualKey(vk, 0);
	i.ki.dwFlags = KEYEVENTF_EXTENDEDKEY | (down ? 0 : KEYEVENTF_KEYUP);
	i.mi.dwExtraInfo = GetMessageExtraInfo();

	SendInput(1, &i, sizeof(INPUT));
}

void main(int argc, char **argv)
{
	int loopCount;
	int lockKeyPressed = 0;
	int locked = 0;
	int lBtnKeyPress = 0;
	int rBtnKeyPress = 0;
	int lBtnPressed = 0;
	int rBtnPressed = 0;
	int lBtnPress;
	int rBtnPress;

	printf("+---------------------------------+\n");
	printf("| �E�V�t�g --------> ���{�^���A�� |\n");
	printf("| �E�R���g���[�� --> �E�{�^���A�� |\n");
	printf("| ���V�t�g ----> ��ԃ��b�N�E���� |\n");
	printf("| ���V�t�g���R���g���[�� --> �I�� |\n");
	printf("+---------------------------------+\n");
	printf("START...\n");

	for (loopCount = 0; ; loopCount++)
	{
		Sleep(20); // 16.666 (60 Hz) ��蒷�����Ă����B

		CheckKeyEach();

		if (IsPressLShift() && IsPressLControl())
		{
			break;
		}

		if (IsPressLShift())
		{
			if (!lockKeyPressed)
			{
				lockKeyPressed = 1;
				locked = !locked;

				if (locked)
				{
					if (!lBtnKeyPress && !rBtnKeyPress)
					{
						locked = 0;
						printf("��Ԃ���̂��߃��b�N���܂���B\n");
					}
					else
					{
						printf("���b�N���܂����B��Ԃ� %d %d �ł��B\n", lBtnKeyPress, rBtnKeyPress);
					}
				}
				else
				{
					printf("���b�N���������܂����B\n");
				}
			}
		}
		else
		{
			lockKeyPressed = 0;
		}

		if (!locked)
		{
			lBtnKeyPress = IsPressRShift();
			rBtnKeyPress = IsPressRControl();
		}

		lBtnPress = lBtnKeyPress ? loopCount % 2 == 0 : 0;
		rBtnPress = rBtnKeyPress ? loopCount % 2 == 0 : 0;

		if (lBtnPressed ? !lBtnPress : lBtnPress)
		{
			DoMouseButton(1, lBtnPress);
			lBtnPressed = lBtnPress;
		}
		if (rBtnPressed ? !rBtnPress : rBtnPress)
		{
			DoMouseButton(3, rBtnPress);
			rBtnPressed = rBtnPress;
		}
	}

	if (lBtnPressed)
	{
		DoMouseButton(1, 0);
	}
	if (rBtnPressed)
	{
		DoMouseButton(3, 0);
	}

	printf("END\n");
}
