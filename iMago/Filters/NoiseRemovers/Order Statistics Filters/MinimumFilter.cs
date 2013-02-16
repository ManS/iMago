using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers
{
    class MinimumFilter : IOrderFilter
    {
        public MinimumFilter(int filterSize):base(filterSize)
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
                    int[] WindowArray = this.GetWindowPixels(x, y);
                    filteredImage.SetPixel(x,y,reverseMixed[WindowArray.Min()]);
                }
            }

            filteredImage.UnlockBitmap();
            return filteredImage.Bitmap;
        }
    }
}
