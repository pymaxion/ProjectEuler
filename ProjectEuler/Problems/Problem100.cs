using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public static class Problem100
    {
        public static string Solve()
        {
            // build set of squares for this problem
            List<BigInteger> squares = new List<BigInteger>();

            BigInteger startRoot = BigIntegerUtils.ComputeIntegerSquareRoot(2 * BigInteger.Pow(10, 24)) + 1;
            BigInteger square;
            do
            {
                square = startRoot * startRoot;
                squares.Add(square);
                startRoot++;
            }
            while (squares.Count < 1000000);

            List<BigInteger> validDs = new List<BigInteger>();
            foreach (BigInteger sq in squares)
            {
                BigInteger dSquareRoot = BigIntegerUtils.ComputeIntegerSquareRoot(1 + 2 * (sq - 1));
                BigInteger d = (1 + dSquareRoot) / 2;
                validDs.Add(d);
            }


            foreach (BigInteger d in validDs.Where(x => x >= BigInteger.Pow(10, 12)))
            {
                BigInteger nSquareRoot = BigIntegerUtils.ComputeIntegerSquareRoot(1 + 2 * ((d * d) - d));
                BigInteger n = (1 + nSquareRoot) / 2;
                if (((2 * (n * n)) - (2 * n)) == ((d * d) - d)) 
                {
                    return n.ToString();
                }
            }

            return "Not found";
        }
    }
}
