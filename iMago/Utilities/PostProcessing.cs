using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities
{
   public static class PostProcessing
    {
        public static Bitmap Normalization(RGB[,] resultBuffer, int NewMax, int NewMin)
        {
            int Width = resultBuffer.GetLength(0);
            int Height = resultBuffer.GetLength(1);

            double OldMinB = double.MaxValue;
            double OldMaxB = double.MinValue;

            double OldMinR = double.MaxValue;
            double OldMaxR = double.MinValue;

            double OldMinG = double.MaxValue;
            double OldMaxG = double.MinValue;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    RGB currentPixel = resultBuffer[j, i];

                    OldMaxB = OldMaxB < currentPixel.Blue ? currentPixel.Blue : OldMaxB;
                    OldMaxG = OldMaxG < currentPixel.Green ? currentPixel.Green : OldMaxG;
                    OldMaxR = OldMaxR < currentPixel.Red ? currentPixel.Red : OldMaxR;

                    OldMinB = OldMinB > currentPixel.Blue ? currentPixel.Blue : OldMinB;
                    OldMinG = OldMinG > currentPixel.Green ? currentPixel.Green : OldMinG;
                    OldMinR = OldMinR > currentPixel.Red ? currentPixel.Red : OldMinR;
                }
            }
            UnsafeBitmap resultImage = new UnsafeBitmap(Width, Height);
            resultImage.LockBitmap();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double Blue = ((((resultBuffer[j, i].Blue - OldMinB) / (OldMaxB - OldMinB)) * (NewMax - NewMin)) + NewMin);
                    double Green = ((((resultBuffer[j, i].Green - OldMinG) / (OldMaxG - OldMinG)) * (NewMax - NewMin)) + NewMin);
                    double Red = ((((resultBuffer[j, i].Red - OldMinR) / (OldMaxR - OldMinR)) * (NewMax - NewMin)) + NewMin);
                    resultImage.SetPixel(j, i, new PixelData((byte)Blue, (byte)Red, (byte)Green));
                }
            }
            resultImage.UnlockBitmap();

            return resultImage.Bitmap;
        }

        public static Bitmap Normalization(double[,] resultBuffer, int NewMax, int NewMin)
        {
            int Width = resultBuffer.GetLength(0);
            int Height = resultBuffer.GetLength(1);

            double OldMin = double.MaxValue;
            double OldMax = double.MinValue;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double currentValue = resultBuffer[j, i];
                    OldMax = OldMax < currentValue ? currentValue : OldMax;
                    OldMin = OldMin > currentValue ? currentValue : OldMin;
                }
            }
            UnsafeBitmap resultImage = new UnsafeBitmap(Width, Height);
            resultImage.LockBitmap();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    double NewValue = ((((resultBuffer[j, i] - OldMin) / (OldMax - OldMin)) * (NewMax - NewMin)) + NewMin);

                    resultImage.SetPixel(j, i, new PixelData((byte)NewValue, (byte)NewValue, (byte)NewValue));
                }
            }
            resultImage.UnlockBitmap();

            return resultImage.Bitmap;
        }

        public static MatlabImage Normalization(MatlabImage image, int NewMax, int NewMin)
        {
            

            double[,] Blue = new double[image.Width, image.Height];
            double[,] Green = new double[image.Width, image.Height];
            double[,] Red = new double[image.Width, image.Height];

            double OldMinB = double.MaxValue;
            double OldMaxB = double.MinValue;

            double OldMinR = double.MaxValue;
            double OldMaxR = double.MinValue;

            double OldMinG = double.MaxValue;
            double OldMaxG = double.MinValue;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {

                    OldMaxB = OldMaxB < image.Blue[i, j] ? image.Blue[i, j] : OldMaxB;
                    OldMaxG = OldMaxG < image.Green[i, j] ? image.Green[i, j] : OldMaxG;
                    OldMaxR = OldMaxR < image.Red[i, j] ? image.Red[i, j] : OldMaxR;

                    OldMinB = OldMinB > image.Blue[i, j] ? image.Blue[i, j] : OldMinB;
                    OldMinG = OldMinG > image.Green[i, j] ? image.Green[i, j] : OldMinG;
                    OldMinR = OldMinR > image.Red[i, j] ? image.Red[i, j] : OldMinR;
                }
            }

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Blue[i, j] = ((((image.Blue[i, j] - OldMinB) / (OldMaxB - OldMinB)) * (NewMax - NewMin)) + NewMin);
                    Green[i, j] = ((((image.Green[i, j] - OldMinG) / (OldMaxG - OldMinG)) * (NewMax - NewMin)) + NewMin);
                    Red[i, j] = ((((image.Red[i, j] - OldMinR) / (OldMaxR - OldMinR)) * (NewMax - NewMin)) + NewMin);
                }
            }
            return new MatlabImage(Red, Green, Blue);
        }

        public static Bitmap CutOff(RGB[,] resultBuffer, double Maxval, double Minval)
        {
            int width = resultBuffer.GetLength(0);
            int height = resultBuffer.GetLength(1);
            UnsafeBitmap resultImage = new UnsafeBitmap(width, height);
            resultImage.LockBitmap();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    byte Blue = (byte)resultBuffer[i, j].Blue;
                    byte Green = (byte)resultBuffer[i, j].Green;
                    byte Red = (byte)resultBuffer[i, j].Red;

                    if (resultBuffer[i, j].Blue > Maxval)
                        Blue = 255;
                    if (resultBuffer[i, j].Red > Maxval)
                        Red = 255;
                    if (resultBuffer[i, j].Green > Maxval)
                        Green = 255;

                    if (resultBuffer[i, j].Blue < Minval)
                        Blue = 0;
                    if (resultBuffer[i, j].Red < Minval)
                        Red = 0;
                    if (resultBuffer[i, j].Green < Minval)
                        Green = 0;

                    resultImage.SetPixel(i, j, new PixelData(Blue, Red, Green));
                }
            }
            resultImage.UnlockBitmap();

            return resultImage.Bitmap;
        }

        public static Bitmap CutOff(double[,] resultBuffer, double Maxval, double Minval)
        {
            int width = resultBuffer.GetLength(0);
            int height = resultBuffer.GetLength(1);
            UnsafeBitmap resultImage = new UnsafeBitmap(width, height);
            resultImage.LockBitmap();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    byte NewValue = (byte)resultBuffer[i, j];

                    if (resultBuffer[i, j] > Maxval)
                        NewValue = 255;
                    if (resultBuffer[i, j] > Maxval)
                        NewValue = 255;

                    resultImage.SetPixel(i, j, new PixelData(NewValue, NewValue, NewValue));
                }
            }
            resultImage.UnlockBitmap();

            return resultImage.Bitmap;
        }
        
        public static MatlabImage CutOff(MatlabImage image, int NewMax, int NewMin)
        {
            double[,] Blue = new double[image.Width, image.Height];
            double[,] Green = new double[image.Width, image.Height];
            double[,] Red = new double[image.Width, image.Height];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Blue[i, j] = image.Blue[i, j];
                    Red[i, j] = image.Red[i, j];
                    Green[i, j] = image.Green[i, j];

                    if (Blue[i, j] > 255)
                        Blue[i, j] = 255;

                    if (Red[i, j] > 255)
                        Red[i, j] = 255;

                    if (Green[i, j] > 255)
                        Green[i, j] = 255;

                    if (Blue[i, j] < 0)
                        Blue[i, j] = 0;

                    if (Red[i, j] < 0)
                        Red[i, j] = 0;

                    if (Green[i, j] < 0)
                        Green[i, j] = 0;
                }
            }
           
            return new MatlabImage(Red, Green, Blue);
        }
   }
}