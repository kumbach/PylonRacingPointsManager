using System;
using System.Reflection;
using System.Windows.Forms;

namespace PylonRacingPointsManager {
    public partial class About : Form {
        public About() {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e) {
            Text = $"About {Form1.AppName}";
            label4.Text = $"Version {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            CenterToParent();
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("http://www.cppra.org/race-tools/points-manager");
        }
    }
}