using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClubPylonManager {
    public partial class ContestForm : Form {
        private readonly ClubFile clubFile;
        private readonly string[] heatCodes = {"NT", "DC", "DNS", "DNF", "MA", "CRA"};
        private readonly Regex regex = new Regex("^[0-2]:[0-5][0-9]\\.[0-9][0-9]$");
        private bool Dirty { get; set; }

        public ContestForm(ClubFile clubFile, Contest contest) {
            this.clubFile = clubFile;
            InitializeComponent();

            PopulateComboBoxes();
            if (contest == null) {
                contestBindingSource.AddNew();
            }
            else {
                contestBindingSource.Add(contest.Clone());
            }

            SetupScoreboardColumns();
            PopulateScoreboard();
        }

        public Contest GetContest() {
            return (Contest) contestBindingSource.Current;
        }

        private void SetupScoreboardColumns() {
            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[GetContest().Rounds];
            for (int i = 1; i <= GetContest().Rounds; ++i) {
                var column = new DataGridViewTextBoxColumn {
                    HeaderText = $"Round {i}",
                    MaxInputLength = 7,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    Width = 70,
                    MinimumWidth = 70
                };

                columns[i - 1] = column;
            }

            scoreboardGrid.Columns.AddRange(columns);
        }

        public AutoCompleteStringCollection LoadPilotAutoComplete() {
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            foreach (Pilot pilot in clubFile.ClubRoster) {
                if (clubFile.InactiveMembersInLists || pilot.MembershipPaid) {
                    str.Add(pilot.Name);
                }
            }

            return str;
        }

        public AutoCompleteStringCollection LoadHeatCodeAutoComplete() {
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();

            str.Add("NT");
            str.Add("DC");
            str.Add("DNS");
            str.Add("DNF");
            str.Add("MA");
            str.Add("CRA");
            return str;
        }

        private void PopulateComboBoxes() {
            locationCombo.DataSource = clubFile.Locations;
            raceClassCombo.DataSource = clubFile.RaceClasses;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool DiscardChanges() {
            if (!Dirty) {
                return true;
            }

            var result = MessageBox.Show(
                $"Discard the changes made to this contest?",
                "Unsaved Changes",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
            );

            return result == DialogResult.Yes;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            var contest = GetContest();
            contest.ContestDate = contest.ContestDate.Date; // strip off time
            ClearValidationErrors();

            if (ValidateScoreboard()) {
                contest.Status = "Valid";
            }
            else {
                contest.Status = "Incomplete";
                var result = MessageBox.Show("The scoreboard is incomplete or has entry errors. \n\n" +
                                             "You can still save it but it won't be included in any reports.\n\n" +
                                             "Save it?", Form1.AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes) {
                    contest.Status = "Incomplete";
                }
                else if (result == DialogResult.Cancel) {
                    return;
                }
                else {
                    return;
                }
            }

            contest.Scoreboard.Clear();
            contest.Pilots = scoreboardGrid.RowCount - 1;
            for (int i = 0; i < scoreboardGrid.RowCount; ++i) {
                if (RowIsBlank(i)) {
                    continue;
                }

                var scoreboard = new Scoreboard();
                int.TryParse((string) scoreboardGrid.Rows[i].Cells[0].Value, out var placeValue);
                scoreboard.Place = placeValue.ToString();
                scoreboard.Pilot = (string) scoreboardGrid.Rows[i].Cells[1].Value;
                for (int cell = 2; cell < scoreboardGrid.ColumnCount; ++cell) {
                    scoreboard.HeatTimes.Add(((string) scoreboardGrid.Rows[i].Cells[cell].Value ?? "").Trim()
                        .ToUpper());
                }

                contest.Scoreboard.Add(scoreboard);
            }

            DialogResult = DialogResult.OK;
            clubFile.SetDirty();
            this.Close();
        }

        private bool ValidateScoreboard() {
            List<CellValidationDetail> errors = new List<CellValidationDetail>();
            ValidatePlace(errors);
            ValidatePilots(errors);
            ValidateHeats(errors);
            ShowValidationErrors(errors);
            return errors.Count == 0;
        }

        private void ValidateHeats(List<CellValidationDetail> errors) {
            for (int row = 0; row < scoreboardGrid.RowCount; ++row) {
                if (RowIsBlank(row)) {
                    continue;
                }

                for (var col = 2; col < scoreboardGrid.ColumnCount; ++col) {
                    string cellValue = (string) scoreboardGrid.Rows[row].Cells[col].Value ?? "";
                    cellValue = cellValue.Trim().ToUpper();

                    if (cellValue.Length == 0) {
                        errors.Add(new CellValidationDetail(row, col, "Heat time is required"));
                        continue;
                    }

                    if (regex.Match(cellValue).Success) {
                        continue;
                    }

                    if (heatCodes.Contains(cellValue)) {
                        continue;
                    }

                    errors.Add(
                        new CellValidationDetail(row, col, "Heat time or code is invalid.\nRefer to Heat Entry tip below."));
                }
            }
        }

        private void ValidatePlace(List<CellValidationDetail> errors) {
            Dictionary<string, List<int>> placeToCountMap = new Dictionary<string, List<int>>();
            int rows = scoreboardGrid.RowCount;

            for (int row = 0; row < rows; ++row) {
                if (RowIsBlank(row)) {
                    continue;
                }

                int.TryParse((string) scoreboardGrid.Rows[row].Cells[0].Value, out var place);
                if (place < 1 || place > scoreboardGrid.RowCount - 1) {
                    errors.Add(new CellValidationDetail(row, 0,
                        $"Place must be between 1 and {scoreboardGrid.RowCount - 1}"));
                    continue;
                }

                string key = (string) scoreboardGrid.Rows[row].Cells[0].Value ?? "";
                key = key.Trim().ToLower();
                if (placeToCountMap.ContainsKey(key)) {
                    var rowList = placeToCountMap[key];
                    rowList.Add(row);
                }
                else {
                    var rowList = new List<int> {row};
                    placeToCountMap.Add(key, rowList);
                }
            }

            foreach (var key in placeToCountMap.Keys) {
                var rowList = placeToCountMap[key];
                foreach (var row in rowList) {
                    if (rowList.Count > 1) {
                        errors.Add(new CellValidationDetail(row, 0, "Duplicate place"));
                    }
                }
            }
        }

        private void ValidatePilots(List<CellValidationDetail> errors) {
            Dictionary<string, List<int>> pilotToCountMap = new Dictionary<string, List<int>>();
            for (int row = 0; row < scoreboardGrid.RowCount; ++row) {
                if (RowIsBlank(row)) {
                    continue;
                }

                string name = (string) scoreboardGrid.Rows[row].Cells[1].Value ?? "";
                name = name.Trim().ToLower();

                if (pilotToCountMap.ContainsKey(name)) {
                    var rowList = pilotToCountMap[name];
                    rowList.Add(row);
                }
                else {
                    var rowList = new List<int> {row};
                    pilotToCountMap.Add(name, rowList);
                }
            }

            foreach (var key in pilotToCountMap.Keys) {
                var rowList = pilotToCountMap[key];
                foreach (var row in rowList) {
                    if (key.Length == 0) {
                        errors.Add(new CellValidationDetail(row, 1, "Pilot name is required"));
                    }
                    else if (rowList.Count > 1) {
                        errors.Add(new CellValidationDetail(row, 1, "Duplicate pilot entry"));
                    }
                }
            }
        }

        private bool RowIsBlank(int row) {
            for (int i = 0; i < scoreboardGrid.ColumnCount; ++i) {
                if (!string.IsNullOrEmpty((string) scoreboardGrid.Rows[row].Cells[i].Value)) {
                    return false;
                }
            }

            return true;
        }

        private void roundsNumeric_ValueChanged(object sender, EventArgs e) {
            var control = (NumericUpDown) sender;
            var diff = scoreboardGrid.Columns.Count - 2 - control.Value;
            if (diff < 0) {
                for (int i = scoreboardGrid.ColumnCount - 2 + 1; i <= control.Value; ++i) {
                    var column = new DataGridViewTextBoxColumn {
                        HeaderText = $"Round {i}",
                        MaxInputLength = 7,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                        Width = 70,
                        MinimumWidth = 70
                    };

                    scoreboardGrid.Columns.Add(column);
                }
            }
            else {
                while (scoreboardGrid.ColumnCount - 2 > control.Value) {
                    scoreboardGrid.Columns.RemoveAt(scoreboardGrid.ColumnCount - 1);
                }
            }
        }

        private void PopulateScoreboard() {
            int row = 0;
            var scoreboardRows = GetContest().Scoreboard;
            if (scoreboardRows.Count == 0) {
                return;
            }

            scoreboardGrid.Rows.Add(scoreboardRows.Count);
            foreach (var scoreboard in scoreboardRows) {
                scoreboardGrid.Rows[row].Cells[0].Value = "" + scoreboard.Place;
                scoreboardGrid.Rows[row].Cells[1].Value = scoreboard.Pilot;

                for (int round = 0; round < GetContest().Rounds; ++round) {
                    scoreboardGrid.Rows[row].Cells[round + 2].Value = scoreboard.HeatTimes[round];
                }

                ++row;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (scoreboardGrid.SelectedCells.Count == 0) {
                return;
            }

            int row = scoreboardGrid.SelectedCells[0].RowIndex;
            for (int i = 0; i < scoreboardGrid.ColumnCount; ++i) {
                scoreboardGrid.Rows[row].Cells[i].Value = "";
                scoreboardGrid.Rows[row].Cells[i].Style.BackColor = Color.White;
                scoreboardGrid.Rows[row].Cells[i].ToolTipText = "";
            }
        }

        private void SelectionChanged(object sender, EventArgs e) {
            if (scoreboardGrid.SelectedCells.Count == 0) {
                clearRowButton.Enabled = false;
                deleteRowButton.Enabled = false;
                return;
            }

            int row = scoreboardGrid.SelectedCells[0].RowIndex;
            bool enabled = row < scoreboardGrid.RowCount - 1;
            clearRowButton.Enabled = enabled;
            deleteRowButton.Enabled = enabled;
        }

        private void deleteRowButton_Click(object sender, EventArgs e) {
            if (scoreboardGrid.SelectedCells.Count == 0) {
                return;
            }

            else if (scoreboardGrid.Rows.Count == 1) {
                button1_Click(sender, e);
                return;
            }

            int row = scoreboardGrid.SelectedCells[0].RowIndex;
            scoreboardGrid.Rows.RemoveAt(row);
        }

        private void ClearValidationErrors() {
            for (int row = 0; row < scoreboardGrid.RowCount; ++row) {
                for (int col = 0; col < scoreboardGrid.ColumnCount; ++col) {
                    scoreboardGrid.Rows[row].Cells[col].Style.BackColor = Color.White;
                    scoreboardGrid.Rows[row].Cells[col].ToolTipText = "";
                }
            }
        }

        private void ShowValidationErrors(List<CellValidationDetail> errors) {
            foreach (CellValidationDetail detail in errors) {
                scoreboardGrid.Rows[detail.Row].Cells[detail.Col].Style.BackColor = Color.Salmon;
                scoreboardGrid.Rows[detail.Row].Cells[detail.Col].ToolTipText = detail.message;
            }
        }

        private void SortCompare(object sender, DataGridViewSortCompareEventArgs e) {
            //Suppose your interested column has index 1
            if (e.Column.Index == 0) {
                int left = 0;
                if (e.CellValue1 != null) {
                    int.TryParse(e.CellValue1.ToString() ?? "0", out left);
                }

                int right = 0;
                if (e.CellValue2 != null) {
                    int.TryParse(e.CellValue2.ToString() ?? "0", out right);
                }

                e.SortResult = left.CompareTo(right);
                e.Handled = true; //pass by the default sorting
            }
        }

        private void scoreboardGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            int column = scoreboardGrid.CurrentCell.ColumnIndex;
            string headerText = scoreboardGrid.Columns[column].HeaderText;

            if (headerText.Equals("Pilot")) {
                TextBox tb = e.Control as TextBox;
                if (tb != null) {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = LoadPilotAutoComplete();
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (headerText.StartsWith("Round")) {
                TextBox tb = e.Control as TextBox;
                if (tb != null) {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = LoadHeatCodeAutoComplete();
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }

        private void ValidateButton_Click(object sender, EventArgs e) {
            var contest = GetContest();
            contest.ContestDate = contest.ContestDate.Date; // strip off time
            ClearValidationErrors();
            scoreboardGrid.ClearSelection();

            if (ValidateScoreboard()) {
                MessageBox.Show(
                    "The scoreboard looks okay.", "Scoreboard Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else {
                MessageBox.Show(
                    "Scoreboard errors detected.\n\nHover the mouse over the highlighted fields for more details.",
                    "Scoreboard Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            e.Cancel = !DiscardChanges();
        }

        private void scoreboardGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            Dirty = true;
        }
    }
}