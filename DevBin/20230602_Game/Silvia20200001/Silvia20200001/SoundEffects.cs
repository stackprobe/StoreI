﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte
{
	public static class SoundEffects
	{
		public static SoundEffect Save = new SoundEffect(@"SoundEffect\ユーフルカ\save-01.wav");
		public static SoundEffect Load = new SoundEffect(@"SoundEffect\ユーフルカ\load.wav");
		public static SoundEffect Buy = new SoundEffect(@"SoundEffect\ユーフルカ\shop.wav");

		public static SoundEffect PlayerDamaged = new SoundEffect(@"SoundEffect\小森平\coin02.mp3"); // HACK: 適当な音
		public static SoundEffect EnemyDamaged = new SoundEffect(@"SoundEffect\小森平\coin03.mp3"); // HACK: 適当な音
		public static SoundEffect EnemyKilled = new SoundEffect(@"SoundEffect\小森平\coin04.mp3"); // HACK: 適当な音
		public static SoundEffect PlayerJump = new SoundEffect(@"SoundEffect\小森平\coin05.mp3"); // HACK: 適当な音
		public static SoundEffect PlayerShoot = new SoundEffect(@"SoundEffect\小森平\poka01.mp3"); // HACK: 適当な音
		public static SoundEffect CrashToWall = new SoundEffect(@"SoundEffect\小森平\coin07.mp3"); // HACK: 適当な音
	}
}
