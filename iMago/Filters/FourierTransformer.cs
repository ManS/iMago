using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using Matlab;
using Utilities;


namespace Filters
{
    public class FourierTransformer
    {
        static private Matlab.FourierTransformer fourierTransformer = new Matlab.FourierTransformer();
        public static FrequencyDomainImage FourierTransform(Bitmap image)
        {
            
            MatlabImage matlabImage = new MatlabImage(image);

            FrequencyDomainPlane Red = new FrequencyDomainPlane(fourierTransformer.FourierTransform(2,(MWNumericArray)matlabImage.Red));
            FrequencyDomainPlane Green = new FrequencyDomainPlane(fourierTransformer.FourierTransform(2, (MWNumericArray)matlabImage.Green));
            FrequencyDomainPlane Blue = new FrequencyDomainPlane(fourierTransformer.FourierTransform(2, (MWNumericArray)matlabImage.Blue));

            return new FrequencyDomainImage(Red, Green, Blue);
        }
        public static Bitmap InverseFourierTransform(FrequencyDomainImage FreqImage)
        {
            return InverseFourierToMatlab(FreqImage).Bitmap;
            
        }
        public static MatlabImage InverseFourierToMatlab(FrequencyDomainImage FreqImage)
        {
            MWArray newR = (MWNumericArray)fourierTransformer.InverseFourierTransform((MWNumericArray)FreqImage.Red.Real, (MWNumericArray)FreqImage.Red.Imaginary);
            MWArray newG = (MWNumericArray)fourierTransformer.InverseFourierTransform((MWNumericArray)FreqImage.Green.Real, (MWNumericArray)FreqImage.Green.Imaginary);
            MWArray newB = (MWNumericArray)fourierTransformer.InverseFourierTransform((MWNumericArray)FreqImage.Blue.Real, (MWNumericArray)FreqImage.Blue.Imaginary);

            return new MatlabImage(newR, newG, newB);
        }
    }
}
