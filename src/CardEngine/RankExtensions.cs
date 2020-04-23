// <copyright file="RankExtensions.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

using System;
using CardEngine;

/// <summary>
/// Extension methods for the Rank enum.
/// </summary>
/// <see cref="Rank"/>
public static class RankExtensions
{
    /// <summary>
    /// Converts the Rank to its equivalent shortened string representation.
    /// </summary>
    /// <param name="rank">The Rank.</param>
    /// <returns>The shortened string representation.</returns>
    public static string ToShortString(this Rank rank)
    {
        return rank switch
        {
            Rank.Ace => "A",
            Rank.King => "K",
            Rank.Queen => "Q",
            Rank.Jack => "J",
            Rank.Ten => "10",
            Rank.Nine => "9",
            Rank.Eight => "8",
            Rank.Seven => "7",
            Rank.Six => "6",
            Rank.Five => "5",
            Rank.Four => "4",
            Rank.Three => "3",
            Rank.Two => "2",
            _ => throw new InvalidOperationException("Invalid rank.")
        };
    }
}
