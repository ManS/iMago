using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMago.Forms
{
    public partial class NormalThreshold : DevExpress.XtraEditors.XtraForm
    {
        public int threshold;
        public bool manipulated = false;
        public NormalThreshold()
        {
            InitializeComponent();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            threshold = int.Parse(thresholdTextBox.Text);
            manipulated = true;
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            manipulated = false;
            this.Close();
        }
    }
}
