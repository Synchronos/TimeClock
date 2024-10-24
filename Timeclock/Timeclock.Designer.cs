namespace Dangerwolf.Timeclock
{
    partial class Timeclock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timeclock));
            this.taskContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.associateSelectedTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAssociationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewTimeEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTimeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTimeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTimeDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpTasks = new System.Windows.Forms.GroupBox();
            this.taskDataGridView = new System.Windows.Forms.DataGridView();
            this.taskIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estimatedTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEnteredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskDataSet = new Dangerwolf.Timeclock.TaskDataSet();
            this.timeclockDataSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.timeclockDataOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timeclockTimerControl = new TimeclockControls.clockTimerControl();
            this.taskContextMenuStrip.SuspendLayout();
            this.grpTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // taskContextMenuStrip
            // 
            this.taskContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.associateSelectedTaskToolStripMenuItem,
            this.clearAssociationToolStripMenuItem,
            this.toolStripSeparator1,
            this.viewTimeEntriesToolStripMenuItem,
            this.saveTimeDataToolStripMenuItem,
            this.loadTimeDataToolStripMenuItem,
            this.clearTimeDataToolStripMenuItem});
            this.taskContextMenuStrip.Name = "menuTaskContext";
            this.taskContextMenuStrip.Size = new System.Drawing.Size(200, 142);
            // 
            // associateSelectedTaskToolStripMenuItem
            // 
            this.associateSelectedTaskToolStripMenuItem.Name = "associateSelectedTaskToolStripMenuItem";
            this.associateSelectedTaskToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.associateSelectedTaskToolStripMenuItem.Text = "Associate Selected Task";
            this.associateSelectedTaskToolStripMenuItem.Click += new System.EventHandler(this.associateSelectedTaskToolStripMenuItem_Click);
            // 
            // clearAssociationToolStripMenuItem
            // 
            this.clearAssociationToolStripMenuItem.Name = "clearAssociationToolStripMenuItem";
            this.clearAssociationToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.clearAssociationToolStripMenuItem.Text = "Clear Association";
            this.clearAssociationToolStripMenuItem.Click += new System.EventHandler(this.clearAssociationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // viewTimeEntriesToolStripMenuItem
            // 
            this.viewTimeEntriesToolStripMenuItem.Name = "viewTimeEntriesToolStripMenuItem";
            this.viewTimeEntriesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.viewTimeEntriesToolStripMenuItem.Text = "View Time Entries for Task";
            this.viewTimeEntriesToolStripMenuItem.Click += new System.EventHandler(this.viewTimeEntriesToolStripMenuItem_Click);
            // 
            // saveTimeDataToolStripMenuItem
            // 
            this.saveTimeDataToolStripMenuItem.Name = "saveTimeDataToolStripMenuItem";
            this.saveTimeDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveTimeDataToolStripMenuItem.Text = "Save Time Data";
            this.saveTimeDataToolStripMenuItem.Click += new System.EventHandler(this.saveTimeDataToolStripMenuItem_Click);
            // 
            // loadTimeDataToolStripMenuItem
            // 
            this.loadTimeDataToolStripMenuItem.Name = "loadTimeDataToolStripMenuItem";
            this.loadTimeDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.loadTimeDataToolStripMenuItem.Text = "Load Time Data";
            this.loadTimeDataToolStripMenuItem.Click += new System.EventHandler(this.loadTimeDataToolStripMenuItem_Click);
            // 
            // clearTimeDataToolStripMenuItem
            // 
            this.clearTimeDataToolStripMenuItem.Name = "clearTimeDataToolStripMenuItem";
            this.clearTimeDataToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.clearTimeDataToolStripMenuItem.Text = "Clear Time Data";
            this.clearTimeDataToolStripMenuItem.Click += new System.EventHandler(this.clearTimeDataToolStripMenuItem_Click);
            // 
            // grpTasks
            // 
            this.grpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTasks.ContextMenuStrip = this.taskContextMenuStrip;
            this.grpTasks.Controls.Add(this.taskDataGridView);
            this.grpTasks.ForeColor = System.Drawing.Color.White;
            this.grpTasks.Location = new System.Drawing.Point(0, 199);
            this.grpTasks.Name = "grpTasks";
            this.grpTasks.Size = new System.Drawing.Size(550, 96);
            this.grpTasks.TabIndex = 14;
            this.grpTasks.TabStop = false;
            this.grpTasks.Text = "Tasks";
            // 
            // taskDataGridView
            // 
            this.taskDataGridView.AllowUserToOrderColumns = true;
            this.taskDataGridView.AutoGenerateColumns = false;
            this.taskDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.taskDataGridView.BackgroundColor = System.Drawing.Color.Black;
            this.taskDataGridView.CausesValidation = false;
            this.taskDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.totalTimeDataGridViewTextBoxColumn,
            this.estimatedTimeDataGridViewTextBoxColumn,
            this.dateEnteredDataGridViewTextBoxColumn});
            this.taskDataGridView.DataMember = "Tasks";
            this.taskDataGridView.DataSource = this.taskDataSetBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.taskDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.taskDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDataGridView.Location = new System.Drawing.Point(3, 16);
            this.taskDataGridView.Name = "taskDataGridView";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.taskDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.taskDataGridView.Size = new System.Drawing.Size(544, 77);
            this.taskDataGridView.TabIndex = 0;
            // 
            // taskIDDataGridViewTextBoxColumn
            // 
            this.taskIDDataGridViewTextBoxColumn.DataPropertyName = "TaskID";
            this.taskIDDataGridViewTextBoxColumn.HeaderText = "TaskID";
            this.taskIDDataGridViewTextBoxColumn.Name = "taskIDDataGridViewTextBoxColumn";
            this.taskIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 85;
            // 
            // totalTimeDataGridViewTextBoxColumn
            // 
            this.totalTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalTime";
            this.totalTimeDataGridViewTextBoxColumn.HeaderText = "TotalTime";
            this.totalTimeDataGridViewTextBoxColumn.Name = "totalTimeDataGridViewTextBoxColumn";
            this.totalTimeDataGridViewTextBoxColumn.Width = 79;
            // 
            // estimatedTimeDataGridViewTextBoxColumn
            // 
            this.estimatedTimeDataGridViewTextBoxColumn.DataPropertyName = "EstimatedTime";
            this.estimatedTimeDataGridViewTextBoxColumn.HeaderText = "EstimatedTime";
            this.estimatedTimeDataGridViewTextBoxColumn.Name = "estimatedTimeDataGridViewTextBoxColumn";
            this.estimatedTimeDataGridViewTextBoxColumn.Width = 101;
            // 
            // dateEnteredDataGridViewTextBoxColumn
            // 
            this.dateEnteredDataGridViewTextBoxColumn.DataPropertyName = "DateEntered";
            this.dateEnteredDataGridViewTextBoxColumn.HeaderText = "DateEntered";
            this.dateEnteredDataGridViewTextBoxColumn.Name = "dateEnteredDataGridViewTextBoxColumn";
            this.dateEnteredDataGridViewTextBoxColumn.Width = 92;
            // 
            // taskDataSetBindingSource
            // 
            this.taskDataSetBindingSource.DataSource = this.taskDataSet;
            this.taskDataSetBindingSource.Position = 0;
            // 
            // taskDataSet
            // 
            this.taskDataSet.DataSetName = "taskDataSet";
            this.taskDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timeclockDataSaveFileDialog
            // 
            this.timeclockDataSaveFileDialog.DefaultExt = "xml";
            this.timeclockDataSaveFileDialog.FileName = global::Dangerwolf.Timeclock.Properties.Settings.Default.TimeStoreFile;
            this.timeclockDataSaveFileDialog.Filter = "XML Data Files (.xml)|*.xml|All Files|*.*";
            this.timeclockDataSaveFileDialog.InitialDirectory = global::Dangerwolf.Timeclock.Properties.Settings.Default.TimeStoreDir;
            this.timeclockDataSaveFileDialog.Title = "Save Time Data File";
            // 
            // timeclockDataOpenFileDialog
            // 
            this.timeclockDataOpenFileDialog.DefaultExt = "xml";
            this.timeclockDataOpenFileDialog.FileName = global::Dangerwolf.Timeclock.Properties.Settings.Default.TimeStoreFile;
            this.timeclockDataOpenFileDialog.Filter = "XML Data Files (.xml)|*.xml|All Files|*.*";
            this.timeclockDataOpenFileDialog.InitialDirectory = global::Dangerwolf.Timeclock.Properties.Settings.Default.TimeStoreDir;
            this.timeclockDataOpenFileDialog.Title = "Open Time Data File";
            // 
            // timeclockTimerControl
            // 
            this.timeclockTimerControl.Location = new System.Drawing.Point(13, 13);
            this.timeclockTimerControl.Name = "timeclockTimerControl";
            this.timeclockTimerControl.Size = new System.Drawing.Size(172, 180);
            this.timeclockTimerControl.TabIndex = 15;
            // 
            // Timeclock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(550, 295);
            this.Controls.Add(this.timeclockTimerControl);
            this.Controls.Add(this.grpTasks);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Timeclock";
            this.Text = "Timeclock";
            this.taskContextMenuStrip.ResumeLayout(false);
            this.grpTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taskDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDataSet)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.GroupBox grpTasks;
        private System.Windows.Forms.ContextMenuStrip taskContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem associateSelectedTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAssociationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTimeEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveTimeDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTimeDataToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog timeclockDataSaveFileDialog;
        private System.Windows.Forms.OpenFileDialog timeclockDataOpenFileDialog;

        #endregion

        private System.Windows.Forms.ToolStripMenuItem clearTimeDataToolStripMenuItem;
        private TimeclockControls.clockTimerControl timeclockTimerControl;
        private System.Windows.Forms.DataGridView taskDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimatedTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEnteredDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource taskDataSetBindingSource;
        private TaskDataSet taskDataSet;
    }
}
