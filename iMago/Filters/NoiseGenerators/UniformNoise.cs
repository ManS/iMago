using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
   public class UniformNoise : IRandomNoise
    {
        public int a { get; private set; }
        public int b { get; private set; }
        public double NoisePercentage { get; private set; }

        public UniformNoise(int p_a, int p_b, double noisePercentage)
        {
            this.a = p_a;
            this.b = p_b;
            this.NoisePercentage = noisePercentage;
        }

        protected override Bitmap ApplyFilter(UnsafeBitmap unsafeImage)
        {
            int Width = unsafeImage.Bitmap.Width;
            int Height = unsafeImage.Bitmap.Height;

            unsafeImage.LockBitmap();
            RGB[,] noise = new RGB[Width,Height];
            int noOfPixels = (int)((1f / ((b - a) + 1)) * Width * Height * (this.NoisePercentage / 100f));
            Dictionary<int, Point> randomList = new Dictionary<int, Point>();
            bool exceeded = false;
            int index = 0;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    randomList[index++] = (new Point(i, j));

                    PixelData pixelData = unsafeImage.GetPixel(i, j);
                    noise[i, j] = new RGB(pixelData.Red, pixelData.Green, pixelData.Blue);
                    unsafeImage.SetPixel(i, j, new PixelData((byte)noise[i, j].Blue, (byte)noise[i, j].Red, (byte)noise[i, j].Green));
                }
            }

            Random n = new Random();
            int count = randomList.Count - 1;
            for (int i = a; i <= b; i++)
            {
                for (int j = 0; j < noOfPixels; j++)
                {
                    int number = n.Next(0, count);
                    Point RandomPoint = randomList[number];
                    randomList[number] = randomList[count];
                    randomList[count] = RandomPoint;
                    PixelData pixelData = unsafeImage.GetPixel(RandomPoint.X, RandomPoint.Y);
                    if ((((i + (int)pixelData.Red) > 255)) || (((i + (int)pixelData.Blue) > 255)) || (((i + (int)pixelData.Blue) > 255)))
                        exceeded = true;

                    noise[RandomPoint.X, RandomPoint.Y] = new RGB(i + pixelData.Red, i + pixelData.Green, i + pixelData.Blue);
                    unsafeImage.SetPixel(RandomPoint.X, RandomPoint.Y, new PixelData((byte)noise[RandomPoint.X, RandomPoint.Y].Blue, (byte)noise[RandomPoint.X, RandomPoint.Y].Red, (byte)noise[RandomPoint.X, RandomPoint.Y].Green));
                    count--;
                }
            }
            unsafeImage.UnlockBitmap();
            if (exceeded)
                return PostProcessing.Normalization(noise, 255, 0);
            else
                return unsafeImage.Bitmap;
        }
    }
}
