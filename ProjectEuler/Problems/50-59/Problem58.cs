using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem58
	{
		public static string Solve()
		{
			HashSet<long> primesOnDiags = new HashSet<long>();

			int sideLen = 1;
			bool primeDiagRatioBelow10Percent = false;

			while (!primeDiagRatioBelow10Percent)
			{
				sideLen += 2;
				for (int x = 0; x < sideLen; x += sideLen - 1)
				{
					for (int y = 0; y < sideLen; y += sideLen - 1)
					{
						long numAt = PrimeUtils.GetLongNumAtCoordinatesOnPrimeSpiral(x, y, sideLen);
						if (PrimeUtils.IsPrime(numAt))
						{
							primesOnDiags.Add(numAt);
						}
					}
				}

				double primeDiagRatio = (double)primesOnDiags.Count / (double)(sideLen * 2 - 1);
				primeDiagRatioBelow10Percent = primeDiagRatio < 0.1;
			}

			return sideLen.ToString();
		}
	}
}
