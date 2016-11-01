using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils.Cards
{
	public class PokerHand
	{
		public List<Card> Cards { get; set; }
		public HandRank Ranking { get; set; }

		public PokerHand(string[] cardAbbrevs)
		{
			Cards = new List<Card>();
			foreach (string cardAbbrev in cardAbbrevs)
			{
				Cards.Add(new Card(cardAbbrev));
			}

			Ranking = DetermineRankingAndSort();
		}

		public bool Beats(PokerHand otherHand)
		{
			if (Ranking == otherHand.Ranking)
			{
				for (int i = 0; i < Cards.Count; i++)
				{
					if (Cards[i].Rank == otherHand.Cards[i].Rank)
					{
						continue;
					}
					else
					{
						return Cards[i].Rank > otherHand.Cards[i].Rank;
					}
				}
				throw new Exception("There's been a tie");
			}
			else
			{
				return Ranking > otherHand.Ranking;
			}
		}

		public HandRank DetermineRankingAndSort()
		{
			HandRank ranking;
			
			// straight flush, straight, flush
			bool hasStraight = HandHelper.HasStraight(Cards);
			bool hasFlush = HandHelper.HasFlush(Cards);
			if (hasStraight || hasFlush)
			{
				if (hasStraight && hasFlush)
				{
					ranking = HandRank.StraightFlush;
				}
				else if (hasStraight)
				{
					ranking = HandRank.Straight;
				}
				else
				{
					ranking = HandRank.Flush;
				}
				Cards = (List<Card>)Cards.OrderByDescending(c => (int)c.Rank).ToList();
				return ranking;
			}

			// find pairings
			Dictionary<Rank, int> rankCountMap = new Dictionary<Rank, int>();
			foreach (Card card in Cards)
			{
				if (rankCountMap.ContainsKey(card.Rank))
				{
					rankCountMap[card.Rank] = rankCountMap[card.Rank] + 1;
				}
				else
				{
					rankCountMap.Add(card.Rank, 1);
				}
			}
			var rankCounts = rankCountMap.OrderByDescending(kvp => kvp.Value);

			// four of a kind
			if (rankCounts.First().Value == 4)
			{
				ranking = HandRank.FourOfAKind;
				Card oddOneOut = Cards.First(c => c.Rank != rankCounts.First().Key);
				Cards.Remove(oddOneOut);
				Cards.Add(oddOneOut);
				return ranking;
			}

			// anything containing three of a kind
			if (rankCounts.First().Value == 3)
			{
				if (rankCounts.Skip(1).First().Value == 2)
				{
					ranking = HandRank.FullHouse;
					
				}
				else
				{
					ranking = HandRank.ThreeOfAKind;
				}

				var remainingCards = Cards.FindAll(c => c.Rank != rankCounts.First().Key).OrderByDescending(c => (int)c.Rank);;
				foreach (var remainingCard in remainingCards)
				{
					Cards.Remove(remainingCard);
					Cards.Add(remainingCard);
				}
				return ranking;
			}

			// anything containing two of a kind
			if (rankCounts.First().Value == 2)
			{
				if (rankCounts.Skip(1).First().Value == 2)
				{
					ranking = HandRank.TwoPairs;

				}
				else
				{
					ranking = HandRank.OnePair;
				}

				var remainingCards = Cards.FindAll(c => c.Rank != rankCounts.First().Key).OrderByDescending(c => (int)c.Rank); ;
				foreach (var remainingCard in remainingCards)
				{
					Cards.Remove(remainingCard);
					Cards.Add(remainingCard);
				}
				return ranking;
			}

			// if we make it here, we only have a high card
			ranking = HandRank.HighCard;
			Cards = (List<Card>)Cards.OrderByDescending(c => (int)c.Rank).ToList();
			return ranking;
		}



		private static class HandHelper
		{
			public static Rank ParseIntToRank(int value)
			{
				return (Rank)Enum.Parse(typeof(Rank), value.ToString());
			}

			public static Card GetMaxCard(List<Card> cards)
			{
				Card maxCard = null;
				foreach (Card card in cards)
				{
					if (maxCard == null || card.Rank > maxCard.Rank)
					{
						maxCard = card;
					}
				}
				return maxCard;
			}

			public static bool HasFlush(List<Card> cards)
			{
				Suit firstCardSuit = cards.First().Suit;
				foreach (Card card in cards.Skip(1))
				{
					if (card.Suit != firstCardSuit)
					{
						return false;
					}
				}
				return true;
			}

			public static bool HasStraight(List<Card> cards)
			{
				Card maxCard = GetMaxCard(cards);
				for (int i = 1; i < 5; i++)
				{
					if (!cards.Any(c => c.Rank == ParseIntToRank((int)maxCard.Rank - i)))
					{
						return false;
					}
				}
				return true;
			}
		}
	}

	

	public enum HandRank
	{
		HighCard = 1,
		OnePair,
		TwoPairs,
		ThreeOfAKind,
		Straight,
		Flush,
		FullHouse,
		FourOfAKind,
		StraightFlush
	}
}
