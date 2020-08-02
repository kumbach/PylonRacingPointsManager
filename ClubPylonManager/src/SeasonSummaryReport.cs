using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubPylonManager {
  public class SeasonSummaryReport : AbstractReport {
    private readonly List<Contest> _contests;
    private readonly ClubFile _clubFile;

    public SeasonSummaryReport(List<Contest> contests, ClubFile clubFile) {
      _contests = contests;
      _clubFile = clubFile;
    }

    public override string GenerateReport() {
      Dictionary<string, LineItem> dict = null;

      string currentClass = "";
      foreach (var contest in _contests.OrderBy(c => c.RaceClass)) {
        if (contest.Status.Equals("Incomplete")) {
          continue;
        }

        if (!contest.RaceClass.Equals(currentClass)) {
          if (dict != null) {
            WriteDetails(currentClass, dict);
          }

          currentClass = contest.RaceClass;
          dict = CreatePilotLineItemDict(currentClass);
        }

        foreach (var row in contest.Scoreboard) {
          var pilotKey = row.Pilot.ToLower();
          if (!PilotIsMember(row.Pilot)) {
            continue;
          }

          var lineItem = dict[pilotKey];

          lineItem.NumContests += 1;
          lineItem.Points += row.NmpraPoints(contest.Pilots);

          int.TryParse(row.Place, out var placing);
          if ((lineItem.BestPlace == 0 && placing > 0) || (placing > 0 && placing < lineItem.BestPlace)) {
            lineItem.BestPlace = placing;
          }

          lineItem.Dc += row.HeatCodeCount("DC");
          lineItem.Dns += row.HeatCodeCount("DNS");
          lineItem.Dnf += row.HeatCodeCount("DNF");
          lineItem.Ma += row.HeatCodeCount("MA");
          lineItem.Cra += row.HeatCodeCount("CRA");

          //lineItem.TimeAvgAccum += row.AverageTime();
          lineItem.TimeAvgCount += 1;

          var bestTimeInContest = row.BestTimeValue();
          if (bestTimeInContest > 0) {
            if (lineItem.BestTime == 0 || bestTimeInContest < lineItem.BestTime) {
              lineItem.BestTime = bestTimeInContest;
            }
          }
        }
      }

      if (currentClass.Length > 0) {
        WriteDetails(currentClass, dict);
      }

      return ReportData.ToString();
    }

    private bool PilotIsMember(string pilotKey) {
      if (_clubFile.InactiveMembersInReports) {
        return true;
      }
      foreach (var pilot in _clubFile.ClubRoster) {
        if (pilotKey.ToLower().Equals(pilot.Name.ToLower()) && pilot.MembershipPaid) {
          return true;
        }
      }

      return false;
    }

    private void WriteDetails(string currentClass, Dictionary<string, LineItem> dict) {
      AddLine("Race Class: " + currentClass);
      AddLine("");
      AddLine("                                     Total  Contests Best   Best      ------ TOTAL ------");
      AddLine("Place Pilot                          Points Attended Finish Time       DC DNS DNF  MA CRA");
      AddLine("----- ------------------------------ ------ -------- ------ -------   --- --- --- --- ---");

      int place = 1;
      var fastPilot = GetFastPilot(dict);
      foreach (LineItem row in dict.Values.OrderByDescending(n => n.Points).ThenBy(t => t.BestTime)
        .ThenBy(f => f.BestPlace)) {
      }

      foreach (LineItem row in dict.Values.OrderByDescending(n => n.Points)) {
        if (!PilotIsMember(row.Pilot)) {
          continue;
        }

        string fastTimeCode = row.Pilot.Equals(fastPilot) ? "FT" : "";
        AddLine(
          $"{place++,4}. {row.Pilot,-30} {row.Points,6:F1} {row.NumContests,8} {row.BestPlace,6} {TimeUtils.ConvertDoubleTimeToString(row.BestTime),-7}{fastTimeCode,2} {row.Dc,3} {row.Dns,3} {row.Dnf,3} {row.Ma,3} {row.Cra,3}");
      }

      var totalsLineItem = MakeTotalLineItem(dict);

      AddLine($"{"",69} --- --- --- --- ---");
      AddLine(
        $"{"",69} {totalsLineItem.Dc,3} {totalsLineItem.Dns,3} {totalsLineItem.Dnf,3} {totalsLineItem.Ma,3} {totalsLineItem.Cra,3}");
      AddLine($"{"",69} === === === === ===");

      NewLine();
      AddLine("DC-double cut, DNS-did not start, DNF-did not finish, MA-mid air, CRA-crash, FT-fast time");
      NewLine();
      NewLine();
    }

    private string GetFastPilot(Dictionary<string, LineItem> dict) {
      double fastTime = 99999;
      string pilotName = "";

      foreach (LineItem row in dict.Values) {
        if (row.BestTime > 0 && row.BestTime < fastTime) {
          fastTime = row.BestTime;
          pilotName = row.Pilot;
        }
      }

      return fastTime < 99999 ? pilotName : "";
    }

    private LineItem MakeTotalLineItem(Dictionary<string, LineItem> dict) {
      var lineItem = new LineItem("");
      foreach (LineItem row in dict.Values) {
        lineItem.Dc += row.Dc;
        lineItem.Dns += row.Dns;
        lineItem.Dnf += row.Dnf;
        lineItem.Ma += row.Ma;
        lineItem.Cra += row.Cra;
      }

      return lineItem;
    }

    private Dictionary<string, LineItem> CreatePilotLineItemDict(string currentClass) {
      Dictionary<string, LineItem> dict = new Dictionary<string, LineItem>();
      foreach (var contest in _contests) {
        if (contest.RaceClass.Equals(currentClass)) {
          foreach (var row in contest.Scoreboard) {
            var pilot = row.Pilot.ToLower();
            if (!dict.ContainsKey(pilot)) {
              dict.Add(pilot, new LineItem(row.Pilot));
            }
          }
        }
      }

      return dict;
    }

    private class LineItem {
      public string Pilot { get; set; }
      public int NumContests { get; set; }
      public int BestPlace { get; set; }
      public double TimeAvgAccum { get; set; }
      public double TimeAvgCount { get; set; }
      public double BestTime { get; set; }
      public double Points { get; set; }
      public int Dc { get; set; }
      public int Dns { get; set; }
      public int Dnf { get; set; }
      public int Ma { get; set; }
      public int Cra { get; set; }

      public string AverageTime {
        get {
          if (TimeAvgCount > 0 && TimeAvgAccum > 0) {
            return TimeUtils.ConvertDoubleTimeToString(Math.Round(TimeAvgAccum / TimeAvgCount, 2));
          }

          return "NT";
        }
      }

      public LineItem(string pilot) {
        Pilot = pilot;
      }
    }
  }
}