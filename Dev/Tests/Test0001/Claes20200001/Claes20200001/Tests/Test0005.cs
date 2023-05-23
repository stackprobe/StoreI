using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;
using Charlotte.Drawings;
using Charlotte.Utilities;
using System.Text.RegularExpressions;

namespace Charlotte.Tests
{
	public class Test0005
	{
		public void Test01()
		{
			const int TILE_W = 32;
			const int TILE_H = 32;

			Canvas canvas = Canvas.LoadFromFile(@"C:\home\Resource\ぴぽや倉庫(GrassRiverTree)\_orig\[Base]BaseChip_pipo.png");

			for (int y = 0; y < canvas.H; y += TILE_H)
			{
				for (int x = 0; x < canvas.W; x += TILE_W)
				{
					canvas.GetSubImage(new I4Rect(x, y, TILE_W, TILE_H))
						.Save(Path.Combine(SCommon.GetOutputDir(), string.Format("Tile_{0:D2}{1:D2}.png", x / TILE_W, y / TILE_H)));
				}
			}
		}

		public void Test02()
		{
			const int TILE_W = 24;
			const int TILE_H = 32;

			foreach (string file in Directory.GetFiles(@"C:\home\Resource\点睛集積(東方キャラ歩行チップ)\_orig", "*.png"))
			{
				Canvas canvas = Canvas.LoadFromFile(file);

				for (int y = 0; y < canvas.H; y += TILE_H)
				{
					for (int x = 0; x < canvas.W; x += TILE_W)
					{
						canvas.GetSubImage(new I4Rect(x, y, TILE_W, TILE_H))
							.Save(Path.Combine(SCommon.GetOutputDir(), string.Format("{0}_{1:D2}{2:D2}.png"
								, Path.GetFileNameWithoutExtension(file)
								, x / TILE_W
								, y / TILE_H
								)));
					}
				}
			}
		}

		public void Test03()
		{
			Test03_a(@"C:\Users\mt\Desktop\00_SSAGame\dat\res\World\Map\Tests\t0001.txt");
			Test03_a(@"C:\Users\mt\Desktop\00_SSAGame\dat\res\World\Map\Tests\t0002.txt");
			Test03_a(@"C:\Users\mt\Desktop\00_SSAGame\dat\res\World\Map\Tests\t0003.txt");
			Test03_a(@"C:\Users\mt\Desktop\00_SSAGame\dat\res\World\Map\Tests\t0004.txt");
			Test03_a(@"C:\Users\mt\Desktop\00_SSAGame\dat\res\World\Map\Tests\t0005.txt");

			Test03_a(@"C:\Users\mt\Desktop\00_TVAGame\dat\res\World\Map\Tests\t0001.txt");
			Test03_a(@"C:\Users\mt\Desktop\00_TVAGame\dat\res\World\Map\Tests\t0002.txt");
			Test03_a(@"C:\Users\mt\Desktop\00_TVAGame\dat\res\World\Map\Tests\t0003.txt");
			Test03_a(@"C:\Users\mt\Desktop\00_TVAGame\dat\res\World\Map\Tests\t0004.txt");
		}

		private void Test03_a(string file)
		{
			string[] lines = File.ReadAllLines(file, SCommon.ENCODING_SJIS);
			int c = 0;

			int w = int.Parse(lines[c++]);
			int h = int.Parse(lines[c++]);

			char[,] table = new char[w, h];

			for (int x = 0; x < w; x++)
			{
				for (int y = 0; y < h; y++)
				{
					string line = lines[c++];
					string[] tokens = SCommon.Tokenize(line, "\t");

					if (tokens.Length != 3)
						throw null;

					table[x, y] = tokens[1] == "None" || tokens[1] == "芝" ? '・' : tokens[1] == "水辺" ? '～' : '＠';
				}
			}

			List<string> rows = new List<string>();

			for (int y = 0; y < h; y++)
			{
				StringBuilder buff = new StringBuilder();

				for (int x = 0; x < w; x++)
				{
					buff.Append(table[x, y]);
				}
				rows.Add(buff.ToString());
			}
			File.WriteAllLines(SCommon.NextOutputPath() + ".txt", rows, SCommon.ENCODING_SJIS);
		}

