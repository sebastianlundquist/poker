using CardEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardEngineTests
{
    [TestClass]
    public class PokerHandTests
    {
        PokerHand pairHand;
        PokerHand twoPairHand;
        PokerHand threeOfAKindHand;
        PokerHand straightHand;
        PokerHand flushHand;
        PokerHand fourOfAKindHand;
        PokerHand straightFlushHand;

        [TestInitialize]
        public void Initialize()
        {
            pairHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
            };

            twoPairHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
            };

            threeOfAKindHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Two, Suit.Clubs),
            };

            straightHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Spades),
            };

            flushHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Seven, Suit.Hearts),
            };

            fourOfAKindHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Two, Suit.Clubs),
            };

            straightFlushHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Four, Suit.Hearts),
                new Card(Rank.Five, Suit.Hearts),
                new Card(Rank.Six, Suit.Hearts),
            };
        }

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

        #region Extension Methods
        [TestMethod()]
        public void Evaluate_HighCard_ReturnsHighCard()
        {
            // Arrange
            var hand = new PokerHand { new Card(Rank.Ace, Suit.Spades), new Card(Rank.Queen, Suit.Hearts) };

            // Assert
            Assert.AreEqual(PokerHandRanking.HighCard, hand.Evaluate());
        }

        [TestMethod()]
        public void Evaluate_Pair_ReturnsPair()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.Pair, pairHand.Evaluate());
        }

        [TestMethod()]
        public void Evaluate_TwoPairs_ReturnsTwoPairs()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.TwoPairs, twoPairHand.Evaluate());
        }

        [TestMethod()]
        public void Evaluate_ThreeOfAKind_ReturnsThreeOfAKind()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.ThreeOfAKind, threeOfAKindHand.Evaluate());
        }

        [TestMethod()]
        public void Evaluate_Straight_ReturnsStraight()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.Straight, straightHand.Evaluate());
        }

        [TestMethod()]
        public void Evaluate_Flush_ReturnsFlush()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.Flush, flushHand.Evaluate());
        }

        [TestMethod()]
        public void Evaluate_FourOfAKind_ReturnsFourOfAKind()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.FourOfAKind, fourOfAKindHand.Evaluate());
        }

        [TestMethod()]
        public void Evaluate_StraightFlush_ReturnsStraightFlush()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.StraightFlush, straightFlushHand.Evaluate());
        }
        #endregion
    }
}
