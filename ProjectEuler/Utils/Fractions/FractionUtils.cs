using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils.Fractions
{
    public static class FractionUtils
    {
        // This comes from https://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Continued_fraction_expansion
        public static int[] GetSquareRootContinuedFractionExpansion(int num)
        {
            List<int> expansion = new List<int>();
            int mStart = 0;
            int dStart = 1;
            int aStart = (int)Math.Floor(Math.Sqrt(num));

            int m = mStart;
            int d = dStart;
            int a = aStart;
            expansion.Add(a);

            do
            {
                m = (d * a) - m;
                d = (num - (m * m)) / d;
                a = (int)Math.Floor((double)(aStart + m) / d);
                expansion.Add(a);
            }
            while (a != 2 * aStart);

            return expansion.ToArray();
        }
    }
}
