using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.Dungeons.Fields;

namespace Charlotte.Games.Dungeons
{
	public static class DUGameMaster
	{
		public static void Run()
		{
			using (new DUGame())
			{
				DUGame.I.Run(DUField_Test0001.Create());
			}
		}
	}
}
