using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Commons;

namespace Charlotte
{
	public static class Common
	{
		public class Random6401 : RandomUnit.IRandomNumberGenerator
		{
			private ulong State = 1;

			public ulong Next()
			{
				State ^= State << 13;
				State ^= State >> 7;
				State ^= State << 17;
				return State;
			}

			public byte[] GetBlock()
			{
				ulong value = this.Next() % 65537;

				return new byte[]
				{
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
