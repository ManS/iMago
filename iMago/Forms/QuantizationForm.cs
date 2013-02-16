using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using ImageManipulation;

namespace iMago
{
    public partial class QuantizationForm : DevExpress.XtraEditors.XtraForm
    {
        public bool manipulated = false;
        private List<List<UnsafeBitmap>> imagesList;
        ImageManipulator m_manipulator;

        public QuantizationForm(ImageManipulator p_manipulator)
        {

            InitializeComponent();
            m_manipulator = p_manipulator;

            imagesList = ImageQuantization.GetQuantizedImagesListByColor(m_manipulator.ImagePanel.Image);
            OriginalImage_PB.Image = m_manipulator.ImagePanel.Image;
            ModifiedImage_PB.Image = m_manipulator.ImagePanel.Image;
            OriginalImage_PB.SizeMode = PictureBoxSizeMode.StretchImage;
            ModifiedImage_PB.SizeMode = PictureBoxSizeMode.StretchImage;
            //20, 35
            //20, 167

            int yDist = 35;
            for (int i = 0; i < 3; i++)
            {
                int xDist = 20;
                for (int j = 0; j < 8; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new System.Drawing.Point(xDist, yDist);
                    pictureBox.Name = i.ToString() + "-" + j.ToString() + "_picturebox";
                    pictureBox.Size = new System.Drawing.Size(87, 126);
                    pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
                    pictureBox.Image = imagesList[i][j].Bitmap;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.BorderStyle = BorderStyle.Fixed3D;

                    imagesPanal.Controls.Add(pictureBox);

                    xDist += 90;
                }
                yDist += 140;
            }
        }
        
        private void pictureBox_Click(object sender, EventArgs e)
        {
            BorderStyle imageBorderStyle = ((PictureBox)sender).BorderStyle;
            ((PictureBox)sender).BorderStyle = imageBorderStyle == BorderStyle.Fixed3D ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;
            string picBoxName = ((PictureBox)sender).Name;
            byte intenstyLevel = GetSelectedLevel(picBoxName);
            Colors color = GetSelectedColor(picBoxName);
            switch (imageBorderStyle)
            {
                case BorderStyle.Fixed3D:
                    {
                        ModifiedImage_PB.Image = ImageQuantization.BitSliceQuantizeByColor((Bitmap)ModifiedImage_PB.Image, intenstyLevel, color);
                    }
                    break;
                case BorderStyle.FixedSingle:
                    {
                        ModifiedImage_PB.Image = ImageQuantization.ReturnQuantizedBitSliceByColor((Bitmap)ModifiedImage_PB.Image, (Bitmap)((PictureBox)sender).Image, intenstyLevel, color);
                    }
                    break;
                default:
                    break;
            }
            if (this.Preview_checkbox.Checked)
            {
                Bitmap quantizedImage = (Bitmap)this.ModifiedImage_PB.Image;
                this.m_manipulator.NotifyUpdateHistogram(quantizedImage);
                this.m_manipulator.ImagePanel.Image = quantizedImage;
            }
        }
       
        private Colors GetSelectedColor(string picBoxName)
        {
            int x = int.Parse(picBoxName.Split('-')[0]);

            switch (x)
            {
                case 0:
                    return Colors.Red;
                case 1:
                    return Colors.Green;
                case 2:
                    return Colors.Blue;
                default:
                    throw new NotImplementedException();
            }

        }

        private byte GetSelectedLevel(string picBoxName)
        {
            char[] param = { '-', '_' };
            int level = int.Parse(picBoxName.Split(param, StringSplitOptions.RemoveEmptyEntries)[1]);
            return (byte)Math.Pow(2, 7 - level);
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            this.OriginalImage_PB.Image = this.ModifiedImage_PB.Image;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            manipulated = true;
            this.OriginalImage_PB.Image = this.ModifiedImage_PB.Image;
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            manipulated = false;
            this.Close();
        }

        private void QuantizationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (manipulated)
            {
                this.m_manipulator.ImagePanel.Image = (Bitmap)this.OriginalImage_PB.Image;
                this.m_manipulator.NotifyUpdated("Quantization");
            }
            else
            {
                this.m_manipulator.ImagePanel.Image = this.m_manipulator.Image.BitmapImage;
            }
        }
    }
}
