using CardEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardEngineTests
{
    [TestClass]
    public class RankExtensionsTests
    {
        [TestMethod()]
        [DataRow(Rank.Ace, "A")]
        [DataRow(Rank.King, "K")]
        [DataRow(Rank.Queen, "Q")]
        [DataRow(Rank.Jack, "J")]
        [DataRow(Rank.Ten, "10")]
        [DataRow(Rank.Nine, "9")]
        [DataRow(Rank.Eight, "8")]
        [DataRow(Rank.Seven, "7")]
        [DataRow(Rank.Six, "6")]
        [DataRow(Rank.Five, "5")]
        [DataRow(Rank.Four, "4")]
        [DataRow(Rank.Three, "3")]
        [DataRow(Rank.Two, "2")]
        public void ToShortString_ValidRank_ReturnsCorrectString(Rank input, string output)
        {
            // Assert
            Assert.AreEqual(output, input.ToShortString());
        }
    }
}
