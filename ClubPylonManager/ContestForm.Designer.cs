namespace ClubPylonManager
{
    partial class ContestForm
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.raceClassCombo = new System.Windows.Forms.ComboBox();
            this.contestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contestDatePicker = new System.Windows.Forms.DateTimePicker();
            this.locationCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.scoreboardGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.validateButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.clearRowButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.roundsNumeric = new System.Windows.Forms.NumericUpDown();
            this.scoreboardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.contestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.scoreboardGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.roundsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.scoreboardBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.raceClassCombo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.contestDatePicker, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.locationCombo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.noteTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.scoreboardGrid, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.roundsNumeric, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1098, 569);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // raceClassCombo
            // 
            this.raceClassCombo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contestBindingSource, "RaceClass", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.raceClassCombo.DataSource = this.contestBindingSource;
            this.raceClassCombo.DisplayMember = "RaceClass";
            this.raceClassCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.raceClassCombo.FormattingEnabled = true;
            this.raceClassCombo.Location = new System.Drawing.Point(453, 29);
            this.raceClassCombo.Name = "raceClassCombo";
            this.raceClassCombo.Size = new System.Drawing.Size(168, 24);
            this.raceClassCombo.TabIndex = 7;
            this.raceClassCombo.ValueMember = "RaceClass";
            // 
            // contestBindingSource
            // 
            this.contestBindingSource.AllowNew = true;
            this.contestBindingSource.DataSource = typeof(ClubPylonManager.Contest);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Race Class";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location";
            // 
            // contestDatePicker
            // 
            this.contestDatePicker.CausesValidation = false;
            this.contestDatePicker.CustomFormat = "yyyy-MMM-dd";
            this.contestDatePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contestBindingSource, "ContestDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.contestDatePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contestDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.contestDatePicker.Location = new System.Drawing.Point(13, 29);
            this.contestDatePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.contestDatePicker.MinDate = new System.DateTime(1965, 1, 1, 0, 0, 0, 0);
            this.contestDatePicker.Name = "contestDatePicker";
            this.contestDatePicker.Size = new System.Drawing.Size(140, 22);
            this.contestDatePicker.TabIndex = 5;
            this.contestDatePicker.Value = new System.DateTime(2028, 1, 1, 0, 0, 0, 0);
            // 
            // locationCombo
            // 
            this.locationCombo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contestBindingSource, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.locationCombo.DataSource = this.contestBindingSource;
            this.locationCombo.DisplayMember = "Location";
            this.locationCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locationCombo.FormattingEnabled = true;
            this.locationCombo.Location = new System.Drawing.Point(159, 29);
            this.locationCombo.MaxLength = 40;
            this.locationCombo.Name = "locationCombo";
            this.locationCombo.Size = new System.Drawing.Size(288, 24);
            this.locationCombo.TabIndex = 6;
            this.locationCombo.ValueMember = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 56);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label4.Size = new System.Drawing.Size(36, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Note";
            // 
            // noteTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.noteTextBox, 5);
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contestBindingSource, "Notes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.noteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteTextBox.Location = new System.Drawing.Point(13, 85);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(1072, 22);
            this.noteTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 110);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label5.Size = new System.Drawing.Size(79, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Scoreboard";
            // 
            // scoreboardGrid
            // 
            this.scoreboardGrid.AllowUserToResizeColumns = false;
            this.scoreboardGrid.AllowUserToResizeRows = false;
            this.scoreboardGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.scoreboardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.scoreboardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scoreboardGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Column1, this.PIlot});
            this.tableLayoutPanel1.SetColumnSpan(this.scoreboardGrid, 5);
            this.scoreboardGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoreboardGrid.Location = new System.Drawing.Point(13, 139);
            this.scoreboardGrid.MultiSelect = false;
            this.scoreboardGrid.Name = "scoreboardGrid";
            this.scoreboardGrid.RowHeadersVisible = false;
            this.scoreboardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.scoreboardGrid.Size = new System.Drawing.Size(1072, 376);
            this.scoreboardGrid.TabIndex = 11;
            this.scoreboardGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.scoreboardGrid_EditingControlShowing);
            this.scoreboardGrid.SelectionChanged += new System.EventHandler(this.SelectionChanged);
            this.scoreboardGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.SortCompare);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Place";
            this.Column1.MaxInputLength = 2;
            this.Column1.MinimumWidth = 60;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 60;
            // 
            // PIlot
            // 
            this.PIlot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PIlot.HeaderText = "Pilot";
            this.PIlot.MinimumWidth = 160;
            this.PIlot.Name = "PIlot";
            this.PIlot.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 5);
            this.panel1.Controls.Add(this.validateButton);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.deleteRowButton);
            this.panel1.Controls.Add(this.clearRowButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 35);
            this.panel1.TabIndex = 12;
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(242, 2);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(99, 29);
            this.validateButton.TabIndex = 5;
            this.validateButton.Text = "Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label7.Location = new System.Drawing.Point(594, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(377, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Heat Entry: M:SS.HH, NT, DC, DNS, DNF, MA, CRA";
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.Location = new System.Drawing.Point(479, 2);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(99, 29);
            this.deleteRowButton.TabIndex = 3;
            this.deleteRowButton.Text = "Delete Row";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // clearRowButton
            // 
            this.clearRowButton.Location = new System.Drawing.Point(374, 2);
            this.clearRowButton.Name = "clearRowButton";
            this.clearRowButton.Size = new System.Drawing.Size(99, 29);
            this.clearRowButton.TabIndex = 2;
            this.clearRowButton.Text = "Clear Row";
            this.clearRowButton.UseVisualStyleBackColor = true;
            this.clearRowButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(99, 29);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(112, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(99, 29);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(627, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rounds";
            // 
            // roundsNumeric
            // 
            this.roundsNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contestBindingSource, "Rounds", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.roundsNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundsNumeric.Location = new System.Drawing.Point(627, 29);
            this.roundsNumeric.Maximum = new decimal(new int[] {20, 0, 0, 0});
            this.roundsNumeric.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.roundsNumeric.Name = "roundsNumeric";
            this.roundsNumeric.Size = new System.Drawing.Size(100, 22);
            this.roundsNumeric.TabIndex = 18;
            this.roundsNumeric.Value = new decimal(new int[] {8, 0, 0, 0});
            this.roundsNumeric.ValueChanged += new System.EventHandler(this.roundsNumeric_ValueChanged);
            // 
            // scoreboardBindingSource
            // 
            this.scoreboardBindingSource.DataMember = "Scoreboard";
            this.scoreboardBindingSource.DataSource = this.contestBindingSource;
            // 
            // ContestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(1061, 606);
            this.Name = "ContestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contest Entry";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.contestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.scoreboardGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.roundsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.scoreboardBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clearRowButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.BindingSource contestBindingSource;
        private System.Windows.Forms.DateTimePicker contestDatePicker;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox locationCombo;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIlot;
        private System.Windows.Forms.ComboBox raceClassCombo;
        private System.Windows.Forms.NumericUpDown roundsNumeric;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.BindingSource scoreboardBindingSource;
        private System.Windows.Forms.DataGridView scoreboardGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button validateButton;

        #endregion
    }
}