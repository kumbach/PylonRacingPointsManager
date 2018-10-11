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


    }
}