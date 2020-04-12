// <copyright file="PokerHandRanking.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

namespace CardEngine
{
    /// <summary>
    /// Represents the ranking of a PokerHand.
    /// </summary>
    /// <see cref="PokerHand"/>
    public enum PokerHandRanking
    {
        /// <summary>
        /// High Card
        /// </summary>
        HighCard,

        /// <summary>
        /// Pair
        /// </summary>
        Pair,

        /// <summary>
        /// Two Pairs
        /// </summary>
        TwoPairs,

        /// <summary>
        /// Three of a Kind
        /// </summary>
        ThreeOfAKind,

        /// <summary>
        /// Straight
        /// </summary>
        Straight,

        /// <summary>
        /// Flush
        /// </summary>
        Flush,

        /// <summary>
        /// Full House
        /// </summary>
        FullHouse,

        /// <summary>
        /// Four of a Kind
        /// </summary>
        FourOfAKind,

        /// <summary>
        /// Straight Flush
        /// </summary>
        StraightFlush,
    }
}
