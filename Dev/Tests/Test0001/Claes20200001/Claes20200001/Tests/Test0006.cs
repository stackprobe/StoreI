using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0006
	{
		private const string R_ROOT_DIR = @"C:\home\GitHub\StoreJ";
		private const string W_ROOT_DIR = @"C:\home\GitHub\StoreI";

		public void Test01()
		{
			if (!Directory.Exists(R_ROOT_DIR))
				throw new Exception("no R_ROOT_DIR");

			if (!Directory.Exists(W_ROOT_DIR))
				throw new Exception("no W_ROOT_DIR");

			foreach (string dir in Directory.GetDirectories(W_ROOT_DIR))
			{
				if (Path.GetFileName(dir)[0] == '.') // 除外
					continue;

				SCommon.DeletePath(dir);
			}
			foreach (string file in Directory.GetFiles(W_ROOT_DIR))
			{
				if (Path.GetFileName(file)[0] == '.') // 除外
					continue;

				SCommon.DeletePath(file);
			}

			foreach (string dir in Directory.GetDirectories(R_ROOT_DIR))
			{
				if (Path.GetFileName(dir)[0] == '.') // 除外
					continue;

				SCommon.CopyDir(dir, SCommon.ChangeRoot(dir, R_ROOT_DIR, W_ROOT_DIR));
			}
			foreach (string file in Directory.GetFiles(R_ROOT_DIR))
			{
				if (Path.GetFileName(file)[0] == '.') // 除外
					continue;

				File.Copy(file, SCommon.ChangeRoot(file, R_ROOT_DIR, W_ROOT_DIR));
			}

			{
				Queue<string[]> q = new Queue<string[]>();

				q.Enqueue(Directory.GetDirectories(W_ROOT_DIR).Where(dir => Path.GetFileName(dir)[0] != '.').ToArray());

				while (1 <= q.Count)
				{
					foreach (string dir in q.Dequeue())
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
							q.Enqueue(Directory.GetDirectories(dir));
						}
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
