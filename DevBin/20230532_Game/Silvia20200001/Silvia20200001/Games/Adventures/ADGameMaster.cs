using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
				ADGame.I.Run();
			}
		}
	}
}
