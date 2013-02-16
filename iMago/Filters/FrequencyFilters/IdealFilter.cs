using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace Filters.FrequencyFilters
{
    /// <summary>
    /// Ideal Filter
    /// </summary>
    public class IdealFilter : IFrequencyFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdealFilter"/> class.
        /// </summary>
        /// <param name="p_freqImage">The p_freq image.</param>
        /// <param name="p_filterRadius">The p_filter radius.</param>
        /// <param name="p_filterType">Type of the p_filter.</param>
        /// <param name="p_filterName">Name of the p_filter.</param>
        public IdealFilter(FrequencyDomainImage p_freqImage, int p_filterRadius, FilteringType p_filterType, FrequencyFilterName p_filterName)
            : base(p_freqImage, p_filterName, p_filterType, p_filterRadius)
        {
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
            if ((int)Distance > this.FilterRadius)
                return 0;
            return 1;
        }
    }

}
