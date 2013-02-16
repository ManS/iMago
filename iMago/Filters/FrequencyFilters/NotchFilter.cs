using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace Filters.FrequencyFilters
{
    /// <summary>
    /// Notch Filter
    /// </summary>
    public class NotchFilter : IFrequencyFilter
    {
        /// <summary>
        /// Gets or sets the center X.
        /// </summary>
        /// <value>The center X.</value>
        public int CenterX { get; set; }

        /// <summary>
        /// Gets or sets the center Y.
        /// </summary>
        /// <value>The center Y.</value>
        public int CenterY { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotchFilter"/> class.
        /// </summary>
        /// <param name="FreqImage">The freq image.</param>
        /// <param name="p_FilterName">Name of the p_ filter.</param>
        /// <param name="p_FilteringType">Type of the p_ filtering.</param>
        /// <param name="p_N">The p_ N.</param>
        /// <param name="p_Radius">The p_ radius.</param>
        /// <param name="p_CenterX">The p_ center X.</param>
        /// <param name="p_CenterY">The p_ center Y.</param>
        public NotchFilter(FrequencyDomainImage FreqImage, FrequencyFilterName p_FilterName, FilteringType p_FilteringType, int p_N, int p_Radius, int p_CenterX, int p_CenterY)
            : base(FreqImage,p_FilterName, p_FilteringType, p_Radius)
        {
            this.CenterX = p_CenterX;
            this.CenterY = p_CenterY;
            this.ConstructFilter();
        }

        /// <summary>
        /// Gets the filter value.
        /// </summary>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        /// <returns></returns>
        protected override double GetFilterValue(int u, int v)
        {
            int xCenter = this.Width / 2;
            int yCenter = this.Height / 2;

            int xDiff1 = Math.Abs(u - xCenter - CenterX);
            
            int yDiff1 = Math.Abs(v - yCenter-(CenterY));

            int xDiff2 = Math.Abs(u - xCenter +(CenterX));
     
            int yDiff2 = Math.Abs(v - yCenter +(CenterY));

            double Distance1 = Math.Sqrt(Math.Pow(xDiff1, 2) + Math.Pow(yDiff1, 2));
            double Distance2 = Math.Sqrt(Math.Pow(xDiff2, 2) + Math.Pow(yDiff2, 2));
            switch (this.FilterName)
            {
                case FrequencyFilterName.IdealFilter:
                    if (Distance1 <= this.FilterRadius || Distance2 <= this.FilterRadius)
                        return 0;
                    else
                        return 1;
                case FrequencyFilterName.ButterWorthFilter:
                    {
                     return  ((1f/(1+(Math.Pow((FilterRadius/Distance1),2*N))))*((1f/(1+(Math.Pow((FilterRadius/Distance2),2*N))))));
                    }
                case FrequencyFilterName.GaussianFilter:
                    break;
                default:
                    break;
            }

            throw new NotImplementedException();
        }
    }
}
