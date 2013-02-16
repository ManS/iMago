using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers
{
    public class AlphaTrim : IOrderFilter
    {
        public int d { get; set; }
        public AlphaTrim(int filterSize,int d)
            : base(filterSize)
        {
            this.d = d;
        }

        protected override Bitmap ApplyFilter()
        {
           
            RGB[,] ResultBuffer = new RGB[this.Width, this.Height];
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    List<int> arr = this.GetWindowPixelsMedian(x, y,FilterSize).ToList<int>();
                    arr.Sort();
                    
                    List<PixelData> ModifiedArr = new List<PixelData>();
                    int limit=(FilterSize*FilterSize)-(d/2);
                    if(arr.Count ==(FilterSize*FilterSize))
                    {
                        for (int i = (d / 2); i < limit; i++)
                            ModifiedArr.Add(reverseMixed[arr[i]]);
                       
                        double R = 0, G = 0, B = 0;
                        double value = (1.0 / ((FilterSize * FilterSize) - d));
                        for (int i = 0; i < ModifiedArr.Count; i++)
                        {
                            R += ModifiedArr[i].Red;
                            G += ModifiedArr[i].Green;
                            B += ModifiedArr[i].Blue;
                        }
                        R *= value;
                        G *= value;
                        B *= value;

                        ResultBuffer[x, y] = new RGB(R, G, B);
                    }
                    else
                    {
                        
                        double res=(double)(((double)arr.Count * (d / 2.0)) / (double)(FilterSize * FilterSize));

                        int newD=0;
                        double value = 0;
                        if (res - (int)res > 0.5)
                        {
                            newD = (int)Math.Round(res, 1) + 1;
                            value = (1.0 / ((arr.Count + 1) - (((newD) * 2))));
                            for (int i = newD; i <= arr.Count - newD; i++)
                                ModifiedArr.Add(reverseMixed[arr[i]]);
                        }
                        else
                        {
                            newD = (int)Math.Round(res, 1);
                            value = (1.0 / ((arr.Count) - (((newD) * 2))));
                            for (int i = newD; i < arr.Count - newD; i++)
                                ModifiedArr.Add(reverseMixed[arr[i]]);
                        }
                        double R=0, G=0, B=0;
                        for (int i = 0; i < ModifiedArr.Count; i++)
                        {
                            R += ModifiedArr[i].Red;
                            G+= ModifiedArr[i].Green;
                            B += ModifiedArr[i].Blue;
                        }
                        R *= value;
                        G *= value;
                        B *= value;

                        ResultBuffer[x, y] = new RGB(R, G, B);
                    }
                }
            }
            return PostProcessing.CutOff(ResultBuffer,255,0);
        }
    }
}