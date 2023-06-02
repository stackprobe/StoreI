using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;

namespace Charlotte.Games.Adventures
{
	public static class Adventure
	{
		public static void Run()
		{
			DD.FreezeInput();

			for (; ; )
			{
				if (Inputs.PAUSE.GetInput() == 1)
					break;

				DD.SetPrint(20, 20, 0);
				DD.SetPrintBorder(new I3Color(128, 0, 0), 1);
				DD.Print("PAUSE -> RETURN");

				DD.EachFrame();
			}
			DD.FreezeInput();
		}
	}
}
