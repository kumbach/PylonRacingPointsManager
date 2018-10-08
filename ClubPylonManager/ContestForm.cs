using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubPylonManager
{
    public partial class ContestForm : Form {
        private readonly ClubFile _clubFile;

        public ContestForm(ClubFile clubFile)
        {
            _clubFile = clubFile;
            InitializeComponent();
            PopulateComboBoxes();
            contestBindingSource.AddNew();
        }

        private void PopulateComboBoxes()
        {
            foreach (var location in _clubFile.Locations) {
                locationCombo.Items.Add(location);
            }
            foreach (var raceClass in _clubFile.RaceClasses) {
                raceClassCombo.Items.Add(raceClass);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
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
            NumericUpDown control = (NumericUpDown)sender;
            Console.WriteLine($"Pilots={control.Value}");

        }

        public Contest getContest()
        {
            return (Contest) contestBindingSource.Current;
        }
    }
}