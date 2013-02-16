using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Drawing;

namespace Filters.Blurring
{
    /// <summary>
    /// 2D Mean Blurring Filter
    /// </summary>
    public class MeanBlurring2D : I2DConvolution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeanBlurring2D"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public MeanBlurring2D(int width, int height)
            : base(width, height)
        {
            this.ConstructFilter();
        }

        /// <summary>
        /// Applies the with post processing.
        /// </summary>
        /// <param name="PaddedImage">The padded image.</param>
        /// <param name="origWidth">Width of the orig.</param>
        /// <param name="origHeight">Height of the orig.</param>
        /// <returns></returns>
        protected override Bitmap ApplyWithPostProcessing(Bitmap PaddedImage, int origWidth, int origHeight)
        {
           
            RGB[,] filteredImage = base.ApplyFilter(PaddedImage, origWidth, origWidth);
            return PostProcessing.CutOff(filteredImage, 255, 0);
        }

        /// <summary>
        /// Constructs the filter.
        /// </summary>
        protected override void ConstructFilter()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    this.FilterValues[i, j] = (double)((double)1 / ((double)Width * (double)Height));
                }
            }
        }
    }
}
