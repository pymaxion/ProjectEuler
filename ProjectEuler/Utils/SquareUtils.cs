using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class SquareUtils
	{
		public static HashSet<int> GenerateFirstNSquaresHashSet(int n)
		{
			HashSet<int> squares = new HashSet<int>();
			for (int i = 1; i <= n; i++)
			{
				squares.Add(i * i);
			}
			return squares;
		}

		public static HashSet<long> GenerateSquaresLessThanNHashSetLong(long n)
		{
			HashSet<long> squares = new HashSet<long>();
			long i = 1;
			while (i * i < n)
			{
				squares.Add(i * i);
				i++;
			}
			return squares;
		}
	}
}
