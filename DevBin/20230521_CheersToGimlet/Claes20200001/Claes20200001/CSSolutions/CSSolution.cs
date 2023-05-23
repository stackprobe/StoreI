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
						, index % 2 + 1
						, index % 3 + 3
						, index % 5 + 6
						);
				}
			}
			this.新しい名前空間リスト = this.CSFiles.Select(file => file.新しい名前空間).DistinctOrderBy(SCommon.CompIgnoreCase).ToArray();

			foreach (CSFile file in this.CSFiles)
			{
				file.Confuse(this);
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
