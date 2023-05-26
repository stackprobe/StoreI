using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public static void Sort<T>(IList<T> list, Func<T, T, bool> greaterThan)
		{
			int gap = list.Count;
			bool swapped;
			do
			{
				gap = Math.Max(1, (int)(gap / 1.3));
				swapped = false;

				for (int i = 0, j = gap; j < list.Count; i++, j++)
				{
					if (greaterThan(list[i], list[j]))
					{
						T tmp = list[i];
						list[i] = list[j];
						list[j] = tmp;

						swapped = true;
					}
				}
			}
			while (1 < gap || swapped);
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
