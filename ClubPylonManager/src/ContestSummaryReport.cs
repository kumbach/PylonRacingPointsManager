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


            foreach (var contest in contests)
            {
                rep.Append(contest);
                rep.Append(Environment.NewLine);
                rep.Append("                                             Best    Average -------- TOTAL --------");
                rep.Append(Environment.NewLine);
                rep.Append("Place Pilot                          Points  Time      Time   DC DNS DNF OUT  MA CRA");
                rep.Append(Environment.NewLine);
                rep.Append("----- ------------------------------ ------ -------- ------- --- --- --- --- --- ---");
                rep.Append(Environment.NewLine);

                foreach (var row in contest.Scoreboard)
                {
                    string line = string.Format("{0,4}. {1,-30} {2,6:N1} {3,7}{4,1} {5,3} {6,3} {7,3} {8,3} {9,3} {10,3} {11,3}",
                        row.Place,
                        row.Pilot,
                        row.NmpraPoints(contest.Scoreboard.Count),
                        row.BestTime(),
                        "?",
                        row.AverageTime(),
                        row.HeatCodeCount("DC"),
                        row.HeatCodeCount("DNS"),
                        row.HeatCodeCount("DNF"),
                        row.HeatCodeCount("OUT"),
                        row.HeatCodeCount("MA"),
                        row.HeatCodeCount("CRA")
                    );
                    rep.Append(line);
                    rep.Append(Environment.NewLine);
                }

                rep.Append(Environment.NewLine);
                rep.Append(Environment.NewLine);
            }

            return rep.ToString();
        }
    }
}