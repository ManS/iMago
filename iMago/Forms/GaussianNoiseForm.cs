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
    public partial class GaussianNoiseForm : DevExpress.XtraEditors.XtraForm
    {
        public bool manipulated = false;
        public double mu, sigma, noisePercent;
        public GaussianNoiseForm()
        {
            InitializeComponent();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                mu = double.Parse(Mu_txt.Text);
                sigma = double.Parse(Sigma_txt.Text);
                noisePercent = double.Parse(Noise_txt.Text);
                manipulated = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Wrong Data:@:@");
            }
           
          
        }
    }
}
