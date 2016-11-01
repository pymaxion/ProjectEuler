using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class StringUtils
	{
		public static List<string> GenerateStringRotations(string str)
		{
			List<string> rotations = new List<string>(str.Length);
			char[] chars = str.ToCharArray();
			char[] rotation;
			for (int i = 0; i < chars.Length; i++)
			{
				rotation = new char[chars.Length];
				Array.Copy(chars, i, rotation, 0, chars.Length - i);
				Array.Copy(chars, 0, rotation, chars.Length - i, i);
				rotations.Add(new string(rotation));
			}
			return rotations;
		}
		
		public static string SortString(string str) 
		{
			return String.Concat(str.OrderBy(c => c));
		}

		public static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		public static bool IsPalindrome(string str)
		{
			return String.Equals(str, Reverse(str));
		}
	}
}
