using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace iMago
{
    public partial class Shear : DevExpress.XtraEditors.XtraForm
    {
        Bitmap Image;
        public Bitmap Final;
        int Factor;
        int ImWidth;
        int ImHeight;
        
        public bool ApplyButtonIsPressed;

        public Shear(Bitmap p_Image)
        {
            InitializeComponent();
            Axis_Combo.SelectedIndex = 0;
            Image = p_Image;
            ImWidth = Image.Width;
            ImHeight = Image.Height;
            ApplyButtonIsPressed = false;
        }

        public void ApplyShear()
        {
            int NewWidth;
            int NewHieght;
            try
            {
                Factor = int.Parse(Factor_txt.Text);
                if (Factor < 0)
                {
                    MessageBox.Show("Wrong input !");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Wrong input !");
                return;
            }
            if (Axis_Combo.SelectedIndex == 0)
            {
                NewWidth = ImWidth + (ImHeight * Factor);
                NewHieght = ImHeight;
            }
            else
            {
                NewWidth = ImWidth;
                NewHieght = ImHeight + (ImWidth * Factor);
            }


            UnsafeBitmap UnsafeImage = new UnsafeBitmap(Image);
            UnsafeBitmap FinalImage = new UnsafeBitmap(NewWidth, NewHieght);
            UnsafeImage.LockBitmap();
            FinalImage.LockBitmap();
            if (Axis_Combo.SelectedIndex == 0)
            {
                for (int i = 0; i < ImWidth; i++)
                {
                    for (int j = 0; j < ImHeight; j++)
                    {
                        int X = i + (j * Factor);
                        int Y = j;
                        FinalImage.SetPixel(X, Y, UnsafeImage.GetPixel(i, j));
                    }
                }
            }
            else
            {
                for (int i = 0; i < ImWidth; i++)
                {
                    for (int j = 0; j < ImHeight; j++)
                    {
                        int X = i;
                        int Y = j + (i * Factor); ;
                        FinalImage.SetPixel(X, Y, UnsafeImage.GetPixel(i, j));
                    }
                }
            }
            UnsafeImage.UnlockBitmap();
            FinalImage.UnlockBitmap();
            Final = FinalImage.Bitmap;
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            ApplyShear();
            ApplyButtonIsPressed = true;
            this.Close();
        }
    }
}
