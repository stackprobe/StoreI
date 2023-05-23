﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Utilities
{
	public class JapaneseDate
	{
		private int YMD;

		/// <summary>
		/// (西暦)年月日からインスタンスを生成する。
		/// 日付の範囲
		/// -- 年 1～214748
		/// -- 月 0～99
		/// -- 日 0～99
		/// -- 最小 1/0/0
		/// -- 最大 214748/36/47
		/// </summary>
		/// <param name="ymd">(西暦)年月日</param>
		public JapaneseDate(int ymd)
		{
			// 不正な月日はケアしない。

			if (ymd < 10000)
				ymd = 10000;

			this.YMD = ymd;
		}

		/// <summary>
		/// (西暦)年月日を取得する。
		/// </summary>
		/// <returns>(西暦)年月日</returns>
		public int GetYMD()
		{
			return this.YMD;
		}

		/// <summary>
		/// (西暦)年
		/// </summary>
		public int Y
		{
			get
			{
				return this.YMD / 10000;
			}
		}

		/// <summary>
		/// 月
		/// </summary>
		public int M
		{
			get
			{
				return (this.YMD / 100) % 100;
			}
		}

		/// <summary>
		/// 日
		/// </summary>
		public int D
		{
			get
			{
				return this.YMD % 100;
			}
		}

		#region EraInfos

		private class EraInfo
		{
			public int FirstYMD;
			public string Name;
			public char? Alphabet;

			public EraInfo(int firstYMD, string name, char? alphabet = null)
			{
				this.FirstYMD = firstYMD;
				this.Name = name;
				this.Alphabet = alphabet;
			}
		}

		private static EraInfo[] EraInfos = new EraInfo[]
		{
			new EraInfo(0, null),
			new EraInfo(6450717, "大化"),
			new EraInfo(6500322, "白雉"),
			new EraInfo(6541124, null),
			new EraInfo(6860814, "朱鳥"),
			new EraInfo(6861001, null),
			new EraInfo(7010503, "大宝"),
			new EraInfo(7040616, "慶雲"),
			new EraInfo(7080207, "和銅"),
			new EraInfo(7151003, "霊亀"),
			new EraInfo(7171224, "養老"),
			new EraInfo(7240303, "神亀"),
			new EraInfo(7290902, "天平"),
			new EraInfo(7490504, "天平感宝"),
			new EraInfo(7490819, "天平勝宝"),
			new EraInfo(7570906, "天平宝字"),
			new EraInfo(7650201, "天平神護"),
			new EraInfo(7670913, "神護景雲"),
			new EraInfo(7701023, "宝亀"),
			new EraInfo(7810130, "天応"),
			new EraInfo(7820930, "延暦"),
			new EraInfo(8060608, "大同"),
			new EraInfo(8101020, "弘仁"),
			new EraInfo(8240208, "天長"),
			new EraInfo(8340214, "承和"),
			new EraInfo(8480716, "嘉祥"),
			new EraInfo(8510601, "仁寿"),
			new EraInfo(8541223, "斉衡"),
			new EraInfo(8570320, "天安"),
			new EraInfo(8590520, "貞観"),
			new EraInfo(8770601, "元慶"),
			new EraInfo(8850311, "仁和"),
			new EraInfo(8890530, "寛平"),
			new EraInfo(8980520, "昌泰"),
			new EraInfo(9010831, "延喜"),
			new EraInfo(9230529, "延長"),
			new EraInfo(9310516, "承平"),
			new EraInfo(9380622, "天慶"),
			new EraInfo(9470515, "天暦"),
			new EraInfo(9571121, "天徳"),
			new EraInfo(9610305, "応和"),
			new EraInfo(9640819, "康保"),
			new EraInfo(9680908, "安和"),
			new EraInfo(9700503, "天禄"),
			new EraInfo(9740116, "天延"),
			new EraInfo(9760811, "貞元"),
			new EraInfo(9781231, "天元"),
			new EraInfo(9830529, "永観"),
			new EraInfo(9850519, "寛和"),
			new EraInfo(9870505, "永延"),
			new EraInfo(9890910, "永祚"),
			new EraInfo(9901126, "正暦"),
			new EraInfo(9950325, "長徳"),
			new EraInfo(9990201, "長保"),
			new EraInfo(10040808, "寛弘"),
			new EraInfo(10130208, "長和"),
			new EraInfo(10170521, "寛仁"),
			new EraInfo(10210317, "治安"),
			new EraInfo(10240819, "万寿"),
			new EraInfo(10280818, "長元"),
			new EraInfo(10370509, "長暦"),
			new EraInfo(10401216, "長久"),
			new EraInfo(10441216, "寛徳"),
			new EraInfo(10460522, "永承"),
			new EraInfo(10530202, "天喜"),
			new EraInfo(10580919, "康平"),
			new EraInfo(10650904, "治暦"),
			new EraInfo(10690506, "延久"),
			new EraInfo(10740916, "承保"),
			new EraInfo(10771205, "承暦"),
			new EraInfo(10810322, "永保"),
			new EraInfo(10840315, "応徳"),
			new EraInfo(10870511, "寛治"),
			new EraInfo(10950123, "嘉保"),
			new EraInfo(10970103, "永長"),
			new EraInfo(10971227, "承徳"),
			new EraInfo(10990915, "康和"),
			new EraInfo(11040308, "長治"),
			new EraInfo(11060513, "嘉承"),
			new EraInfo(11080909, "天仁"),
			new EraInfo(11100731, "天永"),
			new EraInfo(11130825, "永久"),
			new EraInfo(11180425, "元永"),
			new EraInfo(11200509, "保安"),
			new EraInfo(11240518, "天治"),
			new EraInfo(11260215, "大治"),
			new EraInfo(11310228, "天承"),
			new EraInfo(11320921, "長承"),
			new EraInfo(11350610, "保延"),
			new EraInfo(11410813, "永治"),
			new EraInfo(11420525, "康治"),
			new EraInfo(11440328, "天養"),
			new EraInfo(11450812, "久安"),
			new EraInfo(11510214, "仁平"),
			new EraInfo(11541204, "久寿"),
			new EraInfo(11560518, "保元"),
			new EraInfo(11590509, "平治"),
			new EraInfo(11600218, "永暦"),
			new EraInfo(11610924, "応保"),
			new EraInfo(11630504, "長寛"),
			new EraInfo(11650714, "永万"),
			new EraInfo(11660923, "仁安"),
			new EraInfo(11690506, "嘉応"),
			new EraInfo(11710527, "承安"),
			new EraInfo(11750816, "安元"),
			new EraInfo(11770829, "治承"),
			new EraInfo(11810825, "養和"),
			new EraInfo(11820629, "寿永"),
			new EraInfo(11840527, "元暦"),
			new EraInfo(11850909, "文治"),
			new EraInfo(11900516, "建久"),
			new EraInfo(11990523, "正治"),
			new EraInfo(12010319, "建仁"),
			new EraInfo(12040323, "元久"),
			new EraInfo(12060605, "建永"),
			new EraInfo(12071116, "承元"),
			new EraInfo(12110423, "建暦"),
			new EraInfo(12140118, "建保"),
			new EraInfo(12190527, "承久"),
			new EraInfo(12220525, "貞応"),
			new EraInfo(12241231, "元仁"),
			new EraInfo(12250528, "嘉禄"),
			new EraInfo(12280118, "安貞"),
			new EraInfo(12290331, "寛喜"),
			new EraInfo(12320423, "貞永"),
			new EraInfo(12330525, "天福"),
			new EraInfo(12341127, "文暦"),
			new EraInfo(12351101, "嘉禎"),
			new EraInfo(12381230, "暦仁"),
			new EraInfo(12390313, "延応"),
			new EraInfo(12400805, "仁治"),
			new EraInfo(12430318, "寛元"),
			new EraInfo(12470405, "宝治"),
			new EraInfo(12490502, "建長"),
			new EraInfo(12561024, "康元"),
			new EraInfo(12570331, "正嘉"),
			new EraInfo(12590420, "正元"),
			new EraInfo(12600524, "文応"),
			new EraInfo(12610322, "弘長"),
			new EraInfo(12640327, "文永"),
			new EraInfo(12750522, "建治"),
			new EraInfo(12780323, "弘安"),
			new EraInfo(12880529, "正応"),
			new EraInfo(12930906, "永仁"),
			new EraInfo(12990525, "正安"),
			new EraInfo(13021210, "乾元"),
			new EraInfo(13030916, "嘉元"),
			new EraInfo(13070118, "徳治"),
			new EraInfo(13081122, "延慶"),
			new EraInfo(13110517, "応長"),
			new EraInfo(13120427, "正和"),
			new EraInfo(13170316, "文保"),
			new EraInfo(13190518, "元応"),
			new EraInfo(13210322, "元亨"),
			new EraInfo(13241225, "正中"),
			new EraInfo(13260528, "嘉暦"),
			new EraInfo(13290922, "元徳"),
			new EraInfo(13310911, "元弘"),
			new EraInfo(13320523, "正慶"),
			new EraInfo(13340305, "建武"),
			new EraInfo(13360411, "延元"),
			new EraInfo(13400525, "興国"),
			new EraInfo(13470120, "正平"),
			new EraInfo(13700816, "建徳"),
			new EraInfo(13720500, "文中"),
			new EraInfo(13750626, "天授"),
			new EraInfo(13810306, "弘和"),
			new EraInfo(13840518, "元中"),
			new EraInfo(13381011, "暦応"),
			new EraInfo(13420601, "康永"),
			new EraInfo(13451115, "貞和"),
			new EraInfo(13500404, "観応"),
			new EraInfo(13521104, "文和"),
			new EraInfo(13560429, "延文"),
			new EraInfo(13610504, "康安"),
			new EraInfo(13621011, "貞治"),
			new EraInfo(13680307, "応安"),
			new EraInfo(13750329, "永和"),
			new EraInfo(13790409, "康暦"),
			new EraInfo(13810320, "永徳"),
			new EraInfo(13840319, "至徳"),
			new EraInfo(13871005, "嘉慶"),
			new EraInfo(13890307, "康応"),
			new EraInfo(13900412, "明徳"),
			new EraInfo(13940802, "応永"),
			new EraInfo(14280610, "正長"),
			new EraInfo(14291003, "永享"),
			new EraInfo(14410310, "嘉吉"),
			new EraInfo(14440223, "文安"),
			new EraInfo(14490816, "宝徳"),
			new EraInfo(14520810, "享徳"),
			new EraInfo(14550906, "康正"),
			new EraInfo(14571016, "長禄"),
			new EraInfo(14610201, "寛正"),
			new EraInfo(14660314, "文正"),
			new EraInfo(14670409, "応仁"),
			new EraInfo(14690608, "文明"),
			new EraInfo(14870809, "長享"),
			new EraInfo(14890916, "延徳"),
			new EraInfo(14920812, "明応"),
			new EraInfo(15010318, "文亀"),
			new EraInfo(15040316, "永正"),
			new EraInfo(15210923, "大永"),
			new EraInfo(15280903, "享禄"),
			new EraInfo(15320829, "天文"),
			new EraInfo(15551107, "弘治"),
			new EraInfo(15580318, "永禄"),
			new EraInfo(15700527, "元亀"),
			new EraInfo(15730825, "天正"),
			new EraInfo(15930110, "文禄"),
			new EraInfo(15961216, "慶長"),
			new EraInfo(16150905, "元和"),
			new EraInfo(16240417, "寛永"),
			new EraInfo(16450113, "正保"),
			new EraInfo(16480407, "慶安"),
			new EraInfo(16521020, "承応"),
			new EraInfo(16550518, "明暦"),
			new EraInfo(16580821, "万治"),
			new EraInfo(16610523, "寛文"),
			new EraInfo(16731030, "延宝"),
			new EraInfo(16811109, "天和"),
			new EraInfo(16840405, "貞享"),
			new EraInfo(16881023, "元禄"),
			new EraInfo(17040416, "宝永"),
			new EraInfo(17110611, "正徳"),
			new EraInfo(17160809, "享保"),
			new EraInfo(17360607, "元文"),
			new EraInfo(17410412, "寛保"),
			new EraInfo(17440403, "延享"),
			new EraInfo(17480805, "寛延"),
			new EraInfo(17511214, "宝暦"),
			new EraInfo(17640630, "明和"),
			new EraInfo(17721210, "安永"),
			new EraInfo(17810425, "天明"),
			new EraInfo(17890219, "寛政"),
			new EraInfo(18010319, "享和"),
			new EraInfo(18040322, "文化"),
			new EraInfo(18180526, "文政"),
			new EraInfo(18310123, "天保"),
			new EraInfo(18450109, "弘化"),
			new EraInfo(18480401, "嘉永"),
			new EraInfo(18550115, "安政"),
			new EraInfo(18600408, "万延"),
			new EraInfo(18610329, "文久"),
			new EraInfo(18640327, "元治"),
			new EraInfo(18650501, "慶応"),
			new EraInfo(18680101, "明治", 'M'),
			new EraInfo(19120730, "大正", 'T'),
			new EraInfo(19261225, "昭和", 'S'),
			new EraInfo(19890108, "平成", 'H'),
			new EraInfo(20190501, "令和", 'R'),
		};

		#endregion

		private class JYearInfo
		{
			public string Gengou;
			public int Y;

			public string Year
			{
				get
				{
					return this.Y == 1 ? "元" : "" + this.Y;
				}
			}
		}

		private JYearInfo JYear = null;

		private JYearInfo GetJYear()
		{
			if (this.JYear == null)
				this.JYear = this.GetJYear_Main();

			return this.JYear;
		}

		private JYearInfo GetJYear_Main()
		{
			EraInfo era;

			{
				int l = 0;
				int r = EraInfos.Length;

				while (l + 1 < r)
				{
					int m = (l + r) / 2;

					if (EraInfos[m].FirstYMD <= this.YMD)
						l = m;
					else
						r = m;
				}
				era = EraInfos[l];
			}

			{
				string gengou;
				int y = this.Y;

				if (era.Name == null)
				{
					gengou = "西暦";
				}
				else
				{
					gengou = era.Name;
					y -= era.FirstYMD / 10000 - 1;
				}

				return new JYearInfo()
				{
					Gengou = gengou,
					Y = y,
				};
			}
		}

		/// <summary>
		/// 元号
		/// </summary>
		public string Gengou
		{
			get
			{
				return this.GetJYear().Gengou;
			}
		}

		/// <summary>
		/// 和暦・年(文字列)
		/// </summary>
		public string SY
		{
			get
			{
				return this.GetJYear().Year;
			}
		}

		/// <summary>
		/// 和暦・年(整数)
		/// </summary>
		public int IY
		{
			get
			{
				return this.GetJYear().Y;
			}
		}

		/// <summary>
		/// 和暦の文字列表現を返す。
		/// 但し年月日は全角
		/// 例：令和元年５月２５日
		/// </summary>
		/// <returns>和暦の文字列表現</returns>
		public override string ToString()
		{
			return HanDigToZenDig(this.ToHalfString());
		}

		/// <summary>
		/// 和暦の文字列表現を返す。
		/// 例：令和元年5月25日
		/// </summary>
		/// <returns>和暦の文字列表現</returns>
		public string ToHalfString()
		{
			return this.ToString("{0}{1}年{3}月{4}日");
		}

		/// <summary>
		/// 和暦の文字列表現を返す。
		/// 但し年数は整数表記
		/// 例：令和1年5月25日
		/// </summary>
		/// <returns>和暦の文字列表現</returns>
		public string ToIntYString()
		{
			return this.ToString("{0}{2}年{3}月{4}日");
		}

		public string ToString(string format)
		{
			return string.Format(format, this.Gengou, this.SY, this.IY, this.M, this.D);
		}

		// ====
		// 定番機能ここまで
		// ====

		/// <summary>
		/// 日付(和暦)文字列からインスタンスを生成する。
		/// </summary>
		/// <param name="str">日付(和暦)文字列</param>
		/// <returns>インスタンス</returns>
		public static JapaneseDate Create(string str)
		{
			if (string.IsNullOrEmpty(str))
				throw new ArgumentException("和暦変換エラー：空の日付");

			// 正規化
			str = RemoveBlank(str);
			str = ZenDigAlpToHanDigAlp(str);
			str = str.ToUpper();

			// 元年の解消
			str = str.Replace("元年", "1年"); // 元を含む元号があるため、年も含めて置き換える。

			EraInfo era = EraInfos
				.Reverse() // 直近の元号から探す。
				.Concat(new EraInfo[] { new EraInfo(10101, "西暦") })
				.FirstOrDefault(v => v.Name != null && (str.Contains(v.Name) || v.Alphabet != null && str.Contains(v.Alphabet.Value)));

			if (era == null)
				throw new ArgumentException("和暦変換エラー：不明な元号");

			string[] symd = SCommon.Tokenize(str, SCommon.DECIMAL, true, true);

			if (symd.Length != 3)
				throw new ArgumentException("和暦変換エラー：不明な年月日");

			if (symd.Any(v => 9 < v.Length))
				throw new ArgumentException("和暦変換エラー：不正な年月日");

			int[] ymd = symd.Select(v => int.Parse(v)).ToArray();

			int y = ymd[0];
			int m = ymd[1];
			int d = ymd[2];

			return new JapaneseDate((era.FirstYMD / 10000 - 1 + y) * 10000 + m * 100 + d);
		}

		private static string RemoveBlank(string str)
		{
			return new string(str.Where(chr => ' ' < chr && chr != '　').ToArray());
		}

		private static char[] ZEN_DIG_ALP = (SCommon.MBC_DECIMAL + SCommon.MBC_ALPHA_UPPER + SCommon.MBC_ALPHA_LOWER).ToArray();
		private static char[] HAN_DIG_ALP = (SCommon.DECIMAL + SCommon.ALPHA_UPPER + SCommon.ALPHA_LOWER).ToArray();

		private static string ZenDigAlpToHanDigAlp(string str)
		{
			return new string(str.Select(chr =>
			{
				for (int index = 0; index < ZEN_DIG_ALP.Length; index++)
					if (chr == ZEN_DIG_ALP[index])
						return HAN_DIG_ALP[index];

				return chr;
			})
			.ToArray());
		}

		private static char[] HAN_DIG = SCommon.DECIMAL.ToArray();
		private static char[] ZEN_DIG = SCommon.MBC_DECIMAL.ToArray();

		private static string HanDigToZenDig(string str)
		{
			return new string(str.Select(chr =>
			{
				for (int index = 0; index < HAN_DIG.Length; index++)
					if (chr == HAN_DIG[index])
						return ZEN_DIG[index];

				return chr;
			})
			.ToArray());
		}
	}
}
