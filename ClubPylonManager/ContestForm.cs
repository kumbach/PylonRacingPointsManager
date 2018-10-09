using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace ClubPylonManager {
    public partial class ContestForm : Form {
        private readonly ClubFile _clubFile;

        public ContestForm(ClubFile clubFile, Contest contest) {
            _clubFile = clubFile;
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
            ValidateScoreboard();
        }

        public Contest GetContest() {
            return (Contest) contestBindingSource.Current;
        }

        private void SetupScoreboardColumns() {
            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[GetContest().Rounds];
            for (int i = 1; i <= GetContest().Rounds; ++i) {
                var column = new DataGridViewTextBoxColumn();
                column.HeaderText = $"Round {i}";
                column.MaxInputLength = 7;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.Width = 70;
                column.MinimumWidth = 70;

                columns[i - 1] = column;
            }

            scoreboardGrid.Columns.AddRange(columns);
        }

        private void PopulateComboBoxes() {
            locationCombo.DataSource = _clubFile.Locations;
            raceClassCombo.DataSource = _clubFile.RaceClasses;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e) {
            var contest = GetContest();
            ClearValidationErrors();

            if (ValidateScoreboard()) {
                contest.Status = "Valid";
            }
            else {
                contest.Status = "Incomplete";
                if (MessageBox.Show("The scoreboard is incomplete or has entry errors. \n\n" +
                                    "You can still save it but it won't be included in any reports.\n\n" +
                                    "Save it?", Form1.AppName, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) ==
                    DialogResult.Yes) {
                    contest.Status = "Incomplete";
                }
                else {
                    return;
                }
            }

            contest.Scoreboard.Clear();
            for (int i = 0; i < scoreboardGrid.RowCount; ++i) {
                if (RowIsBlank(i)) {
                    continue;
                }

                var scoreboard = new Scoreboard();
                int.TryParse((string) scoreboardGrid.Rows[i].Cells[0].Value, out var placeValue);
                scoreboard.Place = placeValue;
                scoreboard.Pilot = (string) scoreboardGrid.Rows[i].Cells[1].Value;
                for (int cell = 2; cell < scoreboardGrid.ColumnCount; ++cell) {
                    scoreboard.HeatTimes.Add((string) scoreboardGrid.Rows[i].Cells[cell].Value);
                }

                contest.Scoreboard.Add(scoreboard);
            }

            DialogResult = DialogResult.OK;
            _clubFile.SetDirty();
            this.Close();
        }

        private bool ValidateScoreboard() {
            // duplicate pilots
            // duplicate place
            // empty cells
            // score cells: #:##.##, NT, DC, DNS, DNF, MA, OUT
            List<CellValidationDetail> errors = new List<CellValidationDetail>();
            ValidatePlace(errors);
            ValidatePilots(errors);
            ShowValidationErrors(errors);
            return false;
        }

        private void ValidatePlace(List<CellValidationDetail> errors) {
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
                        errors.Add(new CellValidationDetail(row, 1, "Duplicate pilot"));
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
                    var column = new DataGridViewTextBoxColumn();
                    column.HeaderText = $"Round {i}";
                    column.MaxInputLength = 7;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column.Width = 70;
                    column.MinimumWidth = 70;

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
    }
}