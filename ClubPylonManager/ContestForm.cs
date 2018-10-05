﻿using System;
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

        private void scoreboardGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}