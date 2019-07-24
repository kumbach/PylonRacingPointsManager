using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClubPylonManager {
  public class ClubFile {
    [JsonIgnore] public string Filename { get; set; }

    [JsonIgnore] public bool Dirty { get; set; }

    public string FileVersion { get; } = "1.0";
    public List<Pilot> ClubRoster { get; set; }
    public List<RaceClass> RaceClasses { get; set; }
    public List<Location> Locations { get; set; }
    public List<Contest> Contests { get; set; }

    public ClubFile() {
      NewFile();
    }

    public void NewFile() {
      this.ClubRoster = new List<Pilot>();
      this.RaceClasses = new List<RaceClass>();
      this.Locations = new List<Location>();
      this.Contests = new List<Contest>();
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
  }
}