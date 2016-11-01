using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem27
	{
		public static string Solve()
		{
			List<int> possibleBs = PrimeUtils.GeneratePrimesLessThanN(1000);
			int maxPrimes = 0;
			int maxA = 0;
			int maxB = 0;

			foreach (int b in possibleBs)
			{
				for (int a = -999; a < 1000; a++)
				{
					int thisPrimes = 0;
					for (int n = 0; n < 80; n++)
					{
						int result = (n * n) + (a * n) + (b);
						if (!PrimeUtils.IsPrime(result))
						{
							break;
						}
						thisPrimes++;
					}
					if (thisPrimes > maxPrimes)
					{
						maxPrimes = thisPrimes;
						maxA = a;
						maxB = b;
					}
				}
			}

			return (maxA*maxB).ToString();
		}
	}
}
