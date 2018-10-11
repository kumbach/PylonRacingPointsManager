using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ClubPylonManager
{
    public class ContestSummaryReport
    {
        private List<Contest> contests;

        public ContestSummaryReport(List<Contest> contests)
        {
            this.contests = contests;
        }

        public string GenerateReport()
        {
            StringBuilder rep = new StringBuilder();


            foreach (var contest in contests) {
                var fastPilot = contest.GetFastestPilot();
                rep.Append(contest);
                rep.Append(Environment.NewLine);

                if (contest.Status.Equals("Incomplete")) {
                    rep.Append("Cannot generate the report because the scoreboard for this");
                    rep.Append(Environment.NewLine);
                    rep.Append("contest is either incomplete or has entry errors.");
                    rep.Append(Environment.NewLine);
                    rep.Append(Environment.NewLine);
                    rep.Append("-------------------------------------------------------------------------------------");
                    rep.Append(Environment.NewLine);
                    rep.Append(Environment.NewLine);
                    continue;
                }

                rep.Append("                                             Best     Average -------- TOTAL --------");
                rep.Append(Environment.NewLine);
                rep.Append("Place Pilot                          Points  Time       Time   DC DNS DNF OUT  MA CRA");
                rep.Append(Environment.NewLine);
                rep.Append("----- ------------------------------ ------ -------   ------- --- --- --- --- --- ---");
                rep.Append(Environment.NewLine);

                foreach (var row in contest.Scoreboard) {
                    string fastTimeCode = row.Pilot.Equals(fastPilot) ? "FT" : ""; 
                    string line =
                        $"{row.Place,4}. {row.Pilot,-30} {row.NmpraPoints(contest.Scoreboard.Count),6:N1} {row.BestTime(),-7}{fastTimeCode,2} {row.AverageTime(),-7} {row.HeatCodeCount("DC"),3} {row.HeatCodeCount("DNS"),3} {row.HeatCodeCount("DNF"),3} {row.HeatCodeCount("OUT"),3} {row.HeatCodeCount("MA"),3} {row.HeatCodeCount("CRA"),3}";
                    rep.Append(line);
                    rep.Append(Environment.NewLine);
                }
                rep.Append(Environment.NewLine);
                rep.Append(Environment.NewLine);
                rep.Append("-------------------------------------------------------------------------------------");
                rep.Append(Environment.NewLine);
                rep.Append(Environment.NewLine);
            }

            return rep.ToString();
        }
    }
}