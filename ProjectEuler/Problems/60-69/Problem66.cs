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
    //----- http://mathworld.wolfram.com/PellEquation.html -----//
    //----- https://en.wikipedia.org/wiki/Pell's_equation#Fundamental_solution_via_continued_fractions -----//
    public static class Problem66
    {
        private const int MaxD = 1000;

        public static string Solve()
        {
            BigInteger largestX = 0;
            int solnD = 0;

            List<int> ds = Enumerable.Range(1, MaxD).ToList();
            HashSet<long> squares = SquareUtils.GenerateSquaresLessThanNHashSetLong(MaxD);
            ds.RemoveAll(d => squares.Contains((long)d));

            foreach (int d in ds)
            {
                int[] continuedFractionExpansion = FractionUtils.GetSquareRootContinuedFractionExpansion(d);
                bool solutionFound = false;
                int whichConvergent = 0;

                while (!solutionFound)
                {
                    whichConvergent++;
                    BigIntegerFraction rationalConvergent = BigIntegerFraction.FractionItUp(whichConvergent, continuedFractionExpansion);
                    if (IsSolution(rationalConvergent.Numerator, rationalConvergent.Denominator, d))
                    {
                        solutionFound = true;
                        if (rationalConvergent.Numerator > largestX)
                        {
                            largestX = rationalConvergent.Numerator;
                            solnD = d;
                        }
                    }
                }
            }

            return solnD.ToString();
        }

        private static bool IsSolution(BigInteger x, BigInteger y, int d)
        {
            return (x * x) - (d * (y * y)) == 1;
        }
    }
}
