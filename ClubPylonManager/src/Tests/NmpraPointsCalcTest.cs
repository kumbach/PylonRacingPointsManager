using NUnit.Framework;

namespace PylonRacingPointsManager.Tests
{
    public class NmpraPointsCalcTest
    {
        private Scoreboard scoreboard;

        [SetUp]
        public void SetUp()
        {
            scoreboard = new Scoreboard("Kevin");
        }

        [TestCase(93, 1, 10)]
        [TestCase(82.8, 2, 10)]
        [TestCase(72.6, 3, 10)]
        [TestCase(62.4, 4, 10)]
        [TestCase(52.20, 5, 10)]
        [TestCase(42.00, 6, 10)]
        [TestCase(31.80, 7, 10)]
        [TestCase(21.60, 8, 10)]
        [TestCase(11.40, 9, 10)]
        [TestCase(1.20, 10, 10)]
        [TestCase(1.20, 45, 45)]
        [TestCase(107.78, 1, 45)]
        [TestCase(53.4, 11, 22)]
        public void DoIt(double expectedResult, int place, int numEntries)
        {
            scoreboard.Place = "" + place;
            Assert.That(scoreboard.NmpraPoints(numEntries), Is.EqualTo(expectedResult));
        }
    }
}