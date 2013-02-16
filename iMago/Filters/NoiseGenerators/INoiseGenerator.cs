using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters.NoiseGenerators
{
    public interface INoiseGenerator
    {
        void AddNoise(Bitmap sourceImage, ref Bitmap noiseImage);
        Bitmap AddNoise(Bitmap sourceImage);
    }
}
