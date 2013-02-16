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
    public partial class RetinexForm : DevExpress.XtraEditors.XtraForm
    {
        public double Sigma;
        public bool PressedOk = false;
        public RetinexForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Sigma = double.Parse(textEdit1.Text);
            PressedOk = true;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            PressedOk = false;
            this.Close();
        }
    }
}
