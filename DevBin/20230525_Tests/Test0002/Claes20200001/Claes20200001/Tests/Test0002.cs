using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0002
	{
		public static void Sort<T>(IList<T> list, Func<T, T, bool> greaterThan)
		{
			for (int gap = list.Count; ; )
			{
				gap = (int)(gap / 1.3);

				if (gap <= 1)
					break;

				if (gap == 9 || gap == 10)
					gap = 11;

				for (int i = 0, j = gap; j < list.Count; i++, j++)
				{
					if (greaterThan(list[i], list[j]))
					{
						T tmp = list[i];
						list[i] = list[j];
						list[j] = tmp;
					}
				}
			}

			for (int i = 0; i + 1 < list.Count; )
			{
				if (greaterThan(list[i], list[i + 1]))
				{
					T tmp = list[i];
					list[i] = list[i + 1];
					list[i + 1] = tmp;

					if (0 < i)
						i--;
					else
						i++;
				}
				else
				{
					i++;
				}
			}
		}

		// ====
		// ====
		// ====

		public void Test01()
		{
			int[] arr = new int[] { 2023, 5, 25, 12, 30, 30 };

			Sort(arr, (a, b) => a > b);

			Console.WriteLine(string.Join(", ", arr));
		}
	}
}
