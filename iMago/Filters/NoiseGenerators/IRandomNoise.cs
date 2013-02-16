using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
   abstract public class IRandomNoise : INoiseGenerator
    {

        public void AddNoise(Bitmap sourceImage, ref Bitmap noiseImage)
        {
            noiseImage = AddNoise(sourceImage);
        }

        public Bitmap AddNoise(Bitmap sourceImage)
        {
            return this.ApplyFilter(new UnsafeBitmap(sourceImage));
        }

        abstract protected Bitmap ApplyFilter(UnsafeBitmap unsafeBitmap);
    }
}
