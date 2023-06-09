﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.GameCommons;

namespace Charlotte
{
	public static class Pictures
	{
		public static Picture Dummy = new Picture(@"General\Dummy.png");
		public static Picture WhiteBox = new Picture(@"General\WhiteBox.png");
		public static Picture WhiteCircle = new Picture(@"General\WhiteCircle.png");
		public static Picture TransparentBox = new Picture(@"General\TransparentBox.png");
		public static Picture Copyright = new Picture(@"Handmade\Copyright.png");

		public static Picture 東方背景_nc73538 = new Picture(@"Picture\かんなにらせ\nc73538.png");
		public static Picture 東方背景_nc73543 = new Picture(@"Picture\かんなにらせ\nc73543.png");
		public static Picture 東方背景_nc73544 = new Picture(@"Picture\かんなにらせ\nc73544.png");
		public static Picture 東方背景_nc73545 = new Picture(@"Picture\かんなにらせ\nc73545.png");
		public static Picture 東方背景_nc73546 = new Picture(@"Picture\かんなにらせ\nc73546.png");
		public static Picture 東方背景_nc73547 = new Picture(@"Picture\かんなにらせ\nc73547.png");
		public static Picture 東方背景_nc77065 = new Picture(@"Picture\かんなにらせ\nc77065.png");
		public static Picture 東方背景_nc77066 = new Picture(@"Picture\かんなにらせ\nc77066.png");
		public static Picture 東方背景_nc77373 = new Picture(@"Picture\かんなにらせ\nc77373.png");
		public static Picture 東方背景_nc77374 = new Picture(@"Picture\かんなにらせ\nc77374.png");
		public static Picture 東方背景_nc77375 = new Picture(@"Picture\かんなにらせ\nc77375.png");
		public static Picture 東方背景_nc77376 = new Picture(@"Picture\かんなにらせ\nc77376.png");
		public static Picture 東方背景_nc77377 = new Picture(@"Picture\かんなにらせ\nc77377.png");
		public static Picture 東方背景_nc77378 = new Picture(@"Picture\かんなにらせ\nc77378.png");
		public static Picture 東方背景_nc77379 = new Picture(@"Picture\かんなにらせ\nc77379.png");
		public static Picture 東方背景_nc77380 = new Picture(@"Picture\かんなにらせ\nc77380.png");
		public static Picture 東方背景_nc77381 = new Picture(@"Picture\かんなにらせ\nc77381.png");
		public static Picture 東方背景_nc77382 = new Picture(@"Picture\かんなにらせ\nc77382.png");
		public static Picture 東方背景_nc77876 = new Picture(@"Picture\かんなにらせ\nc77876.png");
		public static Picture 東方背景_nc77877 = new Picture(@"Picture\かんなにらせ\nc77877.png");
		public static Picture 東方背景_nc77878 = new Picture(@"Picture\かんなにらせ\nc77878.png");
		public static Picture 東方背景_nc77879 = new Picture(@"Picture\かんなにらせ\nc77879.png");
		public static Picture 東方背景_nc77880 = new Picture(@"Picture\かんなにらせ\nc77880.png");
		public static Picture 東方背景_nc77881 = new Picture(@"Picture\かんなにらせ\nc77881.png");
		public static Picture 東方背景_nc77882 = new Picture(@"Picture\かんなにらせ\nc77882.png");
		public static Picture 東方背景_nc77884 = new Picture(@"Picture\かんなにらせ\nc77884.png");
		public static Picture 東方背景_nc77885 = new Picture(@"Picture\かんなにらせ\nc77885.png");
		public static Picture 東方背景_nc77886 = new Picture(@"Picture\かんなにらせ\nc77886.png");
		public static Picture 東方背景_nc77887 = new Picture(@"Picture\かんなにらせ\nc77887.png");
		public static Picture 東方背景_nc77888 = new Picture(@"Picture\かんなにらせ\nc77888.png");
		public static Picture 東方背景_nc77889 = new Picture(@"Picture\かんなにらせ\nc77889.png");
		public static Picture 東方背景_nc77891 = new Picture(@"Picture\かんなにらせ\nc77891.png");
		public static Picture 東方背景_nc77892 = new Picture(@"Picture\かんなにらせ\nc77892.png");
		public static Picture 東方背景_nc77893 = new Picture(@"Picture\かんなにらせ\nc77893.png");
		public static Picture 東方背景_nc77894 = new Picture(@"Picture\かんなにらせ\nc77894.png");
		public static Picture 東方背景_nc77895 = new Picture(@"Picture\かんなにらせ\nc77895.png");
		public static Picture 東方背景_nc77896 = new Picture(@"Picture\かんなにらせ\nc77896.png");
		public static Picture 東方背景_nc77897 = new Picture(@"Picture\かんなにらせ\nc77897.png");
		public static Picture 東方背景_nc78901 = new Picture(@"Picture\かんなにらせ\nc78901.png");
		public static Picture 東方背景_nc78902 = new Picture(@"Picture\かんなにらせ\nc78902.png");
		public static Picture 東方背景_nc78903 = new Picture(@"Picture\かんなにらせ\nc78903.png");
		public static Picture 東方背景_nc78904 = new Picture(@"Picture\かんなにらせ\nc78904.png");

