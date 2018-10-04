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
        public ContestForm()
        {
            InitializeComponent();
            contestBindingSource.AddNew();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine("date=" + ((Contest)contestBindingSource.Current).ContestDate);
            this.Close();
        }

    }
}