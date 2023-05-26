using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0002
	{
#if !true
		public void Test01()
		{
			Dictionary<string, int> counters = SCommon.CreateDictionary<int>();
			RandomUnit ru = new RandomUnit(new ConcreteRandom());
			int lastValue = -1;

			Action<string> increment = key =>
			{
				if (counters.ContainsKey(key))
					counters[key]++;
				else
					counters[key] = 1;
			};

			for (int c = 0; c < 1000000; c++)
			{
				int value = ru.GetByte();

				if (1 <= c)
					increment(string.Format("2. {0:x2} --> {1:x2}", lastValue, value));

				increment(string.Format("1. {0:x2}", value));
				lastValue = value;
			}

			List<string> lines = new List<string>();

			foreach (string key in counters.Keys.OrderBy(SCommon.Comp))
				lines.Add(key + " : " + counters[key]);

			File.WriteAllLines(SCommon.NextOutputPath() + ".txt", lines, Encoding.ASCII);
		}

		public class ConcreteRandom : RandomUnit.IRandomNumberGenerator
		{
			private ulong State = 1;

			private ulong Next()
			{
				State ^= State << 13;
				State ^= State >> 7;
				State ^= State << 17;
				return State;
			}

			public byte[] GetBlock()
			{
				ulong value = this.Next() % 0x100002b;

				return new byte[]
				{
					(byte)((value >> 16) & 0xff),
					(byte)((value >> 8) & 0xff),
					(byte)(value & 0xff),
				};
			}

			public void Dispose()
			{
				// noop
			}
		}
#elif true
		public void Test01()
		{
			RandomUnit ru = new RandomUnit(new ConcreteRandom());

			for (int c = 0; c < 31; c++)
			{
				Console.WriteLine(ru.GetByte().ToString("x2"));
			}
		}

		public class ConcreteRandom : RandomUnit.IRandomNumberGenerator
		{
			private ulong State = 1;

			private ulong Next()
			{
				Console.WriteLine("INTERNAL-1: " + State.ToString("x16")); // cout

				State ^= State << 13;
				State ^= State >> 7;
				State ^= State << 17;

				Console.WriteLine("INTERNAL-2: " + State.ToString("x16")); // cout

				return State;
			}

			public byte[] GetBlock()
			{
				ulong value = this.Next() % 0x100002b;

				Console.WriteLine("INTERNAL-3: " + value.ToString("x16")); // cout

				return new byte[]
				{
					(byte)((value >> 16) & 0xff),
					(byte)((value >> 8) & 0xff),
					(byte)(value & 0xff),
				};
			}

			public void Dispose()
			{
				// noop
			}
		}
#else
		public class ConcreteRandom : RandomUnit.IRandomNumberGenerator
		{
			//private ulong State = 1;
			//private ulong State = ulong.MaxValue;
			//private ulong State = ulong.MaxValue / 2;
			//private ulong State = ulong.MaxValue / 3;
			//private ulong State = ulong.MaxValue / 4;
			//private ulong State = ulong.MaxValue / 5;
			//private ulong State = ulong.MaxValue / 6;
			private ulong State = ulong.MaxValue / 7;

			private ulong Next()
			{
				Console.WriteLine("INTERNAL-1: " + State.ToString("x16")); // cout

				State ^= State << 13;
				State ^= State >> 7;
				State ^= State << 17;

				Console.WriteLine("INTERNAL-2: " + State.ToString("x16")); // cout

				return State;
			}

			public byte[] GetBlock()
			{
				ulong value = this.Next() % 0x100000000000051;

				Console.WriteLine("INTERNAL-3: " + value.ToString("x16")); // cout

				return new byte[]
				{
					(byte)((value >> 48) & 0xff),
					(byte)((value >> 40) & 0xff),
					(byte)((value >> 32) & 0xff),
					(byte)((value >> 24) & 0xff),
					(byte)((value >> 16) & 0xff),
					(byte)((value >> 8) & 0xff),
					(byte)(value & 0xff),
				};
			}

			public void Dispose()
			{
				// noop
			}
		}
#endif
	}
}
