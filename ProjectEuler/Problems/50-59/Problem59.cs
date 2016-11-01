using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem59
	{
		public static readonly string cipherFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p059_cipher.txt";
		
		public static string Solve()
		{
			string fileAsString = FileUtils.ReadFileIntoString(cipherFilepath);
			byte[] cipherBytes = fileAsString.Split(",".ToCharArray()).Select(b => Byte.Parse(b)).ToArray();
			byte[] potentialKey = new byte[3];
			char[] plaintextChars = new char[cipherBytes.Length];

			for (byte keyChar1 = 97; keyChar1 < 123; keyChar1++)
			{
				potentialKey[0] = keyChar1;
				for (byte keyChar2 = 97; keyChar2 < 123; keyChar2++)
				{
					potentialKey[1] = keyChar2;
					for (byte keyChar3 = 97; keyChar3 < 123; keyChar3++)
					{
						potentialKey[2] = keyChar3;
						for (int i = 0; i < cipherBytes.Length; i++)
						{
							plaintextChars[i] = (char)(cipherBytes[i] ^ potentialKey[i % 3]);
						}
						string plaintext = new string(plaintextChars);
						if (plaintext.Contains(" the ") || plaintext.Contains(" and "))
						{
							// we'll assume this is the right decryption
							int asciiSum = 0;
							foreach (char plaintextChar in plaintextChars)
							{
								asciiSum += (int)((byte)plaintextChar);
							}
							return asciiSum.ToString();
						}
					}
				}
			}


			return "";
		}
	}
}
