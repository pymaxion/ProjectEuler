using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
	public static class Problem48
	{
		public static string Solve()
		{
			BigInteger result = 0;
			for (int i = 1; i <= 1000; i++)
			{
				result += BigInteger.Pow(i, i);
			}
			char[] chars = result.ToString().ToCharArray();
			chars = chars.Skip(chars.Length - 10).ToArray();
			return new string(chars);
		}
	}
}
