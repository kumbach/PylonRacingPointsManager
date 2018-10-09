using System;
using System.Windows.Forms;

namespace ClubPylonManager
{
    public partial class RaceClassesForm : Form
    {
        private readonly ClubFile _clubFile;

        public RaceClassesForm(ClubFile clubFile)
        {
            _clubFile = clubFile;
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData()
        {
            foreach (var pilot in _clubFile.RaceClasses)
            {
                dataBindingSource.Add(pilot);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            _clubFile.RaceClasses.Clear();
            foreach (RaceClass location in dataBindingSource)
            {
                _clubFile.RaceClasses.Add(location);
            }

            _clubFile.SetDirty();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
