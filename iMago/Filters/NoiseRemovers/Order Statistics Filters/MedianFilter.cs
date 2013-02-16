using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers
{
    class MedianFilter : IOrderFilter
    {
        public MedianFilter(int filterSize)
            : base(filterSize)
        { }

        protected override Bitmap ApplyFilter()
        {
            UnsafeBitmap filteredImage = new UnsafeBitmap(this.Width, this.Height);
            filteredImage.LockBitmap();
            
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    List<int> arr = this.GetWindowPixels(x, y).ToList<int>();
                    arr.Sort();
                    PixelData ResultPixel = reverseMixed[arr[arr.Count / 2]];
                    filteredImage.SetPixel(x, y, ResultPixel);
                }
            }
            filteredImage.UnlockBitmap();
            return filteredImage.Bitmap;
        }
    }
}