using CardEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardEngineTests
{
    [TestClass]
    public class SuitExtensionsTests
    {
        [TestMethod()]
        [DataRow(Suit.Hearts, '♥')]
        [DataRow(Suit.Spades, '♠')]
        [DataRow(Suit.Diamonds, '♦')]
        [DataRow(Suit.Clubs, '♣')]
        public void ToShortString_ValidSuit_ReturnsCorrectString(Suit input, char output)
        {
            // Assert
            Assert.AreEqual(output, input.ToShortString());
        }

        [TestMethod()]
        [DataRow(Suit.Hearts, ConsoleColor.Red)]
        [DataRow(Suit.Spades, ConsoleColor.Black)]
        [DataRow(Suit.Diamonds, ConsoleColor.Red)]
        [DataRow(Suit.Clubs, ConsoleColor.Black)]
        public void Color_ValidSuit_ReturnsCorrectColor(Suit input, ConsoleColor output)
        {
            // Assert
            Assert.AreEqual(output, input.Color());
        }
    }
}
