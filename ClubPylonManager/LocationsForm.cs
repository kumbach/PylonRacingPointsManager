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
    public partial class Locations : Form
    {
        private readonly ClubFile _clubFile;

        public Locations(ClubFile clubFile)
        {
            _clubFile = clubFile;
            InitializeComponent();

           

            UpdateData();
        }
        private void UpdateData()
        {
            foreach (var pilot in _clubFile.Locations)
            {
                locationBindingSource.Add(pilot);
            }

        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            _clubFile.Locations.Clear();
            foreach (Location location in locationBindingSource)
            {
                _clubFile.Locations.Add(location);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
