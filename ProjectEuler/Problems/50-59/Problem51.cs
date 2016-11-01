using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem51
	{
		private const int PrimeFamilySize = 8;
		
		public static string Solve()
		{
			Dictionary<int, List<int>> solnDict = new Dictionary<int,List<int>>();
			HashSet<int> primesSet = PrimeUtils.GeneratePrimesLessThanNHashSet((int)1e6);
			primesSet.RemoveWhere(p => p < 10);

			foreach (int prime in primesSet)
			{
				if (prime == 120383)
				{
					int y = 0;
				}
				
				string primeStr = prime.ToString();
				for (int digitsToReplace = 1; digitsToReplace < primeStr.Length; digitsToReplace++)
				{
					var digitCombos = Combinatorics.GetCombinations(Enumerable.Range(0, primeStr.Length), digitsToReplace);
					foreach (var digitCombo in digitCombos)
					{
						int primeCount = 0;
						for (int replacementDigit = 0; replacementDigit < 10; replacementDigit++) 
						{
							StringBuilder sb = new StringBuilder(String.Copy(primeStr));
							foreach (int digit in digitCombo)
							{
								sb[digit] = replacementDigit.ToString().First();
							}
							//if (sb[0] == '0') continue;
							int possiblePrime = Int32.Parse(sb.ToString());
							if (possiblePrime < prime) continue;
							if (primesSet.Contains(possiblePrime))
							{
								primeCount++;
								if (primeCount == PrimeFamilySize)
								{
									return prime.ToString();
								}
							}
						}
					}
				}
			}

			return "";
		}
	}
}
