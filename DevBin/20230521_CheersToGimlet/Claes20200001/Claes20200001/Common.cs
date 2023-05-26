using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte
{
	public static class Common
	{
		public static RandomUnit GeneralRandom = new RandomUnit(new Random65(0));

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
	}
}
