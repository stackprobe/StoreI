﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;

namespace Charlotte.Games.SActions.Shots
{
	/// <summary>
	/// テスト用_自弾
	/// </summary>
	public class SAShot_Test0001 : SAShot
	{
		private bool FacingLeft;

		public SAShot_Test0001(double x, double y, bool facingLeft)
			: base(x, y, 1, false)
		{
			this.FacingLeft = facingLeft;
		}

		protected override IEnumerable<bool> E_Draw()
		{
			for (; ; )
			{
				this.X += 8.0 * (this.FacingLeft ? -1 : 1);

				if (SACommon.IsOutOfCamera(new D2Point(this.X, this.Y))) // カメラから出たら消滅する。
					break;

				if (SAGame.I.Field.IsWall(SACommon.ToTablePoint(new D2Point(this.X, this.Y)))) // 壁に当たったら自滅する。
				{
					this.Kill();
					break;
				}

				DD.SetZoom(0.1);
				DD.Draw(Pictures.Dummy, new D2Point(this.X - SAGame.I.Camera.X, this.Y - SAGame.I.Camera.Y));

				this.Crash = Crash.CreateCircle(new D2Point(this.X, this.Y), 5.0);

				yield return true;
			}
		}
	}
}
