using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			using (new ADGame())
			{
				ADGame.I.Run(new ADRoom_Test0001());
			}
		}
	}
}
