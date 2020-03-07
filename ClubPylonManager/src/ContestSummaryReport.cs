using System.Collections.Generic;

namespace ClubPylonManager {
  public class ContestSummaryReport : AbstractReport {
    private List<Contest> contests;

    public ContestSummaryReport(List<Contest> contests) : base() {
      this.contests = contests;
    }

    public override string GenerateReport() {
      foreach (var contest in contests) {
        AddLine(contest.ToString());

        if (contest.Status.Equals("Incomplete")) {
          AddLine("Cannot generate the report because the contest is marked as incomplete.");
          AddLine("Edit the contest and correct all entry errors.");
          NewLine();
          AddLine("---------------------------------------------------------------------------------");
          NewLine();
          continue;
        }

        AddLine("                                             Best     ----- TOTAL -------");
        AddLine("Place Pilot                          Points  Time      DC DNS DNF  MA CRA");
        AddLine("----- ------------------------------ ------ -------   --- --- --- --- ---");

        var fastPilot = contest.GetFastestPilot();

        int totalDc = 0;
        int totalDns = 0;
        int totalDnf = 0;
        int totalMa = 0;
        int totalCra = 0;

        foreach (var row in contest.Scoreboard) {
          int dc = row.HeatCodeCount("DC");
          int dns = row.HeatCodeCount("DNS");
          int dnf = row.HeatCodeCount("DNF");
          int ma = row.HeatCodeCount("MA");
          int cra = row.HeatCodeCount("CRA");
          totalDc += dc;
          totalDns += dns;
          totalDnf += dnf;
          totalMa += ma;
          totalCra += cra;

          string fastTimeCode = row.Pilot.Equals(fastPilot) ? "FT" : "";
          AddLine(
            $"{row.Place,4}. {row.Pilot,-30} {row.NmpraPoints(contest.Scoreboard.Count),6:N1} {row.BestTime(),-7}{fastTimeCode,2} {dc,3} {dns,3} {dnf,3} {ma,3} {cra,3}");
        }

        AddLine($"{"",54}--- --- --- --- ---");
        AddLine($"{"",54}{totalDc,3} {totalDns,3} {totalDnf,3} {totalMa,3} {totalCra,3}");
        AddLine($"{"",54}=== === === === ===");

        NewLine();
        AddLine("DC-double cut, DNS-did not start, DNF-did not finish, MA-mid air, CRA-crash, FT-fast time");
        NewLine();
        AddLine("---------------------------------------------------------------------------------");
        NewLine();
      }

      return ReportData.ToString();
    }
  }
}