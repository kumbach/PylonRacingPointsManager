using System;
using System.Windows.Forms;

namespace ClubPylonManager {
    public partial class About : Form {
        public About() {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e) {
            Text = $"About {Form1.AppName}";
            CenterToParent();
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("http://cppra.org/race-tools");
        }
    }
}