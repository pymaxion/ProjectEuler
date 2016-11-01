using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils.Cards
{
	public class Card
	{
		public Rank Rank;
		public Suit Suit;		

		public Card(string cardAbbrev)
		{
			Rank = ParseRank(cardAbbrev.Substring(0, 1));
			Suit = ParseSuit(cardAbbrev.Substring(1, 1));
		}
		
		private static Rank ParseRank(string rankAbbrev)
		{
			switch (rankAbbrev.ToUpper())
			{
				case "X":
					return Rank.Joker;
				case "2":
					return Rank.Two;
				case "3":
					return Rank.Three;
				case "4":
					return Rank.Four;
				case "5":
					return Rank.Five;
				case "6":
					return Rank.Six;
				case "7":
					return Rank.Seven;
				case "8":
					return Rank.Eight;
				case "9":
					return Rank.Nine;
				case "T":
					return Rank.Ten;
				case "J":
					return Rank.Jack;
				case "Q":
					return Rank.Queen;
				case "K":
					return Rank.King;
				case "A":
					return Rank.Ace;
				default:
					throw new Exception("Could not parse rank");
			}
		}

		private static Suit ParseSuit(string suitAbbrev)
		{
			switch (suitAbbrev.ToUpper())
			{
				case "H":
					return Suit.Hearts;
				case "D":
					return Suit.Diamonds;
				case "C":
					return Suit.Clubs;
				case "S":
					return Suit.Spades;
				case "J":
					return Suit.Joker;
				default:
					throw new Exception("Could not parse suit");
			}
		}
	}

	public enum Suit 
	{
		Hearts = 0,
		Diamonds = 1,
		Clubs = 2,
		Spades = 3,
		Joker = 4
	}

	public enum Rank
	{
		Joker = 0,
		Two = 2,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King,
		Ace
	}
}
