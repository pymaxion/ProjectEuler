using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem53
	{
		public static string Solve()
		{
			BigInteger[][] pascalsTriangle = Combinatorics.GenerateNRowsPascalsTriangle(101);
			int greaterThanOneMilCount = 0;

			for (int n = 1; n <= 100; n++)
			{
				for (int r = 0; r <= n; r++)
				{
					BigInteger nCr = pascalsTriangle[n][r];
					if (nCr > 1000000)
					{
						greaterThanOneMilCount++;
					}
				}
			}

			return greaterThanOneMilCount.ToString();
		}
	}
}
