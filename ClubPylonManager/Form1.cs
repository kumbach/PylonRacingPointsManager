using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ClubPylonManager
{
    public partial class Form1 : Form {
        private ClubFile clubFile;

        public Form1()
        {
            InitializeComponent();
            SetMenuState();
        }

        private void SetMenuState() {
            bool fileOpen = clubFile != null;
            contestGridView.Enabled = fileOpen;

            fileNewMenuItem.Enabled = !fileOpen;
            fileOpenMenuItem.Enabled = !fileOpen;
            fileCloseMenuItem.Enabled = fileOpen;
            fileSaveMenuItem.Enabled = fileOpen;
            fileSaveAsMenuItem.Enabled = fileOpen;

            copyMenuItem.Enabled = fileOpen;
            pasteMenuItem.Enabled = fileOpen;
            deleteMenuItem.Enabled = fileOpen;

            contestNewMenuItem.Enabled = fileOpen;

            contestMenuItem.Enabled = fileOpen;
            seasonMenuItem.Enabled = fileOpen;
            pilotsMenuItem.Enabled = fileOpen;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            clubFile = new ClubFile();
            SetMenuState();
        }

        private void GridDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void fileSaveMenuItem_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(clubFile, Formatting.Indented);
            Console.WriteLine(json);
        }

        private void contestNewMenuItem_Click(object sender, EventArgs e) {
            Contest contest = clubFile.NewContest();

            ContestForm form = new ContestForm(contest);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK) {
                clubFile.AddContest(contest);
                contestBindingSource.Add(contest);
                Console.WriteLine($"Result={result}");
            }

        }
    }
}
