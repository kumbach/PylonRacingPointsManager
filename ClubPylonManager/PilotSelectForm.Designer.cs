namespace PylonRacingPointsManager
{
    partial class PilotSelectForm
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
            this.pilotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pilotSelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.rosterGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pilotSelectionBindingSource)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 567);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // rosterGridView
            // 
            this.rosterGridView.AutoGenerateColumns = false;
            this.rosterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rosterGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.pilotDataGridViewTextBoxColumn, this.selectedDataGridViewCheckBoxColumn});
            this.rosterGridView.DataSource = this.pilotSelectionBindingSource;
            this.rosterGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rosterGridView.Location = new System.Drawing.Point(4, 4);
            this.rosterGridView.Margin = new System.Windows.Forms.Padding(4);
            this.rosterGridView.MultiSelect = false;
            this.rosterGridView.Name = "rosterGridView";
            this.rosterGridView.RowHeadersVisible = false;
            this.rosterGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.rosterGridView.Size = new System.Drawing.Size(504, 515);
            this.rosterGridView.TabIndex = 0;
            // 
            // pilotDataGridViewTextBoxColumn
            // 
            this.pilotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pilotDataGridViewTextBoxColumn.DataPropertyName = "Pilot";
            this.pilotDataGridViewTextBoxColumn.HeaderText = "Pilot";
            this.pilotDataGridViewTextBoxColumn.Name = "pilotDataGridViewTextBoxColumn";
            this.pilotDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // selectedDataGridViewCheckBoxColumn
            // 
            this.selectedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.selectedDataGridViewCheckBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewCheckBoxColumn.HeaderText = "In Contest";
            this.selectedDataGridViewCheckBoxColumn.Name = "selectedDataGridViewCheckBoxColumn";
            this.selectedDataGridViewCheckBoxColumn.Width = 90;
            // 
            // pilotSelectionBindingSource
            // 
            this.pilotSelectionBindingSource.DataSource = typeof(PilotSelection);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.selectAllButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.selectButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 527);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 36);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Skip";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(380, 4);
            this.selectAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(100, 28);
            this.selectAllButton.TabIndex = 2;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(229, 2);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(12, 4);
            this.selectButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(100, 28);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "OK";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // PilotSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 567);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PilotSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Pilots in Contest";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.rosterGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pilotSelectionBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pilotDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pilotSelectionBindingSource;
        private System.Windows.Forms.DataGridView rosterGridView;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}