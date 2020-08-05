namespace PylonRacingPointsManager
{
    partial class RosterForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rosterGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pilotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membershipPaidDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pilotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteRowButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.rosterGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pilotBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rosterGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 690);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rosterGridView
            // 
            this.rosterGridView.AutoGenerateColumns = false;
            this.rosterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rosterGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Column1, this.pilotNumberDataGridViewTextBoxColumn, this.membershipPaidDataGridViewCheckBoxColumn});
            this.rosterGridView.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.pilotBindingSource, "Active", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rosterGridView.DataSource = this.pilotBindingSource;
            this.rosterGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rosterGridView.Location = new System.Drawing.Point(4, 4);
            this.rosterGridView.Margin = new System.Windows.Forms.Padding(4);
            this.rosterGridView.MultiSelect = false;
            this.rosterGridView.Name = "rosterGridView";
            this.rosterGridView.RowHeadersVisible = false;
            this.rosterGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.rosterGridView.Size = new System.Drawing.Size(637, 638);
            this.rosterGridView.TabIndex = 0;
            this.rosterGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rosterGridView_CellContentClick);
            this.rosterGridView.SelectionChanged += new System.EventHandler(this.rosterGridView_SelectionChanged);
            this.rosterGridView.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateInput);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // pilotNumberDataGridViewTextBoxColumn
            // 
            this.pilotNumberDataGridViewTextBoxColumn.DataPropertyName = "PilotNumber";
            this.pilotNumberDataGridViewTextBoxColumn.HeaderText = "Pilot #";
            this.pilotNumberDataGridViewTextBoxColumn.Name = "pilotNumberDataGridViewTextBoxColumn";
            this.pilotNumberDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // membershipPaidDataGridViewCheckBoxColumn
            // 
            this.membershipPaidDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            this.membershipPaidDataGridViewCheckBoxColumn.HeaderText = "Active";
            this.membershipPaidDataGridViewCheckBoxColumn.Name = "membershipPaidDataGridViewCheckBoxColumn";
            this.membershipPaidDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.membershipPaidDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pilotBindingSource
            // 
            this.pilotBindingSource.DataSource = typeof(PylonRacingPointsManager.Pilot);
            this.pilotBindingSource.CurrentChanged += new System.EventHandler(this.pilotBindingSource_CurrentChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.DeleteRowButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 650);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 36);
            this.panel1.TabIndex = 1;
            // 
            // DeleteRowButton
            // 
            this.DeleteRowButton.AutoSize = true;
            this.DeleteRowButton.Location = new System.Drawing.Point(268, 4);
            this.DeleteRowButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteRowButton.Name = "DeleteRowButton";
            this.DeleteRowButton.Size = new System.Drawing.Size(100, 28);
            this.DeleteRowButton.TabIndex = 2;
            this.DeleteRowButton.Text = "Remove Pilot";
            this.DeleteRowButton.UseVisualStyleBackColor = true;
            this.DeleteRowButton.Click += new System.EventHandler(this.DeleteRowButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 4);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 690);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(665, 730);
            this.Name = "RosterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pilot Roster";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.rosterGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pilotBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button DeleteRowButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn membershipPaidDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource pilotBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pilotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView rosterGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}