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
    public enum PPMFileType
    {
        p1,p2,p3,p4,p5,p6
    }

    public partial class SavingFormat : DevExpress.XtraEditors.XtraForm
    {
        public bool Selected = false;
        public PPMFileType selectedtype;

        public SavingFormat()
        {
            InitializeComponent();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            Selected = true;
            if ((bool)radioGroup1.Properties.Items[0].Value)
            {
                selectedtype = PPMFileType.p2;
            }
            if ((bool)radioGroup1.Properties.Items[1].Value)
            {
                selectedtype = PPMFileType.p1;
            }
            if ((bool)radioGroup1.Properties.Items[2].Value)
            {
                selectedtype = PPMFileType.p3;
            }
            if ((bool)radioGroup1.Properties.Items[3].Value)
            {
                selectedtype = PPMFileType.p4;
            }
            if ((bool)radioGroup1.Properties.Items[4].Value)
            {
                selectedtype = PPMFileType.p5;
            }
            if ((bool)radioGroup1.Properties.Items[5].Value)
            {
                selectedtype = PPMFileType.p6;
            }

            this.Close();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.radioGroup1.Properties.Items[this.radioGroup1.SelectedIndex].Value = true;
        }
    }
}
