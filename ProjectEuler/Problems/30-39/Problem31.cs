using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
	public static class Problem31
	{
		private static int _waysToMakeSum;
		private const int DesiredSum = 1000;
		private static readonly int[] validCoins = { 200, 100, 50, 20, 10, 5, 2, 1 };
		
		public static string Solve()
		{
			// initialize
			_waysToMakeSum = 0;

			CoinRecurse(validCoins, 0);
			return String.Format("Ways to make {0} pence: {1}", DesiredSum, _waysToMakeSum);
		}

		private static void CoinRecurse(int[] useableCoins, int sumSoFar)
		{
			for (int i = 0; i < useableCoins.Length; i++)
			{
				int sum = useableCoins[i] + sumSoFar;
				
				if (sum == DesiredSum)
				{
					_waysToMakeSum++;
					continue;
				}

				if (sum > DesiredSum)
				{
					continue;
				}

				// else, we need to go deeper!
				int nextArrSize = useableCoins.Length - i;
				int[] nextLevelCoins = new int[nextArrSize];
				Array.Copy(useableCoins, i, nextLevelCoins, 0, nextArrSize);
				CoinRecurse(nextLevelCoins, sum);
			}
		}
	}
}