		public static Picture DungeonBackground = new Picture(@"Handmade\Dungeon\Background0001.png");
		public static Picture DungeonGate = new Picture(@"Handmade\Dungeon\Gate0001.png");
		public static Picture DungeonWall = new Picture(@"Handmade\Dungeon\Wall0001.png");

		public static Picture チルノ_普 = new Picture(@"Picture\dairi\41675357_p6.png");
		public static Picture チルノ_怒 = new Picture(@"Picture\dairi\41675357_p0.png");
		public static Picture 因幡てゐ_普 = new Picture(@"Picture\dairi\55464134_p0.png");
		public static Picture 因幡てゐ_喜 = new Picture(@"Picture\dairi\55464134_p13.png");

		#region オオバコ Tewi

		private static Lazy<Tewi_t> _tewi = new Lazy<Tewi_t>(() => new Tewi_t());

		private static Tewi_t Tewi
		{
			get
			{
				return _tewi.Value;
			}
		}

		private class Tewi_t
		{
			public Picture[] Tewi_01 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi0101.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0102.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0103.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0104.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0105.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0106.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0107.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0108.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0109.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0110.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0111.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0112.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0113.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0114.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0115.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0116.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0117.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0118.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0119.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0120.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0121.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0122.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0123.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0124.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0125.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0126.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0127.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0128.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0129.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0130.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0131.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0132.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0133.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0134.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0135.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0136.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0137.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0138.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0139.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0140.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0141.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0142.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0143.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0144.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0145.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0146.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0147.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0148.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0149.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0150.png"),
			};

			public Picture[] Tewi_02 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi0201.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0202.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0203.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0204.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0205.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0206.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0207.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0208.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0209.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0210.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0211.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0212.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0213.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0214.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0215.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0216.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0217.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0218.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0219.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0220.png"),
			};

