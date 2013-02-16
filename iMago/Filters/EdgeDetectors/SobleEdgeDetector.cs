using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.EdgeDetectors
{
    /// <summary>
    /// Soble Edge detector Filter
    /// </summary>
    public class SobleEdgeDetector : I2DConvolution
    {
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public FilterDirection Direction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SobleEdgeDetector"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filterDirection">The filter direction.</param>
        public SobleEdgeDetector(int width, int height, FilterDirection filterDirection)
            : base(width, height)
        {
            this.Direction = filterDirection;
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
            int start = -1 * (Width / 2);
            int temp;

            switch (this.Direction)
            {
                case FilterDirection.Vertical:
                    {
                        this.FilterValues[0, 0] = -1;
                        this.FilterValues[0, 1] = -2;
                        this.FilterValues[0, 2] = -1;
                        this.FilterValues[1, 0] = 0;
                        this.FilterValues[1, 1] = 0;
                        this.FilterValues[1, 2] = 0;
                        this.FilterValues[2, 0] = 1;
                        this.FilterValues[2, 1] = 2;
                        this.FilterValues[2, 2] = 1;
                    }
                    //for (int i = 0; i < Width; i++)
                    //{
                    //    temp = start;
                    //    for (int j = 0; j < Height; j++)
                    //    {
                    //        if (i <= Width / 2)
                    //           this.FilterValues[i, j] = temp + j*(i+1) ;
                    //        else
                    //            this.FilterValues[i, j] = temp + j * (((Height - 1) - i) + 1);
                    //    }
                    //    if (i < Width / 2)
                    //        start -= Width / 2;
                    //    else
                    //        start += Width / 2;
                    //}
                    break;
                case FilterDirection.Horizontal:
                    {
                        this.FilterValues[0, 0] = -1;
                        this.FilterValues[0, 1] = 0;
                        this.FilterValues[0, 2] = 1;
                        this.FilterValues[1, 0] = -2;
                        this.FilterValues[1, 1] = 0;
                        this.FilterValues[1, 2] = 2;
                        this.FilterValues[2, 0] = -1;
                        this.FilterValues[2, 1] = 0;
                        this.FilterValues[2, 2] = 1;

                    }
                    //for (int i = 0; i < Height; i++)
                    //{
                    //    temp = start;
                    //    for (int j = 0; j < Width; j++)
                    //    {
                    //        if (i <= Width / 2)
                    //            this.FilterValues[j, i] = temp + j * (j + 1);
                    //        else
                    //            this.FilterValues[i, i] = temp + j * (((Width - 1) - j) + 1);
                    //    }
                    //    if (i < Height / 2)
                    //        start -= Height / 2;
                    //    else
                    //        start += Height / 2;
                    //}
                    break;
                case FilterDirection.RightDiagonal:
                    for (int i = 0; i < Width; i++)
                    {
                        temp = start;
                        for (int j = 0; j < Height; j++)
                        {
                            if (i <= Width / 2)
                                this.FilterValues[i, j] = temp + j;
                        }
                        start += 1;
                    }
                    break;
                case FilterDirection.LeftDiagonal:
                    for (int i = 0; i < Width; i++)
                    {
                        temp = start;
                        for (int j = 0; j < Height; j++)
                        {
                            this.FilterValues[i, j] = temp + j;
                        }
                        start -= 1;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
