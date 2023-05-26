using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.CSSolutions
{
	public class CSSolution
	{
		public string Dir;
		public string Name;
		public string MSVSSolutionFile;
		public string ProjectDir;
		public string ProjectFile;
		public string OutputFile;
		public List<CSFile> CSFiles = new List<CSFile>();

		public CSSolution(string dir, string name)
		{
			if (string.IsNullOrEmpty(dir))
				throw new Exception("Bad dir");

			if (!Directory.Exists(dir))
				throw new Exception("no dir");

			if (string.IsNullOrEmpty(name))
				throw new Exception("Bad name");

			this.Dir = dir;
			this.Name = name;
			this.MSVSSolutionFile = Path.Combine(dir, name + ".sln");
			this.ProjectDir = Path.Combine(dir, name);
			this.ProjectFile = Path.Combine(dir, name, name + ".csproj");
			this.OutputFile = Path.Combine(dir, name, "bin", "Release", name + ".exe");

			if (!File.Exists(this.MSVSSolutionFile))
				throw new Exception("no MSVSSolutionFile");

			if (!Directory.Exists(this.ProjectDir))
				throw new Exception("no ProjectDir");

			if (!File.Exists(this.ProjectFile))
				throw new Exception("no ProjectFile");

			this.Clean(); // ごみファイルをソースファイル(*.cs)として拾わないように先ずクリーンする必要がある。

			foreach (string file in Directory.GetFiles(this.ProjectDir, "*.cs", SearchOption.AllDirectories).OrderBy(SCommon.CompIgnoreCase))
			{
				if (SCommon.ContainsIgnoreCase(file, "\\Properties\\")) // 除外
					continue;

				if (SCommon.EndsWithIgnoreCase(file, ".Designer.cs")) // 除外
					continue;

				this.CSFiles.Add(new CSFile(file));
			}

			// ★名前空間をめちゃくちゃに置き換えるので、クラス名の重複は不可
			//
			if (SCommon.HasSame(this.CSFiles, (a, b) => SCommon.EqualsIgnoreCase(
				a.GetClassName(),
				b.GetClassName()
				)))
				throw new Exception("想定外：クラス名の重複");
		}

		public void Clean()
		{
			ProcMain.WriteLog("Clean-ST");
			SCommon.CreateDir(SCommon.ToParentPath(this.OutputFile));
			File.WriteAllBytes(this.OutputFile, SCommon.EMPTY_BYTES);
			SCommon.Batch(
				new string[]
				{
					"CALL C:\\Factory\\SetEnv.bat",
					"CALL qq",
				},
				this.Dir,
				SCommon.StartProcessWindowStyle_e.MINIMIZED
				);

			if (File.Exists(this.OutputFile))
				throw new Exception("クリーンに失敗しました。");

			ProcMain.WriteLog("Clean-ED");
		}

		public string[] 新しい名前空間リスト;

		public void Confuse()
		{
			new CSProject(this.ProjectDir, this.ProjectFile).Confuse(this);

			for (int index = 0; index < this.CSFiles.Count; index++)
			{
				CSFile file = this.CSFiles[index];

				if (SCommon.EqualsIgnoreCase(file.GetClassName(), "Extensions"))
				{
					file.新しい名前空間 = "Charlotte";
				}
				else
				{
					file.新しい名前空間 = string.Format("Charlotte.Gattonero{0:D4}.Gattonero{1:D4}.Gattonero{2:D4}"
						, index % 3 + 1
						, index % 5 + 4
						, index % 7 + 9
						);
				}
			}
			this.新しい名前空間リスト = this.CSFiles.Select(file => file.新しい名前空間).DistinctOrderBy(SCommon.CompIgnoreCase).ToArray();

			foreach (CSFile file in this.CSFiles)
			{
				file.Confuse(this);
			}

			// チェーン関数の作成
			{
				const string CHAIN_FUNC_PATTERN = "$$_CHAIN_FUNC_$$__0018__CheersToGimlet_{dcda66b1-416f-4419-a1e1-cd33513e3d37}";
				const string INSTANCE_GETTER_FUNC_NAME = "GetInstance__0019__CheersToGimlet"; // ★名前が被ったら変える必要あり。

				CSFile[] files = this.CSFiles.ToArray();
				files = files.Where(file => file.GetSourceCode().Contains(CHAIN_FUNC_PATTERN)).ToArray();
				Common.GeneralRandom.Shuffle(files);

				for (int index = 0; index < files.Length; index++)
				{
					CSFile file = files[index];
					string forwardClassName = files[(index + 1) % files.Length].GetClassName();
					string sourceCode = file.GetSourceCode();

					sourceCode = sourceCode.Replace(CHAIN_FUNC_PATTERN, @"

public string ${chain-func-name}(string repairerOfFences)
{
	foreach (var info in new[]
	{
		new { A = ${random-I0101}, S = ""${random-S0101}"", U = new { B = ${random-I0102}, T = ""${random-S0102}"" } },
		new { A = ${random-I0201}, S = ""${random-S0201}"", U = new { B = ${random-I0202}, T = ""${random-S0202}"" } },
		new { A = ${random-I0301}, S = ""${random-S0301}"", U = new { B = ${random-I0302}, T = ""${random-S0302}"" } },
	})
	{
		repairerOfFences += "", "" + ${forward-class-name}.${instance-getter-func-name}().${chain-func-name}(string.Join("", "", info.A, info.S, info.U.B, info.U.T));
	}
	return repairerOfFences;
}

"
						.Replace("${forward-class-name}", forwardClassName)
						.Replace("${instance-getter-func-name}", INSTANCE_GETTER_FUNC_NAME)
						.Replace("${random-I0101}", Common.GeneralRandom.GetRange(10000000, 99999999).ToString())
						.Replace("${random-I0102}", Common.GeneralRandom.GetRange(10000000, 99999999).ToString())
						.Replace("${random-I0201}", Common.GeneralRandom.GetRange(10000000, 99999999).ToString())
						.Replace("${random-I0202}", Common.GeneralRandom.GetRange(10000000, 99999999).ToString())
						.Replace("${random-I0301}", Common.GeneralRandom.GetRange(10000000, 99999999).ToString())
						.Replace("${random-I0302}", Common.GeneralRandom.GetRange(10000000, 99999999).ToString())
						.Replace("${random-S0101}", SCommon.Base32.I.Encode(Common.GeneralRandom.GetBytes(5)))
						.Replace("${random-S0102}", SCommon.Base32.I.Encode(Common.GeneralRandom.GetBytes(5)))
						.Replace("${random-S0201}", SCommon.Base32.I.Encode(Common.GeneralRandom.GetBytes(5)))
						.Replace("${random-S0202}", SCommon.Base32.I.Encode(Common.GeneralRandom.GetBytes(5)))
						.Replace("${random-S0301}", SCommon.Base32.I.Encode(Common.GeneralRandom.GetBytes(5)))
						.Replace("${random-S0302}", SCommon.Base32.I.Encode(Common.GeneralRandom.GetBytes(5)))
						.Replace("${chain-func-name}", "DestroyerOfFences__0018__CheersToGimlet") // ★名前が被ったら変える必要あり。
						);

					file.SetSourceCode(sourceCode);
				}
			}
		}

		public void Build()
		{
			ProcMain.WriteLog("Build-ST");
			SCommon.DeletePath(this.OutputFile);
			SCommon.Batch(
				new string[]
				{
					"CALL C:\\Factory\\SetEnv.bat",
					"cx **",
				},
				this.Dir,
				SCommon.StartProcessWindowStyle_e.MINIMIZED
				);

			if (!File.Exists(this.OutputFile))
				throw new Exception("ビルドに失敗しました。");

			ProcMain.WriteLog("Build-ED");
		}
	}
}
