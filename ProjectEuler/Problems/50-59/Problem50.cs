using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem50
	{
		public const int limit = 1000000;
		
		public static string Solve()
		{
			HashSet<int> primesHashSet = PrimeUtils.GeneratePrimesLessThanNHashSet(limit);
			int[] primesAry = primesHashSet.ToArray();

			SortedDictionary<int, List<int>> sums = new SortedDictionary<int, List<int>>();

			// add 2 to dictionary
			List<int> twoSummation = new List<int>();
			twoSummation.Add(2);
			sums.Add(2, twoSummation);

			int maxLength = 1;

			for (int i = 1; i < primesAry.Length; i++)
			{
				int prime = primesAry[i];
				int prevPrime = primesAry[i - 1];
				int[] keys = sums.Keys.ToArray();
				foreach (int sum in keys)
				{
					int thisSum = prime + sum;
					bool validSum = (sums[sum].Last() == prevPrime) && (thisSum < limit); // consecutive and less than limit
					if (validSum && !sums.ContainsKey(thisSum))
					{
						List<int> newSummation = new List<int>(sums[sum]);
						newSummation.Add(prime);
						sums.Add((thisSum), newSummation);
						if (primesHashSet.Contains(thisSum) && newSummation.Count > maxLength)
						{
							maxLength = newSummation.Count;
						}
					}
				}

				List<int> sumsToRemove = new List<int>();
				foreach (int sum in keys)
				{
					bool pastTheEnd = sums[sum].Last() != prevPrime;
					if ((sums[sum].Count < maxLength && pastTheEnd) || 
						(sums[sum].Count >= maxLength && pastTheEnd && !primesHashSet.Contains(sum)))
					{
						sumsToRemove.Add(sum);
					}
				}
				foreach (int sumToRemove in sumsToRemove)
				{
					sums.Remove(sumToRemove);
				}

				if (!sums.ContainsKey(prime))
				{
					List<int> trivialSummation = new List<int>();
					trivialSummation.Add(prime);
					sums.Add(prime, trivialSummation);
				}
			}

			// filter non-prime sums
			int mostTerms = 0;
			int longestSum = 0;
			List<int> termsOfSum;
			foreach (int sum in sums.Keys)
			{
				if (sums[sum].Count > mostTerms)
				{
					mostTerms = sums[sum].Count;
					longestSum = sum;
					termsOfSum = sums[sum];
				}
			}

			return longestSum.ToString();
		}
	}
}
