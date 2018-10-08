using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ClubPylonManager
{
    public partial class Form1 : Form
    {
        private ClubFile clubFile;

        public Form1()
        {
            InitializeComponent();
            SetMenuState();
        }

        private void SetMenuState()
        {
            bool fileOpen = clubFile != null;
            contestGridView.Enabled = fileOpen;

            fileNewMenuItem.Enabled = true;
            fileOpenMenuItem.Enabled = true;

            fileCloseMenuItem.Enabled = fileOpen;
            fileSaveMenuItem.Enabled = fileOpen;
            fileSaveAsMenuItem.Enabled = fileOpen;

            contestNewMenuItem.Enabled = fileOpen;
            contestEditMenuItem.Enabled = fileOpen;
            contestDuplicateMenuItem.Enabled = fileOpen;
            contestDeleteMenuItem.Enabled = fileOpen;

            pilotRosterToolStripMenuItem.Enabled = fileOpen;
            locationsToolStripMenuItem.Enabled = fileOpen;
            raceClassesToolStripMenuItem.Enabled = fileOpen;
            settingsToolStripMenuItem.Enabled = fileOpen;

            contestMenuItem.Enabled = fileOpen;
            seasonMenuItem.Enabled = fileOpen;
            pilotsMenuItem.Enabled = fileOpen;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clubFile = new ClubFile();
            clubFile.Filename = @"d:\temp\2018.json";
            SetMenuState();
        }

        private void GridDoubleClick(object sender, MouseEventArgs e)
        {
        }


        private void contestNewMenuItem_Click(object sender, EventArgs e)
        {
            ContestForm form = new ContestForm(clubFile);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                contestBindingSource.Add(form.getContest());
                //clubFile.AddContest(form.getContest());
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

        private void raceClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RaceClassesForm(clubFile);
            form.ShowDialog();
        }

        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Club Pylon Manager Files|*.json";
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                string json = File.ReadAllText(filename);
                clubFile = JsonConvert.DeserializeObject<ClubFile>(json);
                clubFile.Filename = filename;
                SetMenuState();
                contestBindingSource.DataSource = clubFile.Contests;

                this.Text = "Club Pylon Manager - " + filename;
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(clubFile, Formatting.Indented);
            string filename = clubFile.Filename;

            File.WriteAllText(filename, json);
        }

        private void fileSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Club Pylon Manager Files|*.json";
            saveFileDialog1.Title = "Save an Club Pylon Manager File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string filename = saveFileDialog1.FileName;
                clubFile.Filename = filename;
                string json = JsonConvert.SerializeObject(clubFile, Formatting.Indented);

                File.WriteAllText(filename, json);
                this.Text = "Club Pylon Manager - " + filename;

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.contestGridView.SelectedRows)
            {
                contestGridView.Rows.RemoveAt(item.Index);
            }
        }

        private void fileCloseMenuItem_Click(object sender, EventArgs e)
        {
            clubFile = null;
            contestBindingSource.DataSource = null;
            SetMenuState();
        }
    }
}