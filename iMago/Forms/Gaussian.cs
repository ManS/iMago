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
    public partial class GaussianFilter : DevExpress.XtraEditors.XtraForm
    {
        public bool manipulated = false;
        public int sigma;
        public int width;
        public int height;
        public PaddingType type;
        public GaussianFilter()
        {
            InitializeComponent();
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            sigma = int.Parse(SigmaTextBox.Text);
            manipulated = true;


            type = (PaddingType)Enum.Parse(typeof(PaddingType), PaddedComboBox.SelectedItem.ToString());


            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
