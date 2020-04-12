// <copyright file="PokerHand.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

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
        /// Initializes a new instance of the <see cref="PokerHand"/> class.
        /// </summary>
        public PokerHand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PokerHand"/> class.
        /// </summary>
        /// <param name="cards">Stack of Cards to initialize the PokerHand with.</param>
        public PokerHand(Stack<Card> cards)
        {
            var hand = new Stack<Card>(cards);
            foreach (var card in hand)
                Push(card);
        }

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
}
