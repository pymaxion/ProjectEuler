using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class DigitUtils
	{
		public static int GetNumberOfDigits(int n)
		{
			return (int)Math.Floor(Math.Log10(n) + 1);
		}

		public static int GetNumberOfDigits(long n)
		{
			return (int)Math.Floor(Math.Log10(n) + 1);
		}

		public static int GetNumberOfDigits(BigInteger n)
		{
			return (int)Math.Floor(BigInteger.Log10(n) + 1);
		}

		public static int[] GetDigits(int n)
		{
			string numAsStr = n.ToString();
			int[] digitsAry = new int[numAsStr.Length];
			for (int i = 0; i < numAsStr.Length; i++)
			{
				digitsAry[i] = Int32.Parse(numAsStr[i].ToString());
			}
			return digitsAry;
		}

		public static int[] GetDigits(long n)
		{
			string numAsStr = n.ToString();
			int[] digitsAry = new int[numAsStr.Length];
			for (int i = 0; i < numAsStr.Length; i++)
			{
				digitsAry[i] = Int32.Parse(numAsStr[i].ToString());
			}
			return digitsAry;
		}

		public static int[] GetDigits(BigInteger n)
		{
			string numAsStr = n.ToString();
			int[] digitsAry = new int[numAsStr.Length];
			for (int i = 0; i < numAsStr.Length; i++)
			{
				digitsAry[i] = Int32.Parse(numAsStr[i].ToString());
			}
			return digitsAry;
		}

		public static bool IsPandigital(int n, int pandigitalStart)
		{
			int[] digits = GetDigits(n);

			if (pandigitalStart == 0)
			{
				if (digits.Length != 10)
				{
					if (digits.Length != 9)
					{
						return false;
					}
					digits = AddLeadingZeros(digits, 10);
				}
			}

			Array.Sort(digits);
			for (int i = pandigitalStart; i <= digits.Length; i++)
			{
				if (digits[i - pandigitalStart] != i)
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsPandigital(long n, int pandigitalStart)
		{
			int[] digits = GetDigits(n);

			if (pandigitalStart == 0)
			{
				if (digits.Length != 10)
				{
					if (digits.Length != 9)
					{
						return false;
					}
					digits = AddLeadingZeros(digits, 10);
				}
			}

			Array.Sort(digits);
			for (int i = pandigitalStart; i <= digits.Length; i++)
			{
				if (digits[i - pandigitalStart] != i)
				{
					return false;
				}
			}
			return true;
		}

		public static int DigitListToInt(IEnumerable<int> digitList)
		{
			string intStr = "";
			foreach (int digit in digitList)
			{
				intStr += digit;
			}
			return Int32.Parse(intStr);
		}

		public static long DigitListToLong(IEnumerable<int> digitList)
		{
			string intStr = "";
			foreach (int digit in digitList)
			{
				intStr += digit;
			}
			return Int64.Parse(intStr);
		}

		public static int[] AddLeadingZeros(int[] digits, int desiredLength)
		{
			int numZerosToAdd = desiredLength - digits.Length;
			return (new int[numZerosToAdd]).Concat(digits).ToArray();
		}
	}
}
