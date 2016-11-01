using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.Fractions;

namespace ProjectEuler.Problems
{
	public static class Problem33
	{
		public static string Solve()
		{
			Dictionary<int, int> fractList = new Dictionary<int, int>();
			
			// loop denom and numer
			for (int denom = 11; denom < 100; denom++)
			{
				for (int numer = 10; numer < denom; numer++)
				{
					int[] numerDigits = DigitUtils.GetDigits(numer);
					int[] denomDigits = DigitUtils.GetDigits(denom);

					for (int i = 0; i < 2; i++)
					{
						for (int j = 0; j < 2; j++)
						{
							if (numerDigits[i] != 0 && numerDigits[i] == denomDigits[j])
							{
								Fraction original = new Fraction(numer, denom);
								Fraction cancelled = new Fraction(numerDigits[1 - i], denomDigits[1 - j]);

								if (original == cancelled)
								{
									fractList.Add(numer, denom);
								}
							}
						}
					}
				}
			}

			int productNumerator = 1;
			int productDenominator = 1;

			foreach (KeyValuePair<int, int> fraction in fractList)
			{
				productNumerator *= fraction.Key;
				productDenominator *= fraction.Value;
			}

			return new Fraction(productNumerator, productDenominator).ToString();
		}
	}
}
