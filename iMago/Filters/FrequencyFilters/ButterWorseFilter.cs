using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace Filters.FrequencyFilters
{
    /// <summary>
    /// ButterWorth Filter
    /// </summary>
    public class ButterWorthFilter : IFrequencyFilter
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ButterWorthFilter"/> class.
        /// </summary>
        /// <param name="p_freqImage">The p_freq image.</param>
        /// <param name="p_filterRadius">The p_filter radius.</param>
        /// <param name="p_N">The p_ N.</param>
        /// <param name="p_filterType">Type of the p_filter.</param>
        /// <param name="p_filterName">Name of the p_filter.</param>
        public ButterWorthFilter(FrequencyDomainImage p_freqImage, int p_filterRadius, int p_N, FilteringType p_filterType, FrequencyFilterName p_filterName)
            : base(p_freqImage, p_filterName, p_filterType, p_filterRadius)
        {
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

            return 1.0 / (1.0 + Math.Pow((Distance / (double)this.FilterRadius), 2 * this.N));
        }
    }

}
