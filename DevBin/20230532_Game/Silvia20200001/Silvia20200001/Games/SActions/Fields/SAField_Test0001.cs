﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.GameCommons;
using Charlotte.Games.SActions.Enemies;

namespace Charlotte.Games.SActions.Fields
{
	public class SAField_Test0001 : SAField
	{
		#region Resource

		private static readonly string RES_MAPS = @"

・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・＠＠＠・・・・・・・・
・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠・・＠＠＠＠＠・・・・・・・＠＠＠＠・・＠・・・・・・・
・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・＠＠＠＠・・・・＠＠＠＠＠・・・・＠・・・・・・
・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・＠＠＠＠＠＠＠＠＠・＠＠＠・・・・・＠・・・・・
・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・
・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・
・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・
・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠・・＠＠＠・・・・・・＠・・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠・・・・・・・・・・・＠・・・・・・・・・・・・・・＠・＠・＠・＠・・＠・＠・・・・・・・＠・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠・・・・・・・・・・・＠＠・・・・・・・・・・・・・・＠＠＠＠＠＠＠・・＠＠＠・・・・・・・＠・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・＠＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・＠＠＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・＠＠・・＠＠・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・＠＠・・＠＠・・・＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・
・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠
・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・＠
・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・＠
・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・＠＠＠・・＠＠＠・・＠＠＠・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・＠
・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・＠・＠・・＠・＠・・＠・＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠
・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・＠＠＠・・＠＠＠・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠
・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・＠・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠
・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠

/

＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・＠・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・＠・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・＠・・・・＠＠＠＠＠・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・＠＠＠・・・＠・・・＠・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・＠・＠＠＠＠＠・・・＠・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・＠＠＠・・・＠・・・＠・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・＠・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・＠
＠・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・＠
＠・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・＠・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・＠・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・＠
＠・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・＠
＠・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・＠・＠・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・＠
＠・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・・・・・・・・・・・・・・・・・＠・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・＠・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・＠
＠・・・・・・・・・・・・・＠＠＠＠・・・＠＠・・＠＠・・＠＠・・＠＠・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・＠＠・・＠＠・・＠＠・・＠＠・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠＠・・・・・・・・＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠
・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠
・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠
・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠＠・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・＠＠＠
＠＠・・・・・＠＠・・・・・・・・・・＠＠・・＠＠・・＠＠・・＠＠・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠
＠＠・・・・・＠＠・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠
＠・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・＠＠・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・＠
＠・・・・・・＠＠・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・＠
＠・・・・・・＠＠・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・＠＠
＠・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・＠＠
＠・・・・・・・・・・・・＠＠・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・＠＠
＠・・・・・・・・・・・・＠＠・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・＠＠
＠・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・＠＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・＠＠＠
＠・・・・・・・・・・・・・・・・＠＠・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・＠＠＠
＠・・・・・・・・・・・・・・・・＠＠・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・＠＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・＠＠＠
＠＠・・・・・・・・・・＠＠・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・＠＠＠＠
＠＠・・・・・・・・・・＠＠・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠・・・・・・・・＠＠＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠・・・・・・・・・＠＠＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠・・・・・・・・・＠＠＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠・・・・・・・・・・＠＠＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠・・・・・・・・・＠＠＠＠＠
＠＠・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・＠＠＠＠＠＠・・・・・・・・・＠＠＠＠＠
＠＠・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・＠＠＠＠＠＠・・・・・・・・・＠＠＠＠＠
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・・・・＠＠＠＠
＠＠・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・＠＠＠・・・・・・・・・・・・・＠＠
＠＠＠・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・＠＠＠・・・・・・・・・・・・・＠＠
＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・＠＠
＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠・・・・・・・・＠＠・・・・・＠＠
＠＠＠＠・・・・・・・・・・＠＠・・・・・・・・・・＠＠＠＠＠・・・・・・・・・＠＠＠＠・・・・＠＠
＠＠＠＠・・・・・・・・・・＠＠・・・・・・・・・・＠＠＠・・・・・・・・・・＠＠＠＠＠＠＠・・＠＠
＠＠＠＠＠・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠・・＠＠
＠＠＠＠＠＠・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠・・・・・＠
＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠・・・・・＠
＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・＠
＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・＠

/

＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・
＠＠・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・＠＠＠＠＠＠・・・・＠＠・・・・・・・・・・・＠＠＠＠・・・・＠＠＠＠・・・・＠＠＠＠・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠
・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠・＠・・・＠＠＠＠＠＠・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠・・・・・・・・＠・・・・＠＠＠＠＠＠・・・・
・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠・・＠＠＠・・・＠＠＠＠・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠・・・・・＠・・・・・＠＠＠＠＠＠・・・・
・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・＠・・・・・・＠＠＠＠＠＠・・・・
・・・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠・＠・・・・・・・＠＠＠＠＠＠・・・・
＠＠・・・・・・・・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・＠・・・・・・・・＠＠＠＠＠＠・・・・
＠＠＠・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠・・＠＠＠・・・＠＠＠＠＠＠＠＠・・・・・・・・・・＠・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠
＠＠＠＠・・・・・・・・・＠＠＠＠＠＠＠＠＠＠・・＠・＠・・・＠＠＠＠＠＠・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・
＠＠＠＠・・・＠＠・・・・・・・・・・＠＠・・・・＠＠＠・・・＠＠＠＠・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・
＠＠＠＠・・・＠＠・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・
＠＠＠＠＠＠＠＠＠・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・
＠＠＠＠＠＠＠＠＠・・・・・・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・・・＠・・・・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・
＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・・

/

＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠

/

＠・・＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・＠＠＠＠＠＠＠・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・＠＠・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・＠＠＠＠＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・＠＠＠・・・＠＠＠＠・・・・・・・＠
＠・・・・・・・・・・・・・＠・・・・・・＠・・・・・・・＠
＠＠＠・・・・・・・・・・・＠・・・・・・＠・・・・・・・＠
＠・・・・・・・・・・・・・＠・・・・・・＠＠＠＠＠＠＠＠＠
＠・・・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・＠・・・・・・・・・・・＠
＠・・＠＠＠・・・・・・・・・・・＠・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・＠・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・＠＠＠＠＠＠＠＠＠＠＠＠＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・＠＠＠＠・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・＠＠＠＠・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・＠＠＠＠・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・＠＠＠＠＠・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・＠＠＠＠・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠＠＠＠＠＠＠・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・・・・・・・・・・・・・・・・・・・・・＠
＠・・・・・・・・＠＠＠＠＠＠＠＠＠＠・・・＠・・・・・＠＠
＠・・・・・・・・＠・・・・・・・・・・・・＠・・・・・＠＠
＠・・・・・・・・＠・・・・・・・・・・・・＠・・・・・＠＠
＠・・・・・・・・＠・・・・・・・・・・・・＠・・・・・＠＠
＠・・・・・・・＠＠・・・・・・・・・・・＠＠・・・・＠＠＠
＠・・・・・・・＠・・・・・・・・・・・＠＠・・・・＠＠＠＠
＠・・・・・・・＠・・・・・・・・・・・＠・・・・・＠＠＠＠
＠・・・・・・・＠・・・・・・・・・・・＠・・・・・＠＠＠＠
＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠

";

