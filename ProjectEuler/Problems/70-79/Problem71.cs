using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
	public static class Problem71
	{
		private const int MAX_D = 1000000;
		private const decimal MAX_DECIMAL = ((decimal)3 / (decimal)7);
		
		public static string Solve()
		{
			decimal closestDec = (decimal)0;
			int closestN = 1;

			for (int d = 8; d <= MAX_D; d++)
			{
				for (int n = (int)(d * MAX_DECIMAL) - 1; n < d; n++)
				{
					decimal decRep = (decimal)n / (decimal)d;
					if (decRep >= MAX_DECIMAL)
					{
						break;
					}
					if (decRep > closestDec)
					{
						closestDec = decRep;
						closestN = n;
					}
				}
			}

			return closestN.ToString();
		}
	}
}
