using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem92
	{
		public static string Solve()
		{
			int countOf89s = 0;
			for (int i = 1; i < 10000000; i++)
			{
				int thisNum = i;
				int digitSquareSum;
				bool keepLooping;
				do
				{
					digitSquareSum = 0;
					int[] digits = DigitUtils.GetDigits(thisNum);
					foreach (int digit in digits)
					{
						digitSquareSum += digit * digit;
					}

					if (digitSquareSum == 1 || digitSquareSum == 89)
					{
						keepLooping = false;
					}
					else
					{
						keepLooping = true;
						thisNum = digitSquareSum;
					}
				}
				while (keepLooping);

				if (digitSquareSum == 89) 
				{
					countOf89s++;
				}
			}
			return countOf89s.ToString();
		}
	}
}
