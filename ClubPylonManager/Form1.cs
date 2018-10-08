using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ClubPylonManager
{
    public partial class Form1 : Form {
        private ClubFile clubFile;

        public Form1()
        {
            InitializeComponent();
            clubFile = new ClubFile();
            SetMenuState();
        }

        private void SetMenuState() {
            bool fileOpen = clubFile != null;
            contestGridView.Enabled = fileOpen;

            fileNewMenuItem.Enabled = !fileOpen;
            fileOpenMenuItem.Enabled = !fileOpen;
            fileCloseMenuItem.Enabled = fileOpen;
            fileSaveMenuItem.Enabled = fileOpen;
            fileSaveAsMenuItem.Enabled = fileOpen;

            contestNewMenuItem.Enabled = fileOpen;

            pilotRosterToolStripMenuItem.Enabled = fileOpen;
            locationsToolStripMenuItem.Enabled = fileOpen;
            raceClassesToolStripMenuItem.Enabled = fileOpen;
            settingsToolStripMenuItem.Enabled = fileOpen;

            contestMenuItem.Enabled = fileOpen;
            seasonMenuItem.Enabled = fileOpen;
            pilotsMenuItem.Enabled = fileOpen;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            clubFile = new ClubFile();
            SetMenuState();
        }

        private void GridDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(clubFile, Formatting.Indented);
            Console.WriteLine(json);
        }

        private void contestNewMenuItem_Click(object sender, EventArgs e)
        {
            ContestForm form = new ContestForm(clubFile);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                clubFile.AddContest(form.getContest());
                contestBindingSource.Add(form.getContest());
            }

        }

        private void pilotRosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RosterForm(clubFile);
            form.ShowDialog();
        }

        private void locationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Locations(clubFile);
            form.ShowDialog();
        }
    }
}
