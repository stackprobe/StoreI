using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	/// <summary>
	/// SCommon.ParseEnclosed 使用例
	/// </summary>
	public class Test0017
	{
		private static string RES_TEXT = @"

<!DOCTYPE html>
<html>
	<head>
		<title>Example of Strong Tag</title>
	</head>
	<body>
		<h1>Emphasizing Text</h1>
		<p>There is an <strong>important</strong> section in this document.</p>
		<p>In this paragraph, we will use a word that we want to <strong>emphasize</strong>.</p>
		<p>Finally, we have something to say <strong>loud and clear</strong>.</p>
	</body>
</html>

";

		// memo:
		// 戻り値の要素数：
		// SCommon.ParseIsland   --> 3 -- { タグの前, タグ, タグの後 }
		// SCommon.ParseEnclosed --> 5 -- { 開始タグの前, 開始タグ, タグの間, 終了タグ, 終了タグの後 }
		// SCommon.GetIsland     --> 2 -- { タグの開始位置, タグの終了位置(*) }
		// SCommon.GetEnclosed   --> 4 -- { 開始タグの開始位置, 開始タグの終了位置(*), 終了タグの開始位置, 終了タグの終了位置(*) }
		//
		// * 終了位置 == 最後の文字の次の位置

		public void Test01()
		{
			string text = RES_TEXT;

			for (; ; )
			{
				string[] encl = SCommon.ParseEnclosed(text, "<strong>", "</strong>"); // 次の <strong> ... </strong> を探す。

				if (encl == null) // ? 見つからなかった。-> 検索終了
					break;

				string innerText = encl[2]; // <strong> と </strong> の間の部分

				Console.WriteLine("innerText = \"" + innerText + "\"");

				text = encl[4]; // </strong> 以降
			}
			Console.WriteLine("done! (TEST-0017-01)");
		}
	}
}
