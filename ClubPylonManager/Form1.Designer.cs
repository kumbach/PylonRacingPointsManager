﻿
namespace ClubPylonManager
{
    partial class Form1
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileCloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seasonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilotsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilotRosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raceClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.contestSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contestDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pilotsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contestGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contestBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.contestToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.clubToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNewMenuItem,
            this.fileOpenMenuItem,
            this.toolStripSeparator1,
            this.fileCloseMenuItem,
            this.toolStripSeparator2,
            this.fileSaveMenuItem,
            this.fileSaveAsMenuItem,
            this.toolStripSeparator3,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator7,
            this.fileExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileNewMenuItem
            // 
            this.fileNewMenuItem.Name = "fileNewMenuItem";
            this.fileNewMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fileNewMenuItem.Text = "New";
            this.fileNewMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fileOpenMenuItem.Text = "Open...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // fileCloseMenuItem
            // 
            this.fileCloseMenuItem.Name = "fileCloseMenuItem";
            this.fileCloseMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fileCloseMenuItem.Text = "Close";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
            // 
            // fileSaveMenuItem
            // 
            this.fileSaveMenuItem.Name = "fileSaveMenuItem";
            this.fileSaveMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fileSaveMenuItem.Text = "Save";
            this.fileSaveMenuItem.Click += new System.EventHandler(this.fileSaveMenuItem_Click);
            // 
            // fileSaveAsMenuItem
            // 
            this.fileSaveAsMenuItem.Name = "fileSaveAsMenuItem";
            this.fileSaveAsMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fileSaveAsMenuItem.Text = "Save As...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(122, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(122, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fileExitMenuItem.Text = "Exit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contestToolStripMenuItem
            // 
            this.contestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contestNewMenuItem,
            this.editToolStripMenuItem,
            this.toolStripSeparator4,
            this.duplicateToolStripMenuItem,
            this.toolStripSeparator5,
            this.deleteToolStripMenuItem});
            this.contestToolStripMenuItem.Name = "contestToolStripMenuItem";
            this.contestToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.contestToolStripMenuItem.Text = "Contest";
            // 
            // contestNewMenuItem
            // 
            this.contestNewMenuItem.Name = "contestNewMenuItem";
            this.contestNewMenuItem.Size = new System.Drawing.Size(133, 22);
            this.contestNewMenuItem.Text = "Add...";
            this.contestNewMenuItem.Click += new System.EventHandler(this.contestNewMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.editToolStripMenuItem.Text = "Edit...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(130, 6);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(130, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteToolStripMenuItem.Text = "Delete...";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contestMenuItem,
            this.seasonMenuItem,
            this.pilotsMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // contestMenuItem
            // 
            this.contestMenuItem.Name = "contestMenuItem";
            this.contestMenuItem.Size = new System.Drawing.Size(169, 22);
            this.contestMenuItem.Text = "Contest Summary";
            // 
            // seasonMenuItem
            // 
            this.seasonMenuItem.Name = "seasonMenuItem";
            this.seasonMenuItem.Size = new System.Drawing.Size(169, 22);
            this.seasonMenuItem.Text = "Season Summary";
            // 
            // pilotsMenuItem
            // 
            this.pilotsMenuItem.Name = "pilotsMenuItem";
            this.pilotsMenuItem.Size = new System.Drawing.Size(169, 22);
            this.pilotsMenuItem.Text = "Pilot Statistics";
            // 
            // clubToolStripMenuItem
            // 
            this.clubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pilotRosterToolStripMenuItem,
            this.raceClassesToolStripMenuItem,
            this.locationsToolStripMenuItem,
            this.toolStripSeparator6,
            this.contestSettingsToolStripMenuItem});
            this.clubToolStripMenuItem.Name = "clubToolStripMenuItem";
            this.clubToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.clubToolStripMenuItem.Text = "Club";
            // 
            // pilotRosterToolStripMenuItem
            // 
            this.pilotRosterToolStripMenuItem.Name = "pilotRosterToolStripMenuItem";
            this.pilotRosterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pilotRosterToolStripMenuItem.Text = "Pilot Roster...";
            this.pilotRosterToolStripMenuItem.Click += new System.EventHandler(this.pilotRosterToolStripMenuItem_Click);
            // 
            // raceClassesToolStripMenuItem
            // 
            this.raceClassesToolStripMenuItem.Name = "raceClassesToolStripMenuItem";
            this.raceClassesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.raceClassesToolStripMenuItem.Text = "Race Classes...";
            // 
            // locationsToolStripMenuItem
            // 
            this.locationsToolStripMenuItem.Name = "locationsToolStripMenuItem";
            this.locationsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.locationsToolStripMenuItem.Text = "Locations...";
            this.locationsToolStripMenuItem.Click += new System.EventHandler(this.locationsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // contestSettingsToolStripMenuItem
            // 
            this.contestSettingsToolStripMenuItem.Name = "contestSettingsToolStripMenuItem";
            this.contestSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.contestSettingsToolStripMenuItem.Text = "Default Settings...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // contestGridView
            // 
            this.contestGridView.AllowUserToAddRows = false;
            this.contestGridView.AllowUserToDeleteRows = false;
            this.contestGridView.AllowUserToResizeColumns = false;
            this.contestGridView.AllowUserToResizeRows = false;
            this.contestGridView.AutoGenerateColumns = false;
            this.contestGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.contestGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.contestGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.contestGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contestGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contestDateDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.raceClassDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.roundsDataGridViewTextBoxColumn,
            this.pilotsDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn});
            this.contestGridView.DataSource = this.contestBindingSource;
            this.contestGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contestGridView.Location = new System.Drawing.Point(0, 24);
            this.contestGridView.MinimumSize = new System.Drawing.Size(100, 100);
            this.contestGridView.Name = "contestGridView";
            this.contestGridView.ReadOnly = true;
            this.contestGridView.RowHeadersVisible = false;
            this.contestGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contestGridView.Size = new System.Drawing.Size(800, 426);
            this.contestGridView.TabIndex = 0;
            this.contestGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GridDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // contestDateDataGridViewTextBoxColumn
            // 
            this.contestDateDataGridViewTextBoxColumn.DataPropertyName = "ContestDate";
            this.contestDateDataGridViewTextBoxColumn.HeaderText = "ContestDate";
            this.contestDateDataGridViewTextBoxColumn.Name = "contestDateDataGridViewTextBoxColumn";
            this.contestDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.contestDateDataGridViewTextBoxColumn.Width = 91;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationDataGridViewTextBoxColumn.Width = 73;
            // 
            // raceClassDataGridViewTextBoxColumn
            // 
            this.raceClassDataGridViewTextBoxColumn.DataPropertyName = "RaceClass";
            this.raceClassDataGridViewTextBoxColumn.HeaderText = "RaceClass";
            this.raceClassDataGridViewTextBoxColumn.Name = "raceClassDataGridViewTextBoxColumn";
            this.raceClassDataGridViewTextBoxColumn.ReadOnly = true;
            this.raceClassDataGridViewTextBoxColumn.Width = 83;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 62;
            // 
            // roundsDataGridViewTextBoxColumn
            // 
            this.roundsDataGridViewTextBoxColumn.DataPropertyName = "Rounds";
            this.roundsDataGridViewTextBoxColumn.HeaderText = "Rounds";
            this.roundsDataGridViewTextBoxColumn.Name = "roundsDataGridViewTextBoxColumn";
            this.roundsDataGridViewTextBoxColumn.ReadOnly = true;
            this.roundsDataGridViewTextBoxColumn.Width = 69;
            // 
            // pilotsDataGridViewTextBoxColumn
            // 
            this.pilotsDataGridViewTextBoxColumn.DataPropertyName = "Pilots";
            this.pilotsDataGridViewTextBoxColumn.HeaderText = "Pilots";
            this.pilotsDataGridViewTextBoxColumn.Name = "pilotsDataGridViewTextBoxColumn";
            this.pilotsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pilotsDataGridViewTextBoxColumn.Width = 57;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contestBindingSource
            // 
            this.contestBindingSource.DataSource = typeof(ClubPylonManager.Contest);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contestGridView);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contestGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contestBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileCloseMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridView contestGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.BindingSource contestBindingSource;
        private System.Windows.Forms.ToolStripMenuItem contestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seasonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pilotsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contestNewMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn contestDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roundsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pilotsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem clubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pilotRosterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raceClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem contestSettingsToolStripMenuItem;
    }
}

