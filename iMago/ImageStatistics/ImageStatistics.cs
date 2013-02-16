using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using ImageStatistics;
using Utilities;


namespace ImageStatistics
{
    public class ImageStatistics
    {
        #region Properties
        public Histogram Red { get; private set; }
        public Histogram Green { get; private set; }
        public Histogram Blue { get; private set; }
        public Histogram Gray { get; private set; }
        public bool IsGray { get; private set; }
        public ImageStatistics Instance { get; private set; }
        #endregion

        #region Methods
        public void CalculateStatistics(Bitmap p_image)
        {
            if (p_image.PixelFormat != PixelFormat.Format8bppIndexed)
                this.IsGray = false;
            else
                this.IsGray = true;

            UnsafeBitmap unsafeImage = new UnsafeBitmap(p_image);
            unsafeImage.LockBitmap();

            if (this.IsGray)
            {
                int[] GrayHist = new int[256];
                int width = p_image.Width;
                int height = p_image.Height;
                
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        PixelData currentPixel = unsafeImage.GetPixel(i,j);
                        GrayHist[(int)currentPixel.Blue]++;
                    }
                }
                this.Gray = new Histogram(GrayHist);
                this.Green = this.Gray;
                this.Red = this.Gray;
                this.Blue = this.Gray;
            }
            else
            {
                int[] RedHist = new int[256];
                int[] BlueHist = new int[256];
                int[] GreenHist = new int[256];
                int[] GrayHist = new int[256];

                int width = p_image.Width;
                int height = p_image.Height;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        PixelData currentPixel = unsafeImage.GetPixel(i, j);
                        RedHist[(int)currentPixel.Red]++;
                        BlueHist[(int)currentPixel.Blue]++;
                        GreenHist[(int)currentPixel.Green]++;
                        int grayValue = (int)((currentPixel.Blue + currentPixel.Green + currentPixel.Red) / 3f);
                        GrayHist[grayValue]++;
                    }
                }
                this.Red = new Histogram(RedHist);
                this.Green = new Histogram(GreenHist);
                this.Blue = new Histogram(BlueHist);
                this.Gray = new Histogram(GrayHist);
            }
            unsafeImage.UnlockBitmap();
        }
        #endregion
    }
}
