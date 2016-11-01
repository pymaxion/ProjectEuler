using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
	public static class Problem1
	{
		public static string Solve()
		{
			int sum = 0;
			for (int i = 1; i < 1000; i++)
			{
				if (i % 3 == 0 || i % 5 == 0)
				{
					sum += i;
				}
			}
			return sum.ToString();
		}
	}
}
