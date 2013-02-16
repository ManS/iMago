using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.Blurring
{
    /// <summary>
    /// 2D Gaussian Blurring Filter
    /// </summary>
   public  class GaussianBlurring2D : I2DConvolution
    {

        /// <summary>
        /// Gets or sets the sigma.
        /// </summary>
        /// <value>The sigma.</value>
        public float Sigma { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GaussianBlurring2D"/> class.
        /// </summary>
        /// <param name="sigma">The sigma.</param>
        public GaussianBlurring2D(float sigma)
        {
           
            this.Sigma = sigma;
            int N = (int)((3.7 * sigma) - 0.5);
            this.Width = (2 * N) + 1;
            this.Height = (2 * N) + 1;
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
            RGB[,] filteredImage = base.ApplyFilter(paddedImage, origWidth, origWidth);
            return PostProcessing.CutOff(filteredImage, 255, 0);
        }

        /// <summary>
        /// Constructs the filter.
        /// </summary>
        protected override void ConstructFilter()
        {
            double[,] GaussianMask;

            float pi = (float)Math.PI;
            int i, j;
            int SizeofKernel = this.Width;
            double[,] Kernel = new double[this.Width, this.Width];
            GaussianMask = new double[this.Width, this.Width];
            float[,] OP = new float[this.Width, this.Width];
            float D1, D2;
            D1 = 1 / (2 * pi * Sigma * Sigma);
            D2 = 2 * Sigma * Sigma;
            double min = 1000.0;
            for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
            {
                for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
                {
                    Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = ((1 / D1) * (float)Math.Exp(-(i * i + j * j) / D2));
                    if (Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] < min)
                        min = Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                }
            }
            int mult = (int)(1 / min);
            double sum = 0.0;
            if ((min > 0) && (min < 1))
            {

                for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
                {
                    for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
                    {
                        Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (float)Math.Round(Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] * mult, 0);
                        GaussianMask[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (int)Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                        sum = sum + GaussianMask[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                    }
                }

            }
            else
            {
                sum = 0;
                for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
                {
                    for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
                    {
                        Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (float)Math.Round(Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j], 0);
                        GaussianMask[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (int)Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                        sum = sum + GaussianMask[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                    }

                }

            }
            //Normalizing kernel Weight
            for (int k = 0; k < SizeofKernel; k++)
            {
                for (int m = 0; m < SizeofKernel; m++)
                {
                    GaussianMask[k, m] = GaussianMask[k, m] / sum;
                }
            }
            this.FilterValues = GaussianMask;
        }
    }
}