		#endregion

		public static SAField_Test0001 Create(int index)
		{
			string[] lines = SCommon.TextToLines(SCommon.Tokenize(RES_MAPS, "/")[index].Trim());

			int w = lines[0].Length;
			int h = lines.Length;

			bool[,] table = new bool[w, h];

			for (int x = 0; x < w; x++)
				for (int y = 0; y < h; y++)
					table[x, y] = lines[y][x] == '＠';

			return new SAField_Test0001(w, h, table);
		}

		private bool[,] Table;

		private SAField_Test0001(int w, int h, bool[,] table)
			: base(new I2Size(w, h))
		{
			this.Table = table;
		}

		public override void Initialize()
		{
			SAGame.I.Player.X = this.W / 2.0;
			SAGame.I.Player.Y = this.H / 2.0;

			for (int c = 0; c < 10; c++)
			{
				D2Point pt = new D2Point(
					(double)(int)SCommon.CRandom.GetDoubleRange(50.0, SAGame.I.Field.W - 150.0),
					(double)(int)SCommon.CRandom.GetDoubleRange(50.0, SAGame.I.Field.H - 150.0)
					);

				if (DD.GetDistance(pt, new D2Point(SAGame.I.Player.X, SAGame.I.Player.Y)) < 200.0) // ? プレイヤーに近すぎる。
					continue;

				SAGame.I.Enemies.Add(new SAEnemy_Test0001(pt.X, pt.Y));
			}
			Musics.SunBeams.Play();
		}

		protected override bool P_IsWall(I2Point tilePt)
		{
			return this.Table[tilePt.X, tilePt.Y];
		}

		protected override void P_DrawTile(I2Point tilePt, D2Point drawPt)
		{
			if (this.IsWall(tilePt))
			{
				DD.Draw(Pictures.石壁, drawPt);
			}
		}

		protected override IEnumerable<bool> E_DrawWall()
		{
			for (; ; )
			{
				int l = -SAGame.I.Camera.X / 10;
				int t = -SAGame.I.Camera.Y / 10;

				l %= SAConsts.TILE_W * 2;
				t %= SAConsts.TILE_H * 2;

				for (int x = 0; l + x * SAConsts.TILE_W < GameConfig.ScreenSize.W; x++)
				{
					for (int y = 0; t + y * SAConsts.TILE_H < GameConfig.ScreenSize.H; y++)
					{
						D2Point drawPt = new D2Point(
							(double)(l + x * SAConsts.TILE_W + SAConsts.TILE_W / 2),
							(double)(t + y * SAConsts.TILE_H + SAConsts.TILE_H / 2)
							);

						Picture picture1;
						Picture picture2;
						Picture picture3;

						picture1 = Pictures.Grass;

						if ((x + y) % 2 == 0)
						{
							picture2 = Pictures.Tree[4];
							picture3 = Pictures.Tree[1];
						}
						else
						{
							picture2 = Pictures.Tree[2];
							picture3 = Pictures.Tree[3];
						}

						DD.Draw(picture1, drawPt);
						DD.Draw(picture2, drawPt);
						DD.Draw(picture3, drawPt);
					}
				}
				DD.DrawCurtain(-0.7);

				yield return true;
			}
		}
	}
}
