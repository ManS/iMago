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
    public partial class PeriodicNoiseForm : DevExpress.XtraEditors.XtraForm
    {
        public bool manipulated = false;
        public double phaseX;
        public double PhaseY;
        public double frequencyX;
        public double frequencyY;
        public double amplitude;
        public PeriodicNoiseForm()
        {
            InitializeComponent();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                phaseX = double.Parse(XPhase_txt.Text);
                PhaseY = double.Parse(YPhase_txt.Text);
                frequencyX = double.Parse(Xfrequency_txt.Text);
                frequencyY = double.Parse(YFrequency_txt.Text);
                amplitude = double.Parse(Amplitude_txt.Text);
                manipulated = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid Data");
                manipulated = false;
                this.Close();
            }
            
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            manipulated = false;
            this.Close();
        }
    }
}
