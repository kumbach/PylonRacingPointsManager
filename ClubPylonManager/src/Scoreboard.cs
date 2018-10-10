using System.Collections.Generic;

namespace ClubPylonManager {
    public class Scoreboard {
        public string Place { get; set; }
        public string Pilot { get; set; }
        public List<string> HeatTimes { get; set; }

        public Scoreboard() {
            Pilot = "";
            Place = "";
            HeatTimes = new List<string>();
        }

        public Scoreboard(string pilot) : this()
        {
            this.Pilot = pilot;
        }
    }
}