using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.Monopoly;

namespace ProjectEuler.Problems
{
    public static class Problem84
    {
        public static string Solve()
        {
            Dictionary<int, int> squareFrequencyCounts = new Dictionary<int, int>();

            for (int i = 0; i < 1000; i++) // play one thousand games consisting of ten thousand moves
            {
                //MonopolyBoard gameBoard = new MonopolyBoard(6, 6);
                MonopolyBoard gameBoard = new MonopolyBoard(4, 4);
                for (int j = 0; j < 10000; j++)
                {
                    gameBoard.PlayTurn();
                    if (!squareFrequencyCounts.ContainsKey(gameBoard.CurrentSquareId))
                    {
                        squareFrequencyCounts.Add(gameBoard.CurrentSquareId, 0);
                    }
                    squareFrequencyCounts[gameBoard.CurrentSquareId] += 1;
                }
            }

            int totalTurns = squareFrequencyCounts.Sum(kvp => kvp.Value);
            var topSquares = squareFrequencyCounts.OrderByDescending(kvp => kvp.Value);
            var topSquaresAsEnums = topSquares.ToDictionary(kvp => MonopolyBoard.SquareLookupDict[kvp.Key], kvp => (((double)kvp.Value) / totalTurns) * 100);
            List<int> top3Squares = topSquares.Select(kvp => kvp.Key).Take(3).ToList();
            string modalString = String.Join("", top3Squares.Select(id => id.ToString()));
            return modalString;
        }
    }
}
