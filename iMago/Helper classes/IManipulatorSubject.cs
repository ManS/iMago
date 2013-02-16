using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace iMago
{
    public interface IManipulatorSubject 
    {
        void NotifyUpdated(string p_operation);
        void RegisterObserver(IManipulatorObserver p_observer);
        void UnRegisterObserver(IManipulatorObserver p_observer);
        void NotifyUpdateHistogram(Bitmap p_newImage);
    }
}
