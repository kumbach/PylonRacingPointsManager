using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace PylonRacingPointsManager {
    public partial class Form1 : Form {
        public const string AppName = "Pylon Racing Points Manager";
        public const string LastFileKey = "LastFile";
        public const string ShowInactiveInListsKey = "ShowInactiveInLists";
        public const string ShowInactiveInReportsKey = "ShowInactiveInReports";
        public const string UsePilotNumbersKey = "UsePilotNumbers";

        private ClubFile clubFile;

        public Form1() {
            InitializeComponent();
            Text = AppName;
            SetMenuState();
        }

        private void SetMenuState() {
            bool fileOpen = clubFile != null;
            contestGridView.Enabled = fileOpen;

            fileNewMenuItem.Enabled = true;
            fileOpenMenuItem.Enabled = true;

            fileCloseMenuItem.Enabled = fileOpen;
            fileSaveMenuItem.Enabled = fileOpen;
            fileSaveAsMenuItem.Enabled = fileOpen;

            ImportContestsToolStripMenuItem.Enabled = fileOpen;
            ImportPilotsToolStripMenuItem.Enabled = fileOpen;

            contestNewMenuItem.Enabled = fileOpen;

            seasonReportMenuItem.Enabled = fileOpen;
            pilotStatisticsMenuItem.Enabled = fileOpen;

            pilotRosterToolStripMenuItem.Enabled = fileOpen;
            locationsToolStripMenuItem.Enabled = fileOpen;
            raceClassesToolStripMenuItem.Enabled = fileOpen;

            SetEditMenuState();
        }


        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            if (!DirtyFileSaved("closing")) {
                e.Cancel = true;
                return;
            }

            SetClosedFileState();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!DirtyFileSaved("exiting")) {
                return;
            }

            SetClosedFileState();
            Application.Exit();
        }

        private void SetClosedFileState() {
            clubFile = null;
            this.Text = AppName;
            contestBindingSource.DataSource = null;

            SetMenuState();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!DirtyFileSaved("creating a new one")) {
                return;
            }

            clubFile = new ClubFile();
            SetOpenFileState();
            SetSetting(LastFileKey, "");
        }

        private bool DirtyFileSaved(string saveMessageSuffix) {
            if (clubFile != null && clubFile.Dirty) {
                var result = MessageBox.Show(
                    $"The current file has changed. Save it before {saveMessageSuffix}?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation
                );

                if (result == DialogResult.Yes) {
                    fileSaveMenuItem_Click(null, null);
                }
                else if (result == DialogResult.Cancel) {
                    return false;
                }
            }

            return true;
        }

        private void contestNewMenuItem_Click(object sender, EventArgs e) {
            if (clubFile.PilotRosterIsEmpty()) {
                ContestForm contestForm = new ContestForm(clubFile, new Contest());
                var result = contestForm.ShowDialog(this);
                if (result == DialogResult.OK) {
                    AddRowAndBringIntoView(contestForm.GetContest());
                }

                return;
            }

            var form = new PilotSelectForm(clubFile);
            var r = form.ShowDialog();

            if (r != DialogResult.Cancel) {
                ContestForm contestForm = new ContestForm(clubFile, new Contest(form.SelectedPilots()));
                var result = contestForm.ShowDialog(this);
                if (result == DialogResult.OK) {
                    AddRowAndBringIntoView(contestForm.GetContest());
                }
            }
        }

        private void AddRowAndBringIntoView(Contest contest) {
            contestBindingSource.Insert(0, contest);
            contestGridView.ClearSelection();
            contestGridView.Rows[0].Selected = true;
            contestGridView.FirstDisplayedScrollingRowIndex = 0;
        }

        private void pilotRosterToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new RosterForm(clubFile);
            form.ShowDialog();
        }

        private void locationsToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new Locations(clubFile);
            form.ShowDialog();
        }

        private void raceClassesToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new RaceClassesForm(clubFile);
            form.ShowDialog();
        }

        private void fileOpenMenuItem_Click(object sender, EventArgs e) {
            if (!DirtyFileSaved("opening a new one")) {
                return;
            }

            OpenFileDialog openFileDialog1 = new OpenFileDialog {
                Filter = $"{AppName} Files|*.json",
                Title = "Select a File"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                var filename = openFileDialog1.FileName;
                OpenFile(filename);

                SetSetting(LastFileKey, filename);
            }
        }

        private void OpenFile(string filename) {
            string json = File.ReadAllText(filename);
            clubFile = JsonConvert.DeserializeObject<ClubFile>(json);
            clubFile.Filename = filename;
            SetOpenFileState();
        }

        private void SetOpenFileState() {
            SetMenuState();
            contestBindingSource.DataSource = clubFile.Contests;
            var filename = string.IsNullOrEmpty(clubFile.Filename) ? "Untitled.json" : clubFile.Filename;
            Text = $"{AppName} - {filename}";
        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e) {
            if (clubFile.IsUnNamed()) {
                fileSaveAsMenuItem_Click(sender, e);
                return;
            }

            if (!clubFile.Save()) {
                MessageBox.Show(clubFile.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fileSaveAsMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog {
                Filter = $"{AppName} Files|*.json",
                Title = $"Save an {AppName} File"
            };
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "") {
                string filename = saveFileDialog1.FileName;
                clubFile.Filename = filename;
                if (clubFile.Save()) {
                    Text = $"{AppName} - {filename}";
                    SetSetting(LastFileKey, filename);
                }
                else {
                    MessageBox.Show(clubFile.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            var count = contestGridView.SelectedRows.Count;

            string title = count == 1 ? "Delete Contest" : "Delete Contests";
            string message = count == 1 ? "Delete the selected contest?" : $"Delete the {count} selected contests?";

            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                DialogResult.Yes) {
                foreach (DataGridViewRow item in this.contestGridView.SelectedRows) {
                    contestGridView.Rows.RemoveAt(item.Index);
                }
            }
        }

        private void fileCloseMenuItem_Click(object sender, EventArgs e) {
            if (!DirtyFileSaved("closing")) {
                return;
            }

            SetSetting(LastFileKey, "");
            SetClosedFileState();
        }

        private void contestEditMenuItem_Click(object sender, EventArgs e) {
            EditSelectedContest();
        }

        private void RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            SetEditMenuState();
        }

        private void SetEditMenuState() {
            contestEditMenuItem.Enabled = contestGridView.SelectedRows.Count == 1;
            contestDuplicateMenuItem.Enabled = contestGridView.SelectedRows.Count == 1;

            contestDeleteMenuItem.Enabled = contestGridView.SelectedRows.Count > 0;
            contestReportMenuItem.Enabled = contestGridView.SelectedRows.Count > 0;
        }

        private void GridDoubleClicked(object sender, EventArgs e) {
            EditSelectedContest();
        }

        private void EditSelectedContest() {
            if (contestGridView.CurrentRow == null) {
                return;
            }

            var contest = (Contest) contestGridView.SelectedRows[0].DataBoundItem;
            var index = contestGridView.CurrentRow.Index;

            ContestForm form = new ContestForm(clubFile, contest);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK) {
                contestBindingSource.RemoveAt(index);
                contestBindingSource.Insert(index, form.GetContest());
                contestGridView.ClearSelection();

                contestGridView.Rows[index].Selected = true;
            }
        }

        private void contestDuplicateMenuItem_Click(object sender, EventArgs e) {
            if (contestGridView.CurrentRow == null) {
                return;
            }

            var contest = (Contest) contestGridView.SelectedRows[0].DataBoundItem;

            string json = JsonConvert.SerializeObject(contest);
            var dupContest = JsonConvert.DeserializeObject<Contest>(json);

            ContestForm form = new ContestForm(clubFile, dupContest);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK) {
                AddRowAndBringIntoView(form.GetContest());
            }
        }

        private void contestReportMenuItem_Click(object sender, EventArgs e) {
            List<Contest> contests = new List<Contest>();
            foreach (DataGridViewRow row in contestGridView.SelectedRows) {
                contests.Add((Contest) contestBindingSource.List[row.Index]);
            }

            var report = new ContestSummaryReport(contests);
            var form = new ReportViewerForm("Contest Summary", report.GenerateReport());
            form.ShowDialog();
        }

        private void seasonReportMenuItem_Click(object sender, EventArgs e) {
            if (contestGridView.SelectedRows.Count <= 1) {
                MessageBox.Show(
                    "Tip: You have only highlighted a single contest. If there are more contests in the season, highlight them too before creating the report.",
                    "Tip",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            List<Contest> contests = new List<Contest>();

            foreach (DataGridViewRow row in contestGridView.SelectedRows) {
                var contest = (Contest) contestBindingSource.List[row.Index];
                if (contest.IsValid()) {
                    contests.Add(contest);
                }
            }

            var report = new SeasonSummaryReport(contests, clubFile);
            var form = new ReportViewerForm("Season Summary", report.GenerateReport());
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e) {
            var lastFile = GetSetting(LastFileKey);
            if (!string.IsNullOrEmpty(lastFile) && File.Exists(lastFile)) {
                OpenFile(lastFile);
            }
            else {
                newToolStripMenuItem_Click(null, null);
            }

            InactiveMembersInLists.Checked = GetSetting(Form1.ShowInactiveInListsKey).Equals("True");
            includeUnpaidMembersInReportsToolStripMenuItem1.Checked = GetSetting(Form1.ShowInactiveInReportsKey).Equals("True");
            UsePilotNumbersToolStripMenuItem.Checked = GetSetting(Form1.UsePilotNumbersKey).Equals("True");
        }

        public static string GetSetting(string settingName) {
            var key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{AppName}");
            var value = key.GetValue($"{settingName}");

            return value == null ? "" : value.ToString();
        }

        public static void SetSetting(string settingName, string value) {
            var key = Registry.CurrentUser.CreateSubKey($@"SOFTWARE\{AppName}");
            key.SetValue(settingName, value);
        }

        private void pilotStatisticsMenuItem_Click(object sender, EventArgs e) {
            List<Contest> contests = new List<Contest>();

            foreach (DataGridViewRow row in contestGridView.Rows) {
                var contest = (Contest) contestBindingSource.List[row.Index];
                if (contest.IsValid()) {
                    contests.Add(contest);
                }
            }

            var report = new SeasonSummaryReport(contests, clubFile);
            var form = new ReportViewerForm("Historical Pilot Summary", report.GenerateReport());
            form.ShowDialog();
        }

        private void includeUnpaidMembersInReportsToolStripMenuItem1_Click(object sender, EventArgs e) {
            includeUnpaidMembersInReportsToolStripMenuItem1.Checked ^= true;
            SetSetting(Form1.ShowInactiveInReportsKey, includeUnpaidMembersInReportsToolStripMenuItem1.Checked.ToString());
        }

        private void showUnpaidMembersInListsToolStripMenuItem_Click(object sender, EventArgs e) {
            InactiveMembersInLists.Checked ^= true;
            SetSetting(Form1.ShowInactiveInListsKey, InactiveMembersInLists.Checked.ToString());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            new About().ShowDialog();
        }

        private void UsePilotNumbersToolStripMenuItem_Click(object sender, EventArgs e) {
            UsePilotNumbersToolStripMenuItem.Checked ^= true;
            SetSetting(Form1.UsePilotNumbersKey, UsePilotNumbersToolStripMenuItem.Checked.ToString());
        }

        private void pilotsToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog {
                Filter = $"CSV Files|*.csv",
                Title = "Select Pilots File"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                var filename = openFileDialog1.FileName;
                var importer = new PilotImporter();
                var pilots = importer.Import(filename);
                var count = clubFile.AddMissingPilots(pilots);
                if (count > 0) {
                    clubFile.SetDirty();
                }
                var result = count == 0 ? "No pilots were" : count == 1 ? "1 pilot was" : $"{count} pilots were";
                MessageBox.Show($"{result} imported.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ImportContestsToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog {
                Filter = $"CSV Files|*.csv",
                Title = "Select Contests File"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                var filename = openFileDialog1.FileName;
                try {
                    var importer = new ContestImporter();
                    var contests = importer.Import(filename, clubFile);
                    if (contests.Count > 0) {
                        clubFile.Contests.AddRange(contests);
                        clubFile.Contests = clubFile.Contests.OrderByDescending(o => o.ContestDate).ToList();
                        clubFile.Contests.ForEach(contest => {
                            clubFile.AddMissingLocation(contest.Location);
                            clubFile.AddMissingRaceClass(contest.RaceClass);
                            clubFile.AddMissingPilotsInContest(contest);
                        });
                        clubFile.SortAll();
                        clubFile.SetDirty();
                        contestBindingSource.DataSource = clubFile.Contests;
                    }

                    var result = contests.Count == 0 ? "No contests were" :
                        contests.Count == 1 ? "1 contest was" : $"{contests.Count} contests were";
                    MessageBox.Show($"{result} imported.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ee) {
                    MessageBox.Show($"The import failed.\n\n{ee.Message}", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}