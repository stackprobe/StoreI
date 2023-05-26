using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using Charlotte.Commons;

namespace Charlotte.Tests
{
	public class Test0001
	{
		public void Test01()
		{
			Test01_a(10, 300000);
			Test01_a(30, 100000);
			Test01_a(100, 30000);
			Test01_a(300, 10000);
			Test01_a(1000, 3000);
			Test01_a(3000, 1000);
			Test01_a(10000, 300);
			Test01_a(30000, 100);
			Test01_a(100000, 30);
			Test01_a(300000, 10);
		}

		private void Test01_a(int dataCount, int testCount)
		{
			Test01_b(dataCount, testCount, 300);
			Test01_b(dataCount, testCount, 50000);
			Test01_b(dataCount, testCount, 2100000000);
		}

		private void Test01_b(int dataCount, int testCount, int valueScale)
		{
			long micros_01 = 0L;
			long micros_02 = 0L;
			long micros_03 = 0L;

			for (int testcnt = 0; testcnt < testCount; testcnt++)
			{
				int[] arr_01 = Enumerable.Range(0, dataCount).Select(dummy => SCommon.CRandom.GetInt(valueScale)).ToArray();
				int[] arr_02 = arr_01.ToArray();
				int[] arr_03 = arr_01.ToArray();

				{
					DateTime stTm = DateTime.Now;
					Sort_01(arr_01);
					micros_01 += (long)((DateTime.Now - stTm).TotalMilliseconds * 1000.0);
				}

				{
					DateTime stTm = DateTime.Now;
					Sort_02(arr_02);
					micros_02 += (long)((DateTime.Now - stTm).TotalMilliseconds * 1000.0);
				}

				{
					DateTime stTm = DateTime.Now;
					Sort_03(arr_03);
					micros_03 += (long)((DateTime.Now - stTm).TotalMilliseconds * 1000.0);
				}

				CheckSorted(arr_01);
				//CheckSorted(arr_02);
				//CheckSorted(arr_03);

				CheckSameArray(arr_01, arr_02);
				CheckSameArray(arr_01, arr_03);
			}

			micros_01 /= testCount;
			micros_02 /= testCount;
			micros_03 /= testCount;

			Console.WriteLine(string.Join("\t", micros_01, micros_02, micros_03, dataCount, valueScale));
		}

		private void CheckSorted(int[] arr)
		{
			for (int i = 0; i + 1 < arr.Length; i++)
				if (arr[i] > arr[i + 1])
					throw null;
		}

		private void CheckSameArray(int[] arr1, int[] arr2)
		{
			if (SCommon.Comp(arr1, arr2, (a, b) => a - b) != 0)
				throw null;
		}

		private void Sort_01(int[] arr)
		{
			Array.Sort(arr, (a, b) => a - b);
		}

		private void Sort_02(int[] arr)
		{
			int gap = arr.Length;
			bool swapped;
			do
			{
				gap = Math.Max(1, (int)(gap / 1.3));
				swapped = false;

				for (int i = 0, j = gap; j < arr.Length; i++, j++)
				{
					if (arr[i] > arr[j])
					{
						int tmp = arr[i];
						arr[i] = arr[j];
						arr[j] = tmp;

						swapped = true;
					}
				}
			}
			while (1 < gap || swapped);
		}

		private void Sort_03(int[] arr)
		{
			for (int gap = arr.Length; ; )
			{
				gap = (int)(gap / 1.3);

				if (gap <= 1)
					break;

				if (gap == 9 || gap == 10)
					gap = 11;

				for (int i = 0, j = gap; j < arr.Length; i++, j++)
				{
					if (arr[i] > arr[j])
					{
						int tmp = arr[i];
						arr[i] = arr[j];
						arr[j] = tmp;
					}
				}
			}

			for (int i = 0; i + 1 < arr.Length; )
			{
				if (arr[i] > arr[i + 1])
				{
					int tmp = arr[i];
					arr[i] = arr[i + 1];
					arr[i + 1] = tmp;

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
	}
}
