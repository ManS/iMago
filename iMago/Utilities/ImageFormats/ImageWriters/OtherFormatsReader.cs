using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities.ImageFormats
{
    class OtherFormatsReader : IImageReader
    {
        public Bitmap ReadImage(string p_imagePath)
        {
            return new Bitmap(p_imagePath);
        }
    }
}
