using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
   public class SaltAndPepperNoise : IRandomNoise
    {
        public double SaltProbability { get; set; }
        public double PepperProbability { get; set; }

        public SaltAndPepperNoise(double saltProb, double pepperProb)
        {
            this.SaltProbability = saltProb;
            this.PepperProbability = pepperProb;
        }
        
        protected override Bitmap ApplyFilter(UnsafeBitmap unsafeImage)
        {
            int Width = unsafeImage.Bitmap.Width;
            int Height = unsafeImage.Bitmap.Height;

            int noOfSaltPixels = (int)(this.SaltProbability * Height *Width);
            int noOfPepperPixels = (int)(this.PepperProbability * Height *Width);
            Dictionary<int, Point> randomList = new Dictionary<int, Point>();

            unsafeImage.LockBitmap();
            int index = 0;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    randomList[index++] = (new Point(i, j));
                }
            }

            Random n = new Random();
            int count = randomList.Count - 1;
            for (int i = 0; i < noOfSaltPixels; i++)
            {
                int number = n.Next(0, count);
                Point saltRandomPoint = randomList[number];
                randomList[number] = randomList[count];

                count--;
                unsafeImage.SetPixel(saltRandomPoint.X, saltRandomPoint.Y, new PixelData((byte)(255), (byte)(255), (byte)(255)));
            }

            for (int i = 0; i < noOfPepperPixels; i++)
            {

                int number = n.Next(0, count);
                Point PepperRandomPoint = randomList[number];
                randomList[number] = randomList[count];

                count--;
                unsafeImage.SetPixel(PepperRandomPoint.X, PepperRandomPoint.Y, new PixelData((byte)(0), (byte)(0), (byte)(0)));

            }
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;

        }
    }
}
