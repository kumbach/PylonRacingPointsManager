using System.Collections.Generic;
using System.IO;

namespace PylonRacingPointsManager {
    public class PilotImporter {
        private StreamReader file;

        public List<Pilot> Import(string filename) {
            file = new StreamReader(filename);

            var pilots = new List<Pilot>();
            string line;

            line = NextLine();
            while (line != null) {
                ExtractPilotDetails(line, out var name, out var number, out var active);
                if (ValidPilotRow(name, number, active)) {
                    pilots.Add(new Pilot() {
                        Name = name,
                        PilotNumber = number,
                        Active = active.Equals("yes"),
                        InDistrict = false
                    });
                }

                line = NextLine();
            }

            file.Close();

            return pilots;
        }

        private bool ValidPilotRow(string name, string number, string active) {
            return !string.IsNullOrEmpty(name);
        }

        private void ExtractPilotDetails(string line, out string name, out string number, out string active) {
            name = "";
            number = "";
            active = "";
            string[] fields = line.Split(',');
            
            if (fields.Length >= 1) {
                name = fields[0];
            }

            if (fields.Length > 1) {
                number = fields[1].Trim().ToUpper();
            }

            if (fields.Length > 2) {
                active = fields[2].Trim().ToLower();
            }
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