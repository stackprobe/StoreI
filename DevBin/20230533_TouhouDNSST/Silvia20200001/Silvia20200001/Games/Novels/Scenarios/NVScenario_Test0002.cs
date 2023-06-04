using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Games.Novels.Theaters;

namespace Charlotte.Games.Novels.Scenarios
{
	public class NVScenario_Test0002 : NVScenario
	{
		public NVScenario_Test0002()
			: base(new NVTheater_Test0001())
		{ }

		public override string GetScenario()
		{
			return @"
/
上の選択肢を選びました。

@キャラクタ登場 てゐ
@キャラクタ位置 てゐ 左
@キャラクタ画像 てゐ 因幡てゐ(普)

@背景変更 73544
@音楽再生 EoTE

/
因幡てゐをバストアップにします。

@キャラクタ退場 てゐ

@キャラクタ登場 てゐ(BU)
@キャラクタ位置 てゐ(BU) 右(BU)
@キャラクタ画像 てゐ(BU) 因幡てゐ(普)

/
モード変更

@キャラクタ画像 てゐ(BU) 因幡てゐ(喜)

/
左寄せ

@キャラクタ位置 てゐ(BU) 左(BU)

/
右寄せ

@キャラクタ位置 てゐ(BU) 右(BU)

/
テストシナリオはここまでです。
おわり

; 想定外の位置変更
;
@キャラクタ位置 てゐ(BU) 左

";
		}
	}
}
