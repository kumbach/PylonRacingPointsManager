using System;
using System.Linq;
using System.Windows.Forms;

namespace PylonRacingPointsManager {
    public partial class RosterForm : Form {
        private readonly ClubFile clubFile;

        public RosterForm(ClubFile clubFile) {
            this.clubFile = clubFile;
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData() {
            foreach (var pilot in clubFile.ClubRoster) {
                pilotBindingSource.Add(pilot);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            clubFile.ClubRoster.Clear();
            foreach (Pilot pilot in pilotBindingSource) {
                pilot.Name = pilot.Name == null ? "" : pilot.Name.Trim();
                pilot.PilotNumber = pilot.PilotNumber == null ? "" : pilot.PilotNumber.Trim();
                if (string.IsNullOrEmpty(pilot.Name)) {
                    continue;
                }

                clubFile.ClubRoster.Add(pilot);
            }

            clubFile.ClubRoster = clubFile.ClubRoster.OrderBy(o => o.Name).ToList();
            clubFile.SetDirty();
            Close();
        }

        private void rosterGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        }

        private void pilotBindingSource_CurrentChanged(object sender, EventArgs e) {
        }

        private void ValidateInput(object sender, System.ComponentModel.CancelEventArgs e) {
            if (sender != rosterGridView) {
                return;
            }

// no validation required yet
            // foreach (Pilot pilot in pilotBindingSource) {
            //     if (string.IsNullOrEmpty(pilot.Name)) {
            //         e.Cancel = true;
            //     }
            // }
        }

        private void DeleteRowButton_Click(object sender, EventArgs e) {
            if (rosterGridView.SelectedCells.Count == 0) {
                return;
            }

            if (rosterGridView.Rows.Count == 1) {
                DeleteRowButton_Click(sender, e);
                return;
            }

            int row = rosterGridView.SelectedCells[0].RowIndex;
            rosterGridView.Rows.RemoveAt(row);
        }

        private void rosterGridView_SelectionChanged(object sender, EventArgs e) {
            if (rosterGridView.SelectedCells.Count == 0) {
                DeleteRowButton.Enabled = false;
                return;
            }

            int row = rosterGridView.SelectedCells[0].RowIndex;
            bool enabled = row < rosterGridView.RowCount - 1;
            DeleteRowButton.Enabled = enabled;
        }
    }
}