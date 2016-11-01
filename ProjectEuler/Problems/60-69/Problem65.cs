using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.Fractions;

namespace ProjectEuler.Problems
{
    public static class Problem65
    {
        private const int WhichConvergent = 100;

        public static string Solve()
        {
            int[] eNotation = ComputeContinuedFractionNotationForE(WhichConvergent);
            BigIntegerFraction rationalConvergent = FractionItUp(WhichConvergent, eNotation);
            int numeratorDigitSum = DigitUtils.GetDigits(rationalConvergent.Numerator).Sum();
            return numeratorDigitSum.ToString();
        }

        private static BigIntegerFraction FractionItUp(int convergentLimit, int[] eNotation)
        {
            return FractionHelper(0, convergentLimit, eNotation);
        }

        private static BigIntegerFraction FractionHelper(int convergentNum, int convergentLimit, int[] eNotation)
        {
            if (convergentNum >= convergentLimit)
            {
                return new BigIntegerFraction(0, 1);
            }
            else
            {
                BigIntegerFraction nextFraction = FractionHelper(convergentNum + 1, convergentLimit, eNotation);
                BigIntegerFraction flippedFraction = nextFraction.Numerator == 0 ? nextFraction : new BigIntegerFraction(nextFraction.Denominator, nextFraction.Numerator);
                return eNotation[convergentNum] + flippedFraction;
            }
        }

        private static int[] ComputeContinuedFractionNotationForE(int length)
        {
            int[] cfNotation = new int[length];
            int k = 1;
            for (int i = 0; i < length;)
            {
                if (i == 0)
                {
                    cfNotation[i++] = 2;
                }
                if (i < length)
                {
                    cfNotation[i++] = 1;
                }
                if (i < length)
                {
                    cfNotation[i++] = 2*k++;
                }
                if (i < length)
                {
                    cfNotation[i++] = 1;
                }
            }
            return cfNotation;
        }
    }
}
