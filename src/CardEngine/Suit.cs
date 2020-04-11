using System;

namespace CardEngine
{
    /// <summary>
    /// Represents the suit of a Card.
    /// </summary>
    /// <see cref="Card"/>
    public enum Suit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts,
    }

    /// <summary>
    /// Extension methods for the Suit enum.
    /// </summary>
    /// <see cref="Suit"/>
    public static class SuitExtensions
    {
        /// <summary>
        /// Converts the Suit to its equivalent shortened string representation.
        /// </summary>
        /// <param name="suit">The Suit.</param>
        /// <returns>The shortened string representation.</returns>
        public static char ToShortString(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts:
                    return '♥';
                case Suit.Spades:
                    return '♠';
                case Suit.Diamonds:
                    return '♦';
                case Suit.Clubs:
                    return '♣';
                default:
                    throw new InvalidOperationException("Invalid suit.");
            }
        }

        /// <summary>
        /// Gets the color of the Suit as a ConsoleColor.
        /// </summary>
        /// <param name="suit">The Suit.</param>
        /// <returns>The ConsoleColor.</returns>
        public static ConsoleColor Color(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts:
                case Suit.Diamonds:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Black;
            }
        }
    }
}
