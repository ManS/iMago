using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessingAssignment1
{
    public partial class TimeForm : Form
    {
        string TestName, TimeTaken;
        public TimeForm()
        {
            InitializeComponent();
        }
        public TimeForm(string _TestName, string _TimeTaken)
        {
            TestName = _TestName;
            TimeTaken = _TimeTaken;
            InitializeComponent();
        }

        private void TimeForm_Load(object sender, EventArgs e)
        {
            RunTimeLBL.Text = TimeTaken;
            TestNameLBL.Text = TestName;
        }
    }
}
