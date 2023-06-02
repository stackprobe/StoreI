using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Games.TActions.Fields;

namespace Charlotte.Games.TActions
{
	public class TAGameMaster : IDisposable
	{
		public static TAGameMaster I;

		public TAGameMaster()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public void Run(TAField field)
		{
			using (new TAGame())
			{
				TAGame.I.Run(field);
			}
		}
	}
}
