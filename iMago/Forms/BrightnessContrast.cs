using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageManipulation;
using System.Threading;

namespace iMago
{
    public partial class BrightnessContrast : DevExpress.XtraEditors.XtraForm
    {

        #region Attributes
        private ImageManipulator m_Manipulator;
        private ImageIllumination m_imageIllumination;
        private Thread workerThread;
        bool manipulated = false;
        #endregion

        public BrightnessContrast(ImageManipulator p_Manipulator )
        {
            InitializeComponent();
            Bitmap sourceImage = p_Manipulator.Image.BitmapImage;
            this.m_Manipulator = p_Manipulator;
            m_imageIllumination = new ImageIllumination(sourceImage, p_Manipulator.Image.ImageStatistics);
            OriginalPictureBox.Image = sourceImage;
            ModifiedPictureBox.Image = sourceImage;
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            this.OriginalPictureBox.Image = this.ModifiedPictureBox.Image;
        }

        private void BrightnessTrackBar_EditValueChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
	        {
                this.BeginInvoke(new EventHandler(BrightnessTrackBar_EditValueChanged),sender,e);
                return;
	        }
            int offset = BrightnessTrackBar.Value;
            if (workerThread != null && workerThread.ThreadState == ThreadState.Running)
                workerThread.Join();
            workerThread = new Thread(delegate(){this.AdjustBrightness(offset); });
            workerThread.Start();
        }

        object sync = new object();
        private void AdjustBrightness(int offset)
        {
            lock (sync)
            {

                Bitmap processedImage = this.m_imageIllumination.AdjustBrightness(offset);
                this.ModifiedPictureBox.Image = processedImage;
                if (this.Preview_check.Checked)
                {
                    this.m_Manipulator.ImagePanel.Image = processedImage;
                }
            }
        }

        private void ContrastTrackBar_EditValueChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(BrightnessTrackBar_EditValueChanged), sender, e);
                return;
            }
            int offset = ContrastTrackBar.Value;
            if (workerThread != null && workerThread.ThreadState == ThreadState.Running)
                workerThread.Join();
            workerThread = new Thread(delegate() { this.AdjustContrast(offset); });
            workerThread.Start();
        }

        private void AdjustContrast(int offset)
        {
            lock (sync)
            {
                Bitmap processedImage = this.m_imageIllumination.AdjustContrast(offset);
                this.ModifiedPictureBox.Image = processedImage;
                if (this.Preview_check.Checked)
                {
                    this.m_Manipulator.ImagePanel.Image = processedImage;
                }
            }
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            manipulated = true;
          
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BrightnessContrast_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (manipulated)
            {
                this.m_Manipulator.ImagePanel.Image = (Bitmap)this.ModifiedPictureBox.Image;
                this.m_Manipulator.NotifyUpdated("Brightness/Contrast");
            }
            else
            {
                this.m_Manipulator.ImagePanel.Image = this.m_Manipulator.Image.BitmapImage;
            }
        }
    }
}