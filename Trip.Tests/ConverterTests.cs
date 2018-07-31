using NUnit.Framework;
using System.Collections.Generic;

namespace Trip.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void TourListToChain_ShouldReturnSortedChain_IfCardsNotSorted()
        {
            var expected = new string[] { "Melbourne", "Cologne", "Moscow", "Paris" };
            var cards = new List<Tour>()
            {
                new Tour(expected[0],expected[1]),
                new Tour(expected[2],expected[3]),
                new Tour(expected[1],expected[2])
            };
            var sut = new Converter();
            var result = sut.TourListToChain(cards);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void TourListToChain_ShouldReturnSortedChain_IfCardsSorted()
        {
            var expected = new string[] { "Melbourne", "Cologne", "Moscow", "Paris" };
            var cards = new List<Tour>()
            {
                new Tour(expected[0],expected[1]),
                new Tour(expected[1],expected[2]),
                new Tour(expected[2],expected[3])
            };
            var sut = new Converter();
            var result = sut.TourListToChain(cards);
            Assert.AreEqual(result, expected);
        }
    }
}
