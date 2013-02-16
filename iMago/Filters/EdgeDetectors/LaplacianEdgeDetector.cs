using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Drawing;

namespace Filters.EdgeDetectors
{
    /// <summary>
    /// Laplacian Edge detector filter
    /// </summary>
   public class LaplacianEdgeDetector : I2DConvolution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaplacianEdgeDetector"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public LaplacianEdgeDetector(int width, int height):base(width,height)
        { this.ConstructFilter(); }

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
            for (int i = 0; i < this.Width ; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    this.FilterValues[i, j] = -1;
                }
            }
            this.FilterValues[Width / 2, Height / 2] = Width * Height - 1;
        }
    }
}