using System;
using System.Linq;
using System.Windows.Forms;

namespace ClubPylonManager {
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
                clubFile.Locations.Add(location);
            }

            clubFile.Locations = clubFile.Locations.OrderBy(o => o.name).ToList();

            clubFile.SetDirty();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}