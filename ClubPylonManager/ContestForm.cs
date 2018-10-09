using System;
using System.Configuration;
using System.Windows.Forms;

namespace ClubPylonManager
{
    public partial class ContestForm : Form
    {
        private readonly ClubFile _clubFile;

        public ContestForm(ClubFile clubFile, Contest contest)
        {
            _clubFile = clubFile;
            InitializeComponent();

            PopulateComboBoxes();
            if (contest == null)
            {
                contestBindingSource.AddNew();
            }
            else
            {
                contestBindingSource.Add(contest.Clone());
            }

            SetupScoreboardColumns();
            PopulateScoreboard();
        }

        private void SetupScoreboardColumns()
        {
            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[GetContest().Rounds];
            for (int i = 1; i <= GetContest().Rounds; ++i)
            {
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

        private void PopulateComboBoxes()
        {
            locationCombo.DataSource = _clubFile.Locations;
            raceClassCombo.DataSource = _clubFile.RaceClasses;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var contest = GetContest();
            contest.Scoreboard.Clear();
            for (int i = 0; i < scoreboardGrid.RowCount; ++i)
            {
                if (RowIsBlank(i))
                {
                    continue;
                }
                var scoreboard = new Scoreboard();
                int.TryParse((string) scoreboardGrid.Rows[i].Cells[0].Value, out var placeValue);
                scoreboard.Place = placeValue;
                scoreboard.Pilot = (string)scoreboardGrid.Rows[i].Cells[1].Value;
                for (int cell = 2; cell < scoreboardGrid.ColumnCount; ++cell)
                {
                    scoreboard.HeatTimes.Add((string)scoreboardGrid.Rows[i].Cells[cell].Value);
                }
                contest.Scoreboard.Add(scoreboard);

            }
            DialogResult = DialogResult.OK;
            _clubFile.SetDirty();
            this.Close();
        }

        private bool RowIsBlank(int row)
        {
            for (int i = 0; i < scoreboardGrid.ColumnCount; ++i)
            {
                if (!string.IsNullOrEmpty((string) scoreboardGrid.Rows[row].Cells[i].Value))
                {
                    return false;
                }
            }

            return true;
        }

        private void roundsNumeric_ValueChanged(object sender, EventArgs e)
        {
            var control = (NumericUpDown) sender;
            var diff = scoreboardGrid.Columns.Count - 2 - control.Value;
            if (diff < 0)
            {
                for (int i = scoreboardGrid.ColumnCount - 2 + 1; i <= control.Value; ++i)
                {
                    var column = new DataGridViewTextBoxColumn();
                    column.HeaderText = $"Round {i}";
                    column.MaxInputLength = 7;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    column.Width = 70;
                    column.MinimumWidth = 70;

                    scoreboardGrid.Columns.Add(column);
                }
            }
            else
            {
                while (scoreboardGrid.ColumnCount - 2 > control.Value)
                {
                    scoreboardGrid.Columns.RemoveAt(scoreboardGrid.ColumnCount - 1);
                }

            }
        }

        private void PopulateScoreboard()
        {
            int row = 0;
            var scoreboardRows = GetContest().Scoreboard;
            if (scoreboardRows.Count == 0) {
                return;
            }

            scoreboardGrid.Rows.Add(scoreboardRows.Count);
            foreach (var scoreboard in scoreboardRows)
            {
                scoreboardGrid.Rows[row].Cells[0].Value = "" + scoreboard.Place;
                scoreboardGrid.Rows[row].Cells[1].Value = scoreboard.Pilot;

                for (int round = 0; round < GetContest().Rounds; ++round)
                {
                    scoreboardGrid.Rows[row].Cells[round + 2].Value = scoreboard.HeatTimes[round];
                }

                ++row;
            }

        }

        public Contest GetContest()
        {
            return (Contest) contestBindingSource.Current;
        }

        private void contestBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}