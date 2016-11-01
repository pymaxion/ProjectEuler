using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem38
	{
		public static string Solve()
		{
			List<int> pandigitalConcatInts = new List<int>();
			
			for (int len = 2; len < 10; len++)
			{
				int[] intList = GenerateIntList(len);
				int number = 1;

				while (true)
				{
					List<int> products = new List<int>();
					HashSet<int> digitsInConcattedProducts = new HashSet<int>();
					int concattedLength = 0;
					bool breakFlag = false;

					foreach (int n in intList)
					{
						int product = number * n;
						int[] productDigits = DigitUtils.GetDigits(product);

						concattedLength += productDigits.Length;
						if (concattedLength > 9)
						{
							breakFlag = true;
							break;
						}

						if (digitsInConcattedProducts.Any(x => productDigits.Contains(x)))
						{
							break;
						}
						else
						{
							foreach (int digit in productDigits)
							{
								digitsInConcattedProducts.Add(digit);
							}
						}

						products.Add(product);
					}

					if (breakFlag)
					{
						break;
					}

					if (concattedLength == 9)
					{
						string concatStr = "";
						foreach (int product in products)
						{
							concatStr += product;
						}
						int concatInt = Int32.Parse(concatStr);
						if (DigitUtils.IsPandigital(concatInt, 1))
						{
							pandigitalConcatInts.Add(Int32.Parse(concatStr));
						}
					}

					number++;
				}
			}

			int maxPandigitalConcat = 0;
			foreach (int pandigitalConcat in pandigitalConcatInts)
			{
				if (pandigitalConcat > maxPandigitalConcat)
				{
					maxPandigitalConcat = pandigitalConcat;
				}
			}

			return maxPandigitalConcat.ToString();
		}

		private static int[] GenerateIntList(int n)
		{
			int[] intList = new int[n];
			for (int i = 0; i < n; i++)
			{
				intList[i] = i + 1;
			}
			return intList;
		}
	}
}
