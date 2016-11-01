using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem69
	{
		private const int LIMIT = (int)1e6;
		
		public static string Solve()
		{
			double maxTotientRatio = 0;
			int nOfMaxTotientRatio = 0;

			for (int n = 2; n <= LIMIT; n += 2)
			{
				double totientRatio = n / (double)MiscUtils.EfficientPhi(n);
				if (totientRatio > maxTotientRatio)
				{
					maxTotientRatio = totientRatio;
					nOfMaxTotientRatio = n;
				}
			}

			return nOfMaxTotientRatio.ToString();
		}
	}
}
