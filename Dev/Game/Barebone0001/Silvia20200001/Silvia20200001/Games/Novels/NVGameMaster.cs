using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.Novels.Scenarios;

namespace Charlotte.Games.Novels
{
	public static class NVGameMaster
	{
		public static void Run()
		{
			int choosedIndex;
			NVScenario scenario;

			using (new NVGame())
			{
				NVGame.I.Run(new NVScenario_Test0001());

				if (NVGame.I.ReturnToCallerRequested)
					return;

				choosedIndex = NVGame.I.ChoosedIndex;
			}

			switch (choosedIndex)
			{
				case 0: scenario = new NVScenario_Test0002(); break;
				case 1: scenario = new NVScenario_Test0003(); break;
				case 2: scenario = new NVScenario_Test0004(); break;

				default:
					throw null; // never
			}

			using (new NVGame())
			{
				NVGame.I.Run(scenario);
			}
		}
	}
}
