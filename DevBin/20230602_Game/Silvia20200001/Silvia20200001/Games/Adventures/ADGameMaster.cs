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
	public class ADGameMaster : IDisposable
	{
		public static ADGameMaster I;

		public ADGameMaster()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public void Run()
		{
			ADRoom room = new ADRoom_Test0001();
			do
			{
				using (new ADGame())
				{
					ADGame.I.Run(room);
					room = ADGame.I.NextRoom;
				}
			}
			while (room != null);
		}
	}
}
