using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;

namespace Charlotte.Games.Adventures.Rooms
{
	public class ADRoom_Test0001 : ADRoom
	{
		public override ADRoom DefaultActionAndGetNextRoom()
		{
			return new ADRoom_Test0002();
		}

		protected override IEnumerable<bool> E_Draw()
		{
			Musics.RemotestLibrary.Play();

			for (; ; )
			{
				DD.Draw(Pictures.AigAi230105750, new I2Point(GameConfig.ScreenSize.W / 2, GameConfig.ScreenSize.H / 2).ToD2Point()
					+ new D2Point(ADGame.I.SlideX * 20.0, ADGame.I.SlideY * 65.0));

				yield return true;
			}
		}
	}
}
