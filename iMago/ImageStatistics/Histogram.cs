using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageStatistics;

namespace ImageStatistics
{
    public class Histogram
    {
        #region Properties
        public int Max { get; set; }
        public int Min { get; set; }
        public int Median { get; set; }
        public int[] Values { get; set; }
        public double StandardDeviation { get; set; }
        public double Mean { get; set; }
        #endregion

        #region Constructor
        public Histogram(int[] p_values)
        {
            this.Values = p_values;
            this.UpdateHistogram();
        }
        #endregion

        #region Methods
        public void UpdateHistogram()
        {
            this.Max = int.MinValue;
            this.Min = int.MaxValue;

            for (int i = 0; i < this.Values.Length; i++)
            {
                if (this.Max < this.Values[i])
                    this.Max = this.Values[i];

                if (this.Min > this.Values[i])
                    this.Min = this.Values[i];
            }
            this.Mean = Statistics.Mean(this.Values);
            this.Median = Statistics.Median(this.Values);
            this.StandardDeviation = Statistics.StandardDeviation(this.Values);

        }
        #endregion
    }
}
