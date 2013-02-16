using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities.ImageFormats
{
    public interface IImageReader
    {
        Bitmap ReadImage(string p_imagePath);
    }
}
