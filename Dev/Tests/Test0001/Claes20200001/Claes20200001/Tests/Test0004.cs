using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	public class Test0004
	{
		private class PostImageInfo
		{
			public string FileName;
			public bool ExistFlag = false;
		}

		private class PostInfo
		{
			public string Serial;
			public string Title;
			public int ImageCount;

			// ----

			public List<PostImageInfo> Images = new List<PostImageInfo>();
		}

		private List<PostInfo> Posts = new List<PostInfo>();

		public void Test01()
		{
			foreach (string file in Directory.GetFiles(@"C:\削除予定\20230514_dairi\Pages"))
			{
				//Console.WriteLine(file); // cout

				string text = File.ReadAllText(file, Encoding.UTF8);
				string[] isld;
				string[] encl;

				for (; ; )
				{
					encl = SCommon.ParseEnclosed(text, "data-gtm-value=\"", "\"");

					if (encl == null)
						break;

					string serial = encl[2];
					text = encl[4];
					encl = null;

					isld = SCommon.ParseIsland(text, "sc-d98f2c-0 sc-iasfms-4 cwshsL");
					encl = SCommon.ParseEnclosed(isld[0], "</path></svg></span></span><span>", "</span>");
					int imageCount = encl == null ? 1 : int.Parse(encl[2]);
					encl = null;
					text = isld[2];
					isld = null;

					encl = SCommon.ParseEnclosed(text, ">", "<");
					string title = encl[2];
					text = encl[4];

					//Console.WriteLine(string.Join(", ", serial, imageCount, title)); // cout

					Posts.Add(new PostInfo()
					{
						Serial = serial,
						Title = title,
						ImageCount = imageCount,
					});
				}
			}

			//Console.WriteLine(Posts.Count); // cout // 781 @ 2023.5.14

			foreach (PostInfo post in Posts)
			{
				for (int index = 0; index < post.ImageCount; index++)
				{
					post.Images.Add(new PostImageInfo()
					{
						FileName = post.Serial + "_p" + index + ".png",
					});
				}
			}

			List<string> imagesDirFileNameList = Directory.GetFiles(@"C:\削除予定\20230514_dairi\Images")
				.Select(imageFile => Path.GetFileName(imageFile))
				.OrderBy(SCommon.Comp)
				.ToList();

			foreach (PostInfo post in Posts)
			{
				foreach (PostImageInfo image in post.Images)
				{
					int index = imagesDirFileNameList.IndexOf(image.FileName);

					if (index != -1)
					{
						SCommon.FastDesertElement(imagesDirFileNameList, index);
						image.ExistFlag = true;
					}
				}
			}
			imagesDirFileNameList.Sort(SCommon.Comp); // == 不明なファイル・リスト

			List<PostInfo> Posts_Collected =
				Posts.Where(post => post.Images.Any(image => image.ExistFlag)).ToList();
			List<PostInfo> Posts_Uncollected =
				Posts.Where(post => !post.Images.Any(image => image.ExistFlag)).ToList();

			// ====

			Posts = Posts_Collected;
			Posts_Collected = null;
			Posts_Uncollected = null;

			SCommon.ForEachPair(Posts, (a, b) =>
			{
				if (a.Serial == b.Serial || a.Title == b.Title)
				{
					ProcMain.WriteLog(a.Serial);
					ProcMain.WriteLog(b.Serial);
					ProcMain.WriteLog(a.Title);
					ProcMain.WriteLog(b.Title);

					//throw null;

					a.Title += "(2)";
					b.Title += "(1)";
				}
			});

			if (SCommon.HasSame(Posts, (a, b) => a.Serial == b.Serial || a.Title == b.Title))
				throw null;

			foreach (PostInfo post in Posts)
				SCommon.CreateDir(Path.Combine(SCommon.GetOutputDir(), post.Title));

			if (Directory.GetDirectories(SCommon.GetOutputDir()).Length != Posts.Count)
				throw null;

			foreach (PostInfo post in Posts)
			{
				foreach (PostImageInfo image in post.Images)
				{
					string rFile = Path.Combine(@"C:\削除予定\20230514_dairi\Images", image.FileName);
					string wFile = Path.Combine(SCommon.GetOutputDir(), post.Title, image.FileName);

					ProcMain.WriteLog("< " + rFile);
					ProcMain.WriteLog("> " + wFile);

					File.WriteAllBytes(wFile, File.ReadAllBytes(rFile));
				}
			}
			ProcMain.WriteLog("DONE");
		}
	}
}
