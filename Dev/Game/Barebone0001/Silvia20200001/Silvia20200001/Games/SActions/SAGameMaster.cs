using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.SActions.Fields;

namespace Charlotte.Games.SActions
{
	public static class SAGameMaster
	{
		public static void Run(SAField field)
		{
			using (new SAGame())
			{
				SAGame.I.Run(field);
			}
		}
	}
}
