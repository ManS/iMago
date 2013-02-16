using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace iMago
{
    public partial class LaplacianOfGaussianForm : DevExpress.XtraEditors.XtraForm
    {
        public int FilterSize;
        public double Sigma;
        public bool IsPressed = false;
        public PaddingType Padding;

        public LaplacianOfGaussianForm()
        {
            InitializeComponent();
        }

        private void LaplacianOfGaussianForm_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                FilterSize = int.Parse(textEdit1.Text);
                Sigma = double.Parse(textEdit2.Text);
                Padding = GetPaddingType();
                IsPressed = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            IsPressed = true;
        }

        private PaddingType GetPaddingType()
        {
            if (this.comboBoxEdit1.SelectedIndex == 0)
            {
                return PaddingType.Replication;
            }
            else
            {
                return PaddingType.Zeros;
            }
        }
    }
}
