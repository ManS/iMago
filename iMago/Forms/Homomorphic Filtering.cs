using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Filters;
using Filters.FrequencyFilters;
namespace iMago.Forms
{
    public partial class Homomorphic_Filtering : DevExpress.XtraEditors.XtraForm
    {
        public float lowGain, highGain, C;
       public int Raduis;
        public bool manipulated = true;
        public Bitmap image;
        public Bitmap freqImage;
        public Homomorphic_Filtering(Bitmap image)
        {
            InitializeComponent();
            this.image = image;
            pictureEdit1.Image = image;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            
            
                lowGain = float.Parse(LowGainTextBox.Text);
                highGain = float.Parse(HightGainTextBox.Text);
                C = float.Parse(CTextBox.Text);
                Raduis = int.Parse(RaduisTextBox.Text);

                HomomorphicFilter filter = new HomomorphicFilter(FourierTransformer.FourierTransform(image), FrequencyFilterName.IdealFilter, FilteringType.Pass, C, Raduis, lowGain, highGain);
                
                this.image = filter.ApplyFilter(image);
                pictureEdit2.Image = image;
                pictureEdit3.Image = filter.GetMaskPreviewImage();
            
            
        }

        private void OkButton_Click_1(object sender, EventArgs e)
        {
            manipulated = true;
            this.Close();
        }
    }
}
