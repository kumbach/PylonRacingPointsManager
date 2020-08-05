using System;
using System.Linq;
using System.Windows.Forms;

namespace PylonRacingPointsManager {
    public partial class Locations : Form {
        private readonly ClubFile clubFile;

        public Locations(ClubFile clubFile) {
            this.clubFile = clubFile;
            InitializeComponent();

            UpdateData();
        }

        private void UpdateData() {
            foreach (var pilot in clubFile.Locations) {
                locationBindingSource.Add(pilot);
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            clubFile.Locations.Clear();
            foreach (Location location in locationBindingSource) {
                location.Name = location.Name == null ? "" : location.Name.Trim();
                if (string.IsNullOrEmpty(location.Name)) {
                    continue;
                }

                clubFile.Locations.Add(location);
            }

            clubFile.Locations = clubFile.Locations.OrderBy(o => o.Name).ToList();

            clubFile.SetDirty();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void rosterGridView_SelectionChanged(object sender, EventArgs e) {
            if (rosterGridView.SelectedCells.Count == 0) {
                RemoveLocationButton.Enabled = false;
                return;
            }

            int row = rosterGridView.SelectedCells[0].RowIndex;
            bool enabled = row < rosterGridView.RowCount - 1;
            RemoveLocationButton.Enabled = enabled;
        }

        private void RemoveLocationButton_Click(object sender, EventArgs e) {
            if (rosterGridView.SelectedCells.Count == 0) {
                return;
            }

            if (rosterGridView.Rows.Count == 1) {
                RemoveLocationButton_Click(sender, e);
                return;
            }

            int row = rosterGridView.SelectedCells[0].RowIndex;
            rosterGridView.Rows.RemoveAt(row);
        }
    }
}