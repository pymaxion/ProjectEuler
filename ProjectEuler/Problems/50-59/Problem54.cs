using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using ProjectEuler.Utils.Cards;

namespace ProjectEuler.Problems
{
	public static class Problem54
	{
		public static readonly string pokerFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p054_poker.txt";
		
		public static string Solve()
		{
			int player1WinTally = 0;
			List<string> pokerHands = FileUtils.ReadFileIntoList(pokerFilepath, 1000);

			foreach (string hand in pokerHands)
			{
				string[] player1Cards = new string[5];
				string[] player2Cards = new string[5];
				string[] allCards = hand.Split(' ');
				
				Array.Copy(allCards, 0, player1Cards, 0, 5);
				Array.Copy(allCards, 5, player2Cards, 0, 5);

				PokerHand player1Hand = new PokerHand(player1Cards);
				PokerHand player2Hand = new PokerHand(player2Cards);

				if (player1Hand.Beats(player2Hand))
				{
					player1WinTally++;
				}
			}

			return player1WinTally.ToString();
		}
	}
}
