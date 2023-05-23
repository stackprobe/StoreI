using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.Shootings.Shots;

namespace Charlotte.Games.Shootings
{
	/// <summary>
	/// プレイヤーに関する情報と機能
	/// 唯一のインスタンスを Game.I.Player に保持する。
	/// </summary>
	public class SHPlayer
	{
		public double X;
		public double Y;
		public double Reborn_X;
		public double Reborn_Y;
		public Crash Crash;
		public int AttackFrame;
		public int DeadFrame = 0; // 0 == 無効, 1～ == 死亡中
		public int RebornFrame = 0; // 0 == 無効, 1～ == 登場中
		public int InvincibleFrame = 0; // 0 == 無効, 1～ == 無敵時間中

		public void Draw()
		{
			if (1 <= this.DeadFrame)
			{
				// noop
			}
			else if (1 <= this.RebornFrame)
			{
				DD.EL.Add(() =>
				{
					DD.SetAlpha(0.5);
					DD.SetMosaic();
					DD.SetZoom(3.0);
					DD.Draw(Pictures.CirnoWalk[0, 2], new D2Point(this.Reborn_X, this.Reborn_Y));

					return false;
				});
			}
			else if (1 <= this.InvincibleFrame)
			{
				DD.EL.Add(() =>
				{
					DD.SetAlpha(0.5);
					DD.SetMosaic();
					DD.SetZoom(3.0);
					DD.Draw(Pictures.CirnoWalk[0, 2], new D2Point(this.X, this.Y));

					return false;
				});
			}
			else
			{
				DD.SetMosaic();
				DD.SetZoom(3.0);
				DD.Draw(Pictures.CirnoWalk[0, 2], new D2Point(this.X, this.Y));
			}
		}
	}
}
