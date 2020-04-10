using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEngine
{
    /// <summary>
    /// Represents a poker hand.
    /// </summary>
    public class PokerHand : Stack<Card>
    {
        /// <summary>
        /// Inserts a Card at the top of the PokerHand.
        /// </summary>
        /// <param name="card">The Card to insert at the top of the PokerHand.</param>
        public new void Push(Card card)
        {
            if (Count == 7)
                throw new InvalidOperationException("Cannot have more than 7 cards in a hand.");
            base.Push(card);
        }

        /// <summary>
        /// Calls Push to insert a Card at the top of the PokerHand to enable simplified collection initialization.
        /// </summary>
        /// <param name="card">The Card to insert at the top of the PokerHand.</param>
        /// <see cref="Push(Card)"/>
        public void Add(Card card)
        {
            Push(card);
        }
    }

    /// <summary>
    /// Extension methods for the PokerHand class.
    /// </summary>
    /// <see cref="PokerHand"/>
    public static class PokerHandExtensions
    {
        /// <summary>
        /// Determines whether the PokerHand contains its maximum number of 7 cards.
        /// </summary>
        /// <param name="hand">The PokerHand to evaluate.</param>
        /// <returns>True if the PokerHand is full. False if the PokerHand is not full.</returns>
        public static bool IsFull(this PokerHand hand)
        {
            return hand.Count == 7;
        }

        /// <summary>
        /// Evaluates the PokerHandRanking of the given PokerHand.
        /// </summary>
        /// <param name="hand">The PokerHand to evaluate.</param>
        /// <returns>The PokerHandRanking of the PokerHand.</returns>
        /// <see cref="PokerHandRanking"/>
        public static PokerHandRanking Evaluate(this PokerHand hand)
        {
            if (hand.IsStraightFlush())
                return PokerHandRanking.StraightFlush;

            if (hand.IsFourOfAKind())
                return PokerHandRanking.FourOfAKind;

            if (hand.IsFullHouse())
                return PokerHandRanking.FullHouse;

            if (hand.IsFlush())
                return PokerHandRanking.Flush;

            if (hand.IsStraight())
                return PokerHandRanking.Straight;

            if (hand.IsThreeOfAKind())
                return PokerHandRanking.ThreeOfAKind;

            if (hand.IsTwoPair())
                return PokerHandRanking.TwoPairs;

            if (hand.IsPair())
                return PokerHandRanking.Pair;

            return PokerHandRanking.HighCard;
        }

        private static Card HighestValueCard(this PokerHand cards)
        {
            return cards.OrderByDescending(c => c.Rank).ThenByDescending(c => c.Suit).ToList().First();
        }

        private static List<List<Card>> Group(this PokerHand cards)
        {
            var groups = new List<List<Card>>();
            var query = cards.OrderByDescending(c => c.Rank).ThenByDescending(c => c.Suit).GroupBy(c => c.Rank).OrderByDescending(d => d.Count());
            foreach (var group in query)
                if (group.Count() >= 2)
                    groups.Add(group.ToList());
            return groups;
        }

        private static bool IsFourOfAKind(this PokerHand cards)
        {
            var groups = cards.Group();
            return groups.Count > 0 && groups.First().Count >= 4;
        }

        private static bool IsThreeOfAKind(this PokerHand cards)
        {
            var groups = cards.Group();
            return groups.Count > 0 && groups.First().Count >= 3;
        }

        private static bool IsPair(this PokerHand cards)
        {
            return cards.Group().Count >= 1;
        }

        private static bool IsTwoPair(this PokerHand cards)
        {
            return cards.Group().Count >= 2;
        }

        private static bool IsFullHouse(this PokerHand cards)
        {
            var groups = cards.Group();
            return groups.Count >= 2 && groups[0].Count >= 3;
        }

        private static bool IsFlush(this PokerHand cards)
        {
            var query = cards.GroupBy(c => c.Suit);
            foreach (var group in query)
                if (group.Count() >= 5)
                    return true;
            return false;
        }

        private static bool IsStraight(this PokerHand cards)
        {
            var sortedCards = cards.OrderByDescending(o => o.Rank).ToList();
            Rank currentRank = sortedCards[0].Rank;
            int count = 1;
            for (int i = 1; i < sortedCards.Count; i++)
            {
                if (sortedCards[i].Rank == currentRank - 1)
                    count++;
                else if (sortedCards[i].Rank != currentRank)
                    count = 1;

                currentRank = sortedCards[i].Rank;

                if (count == 5)
                    return true;
            }

            return false;
        }

        private static bool IsStraightFlush(this PokerHand cards)
        {
            return cards.IsStraight() && cards.IsFlush();
        }

        private static Rank NumberOfAKindRank(this PokerHand cards)
        {
            return cards.Group().First().First().Rank;
        }

        private static (Rank FirstRank, Rank SecondRank) TwoPairOrFullHouseRanks(this PokerHand cards)
        {
            var groups = cards.Group();
            return (groups[0].First().Rank, groups[1].First().Rank);
        }
    }
}
