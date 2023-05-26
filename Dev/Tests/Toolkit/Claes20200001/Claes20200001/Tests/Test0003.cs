using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0003
	{
		private const string R_ROOT_DIR = @"C:\home\GitHub\StoreJ";
		private const string W_ROOT_DIR = @"C:\home\GitHub\StoreI";

		public void Test01()
		{
			if (!Directory.Exists(R_ROOT_DIR))
				throw new Exception("no R_ROOT_DIR");

			if (!Directory.Exists(W_ROOT_DIR))
				throw new Exception("no W_ROOT_DIR");

			Console.WriteLine("start!!");

			CopyDirectory("Dev");
			CopySubDirectories("DevBin");
			CopyDirectory("Factory");

			Console.WriteLine("done!!");
		}

		private void CopySubDirectories(string relDir)
		{
			string rDir = Path.Combine(R_ROOT_DIR, relDir);
			string wDir = Path.Combine(W_ROOT_DIR, relDir);

			Console.WriteLine("< " + rDir);
			Console.WriteLine("D " + wDir);

			if (!Directory.Exists(rDir))
				throw new Exception("no rDir");

			//SCommon.DeletePath(wDir); // 既にコピーされたプロジェクトを削除しない。
			SCommon.CreateDir(wDir);

			foreach (string subDir in Directory.GetDirectories(rDir))
				CopyDirectory(SCommon.ChangeRoot(subDir, R_ROOT_DIR));

			Console.WriteLine("done!");
		}

		private void CopyDirectory(string relDir)
		{
			string rDir = Path.Combine(R_ROOT_DIR, relDir);
			string wDir = Path.Combine(W_ROOT_DIR, relDir);

			Console.WriteLine("< " + rDir);
			Console.WriteLine("> " + wDir);

			if (!Directory.Exists(rDir))
				throw new Exception("no rDir");

			SCommon.DeletePath(wDir);
			SCommon.CopyDir(rDir, wDir);

			PostCopyDirectory(wDir);

			Console.WriteLine("done");
		}

		private void PostCopyDirectory(string targDir)
		{
			Queue<string> q = new Queue<string>();

			q.Enqueue(targDir);

			while (1 <= q.Count)
			{
				foreach (string dir in Directory.GetDirectories(q.Dequeue()))
				{
					if (SCommon.EqualsIgnoreCase(Path.GetFileName(dir), "doc"))
					{
						string treeFile = Path.Combine(dir, "_Tree.txt");
						string[] treeFileData = MakeTreeFileData(dir);

						SCommon.DeletePath(dir);
						SCommon.CreateDir(dir);

						File.WriteAllLines(treeFile, treeFileData, Encoding.UTF8);
					}
					else
					{
						q.Enqueue(dir);
					}
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
						, SCommon.SimpleDateTime.FromTimeStamp(19700101000000L) //, new SCommon.SimpleDateTime(info.LastWriteTime)
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
