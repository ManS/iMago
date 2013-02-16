using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters
{
   public abstract class I1DConvolution : IFilter
    {
        public double[] FilterValues { get; set; }
        public int FilterSize { get; set; }

        public I1DConvolution()
        {
            
        }
        public I1DConvolution(int FilterSize)
        {
            this.FilterSize = FilterSize;
        }
        
        public void Apply(Bitmap sourceImage, ref Bitmap destinationImage, PaddingType paddingType)
        {
            destinationImage = Apply(sourceImage, paddingType);
        }

        public Bitmap Apply(Bitmap sourceImage, PaddingType paddingType)
        {
          
            return ApplyWithPostProcessing(sourceImage, sourceImage.Width, sourceImage.Height);

        }
        
        protected RGB[,] ApplyFilter( Bitmap sourceImage, int origWidth, int origHeight)
        {
            UnsafeBitmap unsafeImage = new UnsafeBitmap(sourceImage);
            RGB[,] HorizontalBuffer = new RGB[origWidth, origHeight];
            RGB[,] VerticalBuffer = new RGB[origWidth, origHeight];

            unsafeImage.LockBitmap();
            for (int x = 0; x < origWidth; x++)
            {
                for (int y = 0; y < origHeight; y++)
                {
                    double blue = 0.0;
                    double red = 0.0;
                    double green = 0.0;
                    int BeginX = (x > this.FilterSize / 2) ? (x - this.FilterSize / 2) : 0;
                    int EndX = ((origWidth - x) > (this.FilterSize / 2)-1) ? (x + this.FilterSize / 2) : origWidth - 1;
                    
                    int iterator = (x >= (this.FilterSize / 2)) ? 0 :((this.FilterSize/2)-x);
                    for (int i = BeginX; i <= EndX; i++)
                    {
                        PixelData ImagePixels = unsafeImage.GetPixel(i, y);
                        blue += this.FilterValues[iterator] * (double)ImagePixels.Blue;
                        red += this.FilterValues[iterator] * (double)ImagePixels.Red;
                        green += this.FilterValues[iterator] * (double)ImagePixels.Green;
                        iterator++;
                    }
                    HorizontalBuffer[x, y] = new RGB(red, green, blue);
                 }
            }
   
            for (int x = 0; x < origWidth; x++)
            {
                for (int y = 0; y < origHeight; y++)
                {
                    double blue = 0.0;
                    double red = 0.0;
                    double green = 0.0;
                    int EndY = ((origHeight - y) > (this.FilterSize / 2)) ? (y + this.FilterSize / 2) : origHeight - 1;
                    int BeginY = (y > this.FilterSize / 2) ? (y - this.FilterSize / 2) : 0;
                    int iterator = (y >= (this.FilterSize / 2)) ? 0 : ((this.FilterSize / 2 )-y);
                    for (int i = BeginY; i <= EndY; i++)
                    {
                        PixelData ImagePixels = unsafeImage.GetPixel(x, i);
                        blue += (double)this.FilterValues[iterator] * (double)ImagePixels.Blue;
                        red += (double)this.FilterValues[iterator] * (double)ImagePixels.Red;
                        green += (double)this.FilterValues[iterator] * (double)ImagePixels.Green;
                        iterator++;
                    }
                    VerticalBuffer[x, y] = new RGB(red, green, blue);
                }
            }
            unsafeImage.UnlockBitmap();
            return VerticalBuffer;
        }

        abstract protected Bitmap ApplyWithPostProcessing(Bitmap paddedImage, int origWidth, int origHeight);
        abstract protected void ConstructFilter();
    }
}
