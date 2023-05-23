using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Charlotte.Commons;

namespace Charlotte
{
	class Program
	{
		static void Main(string[] args)
		{
			ProcMain.CUIMain(new Program().Main2);
		}

		private void Main2(ArgsReader ar)
		{
			if (ProcMain.DEBUG)
			{
				Main3();
			}
			else
			{
				Main4(ar);
			}
			SCommon.OpenOutputDirIfCreated();
		}

		private void Main3()
		{
			// テスト系 -- リリース版では使用しない。
#if DEBUG
			// -- choose one --

			Main4(new ArgsReader(new string[] { "Dev", "J" }));
			//Main4(new ArgsReader(new string[] { "DevBin", "J" }));
			//Main4(new ArgsReader(new string[] { }));
			//Main4(new ArgsReader(new string[] { }));

			// --
#endif
			SCommon.Pause();
		}

		private void Main4(ArgsReader ar)
		{
			try
			{
				Main5(ar);
			}
			catch (Exception ex)
			{
				ProcMain.WriteLog(ex);

				MessageBox.Show("" + ex, Path.GetFileNameWithoutExtension(ProcMain.SelfFile) + " / エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

				//Console.WriteLine("Press ENTER key. (エラーによりプログラムを終了します)");
				//Console.ReadLine();
			}
		}

		private string R_RootDir;
		private string W_RootDir;

		private void Main5(ArgsReader ar)
		{
			string devDirName = ar.NextArg();
			string alpha = ar.NextArg();

			ar.End();

			if (!SCommon.IsFairLocalPath(devDirName, -1))
				throw new Exception("Bad devDirName");

			if (!Regex.IsMatch(alpha, "^[A-Z]$"))
				throw new Exception("Bad alpha");

			R_RootDir = string.Format(Consts.R_ROOT_DIR_FORMAT, devDirName);
			W_RootDir = string.Format(Consts.W_ROOT_DIR_FORMAT, devDirName, alpha);

			ProcMain.WriteLog("< " + R_RootDir);
			ProcMain.WriteLog("> " + W_RootDir);

			if (!Directory.Exists(R_RootDir))
				throw new Exception("no R_RootDir");

			if (!Directory.Exists(W_RootDir))
				throw new Exception("no W_RootDir");

			ProcMain.WriteLog("start!");

			// 出力先(全)クリア
			SCommon.DeletePath(W_RootDir);
			SCommon.CreateDir(W_RootDir);

			Queue<string> q = new Queue<string>();

			q.Enqueue(R_RootDir);

			while (1 <= q.Count)
			{
				foreach (string dir in Directory.GetDirectories(q.Dequeue()))
				{
					if (IsProjectDir(dir))
					{
						CopyProjectDir(dir);
					}
					else
					{
						SCommon.CreateDir(SCommon.ChangeRoot(dir, R_RootDir, W_RootDir));
						q.Enqueue(dir);
					}
				}
			}
			ProcMain.WriteLog("done!");
		}

		private bool IsProjectDir(string estProjectDir)
		{
			return Directory.GetDirectories(estProjectDir).Any(dir => Regex.IsMatch(Path.GetFileName(dir), Consts.SRC_LOCAL_DIR_FORMAT));
		}

		private void CopyProjectDir(string projectDir)
		{
			CopySourceDir(projectDir);

			CopyBatchFile(projectDir, "Clean.bat");
			CopyBatchFile(projectDir, "Release.bat");

			CopyResourceDir(projectDir, "dat", true);
			CopyResourceDir(projectDir, "res", true);
			CopyResourceDir(projectDir, "doc", false);

			CopyOtherResourceFiles(projectDir);
			CopyOtherResourceDirs(projectDir);
		}

		private void CopySourceDir(string projectDir)
		{
			string[] rDirs = Directory.GetDirectories(projectDir)
				.Where(dir => Regex.IsMatch(Path.GetFileName(dir), Consts.SRC_LOCAL_DIR_FORMAT))
				.ToArray();

			foreach (string rDir in rDirs)
			{
				string wDir = SCommon.ChangeRoot(rDir, R_RootDir, W_RootDir);

				ProcMain.WriteLog("< " + rDir);
				ProcMain.WriteLog("> " + wDir);

				SCommon.CopyDir(rDir, wDir);
			}
		}

		private void CopyBatchFile(string projectDir, string batchLocalName)
		{
			string rFile = Path.Combine(projectDir, batchLocalName);
			string wFile = SCommon.ChangeRoot(rFile, R_RootDir, W_RootDir);

			if (File.Exists(rFile))
			{
				ProcMain.WriteLog("< " + rFile);
				ProcMain.WriteLog("> " + wFile);

				File.Copy(rFile, wFile);
			}
		}

		private void CopyOtherResourceFiles(string projectDir)
		{
			foreach (string rFile in Directory.GetFiles(projectDir))
			{
				string wFile = SCommon.ChangeRoot(rFile, R_RootDir, W_RootDir);

				if (!Common.ExistsPath(wFile))
				{
					ProcMain.WriteLog("< " + rFile);
					ProcMain.WriteLog("> " + wFile);

					File.Copy(rFile, wFile);
				}
			}
		}

		private void CopyResourceDir(string projectDir, string resourceRelDir, bool outputFileListMode)
		{
			string rDir = Path.Combine(projectDir, resourceRelDir);

			if (Directory.Exists(rDir))
			{
				string wDir = SCommon.ChangeRoot(rDir, R_RootDir, W_RootDir);

				if (outputFileListMode)
				{
					ProcMain.WriteLog("< " + rDir);
					ProcMain.WriteLog("T " + wDir);

					string treeFile = Path.Combine(wDir, "_Tree.txt");
					string[] treeFileData = MakeTreeFileData(rDir);

					SCommon.CreateDir(wDir);

					File.WriteAllLines(treeFile, treeFileData, Encoding.UTF8);
				}
				else
				{
					ProcMain.WriteLog("< " + rDir);
					ProcMain.WriteLog("> " + wDir);

					SCommon.CopyDir(rDir, wDir);
				}
			}
		}

		private void CopyOtherResourceDirs(string projectDir)
		{
			foreach (string rDir in Directory.GetDirectories(projectDir))
			{
				string wDir = SCommon.ChangeRoot(rDir, R_RootDir, W_RootDir);

				if (!Common.ExistsPath(wDir))
				{
					ProcMain.WriteLog("< " + rDir);
					ProcMain.WriteLog("T " + wDir);

					string treeFile = Path.Combine(wDir, "_Tree.txt");
					string[] treeFileData = MakeTreeFileData(rDir);

					SCommon.CreateDir(wDir);

					File.WriteAllLines(treeFile, treeFileData, Encoding.UTF8);
				}
			}
		}

		private string[] MakeTreeFileData(string targDir)
		{
			string[] paths = Directory.GetDirectories(targDir, "*", SearchOption.AllDirectories)
				.Concat(Directory.GetFiles(targDir, "*", SearchOption.AllDirectories))
				.OrderBy(SCommon.Comp)
				.ToArray();

			List<string> dest = new List<string>();

			foreach (string path in paths)
			{
				dest.Add(SCommon.ChangeRoot(path, targDir));

				if (Directory.Exists(path))
				{
					dest.Add("\t-> Directory");
				}
				else
				{
					FileInfo info = new FileInfo(path);

					dest.Add(string.Format(
						"\t-> File {0} / {1} / {2:#,0}"
						, SCommon.SimpleDateTime.FromTimeStamp(19700101000000L) //, new SCommon.SimpleDateTime(info.CreationTime)
						, new SCommon.SimpleDateTime(info.LastWriteTime)
						, info.Length
						));
				}
			}

			if (dest.Count == 0)
				dest.Add("Nothing");

			return dest.ToArray();
		}
	}
}
