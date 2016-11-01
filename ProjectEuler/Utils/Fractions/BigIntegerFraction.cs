using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Utils.Fractions
{
    public class BigIntegerFraction
    {
        public BigInteger Numerator { get; set; }
        public BigInteger Denominator { get; set; }

        public BigIntegerFraction(BigInteger wholeNumber)
        {
            Numerator = wholeNumber;
            Denominator = 1;
            // no reducing required, we're a whole number
        }

        public BigIntegerFraction(BigInteger numerator, BigInteger denominator)
        {
            Tuple<BigInteger, BigInteger> reducedFrac = ReduceFraction(numerator, denominator);
            Numerator = reducedFrac.Item1;
            Denominator = reducedFrac.Item2;
        }

        public static Tuple<BigInteger, BigInteger> ReduceFraction(BigInteger numerator, BigInteger denominator) 
        {
            BigInteger iGCD = MiscUtils.BigIntegerGCD(numerator, denominator);
            numerator /= iGCD;
            denominator /= iGCD;

            // if negative sign in denominator
            if (denominator < 0)
            {
                //move negative sign to numerator
                numerator = -numerator;
                denominator = -denominator;
            }

            return new Tuple<BigInteger, BigInteger>(numerator, denominator);
        }

        private static BigIntegerFraction Add(BigIntegerFraction left, BigIntegerFraction right)
        {
            BigInteger gcd = MiscUtils.BigIntegerGCD(left.Denominator, right.Denominator); // cannot return less than 1
            BigInteger leftDenominator = left.Denominator / gcd;
            BigInteger rightDenominator = right.Denominator / gcd;

            try
            {
                checked
                {
                    BigInteger numerator = left.Numerator * rightDenominator + right.Numerator * leftDenominator;
                    BigInteger denominator = leftDenominator * rightDenominator * gcd;

                    return new BigIntegerFraction(numerator, denominator);
                }
            }
            catch (Exception e)
            {
                throw new FractionException("Add error", e);
            }
        }

        public static BigIntegerFraction operator +(BigIntegerFraction left, BigIntegerFraction right)
        {
            return Add(left, right);
        }

        public static BigIntegerFraction operator +(BigInteger left, BigIntegerFraction right)
        {
            return Add(new BigIntegerFraction(left), right);
        }

        public static BigIntegerFraction operator +(BigIntegerFraction left, BigInteger right)
        {
            return Add(left, new BigIntegerFraction(right));
        }

        public static BigIntegerFraction FractionItUp(int convergentLimit, int[] eNotation)
        {
            return FractionHelper(0, convergentLimit, eNotation);
        }

        public static BigIntegerFraction FractionHelper(int convergentNum, int convergentLimit, int[] cfNotation)
        {
            if (convergentNum >= convergentLimit)
            {
                return new BigIntegerFraction(0, 1);
            }
            else
            {
                BigIntegerFraction nextFraction = FractionHelper(convergentNum + 1, convergentLimit, cfNotation);
                BigIntegerFraction flippedFraction = nextFraction.Numerator == 0 ? nextFraction : new BigIntegerFraction(nextFraction.Denominator, nextFraction.Numerator);

                if (convergentNum >= cfNotation.Length)
                {
                    var repeatingPart = cfNotation.Skip(1);
                    var list = cfNotation.ToList();
                    list.AddRange(repeatingPart);
                    cfNotation = list.ToArray();
                }

                return cfNotation[convergentNum] + flippedFraction;
            }
        }
    }
}