			public Picture[] Tewi_03 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi0301.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0302.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0303.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0304.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0305.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0306.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0307.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0308.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0309.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0310.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0311.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0312.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0313.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0314.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0315.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0316.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0317.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0318.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0319.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0320.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0321.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0322.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0323.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0324.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0325.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0326.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0327.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0328.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0329.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0330.png"),
			};

			public Picture[] Tewi_05 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi0501.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0502.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0503.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0504.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0505.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0506.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0507.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0508.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0509.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0510.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0511.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0512.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0513.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0514.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0515.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0516.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0517.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0518.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0519.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0520.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0521.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0522.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0523.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0524.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0525.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0526.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0527.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0528.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0529.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi0530.png"),
			};

			public Picture[] Tewi_13 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi1301.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1302.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1303.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1304.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1305.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1306.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1307.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1308.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1309.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1310.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1311.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1312.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1313.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1314.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1315.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1316.png"),
			};

			public Picture[] Tewi_18 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi1801.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1802.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1803.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1804.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1805.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1806.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1807.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1808.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1809.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1810.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1811.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi1812.png"),
			};

			public Picture[] Tewi_20 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi2001.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2002.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2003.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2004.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2005.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2006.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2007.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2008.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2009.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2010.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2011.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2012.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2013.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2014.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2015.png"),
			};

			public Picture[] Tewi_21 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi2101.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2102.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2103.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2104.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2105.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2106.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2107.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2108.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2109.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2110.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2111.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2112.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2113.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2114.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2115.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2116.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2117.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2118.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2119.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2120.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2121.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2122.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2123.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2124.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2125.png"),
			};

			public Picture[] Tewi_22 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi2201.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2202.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2203.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2204.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2205.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2206.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2207.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2208.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2209.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2210.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2211.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2212.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2213.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2214.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2215.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2216.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2217.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2218.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2219.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2220.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2221.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2222.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2223.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2224.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2225.png"),
			};

			public Picture[] Tewi_23 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi2301.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2302.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2303.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2304.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2305.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2306.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2307.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2308.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2309.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2310.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2311.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2312.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2313.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2314.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2315.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2316.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2317.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2318.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2319.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2320.png"),
			};

			public Picture[] Tewi_24 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi2401.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2402.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2403.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2404.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2405.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2406.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2407.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2408.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2409.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2410.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2411.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2412.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2413.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2414.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2415.png"),
			};

			public Picture[] Tewi_25 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi2501.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2502.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2503.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2504.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2505.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2506.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2507.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2508.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2509.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2510.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2511.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2512.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2513.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2514.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2515.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2516.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2517.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2518.png"),
			};

			public Picture[] Tewi_26 = new Picture[]
			{
				new Picture(@"Picture\オオバコ\tewi\tewi2601.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2602.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2603.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2604.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2605.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2606.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2607.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2608.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2609.png"),
				new Picture(@"Picture\オオバコ\tewi\tewi2610.png"),
			};
		}

		#endregion

		public static Picture[] Tewi_立ち = Tewi.Tewi_01.Skip(0).Take(12).ToArray();
		public static Picture[] Tewi_振り向き = Tewi.Tewi_01.Skip(13).Take(2).ToArray();
		public static Picture[] Tewi_しゃがみ = Tewi.Tewi_01.Skip(20).Take(5).ToArray();
		public static Picture[] Tewi_しゃがみ解除 = Tewi.Tewi_01.Skip(26).Take(4).ToArray();
		public static Picture[] Tewi_しゃがみ振り向き = Tewi.Tewi_01.Skip(16).Take(2).ToArray();
		public static Picture[] Tewi_ジャンプ_上昇 = Tewi.Tewi_01.Skip(32).Take(2).ToArray();
		public static Picture[] Tewi_ジャンプ_下降 = Tewi.Tewi_01.Skip(34).Take(6).ToArray();
		public static Picture[] Tewi_歩く = Tewi.Tewi_02.Skip(0).Take(10).ToArray();
		public static Picture[] Tewi_走る = Tewi.Tewi_03.Skip(2).Take(6).ToArray();
		public static Picture[] Tewi_小ダメージ = Tewi.Tewi_05.Skip(0).Take(3).ToArray();
		public static Picture[] Tewi_大ダメージ = Tewi.Tewi_05.Skip(4).Take(3).ToArray();
		public static Picture[] Tewi_しゃがみ小ダメージ = Tewi.Tewi_05.Skip(20).Take(3).ToArray();
		public static Picture[] Tewi_しゃがみ大ダメージ = Tewi.Tewi_05.Skip(24).Take(3).ToArray();
		public static Picture[] Tewi_飛翔_開始 = Tewi.Tewi_13.Skip(0).Take(2).ToArray();
		public static Picture[] Tewi_飛翔_前進 = Tewi.Tewi_13.Skip(3).Take(3).ToArray();
		public static Picture[] Tewi_弱攻撃 = Tewi.Tewi_18.Skip(0).Take(10).ToArray();
		public static Picture[] Tewi_中攻撃 = Tewi.Tewi_20.Skip(0).Take(11).ToArray();
		public static Picture[] Tewi_強攻撃 = Tewi.Tewi_21.Skip(15).Take(8).ToArray();
		public static Picture[] Tewi_しゃがみ弱攻撃 = Tewi.Tewi_22.Skip(10).Take(8).ToArray();
		public static Picture[] Tewi_しゃがみ中攻撃 = Tewi.Tewi_22.Skip(0).Take(9).ToArray();
		public static Picture[] Tewi_しゃがみ強攻撃 = Tewi.Tewi_23.Skip(0).Take(14).ToArray();
		public static Picture[] Tewi_ジャンプ弱攻撃 = Tewi.Tewi_26.Skip(0).Take(8).ToArray();
		public static Picture[] Tewi_ジャンプ中攻撃 = Tewi.Tewi_24.Skip(0).Take(11).ToArray();
		public static Picture[] Tewi_ジャンプ強攻撃 = Tewi.Tewi_25.Skip(0).Take(15).ToArray();

		public static Picture[,] CirnoWalk = new Picture[,]
		{
			{
				new Picture(@"Picture\点睛集積\thv8_cirno2_0000.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0001.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0002.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0003.png"),
			},
			{
				new Picture(@"Picture\点睛集積\thv8_cirno2_0100.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0101.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0102.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0103.png"),
			},
			{
				new Picture(@"Picture\点睛集積\thv8_cirno2_0200.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0201.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0202.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0203.png"),
			},
			{
				new Picture(@"Picture\点睛集積\thv8_cirno2_0300.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0301.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0302.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0303.png"),
			},
			{
				new Picture(@"Picture\点睛集積\thv8_cirno2_0400.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0401.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0402.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0403.png"),
			},
			{
				new Picture(@"Picture\点睛集積\thv8_cirno2_0500.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0501.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0502.png"),
				new Picture(@"Picture\点睛集積\thv8_cirno2_0503.png"),
			},
		};

		public static Picture 石壁 = new Picture(@"Picture\出所不詳\石壁.png");

		public static Picture Grass = new Picture(@"Picture\ぴぽや倉庫\Grass\Tile_0000.png");
		public static Picture[, ,] River = new Picture[,,]
		{
			{
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0000.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0200.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0400.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0600.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0800.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1000.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1200.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1400.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0001.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0201.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0401.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0601.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0801.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1001.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1201.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1401.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0002.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0202.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0402.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0602.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0802.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1002.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1202.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1402.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0003.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0203.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0403.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0603.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0803.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1003.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1203.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1403.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0004.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0204.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0404.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0604.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0804.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1004.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1204.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1404.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0005.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0205.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0405.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0605.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0805.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1005.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1205.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1405.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0006.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0206.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0406.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0606.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0806.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1006.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1206.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1406.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0007.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0207.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0407.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0607.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0807.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1007.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1207.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1407.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0008.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0208.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0408.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0608.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0808.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1008.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1208.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1408.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0009.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0209.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0409.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0609.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0809.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1009.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1209.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1409.png"),
				},
			},
			{
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0100.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0300.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0500.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0700.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0900.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1100.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1300.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1500.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0101.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0301.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0501.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0701.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0901.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1101.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1301.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1501.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0102.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0302.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0502.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0702.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0902.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1102.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1302.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1502.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0103.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0303.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0503.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0703.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0903.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1103.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1303.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1503.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0104.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0304.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0504.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0704.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0904.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1104.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1304.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1504.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0105.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0305.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0505.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0705.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0905.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1105.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1305.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1505.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0106.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0306.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0506.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0706.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0906.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1106.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1306.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1506.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0107.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0307.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0507.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0707.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0907.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1107.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1307.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1507.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0108.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0308.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0508.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0708.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0908.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1108.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1308.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1508.png"),
				},
				{
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0109.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0309.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0509.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0709.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_0909.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1109.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1309.png"),
					new Picture(@"Picture\ぴぽや倉庫\River\Tile_1509.png"),
				},
			},
		};
		public static Picture[] Tree = new Picture[]
		{
			new Picture(@"Picture\ぴぽや倉庫\Tree\Tile_0005.png"), // 低木
			new Picture(@"Picture\ぴぽや倉庫\Tree\Tile_0001.png"), // 木の左上
			new Picture(@"Picture\ぴぽや倉庫\Tree\Tile_0002.png"), // 木の左下
			new Picture(@"Picture\ぴぽや倉庫\Tree\Tile_0101.png"), // 木の右上
			new Picture(@"Picture\ぴぽや倉庫\Tree\Tile_0102.png"), // 木の右下
		};
	}
}
