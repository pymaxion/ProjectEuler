using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class FileUtils
	{
		public static List<string> ReadFileIntoList(string filepath, int defaultCapacity = 0)
		{
			StreamReader file = new StreamReader(filepath);
			List<string> lines = ((defaultCapacity > 0) ? new List<string>(defaultCapacity) : new List<string>());
			string line;
			while ((line = file.ReadLine()) != null)
			{
				lines.Add(line);
			}
			file.Close();
			return lines;
		}

		public static string ReadFileIntoString(string filepath)
		{	
			StreamReader file = new StreamReader(filepath);
			string fileAsString = file.ReadToEnd();
			file.Close();
			return fileAsString;
		}
	}
}
