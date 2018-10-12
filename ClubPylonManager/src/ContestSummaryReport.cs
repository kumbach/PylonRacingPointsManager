using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ClubPylonManager
{
    public class ContestSummaryReport : AbstractReport
    {
        private List<Contest> contests;

        public ContestSummaryReport(List<Contest> contests) : base()
        {
            this.contests = contests;
        }

        public override string GenerateReport() {
            foreach (var contest in contests) {
                AddLine(contest.ToString());

                if (contest.Status.Equals("Incomplete")) {
                    AddLine("Cannot generate the report because the contest is marked as incomplete.");
                    AddLine("Edit the contest and correct all entry errors.");
                    NewLine();
                    AddLine("-------------------------------------------------------------------------------------");
                    NewLine();
                    continue;
                }

                AddLine("                                             Best     Average -------- TOTAL --------");
                AddLine("Place Pilot                          Points  Time       Time   DC DNS DNF OUT  MA CRA");
                AddLine("----- ------------------------------ ------ -------   ------- --- --- --- --- --- ---");

                var fastPilot = contest.GetFastestPilot();

                int totalDc = 0;
                int totalDns = 0;
                int totalDnf = 0;
                int totalOut = 0;
                int totalMa = 0;
                int totalCra = 0;

                foreach (var row in contest.Scoreboard) {
                    int dc = row.HeatCodeCount("DC");
                    int dns = row.HeatCodeCount("DNS");
                    int dnf = row.HeatCodeCount("DNF");
                    int outt = row.HeatCodeCount("OUT");
                    int ma = row.HeatCodeCount("MA");
                    int cra = row.HeatCodeCount("CRA");
                    totalDc += dc;
                    totalDns += dns;
                    totalDnf += dnf;
                    totalOut += outt;
                    totalMa += ma;
                    totalCra += cra;

                    string fastTimeCode = row.Pilot.Equals(fastPilot) ? "FT" : ""; 
                    AddLine($"{row.Place,4}. {row.Pilot,-30} {row.NmpraPoints(contest.Scoreboard.Count),6:N1} {row.BestTime(),-7}{fastTimeCode,2} {row.AverageTime(),-7} {dc,3} {dns,3} {dnf,3} {outt,3} {ma,3} {cra,3}");
                }
                AddLine($"{"",62}--- --- --- --- --- ---");
                AddLine($"{"",62}{totalDc,3} {totalDns,3} {totalDnf,3} {totalOut,3} {totalMa,3} {totalCra,3}");
                AddLine($"{"",62}=== === === === === ===");

                NewLine();
                AddLine("DC-double cut, DNS-did not start, DNF-did not finish, OUT-missed heat,");
                AddLine("MA-mid air, CRA-crash, FT-fast time");
                NewLine();
                AddLine("-------------------------------------------------------------------------------------");
                NewLine();
            }

            return rep.ToString();
        }
    }
}