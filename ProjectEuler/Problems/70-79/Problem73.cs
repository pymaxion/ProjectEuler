using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{	
	public static class Problem73
	{
		private const int MAX_D = 12000;
		private const decimal MIN_DECIMAL = ((decimal)1 / (decimal)3);
		private const decimal MAX_DECIMAL = ((decimal)1 / (decimal)2);

		public static string Solve()
		{
			HashSet<decimal> decReps = new HashSet<decimal>();

			for (int d = 8; d <= MAX_D; d++)
			{
				int minN = (int)(d * MIN_DECIMAL) - 1;
				int maxN = (int)(d * MAX_DECIMAL) + 1;
				
				for (int n = minN; n <= maxN; n++)
				{
					decimal decRep = (decimal)n / (decimal)d;
					if (!decReps.Contains(decRep) && decRep > MIN_DECIMAL && decRep < MAX_DECIMAL)
					{
						decReps.Add(decRep);
					}
				}
			}

			return decReps.Count.ToString();
		}
	}
}
