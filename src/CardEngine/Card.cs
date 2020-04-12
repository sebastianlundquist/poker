// <copyright file="Card.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace CardEngine
{
    /// <summary>
    /// Represents a card in a standard 52-card Deck.
    /// </summary>
    /// <see cref="Deck"/>
    public class Card
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="rank">The given Rank.</param>
        /// <param name="suit">The given Suit.</param>
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        /// <summary>
        /// Gets or sets the Rank of the Card.
        /// </summary>
        /// <see cref="Rank"/>
        public Rank Rank { get; set; }

        /// <summary>
        /// Gets or sets the Suit of the Card.
        /// </summary>
        /// <see cref="Suit"/>
        public Suit Suit { get; set; }

        /// <summary>
        /// Override of operator==.
        /// </summary>
        /// <param name="left">Left Card.</param>
        /// <param name="right">Right Card.</param>
        /// <returns>True if left and right Cards are equal. False if left and right Cards are not equal.</returns>
        public static bool operator ==(Card left, Card right) => EqualityComparer<Card>.Default.Equals(left, right);

        /// <summary>
        /// Override of operator!=.
        /// </summary>
        /// <param name="left">Left Card.</param>
        /// <param name="right">Right Card.</param>
        /// <returns>True if left and right Cards are not equal. False if left and right Cards are equal.</returns>
        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts the Card to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return Rank.ToString() + " of " + Suit.ToString();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the actual object.
        /// </summary>
        /// <param name="obj">The specified object.</param>
        /// <returns>True if the objects are equal. False if the objects are not equal.</returns>
        public override bool Equals(object obj)
        {
            var card = (Card)obj;
            if (Rank == card.Rank && Suit == card.Suit)
                return true;

            return false;
        }

        /// <summary>
        /// Override of GetHashCode.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 483265535;
            hashCode = (hashCode * -1521134295) + Rank.GetHashCode();
            hashCode = (hashCode * -1521134295) + Suit.GetHashCode();
            return hashCode;
        }
    }
}
