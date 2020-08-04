using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PylonRacingPointsManager {
    public partial class PilotSelectForm : Form {
        private bool selectAllStatus = true;

        public PilotSelectForm(ClubFile clubFile) {
            InitializeComponent();
            UpdateData(clubFile);
        }

        private void UpdateData(ClubFile clubFile) {
            foreach (var pilot in clubFile.ClubRoster) {
                if (Form1.GetSetting(Form1.ShowInactiveInListsKey).Equals("True") || pilot.Active) {
                    pilotSelectionBindingSource.Add(new PilotSelection(pilot.Name));
                }
            }
        }

        private void selectButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void SkipButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Ignore;
            this.Close();
        }

        public List<string> SelectedPilots() {
            List<string> pilots = new List<string>();
            if (DialogResult == DialogResult.OK) {
                foreach (PilotSelection row in pilotSelectionBindingSource) {
                    if (row.Selected) {
                        pilots.Add(row.Pilot);
                    }
                }
            }

            return pilots;
        }

        private void selectAllButton_Click(object sender, EventArgs e) {
            foreach (PilotSelection row in pilotSelectionBindingSource) {
                row.Selected = selectAllStatus;
            }

            rosterGridView.Refresh();
            selectAllStatus ^= true;
        }
    }
}