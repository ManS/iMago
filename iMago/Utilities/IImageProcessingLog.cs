using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities
{
    public interface IImageProcessingLog
    {
        void AddImage(int key, Bitmap p_image, string p_operationName);
        void Clear();
    }
}
