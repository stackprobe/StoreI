using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.CSSolutions
{
	public class CSProject
	{
		public string Dir;
		public string FilePath;

		public CSProject(string dir, string filePath)
		{
			if (string.IsNullOrEmpty(dir))
				throw new Exception("Bad dir");

			if (!Directory.Exists(dir))
				throw new Exception("no dir");

			if (string.IsNullOrEmpty(filePath))
				throw new Exception("Bad filePath");

			if (!File.Exists(filePath))
				throw new Exception("no filePath");

			this.Dir = dir;
			this.FilePath = filePath;
		}

		public void Confuse(CSSolution sol)
		{
			List<string> files = new List<string>();
			string classesDir = Path.Combine(this.Dir, "_Classes__9901__CheersToGimlet"); // ★名前が被ったら変える必要あり。

			SCommon.CreateDir(classesDir);

			if (SCommon.HasSame(Consts.IDENTIFIERS, (a, b) => SCommon.EqualsIgnoreCase(a, b)))
				throw new Exception("FATAL: 内部リソース・識別子の重複");

			foreach (string f_identifier in Consts.IDENTIFIERS)
			{
				string identifier = f_identifier;

				while (sol.CSFiles.Any(v => SCommon.EqualsIgnoreCase(v.GetClassName(), identifier))) // ? 既に存在するクラス名と被る -> 回避
					identifier += "_";

				string file = Path.Combine(classesDir, identifier + ".cs");

				// NOTE:
				// クラス名が標準クラスなどと被ってしまった場合を想定して、
				// せめてビルドエラーになって検出できるように、メンバ名は被りそうにない名前にする。コンストラクタも隠蔽する。
				//
				File.WriteAllText(file, @"

namespace Charlotte
{
	public class ${identifier}
	{
		public static System.Lazy<${identifier}> Instance__0017__CheersToGimlet = new System.Lazy<${identifier}>(() => Create${identifier}__0017__CheersToGimlet());

		private static ${identifier} Create${identifier}__0017__CheersToGimlet()
		{
			System.Func<${identifier}> creator = () => new ${identifier}(); return creator(); // return new ${identifier}();
		}

		private ${identifier}()
		{ }

		public string Get${identifier}__0017__CheersToGimlet()
		{
			return ""${identifier}"";
		}

		$$_CHAIN_FUNC_$$__0018__CheersToGimlet_{dcda66b1-416f-4419-a1e1-cd33513e3d37}

		public static ${identifier} GetInstance__0019__CheersToGimlet() // for CHAIN_FUNC
		{
			return Instance__0017__CheersToGimlet.Value;
		}
	}
}

"
					.Replace("${identifier}", identifier),
					Encoding.UTF8
					);

				files.Add(file);
			}

			// ----

			string text = File.ReadAllText(this.FilePath, Encoding.UTF8);
			string[] parts = SCommon.ParseIsland(text, "<Compile Include=\"Program.cs\" />"); // HACK: 雑な探し方

			if (parts == null)
				throw new Exception("no Program.cs");

			text =
				parts[0] +
				parts[1] +
				"\r\n" +
				string.Join("\r\n", files.Select(v => "<Compile Include=\"" + SCommon.ChangeRoot(v, this.Dir) + "\" />")) +
				parts[2];

			File.WriteAllText(this.FilePath, text, Encoding.UTF8);

			// ----

			sol.CSFiles.AddRange(files.Select(v => new CSFile(v)));

			sol.CSFiles.Sort((a, b) => SCommon.CompIgnoreCase(
				a.GetClassName(),
				b.GetClassName()
				));

			// ----

			this.CompileTagsFilter(list =>
			{
				this.CollectSourceFiles(list, classesDir, sol.CSFiles.ToArray());
				Common.GeneralRandom.Shuffle(list);
				return list;
			});
		}

		private void CompileTagsFilter(Func<string[], string[]> filter)
		{
			string src = File.ReadAllText(this.FilePath, Encoding.UTF8);
			StringBuilder dest = new StringBuilder();

			for (; ; )
			{
				string[] encl = SCommon.ParseEnclosed(src, "<ItemGroup>", "</ItemGroup>");

				if (encl == null)
				{
					dest.Append(src);
					break;
				}
				string inner = encl[2];

				if (inner.Contains("<Compile Include=\"Program.cs\" />")) // HACK: 雑な探し方
				{
					string[] innerList = this.CompileTagsSeparater(inner);
					innerList = filter(innerList);
					inner = string.Join("\r\n", innerList);
				}
				dest.Append(encl[0]);
				dest.Append(encl[1]);
				dest.Append(inner);
				dest.Append(encl[3]);
				src = encl[4];
			}
			File.WriteAllText(this.FilePath, dest.ToString(), Encoding.UTF8);
		}

		private string[] CompileTagsSeparater(string text)
		{
			string[] lines = SCommon.TextToLines(text)
				.Select(line => line.Trim())
				.Where(line => line != "")
				.ToArray();

			List<string> dest = new List<string>();

			for (int p = 0; p < lines.Length; )
			{
				int q = p + 1;

				if (lines[p].EndsWith("/>"))
				{
					// noop
				}
				else
				{
					while (!lines[q].StartsWith("</"))
						q++;

					q++;
				}
				dest.Add(string.Join("\r\n", SCommon.GetPart(lines, p, q - p)));
				p = q;
			}
			return dest.ToArray();
		}

		private void CollectSourceFiles(string[] compileTags, string classesDir, CSFile[] solCSFiles)
		{
			string[] SUB_DIR_NAMES = Enumerable.Range(1, CSF_GetSubDirNum(solCSFiles.Length))
				.Select(v => string.Format("_{0:D4}", v))
				.ToArray();

			foreach (string subDirName in SUB_DIR_NAMES)
				SCommon.CreateDir(Path.Combine(classesDir, subDirName));

			for (int index = 0; index < compileTags.Length; index++)
			{
				string compileTag = compileTags[index];

				if (compileTag.StartsWith("<Compile Include=\"") && compileTag.EndsWith(".cs\" />"))
				{
					string sourceFile = SCommon.ParseEnclosed(compileTag, "\"", "\"")[2];

					if (SCommon.IsFairRelPath(sourceFile, -1))
					{
						if (SCommon.StartsWithIgnoreCase(sourceFile, "Properties\\")) // 除外
							continue;

						sourceFile = Path.Combine(this.Dir, sourceFile);

						if (!File.Exists(sourceFile))
							throw new Exception("不正なコンパイル・タグ：存在しないファイル");

						string destSourceFile = Path.Combine(classesDir, SUB_DIR_NAMES[index % SUB_DIR_NAMES.Length], Path.GetFileName(sourceFile));

						if (SCommon.EqualsIgnoreCase(sourceFile, destSourceFile)) // ? 同じファイル -> 移動不要
							continue;

						if (File.Exists(destSourceFile))
							throw new Exception("不正なコンパイル・タグ：クラス名の衝突");

						File.Move(sourceFile, destSourceFile);
						compileTag = "<Compile Include=\"" + SCommon.ChangeRoot(destSourceFile, this.Dir) + "\" />";
						compileTags[index] = compileTag;

						// solCSFiles 同期
						{
							CSFile solCSFile = solCSFiles.FirstOrDefault(v => SCommon.EqualsIgnoreCase(v.FilePath, sourceFile));

							if (solCSFile == null)
								throw new Exception("不正なコンパイル・タグ：不明なクラス");

							solCSFile.SourceFileMoved(destSourceFile);
						}
					}
				}
			}
		}

		private int CSF_GetSubDirNum(int scale)
		{
			int count = 1;

			while (count * count < scale)
				count++;

			return count;
		}
	}
}
