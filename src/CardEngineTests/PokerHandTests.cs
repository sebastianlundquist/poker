using CardEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardEngineTests
{
    [TestClass]
    public class PokerHandTests
    {
        [TestMethod()]
        public void Push_CardToEmptyPokerHand_AddsCardToHand()
        {
            // Arrange
            var hand = new PokerHand();
            var card = new Card(Rank.Ace, Suit.Spades);

            // Act
            hand.Push(card);

            // Assert
            Assert.IsTrue(hand.Contains(card));
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_CardToFullPokerHand_ThrowsInvalidOperationException()
        {
            // Arrange
            var hand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
                new Card(Rank.Eight, Suit.Hearts),
            };
            var card = new Card(Rank.Ace, Suit.Spades);

            // Act
            hand.Push(card);
        }
    }
}
