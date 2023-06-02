using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Games.Novels.Theaters;

namespace Charlotte.Games.Novels.Scenarios
{
	public class NVScenario_Test0003 : NVScenario
	{
		public NVScenario_Test0003()
			: base(new NVTheater_Test0001())
		{ }

		public override string GetScenario()
		{
			return @"
/
２つ目の選択肢を選びました。

@キャラクタ登場 因幡てゐ
@キャラクタ位置 因幡てゐ 左
@キャラクタ画像 因幡てゐ 因幡てゐ(普)

@背景変更 73544
@音楽停止

/
このルートはここで終わりです。

";
		}
	}
}
