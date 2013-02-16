using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using Utilities;

namespace Filters.FrequencyFilters
{
   public enum FilteringType
    {
        LowPass,
        HighPass,
        BandPass,
        BandReject,
        NotchPass,
        NotchReject
    }
    
   public enum FrequencyFilterName
    {
        IdealFilter,
        ButterworthFilter,
        GaussianFilter
    }
    
   public enum DomainType
    {
        FrequencyDomain,
        SpatialDomain
    }
   
   public class FrequencyDomainFilter
    {
        #region Attributes
        private int filterRadius;
        private int width;
        private int height;
        private int n;
        private FilteringType filterType;
        private FrequencyFilterName filterName;
        #endregion

        #region Properties
        public int FilterRadius
        {
            get { return filterRadius; }
            set { 
                  filterRadius = value;
                  }
        }
        public int Width { get; private set; }
        public int Height { get; private  set; }
        
        public int N
        {
            get { return n; }
            set
            {
                n = value;
            }
        }
        public double[,] Filter { get; set; }
        public FilteringType FilterType
        {
            get { return filterType; }
            set
            {
                filterType = value;
            }
        }
        public FrequencyFilterName FilterName
        {
            get { return filterName; }
            set
            {
                filterName = value;
            }
        }
        public FrequencyDomainImage FreqImage { get; set; }
        #endregion

        #region Constructor
        public FrequencyDomainFilter()
        {
            this.FilterRadius = 0;
            this.Width = 0;
            this.Height = 0;
            this.N = 0;
        }
        public FrequencyDomainFilter(int p_width, int p_height)
        {
            this.width = p_width;
            this.height = p_height;
        }
        public FrequencyDomainFilter(FrequencyDomainImage freqImage ,int p_filterRadius, int p_N, FilteringType p_filterType, FrequencyFilterName p_filterName)
        {
            this.FreqImage = freqImage;
            this.Width = freqImage.Width;
            this.Height = freqImage.Height;
            this.filterRadius = p_filterRadius;
            this.n = p_N;
            this.Filter = new double[this.Width, this.Height];
            this.filterType = p_filterType;
            this.filterName = p_filterName;
           
        }
        #endregion

        #region Methods
        public void ConstructFilter()
        {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    switch (this.FilterType)
                    {
                        case FilteringType.LowPass:
                            this.Filter[i, j] = this.GetFilterValue(i, j);
                            break;
                        case FilteringType.HighPass:
                            this.Filter[i, j] = 1 - this.GetFilterValue(i, j);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private double GetFilterValue(int u, int v)
        {
            int xCenter = this.Width / 2;
            int xDiff = Math.Abs(u - xCenter);
            int yCenter = this.Height / 2;
            int yDiff = Math.Abs(v - yCenter);

            double Distance = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));

            switch (this.FilterName)
            {
                case FrequencyFilterName.IdealFilter:
                    if ((int)Distance > this.FilterRadius)
                        return 0;
                    return 1;
                case FrequencyFilterName.ButterworthFilter:
                    return 1.0 / (1.0 + Math.Pow((Distance / (double)this.FilterRadius), 2 * this.N));
                case FrequencyFilterName.GaussianFilter:
                    return Math.Pow(Math.E, (-1 * Distance * Distance) / (2 * this.FilterRadius * this.FilterRadius));
                default:
                    throw new NotImplementedException();
            }
        }
        public Bitmap GetMaskPreviewImage()
        {
            this.ConstructFilter();
            UnsafeBitmap maskPreviewImage = new UnsafeBitmap(this.Width, this.Height);
            maskPreviewImage.LockBitmap();

            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    double pixelValue = 255.0 * this.Filter[i, j];
                    maskPreviewImage.SetPixel(i, j, new PixelData((byte)pixelValue, (byte)pixelValue, (byte)pixelValue));
                }
            }
            maskPreviewImage.UnlockBitmap();
            return maskPreviewImage.Bitmap;
        }
        private FrequencyDomainImage ApplyFilter(FrequencyDomainImage freqImage)
        {
            this.FreqImage = new FrequencyDomainImage(freqImage.Width, freqImage.Height);
            this.ConstructFilter();
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    FreqImage.Blue.Real[i, j] = freqImage.Blue.Real[i,j] * this.Filter[i, j];
                    FreqImage.Blue.Imaginary[i, j] = freqImage.Blue.Imaginary[i, j] * this.Filter[i, j];

                    FreqImage.Red.Real[i, j] = freqImage.Red.Real[i, j] * this.Filter[i, j];
                    FreqImage.Red.Imaginary[i, j] = freqImage.Red.Imaginary[i, j] * this.Filter[i, j];

                    FreqImage.Green.Real[i, j] = freqImage.Green.Real[i, j] * this.Filter[i, j];
                    FreqImage.Green.Imaginary[i, j] = freqImage.Green.Imaginary[i, j] * this.Filter[i, j];
                }
            }
            return this.FreqImage;
        }
        public Bitmap ApplyFilter(FrequencyDomainImage Image, DomainType domainType)
        {
            switch (domainType)
            {
                case DomainType.FrequencyDomain:
                    return this.ApplyFilter(Image).GetMagnitudeImage();
                case DomainType.SpatialDomain:
                    {
                        //if (this.filterName == FrequencyFilterName.GaussianFilter)
                        //    return HistogramOperations.Normalization(FourierTransformer.InverseFourierToMatlab(this.ApplyFilter(Image)), 255, 0).Bitmap;
                        //else
                            //return  FourierTransformer.InverseFourierTransform(this.ApplyFilter(Image));
                        return PostProcessing.Normalization(FourierTransformer.InverseFourierToMatlab(this.ApplyFilter(Image)), 255, 0).Bitmap;
                    }
                default:
                    throw new NotSupportedException();
            }
        }
        public Bitmap ApplyFilter(Bitmap Image)
        {
            this.ConstructFilter();
            UnsafeBitmap maskPreviewImage = new UnsafeBitmap(Image);
            maskPreviewImage.LockBitmap();

            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    PixelData currentPixel = maskPreviewImage.GetPixel(i,j);
                    maskPreviewImage.SetPixel(i, j, new PixelData((byte)(this.Filter[i, j] * currentPixel.Blue), (byte)(this.Filter[i, j] * currentPixel.Red), (byte)(this.Filter[i, j] * currentPixel.Green)));
                }
            }
            maskPreviewImage.UnlockBitmap();
            return maskPreviewImage.Bitmap;
        }
        #endregion
    }
}
