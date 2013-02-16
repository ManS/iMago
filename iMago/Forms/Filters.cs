using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using Filters.Blurring;

namespace iMago
{
    public partial class Filters : DevExpress.XtraEditors.XtraForm
    {
        
        public bool IsPressed = false;
        public int filterSize;
        public PaddingType paddingType;
        public float sigma;
        public bool manipulated = false;
        public ImageManipulator m_manipulator;
        
        public Filters(ImageManipulator p_manipulator) 
        {
            InitializeComponent();
            m_manipulator = p_manipulator;
            PaddingComboBox.SelectedIndex = 0;
            OriginalPictureBox.Image = p_manipulator.ImagePanel.Image;
            ModifiedPictureBox.Image = p_manipulator.ImagePanel.Image;
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                manipulated = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PaddingType GetPaddingType()
        {
            if (PaddingComboBox.SelectedIndex == 0)
            {
                return PaddingType.Replication;
            }
            else
            {
                return PaddingType.Zeros;
            }
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            //GaussianBlurring2D gaussian = new GaussianBlurring2D(int.Parse(WidthTextBox.Text), int.Parse(HeightTextBox.Text), float.Parse(SigmatextBox.Text));
            //paddingType = this.GetPaddingType();
            //ModifiedPictureBox.Image = gaussian.Apply(m_manipulator.ImagePanel.Image, paddingType);
        }

        private void Filters_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (manipulated)
            {
                this.m_manipulator.ImagePanel.Image = (Bitmap)this.ModifiedPictureBox.Image;
                this.m_manipulator.NotifyUpdated("(Blurred Gaussian Filter");
            }
            else
            {
                this.m_manipulator.ImagePanel.Image = this.m_manipulator.Image.BitmapImage;
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            manipulated = false;
            this.Close();
        }
    }
}
