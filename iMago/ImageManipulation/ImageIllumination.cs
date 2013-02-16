using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace ImageManipulation
{       
    public class ImageIllumination
    {   
        public UnsafeBitmap BrightnessImage { get; private set; }
        public UnsafeBitmap ContrastImage { get; private set; }
        public Bitmap ProcessedImage { get; private set; }

        public ImageStatistics.ImageStatistics SourceImageStatistics { get; private set; }
        
        public ImageIllumination(Bitmap sourceImage, ImageStatistics.ImageStatistics sourceImageStatistics)
        {
            this.BrightnessImage = new UnsafeBitmap(sourceImage);
            this.ContrastImage = new UnsafeBitmap(sourceImage);
            this.SourceImageStatistics = sourceImageStatistics;
        }

        public Bitmap AdjustContrast(int Value)//stretch/shrink
        {
            int Width = this.BrightnessImage.Bitmap.Width;
            int Height = this.BrightnessImage.Bitmap.Height;
            
            this.ContrastImage.LockBitmap();

            int minR = 255, maxR = 0, minG = 255, maxG = 0, minB = 255, maxB = 0;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    PixelData c = ContrastImage.GetPixel(x, y);
                    if (c.Red > maxR)
                        maxR = c.Red;
                    if (c.Red < minR)
                        minR = c.Red;

                    if (c.Green > maxG)
                        maxG = c.Green;
                    if (c.Green < minG)
                        minG = c.Green;

                    if (c.Blue > maxB)
                        maxB = c.Blue;
                    if (c.Blue < minB)
                        minB = c.Blue;
                }
            }

            int newMinR = minR - ((int)Value);
            int newMaxR = maxR + ((int)Value);

            int newMinG = minG - ((int)Value);
            int newMaxG = maxG + ((int)Value * 4);

            int newMinB = minB - ((int)Value);
            int newMaxB = maxB + ((int)Value * 3);

            RGB[,] resultBuffer = new RGB[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    PixelData Pixel = ContrastImage.GetPixel(x, y);
                    float Red = (((float)Pixel.Red - (float)minR) / (float)(maxR - minR)) * (float)(newMaxR - newMinR) + newMinR;
                    float Green = (((float)Pixel.Green - (float)minG) / (float)(maxR - minG)) * (float)(newMaxG - newMinG) + newMinG;
                    float Blue = (((float)Pixel.Blue - (float)minB) / (float)(maxR - minB)) * (float)(newMaxB - newMinB) + newMinB;

                    resultBuffer[x, y] = new RGB(Red, Green, Blue);
                }
            }
            this.ContrastImage.UnlockBitmap();

            this.ProcessedImage = PostProcessing.CutOff(resultBuffer, 255, 0);
            return this.ProcessedImage;
        }

        public Bitmap AdjustBrightness(int offset)//histogram sliding
        {
            int Width = this.BrightnessImage.Bitmap.Width;
            int Height = this.BrightnessImage.Bitmap.Height;

            this.BrightnessImage.LockBitmap();
            this.ContrastImage.LockBitmap();

            RGB[,] resultBuffer = new RGB[Width,Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    PixelData currentPixel = BrightnessImage.GetPixel(j, i);
                    double newRed = (int)currentPixel.Red + offset;
                    double newGreen = (int)currentPixel.Green + offset;
                    double newBlue = (int) currentPixel.Blue + offset;

                    resultBuffer[j,i] = new RGB(newRed,newGreen,newBlue);
                }
            }

            this.BrightnessImage.UnlockBitmap();
            this.ContrastImage.UnlockBitmap();

            this.ProcessedImage = PostProcessing.CutOff(resultBuffer, 255, 0);

            this.ContrastImage = new UnsafeBitmap(this.ProcessedImage);

            return this.ProcessedImage;
        }

        public void ApplyChanges()
        {
            this.BrightnessImage = this.ContrastImage;
            this.SourceImageStatistics.CalculateStatistics(this.ContrastImage.Bitmap);
        }
    }
}