		public void Test04()
		{
			#region Resource

			string RES_LINES = @"

daily01.html
生活上の動作・その１
daily02.html
生活上の動作・その２
putting01.html
置く・持ち上げる
electric01.html
生活家電
cooking01.html
料理・台所
eating01.html
食事
openclose01.html
開ける閉める
nature01.html
自然・季節・昆虫
animals01.html
動物
human01.html
人間・足音
sports01.html
スポーツ・大会・学校
game01.html
ゲーム・ボタン音
anime01.html
ゲーム・アニメ調
magic01.html
魔法・ファンタジー
sf01.html
SF・ロボット
jidaigeki01.html
時代劇・歴史物
attack01.html
打撃・攻撃
arms01.html
兵器・爆発
horror01.html
ホラー・心理系
horror02.html
ホラー・生音系
monster01.html
怪物・悪魔・竜
noise01.html
ノイズ・空調
acoustica.html
ACOUSTICA
playing01.html
楽器・遊び
event01.html
イベント・お祭り・宴会
enviroment01.html
街の環境音（日常系）
enviroment02.html
街の環境音（騒音系）
car01.html
自動車
transfer01.html
乗り物・交通機関
us01.html
海外の音１ アメリカ/ニューヨーク
french01.html
海外の音２ フランス（ヨーロッパ）

";

			#endregion

			string[] lines = SCommon.TextToLines(RES_LINES).Where(line => line != "").ToArray();

			for (int index = 0; index < lines.Length; )
			{
				string htmlName = lines[index++];
				string title = lines[index++];

				title = SCommon.ToFairLocalPath(title, -1);

				string html = SCommon.ENCODING_SJIS.GetString(Download("https://taira-komori.jpn.org/" + htmlName));

				//Console.WriteLine(html); // test

				for (; ; )
				{
					string[] isld = SCommon.ParseIsland(html, ".mp3\"");

					if (isld == null)
						break;

					string text = isld[0];
					html = isld[2];

					int p = text.LastIndexOf("src=\"");

					if (p == -1)
						continue;

					string soundRelPath = text.Substring(p + 5) + ".mp3";
					string soundRelPathYen = soundRelPath.Replace('/', '\\');

					if (!SCommon.IsFairRelPath(soundRelPathYen, -1))
					{
						Console.WriteLine("★除外：" + soundRelPath);
						continue;
					}
					string soundTitle = Path.GetFileNameWithoutExtension(soundRelPathYen);
					soundTitle = SCommon.ToFairLocalPath(soundTitle, -1);

					//Console.WriteLine(soundTitle); // test
					//Console.WriteLine(soundRelPath); // test

					//byte[] soundData = Download("https://taira-komori.jpn.org/" + soundRelPath);
					byte[] soundData = SCommon.EMPTY_BYTES; // test test test test test

					string destDir = Path.Combine(SCommon.GetOutputDir(), title);
					string destFile = Path.Combine(destDir, soundTitle + ".mp3");
					destFile = SCommon.ToCreatablePath(destFile);

					//Console.WriteLine("< " + soundData.Length);
					//Console.WriteLine("> " + destFile);

					SCommon.CreateDir(destDir);

					File.WriteAllBytes(destFile, soundData);
				}
				/*
				for (; ; )
				{
					string[] encl = SCommon.ParseEnclosed(html, "<TR>", "</TR>");

					if (encl == null)
						break;

					string tr = encl[2];
					html = encl[4];

					if (!tr.Contains(".mp3\""))
						continue;

					encl = SCommon.ParseEnclosed(tr, "<DIV align=\"right\">", "</DIV>");
					string soundTitle = encl == null ? null : encl[2];
					encl = SCommon.ParseEnclosed(tr, "<A href=\"", "\"");
					string soundRelPath = encl == null ? null : encl[2];

					//Console.WriteLine(soundTitle); // test
					//Console.WriteLine(soundRelPath); // test

					if (soundTitle == null && soundRelPath != null)
						soundTitle = Path.GetFileNameWithoutExtension(soundRelPath);

					soundTitle = SCommon.ToFairLocalPath(soundTitle, -1);

					// cout
					if (soundTitle == null || soundRelPath == null)
					{
						Console.WriteLine("★★★除外TRタグ★★★");
						Console.WriteLine("title: " + title);
						Console.WriteLine("soundTitle: " + soundTitle);
						Console.WriteLine("soundRelPath: " + soundRelPath);
					}

					byte[] soundData = Download("https://taira-komori.jpn.org/" + soundRelPath);

					string destDir = Path.Combine(SCommon.GetOutputDir(), title);
					string destFile = Path.Combine(destDir, soundTitle + ".mp3");

					Console.WriteLine("< " + soundData.Length);
					Console.WriteLine("> " + destFile);

					SCommon.CreateDir(destDir);

					if (File.Exists(destFile)) // ? ファイル名の重複
						throw null;

					File.WriteAllBytes(destFile, soundData);
				}
				 * */
			}
		}

		private byte[] Download(string url)
		{
			using (WorkingDir wd = new WorkingDir())
			{
				string resFile = wd.MakePath();

				HTTPClient hc = new HTTPClient(url);
				hc.ResFile = resFile;
				hc.Get();

				return File.ReadAllBytes(resFile);
			}
		}

		public void Test05()
		{
			foreach (string file in Directory.GetFiles(@"C:\temp"))
			{
				Canvas canvas = Canvas.LoadFromFile(file);

				canvas = canvas.Expand(960, 540);

				canvas.Save(Path.Combine(SCommon.GetOutputDir(), Path.GetFileNameWithoutExtension(file) + ".png"));
			}
		}

		public void Test06()
		{
			/*
			string[] lines = File.ReadAllLines(@"C:\temp\0001.txt", SCommon.ENCODING_SJIS);
			List<string> corr = new List<string>();
			List<string> inco = new List<string>();

			foreach (string line in lines)
			{
				if (Regex.IsMatch(line, "^([A-Z][a-z]* )*[A-Z][a-z]*$"))
					corr.Add(line);
				else
					inco.Add(line);
			}
			File.WriteAllLines(@"C:\temp\corr.txt", corr, SCommon.ENCODING_SJIS);
			File.WriteAllLines(@"C:\temp\inco.txt", inco, SCommon.ENCODING_SJIS);
			 * */

			string[] lines = File.ReadAllLines(@"C:\temp\0001.txt", SCommon.ENCODING_SJIS);

			lines = lines.DistinctOrderBy(SCommon.CompIgnoreCase).ToArray();

			File.WriteAllLines(@"C:\temp\0002.txt", lines, SCommon.ENCODING_SJIS);
		}
	}
}
