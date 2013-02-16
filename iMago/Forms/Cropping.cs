using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace iMago
{
    public partial class Cropping : DevExpress.XtraEditors.XtraForm
    {
        #region Attributes
        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        Bitmap cropBitmap;
        int cropPenSize = 1 ;
        System.Drawing.Pen cropPen;
        Color cropPenColor = Color.Red;
        Bitmap image;
        public bool cropped = false;
        #endregion

        public Cropping(Bitmap p_image)
        {
            InitializeComponent();
            this.Image = p_image;
            Original_image.Cursor = Cursors.Cross;
        }
        public Bitmap O_image;
        public Bitmap Output_image
        {
            get { return O_image; }
        }
        public Bitmap Image
        {
            get { return image; }
            set { image = value; Original_image.Image = value; }
        }

        private void Original_image_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cropX = e.X;
                cropY = e.Y;
                cropPen = new Pen(cropPenColor, cropPenSize);
                cropPen.DashStyle = DashStyle.DashDotDot;
                Cursor = Cursors.Cross;
            }
            Original_image.Refresh(); 
        }

        private void Original_image_MouseMove(object sender, MouseEventArgs e)
        {
            if (Original_image.Image == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                Original_image.Refresh();
                cropWidth = e.X - cropX;
                cropHeight = e.Y - cropY;
                Original_image.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
            }
        }

        private void Original_image_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (cropWidth < 1)
                return;
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap bit = new Bitmap(Original_image.Image, Original_image.Width, Original_image.Height);
            cropBitmap = new Bitmap(cropWidth, cropHeight);
            Graphics g = Graphics.FromImage(cropBitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel);
            Clipped_image.Image = cropBitmap;
            DrawHistogram(cropBitmap);
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            O_image = new Bitmap(Clipped_image.Image);
            cropped = true;
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            O_image = new Bitmap(Clipped_image.Image);
            if (this.O_image.Size != this.Image.Size)
            {
                cropped = true;
            }
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            cropped = false;
            this.Close();
        }



        # region Histograms
        public enum Histo
        {
            SourceHistogram,
            DestinationHistogram
        }
        private static Color[] colors = new Color[] {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),};

        private int SourceImageHash = 0;
        private int DestinationImageHash = 0;
        private AForge.Math.Histogram Source_activeHistogram = null;
        private AForge.Imaging.ImageStatistics Source_stat;
        #endregion


        # region Histogram
        public void DrawHistogram(Bitmap image)
        {
            GatherStatistics(image);
        }
        public void GatherStatistics(Bitmap image)
        {
            // avoid calculation in the case of the same image
            if (image != null)
            {
                if (SourceImageHash == image.GetHashCode())
                    return;
                SourceImageHash = image.GetHashCode();
            }

            // busy
            Capture = true;
            Cursor = Cursors.WaitCursor;

            // get statistics
           
            Source_stat = (image == null) ? null : new AForge.Imaging.ImageStatistics(image);
            
            // free
            Cursor = Cursors.Arrow;
            Capture = false;

            // clean combo
            histogram_cropped_ComboBox.Properties.Items.Clear();
            if (Source_stat != null)
            {
                if (!Source_stat.IsGrayscale)
                {
                    // RGB picture
                    histogram_cropped_ComboBox.Properties.Items.AddRange(new object[] { "Red", "Green", "Blue" });
                }
                else
                {
                    // grayscale picture
                    histogram_cropped_ComboBox.Properties.Items.Add("Gray");
                }
                histogram_cropped_ComboBox.SelectedIndex = 0;
                SwitchChannel((Source_stat.IsGrayscale) ? 3 : histogram_cropped_ComboBox.SelectedIndex, Histo.SourceHistogram);
            }
            else
                histogram_cropped.Values = null;
        }
        public void SwitchChannel(int channel, Histo Type)
        {
            if (Type == Histo.SourceHistogram)
            {
                if ((channel >= 0) && (channel <= 2))
                {
                    if (!Source_stat.IsGrayscale)
                    {
                        histogram_cropped.Color = colors[channel];
                        Source_activeHistogram = (channel == 0) ? Source_stat.Red : (channel == 1) ? Source_stat.Green : Source_stat.Blue;
                    }
                }
                else if (channel == 3)
                {
                    if (Source_stat.IsGrayscale)
                    {
                        histogram_cropped.Color = colors[3];
                        Source_activeHistogram = Source_stat.Gray;
                    }
                }

                if (Source_activeHistogram != null)
                {
                    histogram_cropped.Values = Source_activeHistogram.Values;
                }
            }
            
        }
        private void histogram_cropped_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Source_stat != null)
            {
                SwitchChannel((Source_stat.IsGrayscale) ? 3 : histogram_cropped_ComboBox.SelectedIndex, Histo.SourceHistogram);
            }
        }
        private void Source_Log_check_CheckedChanged(object sender, EventArgs e)
        {
            histogram_cropped.LogView = Source_Log_check.Checked;
        }
        
        #endregion


    }
}
