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
	public class Test0007
	{
		public void Test01()
		{
			foreach (string file in Directory.GetFiles(@"C:\temp", "*.png"))
			{
				Canvas canvas = Canvas.LoadFromFile(file);
				//canvas = canvas.Expand(540, 790);
				canvas = canvas.GetSubImage(new I4Rect(0, 0, 540, 790));
				canvas.Save(Path.Combine(SCommon.GetOutputDir(), Path.GetFileNameWithoutExtension(file) + ".png"));
			}
		}

		public void Test02()
		{
			foreach (string file in Directory.GetFiles(@"C:\Dev", "*.png", SearchOption.AllDirectories))
			{
				if (SCommon.EqualsIgnoreCase(Path.GetFileName(file), "TransparentBox.png"))
				{
					//Console.WriteLine(file); // cout

					Canvas canvas = Canvas.LoadFromFile(file);

					canvas.FilterAllDot((dot, x, y) =>
					{
						dot.A = 0;
						return dot;
					});

					canvas.Save(file);
				}
			}
		}

		public void Test03()
		{
			foreach (string file in Directory.GetFiles(@"C:\temp", "*", SearchOption.AllDirectories))
			{
				Canvas canvas = Canvas.LoadFromFile(file);

				//canvas = canvas.Expand(1000, 490);
				canvas = canvas.Expand(1000, 670);

				canvas.Save(SCommon.NextOutputPath() + ".png");
			}
		}
	}
}
