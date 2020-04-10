﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEngine
{
    /// <summary>
    /// Represents a standard 52-card deck.
    /// </summary>
    public class Deck : Stack<Card>
    {
        /// <summary>
        /// Constructs a Deck.
        /// </summary>
        public Deck()
        {
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>().ToList();
            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList();
            for (int i = 0; i < ranks.Count; i++)
                for (int j = 0; j < suits.Count; j++)
                    Push(new Card(ranks[i], suits[j]));
        }
    }

    /// <summary>
    /// Extension methods for the Deck class.
    /// </summary>
    /// <see cref="Deck"/>
    public static class DeckExtensions
    {
        /// <summary>
        /// Draws a Card from the top of the Deck.
        /// </summary>
        /// <param name="deck">The Deck.</param>
        /// <returns>The Card.</returns>
        public static Card Draw(this Deck deck)
        {
            if (deck.Count > 0)
                return deck.Pop();

            throw new InvalidOperationException("Cannot draw a card from an empty deck.");
        }

        /// <summary>
        /// Draws a given number of Cards from the top of the Deck.
        /// </summary>
        /// <param name="deck">The Deck.</param>
        /// <param name="count">The number of Cards to draw.</param>
        /// <returns>A List of the drawn Cards.</returns>
        public static List<Card> Draw(this Deck deck, int count)
        {
            if (deck.Count >= count)
            {
                var cards = new List<Card>();
                for (int i = 0; i < count; i++)
                    cards.Add(deck.Pop());

                return cards;
            }

            throw new InvalidOperationException($"Cannot draw {count} cards from a deck containing {deck.Count} cards.");
        }
    }
}
