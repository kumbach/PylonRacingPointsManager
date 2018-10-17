using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ClubPylonManager {
    public class SeasonSummaryReport : AbstractReport {
        private List<Contest> contests;

        public SeasonSummaryReport(List<Contest> contests) : base() {
            this.contests = contests;
        }

        public override string GenerateReport() {
            var dict = CreatePilotLineItemDict();

            AddLine("                                     Total  Contests Best   Best      Average -------- TOTAL --------");
            AddLine("Place Pilot                          Points Attended Finish Time       Time   DC DNS DNF OUT  MA CRA");
            AddLine("----- ------------------------------ ------ -------- ------ -------   ------- --- --- --- --- --- ---");

            foreach (var contest in contests) {
                if (contest.Status.Equals("Incomplete")) {
                    continue;
                }

                var fastPilot = "kevin";

                foreach (var row in contest.Scoreboard) {
                    var pilotKey = row.Pilot.ToLower();
                    var lineItem = dict[pilotKey];

                    lineItem.NumContests += 1;
                    lineItem.Points += row.NmpraPoints(contest.Pilots);
                    lineItem.Dc += row.HeatCodeCount("DC");
                    lineItem.Dns += row.HeatCodeCount("DNF");
                    lineItem.Dnf += row.HeatCodeCount("DNF");
                    lineItem.Out += row.HeatCodeCount("OUT");
                    lineItem.Ma += row.HeatCodeCount("MA");
                    lineItem.Cra += row.HeatCodeCount("CRA");

                    var bestTimeInContest = row.BestTimeValue();
                    if (bestTimeInContest > 0) {
                        lineItem.TimeAvgAccum += bestTimeInContest;
                        lineItem.TimeAvgCount += 1;

                        if (lineItem.BestTime == 0 || bestTimeInContest < lineItem.BestTime) {
                            lineItem.BestTime = bestTimeInContest;
                        }
                    }
                }
            }

            
            int place = 1;
            string fastTimeCode = "";

            foreach (LineItem row in dict.Values.OrderByDescending(n => n.Points)) {
                AddLine($"{place++,4}. {row.Pilot,-30} {row.Points,6:N1} {row.NumContests,8} {row.BestPlace,6} {TimeUtils.ConvertDoubleTimeToString(row.BestTime),-7}{fastTimeCode,2} {row.AverageTime,-7} {row.Dc,3} {row.Dns,3} {row.Dnf,3} {row.Out,3} {row.Ma,3} {row.Cra,3}");
            }

            var totalsLineItem = MakeTotalLineItem(dict);

            AddLine($"{"",77} --- --- --- --- --- ---");
            AddLine($"{"",77} {totalsLineItem.Dc,3} {totalsLineItem.Dns,3} {totalsLineItem.Dnf,3} {totalsLineItem.Out,3} {totalsLineItem.Ma,3} {totalsLineItem.Cra,3}");
            AddLine($"{"",77} === === === === === ===");

            NewLine();
            AddLine("DC-double cut, DNS-did not start, DNF-did not finish, OUT-missed heat,");
            AddLine("MA-mid air, CRA-crash, FT-fast time");

            return rep.ToString();
        }

        private LineItem MakeTotalLineItem(Dictionary<string, LineItem> dict) {
            var lineItem = new LineItem("");
            foreach (LineItem row in dict.Values) {
                lineItem.Dc += row.Dc;
                lineItem.Dns += row.Dns;
                lineItem.Dnf += row.Dns;
                lineItem.Out += row.Out;
                lineItem.Ma += row.Ma;
                lineItem.Cra += row.Cra;
            }

            return lineItem;
        }

        private Dictionary<string, LineItem> CreatePilotLineItemDict() {
            Dictionary<string, LineItem> dict = new Dictionary<string, LineItem>();
            foreach (var contest in contests) {
                foreach (var row in contest.Scoreboard) {
                    var pilot = row.Pilot.ToLower();
                    if (!dict.ContainsKey(pilot)) {
                        dict.Add(pilot, new LineItem(row.Pilot));
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
            public int Out { get; set; }
            public int Ma { get; set; }
            public int Cra { get; set; }

            public string AverageTime {
                get {
                    if (TimeAvgCount > 0 && TimeAvgAccum > 0) {
                        return TimeUtils.ConvertDoubleTimeToString(Math.Round(TimeAvgAccum / TimeAvgCount, 2));
                    }
                    else {
                        return "NT";
                    }
                }
            }

            public LineItem(string pilot) {
                Pilot = pilot;
            }

        }
    }
}