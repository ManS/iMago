using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Drawing;

namespace Filters
{
    public interface IFilter
    {
        void Apply(Bitmap sourceImage,ref Bitmap destinationImage, PaddingType paddingType);
        Bitmap Apply(Bitmap sourceImage, PaddingType paddingType);
    }
}