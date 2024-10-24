using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Dangerwolf.Timeclock
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Timeclock : Form
    {
        // Flags
        private bool use24HourClock = Dangerwolf.Timeclock.Properties.Settings.Default.Clock24Hour;
        private bool useAlternateTimingMethod = Dangerwolf.Timeclock.Properties.Settings.Default.AlternateTimingMethod;

        // Date & Time Handling
        private TimeSpan spanPrevious = TimeSpan.Zero;

        private DataRowView drAssociatedTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Timeclock"/> class.
        /// </summary>
        public Timeclock()
        {
            InitializeComponent();

            // Set up the event handlers.
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Timeclock_FormClosing);

            this.timeclockTimerControl.Elapsed += new EventHandler<System.Timers.ElapsedEventArgs>(timeclockTimerControl_Elapsed);
            this.timeclockTimerControl.TimerStarted += new EventHandler<EventArgs>(timeclockTimerControl_TimerStarted);
            this.timeclockTimerControl.TimerStopped += new EventHandler<EventArgs>(timeclockTimerControl_TimerStopped);

            this.taskDataGridView.CellValidating += new DataGridViewCellValidatingEventHandler(taskDataGridView_CellValidating);
            //this.taskDataGridView.RowValidating += new DataGridViewCellCancelEventHandler(taskDataGridView_RowValidating);
            this.taskDataGridView.CellEndEdit += new DataGridViewCellEventHandler(taskDataGridView_CellEndEdit);
            this.taskDataSet.Tables["Tasks"].TableNewRow += new DataTableNewRowEventHandler(tasksTable_TableNewRow);
            this.taskDataSet.Tables["Tasks"].RowDeleted += new DataRowChangeEventHandler(tasksTable_RowDeleted);

            // If we have a string formatting expression in the default filename then replace it.
            if (timeclockDataSaveFileDialog.FileName.Contains("{"))
                timeclockDataSaveFileDialog.FileName = String.Format(timeclockDataSaveFileDialog.FileName, DateTime.Now);

            if (timeclockDataOpenFileDialog.FileName.Contains("{"))
                timeclockDataOpenFileDialog.FileName = String.Format(timeclockDataOpenFileDialog.FileName, DateTime.Now);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Timeclock());
        }

        #region "Timer Event Handlers"
        /// <summary>
        /// Handles the TimerStarted event of the timeclockTimerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timeclockTimerControl_TimerStarted(object sender, EventArgs e)
        {
            if (drAssociatedTask != null)
                this.spanPrevious = (TimeSpan)this.drAssociatedTask["TotalTime"];
        }

        /// <summary>
        /// Handles the TimerStopped event of the timeclockTimerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timeclockTimerControl_TimerStopped(object sender, EventArgs e)
        {
            if (timeclockTimerControl.IsRunning && !timeclockTimerControl.IsPaused && drAssociatedTask != null)
            {
                this.drAssociatedTask["TotalTime"] = this.spanPrevious + timeclockTimerControl.GetElapsedTime();
                this.taskDataGridView.Refresh();
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the timeclockTimerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void timeclockTimerControl_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (timeclockTimerControl.IsRunning && !timeclockTimerControl.IsPaused && drAssociatedTask != null)
            {
                this.drAssociatedTask["TotalTime"] = this.spanPrevious + timeclockTimerControl.GetElapsedTime();
                this.taskDataGridView.InvalidateRow(findGridRow(this.drAssociatedTask));
            }
        }

        /// <summary>
        /// Finds the index of the DataGridViewRow in that sources from the specified DataRowView.
        /// </summary>
        /// <param name="matchRow">The row to match.</param>
        /// <returns>The index of the matching row in the DataGridView.</returns>
        private int findGridRow(DataRowView matchRow)
        {
            foreach (DataGridViewRow row in this.taskDataGridView.Rows)
            {
                if (row.DataBoundItem == matchRow)
                    return row.Index;
            }

            return -1;
        }
        #endregion

        #region "Form Event Handlers"

        /// <summary>
        /// Handles the FormClosing event of the Timeclock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        void Timeclock_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Validate();
            //this.taskDataSetBindingSource.EndEdit();

            // Update default properties and save them.
            Dangerwolf.Timeclock.Properties.Settings.Default.Clock24Hour = this.use24HourClock;
            Dangerwolf.Timeclock.Properties.Settings.Default.Save();

            if (this.taskDataSet.HasChanges())
            {
                switch (MessageBox.Show("You have unsaved data. Save the data before quitting?", "Unsaved Data", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        if (this.timeclockDataSaveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (FileStream file = this.timeclockDataSaveFileDialog.OpenFile() as FileStream)
                            {
                                this.taskDataSet.AcceptChanges();
                                this.taskDataSet.WriteXml(file, XmlWriteMode.IgnoreSchema);
                                file.Close();
                            }
                        }
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        #region "Tasks Table Event Handlers"

        /// <summary>
        /// Handles the TableNewRow event of the tasksTable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Data.DataTableNewRowEventArgs"/> instance containing the event data.</param>
        public void tasksTable_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            // Add the default values that can't be created with simple DefaultValue properties.
            if (e.Row["TaskID"] == DBNull.Value || (Guid)e.Row["TaskID"] == Guid.Empty)
                e.Row["TaskID"] = Guid.NewGuid();

            if (e.Row["TotalTime"] == DBNull.Value)
                e.Row["TotalTime"] = TimeSpan.Zero;

            if (e.Row["EstimatedTime"] == DBNull.Value)
                e.Row["EstimatedTime"] = TimeSpan.Zero;

            if (e.Row["DateEntered"] == DBNull.Value)
                e.Row["DateEntered"] = DateTime.Now;
        }

        /// <summary>
        /// Handles the RowDeleted event of the tasksTable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Data.DataRowChangeEventArgs"/> instance containing the event data.</param>
        public void tasksTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (drAssociatedTask.Row == e.Row)
                drAssociatedTask = null;
        }

        #endregion

        #region "Task Grid Event Handlers"

        /// <summary>
        /// Handles the RowValidating event of the taskDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellCancelEventArgs"/> instance containing the event data.</param>
        private void taskDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string taskNameValue = this.taskDataGridView.Rows[e.RowIndex].Cells["TaskName"].FormattedValue.ToString();

            if (String.IsNullOrEmpty(taskNameValue) || taskNameValue.Trim().Length == 0)
            {
                this.taskDataGridView.Rows[e.RowIndex].ErrorText = "Task Name must not be empty.";
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the CellValidating event of the taskDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellValidatingEventArgs"/> instance containing the event data.</param>
        private void taskDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.taskDataGridView.Columns[e.ColumnIndex].Name == "nameDataGridViewTextBoxColumn" && (String.IsNullOrEmpty(e.FormattedValue.ToString()) || e.FormattedValue.ToString().Trim().Length == 0))
            {
                this.taskDataGridView.Rows[e.RowIndex].ErrorText = String.Format("{0} must not be empty.", this.taskDataGridView.Columns[e.ColumnIndex].HeaderText);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Handles the CellEndEdit event of the taskDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        void taskDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.taskDataGridView.Rows[e.RowIndex].ErrorText = "";
        }

        #endregion

        #region "Time Data Context Menu Event Handlers"

        /// <summary>
        /// Handles the Click event of the associateSelectedTaskToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void associateSelectedTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.taskDataGridView.SelectedRows.Count == 1)
            {
                if (this.drAssociatedTask != this.taskDataGridView.SelectedRows[0].DataBoundItem)
                {
                    if (!this.taskDataGridView.SelectedRows[0].IsNewRow)
                    {
                        this.drAssociatedTask = this.taskDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
                        this.spanPrevious = (TimeSpan)this.drAssociatedTask["TotalTime"];
                    }
                    else
                    {
                        MessageBox.Show("You cannot associate the timer with a task that hasn't been created yet", "Timer association error.", MessageBoxButtons.OK);
                    }
                }
            }
            else if (this.taskDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must select the entire task row to associate the timer with it.", "Timer association error.", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("You can only associate one task with the timer at a time.", "Timer association error.", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Handles the Click event of the clearAssociationToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void clearAssociationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.drAssociatedTask != null)
            {
                if (timeclockTimerControl.IsRunning || timeclockTimerControl.IsPaused)
                {
                    if (MessageBox.Show("The timer is currently running. Are you sure you want to clear the association?", "Clear Association", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        if (MessageBox.Show("Restore the original time?", "Restore Original Time", MessageBoxButtons.YesNo)
                            == DialogResult.Yes)
                        {
                            this.drAssociatedTask["TotalTime"] = this.spanPrevious;
                        }

                        this.spanPrevious = TimeSpan.Zero;
                        this.drAssociatedTask = null;
                    }
                }
                else
                {
                    this.spanPrevious = TimeSpan.Zero;
                    this.drAssociatedTask = null;
                }
            }

            this.taskDataGridView.Refresh();
        }

        /// <summary>
        /// Handles the Click event of the saveTimeDataToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void saveTimeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.taskDataSetBindingSource.EndEdit();

            if (this.timeclockDataSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream file = this.timeclockDataSaveFileDialog.OpenFile() as FileStream)
                {
                    this.taskDataSet.WriteXml(file, XmlWriteMode.IgnoreSchema);
                    this.taskDataSet.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the loadTimeDataToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void loadTimeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.timeclockDataOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Validate();
                //this.taskDataSetBindingSource.EndEdit();

                if (this.taskDataSet.HasChanges())
                {
                    switch (MessageBox.Show("You have unsaved data. Save the data before loading the new data?", "Unsaved Data", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Yes:
                            if (this.timeclockDataSaveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                using (FileStream file = this.timeclockDataSaveFileDialog.OpenFile() as FileStream)
                                {
                                    this.taskDataSet.WriteXml(file, XmlWriteMode.IgnoreSchema);
                                    this.taskDataSet.AcceptChanges();
                                }
                            }
                            break;

                        case DialogResult.No:
                            break;

                        case DialogResult.Cancel:
                            return;
                    }
                }

                using (FileStream file = this.timeclockDataOpenFileDialog.OpenFile() as FileStream)
                {
                    this.drAssociatedTask = null;
                    this.taskDataSet.Clear();
                    this.taskDataSet.ReadXml(file);
                    this.taskDataSet.AcceptChanges();
                    file.Close();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the clearTimeDataToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void clearTimeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            //this.taskDataSetBindingSource.EndEdit();

            if (this.taskDataSet.HasChanges())
            {
                switch (MessageBox.Show("You have unsaved data. Save the data before clearing?", "Unsaved Data", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        if (this.timeclockDataSaveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (FileStream file = this.timeclockDataSaveFileDialog.OpenFile() as FileStream)
                            {
                                this.taskDataSet.AcceptChanges();
                                this.taskDataSet.WriteXml(file, XmlWriteMode.IgnoreSchema);
                                file.Close();
                            }
                        }
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        return;
                }
            }

            this.drAssociatedTask = null;
            this.taskDataSet.Clear();
            this.taskDataSet.AcceptChanges();
        }

        /// <summary>
        /// Handles the Click event of the viewTimeEntriesToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void viewTimeEntriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form viewTimeEntries = new ViewTimeEntries(taskDataSet);
            viewTimeEntries.ShowDialog();
        }

        #endregion
    }
}