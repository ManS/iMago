using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;
using Matlab;


namespace Filters.FrequencyFilters
{
    /// <summary>
    /// Filtering Types
    /// </summary>
    public enum FilteringType
    {
        /// <summary>
        ///
        /// </summary>
        Pass,
        /// <summary>
        /// 
        /// </summary>
        Reject,
        /// <summary>
        /// 
        /// </summary>
        Lowpass
    }

    /// <summary>
    /// Frequency filters
    /// </summary>
    public enum FrequencyFilterName
    {
        /// <summary>
        /// Ideal Filter
        /// </summary>
        IdealFilter,
        /// <summary>
        /// ButterWorth Filter
        /// </summary>
        ButterWorthFilter,
        /// <summary>
        /// Gaussian Filter
        /// </summary>
        GaussianFilter
    }

    /// <summary>
    /// Domain Type
    /// </summary>
    public enum DomainType
    {
        /// <summary>
        /// Frequency Domain
        /// </summary>
        FrequencyDomain,
        /// <summary>
        /// Spatial Domain
        /// </summary>
        SpatialDomain
    }

    /// <summary>
    /// abstract Base Class for Frequency filters
    /// </summary>
    abstract public class IFrequencyFilter
    {
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get;  set; }
       
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get;  set; }
        
        /// <summary>
        /// Gets or sets the freq image.
        /// </summary>
        /// <value>The freq image.</value>
        public FrequencyDomainImage FreqImage { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the filter.
        /// </summary>
        /// <value>The name of the filter.</value>
        public FrequencyFilterName FilterName { get; set; }
       
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>The filter.</value>
        public double[,] Filter { get; set; }
       
        /// <summary>
        /// Gets or sets the type of the filtering.
        /// </summary>
        /// <value>The type of the filtering.</value>
        public FilteringType FilteringType { get; set; }
        
        /// <summary>
        /// Gets or sets the filter radius.
        /// </summary>
        /// <value>The filter radius.</value>
        public int FilterRadius { get; set; }
       
        /// <summary>
        /// Gets or sets the N.
        /// </summary>
        /// <value>The N.</value>
        public int N { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IFrequencyFilter"/> class.
        /// </summary>
        public IFrequencyFilter()
        { }
     
        /// <summary>
        /// Initializes a new instance of the <see cref="IFrequencyFilter"/> class.
        /// </summary>
        /// <param name="p_FreqImage">The p_ freq image.</param>
        /// <param name="p_FilterName">Name of the p_ filter.</param>
        /// <param name="p_FilteringType">Type of the p_ filtering.</param>
        /// <param name="p_raduis">The p_raduis.</param>
        public IFrequencyFilter(FrequencyDomainImage p_FreqImage, FrequencyFilterName p_FilterName, FilteringType p_FilteringType, int p_raduis)
        {
            this.FreqImage = p_FreqImage;
            this.Width = p_FreqImage.Width;
            this.Height = p_FreqImage.Height;
            this.FilterName = p_FilterName;
            this.FilteringType = p_FilteringType;
            this.FilterRadius = p_raduis;
            Filter = new double[this.Width, this.Height];
        }
      
        /// <summary>
        /// Initializes a new instance of the <see cref="IFrequencyFilter"/> class.
        /// </summary>
        /// <param name="p_FreqImage">The p_ freq image.</param>
        /// <param name="p_FilterName">Name of the p_ filter.</param>
        /// <param name="p_FilteringType">Type of the p_ filtering.</param>
        /// <param name="p_raduis">The p_raduis.</param>
        /// <param name="p_n">The P_N.</param>
        public IFrequencyFilter(FrequencyDomainImage p_FreqImage, FrequencyFilterName p_FilterName, FilteringType p_FilteringType, int p_raduis, int p_n)
        :this(p_FreqImage,p_FilterName,p_FilteringType,p_raduis)
        {
            this.N = p_n;
        }

        /// <summary>
        /// Gets the mask preview image.
        /// </summary>
        /// <returns></returns>
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
       
        /// <summary>
        /// Applies the filter.
        /// </summary>
        /// <param name="freqImage">The freq image.</param>
        /// <returns></returns>
        private FrequencyDomainImage ApplyFilter(FrequencyDomainImage freqImage)
        {
            //this.ConstructFilter();
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
      
        /// <summary>
        /// Applies the filter.
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="domainType">Type of the domain.</param>
        /// <returns></returns>
        public Bitmap ApplyFilter(FrequencyDomainImage Image, DomainType domainType)
        {
            this.ConstructFilter();
            switch (domainType)
            {
                case DomainType.FrequencyDomain:
                    return this.ApplyFilter(Image).GetMagnitudeImage();
                case DomainType.SpatialDomain:
                    {
                        if (this.FilteringType == FrequencyFilters.FilteringType.Lowpass)
                            return PostProcessing.CutOff(FourierTransformer.InverseFourierToMatlab(this.ApplyFilter(Image)), 255, 0).Bitmap;
                        return PostProcessing.Normalization(FourierTransformer.InverseFourierToMatlab(this.ApplyFilter(Image)), 255, 0).Bitmap;
                    }
                default:
                    throw new NotSupportedException();
            }
        }
  
        /// <summary>
        /// Applies the filter.
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <returns></returns>
        public Bitmap ApplyFilter(Bitmap Image)
        {
            this.ConstructFilter();
            UnsafeBitmap maskPreviewImage = new UnsafeBitmap(Image);
            maskPreviewImage.LockBitmap();

            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    PixelData currentPixel = maskPreviewImage.GetPixel(i, j);
                    maskPreviewImage.SetPixel(i, j, new PixelData((byte)(this.Filter[i, j] * currentPixel.Blue), (byte)(this.Filter[i, j] * currentPixel.Red), (byte)(this.Filter[i, j] * currentPixel.Green)));
                }
            }
            maskPreviewImage.UnlockBitmap();
            return maskPreviewImage.Bitmap;
        }

        /// <summary>
        /// Constructs the filter.
        /// </summary>
        virtual protected void ConstructFilter()
        {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    switch (this.FilteringType)
                    {
                        case FilteringType.Reject:
                            this.Filter[i, j] = 1 - this.GetFilterValue(i, j);
                            break;
                        case FilteringType.Pass:
                        case FrequencyFilters.FilteringType.Lowpass:
                            this.Filter[i, j] = this.GetFilterValue(i, j);
                            break;
                        default:
                            break;
                    }

                }
            }
        }
    
        /// <summary>
        /// Gets the filter value.
        /// </summary>
        /// <param name="u">The u.</param>
        /// <param name="v">The v.</param>
        /// <returns></returns>
        abstract protected double GetFilterValue(int u, int v);
    }
}
