using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem56
	{
		public static string Solve()
		{
			int maxDigitalSum = 0;
			
			for (int i = 1; i < 100; i++)
			{
				BigInteger num = (BigInteger)i;
				for (int j = 2; j < 100; j++)
				{
					num *= i;
					int digitalSum = DigitUtils.GetDigits(num).Sum();
					if (digitalSum > maxDigitalSum)
					{
						maxDigitalSum = digitalSum;
					}
				}
			}

			return maxDigitalSum.ToString();
		}
	}
}
