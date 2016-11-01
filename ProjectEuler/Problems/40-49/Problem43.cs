using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem43
	{
		private static readonly List<int> divisorPrimes = PrimeUtils.GenerateFirstNPrimes(7);
		private static readonly List<int> Digits = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

		public static string Solve()
		{
			return SolveBad();
		}

		//public static string SolveGood()
		//{
		//	List<int> _17s = Enumerable.Range(17, 982).Where(num => num % 17 == 0).ToList();
		//	foreach (int _17 in _17s)
		//	{
		//		List<int> useableDigits = new List<int>(Digits);
		//		useableDigits.RemoveAll(n => DigitUtils.GetDigits(_17).Contains(n));
		//		List<int> _13s = 
		//	}

		//	return "";
		//}
		
		public static string SolveBad()
		{
			List<long> solnPandigitals = new List<long>();
			var pandigitals = Combinatorics.GetFullPermutations(Digits);
			pandigitals = pandigitals.Where(dList => dList.ElementAt(5) % 5 == 0 && dList.ElementAt(3) % 2 == 0);
			int curiosityCtr = 0;

			foreach (var pandigital in pandigitals)
			{
				if (PiecewiseDivisible(DigitUtils.DigitListToLong(pandigital.ToList())))
				{
					solnPandigitals.Add(DigitUtils.DigitListToLong(pandigital.ToList()));
				}
				curiosityCtr++;
			}

			return solnPandigitals.Sum().ToString();
		}

		private static bool PiecewiseDivisible(long n)
		{
			string nStr = (n < 1000000000) ? "0" + n.ToString() : n.ToString();

			for (int divisorIdx = 6; divisorIdx >= 0; divisorIdx--)
			{
				long piece = Int64.Parse(nStr.Substring(divisorIdx + 1, 3));
				if (piece % divisorPrimes[divisorIdx] != 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}
