using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;

namespace ClubPylonManager
{
    public class ContestImporter
    {
        private StreamReader file;


        public List<Contest> Import(string filename)
        {
            file = new System.IO.StreamReader(filename);

            var contests = new List<Contest>();
            string line;
            Contest contest = null;

            line = NextLine();
            while (line != null)
            {
                if (contest == null)
                {
                    ExtractContestDetails(line, out var date, out var raceClass, out var location);
                    contest = new Contest {ContestDate = date, RaceClass = raceClass, Location = location};
                    contest.Status = "Valid";
                }

                line = file.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    ExtractPilotDetails(line, out var place, out var pilot, out var heatTimes);
                    var row = new Scoreboard(pilot);
                    row.Place = place;

                    row.HeatTimes.AddRange(heatTimes);
                    contest.Scoreboard.Add(row);
                    line = file.ReadLine();
                }

                contests.Add(contest);
                contest = null;

                line = NextLine();
            }

            System.Console.WriteLine(line);

            file.Close();

            return contests;

        }

        private void ExtractPilotDetails(string line, out string place, out string pilot, out List<string> heatTimes)
        {
            string[] fields = line.Split(',');
            place = fields[0];
            pilot = fields[1].Trim();
            heatTimes = new List<string>();

            for (int i = 2; i < fields.Length; ++i)
            {
                heatTimes.Add(fields[i]);
            }
        }


        private void ExtractContestDetails(string line, out DateTime dateTime, out string raceClass, out string location)
        {
            string[] fields = line.Split(',');

            DateTime.TryParseExact(fields[0], "yyyy-MM-dd", null, DateTimeStyles.None, out dateTime);
            raceClass = fields[1].Trim();
            location = fields[2].Trim();
        }

        private string NextLine()
        {
            string line = file.ReadLine();

            while (line != null && string.IsNullOrEmpty(line)) 
            {
                line = file.ReadLine();
            }

            return line;
        }
    }
}