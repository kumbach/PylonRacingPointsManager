﻿using System;
using System.Windows.Forms;

namespace ClubPylonManager
{
    public partial class ReportViewerForm : Form
    {
        public ReportViewerForm()
        {InitializeComponent();
        }

        public ReportViewerForm(string title, string content) : this()
        {
            Text = title;
            textBox1.Text = content;
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
