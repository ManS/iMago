using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Filters.Morphology;

namespace iMago.Forms
{
    public partial class Epsilon : DevExpress.XtraEditors.XtraForm
    {
        public float epsilon;
        public bool okPress;
        public Epsilon()
        {
            InitializeComponent();
            okPress = false;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                epsilon = float.Parse(textEdit1.Text);
      
                okPress = true;
            }
            catch
            {
                MessageBox.Show("Invalid Data");
            }
                this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            okPress = false;
            this.Close();
        }
    }
}