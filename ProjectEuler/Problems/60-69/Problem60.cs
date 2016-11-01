using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem60
	{
		public static string Solve()
		{
			HashSet<HashSet<int>> primePairSets = new HashSet<HashSet<int>>();
			List<int> validPrimes = PrimeUtils.GenerateFirstNPrimes(1500); // seemed like a reasonable upper bound
			validPrimes.Remove(2); // can't have 2
			validPrimes.Remove(5); // can't have 5

			// first pass -- add a unique set containing only one prime to set of possible prime pair sets
			foreach (int prime in validPrimes)
			{
				HashSet<int> newPrimePairSet = new HashSet<int>();
				newPrimePairSet.Add(prime);
				primePairSets.Add(newPrimePairSet);
			}

			// second pass
			foreach (int prime in validPrimes)
			{
				foreach (HashSet<int> primePairSet in primePairSets)
				{					
					bool primeBelongsInSet = true;
					foreach (int primeAlreadyInSet in primePairSet)
					{
						long concatBefore = Int64.Parse(prime.ToString() + primeAlreadyInSet.ToString());
						if (!PrimeUtils.IsPrime(concatBefore))
						{
							primeBelongsInSet = false;
							break;
						}
						long concatAfter = Int64.Parse(primeAlreadyInSet.ToString() + prime.ToString());
						if (!PrimeUtils.IsPrime(concatAfter))
						{
							primeBelongsInSet = false;
							break;
						}
					}
					if (primeBelongsInSet)
					{
						primePairSet.Add(prime);
					}
				}

				if (primePairSets.Any(set => set.Count == 5)) // are we done?
				{
					break;
				}
			}

			int lowestSum = primePairSets.First(set => set.Count == 5).Sum();
			return lowestSum.ToString();
		}
	}
}
