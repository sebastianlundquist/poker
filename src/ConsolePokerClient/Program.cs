// <copyright file="Program.cs" company="Sebastian Lundquist">
// Copyright (c) Sebastian Lundquist. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardEngine;
using static System.Console;

namespace ConsolePokerClient
{
    /// <summary>
    /// Entry point for the console poker client.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            DrawNewHand();
        }

        private static void DrawNewHand()
        {
            Clear();
            var deck = new Deck().Shuffle<Deck, Card>();
            var communityCards = deck.Draw(5);
            var yourCards = deck.Draw(2);
            var hand = new PokerHand(new Stack<Card>(communityCards.Concat(yourCards)));
            WriteLine();
            WriteLine(" Community cards:");
            communityCards.Print();
            WriteLine();
            WriteLine(" Your cards:");
            yourCards.Print();
            var ranking = hand.Evaluate();
            WriteLine();
            WriteLine($" You have {ranking.ToFriendlyString()}.");
            ReadKey();

            DrawNewHand();
        }
    }
}
