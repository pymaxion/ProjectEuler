using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem46
	{
		public const int Limit = 5000;
		private static readonly HashSet<int> primes = PrimeUtils.GenerateFirstNPrimesHashSet(Limit);
		private static readonly HashSet<int> squares = SquareUtils.GenerateFirstNSquaresHashSet(Limit);

		public static string Solve()
		{			
			for (int candidate = 9; candidate < primes.Last(); candidate += 2)
			{
				if (primes.Contains(candidate))
				{
					continue;
				}

				if (!ObeysGoldbachsOtherConjecture(candidate))
				{
					return candidate.ToString();
				}
			}

			return "";
		}

		private static bool ObeysGoldbachsOtherConjecture(int oddComposite)
		{
			foreach (int prime in primes)
			{
				if (prime > oddComposite)
				{
					break;
				}

				if (squares.Contains((oddComposite - prime) / 2))
				{
					return true;
				}
			}
			return false;
		}
	}
}
