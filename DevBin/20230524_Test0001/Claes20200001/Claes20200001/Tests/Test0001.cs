using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			//string text = "AAA<ABC>BBBB</ABC>CCCCC<ABC>DDDDDD</ABC>EEEEEEE<ABC></ABC><ABC>XXX</ABC><ABC></ABC>YYYZZZ111222333<ABC>7777777</ABC>";
			string text = "AAA<ABC>123</ABC>BBBB<ABC>4567</ABC>CCCCC<ABC>89012</ABC>DDDDDD";

			for (; ; )
			{
				string[] encl = SCommon.ParseEnclosed(text, "<ABC>", "</ABC>");

				if (encl == null)
					break;

				string innerText = encl[2];

				Console.WriteLine("[" + innerText + "]");

				text = encl[4];
			}
		}

		public void Test02()
		{
			using (MemoryStream reader = new MemoryStream(Enumerable.Range(1, 203).Select(chr => (byte)chr).ToArray()))
			{
				int c1 = reader.ReadByte();
				int c2 = reader.ReadByte();
				int c3 = reader.ReadByte();

				if (c1 != 1) throw null;
				if (c2 != 2) throw null;
				if (c3 != 3) throw null;

				{
					byte[] data = new byte[100];
					reader.Read(data, 0, data.Length);

					if (SCommon.Comp(data, Enumerable.Range(4, 100).Select(chr => (byte)chr).ToArray()) != 0) throw null;
				}

				{
					byte[] data = SCommon.Read(reader, 100);

					if (SCommon.Comp(data, Enumerable.Range(104, 100).Select(chr => (byte)chr).ToArray()) != 0) throw null;
				}
			}

			using (MemoryStream writer = new MemoryStream())
			{
				writer.WriteByte(0x01);
				writer.WriteByte(0x02);
				writer.WriteByte(0x03);

				{
					byte[] data = Enumerable.Range(4, 100).Select(chr => (byte)chr).ToArray();
					writer.Write(data, 0, data.Length);
				}

				{
					byte[] data = Enumerable.Range(104, 100).Select(chr => (byte)chr).ToArray();
					SCommon.Write(writer, data);
				}

				if (SCommon.Comp(writer.ToArray(), Enumerable.Range(1, 203).Select(chr => (byte)chr).ToArray()) != 0) throw null;
			}

			Console.WriteLine("TEST-0001-02 OK");
		}
	}
}
