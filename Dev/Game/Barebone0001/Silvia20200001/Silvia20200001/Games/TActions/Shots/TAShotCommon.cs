﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;

namespace Charlotte.Games.TActions.Shots
{
	public static class TAShotCommon
	{
		/// <summary>
		/// 汎用・消滅イベント
		/// </summary>
		/// <param name="shot">消滅する自弾</param>
		public static void Killed(TAShot shot)
		{
			DD.EL.Add(SCommon.Supplier(TAEffects.Explode(shot.X, shot.Y, 1.0)));
		}
	}
}
