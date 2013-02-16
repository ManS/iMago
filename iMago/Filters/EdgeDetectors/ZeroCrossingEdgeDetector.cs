using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.EdgeDetectors
{
    /// <summary>
    /// Zero Crossing Edge Detector filter
    /// </summary>
    public class ZeroCrossingEdgeDetector : IFilter
    {
        /// <summary>
        /// Gets or sets the deviation1.
        /// </summary>
        /// <value>The deviation1.</value>
        public float Deviation1 { get; set; }
        
        /// <summary>
        /// Gets or sets the deviation2.
        /// </summary>
        /// <value>The deviation2.</value>
        public float Deviation2 { get; set; }

        /// <summary>
        /// Gets or sets the size of the filter.
        /// </summary>
        /// <value>The size of the filter.</value>
        public int FilterSize { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroCrossingEdgeDetector"/> class.
        /// </summary>
        /// <param name="deviation1">The deviation1.</param>
        /// <param name="deviation2">The deviation2.</param>
        /// <param name="size">The size.</param>
        public ZeroCrossingEdgeDetector(float deviation1, float deviation2, int size)
        {
            this.Deviation1 = deviation1;
            this.Deviation2 = deviation2;
            this.FilterSize = size;
        }

        /// <summary>
        /// Applies the specified source image.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="destinationImage">The destination image.</param>
        /// <param name="paddingType">Type of the padding.</param>
        public void Apply(Bitmap sourceImage, ref Bitmap destinationImage, PaddingType paddingType)
        {
            destinationImage = Apply(sourceImage, paddingType);
        }

        /// <summary>
        /// Applies the specified source image.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="paddingType">Type of the padding.</param>
        /// <returns></returns>
        public Bitmap Apply(Bitmap sourceImage, PaddingType paddingType)
        {
            Bitmap paddedImage = ImagePadding.PaddingImage(sourceImage, this.FilterSize, this.FilterSize, paddingType);
            LaplacianOfGaussian LOG = new LaplacianOfGaussian(this.FilterSize, this.FilterSize, this.Deviation1);
            Bitmap BlurredScale1 = LOG.Apply(sourceImage, paddingType);
            LOG = new LaplacianOfGaussian(this.FilterSize, this.FilterSize, this.Deviation2);
            Bitmap BlurredScale2 = LOG.Apply(sourceImage, paddingType);
            LaplacianEdgeDetector LaplacEdgeDetector = new LaplacianEdgeDetector(this.FilterSize, this.FilterSize);
            RGB[,] result1 = LaplacEdgeDetector.ApplyFilter((ImagePadding.PaddingImage(BlurredScale1, this.FilterSize, this.FilterSize, paddingType)), BlurredScale1.Width, BlurredScale1.Height);
            RGB[,] result2 = LaplacEdgeDetector.ApplyFilter((ImagePadding.PaddingImage(BlurredScale2, this.FilterSize, this.FilterSize, paddingType)), BlurredScale2.Width, BlurredScale2.Height);

            double[,] scale1Result = DetectZeroCrossing(result1);
            double[,] scale2Result = DetectZeroCrossing(result2);

            UnsafeBitmap finalResult = new UnsafeBitmap(sourceImage.Width, sourceImage.Height);
            finalResult.LockBitmap();
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    int scale = scale1Result[i, j] > 0 && scale2Result[i, j] > 0 ? 255 : 0;
                    finalResult.SetPixel(i, j, new PixelData((byte)scale, (byte)scale, (byte)scale));
                }
            }
            finalResult.UnlockBitmap();

            return finalResult.Bitmap;

        }

        /// <summary>
        /// Detects the zero crossing.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        private static double[,] DetectZeroCrossing(RGB[,] matrix)
        {
            double[,] res = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 1; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    res[i, j] = 0;
                    //left-right
                    if (matrix[i, j - 1].Red * matrix[i, j + 1].Red < 0)
                        res[i, j] = 1;
                    else if (matrix[i - 1, j].Red * matrix[i + 1, j].Red < 0)//top-down
                        res[i, j] = 1;
                    else if (matrix[i - 1, j - 1].Red * matrix[i + 1, j + 1].Red < 0)//upperleft-downright
                        res[i, j] = 1;
                    else if (matrix[i - 1, j + 1].Red * matrix[i + 1, j - 1].Red < 0)//upperright-downleft
                        res[i, j] = 1;
                }
            }
            return res;
        }
    }
}
