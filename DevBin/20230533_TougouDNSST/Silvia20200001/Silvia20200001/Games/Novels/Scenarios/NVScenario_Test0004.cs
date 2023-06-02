﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Games.Novels.Theaters;

namespace Charlotte.Games.Novels.Scenarios
{
	public class NVScenario_Test0004 : NVScenario
	{
		public NVScenario_Test0004()
			: base(new NVTheater_Test0001())
		{ }

		public override string GetScenario()
		{
			return @"
/
ほげほげ

@背景変更 73544

";
		}
	}
}
