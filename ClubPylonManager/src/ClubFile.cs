﻿using System;
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

        public void AddMissingPilots() {
            foreach (var contest in Contests) {
                foreach (var row in contest.Scoreboard) {
                    var addPilot = true;

                    foreach (var pilot in ClubRoster) {
                        if (pilot.Name.ToLower().Equals(row.Pilot.ToLower())) {
                            addPilot = false;
                            break;
                        }
                    }

                    if (addPilot) {
                        ClubRoster.Add(new Pilot() {
                            Name =  row.Pilot,
                            Active =  false
                        });
                    }
                }
            }
        }
    }
}