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
    public partial class ResizeByFactorInputForm : DevExpress.XtraEditors.XtraForm
    {
        public int ResizingFactor;
        public bool IsPressed = false;
        public ResizeByFactorInputForm()
        {
            InitializeComponent();
        }

        private void Resize_btn_Click(object sender, EventArgs e)
        {
            IsPressed = true;
            ResizingFactor = int.Parse(ResizingFactor_text.Text);
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
