using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0004
	{
		public class Random65 : RandomUnit.IRandomNumberGenerator
		{
			private ulong State;

			private ulong Next()
			{
				State ^= State << 13;
				State ^= State >> 7;
				State ^= State << 17;
				return State;
			}

			public Random65(ulong seed)
			{
				this.State = seed % ulong.MaxValue + 1;
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

		// ====
		// ====
		// ====

		public void Test01()
		{
			RandomUnit rand = new RandomUnit(new Random65(0));

			for (int c = 0; c < 10; c++)
			{
				Console.WriteLine(rand.GetULong64());
			}
		}
	}
}
