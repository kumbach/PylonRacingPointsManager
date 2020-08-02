using System;
using System.Linq;
using System.Windows.Forms;

namespace ClubPylonManager {
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

    private void ValidateSomething(object sender, System.ComponentModel.CancelEventArgs e) {
      if (sender != rosterGridView) {
        return;
      }

      foreach (Pilot pilot in pilotBindingSource) {
        if (string.IsNullOrEmpty(pilot.Name)) {
          e.Cancel = true;
        }
      }
    }
  }
}