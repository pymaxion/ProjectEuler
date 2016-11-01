using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem32
	{
		public static List<int> DigitList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		public static List<string> IdentityList = new List<string>();
		
		public static string Solve()
		{
			HashSet<int> productSet = new HashSet<int>();
			
			for (int i = 1; i <= 4; i++) // multiplicand
			{
				for (int j = 1; j <= i; j++) // multiplier
				{
					HashSet<int> partialProductSet = PandigitalProductHelper(i, j);
					foreach (int product in partialProductSet)
					{
						productSet.Add(product);
					}
				}
			}

			IdentityList.Sort();
			int productSum = 0;
			foreach (int product in productSet)
			{
				productSum += product;
			}

			return productSum.ToString();
		}

		private static HashSet<int> PandigitalProductHelper(int numMultiplicandDigits, int numMultiplierDigits) 
		{
			HashSet<int> products = new HashSet<int>();
			int product;
			string identity;

			List<int> multiplicands = GetMultiplicands(numMultiplicandDigits);
			foreach (int multiplicand in multiplicands)
			{
				List<int> multipliers = GetMultipliersGivenMultiplicand(numMultiplierDigits, multiplicand);
				foreach (int multiplier in multipliers)
				{
					product = multiplicand * multiplier;
					identity = "" + multiplicand + multiplier + product;
					if (identity.Length != 9)
					{
						continue;
					}
					long concatIdentity = Int64.Parse(identity);
					if (DigitUtils.IsPandigital(concatIdentity, 1))
					{
						products.Add(product);
						IdentityList.Add(multiplicand + " x " + multiplier + " = " + product);
					}
				}
			}
			return products;
		}

		private static List<int> GetMultiplicands(int numDigits)
		{
			return GetIntCombos(DigitList, numDigits);
		}

		private static List<int> GetMultipliersGivenMultiplicand(int numDigits, int multiplicand)
		{
			List<int> multipliers = new List<int>();
			List<int> useableDigits = new List<int>(DigitList);

			int[] multiplicandDigits = DigitUtils.GetDigits(multiplicand);
			foreach (int multiplicandDigit in multiplicandDigits)
			{
				useableDigits.Remove(multiplicandDigit);
			}

			return GetIntCombos(useableDigits, numDigits);
		}

		private static List<int> GetIntCombos(List<int> useableDigits, int numDigits)
		{
			List<int> combos = new List<int>();
			var comboDigitsList = Combinatorics.GetPermutations(useableDigits, numDigits);
			foreach (var comboDigits in comboDigitsList)
			{
				combos.Add(DigitUtils.DigitListToInt(comboDigits));
			}
			return combos;
		}
	}
}
