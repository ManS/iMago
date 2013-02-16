using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers
{
    class MidPointFilter :  IOrderFilter
    {
        public MidPointFilter(int filterSize)
            : base(filterSize)
        { }

        protected override Bitmap ApplyFilter()
        {
            UnsafeBitmap filteredImage = new UnsafeBitmap(this.Width, this.Height);
            filteredImage.LockBitmap();

            int a = this.FilterSize / 2;
            int b = this.FilterSize / 2;

            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    int[] WindowPixels = this.GetWindowPixels(x, y);
                    PixelData max = reverseMixed[WindowPixels.Max()];
                    PixelData min = reverseMixed[WindowPixels.Min()];
                    PixelData ResultPixel = new PixelData((byte)((max.Blue + min.Blue) / 2), (byte)((max.Red + min.Red) / 2), (byte)((max.Green + min.Green) / 2));
                    
                    filteredImage.SetPixel(x, y, ResultPixel);
                }
            }

            filteredImage.UnlockBitmap();
            return filteredImage.Bitmap;
        }
    }
}
