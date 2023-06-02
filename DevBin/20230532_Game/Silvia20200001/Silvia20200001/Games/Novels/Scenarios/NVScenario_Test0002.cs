﻿using System;
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

@キャラクタ登場 ゆかり
@キャラクタ位置 ゆかり 左
@キャラクタ画像 ゆかり ゆかり(普)

@背景変更 UKIc
@音楽再生 SunB

/
ゆかりをバストアップにします。

@キャラクタ退場 ゆかり

@キャラクタ登場 ゆかり(BU)
@キャラクタ位置 ゆかり(BU) 右(BU)
@キャラクタ画像 ゆかり(BU) ゆかり(普)

/
モード変更

@キャラクタ画像 ゆかり(BU) ゆかり(喜)

/
左寄せ

@キャラクタ位置 ゆかり(BU) 左(BU)

/
右寄せ

@キャラクタ位置 ゆかり(BU) 右(BU)

/
テストシナリオはここまでです。
おわり

; 想定外の位置変更
;
@キャラクタ位置 ゆかり(BU) 左

";
		}
	}
}
