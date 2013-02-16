using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMago
{
    public partial class ExponentialNoiseForm : DevExpress.XtraEditors.XtraForm
    {
        public double A;
        public double noisePercentage;
        public bool Modified = false;
        public ExponentialNoiseForm()
        {
            InitializeComponent();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                A = double.Parse(A_txt.Text);
                noisePercentage = double.Parse(Noise_txt.Text);
                Modified = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
    }
}
