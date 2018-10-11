using NUnit.Framework;

namespace ClubPylonManager
{
    public class ScoreboardTests
    {
        [TestCase(0.01, "0:00.01")]
        [TestCase(0.10, "0:00.10")]
        [TestCase(1.0, "0:01.00")]
        [TestCase(10.0, "0:10.00")]
        [TestCase(60.0, "1:00.00")]
        [TestCase(61.0, "1:01.00")]
        [TestCase(62.5, "1:02.50")]
        [TestCase(120, "2:00.00")]
        public void ConvertHeatStringToSeconds(double expectedResult, string timeString)
        {
            Scoreboard s = new Scoreboard("Kevin");
            s.HeatTimes.Add(timeString);
            Assert.That(s.ConvertHeatStringToSeconds(0), Is.EqualTo(expectedResult));
        }

        [Test]
        public void BestTime()
        {
            Scoreboard s = new Scoreboard("Kevin");
            s.HeatTimes.Add("1:04.42");
            s.HeatTimes.Add("1:10.06");
            s.HeatTimes.Add("1:31.22");
            s.HeatTimes.Add("NT");
            s.HeatTimes.Add("DC");

            Assert.That(s.BestTime(), Is.EqualTo("1:04.42"));
        }

        [TestCase("2:00.00", 120)]
        [TestCase("1:00.00", 60)]
        [TestCase("1:01.00", 61)]
        [TestCase("1:01.50", 61.5)]
        [TestCase("1:01.05", 61.05)]
        [TestCase("1:01.01", 61.01)]
        [TestCase("1:01.99", 61.99)]
        [TestCase("NT", 9*60 + .01)]
        public void ConvertDoubleTimeToString(string expectedResult, double seconds)
        {
            Assert.That(TimeUtils.ConvertDoubleTimeToString(seconds), Is.EqualTo(expectedResult));
        }


    }
}