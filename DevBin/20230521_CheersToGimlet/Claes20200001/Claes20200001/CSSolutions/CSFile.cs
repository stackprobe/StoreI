using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.CSSolutions
{
	public class CSFile
	{
		public string FilePath;

		public CSFile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new Exception("Bad filePath");

			if (!File.Exists(filePath))
				throw new Exception("no filePath");

			this.FilePath = filePath;
		}

		public string GetClassName()
		{
			return Path.GetFileNameWithoutExtension(this.FilePath);
		}

		public void SourceFileMoved(string filePath)
		{
			this.FilePath = filePath;
		}

		public string 新しい名前空間;

		public void Confuse(CSSolution sol)
		{
			string[] lines = File.ReadAllLines(this.FilePath, Encoding.UTF8);

			for (int index = 0; index < lines.Length; index++)
			{
				string line = lines[index];

				if (line.StartsWith("using Charlotte."))
					line = "";

				if (line.StartsWith("namespace "))
					line = "namespace " + this.新しい名前空間;

				// ★拡張：コードの置き換え
				{
					string[] isld = SCommon.ParseIsland(line, "// $$_CheersToGimlet:");

					if (isld != null)
					{
						line = isld[2].Trim();
					}
				}

				lines[index] = line;
			}

			lines = sol.新しい名前空間リスト.Select(ns => "using " + ns + ";").Concat(lines).ToArray();

			this.静的クラスの解除(lines);

			File.WriteAllLines(this.FilePath, lines, Encoding.UTF8);

			// ----

			string designerFile = SCommon.ChangeExt(this.FilePath, ".Designer.cs");

			if (File.Exists(designerFile))
			{
				lines = File.ReadAllLines(designerFile, Encoding.UTF8);

				for (int index = 0; index < lines.Length; index++)
				{
					string line = lines[index];

					if (line.StartsWith("namespace "))
						line = "namespace " + this.新しい名前空間;

					lines[index] = line;
				}

				File.WriteAllLines(designerFile, lines, Encoding.UTF8);
			}
		}

		private void 静的クラスの解除(string[] lines)
		{
			if (SCommon.EqualsIgnoreCase(this.GetClassName(), "Extensions")) // 除外
				return;

			for (int index = 0; index + 1 < lines.Length; index++)
			{
				if (
					lines[index + 0].StartsWith("\tpublic static class ") &&
					lines[index + 1] == "\t{"
					)
				{
					lines[index + 0] = "";
					lines[index + 1] = @"

public class ${class-name}
{
	private ${class-name}()
	{ }

	private static ${class-name} ${instance-variable} = null;

	public static ${class-name} ${instance-getter}()
	{
		if (${instance-variable} == null)
			${instance-variable} = new ${class-name}();

		return ${instance-variable};
	}

"
					.Replace("${class-name}", this.GetClassName())
					.Replace("${instance-getter}", "GetInstance__0011__CheersToGimlet")  // ★名前が被ったら変える必要あり。
					.Replace("${instance-variable}", "_instance__0011__CheersToGimlet"); // ★名前が被ったら変える必要あり。

					break;
				}
			}
		}
	}
}
