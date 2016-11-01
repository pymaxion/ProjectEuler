using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem49
	{
		public static string Solve()
		{
			List<Tuple<int, int, int>> solutionSequences = new List<Tuple<int,int,int>>();
			HashSet<int> fourDigitPrimes = PrimeUtils.GeneratePrimesLessThanNHashSet(10000);
			fourDigitPrimes.RemoveWhere(prime => prime < 1000);
			Dictionary<int, bool> checkedPrime = new Dictionary<int, bool>();
			foreach (int prime in fourDigitPrimes)
			{
				checkedPrime.Add(prime, false);
			}

			foreach (int prime in fourDigitPrimes)
			{
				if (!checkedPrime[prime])
				{
					HashSet<int> permutations = new HashSet<int>(Combinatorics.GetFullPermutations(DigitUtils.GetDigits(prime))
						.Select(num => DigitUtils.DigitListToInt(num)));
					permutations.RemoveWhere(perm => !fourDigitPrimes.Contains(perm));

					foreach (int primePerm in permutations)
					{
						checkedPrime[primePerm] = true;
					}

					if (permutations.Count > 2)
					{
						var combos = Combinatorics.GetCombinations(permutations, 2);
						foreach (var combo in combos)
						{
							int term1 = combo.Min();
							int term2 = combo.Max();
							int term3 = term2 + (term2 - term1);

							if (permutations.Contains(term3))
							{
								solutionSequences.Add(new Tuple<int, int, int>(term1, term2, term3));
							}
						}
					}
				}
			}

			string solnStr = "";
			foreach (Tuple<int, int, int> solnSeq in solutionSequences)
			{
				solnStr += String.Format("{0}, {1}, {2}, diff: {3}, concat: {0}{1}{2}\n",
					solnSeq.Item1, solnSeq.Item2, solnSeq.Item3, solnSeq.Item3 - solnSeq.Item2);
			}
			return solnStr;
		}
	}
}
