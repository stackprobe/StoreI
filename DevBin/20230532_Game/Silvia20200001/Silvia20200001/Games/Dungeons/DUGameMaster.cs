using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Games.Dungeons.Fields;

namespace Charlotte.Games.Dungeons
{
	public class DUGameMaster : IDisposable
	{
		public static DUGameMaster I;

		public DUGameMaster()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public void Run()
		{
			using (new DUGame())
			{
				DUGame.I.Run(DUField_Test0001.Create());
			}
		}
	}
}
