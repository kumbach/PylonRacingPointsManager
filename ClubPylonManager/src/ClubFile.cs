﻿using System.Collections;
using System.Collections.Generic;

namespace ClubPylonManager {
    public class ClubFile
    {
        public string FileVersion { get; } = "1.0";
        public List<Pilot> ClubRoster { get; set; }
        public List<string> RaceClasses { get; set; }
        public List<Location> Locations { get; set; }
        public List<Contest> Contests { get; set; }

        public ClubFile() {
            NewFile();
        }

        public void NewFile() {
            this.ClubRoster = new List<Pilot>();
            this.RaceClasses = new List<string>();
            this.Locations = new List<Location>();
            this.Contests = new List<Contest>();
        }

        public Contest NewContest() {
            Contest contest = new Contest();
            //TODO populate with club roster, etc.
            return contest;
        }

        public void AddContest(Contest contest) {
            Contests.Add(contest);
        }
    }
}