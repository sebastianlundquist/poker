// <copyright file="PokerHandRankingExtensions.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

using System.Linq;
using CardEngine;

/// <summary>
/// Extension methods for the PokerHandRanking enum.
/// </summary>
/// <see cref="PokerHandRanking"/>
public static class PokerHandRankingExtensions
{
    /// <summary>
    /// Converts the PokerHandRanking to its equivalent friendly string representation.
    /// </summary>
    /// <param name="ranking">The PokerHandRanking.</param>
    /// <returns>The friendly string representation.</returns>
    public static string ToFriendlyString(this PokerHandRanking ranking)
    {
        return string.Concat(ranking.ToString().Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
    }
}