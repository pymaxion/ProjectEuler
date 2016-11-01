using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils.Sudoku
{
	public class Puzzle
	{
		public int[][] PuzzleRows { get; private set; }
		public HashSet<int>[][] PossibilitiesGrid { get; private set; }
		
		public Puzzle(List<string> rows, int sideLen)
		{
			PuzzleRows = new int[sideLen][];

			for (int i = 0; i < rows.Count; i++)
			{
				PuzzleRows[i] = new int[sideLen];
				char[] rowChars = rows[i].ToCharArray();
				for (int j = 0; j < rowChars.Length; j++)
				{
					PuzzleRows[i][j] = Int32.Parse(rowChars[j] + "");
				}
			}
		}

		public void Solve()
		{
			DoPureLogic();
			if (IsUnsolved())
			{
				GuessAndCheck();
			}
		}

		private void DoPureLogic()
		{
			bool changed;
			do
			{
				changed = false;
				BuildPossibilitiesGrid();
				for (int x = 0; x < PuzzleRows.Length; x++)
				{
					for (int y = 0; y < PuzzleRows.Length; y++)
					{
						if (PuzzleRows[x][y] == 0 && PossibilitiesGrid[x][y].Count == 1)
						{
							PuzzleRows[x][y] = PossibilitiesGrid[x][y].First();
							changed = true;
							PossibilitiesGrid[x][y].RemoveWhere(xs => true);
						}
					}
				}
			}
			while (changed);
		}

		private void BuildPossibilitiesGrid()
		{
			PossibilitiesGrid = new HashSet<int>[PuzzleRows.Length][];
			for (int i = 0; i < PuzzleRows.Length; i++)
			{
				PossibilitiesGrid[i] = new HashSet<int>[PuzzleRows.Length];
			}

			for (int x = 0; x < PuzzleRows.Length; x++)
			{
				for (int y = 0; y < PuzzleRows.Length; y++)
				{
					PossibilitiesGrid[x][y] = DeterminePossibilities(x, y);
				}
			}
		}

		private HashSet<int> DeterminePossibilities(int x, int y)
		{
			if (PuzzleRows[x][y] != 0)
			{
				return new HashSet<int>();
			}

			HashSet<int> possibilities = new HashSet<int>(Enumerable.Range(1, 9).ToList());
			
			// check row
			int[] row = PuzzleRows[x];
			foreach (int num in row)
			{
				if (num > 0)
				{
					possibilities.Remove(num);
				}
			}

			// check column
			for (int i = 0; i < PuzzleRows.Length; i++)
			{
				if (PuzzleRows[i][y] > 0)
				{
					possibilities.Remove(PuzzleRows[i][y]);
				}
			}

			// check square
			int xLow = (3 * (x / 3));
			int xHi = xLow + 3;
			int yLow = (3 * (y / 3));
			int yHi = yLow + 3;
			for (int i = xLow; i < xHi; i++)
			{
				for (int j = yLow; j < yHi; j++)
				{
					if (PuzzleRows[i][j] > 0)
					{
						possibilities.Remove(PuzzleRows[i][j]);
					}
				}
			}

			return possibilities;
		}

		private void GuessAndCheck()
		{
			// create list of unsolved locations
			Dictionary<Point, List<int>> unsolvedPossibilities = new Dictionary<Point, List<int>>();
			for (int x = 0; x < PuzzleRows.Length; x++)
			{
				for (int y = 0; y < PuzzleRows.Length; y++)
				{
					if (PuzzleRows[x][y] == 0)
					{
						unsolvedPossibilities.Add(new Point(x, y), PossibilitiesGrid[x][y].ToList());
					}
				}
			}

			Point startPoint = GetMinPossPoint(unsolvedPossibilities);
			SearchHelper(startPoint, unsolvedPossibilities);
		}

		private bool SearchHelper(Point thisPoint, Dictionary<Point, List<int>> uP)
		{
			Dictionary<Point, List<int>> unsolvedPossibilities;
			int curPossIdx = -1;
			do
			{
				unsolvedPossibilities = new Dictionary<Point, List<int>>(uP);
				bool foundCandidate = false;
				do
				{
					curPossIdx++;
					if (curPossIdx == unsolvedPossibilities[thisPoint].Count)
					{
						PuzzleRows[thisPoint.X][thisPoint.Y] = 0;
						return false;
					}
					int proposedSoln = unsolvedPossibilities[thisPoint][curPossIdx];
					if (NumOkInRow(proposedSoln, thisPoint.X) && NumOkInCol(proposedSoln, thisPoint.Y) && NumOkInSqr(proposedSoln, thisPoint.X, thisPoint.Y))
					{
						foundCandidate = true;
						PuzzleRows[thisPoint.X][thisPoint.Y] = proposedSoln;
					}
				} while (!foundCandidate);

				unsolvedPossibilities.Remove(thisPoint);
				if (unsolvedPossibilities.Count == 0)
				{
					return true;
				}
			} while (!SearchHelper(GetMinPossPoint(unsolvedPossibilities), unsolvedPossibilities));

			return true;
		}

		private Point GetMinPossPoint(Dictionary<Point, List<int>> uP)
		{
			int min = uP.Values.Min(x => x.Count);
			return uP.First(kvp => kvp.Value.Count == min).Key;
		}

		private bool NumOkInRow(int num, int row)
		{
			return !PuzzleRows[row].Contains(num);
		}

		private bool NumOkInCol(int num, int col)
		{
			for (int i = 0; i < PuzzleRows.Length; i++)
			{
				if (PuzzleRows[i][col] == num)
				{
					return false;
				}
			}
			return true;
		}

		private bool NumOkInSqr(int num, int x, int y)
		{
			int xLow = (3 * (x / 3));
			int xHi = xLow + 3;
			int yLow = (3 * (y / 3));
			int yHi = yLow + 3;
			for (int i = xLow; i < xHi; i++)
			{
				for (int j = yLow; j < yHi; j++)
				{
					if (PuzzleRows[i][j] == num)
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool IsUnsolved()
		{
			foreach (int[] row in PuzzleRows)
			{
				if (row.Contains(0))
				{
					return true;
				}
			}
			return false;
		}

		public int AnswerInt 
		{
			get
			{
				return PuzzleRows[0][0] * 100 + PuzzleRows[0][1] * 10 + PuzzleRows[0][2];
			}
		}

		public string GeneratePrintableSudoku()
		{
			string print = "";
			for (int x = 0; x < PuzzleRows.Length; x++)
			{
				//if (x == 0 || (x + 1) % 3 == 0)
				if (x % 3 == 0)
				{
					if (x == 0)
					{
						print += "-------------------------\n";
					}
					else
					{
						print += "|-------+-------+-------|\n";
					}
				}
				
				for (int y = 0; y < PuzzleRows.Length; y++)
				{
					//if (y == 0 || (y + 1) % 3 == 0)
					if (y % 3 == 0)
					{
						print += "| ";
					}

					print += PuzzleRows[x][y] + " ";
				}
				print += "|\n";
			}
			print += "-------------------------\n";
			return print;
		}
	}
}
