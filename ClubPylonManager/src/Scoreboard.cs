using System;
using System.Collections.Generic;

namespace ClubPylonManager
{
    public class Scoreboard
    {
        public string Place { get; set; }
        public string Pilot { get; set; }
        public List<string> HeatTimes { get; set; }

        public Scoreboard()
        {
            Pilot = "";
            Place = "";
            HeatTimes = new List<string>();
        }

        public Scoreboard(string pilot) : this()
        {
            this.Pilot = pilot;
        }

        public double NmpraPoints(int numPilots)
        {
            double pilotEntries = numPilots;
            double.TryParse(Place, out var place);
            return Math.Round((100 / pilotEntries + 0.2) * (pilotEntries - place) + 1.2, 2);
        }

        public double ConvertHeatStringToSeconds(int heatNum)
        {
            string heatString = HeatTimes[heatNum];
            if (heatString.Length == 7)
            {
                double.TryParse(heatString.Substring(0, 1), out var mins);
                double.TryParse(heatString.Substring(2, 2), out var secs);
                double.TryParse(heatString.Substring(5), out var huns);

                return(mins * 60.0) + secs + (huns / 100.0);
            }

            return 0;
        }

        public int HeatCodeCount(string code)
        {
            int count = 0;
            foreach (var heatTime in HeatTimes)
            {
                if (heatTime.Equals(code)) {
                    ++count;
                }
            }
            return count;
        }

        public string BestTime()
        {
            double bestTime = 0;
            int bestHeatNum = -1;

            for (var i = 0; i < HeatTimes.Count; ++i) 
            {
                var time = ConvertHeatStringToSeconds(i);
                if (bestTime == 0 || (time > 0 && time < bestTime))
                {
                    bestTime = time;
                    bestHeatNum = i;
                }
            }

            return bestHeatNum < 0 ? "NT" : HeatTimes[bestHeatNum];
        }

        public string AverageTime()
        {
            double timeAccum = 0;
            double numHeats = 0;

            for (var i = 0; i < HeatTimes.Count; ++i)
            {
                if (string.IsNullOrWhiteSpace(HeatTimes[i]) || HeatTimes[i].Length != 7) {
                    continue;
                }
                var time = ConvertHeatStringToSeconds(i);
                if (time > 0)
                {
                    ++numHeats;
                    timeAccum += time;
                }
            }

            if (numHeats == 0) {
                return "NT";
            }
            return TimeUtils.ConvertDoubleTimeToString(Math.Round(timeAccum / numHeats, 2));
        }
    }
}