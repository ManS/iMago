using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Filters.FrequencyFilters;
using Utilities;

namespace Filters
{
    /// <summary>
    /// Homomorphic Filter
    /// </summary>
   public class HomomorphicFilter: IFrequencyFilter
    {

        float lowGain, highGain,c;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomomorphicFilter"/> class.
        /// </summary>
        /// <param name="p_freqImage">The p_freq image.</param>
        /// <param name="p_FilterName">Name of the p_ filter.</param>
        /// <param name="p_FilteringType">Type of the p_ filtering.</param>
        /// <param name="c">The c.</param>
        /// <param name="p_Radius">The p_ radius.</param>
        /// <param name="lowGain">The low gain.</param>
        /// <param name="hightGain">The hight gain.</param>
        public HomomorphicFilter(FrequencyDomainImage p_freqImage, FrequencyFilterName p_FilterName, FilteringType p_FilteringType,float c, int p_Radius ,float lowGain,float hightGain)
            : base(p_freqImage, p_FilterName, p_FilteringType, p_Radius)
        {

            this.lowGain = lowGain;
            this.highGain = hightGain;
            this.c = c;
            this.ConstructFilter();
        }

        /// <summary>
        /// Constructs the filter.
        /// </summary>
        override protected void ConstructFilter()
        {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    this.Filter[i, j] = this.GetFilterValue(i, j);
                }
            }

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
            double value=-1*c*(Math.Pow(Distance,2))/(Math.Pow(FilterRadius,2));
          return   this.lowGain + (((highGain -lowGain)) *(1f - Math.Pow(Math.E,value)));
          
        }
    }
}
