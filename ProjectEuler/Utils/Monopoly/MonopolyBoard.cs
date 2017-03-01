using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils.Monopoly
{
	public class MonopolyBoard
	{
        #region static stuff
        public enum Square
        {
            GO, A1, CC1, A2, T1, R1, B1, CH1, B2, B3, JAIL, C1, U1, C2, C3, R2, D1, CC2, D2, D3, FP, E1, CH2, E2, E3, R3, F1, F2, U2, F3, G2J, G1, G2, CC3, G3, R4, CH3, H1, T2, H2
        }

        private static Dictionary<int, Square> MakeSquareLookupDictionary()
        {
            Dictionary<int, Square> squareLookupDict = new Dictionary<int, Square>();
            Square[] squares = Enum.GetValues(typeof(Square)).Cast<Square>().ToArray();
            for (int i = 0; i < squares.Length; i++)
            {
                squareLookupDict.Add(i, squares[i]);
            }
            return squareLookupDict;
        }

        private static Dictionary<Square, int> MakeIdLookupDictionary()
        {
            Dictionary<Square, int> idLookupDict = new Dictionary<Square, int>();
            Square[] squares = Enum.GetValues(typeof(Square)).Cast<Square>().ToArray();
            for (int i = 0; i < squares.Length; i++)
            {
                idLookupDict.Add(squares[i], i);
            }
            return idLookupDict;
        }

        public static readonly Dictionary<int, Square> SquareLookupDict = MakeSquareLookupDictionary();
        public static readonly Dictionary<Square, int> IdLookupDict = MakeIdLookupDictionary();
        private static readonly int NumberOfSquares = SquareLookupDict.Keys.Count;
        private static readonly HashSet<int> RailroadIds = new HashSet<int>(new List<int>() { IdLookupDict[Square.R1], IdLookupDict[Square.R2], IdLookupDict[Square.R3], IdLookupDict[Square.R4] });
        private static readonly HashSet<int> UtilityIds = new HashSet<int>(new List<int>() { IdLookupDict[Square.U1], IdLookupDict[Square.U2] });
        #endregion

        public int CurrentSquareId { get; set; }
        public Square CurrentSquare { get { return SquareLookupDict[CurrentSquareId]; } }
        public Random Dice { get; set; }
        public int Die1Sides { get; set; }
        public int Die2Sides { get; set; }
        public List<int> CommunityChestCards { get; set; }
        public List<int> ChanceCards { get; set; }
        public int CommunityChestIdx { get; set; }
        public int ChanceIdx { get; set; }
        public int DoublesCount { get; set; }

        public MonopolyBoard(int die1Sides, int die2Sides)
        {
            CurrentSquareId = 0; // Start at GO
            Dice = new Random();
            Die1Sides = die1Sides;
            Die2Sides = die2Sides;
            CommunityChestCards = Enumerable.Range(1, 16).ToList();
            ChanceCards = Enumerable.Range(1, 16).ToList();
            CommunityChestCards.Shuffle();
            ChanceCards.Shuffle();
            CommunityChestIdx = 0;
            ChanceIdx = 0;
            DoublesCount = 0;
        }

        public void PlayTurn()
        {
            // roll dice
            int die1Result = Dice.Next(1, Die1Sides + 1);
            int die2Result = Dice.Next(1, Die2Sides + 1);
            DoublesCount = (die1Result == die2Result) ? DoublesCount + 1 : 0;

            if (DoublesCount == 3)
            {
                // Go to JAIL!
                CurrentSquareId = IdLookupDict[Square.JAIL];
                DoublesCount = 0;
            }
            else
            {
                int diceTotal = die1Result + die2Result;

                // update current square
                CurrentSquareId = (CurrentSquareId + diceTotal) % NumberOfSquares;

                // check game logic for jumps and stuff 
                ExecuteGameLogic();
            }    
        }

        private void ExecuteGameLogic()
        {
            switch (CurrentSquare)
            {
                case Square.G2J: // go to jail
                    CurrentSquareId = IdLookupDict[Square.JAIL];
                    break;

                case Square.CC1:
                case Square.CC2:
                case Square.CC3:
                    PlayCommunityChest();
                    break;

                case Square.CH1:
                case Square.CH2:
                case Square.CH3:
                    PlayChance();
                    break;

                default:
                    break;
            }
        }

        private void PlayCommunityChest()
        {
            bool changedSquare = true;

            // draw next card
            int communityChest = CommunityChestCards[CommunityChestIdx];
            switch (communityChest)
            {
                case 1: // advance to GO
                    CurrentSquareId = IdLookupDict[Square.GO];
                    break;

                case 2: // go to jail
                    CurrentSquareId = IdLookupDict[Square.JAIL];
                    break;

                default:
                    changedSquare = false;
                    break;
            }

            // update
            CommunityChestIdx = (CommunityChestIdx + 1) % CommunityChestCards.Count;
            if (changedSquare)
            {
                ExecuteGameLogic();
            }
        }

        private void PlayChance()
        {
            bool changedSquare = true;

            // draw next card
            int chance = ChanceCards[ChanceIdx];
            switch (chance)
            {
                case 1: // advance to GO
                    CurrentSquareId = IdLookupDict[Square.GO];
                    break;

                case 2: // go to jail
                    CurrentSquareId = IdLookupDict[Square.JAIL];
                    break;

                case 3: // go to C1
                    CurrentSquareId = IdLookupDict[Square.C1];
                    break;

                case 4: // go to E3
                    CurrentSquareId = IdLookupDict[Square.E3];
                    break;

                case 5: // go to H2
                    CurrentSquareId = IdLookupDict[Square.H2];
                    break;

                case 6: // go to R1
                    CurrentSquareId = IdLookupDict[Square.R1];
                    break;

                case 7: // go to next R
                case 8: // go to next R
                    CurrentSquareId = GetClosestRailroad(CurrentSquareId);
                    break;

                case 9: // go to next U
                    CurrentSquareId = GetClosestUtility(CurrentSquareId);
                    break;

                case 10: // go back 3 squares
                    CurrentSquareId -= 3;
                    break;

                default:
                    changedSquare = false;
                    break;
            }

            // update
            ChanceIdx = (ChanceIdx + 1) % ChanceCards.Count;
            if (changedSquare)
            {
                ExecuteGameLogic();
            }
        }

        private static int GetClosestRailroad(int currSquare)
        {
            while (true)
            {
                currSquare = (currSquare + 1) % NumberOfSquares;
                if (RailroadIds.Contains(currSquare))
                {
                    return currSquare;
                }
            }
        }

        private static int GetClosestUtility(int currSquare)
        {
            while (true)
            {
                currSquare = (currSquare + 1) % NumberOfSquares;
                if (UtilityIds.Contains(currSquare))
                {
                    return currSquare;
                }
            }
        }
    }

    public static class MonopolyExtensions
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
