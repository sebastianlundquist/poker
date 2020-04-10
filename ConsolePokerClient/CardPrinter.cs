using System;
using System.Collections.Generic;
using static System.Console;

namespace CardEngine
{
    public static class CardPrinter
    {
        public static void Print(this Card card)
        {
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = card.Suit.Color();
            WriteLine(card.Rank.ToShortString() + GetSpaces(card.Rank));
            WriteLine($"  {card.Suit.ToShortString()}  ");
            WriteLine(GetSpaces(card.Rank) + card.Rank.ToShortString());
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;

            static string GetSpaces(Rank rank)
            {
                string spaces = "     ";
                return spaces.Remove(spaces.Length - rank.ToShortString().Length);
            }
        }

        public static void Print(this List<Card> cards)
        {
            int numberOfCardsPerLine = WindowWidth / 6 - 1;

            WriteLine();
            Write(" ");
            foreach (var card in cards)
            {
                PrintLine(card, card.Rank.ToShortString() + GetSpaces(card.Rank));
            }
            WriteLine();
            Write(" ");
            foreach (var card in cards)
            {
                PrintLine(card, $"  {card.Suit.ToShortString()}  ");
            }
            WriteLine();
            Write(" ");
            foreach (var card in cards)
            {
                PrintLine(card, GetSpaces(card.Rank) + card.Rank.ToShortString());
            }
            WriteLine();

            static void PrintLine(Card card, string line)
            {
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = card.Suit.Color();
                Write(line);
                ResetColor();
                Write(" ");
            }

            static string GetSpaces(Rank rank)
            {
                string spaces = "     ";
                return spaces.Remove(spaces.Length - rank.ToShortString().Length);
            }
        }
    }
}
