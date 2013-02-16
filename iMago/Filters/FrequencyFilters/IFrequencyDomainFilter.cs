using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;
using MatlabLibrary;

namespace Filters.FrequencyFilters
{
    
    class FrequencyFilter
    {
        public int Width { get;  set; }
        public int Height { get;  set; }
        public FrequencyDomainImage FreqImage { get; set; }
        public FrequencyFilterName FilterName { get; set; }
        public double[,] Filter { get; set; }
        public int FilterRadius { get; set; }
        public FilteringType FilteringType { get; set; }
        public int N { get; set; }

        
        public FrequencyFilter()
        { }
        public FrequencyFilter(FrequencyFilterName p_FilterName, FilteringType p_FilteringType, int p_N, int p_Width, int p_Height, int p_Radius)
        {
            
            this.Width = p_Width;
            this.Height = p_Height;
            this.FilterRadius = p_Radius;
            this.FilterName = p_FilterName;
            this.FilteringType = p_FilteringType;
            this.N = p_N;
            Filter = new double[p_Width, p_Height];

        }

        virtual public Bitmap GetMaskPreviewImage()
        {
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
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    FreqImage.Blue.Real[i, j] = freqImage.Blue.Real[i, j] * this.Filter[i, j];
                    FreqImage.Blue.Imaginary[i, j] = freqImage.Blue.Imaginary[i, j] * this.Filter[i, j];

                    FreqImage.Red.Real[i, j] = freqImage.Red.Real[i, j] * this.Filter[i, j];
                    FreqImage.Red.Imaginary[i, j] = freqImage.Red.Imaginary[i, j] * this.Filter[i, j];

                    FreqImage.Green.Real[i, j] = freqImage.Green.Real[i, j] * this.Filter[i, j];
                    FreqImage.Green.Imaginary[i, j] = freqImage.Green.Imaginary[i, j] * this.Filter[i, j];
                }
            }
            return this.FreqImage;
        }
        virtual public Bitmap ApplyFilter(FrequencyDomainImage Image, DomainType domainType)
        {
            switch (domainType)
            {
                case DomainType.FrequencyDomain:
                    return this.ApplyFilter(Image).GetMagnitudeImage();
                case DomainType.SpatialDomain:
                    {
                        return PostProcessing.Normalization(FourierTransformer.InverseFourierToMatlab(this.ApplyFilter(Image)), 255, 0).Bitmap;
                    }
                default:
                    throw new NotSupportedException();
            }
        }
        virtual public void ConstructFilter()
        { }
    }



    /*
    class IdealFilter : IFrequencyDomainFilter
    {
        public void ConstructFilter()
        {
            throw new NotImplementedException();
        }

        public Bitmap GetMaskPreviewImage()
        {
            throw new NotImplementedException();
        }


        public Bitmap ApplyFilter(FrequencyDomainImage Image, DomainType domainType)
        {
            throw new NotImplementedException();
        }
    }
    */
    /**  class ButterworthFilter : FrequencyFilter, IFrequencyDomainFilter
    {
        public int N { get; set; }

        public ButterworthFilter(int p_N , int p_Width, int p_Height, int p_Radius)
        {
            
        }
        public void ConstructFilter()
        {
            throw new NotImplementedException();
        }

        public Bitmap GetMaskPreviewImage()
        {
            throw new NotImplementedException();
        }


        public Bitmap ApplyFilter(FrequencyDomainImage Image, DomainType domainType)
        {
            throw new NotImplementedException();
        }
    }
    */
}
