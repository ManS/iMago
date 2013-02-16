using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities.ImageFormats
{
    public interface IImageWriter
    {
        void SaveImage(Bitmap p_image, string p_imageSavePath);
    }
}
