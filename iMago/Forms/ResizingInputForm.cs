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
    public partial class ResizingInputForm : DevExpress.XtraEditors.XtraForm
    {
        public bool IsPressed = false;
        public int newWidth;
        public int newHeight;
        public ResizingInputForm()
        {
            InitializeComponent();
        }

        private void Resize_btn_Click(object sender, EventArgs e)
        {
            newWidth = int.Parse(NewWidth_txtbox.Text);
            newHeight = int.Parse(NewHeight_txtbox.Text);
            IsPressed = true;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
