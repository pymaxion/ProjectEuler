using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem70
	{
		private const int LIMIT = (int)1e7;
		
		public static string Solve()
		{
			Dictionary<int, int> totientPermutations = new Dictionary<int, int>();
			double minTotientRatio = Double.MaxValue;
			int nWithMinTotientRatio = 0;

			for (int n = 2; n < LIMIT; n++)
			{
				int totient = MiscUtils.EulerTotient(n);
				if (String.Equals(StringUtils.SortString(n.ToString()), StringUtils.SortString(totient.ToString())))
				{
					double totientRatio = (double)n / (double)totient;
					if (totientRatio < minTotientRatio)
					{
						minTotientRatio = totientRatio;
						nWithMinTotientRatio = n;
					}
					//totientPermutations.Add(n, totient);
				}
			}
			return nWithMinTotientRatio.ToString();
		}
	}
}
