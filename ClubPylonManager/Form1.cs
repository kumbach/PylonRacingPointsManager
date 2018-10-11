using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ClubPylonManager
{
    public partial class Form1 : Form {
        public const string AppName = "Club Pylon Manager";

        private ClubFile _clubFile;

        public Form1()
        {
            InitializeComponent();
            SetMenuState();
        }

        private void SetMenuState()
        {
            bool fileOpen = _clubFile != null;
            contestGridView.Enabled = fileOpen;

            fileNewMenuItem.Enabled = true;
            fileOpenMenuItem.Enabled = true;

            fileCloseMenuItem.Enabled = fileOpen;
            fileSaveMenuItem.Enabled = fileOpen;
            fileSaveAsMenuItem.Enabled = fileOpen;

            contestNewMenuItem.Enabled = fileOpen;

            seasonReportMenuItem.Enabled = fileOpen;
            pilotStatisticsMenuItem.Enabled = fileOpen;

            pilotRosterToolStripMenuItem.Enabled = fileOpen;
            locationsToolStripMenuItem.Enabled = fileOpen;
            raceClassesToolStripMenuItem.Enabled = fileOpen;
            settingsToolStripMenuItem.Enabled = fileOpen;

            SetEditMenuState();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _clubFile = new ClubFile();
            this.Text = $"{AppName} - Untitled.json";
            SetMenuState();
        }

        private void contestNewMenuItem_Click(object sender, EventArgs e)
        {
            if (_clubFile.ClubRoster.Count == 0)
            {
                ContestForm contestForm = new ContestForm(_clubFile, new Contest());
                var result = contestForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    contestBindingSource.Add(contestForm.GetContest());
                }

                return;
            }

            var form = new PilotSelectForm(_clubFile);
            var r = form.ShowDialog();

            if (r != DialogResult.Cancel)
            {
                ContestForm contestForm = new ContestForm(_clubFile, new Contest(form.SelectedPilots()));
                var result = contestForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    contestBindingSource.Add(contestForm.GetContest());
                }
            }
        }

        private void pilotRosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RosterForm(_clubFile);
            form.ShowDialog();
        }

        private void locationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Locations(_clubFile);
            form.ShowDialog();
        }

        private void raceClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new RaceClassesForm(_clubFile);
            form.ShowDialog();
        }

        private void fileOpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = $"{AppName} Files|*.json";
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                string json = File.ReadAllText(filename);
                _clubFile = JsonConvert.DeserializeObject<ClubFile>(json);
                _clubFile.Filename = filename;
                SetMenuState();
                contestBindingSource.DataSource = _clubFile.Contests;

                this.Text = $"{AppName} - {filename}";
            }
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            if (_clubFile.IsUnNamed()) {
                fileSaveAsMenuItem_Click(sender, e);
                return;
            }

            string json = JsonConvert.SerializeObject(_clubFile, Formatting.Indented);
            string filename = _clubFile.Filename;

            File.WriteAllText(filename, json);
        }

        private void fileSaveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = $"{AppName} Files|*.json";
            saveFileDialog1.Title = $"Save an {AppName} File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string filename = saveFileDialog1.FileName;
                _clubFile.Filename = filename;
                string json = JsonConvert.SerializeObject(_clubFile, Formatting.Indented);

                File.WriteAllText(filename, json);
                this.Text = $"{AppName} - {filename}";
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
            _clubFile = null;
            this.Text = AppName;

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
            contestReportMenuItem.Enabled = contestGridView.SelectedRows.Count > 0;
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

            ContestForm form = new ContestForm(_clubFile, contest);
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

            ContestForm form = new ContestForm(_clubFile, dupContest);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                contestBindingSource.Add(form.GetContest());
            }

        }

        private void contestReportMenuItem_Click(object sender, EventArgs e)
        {
            List<Contest> contests = new List<Contest>();
            foreach (DataGridViewRow row in contestGridView.SelectedRows)
            {
                contests.Add((Contest) contestBindingSource.List[row.Index]);
            }

            var report = new ContestSummaryReport(contests);
            var form = new ReportViewerForm(report.GenerateReport());
            form.ShowDialog();
        }
    }
}