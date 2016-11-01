using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.Sudoku;

namespace ProjectEuler.Problems
{
	public static class Problem96
	{
		public const int SIDELEN = 9;
		public static readonly string sudokuFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p096_sudoku.txt";
		
		public static string Solve()
		{
			int answer = 0;
			
			List<string> lines = FileUtils.ReadFileIntoList(sudokuFilepath);
			for (int i = 0; i < lines.Count; i += 10)
			{
				Puzzle sudokuPuzzle = new Puzzle(lines.Skip(i + 1).Take(SIDELEN).ToList(), SIDELEN);
				sudokuPuzzle.Solve();
				answer += sudokuPuzzle.AnswerInt;
			}

			return answer.ToString();
		}
	}
}
