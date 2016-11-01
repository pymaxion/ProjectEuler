using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem37
	{
		public static string Solve()
		{
			List<int> truncatablePrimes = new List<int>();
			List<int> primes = PrimeUtils.GeneratePrimesLessThanN(1000000);
			primes.Remove(2);
			primes.Remove(3);
			primes.Remove(5);
			primes.Remove(7);

			foreach (int prime in primes)
			{
				if (IsTruncatablePrime(prime))
				{
					truncatablePrimes.Add(prime);
				}
			}

			int sum = 0;
			foreach (int truncatablePrime in truncatablePrimes)
			{
				sum += truncatablePrime;
			}

			return sum.ToString();
		}

		private static bool IsTruncatablePrime(int prime)
		{
			int[] digits = DigitUtils.GetDigits(prime);
			for (int i = 1; i < digits.Length; i++)
			{
				var truncLeft = digits.Skip(i);
				if (!PrimeUtils.IsPrime(DigitUtils.DigitListToInt(truncLeft)))
				{
					return false;
				}
				var truncRight = digits.Take(digits.Length - i);
				if (!PrimeUtils.IsPrime(DigitUtils.DigitListToInt(truncRight)))
				{
					return false;
				}
			}
			return true;
		}
	}
}
