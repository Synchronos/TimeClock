namespace Dangerwolf.Timeclock
{
    partial class ViewTimeEntries
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
            this.timeEntriesGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.taskDataSet = new Dangerwolf.Timeclock.TaskDataSet();
            this.taskDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeEntriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeEntryIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStartedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeEndedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elapsedTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeEntriesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEntriesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timeEntriesGroupBox
            // 
            this.timeEntriesGroupBox.Controls.Add(this.dataGridView1);
            this.timeEntriesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeEntriesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.timeEntriesGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeEntriesGroupBox.Name = "timeEntriesGroupBox";
            this.timeEntriesGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeEntriesGroupBox.Size = new System.Drawing.Size(389, 327);
            this.timeEntriesGroupBox.TabIndex = 0;
            this.timeEntriesGroupBox.TabStop = false;
            this.timeEntriesGroupBox.Text = "Time Entries for {0}";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeEntryIDDataGridViewTextBoxColumn,
            this.taskIDDataGridViewTextBoxColumn,
            this.timeStartedDataGridViewTextBoxColumn,
            this.timeEndedDataGridViewTextBoxColumn,
            this.elapsedTimeDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.timeEntriesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(381, 304);
            this.dataGridView1.TabIndex = 0;
            // 
            // taskDataSet
            // 
            this.taskDataSet.DataSetName = "TaskDataSet";
            this.taskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taskDataSetBindingSource
            // 
            this.taskDataSetBindingSource.DataSource = this.taskDataSet;
            this.taskDataSetBindingSource.Position = 0;
            // 
            // timeEntriesBindingSource
            // 
            this.timeEntriesBindingSource.DataMember = "TimeEntries";
            this.timeEntriesBindingSource.DataSource = this.taskDataSetBindingSource;
            // 
            // timeEntryIDDataGridViewTextBoxColumn
            // 
            this.timeEntryIDDataGridViewTextBoxColumn.DataPropertyName = "TimeEntryID";
            this.timeEntryIDDataGridViewTextBoxColumn.HeaderText = "TimeEntryID";
            this.timeEntryIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeEntryIDDataGridViewTextBoxColumn.Name = "timeEntryIDDataGridViewTextBoxColumn";
            this.timeEntryIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeEntryIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // taskIDDataGridViewTextBoxColumn
            // 
            this.taskIDDataGridViewTextBoxColumn.DataPropertyName = "TaskID";
            this.taskIDDataGridViewTextBoxColumn.HeaderText = "TaskID";
            this.taskIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.taskIDDataGridViewTextBoxColumn.Name = "taskIDDataGridViewTextBoxColumn";
            this.taskIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.taskIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // timeStartedDataGridViewTextBoxColumn
            // 
            this.timeStartedDataGridViewTextBoxColumn.DataPropertyName = "TimeStarted";
            this.timeStartedDataGridViewTextBoxColumn.HeaderText = "TimeStarted";
            this.timeStartedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeStartedDataGridViewTextBoxColumn.Name = "timeStartedDataGridViewTextBoxColumn";
            this.timeStartedDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeStartedDataGridViewTextBoxColumn.Width = 125;
            // 
            // timeEndedDataGridViewTextBoxColumn
            // 
            this.timeEndedDataGridViewTextBoxColumn.DataPropertyName = "TimeEnded";
            this.timeEndedDataGridViewTextBoxColumn.HeaderText = "TimeEnded";
            this.timeEndedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.timeEndedDataGridViewTextBoxColumn.Name = "timeEndedDataGridViewTextBoxColumn";
            this.timeEndedDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeEndedDataGridViewTextBoxColumn.Width = 125;
            // 
            // elapsedTimeDataGridViewTextBoxColumn
            // 
            this.elapsedTimeDataGridViewTextBoxColumn.DataPropertyName = "ElapsedTime";
            this.elapsedTimeDataGridViewTextBoxColumn.HeaderText = "ElapsedTime";
            this.elapsedTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.elapsedTimeDataGridViewTextBoxColumn.Name = "elapsedTimeDataGridViewTextBoxColumn";
            this.elapsedTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.elapsedTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            this.notesDataGridViewTextBoxColumn.Width = 125;
            // 
            // ViewTimeEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(389, 327);
            this.Controls.Add(this.timeEntriesGroupBox);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ViewTimeEntries";
            this.Text = "View Time Entries";
            this.timeEntriesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEntriesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox timeEntriesGroupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeEntryIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStartedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeEndedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elapsedTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource timeEntriesBindingSource;
        private System.Windows.Forms.BindingSource taskDataSetBindingSource;
        private TaskDataSet taskDataSet;
    }
}