using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dangerwolf.Timeclock
{
    public partial class ViewTimeEntries : Form
    {
        public ViewTimeEntries(TaskDataSet taskDataSet)
        {
            this.taskDataSet = taskDataSet;
            InitializeComponent();
        }
    }
}