using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
namespace iMago.Forms
{
    public partial class ZeroCrossing : DevExpress.XtraEditors.XtraForm
    {
        public bool manipulated = true;
        public float derivative1, derivative2;
        public int filterSize;
        public PaddingType paddingType;
        public ZeroCrossing()
        {
            InitializeComponent();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                derivative1 = float.Parse(derivative1TextBox.Text);
                derivative2 = float.Parse(derivative2TextBox.Text);
                filterSize = int.Parse(FilterSizeTextBox.Text);
                paddingType = PaddingType.Replication;
                manipulated = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Wrong Data");
                this.Close();
            }

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            manipulated = false;
            this.Close();
        }
    }
}
