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
    public partial class AdaptiveThresholding : DevExpress.XtraEditors.XtraForm

    {
        public int winSize;
        public bool IsPressed=false;
        public AdaptiveThresholding()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            winSize = int.Parse(textEdit1.Text);
            IsPressed = true;
            this.Close();
        }
    }
}
