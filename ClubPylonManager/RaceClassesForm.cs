using System;
using System.Linq;
using System.Windows.Forms;

namespace PylonRacingPointsManager {
    public partial class RaceClassesForm : Form {
        private readonly ClubFile clubFile;

        public RaceClassesForm(ClubFile clubFile) {
            this.clubFile = clubFile;
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData() {
            foreach (var pilot in clubFile.RaceClasses) {
                dataBindingSource.Add(pilot);
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            clubFile.RaceClasses.Clear();
            foreach (RaceClass raceClass in dataBindingSource) {
                raceClass.Name = raceClass.Name == null ? "" : raceClass.Name.Trim();
                if (string.IsNullOrEmpty(raceClass.Name)) {
                    continue;
                }
                clubFile.RaceClasses.Add(raceClass);
            }

            clubFile.RaceClasses = clubFile.RaceClasses.OrderBy(o => o.Name).ToList();

            clubFile.SetDirty();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void rosterGridView_SelectionChanged(object sender, EventArgs e) {
            if (rosterGridView.SelectedCells.Count == 0) {
                RemoveRowButton.Enabled = false;
                return;
            }

            int row = rosterGridView.SelectedCells[0].RowIndex;
            bool enabled = row < rosterGridView.RowCount - 1;
            RemoveRowButton.Enabled = enabled;
        }

        private void RemoveRowButton_Click(object sender, EventArgs e) {
            if (rosterGridView.SelectedCells.Count == 0) {
                return;
            }

            if (rosterGridView.Rows.Count == 1) {
                RemoveRowButton_Click(sender, e);
                return;
            }

            int row = rosterGridView.SelectedCells[0].RowIndex;
            rosterGridView.Rows.RemoveAt(row);
        }
    }
}