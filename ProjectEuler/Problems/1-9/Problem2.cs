using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
	public static class Problem2
	{
		public static string Solve()
		{
			int term1 = 1;
			int term2 = 2;
			int sum;
			int evenSum = 2;
			while (term1 + term2 < 4e6)
			{
				sum = term1 + term2;
				if (sum % 2 == 0)
				{
					evenSum += sum;
				}
				term1 = term2;
				term2 = sum;
			}

			return evenSum.ToString();
		}
	}
}
