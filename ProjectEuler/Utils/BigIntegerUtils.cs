using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class BigIntegerUtils
    {
        public static BigInteger ComputeIntegerSquareRoot(BigInteger n)
        {
            //List<BigInteger> xs = new List<BigInteger>();
            BigInteger xNext = n / 2;
            BigInteger xThis;
            do 
            {
                xThis = xNext;
                //xs.Add(xThis);
                xNext = (xThis + (n / xThis)) / 2;
            }
            while (xNext != xThis && BigInteger.Abs(xNext - xThis) != 1);

            return xThis;
        }
    }
}
