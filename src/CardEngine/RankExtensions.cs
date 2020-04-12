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
        switch (rank)
        {
            case Rank.Ace:
                return "A";
            case Rank.King:
                return "K";
            case Rank.Queen:
                return "Q";
            case Rank.Jack:
                return "J";
            case Rank.Ten:
                return "10";
            case Rank.Nine:
                return "9";
            case Rank.Eight:
                return "8";
            case Rank.Seven:
                return "7";
            case Rank.Six:
                return "6";
            case Rank.Five:
                return "5";
            case Rank.Four:
                return "4";
            case Rank.Three:
                return "3";
            case Rank.Two:
                return "2";
            default:
                throw new InvalidOperationException("Invalid rank.");
        }
    }
}
