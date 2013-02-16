using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
    public class PeriodicNoise : INoiseGenerator
    {
        public FrequencyDomainComponent NoiseComponent { get; set; }

        public PeriodicNoise(FrequencyDomainComponent noiseComponent)
        {
            this.NoiseComponent = noiseComponent;
        }
        
        public void AddNoise(Bitmap sourceImage, ref Bitmap noiseImage)
        {
            noiseImage = this.AddNoise(sourceImage);
        }
        public Bitmap AddNoise(Bitmap sourceImage)
        {
            UnsafeBitmap image = new UnsafeBitmap(sourceImage);
            image.LockBitmap();
            double[,] Noise = new double[image.Bitmap.Width, image.Bitmap.Height];
            for (int x = 0; x < image.Bitmap.Width; x++)
            {
                for (int y = 0; y < image.Bitmap.Height; y++)
                {
                    Noise[x, y] = NoiseComponent.Amplitude * Math.Sin(((2 * Math.PI * NoiseComponent.FreqencyInX * (x)) / image.Bitmap.Width )+ ((NoiseComponent.PhaseShiftInX)) + (2 * Math.PI * NoiseComponent.FreqencyInY * (y) / image.Bitmap.Height + (NoiseComponent.PhaseShiftInY)));
                }
            }

            RGB[,] buffer = new RGB[image.Bitmap.Width, image.Bitmap.Height];
            for (int i = 0; i < image.Bitmap.Width; i++)
            {
                for (int j = 0; j < image.Bitmap.Height; j++)
                {

                    PixelData pixel = image.GetPixel(i, j);
                    double R = pixel.Red + Noise[i, j];

                    double G = pixel.Green + Noise[i, j];

                    double B = pixel.Blue + Noise[i, j];

                    buffer[i, j].Red = R;
                    buffer[i, j].Green = G;
                    buffer[i, j].Blue = B;
                    //PixelData newPixel=new PixelData((byte)B,(byte)R,(byte)G);
                }
            }

            return (PostProcessing.Normalization(buffer, 255, 0));
        }
    }
}