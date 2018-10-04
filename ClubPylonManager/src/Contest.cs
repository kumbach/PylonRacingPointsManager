namespace ClubPylonManager {
    public class Contest {
        public string ContestDate { get; set; }
        public string Location { get; set; }
        public string RaceClass { get; set; }
        public string Status { get; set; }
        public string Rounds { get; set; }
        public string Pilots { get; set; }
        public string Notes { get; set; }

        public Contest() {

        }

        public Contest(string date, string location, string raceClass, string status, string rounds, string pilots, string notes) {
            this.ContestDate = date;
            this.Location = location;
            this.RaceClass = raceClass;
            this.Status = status;
            this.Rounds = rounds;
            this.Pilots = pilots;
            this.Notes = notes;
        }
    }
}