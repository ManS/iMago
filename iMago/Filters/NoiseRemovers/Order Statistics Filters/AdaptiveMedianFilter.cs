using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers
{
    class AdaptiveMedianFilter : IOrderFilter
    {
        public int maxkSize { get; set; }

        public AdaptiveMedianFilter(int filterSize, int p_maxSize)
            : base(filterSize)
        {
            this.maxkSize = p_maxSize;
            this.FilterSize = maxkSize;
        }

        protected override Bitmap ApplyFilter()
        {
            UnsafeBitmap finalImage = new UnsafeBitmap(this.Width, this.Height);
           
            finalImage.LockBitmap();

            for (int i = 0; i < this.Width ; i++)
            {
                for (int j = 0; j < this.Height ; j++)
                {
                    int centerPixel;
                    int currentSize = 3;
                    do
                    {
                        int[] currentWindow = this.GetWindowPixelsMedian(i, j, currentSize);

                        List<int> n = new List<int>(currentWindow);
                        n.Sort();

                        int Min = n[0];
                        int Median = n[ n.Count / 2];
                        int Max = n[n.Count - 1];

                        centerPixel = this.MixedPixels[i, j];

                        if (Median > Min && Median < Max) // Correct Median
                        {
                            if (centerPixel > Min && centerPixel < Max) // Not noise 
                            {
                                finalImage.SetPixel(i , j ,this.reverseMixed[this.MixedPixels[i,j]]);
                            }
                            else
                            {
                                finalImage.SetPixel(i , j,this.reverseMixed[Median]);
                            }
                            break;
                        }
                        // Noise ! ,, increase window size to get correct Median  

                        currentSize = currentSize + 2;
                        if (currentSize == maxkSize + 2)
                        {
                            finalImage.SetPixel(i , j, this.reverseMixed[Median]);
                        }
                    } while (currentSize <= maxkSize);
                }
            }
            finalImage.UnlockBitmap();
            return finalImage.Bitmap;
        }
    }
}
