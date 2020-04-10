using CardEngine;
using System;
using System.Text;

namespace ConsolePokerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var deck = new Deck();
            var cards = deck.Draw(5);
            cards.Print();

            Console.ReadKey();
        }
    }
}
