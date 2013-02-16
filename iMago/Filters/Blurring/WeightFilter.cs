using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Drawing;

namespace Filters.Blurring
{
    /// <summary>
    /// Weight Filter
    /// </summary>
    public  class WeightFilter:I2DConvolution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeightFilter"/> class.
        /// </summary>
        public WeightFilter()
        {
          this.FilterValues = new double[3, 3];
            this.Width = 3;
            this.Height = 3;
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

            this.FilterValues[0, 0] = 1 / 16f;
            this.FilterValues[0, 1] = 1 / 8f;
            this.FilterValues[0, 2] = 1 / 16f;
            this.FilterValues[1, 0] = 1 / 8f;
            this.FilterValues[1, 1] = 1 / 4f;
            this.FilterValues[1, 2] = 1 / 8f;
            this.FilterValues[2, 0] = 1 / 16f;
            this.FilterValues[2, 1] = 1 / 8f;
            this.FilterValues[2, 2] = 1 / 16f;

               
           
        }
    }
}
