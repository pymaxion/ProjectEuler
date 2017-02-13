using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils.RomanNumerals
{
    public class RomanNumeral
    {
        private static Dictionary<int, string> ValueToFormDict = new Dictionary<int, string>()
        {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" },
        };

        private static Dictionary<string, int> FormToValueDict = new Dictionary<string, int>()
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
        };


        public string WrittenForm { get; set; }
        public string MinimalWrittenForm { get; set; }
        public int Value { get; set; }

        public RomanNumeral(int n)
        {
            Value = n;
            WrittenForm = GetMinimalWrittenForm(n);
            MinimalWrittenForm = WrittenForm;            
        }

        public RomanNumeral(string writtenForm)
        {
            WrittenForm = writtenForm;
            Value = ParseWrittenForm(writtenForm);
            MinimalWrittenForm = GetMinimalWrittenForm(Value);
        }

        private static string GetMinimalWrittenForm(int n)
        {
            string writtenForm = "";

            while (n >= FormToValueDict["M"])
            {
                writtenForm += "M";
                n -= FormToValueDict["M"];
            }

            if (n >= 9 * FormToValueDict["C"]) // subtractive rule!
            {
                writtenForm += "CM";
                n -= 9 * FormToValueDict["C"];
            }

            // only one D is allowed
            if (n >= FormToValueDict["D"])
            {
                writtenForm += "D";
                n -= FormToValueDict["D"];
            }

            while (n >= FormToValueDict["C"])
            {
                if (n >= 4 * FormToValueDict["C"]) // subtractive rule!
                {
                    writtenForm += "CD";
                    n -= 4 * FormToValueDict["C"];
                }
                else
                {
                    writtenForm += "C";
                    n -= FormToValueDict["C"];
                }
            }

            if (n >= 9 * FormToValueDict["X"]) // subtractive rule!
            {
                writtenForm += "XC";
                n -= 9 * FormToValueDict["X"];
            }

            // only one L is allowed
            if (n >= FormToValueDict["L"])
            {
                writtenForm += "L";
                n -= FormToValueDict["L"];
            }

            while (n >= FormToValueDict["X"])
            {
                if (n >= 4 * FormToValueDict["X"]) // subtractive rule!
                {
                    writtenForm += "XL";
                    n -= 4 * FormToValueDict["X"];
                }
                else
                {
                    writtenForm += "X";
                    n -= FormToValueDict["X"];
                }
            }

            if (n >= 9 * FormToValueDict["I"]) // subtractive rule!
            {
                writtenForm += "IX";
                n -= 9 * FormToValueDict["I"];
            }

            // only one V is allowed
            if (n >= FormToValueDict["V"])
            {
                writtenForm += "V";
                n -= FormToValueDict["V"];
            }

            while (n >= FormToValueDict["I"])
            {
                if (n >= 4 * FormToValueDict["I"]) // subtractive rule!
                {
                    writtenForm += "IV";
                    n -= 4 * FormToValueDict["I"];
                }
                else
                {
                    writtenForm += "I";
                    n -= FormToValueDict["I"];
                }
            }

            return writtenForm;
        }

        private static int ParseWrittenForm(string writtenForm)
        {
            int n = 0;
            string[] chars = writtenForm.Select(c => c.ToString()).ToArray();
            for (int i = 0; i < chars.Length; i++)
            {
                string thisChar = chars[i];
                if (i != chars.Length - 1 && IsSubtractivePair(thisChar, chars[i + 1]))
                {
                    n += FormToValueDict[chars[i + 1]] - FormToValueDict[thisChar];
                    i++;
                }
                else
                {
                    n += FormToValueDict[thisChar];
                }
            }
            return n;
        }

        private static bool IsSubtractivePair(string firstChar, string secondChar)
        {
            return (firstChar.Equals("C") || firstChar.Equals("X") || firstChar.Equals("I")) && FormToValueDict[secondChar] > FormToValueDict[firstChar];
        }
    }
}
