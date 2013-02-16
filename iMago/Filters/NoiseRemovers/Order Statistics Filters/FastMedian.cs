using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Drawing;

namespace Filters.NoiseRemovers
{
  public  class FastMedian : IOrderFilter
    {
      public FastMedian(int filterSize,int Width,int Height)
          : base(filterSize)
      {
          this.Width = Width;
          this.Height = Height;
      }

        protected override Bitmap ApplyFilter()
        {
            throw new NotImplementedException();
        }
        public  void InitializeHistograms(ref List<int>[] histograms, int maskSize)
        {
            for (int i = 0; i < histograms.Length; i++)
            {
                histograms[i] = new List<int>();

                for (int j = 0; j < maskSize; j++)
                {
                    histograms[i].Add(this.MixedPixels[i, j]);
                }

            }
        }

        public  void InitializeH(ref UnsafeBitmap unsafeImage, ref List<List<int>> H, ref List<int>[] histogramList, int maskSize)
        {
            for (int i = 0; i < maskSize; i++)
            {
                H.Add(histogramList[i]);
            }
        }

        public  int GetMedian1(ref List<List<int>> H)
        {
            List<int> a = new List<int>(H[0]);
            for (int i = 1; i < H.Count; i++)
                a.AddRange(H[i]);
            a.Sort();
            return a[(H.Count * H.Count) / 2];

        }
        public  int getMax(ref List<List<int>> H)
        {
            List<int> a = new List<int>(H[0]);
            for (int i = 1; i < H.Count; i++)
                a.AddRange(H[i]);
            a.Sort();
            return a[(H.Count * H.Count) - 1];

        }
        public  int getMin(ref List<List<int>> H)
        {
            List<int> a = new List<int>(H[0]);
            for (int i = 1; i < H.Count; i++)
                a.AddRange(H[i]);
            a.Sort();
            return a[0];

        }
        public  PixelData getMidPoint(ref List<List<int>> H)
        {
            List<int> a = new List<int>(H[0]);
            for (int i = 1; i < H.Count; i++)
                a.AddRange(H[i]);
            a.Sort();

            PixelData min = this.reverseMixed[a[0]];
            PixelData max = this.reverseMixed[a[(H.Count * H.Count) - 1]];
            return new PixelData((byte)((max.Blue + min.Blue) / 2), (byte)((max.Red + min.Red) / 2), (byte)((max.Green + min.Green) / 2));

        }
        public Bitmap FastMedianFilter(Bitmap image, int maskSize, OrderStatisticsFiltersTypes type)
        {
            Bitmap paddedImage = ImagePadding.PaddingImage(image, maskSize, maskSize, PaddingType.Replication);
            
            UnsafeBitmap unSafeImage = new UnsafeBitmap(paddedImage); int r = maskSize / 2;
            UnsafeBitmap newUnsafeImage = new UnsafeBitmap(paddedImage.Width -maskSize, paddedImage.Height - maskSize);
            this.FillMixedArrays(paddedImage);

            unSafeImage.LockBitmap();
            newUnsafeImage.LockBitmap();
            
            List<int>[] histograms = new List<int>[paddedImage.Width];
            List<List<int>> H = new List<List<int>>();
            InitializeHistograms(ref histograms, maskSize);
            InitializeH(ref unSafeImage, ref H, ref histograms, maskSize);
            DateTime DT = DateTime.Now;
            for (int i = r; i < paddedImage.Height-r ; i++)
            {
                for (int j = r; j < paddedImage.Width-r ; j++)
                {
                    histograms[j + r].RemoveAt(0);
                    histograms[j + r].Add(this.MixedPixels[j, i]);
                    H.RemoveAt(0);
                    H.Add(histograms[j + r]);

                    int value = 0;
                    switch (type)
                    {
                        case  OrderStatisticsFiltersTypes.Median:
                            value = GetMedian1(ref H);
                            newUnsafeImage.SetPixel(j - r, i - r,this.reverseMixed[value]);
                            break;
                        case  OrderStatisticsFiltersTypes.Minimum:
                            value = getMin(ref H);
                            newUnsafeImage.SetPixel(j - r, i - r, this.reverseMixed[value]);
                            break;
                        case OrderStatisticsFiltersTypes.Maximum:
                            value = getMax(ref H);
                            newUnsafeImage.SetPixel(j - r, i - r, this.reverseMixed[value]);
                            break;
                        case OrderStatisticsFiltersTypes.MidPoint:
                            newUnsafeImage.SetPixel(j - r, i - r, getMidPoint(ref H));
                            break;
                    }

                }
            }
            newUnsafeImage.UnlockBitmap();
            unSafeImage.UnlockBitmap();
            DateTime T = DateTime.Now;
            int diff = (T - DT).Seconds;
            return newUnsafeImage.Bitmap;
        }
    }

}
