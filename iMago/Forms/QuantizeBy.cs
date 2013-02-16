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
    public partial class QuantizeBy : DevExpress.XtraEditors.XtraForm
    {
        public byte bpp;
        public bool modified = false;
        public QuantizeBy()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            modified = true;
            bpp = byte.Parse(QuantizeValue.Text);
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
