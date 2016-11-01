using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem22
	{
		public static readonly string namesFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p022_names.txt";
		
		public static string Solve()
		{
			string namesAsString = FileUtils.ReadFileIntoString(namesFilepath);
			namesAsString = namesAsString.Remove(0, 1); // remove first char, quotation mark
			namesAsString = namesAsString.Remove(namesAsString.Length - 1, 1); // remove last char, quotation mark
			List<string> namesList = namesAsString.Split(("\",\"").ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
			namesList.Sort();

			long totalScore = 0;
			for (int i = 0; i < namesList.Count; i++)
			{
				totalScore += ((i + 1) * Alphabet.ComputeAlphabetScore(namesList[i]));
			}
			return totalScore.ToString();
		}
	}
}
