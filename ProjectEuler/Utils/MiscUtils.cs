using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
    public static class MiscUtils
    {
        public static readonly Dictionary<int, int> DigitFactorials = new Dictionary<int, int>()
        {
            { 0, 1 },
            { 1, 1 },
            { 2, 2 },
            { 3, 6 },
            { 4, 24 },
            { 5, 120 },
            { 6, 720 },
            { 7, 5040 },
            { 8, 40320 },
            { 9, 362880 }
        };
        
        public static bool IsDivisibleBy(int x, int y)
        {
            return x % y == 0;
        }

        public static int EulerTotient(int n)
        {
            /*int count = 0;
            for (int i = 1; i < n; i++)
            {
                if (GetGCD(n, i) == 1)
                {
                    count++;
                }
            }
            return count;*/
            return EfficientPhi(n);
        }

        public static int EfficientPhi(int n)
        {
            int result = n;   // Initialize result as n

            // Consider all prime factors of n and subtract their
            // multiples from result
            for (int p = 2; p * p <= n; ++p)
            {
                // Check if i is a prime factor.
                if (n % p == 0)
                {
                    // If yes, then update n and result 
                    while (n % p == 0)
                        n /= p;
                    result -= result / p;
                }
            }

            // If n has a prime factor greater than sqrt(n)
            // (There can be at-most one such prime factor)
            if (n > 1)
                result -= result / n;
            return result;
        }

        public static int GetGCD(int u, int v)
        {
            int shift;

            /* GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0 */
            if (u == 0) return v;
            if (v == 0) return u;

            /* Let shift := lg K, where K is the greatest power of 2
                  dividing both u and v. */
            for (shift = 0; ((u | v) & 1) == 0; ++shift)
            {
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0)
                u >>= 1;

            /* From here on, u is always odd. */
            do
            {
                /* remove all factors of 2 in v -- they are not common */
                /*   note: v is not zero, so while will terminate */
                while ((v & 1) == 0)  /* Loop X */
                    v >>= 1;

                /* Now u and v are both odd. Swap if necessary so u <= v,
                   then set v = v - u (which is even). For bignums, the
                   swapping is just pointer movement, and the subtraction
                   can be done in-place. */
                if (u > v)
                {
                    int t = v; v = u; u = t;
                }  // Swap u and v.
                v = v - u;                       // Here v >= u.
            } while (v != 0);

            /* restore common factors of 2 */
            return u << shift;
        }

        public static BigInteger BigIntegerGCD(BigInteger left, BigInteger right)
        {
            // take absolute values
            if (left < 0)
                left = -left;

            if (right < 0)
                right = -right;

            // if we're dealing with any zero or one, the GCD is 1
            if (left < 2 || right < 2)
                return 1;

            do
            {
                if (left < right)
                {
                    BigInteger temp = left;  // swap the two operands
                    left = right;
                    right = temp;
                }

                left %= right;
            } while (left != 0);

            return right;
        }

        public static double DistanceFormula(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static bool IsInteger(double d)
        {
            return Math.Abs(d % 1) <= 0.0000000001;
        }
    }
}
