using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Utilities;
using ImageManipulation;
namespace iMago
{
    public partial class Text_Hidding : DevExpress.XtraEditors.XtraForm
    {
       UnsafeBitmap image;
       Bitmap myImage;
       string FilePath;
        public Text_Hidding()
        {
            
            InitializeComponent();
            
           textBox1.Hide();
        }

        

        
        private void Text_Hidding_Load(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "All Formats |*.*|Bitmap Files|*.bmp" +
                "|Enhanced Windows MetaFile|*.emf" + "PPM Files|*.PPM|" +
                "|Exchangeable Image File|*.exif" +
                "|Gif Files|*.gif|Icons|*.ico|JPEG Files|*.jpg" +
                "|PNG Files|*.png|TIFF Files|*.tif|Windows MetaFile|*.wmf|All Formats |*.*";

            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap img = new Bitmap(OpenFile.FileName);
                image = new UnsafeBitmap(img);
                img = ImageResizer.Resize(img, 395, 186, ResizeingMethod.Bilinear);
                pictureBox1.Image = img;
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog OpenFile = new OpenFileDialog();
           

            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilePath=OpenFile.FileName;
                label1.Show();
                 button3.Enabled = true;

               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             myImage = TextHidding.HideText(image.Bitmap,FilePath );
             if (myImage != null)
             {
                 Bitmap myImage2 = ImageResizer.Resize(myImage, 400, 189, ResizeingMethod.Bilinear);
                 pictureBox2.Image = myImage2;
             }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog OpenFile = new SaveFileDialog();
            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                myImage.Save(OpenFile.FileName, ImageFormat.Bmp);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            string text =TextHidding.ShowText(image.Bitmap);
            textBox1.Show();
            textBox1.Text = text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();


            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                myImage = new Bitmap(OpenFile.FileName);
                Bitmap img2 = ImageResizer.Resize(myImage, 237, 222, ResizeingMethod.Bilinear);
                pictureBox3.Image = img2;
                button5.Enabled = true;
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            UnsafeBitmap img2 = new UnsafeBitmap(myImage);
           
                myImage = TextHidding.HideImage(image, img2);
                if (myImage != null)
                {
                Bitmap imageTobeDisplayed = ImageResizer.Resize(myImage, 400, 189, ResizeingMethod.Bilinear);
                pictureBox2.Image = imageTobeDisplayed;
                }
            else
            MessageBox.Show("image too larg");
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
              myImage =TextHidding.RetrieveImage(image);
              pictureBox2.Image = myImage;
              button2.Show();
        }
    }
}
