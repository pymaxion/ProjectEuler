using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem34
	{
		private static readonly Dictionary<int, int> digitFactorials = new Dictionary<int, int>()
		{
			{ 0, 1 },
			{ 1, 1 },
			{ 2, 2 },
			{ 3, 6 },
			{ 4, 24 },
			{ 5, 120 },
			{ 6, 720 },
			{ 7, 5040 },
			{ 8, 40320 },
			{ 9, 362880 }
		};

		public static string Solve()
		{
			int total = 0;
			for (int i = 10; i < 1000000; i++)
			{
				if (i == GetSumOfDigitFactorials(i))
				{
					total += i;
				}
			}
			return total.ToString();
		}

		private static int GetSumOfDigitFactorials(int n)
		{
			int[] digits = DigitUtils.GetDigits(n);
			int total = 0;
			foreach (int digit in digits)
			{
				total += digitFactorials[digit];
			}
			return total;
		}
	}
}
