using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClubPylonManager {
    public class Contest {
        private const int DefaultNumPilots = 10;
        private const int DefaultNumRounds = 8;

        public DateTime ContestDate { get; set; }
        public string Location { get; set; }
        public string RaceClass { get; set; }
        public string Status { get; set; }
        public int Rounds { get; set; }
        public int Pilots { get; set; }
        public string Notes { get; set; }
        public List<Scoreboard> Scoreboard { get; set; }

        public Contest() : this(DateTime.Now, "", "", "Open", DefaultNumRounds, DefaultNumPilots, "") {

        }

        public Contest(DateTime date, string location, string raceClass, string status, int rounds, int pilots, string notes) {
            this.ContestDate = date;
            this.Location = location;
            this.RaceClass = raceClass;
            this.Status = status;
            this.Rounds = rounds;
            this.Pilots = pilots;
            this.Notes = notes;
            this.Scoreboard = new List<Scoreboard>();
        }

        public Contest Clone()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Contest>(json);
        }
    }
}