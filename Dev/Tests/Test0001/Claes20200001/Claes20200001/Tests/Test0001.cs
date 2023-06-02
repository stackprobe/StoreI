using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			Console.WriteLine(Path.GetFullPath("C:\\ABC\\DEF"));
			Console.WriteLine(Path.GetFullPath("C:\\ABC"));
			Console.WriteLine(Path.GetFullPath("ABC\\DEF"));
			Console.WriteLine(Path.GetFullPath("DEF"));

			Console.WriteLine(Path.GetFullPath("C:\\ABC\\DEF\\"));
			Console.WriteLine(Path.GetFullPath("C:\\ABC\\"));
			Console.WriteLine(Path.GetFullPath("ABC\\DEF\\"));
			Console.WriteLine(Path.GetFullPath("DEF\\"));

			Console.WriteLine(Path.GetFullPath("C:\\ABC\\DEF\\."));
			Console.WriteLine(Path.GetFullPath("C:\\ABC\\."));
			Console.WriteLine(Path.GetFullPath("ABC\\DEF\\."));
			Console.WriteLine(Path.GetFullPath("DEF\\."));

			Console.WriteLine(Path.GetFullPath("C:\\"));
			Console.WriteLine(Path.GetFullPath("C:"));
			Console.WriteLine(Path.GetFullPath("\\"));
			Console.WriteLine(Path.GetFullPath("."));
			//Console.WriteLine(Path.GetFullPath("")); // 例外
			//Console.WriteLine(Path.GetFullPath(null)); // 例外
		}
	}
}
