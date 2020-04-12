// <copyright file="Deck.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

using System;
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
        /// Initializes a new instance of the <see cref="Deck"/> class.
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
}
