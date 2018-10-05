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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            contestBindingSource.Add(new Contest("2018", "Edm", "Q40", "Open", "8", "13", "Hello!"));
            contestBindingSource.Add(new Contest("2018", "Calg", "Q50", "Open", "5", "11", "Hello2!"));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            ContestForm form = new ContestForm();
            form.ShowDialog(this);
        }

        private void GridDoubleClick(object sender, MouseEventArgs e)
        {
            ContestForm form = new ContestForm();
            form.ShowDialog(this);

        }
    }
}
