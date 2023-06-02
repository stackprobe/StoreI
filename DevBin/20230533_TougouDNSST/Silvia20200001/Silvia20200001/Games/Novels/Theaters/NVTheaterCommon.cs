using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte.Games.Novels.Theaters
{
	public static class NVTheaterCommon
	{
		/// <summary>
		/// 全てのシナリオで共通のコマンドを処理する。
		/// </summary>
		/// <param name="command">コマンド</param>
		/// <param name="arguments">パラメータ列</param>
		/// <returns>コマンドを処理したか</returns>
		public static bool Invoke(string command, string[] arguments)
		{
			int c = 0;

			if (command == "音楽再生")
			{
				Music music;

				switch (arguments[c++])
				{
					case "DsDr": music = Musics.DesireDrive; break;
					case "EoTE": music = Musics.EndOfTheEnd; break;

					default:
						throw null; // never
				}
				music.Play();
			}
			else if (command == "音楽停止")
			{
				Music.FadeOut();
			}
			else if (command == "選択肢")
			{
				NVGame.I.Choices = arguments;
			}
			else
			{
				return false; // コマンドを処理しなかった。
			}
			return true; // コマンドを処理した。
		}
	}
}
