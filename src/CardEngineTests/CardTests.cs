using CardEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardEngineTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod()]
        public void NewCard_GetsCorrectSuitAndRank()
        {
            // Arrange
            Rank rank = Rank.Ace;
            Suit suit = Suit.Hearts;

            // Act
            var card = new Card(rank, suit);

            // Assert
            Assert.AreEqual(card.Suit, suit);
            Assert.AreEqual(card.Rank, rank);
        }

        [TestMethod()]
        public void Equals_EqualRankAndSuit_ReturnsTrue()
        {
            // Arrange
            Rank rank = Rank.Ace;
            Suit suit = Suit.Hearts;
            var card1 = new Card(rank, suit);
            var card2 = new Card(rank, suit);

            // Assert
            Assert.IsTrue(card1.Equals(card2));
        }

        [TestMethod()]
        public void Equals_NonEqualRankOrSuit_ReturnsFalse()
        {
            // Arrange
            var card1 = new Card(Rank.Ace, Suit.Hearts);
            var card2 = new Card(Rank.Ace, Suit.Spades);

            // Assert
            Assert.IsFalse(card1.Equals(card2));
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void Equals_NonCard_ThrowsInvalidCastException()
        {
            // Arrange
            var card1 = new Card(Rank.Ace, Suit.Hearts);
            var notACard = new object();

            // Act
            card1.Equals(notACard);
        }

        [TestMethod()]
        public void GetHashCode_DistinctEqualCards_HaveSameHashCode()
        {
            // Arrange
            Rank rank = Rank.Ace;
            Suit suit = Suit.Hearts;
            var card1 = new Card(rank, suit);
            var card2 = new Card(rank, suit);

            // Assert
            Assert.AreEqual(card1.GetHashCode(), card2.GetHashCode());
        }

        [TestMethod()]
        public void GetHashCode_NonEqualCards_HaveDifferentHashCodes()
        {
            // Arrange
            var card1 = new Card(Rank.Ace, Suit.Hearts);
            var card2 = new Card(Rank.Ace, Suit.Spades);

            // Assert
            Assert.AreNotEqual(card1.GetHashCode(), card2.GetHashCode());
        }

        [TestMethod()]
        public void EqualsOperator_EqualRankAndSuit_ReturnsTrue()
        {
            // Arrange
            Rank rank = Rank.Ace;
            Suit suit = Suit.Hearts;
            var card1 = new Card(rank, suit);
            var card2 = new Card(rank, suit);

            // Assert
            Assert.IsTrue(card1 == card2);
        }

        [TestMethod()]
        public void NotEqualsOperator_EqualRankAndSuit_ReturnsFalse()
        {
            // Arrange
            Rank rank = Rank.Ace;
            Suit suit = Suit.Hearts;
            var card1 = new Card(rank, suit);
            var card2 = new Card(rank, suit);

            // Assert
            Assert.IsFalse(card1 != card2);
        }

        [TestMethod()]
        public void Card_ToString_ContainsRankAndSuit()
        {
            // Arrange
            Rank rank = Rank.Ace;
            Suit suit = Suit.Hearts;
            var card = new Card(rank, suit);

            // Act
            string shortString = card.ToString();

            // Assert
            Assert.IsTrue(shortString.Contains(rank.ToString()));
            Assert.IsTrue(shortString.Contains(suit.ToString()));
        }

        [TestMethod()]
        public void Card_ToShortString_ContainsRankAndSuit()
        {
            // Arrange
            Rank rank = Rank.Ace;
            Suit suit = Suit.Hearts;
            var card = new Card(rank, suit);

            // Act
            string shortString = card.ToShortString();

            // Assert
            Assert.IsTrue(shortString.Contains(rank.ToShortString()));
            Assert.IsTrue(shortString.Contains(suit.ToShortString()));
        }
    }
}
