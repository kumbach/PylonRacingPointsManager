using System;
using System.Linq;
using System.Windows.Forms;

namespace ClubPylonManager {
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
                clubFile.RaceClasses.Add(raceClass);
            }

            clubFile.RaceClasses = clubFile.RaceClasses.OrderBy(o => o.Name).ToList();

            clubFile.SetDirty();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}