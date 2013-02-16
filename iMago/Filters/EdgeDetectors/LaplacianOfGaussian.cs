using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.EdgeDetectors
{
    /// <summary>
    /// Laplacian Of Gaussian filter
    /// </summary>
    public class LaplacianOfGaussian : I2DConvolution
    {
        /// <summary>
        /// Gets or sets the sigma.
        /// </summary>
        /// <value>The sigma.</value>
        public double Sigma { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LaplacianOfGaussian"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="sigma">The sigma.</param>
        public LaplacianOfGaussian(int width, int height, double sigma)
            : base(width, height)
        {
            this.Sigma = sigma;
            this.ConstructFilter();
        }

        /// <summary>
        /// Applies the with post processing.
        /// </summary>
        /// <param name="paddedImage">The padded image.</param>
        /// <param name="origWidth">Width of the orig.</param>
        /// <param name="origHeight">Height of the orig.</param>
        /// <returns></returns>
        protected override Bitmap ApplyWithPostProcessing(Bitmap paddedImage, int origWidth, int origHeight)
        {
            RGB[,] filteredImage = base.ApplyFilter(paddedImage, origWidth, origHeight);
            return PostProcessing.Normalization(filteredImage, 255, 0);
        }

        /// <summary>
        /// Constructs the filter.
        /// </summary>
        protected override void ConstructFilter()
        {
            double pm = this.Width / 2;
            int min = -this.Width / 2;
            int max = this.Width / 2;
            int xCount = 0;
            int yCount = 0;

            for (int i = min; i <= max; i++)
            {
                yCount = 0;
                for (int j = min; j <= max; j++)
                {

                    this.FilterValues[xCount, yCount] = (-1.0 / (Math.PI * this.Sigma * this.Sigma * this.Sigma * this.Sigma)) * (1 - ((i * i + j * j) / (2 * this.Sigma * this.Sigma))) * Math.Exp(-(i * i + j * j) / (2 * this.Sigma * this.Sigma));
                    yCount++;
                }
                xCount++;
            }
        }
    }
}
