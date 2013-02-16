using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace Utilities
{
    public class FrequencyDomainPlane
    {
        #region Properties

        public double[,] Real { get; set; }
        public double[,] Imaginary { get; set; }
        public double[,] Magnitude { get; private set; }

        public int Width { get; set; }
        public int Height { get; set; }
        #endregion
        
        #region Constructor
        public FrequencyDomainPlane(MWArray[] p_ComplexImage)
        {
            this.Real = (double[,])(p_ComplexImage[0]).ToArray();
            this.Imaginary = (double[,])(p_ComplexImage[1]).ToArray();
            this.Width = Real.GetLength(0);
            this.Height = Real.GetLength(1);
            this.CalculateMagnitude();
            //calculate
        }

        public FrequencyDomainPlane(double[,] p_Real, double[,] p_Imaginary)
        {
            this.Real = p_Real;
            this.Imaginary = p_Imaginary;
            this.Width = p_Real.GetLength(0);
            this.Height = p_Real.GetLength(1);
            this.CalculateMagnitude();
        }
        #endregion
        
        #region Methods
 
        private void CalculateMagnitude()
        {
            this.Magnitude = new double[this.Width, this.Height];
            double Ep = 0.1;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    double Value = Math.Sqrt((Math.Pow(this.Real[i, j], 2)) + (Math.Pow(this.Imaginary[i, j], 2)));
                    this.Magnitude[i, j] = Math.Log(Value + Ep);
                }
            }
        }
        public Bitmap GetPlaneImage()
        {
            return  PostProcessing.Normalization(this.Magnitude, 255, 0);
        }
        #endregion
    }
}
