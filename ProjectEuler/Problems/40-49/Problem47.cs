using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem47
	{
		public static string Solve()
		{
			HashSet<int> primes = PrimeUtils.GenerateFirstNPrimesHashSet(15000);
			Dictionary<int, List<int>> primeFactorizations = PrimeUtils.GeneratePrimeFactorizationsForNLessThan(primes.Last(), primes);
			string firstOfConsecutiveFour = "";
			int countNum = 0;

			for (int i = 2; i < primes.Last(); i++)
			{
				if (primeFactorizations[i].Count < 4)
				{
					firstOfConsecutiveFour = "";
					countNum = 0;
					continue;
				}

				HashSet<int> distinctFactors = new HashSet<int>(primeFactorizations[i]);
				if (distinctFactors.Count == 4)
				{
					if (countNum == 0)
					{
						firstOfConsecutiveFour = i.ToString();
					}
					countNum++;

					if (countNum == 4)
					{
						break;
					}
				}
				else
				{
					firstOfConsecutiveFour = "";
					countNum = 0;
				}
			}

			return firstOfConsecutiveFour;
		}
	}
}
