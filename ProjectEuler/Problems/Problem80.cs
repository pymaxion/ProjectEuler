using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    // https://en.wikipedia.org/wiki/Integer_square_root
    public static class Problem80
    {
        private const int Limit = 100;
        private const int DigitLimit = 100;
        private static HashSet<long> Squares = SquareUtils.GenerateSquaresLessThanNHashSetLong(Limit + 1);
        private static BigInteger HundredDec = BigInteger.Pow(10, 210);

        public static string Solve()
        {
            int hundredDecimalDigitSum = 0;

            for (int i = 1; i <= Limit; i++)
            {
                if (!Squares.Contains(i))
                {
                    BigInteger intSqrt = BigIntegerUtils.ComputeIntegerSquareRoot(i * HundredDec);
                    int[] decimalDigits = DigitUtils.GetDigits(intSqrt).Take(DigitLimit).ToArray();
                    int firstHundredDecimalDigits = decimalDigits.Sum();
                    hundredDecimalDigitSum += firstHundredDecimalDigits;
                }
            }

            return hundredDecimalDigitSum.ToString();
        }
    }
}
