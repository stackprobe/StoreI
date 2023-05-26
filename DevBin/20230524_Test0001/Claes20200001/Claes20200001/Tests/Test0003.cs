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
	public class Test0003
	{
		private class PostImageInfo
		{
			public string FileName;
			public bool ExistFlag = false;

			// ----

			//public I2Size Size;
			//public bool FairIamgeFlag;
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

			/*
			ProcMain.WriteLog("CHECK-IMAGE-ST");
			foreach (PostInfo post in Posts)
			{
				foreach (PostImageInfo image in post.Images)
				{
					if (image.ExistFlag)
					{
						ProcMain.WriteLog("CI-file: " + image.FileName);
						try
						{
							int w;
							int h;
							Color lt;
							Color rt;
							Color rb;
							Color lb;

							using (Bitmap bmp = (Bitmap)Bitmap.FromFile(Path.Combine(@"C:\削除予定\20230514_dairi\Images", image.FileName)))
							{
								w = bmp.Width;
								h = bmp.Height;
								lt = bmp.GetPixel(0, 0);
								rt = bmp.GetPixel(w - 1, 0);
								rb = bmp.GetPixel(w - 1, h - 1);
								lb = bmp.GetPixel(0, h - 1);
							}

							image.Size = new I2Size(w, h);
							image.FairIamgeFlag =
								lt.A == 0 &&
								rt.A == 0 &&
								rb.A == 0 &&
								lb.A == 0; // ? 4隅に透過がある。
						}
						catch
						{
							image.Size = new I2Size(0, 0);
							image.FairIamgeFlag = false;
						}
					}
				}
			}
			ProcMain.WriteLog("CHECK-IMAGE-ED");
			 * */

			List<PostInfo> Posts_Collected =
				Posts.Where(post => post.Images.Any(image => image.ExistFlag)).ToList();
			List<PostInfo> Posts_Uncollected =
				Posts.Where(post => !post.Images.Any(image => image.ExistFlag)).ToList();

			File.WriteAllLines(
				Path.Combine(SCommon.GetOutputDir(), "不明なファイル.txt"),
				imagesDirFileNameList,
				Encoding.UTF8
				);

			File.WriteAllLines(
				Path.Combine(SCommon.GetOutputDir(), "収録されていない.txt"),
				Posts_Uncollected.Select(post => string.Join(", ", post.Serial, post.ImageCount, post.Title)),
				Encoding.UTF8
				);

			/*
			File.WriteAllLines(
				Path.Combine(SCommon.GetOutputDir(), "破損しているかもしれない.txt"),
				Posts_Collected.Where(post => IsImageBroken(post)).Select(post => string.Join(", ", post.Serial, post.ImageCount, post.Title)),
				Encoding.UTF8
				);
			 * */

			{
				List<string> lines = new List<string>();

				foreach (PostInfo post in Posts_Collected)
					foreach (PostImageInfo image in post.Images)
						if (!image.ExistFlag)
							lines.Add(post.Title + " ==> " + image.FileName);

				File.WriteAllLines(
					Path.Combine(SCommon.GetOutputDir(), "欠損しているファイル.txt"),
					lines,
					Encoding.UTF8
					);
			}

			File.WriteAllLines(
				Path.Combine(SCommon.GetOutputDir(), "(option)収録されている.txt"),
				Posts_Collected.Select(post => post.Title),
				Encoding.UTF8
				);

			File.WriteAllLines(
				Path.Combine(SCommon.GetOutputDir(), "(option)カタログ.txt"),
				Posts.Select(post => string.Join(", ", post.Serial, post.ImageCount, post.Title)),
				Encoding.UTF8
				);
		}

		/*
		private bool IsImageBroken(PostInfo post)
		{
			PostImageInfo[] images = post.Images.Where(image => image.ExistFlag).ToArray();

			foreach (PostImageInfo image in images)
				if (!image.FairIamgeFlag)
					return true;

			for (int index = 1; index < images.Length; index++)
			{
				PostImageInfo firstImage = images[0];
				PostImageInfo image = images[index];

				if (firstImage.Size.W != image.Size.W)
					return true;

				if (firstImage.Size.H != image.Size.H)
					return true;
			}
			return false;
		}
		 * */
	}
}
