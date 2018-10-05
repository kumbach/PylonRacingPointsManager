using System.Collections.Generic;

namespace ClubPylonManager {
    public class Scoreboard {
        public string Pilot { get; set; }
        public List<string> HeatTimes { get; set; }

        public Scoreboard() {
            Pilot = "";
            HeatTimes = new List<string>();
        }
    }
}