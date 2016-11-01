using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public class Problem35
	{
		public static string Solve()
		{
			List<int> primes = PrimeUtils.GeneratePrimesLessThanN(1000000);
			List<int> circPrimes = FindCircularPrimes(primes);
			circPrimes.Sort();
			return circPrimes.Count.ToString();
		}

		private static List<int> FindCircularPrimes(List<int> primes)
		{
			HashSet<int> circPrimes = new HashSet<int>();
			foreach (int prime in primes)
			{
				List<string> rotations = StringUtils.GenerateStringRotations(prime.ToString());
				bool isCirc = true;
				foreach (string rotation in rotations)
				{
					if (!PrimeUtils.IsPrime(Int32.Parse(rotation)))
					{
						isCirc = false;
						break;
					};
				}
				if (isCirc)
				{
					foreach (string rotation in rotations)
					{
						circPrimes.Add(Int32.Parse(rotation));
					}
				}
			}
			return circPrimes.ToList<int>();
		}
	}
}
