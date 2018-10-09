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
            SetEditMenuState();

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


        private void contestNewMenuItem_Click(object sender, EventArgs e)
        {
            ContestForm form = new ContestForm(clubFile, new Contest());
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                contestBindingSource.Add(form.GetContest());
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
            var count = contestGridView.SelectedRows.Count;

            string title = count == 1 ? "Delete Contest" : "Delete Contests";
            string message = count == 1 ? "Delete the selected contest?" : $"Delete the {count} selected contests?";

            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.contestGridView.SelectedRows)
                {
                    contestGridView.Rows.RemoveAt(item.Index);
                }
            }
        }

        private void fileCloseMenuItem_Click(object sender, EventArgs e)
        {
            clubFile = null;
            contestBindingSource.DataSource = null;
            SetMenuState();
        }

        private void contestEditMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedContest();
        }

        private void RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            SetEditMenuState();
        }

        private void SetEditMenuState()
        {
            contestEditMenuItem.Enabled = contestGridView.SelectedRows.Count == 1;
            contestDuplicateMenuItem.Enabled = contestGridView.SelectedRows.Count == 1;

            contestDeleteMenuItem.Enabled = contestGridView.SelectedRows.Count > 0;
        }

        private void GridDoubleClicked(object sender, EventArgs e)
        {
            EditSelectedContest();
        }

        private void EditSelectedContest()
        {
            if (contestGridView.CurrentRow == null)
            {
                return;
            }

            var contest = (Contest) contestGridView.SelectedRows[0].DataBoundItem;
            var index = contestGridView.CurrentRow.Index;

            ContestForm form = new ContestForm(clubFile, contest);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                contestBindingSource.RemoveAt(index);
                contestBindingSource.Insert(index, form.GetContest());
                contestGridView.ClearSelection();

                contestGridView.Rows[index].Selected = true;
            }
        }

        private void contestDuplicateMenuItem_Click(object sender, EventArgs e)
        {
            if (contestGridView.CurrentRow == null)
            {
                return;
            }

            var contest = (Contest)contestGridView.SelectedRows[0].DataBoundItem;

            string json = JsonConvert.SerializeObject(contest);
            var dupContest = JsonConvert.DeserializeObject<Contest>(json);

            ContestForm form = new ContestForm(clubFile, dupContest);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                contestBindingSource.Add(form.GetContest());
            }

        }
    }
}