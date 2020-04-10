using CardEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardEngineTests
{
    [TestClass]
    public class DeckTests
    {
        private Deck deck;

        [TestInitialize]
        public void Initialize()
        {
            deck = new Deck();
        }

        [TestMethod()]
        public void NewDeck_ContainsAll52Cards()
        {
            // Assert
            foreach (Rank rank in Enum.GetValues(typeof(Rank)).Cast<Rank>().ToList())
                foreach (Suit suit in Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList())
                    Assert.IsTrue(deck.Any(c => c.Rank == rank && c.Suit == suit));
        }

        [TestMethod()]
        public void Draw_One_ReturnsTopCardOfTheDeck()
        {
            // Act
            var expectedCard = deck.Pop();
            deck = new Deck();
            var actualCard = deck.Draw();

            // Assert
            Assert.AreEqual(expectedCard, actualCard);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Draw_OneFromEmptyDeck_ThrowsInvalidOperationException()
        {
            // Arrange
            deck.Draw(52);

            // Act
            deck.Draw();
        }

        [TestMethod()]
        public void Draw_Two_ReturnsTopTwoCardOfTheDeck()
        {
            // Act
            var expectedCards = new List<Card>
            {
                deck.Pop(),
                deck.Pop(),
            };
            deck = new Deck();
            var actualCards = deck.Draw(2);

            // Assert
            Assert.AreEqual(expectedCards[0], actualCards[0]);
            Assert.AreEqual(expectedCards[1], actualCards[1]);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        [DataRow(1, 2)]
        [DataRow(0, 2)]
        public void Draw_MoreThanLeftInDeck_ThrowsInvalidOperationException(int cardsLeft, int cardsToDraw)
        {
            // Arrange
            deck.Draw(52 - cardsLeft);

            // Act
            deck.Draw(cardsToDraw);
        }
    }
}
