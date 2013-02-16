using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.EdgeDetectors
{

    /// <summary>
    /// PrewittCompass Edge detector Filters
    /// </summary>
   public class PrewittCompassEdgeDetectors : I2DConvolution
    {
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public FilterDirection Direction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrewittCompassEdgeDetectors"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="filterDirection">The filter direction.</param>
        public PrewittCompassEdgeDetectors(int width, int height, FilterDirection filterDirection) 
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
            int x = Width / 2;
            int y = Height / 2;
            switch (this.Direction)
            {
                case FilterDirection.Horizontal:
                        for (int i = 0; i < Width; i++)
                        {
                            for (int j = 0; j < Height; j++)
                            {
                                if (j == y)
                                {
                                    this.FilterValues[i, j] = 0;
                                }
                                else
                                    this.FilterValues[i, j] = j > y ? -1 : 1;
                            }
                        }
                    break;
                case FilterDirection.Vertical:
                    for (int i = 0; i < Width; i++)
                    {
                        for (int j = 0; j < Height; j++)
                        {
                            if (i == x)
                            {
                                this.FilterValues[i, j] = 0;
                            }
                            else
                                this.FilterValues[i, j] = i > x ? -1 : 1;
                        }
                    }
                    break;
                case FilterDirection.RightDiagonal:
                        for (int i = 0, k = 0; i < Width;k++, i++)
                        {
                            for (int j = 0; j <= k; j++)
                            {
                                this.FilterValues[i, j] = 1;
                            }
                        }
                        for (int i = 0, k = 0; i < Width; k++,i++)
                        {
                            for (int j = k ; j < Height; j++)
                            {
                                this.FilterValues[i, j] = -1;
                            }
                        }
                        for (int i = 0, j = 0; i < Width; i++,j++)
                        {
                            this.FilterValues[j, j] = 0;
                        }
                    break;
                case FilterDirection.LeftDiagonal:
                        for (int i = 0; i < Width; i++)
                        {
                            for (int k = Height - 1, j = 0; k >= i; k--, j++)
                            {
                                this.FilterValues[i, j] = 1;
                            }
                        }

                        for (int i = Width - 1, k = 0; i >= 0; i--, k++)
                        {
                            for (int j = k; j < Width; j++)
                            {
                                this.FilterValues[i, j] = -1;
                            }
                        }
                        for (int i = Height - 1, j = 0; i >= 0; i--, j++)
                            this.FilterValues[i, j] = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
