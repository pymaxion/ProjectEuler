using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.Fractions;

namespace ProjectEuler.Problems
{
    public static class Problem64
    {
        private const int nLimit = 10000;

        public static string Solve()
        {
            HashSet<long> squares = SquareUtils.GenerateSquaresLessThanNHashSetLong(nLimit + 1);
            int oddPeriodCount = 0;

            for (int i = 1; i <= nLimit; i++)
            {
                if (!squares.Contains((long)i))
                {
                    int[] continuedFractionExpansion = FractionUtils.GetSquareRootContinuedFractionExpansion(i);
                    if ((continuedFractionExpansion.Length - 1) % 2 != 0)
                    {
                        oddPeriodCount++;
                    }
                }
            }
                
            return oddPeriodCount.ToString();
        }
    }
}
