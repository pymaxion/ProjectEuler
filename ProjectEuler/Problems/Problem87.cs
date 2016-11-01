using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public static class Problem87
    {
        public const int Limit = 50000000;

        public static string Solve()
        {
            return SolveImpl().ToString(); ;
        }

        public static int SolveImpl()
        {
            HashSet<int> primes = PrimeUtils.GeneratePrimesLessThanNHashSet((int)Math.Floor(Math.Sqrt(Limit)));
            var primesSquared = primes.Select(p => p * p).Where(p2 => p2 <= (Limit - 25));
            var primesCubed = primes.Select(p => p * p * p).Where(p3 => p3 <= (Limit - 20));
            var primesFourthed = primes.Select(p => p * p * p * p).Where(p4 => p4 <= (Limit - 12));

            HashSet<int> squaredPlusCubeds = new HashSet<int>();
            foreach (int primeSquared in primesSquared)
            {
                foreach (int primeCubed in primesCubed)
                {
                    int sum = primeSquared + primeCubed;
                    if (sum > (Limit - 16) || sum < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (!squaredPlusCubeds.Contains(sum))
                        {
                            squaredPlusCubeds.Add(sum);
                        }
                    }
                }
            }

            HashSet<int> cubedPlusFourtheds = new HashSet<int>();
            foreach (int squaredPlusCubed in squaredPlusCubeds)
            {
                foreach (int primeFourthed in primesFourthed)
                {
                    int sum = squaredPlusCubed + primeFourthed;
                    if (sum > Limit || sum < 0)
                    {
                        break;
                    }
                    else
                    {
                        if (!cubedPlusFourtheds.Contains(sum))
                        {
                            cubedPlusFourtheds.Add(sum);
                        }
                    }
                }
            }

            return cubedPlusFourtheds.Count();
        }
    }
}
