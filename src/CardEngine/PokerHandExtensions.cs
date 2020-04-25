// <copyright file="PokerHandExtensions.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEngine
{
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
        /// Gets the five Cards in play and the hand's PokerHandRanking out of an IEnumerable of Cards.
        /// </summary>
        /// <param name="cards">The Cards to evaluate.</param>
        /// <returns>The Cards in play and the hand's PokerHandRanking.</returns>
        public static (IEnumerable<Card> Cards, PokerHandRanking Ranking) GetCurrentHand(this IEnumerable<Card> cards)
        {
            if (cards.Count() < 5)
                throw new InvalidOperationException("Cannot get a hand with fewer than 5 cards.");

            IEnumerable<Card> hand;

            hand = cards.StraightFlush();
            if (hand != null)
            {
                return (hand, PokerHandRanking.StraightFlush);
            }

            hand = cards.FourOfAKind();
            if (hand != null)
            {
                return (hand, PokerHandRanking.FourOfAKind);
            }

            hand = cards.FullHouse();
            if (hand != null)
            {
                return (hand, PokerHandRanking.FullHouse);
            }

            hand = cards.Flush();
            if (hand != null)
            {
                return (hand, PokerHandRanking.Flush);
            }

            hand = cards.Straight();
            if (hand != null)
            {
                return (hand, PokerHandRanking.Straight);
            }

            hand = cards.ThreeOfAKind();
            if (hand != null)
            {
                return (hand, PokerHandRanking.ThreeOfAKind);
            }

            hand = cards.TwoPair();
            if (hand != null)
            {
                return (hand, PokerHandRanking.TwoPairs);
            }

            hand = cards.Pair();
            if (hand != null)
            {
                return (hand, PokerHandRanking.Pair);
            }

            return (cards.HighCard(), PokerHandRanking.HighCard);
        }

        private static Card HighestValueCard(this IEnumerable<Card> cards)
        {
            return cards.OrderByDescending(c => c.Rank).ThenByDescending(c => c.Suit).ToList().First();
        }

        private static IOrderedEnumerable<Card> HighCard(this IEnumerable<Card> cards)
        {
            return cards.OrderByDescending(c => c.Rank).Take(5).OrderByDescending(c => c.Rank);
        }

        private static List<List<Card>> Group(this IEnumerable<Card> cards)
        {
            var groups = new List<List<Card>>();
            var query = cards.OrderByDescending(c => c.Rank).ThenByDescending(c => c.Suit).GroupBy(c => c.Rank).OrderByDescending(d => d.Count());
            foreach (var group in query)
                if (group.Count() >= 2)
                    groups.Add(group.ToList());
            return groups;
        }

        private static IEnumerable<Card> FourOfAKind(this IEnumerable<Card> cards)
        {
            var groups = cards.Group();
            if (groups.Count > 0 && groups.First().Count >= 4)
            {
                var fourOfAKindList = cards.Group().First();
                var kicker = cards.Except(fourOfAKindList).HighestValueCard();
                fourOfAKindList.Add(kicker);
                return fourOfAKindList;
            }

            return null;
        }

        private static IEnumerable<Card> ThreeOfAKind(this IEnumerable<Card> cards)
        {
            var groups = cards.Group();
            if (groups.Count > 0 && groups.First().Count >= 3)
            {
                var cardList = cards.ToList();
                var threeOfAKindList = cardList.Group().First();
                cardList.RemoveAll(c => threeOfAKindList.Contains(c));
                var extraCards = cardList.OrderByDescending(c => c.Rank).ThenByDescending(c => c.Suit).ToList();
                while (threeOfAKindList.Count < 5)
                {
                    threeOfAKindList.Add(extraCards[0]);
                    extraCards.RemoveAt(0);
                }

                return threeOfAKindList;
            }

            return null;
        }

        private static IEnumerable<Card> Pair(this IEnumerable<Card> cards)
        {
            if (cards.Group().Count >= 1)
            {
                var cardList = cards.ToList();
                var pairList = cardList.Group().First();
                cardList.RemoveAll(c => pairList.Contains(c));
                var extraCards = cardList.OrderByDescending(c => c.Rank).ThenByDescending(c => c.Suit).ToList();
                while (pairList.Count < 5)
                {
                    pairList.Add(extraCards[0]);
                    extraCards.RemoveAt(0);
                }

                return pairList;
            }

            return null;
        }

        private static IEnumerable<Card> TwoPair(this IEnumerable<Card> cards)
        {
            if (cards.Group().Count >= 2)
            {
                var cardList = cards.ToList();
                var twoPairList = cardList.Group()[0].Concat(cardList.Group()[1]).ToList();
                var kicker = cards.Except(twoPairList).HighestValueCard();
                twoPairList.Add(kicker);
                return twoPairList;
            }

            return null;
        }

        private static IEnumerable<Card> FullHouse(this IEnumerable<Card> cards)
        {
            var groups = cards.Group();
            if (groups.Count >= 2 && groups[0].Count >= 3)
                return groups[0].Concat(groups[1]);

            return null;
        }

        private static IEnumerable<Card> FlushCards(this IEnumerable<Card> cards)
        {
            return cards.GroupBy(c => c.Suit).First();
        }

        private static IOrderedEnumerable<Card> Flush(this IEnumerable<Card> cards)
        {
            if (cards.FlushCards().Count() >= 5)
                return cards.FlushCards().Take(5).OrderByDescending(c => c.Rank);

            return null;
        }

        private static IOrderedEnumerable<Card> StraightCards(this IEnumerable<Card> cards)
        {
            var sortedCards = cards.OrderByDescending(o => o.Rank).ToList();
            var straightCards = new List<Card> { sortedCards.First() };
            Rank currentRank = sortedCards[0].Rank;
            int count = 1;
            for (int i = 1; i < sortedCards.Count; i++)
            {
                if (sortedCards[i].Rank == currentRank - 1)
                {
                    straightCards.Add(sortedCards[i]);
                    count++;
                }
                else if (sortedCards[i].Rank != currentRank)
                {
                    if (straightCards.Count >= 5)
                    {
                        return straightCards.OrderByDescending(o => o.Rank);
                    }
                    else
                    {
                        straightCards = new List<Card> { sortedCards[i] };
                        count = 1;
                    }
                }

                currentRank = sortedCards[i].Rank;

                if (count >= 5)
                    return straightCards.OrderByDescending(o => o.Rank);
            }

            return null;
        }

        private static IOrderedEnumerable<Card> Straight(this IEnumerable<Card> cards)
        {
            if (cards.StraightCards() != null)
                return cards.StraightCards().Take(5).OrderBy(c => c.Rank);

            return null;
        }

        private static IEnumerable<Card> StraightFlush(this IEnumerable<Card> cards)
        {
            var straightCards = cards.StraightCards();
            var flushCards = cards.FlushCards();
            if (straightCards != null && flushCards != null)
            {
                var straightFlushCards = cards.StraightCards().Intersect(cards.FlushCards());
                if (straightFlushCards.Count() >= 5)
                    return straightFlushCards.Take(5);
            }

            return null;
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
