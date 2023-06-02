using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.TActions.Fields;

namespace Charlotte.Games.TActions
{
	public static class TAGameMaster
	{
		public static void Run(TAField field)
		{
			using (new TAGame())
			{
				TAGame.I.Run(field);
			}
		}
	}
}
