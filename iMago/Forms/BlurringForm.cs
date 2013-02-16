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
    public partial class BlurringForm : DevExpress.XtraEditors.XtraForm
    {
        public bool IsPressed = false;
        public float Sigma;
   
        public BlurringForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Sigma = float.Parse(sigma_txt.Text);
            
            IsPressed = true;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
