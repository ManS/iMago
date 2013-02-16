using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers
{
  abstract public class IMeanFilter : INoiseRemover
    {
        public int FilterSize { get; private set; } 
      
        public IMeanFilter(int filterSize)
        {
            this.FilterSize = filterSize;
        }

        public void RemoveNoise(Bitmap noiseImage, ref Bitmap destinationImage)
        {
            destinationImage = RemoveNoise(noiseImage);
        }
        public Bitmap RemoveNoise(Bitmap sourceImage)
        {
            UnsafeBitmap unsafePaddedImage = new UnsafeBitmap(ImagePadding.PaddingImage(sourceImage, this.FilterSize, this.FilterSize, PaddingType.Replication));

            return this.ApplyFilter(unsafePaddedImage, sourceImage.Width, sourceImage.Height);
        }
        abstract protected Bitmap ApplyFilter(UnsafeBitmap unsafePaddedImage, int origWidth, int origHeight);
    }
}
