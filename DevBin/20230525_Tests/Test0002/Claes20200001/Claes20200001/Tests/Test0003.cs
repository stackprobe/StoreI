using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.Tests
{
	public class Test0003
	{
		public class Random64
		{
			public ulong State = 1;

			public ulong Next()
			{
				State ^= State << 13;
				State ^= State >> 7;
				State ^= State << 17;
				return State;
			}
		}

		// ====
		// ====
		// ====

		public void Test01()
		{
			Random64 rand = new Random64();

			for (int c = 0; c < 10; c++)
			{
				Console.WriteLine(rand.Next());
			}

			// ----

			rand = new Random64() { State = 123 };

			for (int c = 0; c < 10; c++)
			{
				Console.WriteLine(rand.Next());
			}

			// ----

			rand = new Random64() { State = 0 };

			for (int c = 0; c < 10; c++)
			{
				Console.WriteLine(rand.Next()); // all 0
			}
		}
	}
}
