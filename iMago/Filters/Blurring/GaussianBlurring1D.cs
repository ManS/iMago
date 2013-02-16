using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.Blurring
{
    /// <summary>
    /// 1D Gaussian Blurring Filter
    /// </summary>
    public class GaussianBlurring1D : I1DConvolution
    {
        /// <summary>
        /// Gets or sets the sigma.
        /// </summary>
        /// <value>The sigma.</value>
        public float Sigma { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GaussianBlurring1D"/> class.
        /// </summary>
        /// <param name="sigma">The sigma.</param>
        public GaussianBlurring1D(float sigma)
        {
            int N = (int)((3.7 * sigma) - 0.5);
            this.FilterSize = (2 * N) + 1;
            this.FilterValues = new double[FilterSize];
            this.Sigma = sigma;
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
            double e = (double)Math.E;
            int pos = 1;
            int neg = -((this.FilterSize - 1) / 2);
            int mid = (this.FilterSize - 1) / 2;
            for (int i = 0; i < mid; i++)
                this.FilterValues[i] = neg++;
            this.FilterValues[mid] = 0;
            for (int j = mid + 1; j < this.FilterSize; j++)
                this.FilterValues[j] = pos++;
            for (int i = 0; i < this.FilterSize; i++)
            {
                this.FilterValues[i] = (double)((1 / Math.Sqrt(2 * Math.PI * Math.Pow((double)this.Sigma, 2))) * (Math.Pow(e, -((Math.Pow((double)this.FilterValues[i], 2)) / (2 * Math.Pow((double)this.Sigma, 2))))));
            }
        }
    }
}
