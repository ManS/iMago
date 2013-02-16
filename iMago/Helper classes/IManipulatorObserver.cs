using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Drawing;

namespace iMago
{
    public interface IManipulatorObserver
    {
        void OnUpdateHistory(int tabNumber, ImageProcessingLog processingLog);
        void OnUpdateHistogram(Bitmap newBitmap);
        void OnClearHistory();
    }
}
