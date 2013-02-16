using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities
{
    public class FrequencyDomainImage
    {
        
        #region Properties
        public FrequencyDomainPlane Red { get; set; }
        public FrequencyDomainPlane Green { get; set; }
        public FrequencyDomainPlane Blue { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        #endregion

        #region Constructor
        public FrequencyDomainImage(FrequencyDomainPlane p_Red, FrequencyDomainPlane p_Green, FrequencyDomainPlane p_Blue)
        {
            this.Red = p_Red;
            this.Green = p_Green;
            this.Blue = p_Blue;
            this.Width = p_Red.Width;
            this.Height = p_Red.Height;
        }
        public FrequencyDomainImage(int p_width, int p_height)
        {
            this.Width = p_width;
            this.Height = p_height;

            this.Red = new FrequencyDomainPlane(new double[this.Width, this.Height], new double[this.Width, this.Height]);
            this.Green = new FrequencyDomainPlane(new double[this.Width, this.Height], new double[this.Width, this.Height]);
            this.Blue = new FrequencyDomainPlane(new double[this.Width, this.Height], new double[this.Width, this.Height]);
        }
        #endregion

        #region Methods
        public Bitmap GetMagnitudeImage()
        {
            return ImageConversions.ConvertToGrayScale(PostProcessing.Normalization(this.MargePlanes(), 255, 0));
        }
        private RGB[,] MargePlanes()
        {
            RGB[,] MargedImage = new RGB[this.Width, this.Height];
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    MargedImage[i, j] = new RGB(this.Red.Magnitude[i, j], this.Green.Magnitude[i, j], this.Blue.Magnitude[i, j]);
                }
            }
            return MargedImage;
        }
        #endregion
    }
}
