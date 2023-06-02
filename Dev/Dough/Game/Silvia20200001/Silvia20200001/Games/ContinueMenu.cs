using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.Dungeons;
using Charlotte.Games.Novels;
using Charlotte.Games.SActions;
using Charlotte.Games.SActions.Fields;
using Charlotte.Games.Shootings;
using Charlotte.Games.TActions;
using Charlotte.Games.TActions.Fields;
using Charlotte.Games.Adventures;

namespace Charlotte.Games
{
	public static class ContinueMenu
	{
		public static void Run()
		{
			SimpleMenu menu = new SimpleMenu(20, 30, 13, 350, "TEST-MENU", new string[]
 			{
				"Adventures.Adventure",
				"Dungeons.DUGameMaster",
				"Novels.NVGameMaster",
				"SAction.SAGameMaster.1",
				"SAction.SAGameMaster.2",
				"SAction.SAGameMaster.3",
				"SAction.SAGameMaster.4",
				"SAction.SAGameMaster.5",
				"Shootings.SHGameMaster",
				"TAction.TAGameMaster.1",
				"TAction.TAGameMaster.2",
				"TAction.TAGameMaster.3",
				"TAction.TAGameMaster.4",
				"Exit",
			});

			for (; ; )
			{
				Music.FadeOut();
				DD.SetCurtain(0.0);
				DD.FreezeInput();

				for (; ; )
				{
					DD.SetBright(new I3Color(0, 128, 0).ToD3Color());
					DD.Draw(Pictures.WhiteBox, new I4Rect(0, 0, GameConfig.ScreenSize.W, GameConfig.ScreenSize.H).ToD4Rect());

					if (menu.Draw())
						break;

					DD.EachFrame();
				}
				DD.FreezeInput();

				switch (menu.SelectedIndex)
				{
					case 0:
						Adventure.Run();
						break;

					case 1:
						DUGameMaster.Run();
						break;

					case 2:
						NVGameMaster.Run();
						break;

					case 3:
						SAGameMaster.Run(SAField_Test0001.Create(0));
						break;

					case 4:
						SAGameMaster.Run(SAField_Test0001.Create(1));
						break;

					case 5:
						SAGameMaster.Run(SAField_Test0001.Create(2));
						break;

					case 6:
						SAGameMaster.Run(SAField_Test0001.Create(3));
						break;

					case 7:
						SAGameMaster.Run(SAField_Test0001.Create(4));
						break;

					case 8:
						SHGameMaster.Run();
						break;

					case 9:
						TAGameMaster.Run(TAField_Test0001.Create(0));
						break;

					case 10:
						TAGameMaster.Run(TAField_Test0001.Create(1));
						break;

					case 11:
						TAGameMaster.Run(TAField_Test0001.Create(2));
						break;

					case 12:
						TAGameMaster.Run(TAField_Test0001.Create(3));
						break;

					case 13:
						goto endOfMenu;

					default:
						throw null; // never
				}
			}
		endOfMenu:
			;
		}
	}
}
