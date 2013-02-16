using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filters.NoiseRemovers
{
    public interface INoiseRemover
    {
        void RemoveNoise(Bitmap noiseImage, ref Bitmap destinationImage);
        Bitmap RemoveNoise(Bitmap sourceImage);
    }
}