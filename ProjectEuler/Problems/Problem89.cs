using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.RomanNumerals;

namespace ProjectEuler.Problems
{
    public static class Problem89
    {
        public static readonly string romansFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p089_roman.txt";

        public static string Solve()
        {
            List<string> romanNumerals = FileUtils.ReadFileIntoList(romansFilepath, 1000);
            int romanNumeralCharacterCount = romanNumerals.Sum(n => n.Length);
            IEnumerable<string> minimalRomanNumerals = romanNumerals.Select(n => (new RomanNumeral(n)).MinimalWrittenForm);
            int minimalRomanNumeralCharacterCount = minimalRomanNumerals.Sum(n => n.Length);
            int diff = romanNumeralCharacterCount - minimalRomanNumeralCharacterCount;
            return diff.ToString();
        }
    }
}
