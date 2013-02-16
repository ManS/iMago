using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public enum Colors
    {
        Red,
        Green,
        Blue,
        Gray
    }
    public struct RGB
    {
        public double Red;
        public double Blue;
        public double Green;

        public RGB(double p_Red, double p_Green, double p_Blue)
        {
            Red = p_Red;
            Green = p_Green;
            Blue = p_Blue;
        }
    }
    public struct PixelData
    {
        #region Attributes
        private byte blue;
        private byte green;
        private byte red;

        #endregion

        #region Properties
        public byte Blue
        {
            get { return blue; }
            set { blue = value; }
        }
        public byte Red
        {
            get { return red; }
            set { red = value; }
        }
        public byte Green
        {
            get { return green; }
            set { green = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PixelData"/> struct.
        /// </summary>
        /// <param name="p_blue">The p_blue.</param>
        /// <param name="p_red">The p_red.</param>
        /// <param name="p_green">The p_green.</param>
        public PixelData(byte p_blue, byte p_red, byte p_green)
        {
            this.blue = p_blue;
            this.red = p_red;
            this.green = p_green;
        }
        public PixelData(PixelData p_pixel)
        {
            this.blue = p_pixel.Blue;
            this.green = p_pixel.Green;
            this.red = p_pixel.Red;
        }
        #endregion
    }
}
