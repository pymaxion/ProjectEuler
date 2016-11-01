using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.Fractions;

namespace ProjectEuler.Problems
{
	public static class Problem57
	{
		public static string Solve()
		{
			int expansionCount = 0;
			int solutionCount = 0;
			BigInteger convergentNumerator = 1;
			BigInteger convergentDenominator = 1;

			while (expansionCount < 1000)
			{
				BigInteger newDenom = convergentNumerator + convergentDenominator;
				BigInteger newNumer = convergentDenominator + newDenom;

				if (DigitUtils.GetNumberOfDigits(newNumer) > DigitUtils.GetNumberOfDigits(newDenom))
				{
					solutionCount++;
				}

				convergentNumerator = newNumer;
				convergentDenominator = newDenom;
				expansionCount++;
			}

			return solutionCount.ToString();
		}
	}
}
