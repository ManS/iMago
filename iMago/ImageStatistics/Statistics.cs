using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageStatistics
{
    public class Statistics
    {
        public static double Mean(int[] Values)
        {
            double mean = 0;
            double total = 0;
            for (int i = 0; i < Values.Length; i++)
            {
                mean += i * (Values[i]);
                total += Values[i];
            }
            return mean / total;
        }

        public static float Mean(int start, int end, float[] values, int width, int height)
        {
            float mean = 0;

            float groupProbability = 0;

            for (int i = start; i <= end; i++)
            {
                groupProbability += values[i];
                mean += values[i] * i;
            }
            mean /= groupProbability;
            return mean;
        }

        public static int Median(int[] Values)
        {
            int total = 0;
            for (int i = 0; i < Values.Length; i++)
            {
                total += Values[i];
            }

            int halfTotal = total / 2;
            int median = 0, v = 0;

            // find median value
            for (; median < Values.Length; median++)
            {
                v += Values[median];
                if (v >= halfTotal)
                    break;
            }
            return median;
        }

        public static double StandardDeviation(int[] Values)
        {
            double mean = 0;
            double stddev = 0;
            int total = 0;

            // for all values
            for (int i = 0, n = Values.Length; i < n; i++)
            {
                int value = Values[i];

                mean += i * value;

                stddev += i * i * value;

                total += value;
            }
            mean /= total;

            return Math.Sqrt(stddev / total - mean * mean);
        }
    }
}