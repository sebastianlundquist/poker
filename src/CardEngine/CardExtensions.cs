// <copyright file="CardExtensions.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

namespace CardEngine
{
    /// <summary>
    /// Extension methods for the Card class.
    /// </summary>
    /// <see cref="Card"/>
    public static class CardExtensions
    {
        /// <summary>
        /// Converts the Card to its equivalent shortened string representation.
        /// </summary>
        /// <param name="card">The Card.</param>
        /// <returns>The shortened string representation.</returns>
        public static string ToShortString(this Card card)
        {
            return card.Rank.ToShortString() + card.Suit.ToShortString();
        }
    }
}
