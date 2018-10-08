using System;
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
            int newRowCount = Convert.ToInt32(((NumericUpDown) sender).Value);


            if (newRowCount < scoreboardGrid.RowCount)
            {
                scoreboardGrid.Rows.RemoveAt(3);
            }
            else if (newRowCount > scoreboardGrid.RowCount)
            {
                scoreboardGrid.Rows.Add(newRowCount - scoreboardGrid.RowCount);
            }
        }

        private void pilotsNumeric_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown control = (NumericUpDown) sender;
            Console.WriteLine($"Pilots={control.Value}");
        }

        public Contest getContest()
        {
            return (Contest) contestBindingSource.Current;
        }
    }
}