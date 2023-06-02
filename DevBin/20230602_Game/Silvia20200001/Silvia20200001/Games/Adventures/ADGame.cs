using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.Adventures.Rooms;

namespace Charlotte.Games.Adventures
{
	public class ADGame : IDisposable
	{
		public static ADGame I;

		public ADGame()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public ADRoom Room;
		public bool ReturnToCallerRequested = false;

		public int DestSlideX = 0; // { -1, 0, 1 }
		public int DestSlideY = 0; // { -1, 0, 1 }
		public double SlideX = 0; // -1.0 ～ 1.0
		public double SlideY = 0; // -1.0 ～ 1.0

		/// <summary>
		/// 次の部屋
		/// ゲームメイン処理を終了する前にセットされる。
		/// null == 無効(呼び出し側に戻る)
		/// </summary>
		public ADRoom NextRoom = null;

		public void Run(ADRoom room)
		{
			this.Room = room;

			// memo: 入力抑止
			// -- DD.FreezeInput
			// -- DD.FreezeInputUntilRelease
			// -- DD.UnfreezeInputUntilRelease
			// -- Inputs.XXX.FreezeInputUntilRelease
			// -- Inputs.XXX.UnfreezeInputUntilRelease

			DD.FreezeInputUntilRelease();

			for (; ; )
			{
				if (Inputs.PAUSE.GetInput() == 1)
				{
					this.Pause();

					if (this.ReturnToCallerRequested)
						break;
				}
				if (Inputs.A.GetInput() == 1)
				{
					this.NextRoom = this.Room.DefaultActionAndGetNextRoom();
					break;
				}
				if (Inputs.DIR_4.GetInput() == 1)
				{
					this.DestSlideX += 2;
					this.DestSlideX %= 3;
					this.DestSlideX--;
				}
				if (Inputs.DIR_6.GetInput() == 1)
				{
					this.DestSlideX += 3;
					this.DestSlideX %= 3;
					this.DestSlideX--;
				}
				if (Inputs.DIR_8.GetInput() == 1)
				{
					this.DestSlideY += 2;
					this.DestSlideY %= 3;
					this.DestSlideY--;
				}
				if (Inputs.DIR_2.GetInput() == 1)
				{
					this.DestSlideY += 3;
					this.DestSlideY %= 3;
					this.DestSlideY--;
				}
				DD.Approach(ref this.SlideX, (double)this.DestSlideX, 0.93);
				DD.Approach(ref this.SlideY, (double)this.DestSlideY, 0.93);

				this.Room.Draw();

				DD.SetPrint(20, 20, 0);
				DD.SetPrintBorder(new I3Color(0, 0, 0), 1);
				DD.Print("A -> 次の部屋 / PAUSE -> ポーズメニュー");

				DD.EachFrame();
			}
			DD.FreezeInput();
		}

		private static VScreen PauseWall = new VScreen(GameConfig.ScreenSize.W, GameConfig.ScreenSize.H);

		/// <summary>
		/// ポーズメニュー
		/// </summary>
		private void Pause()
		{
			using (PauseWall.Section())
			{
				DD.Draw(DD.LastMainScreen.GetPicture(), new I2Point(GameConfig.ScreenSize.W / 2, GameConfig.ScreenSize.H / 2).ToD2Point());
			}

			SimpleMenu menu = new SimpleMenu(24, 30, 16, 400, "PAUSE", new string[]
 			{
				"NOOP",
				"タイトルメニューに戻る",
				"ゲームに戻る",
			});

			menu.NoPound = true;
			menu.CancelByPause = true;

			foreach (Input input in Inputs.GetAllInput())
				input.FreezeInputUntilRelease();

			double blurRate = 0.0;

			for (; ; )
			{
				DD.FreezeInput();

				for (; ; )
				{
					DD.Approach(ref blurRate, 0.5, 0.98);

					DD.Draw(PauseWall.GetPicture(), new I2Point(GameConfig.ScreenSize.W / 2, GameConfig.ScreenSize.H / 2).ToD2Point());
					DD.Blur(blurRate);

					if (menu.Draw())
						break;

					DD.EachFrame();
				}
				DD.FreezeInput();

				switch (menu.SelectedIndex)
				{
					case 0:
						// noop
						break;

					case 1:
						this.ReturnToCallerRequested = true;
						goto endOfMenu;

					case 2:
						goto endOfMenu;

					default:
						throw null; // never
				}
			}
		endOfMenu:
			DD.FreezeInput();
			DD.FreezeInputUntilRelease();

			PauseWall.Unload();
		}
	}
}
