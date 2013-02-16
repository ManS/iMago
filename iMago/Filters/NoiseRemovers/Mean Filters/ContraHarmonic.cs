using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseRemovers.Mean_Filters
{
    class ContraHarmonic : IMeanFilter
    {
        public ContraHarmonic(int filterSize)
            : base(filterSize)
        { }

        protected override Bitmap ApplyFilter(UnsafeBitmap unsafePaddedImage, int origWidth, int origHeight)
        {
            throw new NotImplementedException();
        }
    }
}
