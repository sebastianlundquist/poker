using CardEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardEngineTests
{
    [TestClass]
    public class PokerHandExtensionsTests
    {
        Deck shuffledDeck;
        PokerHand highCardHand;
        PokerHand pairHand;
        PokerHand twoPairHand;
        PokerHand threeOfAKindHand;
        PokerHand straightHand;
        PokerHand flushHand;
        PokerHand fullHouseHand;
        PokerHand fourOfAKindHand;
        PokerHand straightFlushHand;

        [TestInitialize]
        public void Initialize()
        {
            shuffledDeck = new Deck().Shuffle<Deck, Card>();

            highCardHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Eight, Suit.Diamonds),
            };

            pairHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Four, Suit.Spades),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Eight, Suit.Diamonds),
            };

            twoPairHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.Eight, Suit.Diamonds),
            };

            threeOfAKindHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Six, Suit.Clubs),
                new Card(Rank.Eight, Suit.Diamonds),
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

            fullHouseHand = new PokerHand
            {
                new Card(Rank.Three, Suit.Hearts),
                new Card(Rank.Three, Suit.Spades),
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Two, Suit.Diamonds),
            };

            fourOfAKindHand = new PokerHand
            {
                new Card(Rank.Two, Suit.Hearts),
                new Card(Rank.Two, Suit.Spades),
                new Card(Rank.Two, Suit.Diamonds),
                new Card(Rank.Two, Suit.Clubs),
                new Card(Rank.Eight, Suit.Diamonds),
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
        public void IsFull_FullHand_ReturnsTrue()
        {
            // Arrange
            var hand = new PokerHand();
            hand.PushMany(shuffledDeck.Draw(7));

            // Assert
            Assert.IsTrue(hand.IsFull());
        }

        [TestMethod()]
        public void IsFull_NonFullHand_ReturnsFalse()
        {
            // Arrange
            var hand = new PokerHand();
            hand.PushMany(shuffledDeck.Draw(6));

            // Assert
            Assert.IsFalse(hand.IsFull());
        }

        [TestMethod()]
        public void Evaluate_HighCard_ReturnsHighCard()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.HighCard, highCardHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_Pair_ReturnsPair()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.Pair, pairHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_TwoPairs_ReturnsTwoPairs()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.TwoPairs, twoPairHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_ThreeOfAKind_ReturnsThreeOfAKind()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.ThreeOfAKind, threeOfAKindHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_Straight_ReturnsStraight()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.Straight, straightHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_Flush_ReturnsFlush()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.Flush, flushHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_FullHouse_ReturnsFullHouse()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.FullHouse, fullHouseHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_FourOfAKind_ReturnsFourOfAKind()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.FourOfAKind, fourOfAKindHand.GetCurrentHand().Ranking);
        }

        [TestMethod()]
        public void Evaluate_StraightFlush_ReturnsStraightFlush()
        {
            // Assert
            Assert.AreEqual(PokerHandRanking.StraightFlush, straightFlushHand.GetCurrentHand().Ranking);
        }
    }
}
