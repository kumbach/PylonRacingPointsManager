using System.Collections.Generic;

namespace ClubPylonManager {
    public class Scoreboard {
        public int Place { get; set; }
        public string Pilot { get; set; }
        public List<string> HeatTimes { get; set; }

        public Scoreboard() {
            Pilot = "";
            Place = 1;
            HeatTimes = new List<string>();
        }
    }
}