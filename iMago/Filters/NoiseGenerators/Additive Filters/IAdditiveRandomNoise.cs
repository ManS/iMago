using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
   abstract public class IAdditiveRandomNoise : INoiseGenerator
    {
        public double NoisePercentage { get; private set; }
        protected List<double> Probablity { get; set; }

        public IAdditiveRandomNoise(double noisePercentage)
        {
            this.NoisePercentage = noisePercentage;
            this.CalculateProbablity();
        }

        abstract protected void CalculateProbablity();

        public void AddNoise(Bitmap sourceImage, ref Bitmap noiseImage)
        {
            noiseImage = AddNoise(sourceImage);
        }

        public Bitmap AddNoise(Bitmap sourceImage)
        {
            //Code 
            
            int Width = sourceImage.Width;
            int Height = sourceImage.Height;

            UnsafeBitmap image = new UnsafeBitmap(sourceImage);
            image.LockBitmap();
            Dictionary<int, Point> Rand = new Dictionary<int, Point>();
            int key = 0;

            for (int i = 0; i < image.Bitmap.Width; i++)
            {
                for (int j = 0; j < image.Bitmap.Height; j++)
                {
                    Rand.Add(key, new Point(i, j));
                    key++;
                }
            }
            int LastKey = key - 1;

            int[,] noise = new int[image.Bitmap.Width, image.Bitmap.Height];

            int[] colors = new int[256];

            int sum = 0;

            for (int i = 0; i < 256; i++)
            {
                colors[i] = (int)(this.Probablity[i] * (image.Bitmap.Width * image.Bitmap.Height) * (this.NoisePercentage / 100f));
                sum += colors[i];
            }

            Random random = new Random();
            for (int i = 0; i < 256; i++)
            {

                for (int j = 0; j < colors[i]; j++)
                {
                    int H = random.Next(0, LastKey);
                    noise[Rand[H].X, Rand[H].Y] = i;
                    Rand[H] = Rand[LastKey];
                    LastKey--;
                }
            }

            RGB[,] buffer = new RGB[Width, Height];
            bool normalize = false;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {

                    PixelData pixel = image.GetPixel(i, j);
                    buffer[i, j].Red = pixel.Red + noise[i, j];
                    buffer[i, j].Green = pixel.Green + noise[i, j];
                    buffer[i, j].Blue = pixel.Blue + noise[i, j];

                    if (buffer[i, j].Red > 255 || buffer[i, j].Blue > 255 || buffer[i, j].Green > 255)
                        normalize = true;
                }
            }

            if (normalize)
            {
                image.UnlockBitmap();
                return (PostProcessing.Normalization(buffer, 255, 0));
            }
            else
            {
                UnsafeBitmap Noisyimage = new UnsafeBitmap(image.Bitmap.Width, image.Bitmap.Height);
                Noisyimage.LockBitmap();
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j <Height; j++)
                    {

                        PixelData CurrentPixel = new PixelData((byte)buffer[i, j].Blue, (byte)buffer[i, j].Red, (byte)buffer[i, j].Green);
                        Noisyimage.SetPixel(i, j, CurrentPixel);
                    }
                }
                Noisyimage.UnlockBitmap();
                return Noisyimage.Bitmap;
            }

        }
    }
}
