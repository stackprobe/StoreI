using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.Shootings.Scenarios;

namespace Charlotte.Games.Shootings
{
	public static class SHGameMaster
	{
		public static void Run()
		{
			using (new SHGame())
			{
				SHGame.I.Run(new SHScenario_Test0001());
			}
		}
	}
}
