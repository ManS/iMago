using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters.NoiseRemovers
{
    /// <summary>
    /// Order Statistics Filters types
    /// </summary>
    public enum OrderStatisticsFiltersTypes
    {
        /// <summary>
        /// Median 
        /// </summary>
        Median,
        /// <summary>
        /// Minimum
        /// </summary>
        Minimum,
        /// <summary>
        /// Maximum
        /// </summary>
        Maximum,
        /// <summary>
        /// Midpoint
        /// </summary>
        MidPoint,
        /// <summary>
        /// AlphaTrim
        /// </summary>
        AlphaTrim,
        /// <summary>
        /// Adaptive
        /// </summary>
        Adaptive
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class OrderFiltersFactory
    {
        /// <summary>
        /// Gets the order filter.
        /// </summary>
        /// <param name="filterType">Type of the filter.</param>
        /// <param name="filterSize">Size of the filter.</param>
        /// <param name="maxWindowSize">Size of the max window.</param>
        /// <param name="d">The d.</param>
        /// <returns></returns>
      public  static IOrderFilter GetOrderFilter(OrderStatisticsFiltersTypes filterType,int filterSize, int maxWindowSize,int d)
        {
            switch (filterType)
            {
                case OrderStatisticsFiltersTypes.Median:
                    return new MedianFilter(filterSize);
                case OrderStatisticsFiltersTypes.Minimum:
                    return new MinimumFilter(filterSize);
                case OrderStatisticsFiltersTypes.Maximum:
                    return new MaximumFilter(filterSize);
                case OrderStatisticsFiltersTypes.MidPoint:
                    return new MidPointFilter(filterSize);
                case OrderStatisticsFiltersTypes.AlphaTrim:
                    return new AlphaTrim(filterSize,d);
                case OrderStatisticsFiltersTypes.Adaptive:
                    return new AdaptiveMedianFilter(filterSize, maxWindowSize);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
