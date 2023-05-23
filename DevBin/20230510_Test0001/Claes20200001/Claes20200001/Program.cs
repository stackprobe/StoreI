﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Charlotte.Commons;
using Charlotte.Tests;

namespace Charlotte
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcMain.CUIMain(new Program().Main2);
		}

		private void Main2(ArgsReader ar)
		{
			if (ProcMain.DEBUG)
			{
				Main3();
			}
			else
			{
				Main4();
			}
			SCommon.OpenOutputDirIfCreated();
		}

		private void Main3()
		{
			Main4();
			SCommon.Pause();
		}

		private void Main4()
		{
			try
			{
				Main5();
			}
			catch (Exception ex)
			{
				ProcMain.WriteLog(ex);
			}
		}

		private void Main5()
		{
			// -- choose one --

			//new Test0001().Test01();
			//new Test0001().Test02();
			//new Test0001().Test03();
			//new Test0001().Test04();
			//new Test0002().Test01();
			//new Test0002().Test02();
			//new Test0002().Test03();
			//new Test0002().Test04();
			//new Test0002().Test05();
			//new Test0002().Test06();
			//new Test0002().Test07();
			//new Test0002().Test08();
			//new Test0003().Test01();
			//new Test0004().Test01();
			//new Test0004().Test02();
			//new Test0005().Test01();
			//new Test0005().Test02();
			//new Test0005().Test03();
			//new Test0005().Test04();
			new Test0005().Test05();

			// --
		}
	}
}
