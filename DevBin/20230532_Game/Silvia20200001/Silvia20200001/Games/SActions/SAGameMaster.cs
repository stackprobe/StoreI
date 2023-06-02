using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.GameCommons;
using Charlotte.Games.SActions.Fields;

namespace Charlotte.Games.SActions
{
	public class SAGameMaster : IDisposable
	{
		public static SAGameMaster I;

		public SAGameMaster()
		{
			I = this;
		}

		public void Dispose()
		{
			I = null;
		}

		public void Run(SAField field)
		{
			using (new SAGame())
			{
				SAGame.I.Run(field);
			}
		}
	}
}
