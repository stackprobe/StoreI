using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	public class Test0002
	{
		public void Test01()
		{
			Test01_a("01", 80, 96);
			Test01_a("02", 80, 96);
			Test01_a("03", 80, 96);
			Test01_a("05", 80, 96);
			Test01_a("13", 96, 96);
			Test01_a("18", 120, 96);
			Test01_a("20", 152, 128);
			Test01_a("21", 168, 128);
			Test01_a("22", 152, 128);
			Test01_a("23", 168, 128);
			Test01_a("24", 128, 128);
			Test01_a("25", 144, 144);
			Test01_a("26", 144, 144);
		}

		private void Test01_a(string s_no, int piece_w, int piece_h)
		{
			string file = @"C:\home\Resource\オオバコ\tewi\tewi_material" + s_no + ".png";

			Canvas canvas = Canvas.LoadFromFile(file);

			int c = 1;
			for (int t = 0; t < canvas.H; t += piece_h)
			{
				for (int l = 0; l < canvas.W; l += piece_w)
				{
					Canvas piece = canvas.GetSubImage(new I4Rect(l, t, piece_w, piece_h));
					BgTrans(piece);
					piece.Save(Path.Combine(SCommon.GetOutputDir(), "tewi" + s_no + (c++).ToString("D2") + ".png"));
				}
			}
		}

		private void BgTrans(Canvas canvas)
		{
			I4Color leftTopDot = canvas[0, 0];
			bool allTransFlag = true;

			for (int x = 0; x < canvas.W; x++)
			{
				for (int y = 0; y < canvas.H; y++)
				{
					I4Color dot = canvas[x, y];

					if (
						dot.R == leftTopDot.R &&
						dot.G == leftTopDot.G &&
						dot.B == leftTopDot.B
						)
						dot.A = 0;
					else
						allTransFlag = false;

					canvas[x, y] = dot;
				}
			}

			if (allTransFlag)
				canvas.Fill(new I4Color(192, 128, 64, 255));
		}

		public void Test02()
		{
			foreach (string file in Directory.GetFiles(@"C:\home\Resource\かんなにらせ", "*.jpg"))
			{
				Canvas canvas = Canvas.LoadFromFile(file);
				canvas = canvas.Expand(1000, 750);
				canvas.Save(Path.Combine(SCommon.GetOutputDir(), Path.GetFileNameWithoutExtension(file) + ".png"));
			}
		}
	}
}
