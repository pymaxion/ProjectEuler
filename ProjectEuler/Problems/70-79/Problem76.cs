using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem76
	{
		public const int LIMIT = 100;

		public static string Solve()
		{
			return (Combinatorics.GetPartitionsOfN(LIMIT) - 1).ToString();
		}
	}
}
