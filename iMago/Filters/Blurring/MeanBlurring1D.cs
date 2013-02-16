using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.Blurring
{
    /// <summary>
    /// 1D Mean Blurring Filter
    /// </summary>
    public class MeanBlurring1D : I1DConvolution
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MeanBlurring1D"/> class.
        /// </summary>
        /// <param name="filterSize">Size of the filter.</param>
        public MeanBlurring1D(int filterSize)
            : base(filterSize)
        {
            this.FilterValues = new double[filterSize];
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
            RGB[,] filteredImage = base.ApplyFilter(PaddedImage, origWidth, origHeight);
            return PostProcessing.Normalization(filteredImage, 255, 0);
        }

        /// <summary>
        /// Constructs the filter.
        /// </summary>
        protected override void ConstructFilter()
        {
            for (int i = 0; i < this.FilterSize; i++)
            {
                this.FilterValues[i] = (double)(1 / (double)this.FilterSize);
            }
        }
    }
}
