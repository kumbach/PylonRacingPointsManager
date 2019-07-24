using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ClubPylonManager {
  public class ContestImporter {
    private StreamReader file;

    public List<Contest> Import(string filename) {
      file = new StreamReader(filename);

      var contests = new List<Contest>();
      string line;
      Contest contest = null;

      line = NextLine();
      while (line != null) {
        ExtractContestDetails(line, out var date, out var raceClass, out var location);
        contest = new Contest {ContestDate = date, RaceClass = raceClass, Location = location};
        contest.Status = "Valid";

        line = file.ReadLine();
        while (!string.IsNullOrEmpty(line)) {
          ExtractPilotDetails(line, out var place, out var pilot, out var heatTimes);
          var row = new Scoreboard(pilot);
          row.Place = place;

          row.HeatTimes.AddRange(heatTimes);
          contest.Scoreboard.Add(row);
          line = file.ReadLine();
        }

        contest.Pilots = contest.Scoreboard.Count;
        contests.Add(contest);

        line = NextLine();
      }

      file.Close();

      return contests;
    }

    private void ExtractPilotDetails(string line, out string place, out string pilot, out List<string> heatTimes) {
      string[] fields = line.Split(',');
      place = fields[0];
      pilot = fields[1].Trim();
      heatTimes = new List<string>();

      for (int i = 2; i < fields.Length; ++i) {
        heatTimes.Add(convertFieldCode(fields[i]));
      }
    }

    private string convertFieldCode(string code) {
      if (code != null && code.ToUpper().Equals("OUT")) {
        return "DNS";
      }

      return code;
    }


    private void ExtractContestDetails(string line, out DateTime dateTime, out string raceClass, out string location) {
      string[] fields = line.Split(',');

      DateTime.TryParseExact(fields[0], "yyyy-MM-dd", null, DateTimeStyles.None, out dateTime);
      raceClass = fields[1].Trim();
      location = fields[2].Trim();
    }

    private string NextLine() {
      string line = file.ReadLine();

      while (line != null && string.IsNullOrEmpty(line)) {
        line = file.ReadLine();
      }

      return line;
    }
  }
}