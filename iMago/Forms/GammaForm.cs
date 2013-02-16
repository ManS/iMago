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
    public partial class GammaForm : DevExpress.XtraEditors.XtraForm
    {
        public bool IsPressed = false;
        public float value;
        public GammaForm()
        {
            InitializeComponent();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                value = float.Parse(gamma_txtbox.Text);
                IsPressed = true;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            IsPressed = false;
            this.Close();
        }

    }
}
