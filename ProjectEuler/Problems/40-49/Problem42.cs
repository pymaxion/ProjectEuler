using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem42
	{
		public static readonly string namesFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p042_words.txt";

		public static string Solve()
		{
			string wordsAsString = FileUtils.ReadFileIntoString(namesFilepath);
			wordsAsString = wordsAsString.Remove(0, 1); // remove first char, quotation mark
			wordsAsString = wordsAsString.Remove(wordsAsString.Length - 1, 1); // remove last char, quotation mark
			List<string> wordsList = wordsAsString.Split(("\",\"").ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

			// get max word length, mult by 26, get triangle nums up to that
			int maxLength = 0;
			foreach (string word in wordsList)
			{
				if (word.Length > maxLength)
				{
					maxLength = word.Length;
				}
			}
			int triangleNumLimit = maxLength * 26;
			List<int> triangleNums = SequenceUtils.GenerateTriangleNumbersLessThanN(triangleNumLimit);

			// iterate through words, count number of triangle-valued words
			int triangleWordCount = 0;
			foreach (string word in wordsList)
			{
				if (triangleNums.Contains(Alphabet.ComputeAlphabetScore(word)))
				{
					triangleWordCount++;
				}
			}

			return triangleWordCount.ToString();
		}
	}
}
