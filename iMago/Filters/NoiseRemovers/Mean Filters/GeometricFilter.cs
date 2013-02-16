using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers
{
   public class GeometricFilter : IMeanFilter
    {
        public GeometricFilter(int filterSize)
            : base(filterSize)
        { }

        protected override Bitmap ApplyFilter(UnsafeBitmap unsafePaddedImage, int origWidth, int origHeight)
        {
            int a = (this.FilterSize - 1) / 2;
            int b = (this.FilterSize - 1) / 2;
            UnsafeBitmap newUnsafeImage = new UnsafeBitmap(origWidth, origHeight);

            newUnsafeImage.LockBitmap();
            unsafePaddedImage.LockBitmap();
            for (int x = 0; x < origWidth; x++)
            {
                for (int y = 0; y < origHeight; y++)
                {
                    double blue = 1;
                    double red = 1;
                    double green = 1;
                    for (int i = -a; i <= a; i++)
                    {
                        for (int j = -b; j <= b; j++)
                        {
                            PixelData maskPixels = unsafePaddedImage.GetPixel(x + a + i, y + b + j);
                            if(blue>0)
                            blue *= (double)maskPixels.Blue;
                            if (red > 0)
                            red *= (double)maskPixels.Red;
                            if (green > 0)
                            green *= (double)maskPixels.Green;
                        }
                    }
                    double sqrFilterSize = this.FilterSize * this.FilterSize;
                    blue = Math.Pow(blue, (double)1.0 / sqrFilterSize);
                    green = Math.Pow(green, (double)1.0 / sqrFilterSize);
                    red = Math.Pow(red, (double)1.0 / sqrFilterSize);
                    
                    newUnsafeImage.SetPixel(x, y, new PixelData((byte)blue, (byte)red, (byte)green));
                }
            }
            newUnsafeImage.UnlockBitmap();
            unsafePaddedImage.UnlockBitmap();
            return newUnsafeImage.Bitmap;
        }
    }
}
