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
                contestBindingSource.DataSource = contest;
            }

            SetupScoreboardColumns();
        }

        private void SetupScoreboardColumns()
        {
            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[getContest().Rounds];
            for (int i = 1; i <= getContest().Rounds; ++i)
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
            DialogResult = DialogResult.OK;
            this.Close();
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


        public Contest getContest()
        {
            return (Contest) contestBindingSource.Current;
        }
    }
}