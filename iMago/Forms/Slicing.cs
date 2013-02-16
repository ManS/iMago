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
    public partial class Slicing : DevExpress.XtraEditors.XtraForm
    {
        public int minOld, maxOld, NewValue;
        public bool manipulated = false;
        public Slicing()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                minOld = int.Parse(minOldTextBox.Text);
                maxOld = int.Parse(maxOldTextBox.Text);
                NewValue = int.Parse(NewValueTextBox.Text);
                manipulated = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            manipulated = false;
           this.Close();
        }
    }
}
