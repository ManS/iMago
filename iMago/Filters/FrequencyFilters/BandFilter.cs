using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace Filters.FrequencyFilters
{
    /// <summary>
    /// Band Filter
    /// </summary>
    public class BandFilter : IFrequencyFilter
    {
        /// <summary>
        /// Gets or sets the width of the band.
        /// </summary>
        /// <value>The width of the band.</value>
        public int BandWidth { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BandFilter"/> class.
        /// </summary>
        /// <param name="p_FreqImage">The p_ freq image.</param>
        /// <param name="p_FilterName">Name of the p_ filter.</param>
        /// <param name="p_FilteringType">Type of the p_ filtering.</param>
        /// <param name="p_N">The p_ N.</param>
        /// <param name="p_BandWidth">Width of the p_ band.</param>
        /// <param name="p_Radius">The p_ radius.</param>
        public BandFilter(FrequencyDomainImage p_FreqImage, FrequencyFilterName p_FilterName, FilteringType p_FilteringType, int p_N, int p_BandWidth, int p_Radius)
            : base(p_FreqImage, p_FilterName, p_FilteringType, p_Radius)
        {
            this.BandWidth = p_BandWidth;
            this.N = p_N;
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
            int xDiff = Math.Abs(u - xCenter);
            int yCenter = this.Height / 2;
            int yDiff = Math.Abs(v - yCenter);

            double Distance = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
            double RightBoundary = this.FilterRadius + (double)this.BandWidth / 2;
                        double LeftBoundary = this.FilterRadius - (double)this.BandWidth / 2;
            switch (this.FilterName)
            {
                case FrequencyFilterName.IdealFilter:
                    {
                       
                        if (Distance >= LeftBoundary && Distance <= RightBoundary)
                        {
                            
                            return 1;
                        }
                        else
                            return 0;                  
                    }
                   
                case FrequencyFilterName.ButterWorthFilter:
                    {
                         return (1f/(1+( Math.Pow(((Distance *BandWidth)/((Math.Pow(Distance,2)-Math.Pow(FilterRadius,2)))),2*N))));
                       
                    }

                case FrequencyFilterName.GaussianFilter:
                    {
                        return 1 - Math.Pow(Math.E,-1*Math.Pow(((Math.Pow(Distance,2)-Math.Pow(FilterRadius,2)))/(BandWidth*Distance),2));
                    }

                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}