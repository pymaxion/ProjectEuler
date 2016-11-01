using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem3
	{
		public static string Solve()
		{
			long num = 600851475143;
			int ans = 0;
			List<int> primes = PrimeUtils.GeneratePrimesLessThanN((int)Math.Sqrt(num));
			for (int i = 0; i < primes.Count; i++)
			{
				if (num % primes[primes.Count - 1 - i] == 0)
				{
					ans = primes[primes.Count - 1 - i];
					break;
				}
			}
			return ans.ToString();
		}
	}
}
