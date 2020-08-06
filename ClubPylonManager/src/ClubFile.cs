using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace PylonRacingPointsManager {
    public class ClubFile {
        [JsonIgnore] public string Filename { get; set; }
        [JsonIgnore] public bool Dirty { get; set; }
        [JsonIgnore] public string LastError { get; set; } = "";

        public string FileVersion { get; } = "1.0";
        public List<Pilot> ClubRoster { get; set; }
        public List<RaceClass> RaceClasses { get; set; }
        public List<Location> Locations { get; set; }
        public List<Contest> Contests { get; set; }

        public ClubFile() {
            NewFile();
        }

        private void NewFile() {
            ClubRoster = new List<Pilot>();
            RaceClasses = new List<RaceClass>();
            Locations = new List<Location>();
            Contests = new List<Contest>();
        }

        public Contest NewContest() {
            Contest contest = new Contest();
            return contest;
        }

        public void AddContest(Contest contest) {
            Contests.Add(contest);
        }

        public void SetDirty() {
            Dirty = true;
        }

        public bool IsUnNamed() {
            return string.IsNullOrWhiteSpace(Filename);
        }

        public bool PilotRosterIsEmpty() {
            return ClubRoster.Count == 0;
        }

        public void SortAll() {
            Contests = Contests.OrderByDescending(o => o.ContestDate).ToList();
            Locations = Locations.OrderBy(o => o.Name).ToList();
            RaceClasses = RaceClasses.OrderBy(o => o.Name).ToList();
        }

        private void SortByDate() {
            Contests = Contests.OrderByDescending(o => o.ContestDate).ToList();
        }

        public bool Save() {
            try {
                SortByDate();
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);

                File.WriteAllText(Filename, json);
                LastError = "";
                Dirty = false;

                return true;
            }
            catch (Exception e) {
                LastError = $"The file could not be saved.\n{e.Message}";
                return false;
            }
        }

        public void AddMissingPilotsInContest(Contest contest) {
            foreach (var row in contest.Scoreboard) {
                if (!PilotExists(row.Pilot, "")) {
                    ClubRoster.Add(new Pilot() {
                        Name = row.Pilot,
                        Active = true
                    });
                }
            }

            ClubRoster = ClubRoster.OrderBy(o => o.Name).ToList();
        }

        public int AddMissingPilots(List<Pilot> pilots) {
            var numAdded = 0;
            foreach (var row in pilots) {
                var addPilot = true;

                if (!PilotExists(row.Name, row.PilotNumber)) {
                    ClubRoster.Add(row);
                    ++numAdded;
                }
            }

            ClubRoster = ClubRoster.OrderBy(o => o.Name).ToList();
            return numAdded;
        }

        public void AddMissingLocation(string location) {
            foreach (var loc in Locations) {
                if ((loc.Name ?? "").ToUpper().Equals(location.ToUpper())) {
                    return;
                }
            }

            Locations.Add(new Location(location));
        }

        public void AddMissingRaceClass(string name) {
            foreach (var raceClass in RaceClasses) {
                if ((raceClass.Name ?? "").ToUpper().Equals(name.ToUpper())) {
                    return;
                }
            }

            RaceClasses.Add(new RaceClass(name));
        }

        private bool PilotExists(string name, string number) {
            foreach (var pilot in ClubRoster) {
                if ((pilot.Name ?? "").ToLower().Equals(name.ToLower()) &&
                    (pilot.PilotNumber ?? "").ToLower().Equals(number.ToLower())) {
                    return true;
                }
            }

            return false;
        }

        public bool ContestExists(Contest contest) {
            var location = contest.Location.ToUpper();
            var raceClass = contest.RaceClass.ToUpper();
            foreach (var con in Contests) {
                if (con.ContestDate == contest.ContestDate &&
                    con.RaceClass.ToUpper().Equals(raceClass) &&
                    con.Location.ToUpper().Equals(location)) {
                    return true;
                }
            }

            return false;
        }
    }
}