using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace Utilities
{
    public class MatlabImage
    {
        #region Properties
        public double[,] Red { get; set; }
        public double[,] Green { get; set; }
        public double[,] Blue { get; set; }
        public Bitmap Bitmap { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
        
        #region Constructor
        public MatlabImage(int p_Width, int p_Height)
        {
            this.Width = p_Width;
            this.Height = p_Height;
            this.Red = new double[this.Width, this.Height];
            this.Green = new double[this.Width, this.Height];
            this.Blue = new double[this.Width, this.Height];
            this.Bitmap = new Bitmap(this.Width, this.Height);
        }
        public MatlabImage(MWArray p_Red, MWArray p_Green, MWArray p_Blue)
        {
            this.Red = (double[,])p_Red.ToArray();
            this.Green = (double[,])p_Green.ToArray();
            this.Blue = (double[,])p_Blue.ToArray();
            this.Bitmap = this.GetBitmapImage();
            this.Width = this.Red.GetLength(0);
            this.Height = this.Red.GetLength(1);
        }

        public MatlabImage(byte[,] p_Red, byte[,] p_Green, byte [,] p_Blue)
        {
            this.Red = ImageConversions.BytesToEpicDoubles(p_Red);
            this.Green = ImageConversions.BytesToEpicDoubles(p_Green);
            this.Blue = ImageConversions.BytesToEpicDoubles(p_Blue);
            this.Bitmap = this.GetBitmapImage();
            this.Width = this.Red.GetLength(0);
            this.Height = this.Red.GetLength(1);
        }

        public MatlabImage(double[,] p_Red, double[,] p_Green, double[,] p_Blue)
        {
            this.Red = p_Red;
            this.Green = p_Green;
            this.Blue = p_Blue;
            this.Bitmap = GetBitmapImage();
            this.Width = this.Red.GetLength(0);
            this.Height = this.Red.GetLength(1);

        }
        public MatlabImage(Bitmap image)
        {
            this.Bitmap = image;
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);

            this.Red = new double[image.Width, image.Height];
            this.Green = new double[image.Width, image.Height];
            this.Blue = new double[image.Width, image.Height];
            this.Width = this.Red.GetLength(0);
            this.Height = this.Red.GetLength(1);
            unsafeImage.LockBitmap();
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    PixelData currentPixel = unsafeImage.GetPixel(i,j);

                    this.Red[i, j] = currentPixel.Red;
                    this.Blue[i, j] = currentPixel.Blue;
                    this.Green[i, j] = currentPixel.Green;
                }
            }
            unsafeImage.UnlockBitmap();

        }
        #endregion

        #region Methods
        private Bitmap GetBitmapImage()
        {
            UnsafeBitmap unsafeImage = new UnsafeBitmap(this.Red.GetLength(0), this.Red.GetLength(1));
            unsafeImage.LockBitmap();
            for (int i = 0; i < this.Red.GetLength(0); i++)
            {
                for (int j = 0; j < this.Red.GetLength(1); j++)
                {

                    if (Blue[i, j] > 255)
                        Blue[i, j] = 255;

                    if (Red[i, j] > 255)
                        Red[i, j] = 255;

                    if (Green[i, j] > 255)
                        Green[i, j] = 255;

                    if (Blue[i, j] < 0)
                        Blue[i, j] = 0;

                    if (Red[i, j] < 0)
                        Red[i, j] = 0;

                    if (Green[i, j] < 0)
                        Green[i, j] = 0;

                    unsafeImage.SetPixel(i, j, new PixelData((byte)this.Blue[i, j], (byte)this.Red[i, j], (byte)this.Green[i, j]));
                }
            }
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
        }
        #endregion
    }
}
