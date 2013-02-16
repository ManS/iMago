using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Drawing;

namespace Filters
{
    public enum PostProcessingType
    {
        CuttOff,
        Normalization
    }
    public class CustomFilter : I2DConvolution
    {
        public PostProcessingType PostProcessingType { get; set; }
        public CustomFilter(int width, int height, double[,] filterValues,PostProcessingType postProcessing)
           : base(width, height)
        {
            this.PostProcessingType = postProcessing;
            this.FilterValues = filterValues;
        }

        protected override Bitmap ApplyWithPostProcessing(Bitmap paddedImage, int origWidth, int origHeight)
        {
            RGB[,] filteredImage = base.ApplyFilter(paddedImage, origWidth, origHeight);
            switch (this.PostProcessingType)
            {
                case PostProcessingType.CuttOff:
                    return PostProcessing.CutOff(filteredImage, 255, 0);
                case PostProcessingType.Normalization:
                    return PostProcessing.Normalization(filteredImage, 255, 0);
                default:
                    throw new NotImplementedException();
            }
        }

        protected override void ConstructFilter()
        {
            throw new NotImplementedException();
        }
    }
}
