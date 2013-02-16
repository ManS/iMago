using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.Sharping
{
    public class HighBoostFilter : I2DConvolution
    {
        public HighBoostFilter(int width, int height):base(width,height)
        {
            this.ConstructFilter();
        }

        protected override Bitmap ApplyWithPostProcessing(Bitmap paddedImage, int origWidth, int origHeight)
        {
            RGB[,] filteredImage = base.ApplyFilter(paddedImage, origWidth, origHeight);
            return PostProcessing.CutOff(filteredImage, 255, 0);
        }

        protected override void ConstructFilter()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    this.FilterValues[i, j] = -1;
                }
            }
            this.FilterValues[Width / 2, Height / 2] = (Width * Height - 1) + 2;
        }
    }
}