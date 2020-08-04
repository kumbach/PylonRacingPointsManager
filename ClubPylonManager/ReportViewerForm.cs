using System;
using System.Windows.Forms;

namespace PylonRacingPointsManager {
    public partial class ReportViewerForm : Form {
        public ReportViewerForm() {
            InitializeComponent();
        }

        public ReportViewerForm(string title, string content) : this() {
            Text = title;
            textBox1.Text = content;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void CopyButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(textBox1.Text)) {
                Clipboard.SetText(textBox1.Text);
            }
        }
    }
}