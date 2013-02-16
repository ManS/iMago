using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace iMago
{
    public partial class 
        FrequencyDomainForm : DevExpress.XtraEditors.XtraForm
    {

        public FrequencyDomainForm(FrequencyDomainImage freqImage)
        {
            InitializeComponent();
            pb_Blue.Image = freqImage.Blue.GetPlaneImage();
            pb_Green.Image = freqImage.Green.GetPlaneImage();
            pb_Red.Image = freqImage.Red.GetPlaneImage();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
