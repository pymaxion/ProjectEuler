using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class PrimeUtils
	{
		public static bool IsPrime(int number)
		{
			if (number < 2)
			{
				return false;
			}
			if (number % 2 == 0)
			{
				return (number == 2);
			}
			int root = (int)Math.Sqrt((double)number);
			for (int i = 3; i <= root; i += 2)
			{
				if (number % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsPrime(long number)
		{
			if (number < 2)
			{
				return false;
			}
			if (number % 2 == 0)
			{
				return (number == 2);
			}
			long root = (long)Math.Sqrt((double)number);
			for (long i = 3; i <= root; i += 2)
			{
				if (number % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		// http://stackoverflow.com/questions/1042902/most-elegant-way-to-generate-prime-numbers
		public static int ApproximateNthPrime(int nn)
		{
			double n = (double)nn;
			double p;
			if (nn >= 7022)
			{
				p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
			}
			else if (nn >= 6)
			{
				p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
			}
			else if (nn > 0)
			{
				p = new int[] { 2, 3, 5, 7, 11 }[nn - 1];
			}
			else
			{
				p = 0;
			}
			return (int)p;
		}

		// Find all primes up to and including the limit
		public static BitArray SieveOfEratosthenes(int limit)
		{
			BitArray bits = new BitArray(limit + 1, true);
			bits[0] = false;
			bits[1] = false;
			for (int i = 0; i * i <= limit; i++)
			{
				if (bits[i])
				{
					for (int j = i * i; j <= limit; j += i)
					{
						bits[j] = false;
					}
				}
			}
			return bits;
		}

		public static List<int> GenerateFirstNPrimes(int n)
		{
			int limit = ApproximateNthPrime(n);
			BitArray bits = SieveOfEratosthenes(limit);
			List<int> primes = new List<int>();
			for (int i = 0, found = 0; i < limit && found < n; i++)
			{
				if (bits[i])
				{
					primes.Add(i);
					found++;
				}
			}
			return primes;
		}

		public static HashSet<int> GenerateFirstNPrimesHashSet(int n)
		{
			int limit = ApproximateNthPrime(n);
			BitArray bits = SieveOfEratosthenes(limit);
			HashSet<int> primes = new HashSet<int>();
			for (int i = 0, found = 0; i < limit && found < n; i++)
			{
				if (bits[i])
				{
					primes.Add(i);
					found++;
				}
			}
			return primes;
		}

		public static List<int> GeneratePrimesLessThanN(int n)
		{
			var primes = new List<int>();
			for (var i = 2; i <= n; i++)
			{
				var ok = true;
				foreach (var prime in primes)
				{
					if (prime * prime > i)
					{
						break;
					}
					if (i % prime == 0)
					{
						ok = false;
						break;
					}
				}
				if (ok)
				{
					primes.Add(i);
				}
			}
			return primes;
		}

		public static HashSet<int> GeneratePrimesLessThanNHashSet(int n)
		{
			var primes = new HashSet<int>();
			for (var i = 2; i <= n; i++)
			{
				var ok = true;
				foreach (var prime in primes)
				{
					if (prime * prime > i)
					{
						break;
					}
					if (i % prime == 0)
					{
						ok = false;
						break;
					}
				}
				if (ok)
				{
					primes.Add(i);
				}
			}
			return primes;
		}

		public static bool MillerRabinIsPrime(int n)
		{
			return MillerRabin((ulong)n);
		}

		public static bool MillerRabinIsPrime(long n)
		{
			return MillerRabin((ulong)n);
		}

		private static bool MillerRabin(ulong n)
		{
			ulong[] ar;
			if (n < 4759123141) ar = new ulong[] { 2, 7, 61 };
			else if (n < 341550071728321) ar = new ulong[] { 2, 3, 5, 7, 11, 13, 17 };
			else ar = new ulong[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
			ulong d = n - 1;
			int s = 0;
			while ((d & 1) == 0) { d >>= 1; s++; }
			int i, j;
			for (i = 0; i < ar.Length; i++)
			{
				ulong a = Math.Min(n - 2, ar[i]);
				ulong now = pow(a, d, n);
				if (now == 1) continue;
				if (now == n - 1) continue;
				for (j = 1; j < s; j++)
				{
					now = mul(now, now, n);
					if (now == n - 1) break;
				}
				if (j == s) return false;
			}
			return true;
		}

		private static ulong mul(ulong a, ulong b, ulong mod)
		{
			int i;
			ulong now = 0;
			for (i = 63; i >= 0; i--) if (((a >> i) & 1) == 1) break;
			for (; i >= 0; i--)
			{
				now <<= 1;
				while (now > mod) now -= mod;
				if (((a >> i) & 1) == 1) now += b;
				while (now > mod) now -= mod;
			}
			return now;
		}

		private static ulong pow(ulong a, ulong p, ulong mod)
		{
			if (p == 0) return 1;
			if (p % 2 == 0) return pow(mul(a, a, mod), p / 2, mod);
			return mul(pow(a, p - 1, mod), a, mod);
		}

		public static Dictionary<int, List<int>> GeneratePrimeFactorizationsForNLessThan(int n, HashSet<int> primes)
		{
			Dictionary<int, List<int>> primeFactorizations = new Dictionary<int, List<int>>();
			for (int i = 2; i < n; i++)
			{
				List<int> factors = new List<int>();
				if (primes.Contains(i))
				{
					factors.Add(i);
				}
				else
				{
					for (int divisor = 2; divisor <= i / 2; divisor++)
					{
						if (i % divisor == 0 && primeFactorizations.ContainsKey(divisor))
						{
							foreach (int factor in primeFactorizations[divisor])
							{
								factors.Add(factor);
							}
							foreach (int factor in primeFactorizations[i / divisor])
							{
								factors.Add(factor);
							}
							break;
						}
					}
				}
				primeFactorizations.Add(i, factors);
			}

			return primeFactorizations;
		}

		// From http://rosettacode.org/wiki/Ulam_spiral_%28for_primes%29#C
		public static int GetNumAtCoordinatesOnPrimeSpiral(int x, int y, int sideLength)
		{
			if (x > 0 && x == y)
			{
				x++;
				y++;
			}
			
			x -= (sideLength - 1) / 2;
			y -= sideLength / 2;
			int l = 2 * (int)Math.Max(Math.Abs(x), Math.Abs(y));
			int d = y > x ? (l * 3 + x + y) : (l - x - y);
			return (int)Math.Pow(l - 1, 2) + d;
		}

		// From http://rosettacode.org/wiki/Ulam_spiral_%28for_primes%29#C
		public static long GetLongNumAtCoordinatesOnPrimeSpiral(int x, int y, int sideLength)
		{
			if (x > 0 && x == y)
			{
				x++;
				y++;
			}

			x -= (sideLength - 1) / 2;
			y -= sideLength / 2;
			long l = 2 * (long)Math.Max(Math.Abs(x), Math.Abs(y));
			long d = y > x ? (l * 3 + x + y) : (l - x - y);
			return (long)Math.Pow(l - 1, 2) + d;
		}
	}
}
