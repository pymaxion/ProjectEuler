using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class Combinatorics
	{
		public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> elements, int k)
		{
			return k == 0 ? new[] { new T[0] } :
				elements.SelectMany((e, i) =>
					GetCombinations(elements.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c)));
		}

		public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> elements, int k)
		{
			return k == 1 ? elements.Select(t => new T[] { t }) :
				GetPermutations(elements, k - 1).SelectMany(t => 
					elements.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
		}

		public static IEnumerable<IEnumerable<T>> GetFullPermutations<T>(IEnumerable<T> source)
		{
			var c = source.Count();
			if (c == 1)
				yield return source;
			else
				for (int i = 0; i < c; i++)
					foreach (var p in GetFullPermutations(source.Take(i).Concat(source.Skip(i + 1))))
						yield return source.Skip(i).Take(1).Concat(p);
		}

		public static BigInteger[][] GenerateNRowsPascalsTriangle(int n)
		{
			BigInteger[][] pascalsTrinangle = new BigInteger[n][];
			for (int i = 0; i < n; i++)
			{
				pascalsTrinangle[i] = new BigInteger[i + 1];
				for (int j = 0; j < i + 1; j++)
				{
					if (j == 0 || j == i)
					{
						pascalsTrinangle[i][j] = 1;
					}
					else
					{
						pascalsTrinangle[i][j] = pascalsTrinangle[i - 1][j - 1] + pascalsTrinangle[i - 1][j]; 
					}
				}
			}
			return pascalsTrinangle;
		}

		public static long GetPartitionsOfN(long n)
		{
			return GetPartitionDictionary(n)[n];
		}

		public static Dictionary<long, long> GetPartitionDictionary(long n)
		{
			Dictionary<long, long> partitionsOfN = new Dictionary<long, long>();
			partitionsOfN.Add(0, 1);
			for (long i = 1; i <= n; i++)
			{
				partitionsOfN.Add(i, 0);
			}
			partitionsOfN[1] = 1;

			for (long i = -1; i > Math.Min(-10, -n / 10); i--)
			{
				partitionsOfN.Add(i, 0);
			}

			for (long i = 2; i <= n; i++)
			{
				long summation = 0;
				for (long k = 1; k <= i; k++)
				{
					long minusy = i - (k * (3 * k - 1)) / 2;
					long plusy = i - (k * (3 * k + 1)) / 2;
					if (minusy < 0 && plusy < 0)
					{
						break;
					}
					summation += ((k % 2 == 0) ? -1 : 1) * (partitionsOfN[minusy] + partitionsOfN[plusy]);
				}

				partitionsOfN[i] += summation;
			}

			return partitionsOfN;
		}

		public static Dictionary<long, BigInteger> GetPartitionDictionaryBig(long n)
		{
			Dictionary<long, BigInteger> partitionsOfN = new Dictionary<long, BigInteger>();
			partitionsOfN.Add(0, 1);
			for (long i = 1; i <= n; i++)
			{
				partitionsOfN.Add(i, 0);
			}
			partitionsOfN[1] = 1;

			for (long i = -1; i > Math.Min(-10, -n / 10); i--)
			{
				partitionsOfN.Add(i, 0);
			}

			for (long i = 2; i <= n; i++)
			{
				BigInteger summation = 0;
				for (long k = 1; k <= i; k++)
				{
					long minusy = i - (k * (3 * k - 1)) / 2;
					long plusy = i - (k * (3 * k + 1)) / 2;
					if (minusy < 0 && plusy < 0)
					{
						break;
					}
					summation += ((k % 2 == 0) ? -1 : 1) * (partitionsOfN[minusy] + partitionsOfN[plusy]);
				}

				partitionsOfN[i] += summation;
			}

			return partitionsOfN;
		}
	}
}
