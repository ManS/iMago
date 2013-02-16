using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters
{
    public enum FilterDirection
    {
        Horizontal,
        Vertical,
        RightDiagonal,
        LeftDiagonal
    }

    abstract public class I2DConvolution : IFilter
    {
        public double[,] FilterValues { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public I2DConvolution(int width, int height)
        {
            this.FilterValues = new double[width, height];
            this.Width = width; 
            this.Height = height;
        }
        public I2DConvolution()
        { }
        
        public void Apply(Bitmap sourceImage, ref Bitmap destinationImage, PaddingType paddingType)
        {
            destinationImage = Apply(sourceImage, paddingType);
        }
        
        public Bitmap Apply(Bitmap sourceImage, PaddingType paddingType)
        {
            return ApplyWithPostProcessing(ImagePadding.PaddingImage(sourceImage, Width, Height, paddingType), sourceImage.Width, sourceImage.Height);
        }

        public RGB[,] ApplyFilter(Bitmap paddedImage, int origWidth, int origHeight)
        {
            UnsafeBitmap unsafePaddedImage = new UnsafeBitmap(paddedImage);
            RGB[,] resultBuffer = new RGB[origWidth, origHeight];
            int xMask = this.FilterValues.GetLength(0);
            int yMask = this.FilterValues.GetLength(1);

            unsafePaddedImage.LockBitmap();
            int a = (xMask - 1) / 2;
            int b = (yMask - 1) / 2;

            for (int x = 0; x < origWidth; x++)
            {
                for (int y = 0; y < origHeight; y++)
                {
                    double blue = 0.0;
                    double red = 0.0;
                    double green = 0.0;
                    for (int i = -a; i <= a; i++)
                    {
                        for (int j = -b; j <= b; j++)
                        {
                            PixelData maskPixels = unsafePaddedImage.GetPixel(x + a + i, y + b + j);
                            blue += ((double)FilterValues[i + a, j + b] * (double)maskPixels.Blue);
                            red += ((double)FilterValues[i + a, j + b] * (double)maskPixels.Red);
                            green += ((double)FilterValues[i + a, j + b] * (double)maskPixels.Green);
                        }
                    }
                    resultBuffer[x, y] = new RGB(red, green, blue);
                }
            }
            unsafePaddedImage.UnlockBitmap();
            return resultBuffer;
        }

        public Bitmap ApplyWithoutPostProcessing(Bitmap sourceImage, PaddingType paddingType)
        {
            return ApplyFilterWithoutPostProcessing((ImagePadding.PaddingImage(sourceImage, Width, Height, paddingType)),sourceImage.Width,sourceImage.Height);
        }
        private Bitmap ApplyFilterWithoutPostProcessing(Bitmap paddedImage, int origWidth, int origHeight)
        {
            UnsafeBitmap unsafePaddedImage = new UnsafeBitmap(paddedImage);
            UnsafeBitmap newUnsafePaddedImage = new UnsafeBitmap(origWidth, origHeight);
           
            int xMask = this.FilterValues.GetLength(0);
            int yMask = this.FilterValues.GetLength(1);
            newUnsafePaddedImage.LockBitmap();
            unsafePaddedImage.LockBitmap();
            int a = (xMask - 1) / 2;
            int b = (yMask - 1) / 2;

            for (int x = 0; x < origWidth; x++)
            {
                for (int y = 0; y < origHeight; y++)
                {
                    double blue = 0.0;
                    double red = 0.0;
                    double green = 0.0;
                    for (int i = -a; i <= a; i++)
                    {
                        for (int j = -b; j <= b; j++)
                        {
                            PixelData maskPixels = unsafePaddedImage.GetPixel(x + a + i, y + b + j);
                            blue += ((double)FilterValues[i + a, j + b] * (double)maskPixels.Blue);
                            red += ((double)FilterValues[i + a, j + b] * (double)maskPixels.Red);
                            green += ((double)FilterValues[i + a, j + b] * (double)maskPixels.Green);
                           
                        }
                    }
                    newUnsafePaddedImage.SetPixel(x, y, new PixelData((byte)blue, (byte)red, (byte)green));
                   
                }
            }
            unsafePaddedImage.UnlockBitmap();
            newUnsafePaddedImage.UnlockBitmap();
            return newUnsafePaddedImage.Bitmap;
        }

        abstract protected Bitmap ApplyWithPostProcessing(Bitmap PaddedImage, int origWidth, int origHeight);

        abstract protected void ConstructFilter();
    }
}
