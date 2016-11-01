using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem98
	{
		public static readonly string wordsFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p098_words.txt";

		public static string Solve()
		{
			Dictionary<string, Tuple<string, string, long, long>> squareAnagramWordPairs = new Dictionary<string, Tuple<string, string, long, long>>();

			string wordsAsString = FileUtils.ReadFileIntoString(wordsFilepath);
			wordsAsString = wordsAsString.Remove(0, 1); // remove first char, quotation mark
			wordsAsString = wordsAsString.Remove(wordsAsString.Length - 1, 1); // remove last char, quotation mark
			List<string> wordsList = wordsAsString.Split(("\",\"").ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
			HashSet<string> wordsSet = new HashSet<string>(GetWordsWithAnagrams(wordsList));

			int maxLen = 0;
			foreach (string word in wordsSet)
			{
				if (word.Length > maxLen)
				{
					maxLen = word.Length;
				}
			}

			Dictionary<int, HashSet<long>> lengthSquaresMap = new Dictionary<int, HashSet<long>>();
			long totalIdx = 1;
			for (int i = 1; i <= maxLen; i++)
			{
				HashSet<long> lengthSquares = new HashSet<long>();
				for (; totalIdx * totalIdx < Math.Pow(10, i); totalIdx++)
				{
					lengthSquares.Add(totalIdx * totalIdx);
				}
				lengthSquaresMap.Add(i, lengthSquares);
			}

			foreach (string word in wordsSet)
			{
				Dictionary<string, List<string>> anaDict;
				List<long> rightLengthAnagramSquares = GetSquaresWithAnagramsAndDict(lengthSquaresMap[word.Length].ToList(), out anaDict);
				foreach (long rightLengthSquare in rightLengthAnagramSquares)
				{
					Dictionary<int, char> digitCharMap;
					if (MapsToSquare(word, rightLengthSquare, out digitCharMap))
					{
						List<long> squarePermutations = anaDict[StringUtils.SortString(rightLengthSquare.ToString())]
							.Select(p => Int64.Parse(p)).ToList();
						squarePermutations.Remove(rightLengthSquare);

						foreach (long squarePerm in squarePermutations)
						{
							string wordPermutation = "";
							foreach (int digit in DigitUtils.GetDigits(squarePerm))
							{
								wordPermutation += digitCharMap[digit];
							}
							if (wordsSet.Contains(wordPermutation))
							{
								string key = StringUtils.SortString(word);
								if (!squareAnagramWordPairs.ContainsKey(key))
								{
									squareAnagramWordPairs.Add(key, new Tuple<string, string, long, long>(word, wordPermutation, rightLengthSquare, squarePerm));
								}
							}
						}
					}
				}
			}

			long maxSquare = 0;
			foreach (Tuple<string, string, long, long> soln in squareAnagramWordPairs.Values)
			{
				if (soln.Item3 > maxSquare)
				{
					maxSquare = soln.Item3;
				}
				if (soln.Item4 > maxSquare)
				{
					maxSquare = soln.Item4;
				} 
			}

			return maxSquare.ToString();
		}

		private static bool MapsToSquare(string word, long square, out Dictionary<int, char> digitCharMap)
		{
			Dictionary<char, int> charDigitMap = new Dictionary<char, int>();
			digitCharMap = new Dictionary<int, char>();
			char[] chars = word.ToCharArray();
			int[] digits = DigitUtils.GetDigits(square);
			for (int i = 0; i < chars.Length; i++)
			{
				if (!charDigitMap.ContainsKey(chars[i]))
				{
					charDigitMap.Add(chars[i], digits[i]);
				}
				else
				{
					if (charDigitMap[chars[i]] != digits[i])
					{
						return false;
					}
				}

				if (!digitCharMap.ContainsKey(digits[i]))
				{
					digitCharMap.Add(digits[i], chars[i]);
				}
				else
				{
					if (digitCharMap[digits[i]] != chars[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		private static List<string> GetWordsWithAnagrams(List<string> words)
		{
			Dictionary<string, List<string>> anagramsMappedBySortedString = new Dictionary<string, List<string>>();
			foreach (string word in words)
			{
				string key = StringUtils.SortString(word);
				if (anagramsMappedBySortedString.ContainsKey(key))
				{
					anagramsMappedBySortedString[key].Add(word);
				}
				else
				{
					List<string> anagrams = new List<string>();
					anagrams.Add(word);
					anagramsMappedBySortedString.Add(key, anagrams);
				}
			}

			List<string> wordsWithAnagrams = new List<string>();
			foreach (KeyValuePair<string, List<string>> kvp in anagramsMappedBySortedString)
			{
				if (kvp.Value.Count > 1)
				{
					foreach (string anagramWord in kvp.Value)
					{
						wordsWithAnagrams.Add(anagramWord);
					}
				}
			}

			return wordsWithAnagrams;
		}

		private static List<string> GetWordsWithAnagramsAndDict(List<string> words, out Dictionary<string, List<string>> anagramsMappedBySortedString)
		{
			anagramsMappedBySortedString = new Dictionary<string, List<string>>();
			foreach (string word in words)
			{
				string key = StringUtils.SortString(word);
				if (anagramsMappedBySortedString.ContainsKey(key))
				{
					anagramsMappedBySortedString[key].Add(word);
				}
				else
				{
					List<string> anagrams = new List<string>();
					anagrams.Add(word);
					anagramsMappedBySortedString.Add(key, anagrams);
				}
			}

			List<string> wordsWithAnagrams = new List<string>();
			foreach (KeyValuePair<string, List<string>> kvp in anagramsMappedBySortedString)
			{
				if (kvp.Value.Count > 1)
				{
					foreach (string anagramWord in kvp.Value)
					{
						wordsWithAnagrams.Add(anagramWord);
					}
				}
			}

			return wordsWithAnagrams;
		}

		private static List<long> GetSquaresWithAnagramsAndDict(List<long> squares, out Dictionary<string, List<string>> anaDict)
		{
			Dictionary<long, List<long>> squaresAnagramDict = new Dictionary<long, List<long>>();
			return GetWordsWithAnagramsAndDict(squares.Select(num => num.ToString()).ToList(), out anaDict)
				.Select(str => Int64.Parse(str)).ToList();
		}
	}
}
