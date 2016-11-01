using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem79
	{
		public static readonly string keylogFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p079_keylog.txt";

		public static string Solve()
		{
			List<string> logins = FileUtils.ReadFileIntoList(keylogFilepath, 50);



			return "";
		}
	}
}
