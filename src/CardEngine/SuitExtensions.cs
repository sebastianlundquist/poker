﻿// <copyright file="SuitExtensions.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

using System;
using CardEngine;

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
        return suit switch
        {
            Suit.Hearts => '♥',
            Suit.Spades => '♠',
            Suit.Diamonds => '♦',
            Suit.Clubs => '♣',
            _ => throw new InvalidOperationException("Invalid suit."),
        };
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
