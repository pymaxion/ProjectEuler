using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Problems;

namespace ProjectEuler
{
	public class ProjectEuler
	{
		public static void Main(string[] args)
		{
			string solutionString;
			Stopwatch sw = new Stopwatch();
			sw.Start();

			// ---------------------------------------------------
			solutionString = Problem84.Solve();
			// ---------------------------------------------------

			sw.Stop();
			Console.WriteLine(solutionString);
			Console.WriteLine("\nTook " + sw.Elapsed.TotalSeconds + " seconds");
			Console.ReadKey();
		}
	}
}
