using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem77
	{
		private const int LIMIT = 100;
		private static readonly HashSet<int> primes = PrimeUtils.GenerateFirstNPrimesHashSet(LIMIT);
		private static readonly Dictionary<int, List<int>> primeFactorizations = PrimeUtils.GeneratePrimeFactorizationsForNLessThan(LIMIT, primes);
		
		public static string Solve()
		{
			Dictionary<int, int> sumOfPrimeFactors = new Dictionary<int, int>();
			sumOfPrimeFactors.Add(1, 0);
			for (int i = 2; i < LIMIT; i++)
			{
				sumOfPrimeFactors.Add(i, GenerateSumOfPrimeFactors(i));
			}

			Dictionary<int, long> primePartitions = new Dictionary<int, long>();
			primePartitions.Add(1, 0);
			for (int i = 2; i < LIMIT; i++)
			{
				long kappa = sumOfPrimeFactors[i];
				for (int j = 1; j < i; j++)
				{
					kappa += sumOfPrimeFactors[j] * primePartitions[i - j];
				}
				kappa /= i;
				primePartitions.Add(i, kappa);
			}

			return primePartitions.First(kvp => kvp.Value > 5000).Key.ToString();
		}

		private static int GenerateSumOfPrimeFactors(int n)
		{
			List<int> primeFactors = primeFactorizations[n];
			HashSet<int> uniqueFactors = new HashSet<int>(primeFactors);
			return uniqueFactors.Sum();
		}
	}
}
