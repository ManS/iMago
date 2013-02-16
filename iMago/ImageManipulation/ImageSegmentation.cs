using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;
using ImageStatistics;

namespace ImageManipulation
{
    public class ImageSegmentation
    {

        public static Bitmap BasicThreshold(Bitmap image,Histogram GrayHistogram, float epsilon)
        {
            float[] histogramValues = HistogramOperations.HistogramNormalization(GrayHistogram, image.Width, image.Height);
            
            int initialThreshold = 0;
            int newThreshold = (int)(Statistics.Mean(0, 255, histogramValues, image.Width, image.Height));
            do
            {
                initialThreshold = newThreshold;
                int Mean1 = (int)(Statistics.Mean(0, initialThreshold, histogramValues, image.Width, image.Height));
                int Mean2 = (int)(Statistics.Mean(initialThreshold + 1, 255, histogramValues, image.Width, image.Height));
                newThreshold = (int)((Mean1 + Mean2) / 2f);
            } while (Math.Abs(newThreshold - initialThreshold) > epsilon);
            return Thresholding(newThreshold, image);
        }

        public static Bitmap OTSUThreshold(Bitmap image,Histogram GrayHistogram)
        {
            float[] histogramValues = HistogramOperations.HistogramNormalization(GrayHistogram, image.Width, image.Height);
            float[] commulativeProbability = new float[256];
            float[] commulativeSumOfCommulativeMean = new float[256];
            float equalSigmaMean = 0;
            float mGlobal = 0;
            float sigmaSquare = 0, temp = 0;
            int kThanMaximizesTheVariance = 0; int numberOfEqualSigmas = 0; int threshold = 0;

            commulativeProbability[0] = histogramValues[0];
            commulativeSumOfCommulativeMean[0] = 0;
            for (int k = 1; k < 256; k++)
                mGlobal += k * histogramValues[k];
            for (int k = 1; k < 256; k++)
            {
                commulativeProbability[k] = commulativeProbability[k - 1] + histogramValues[k];
                commulativeSumOfCommulativeMean[k] = commulativeSumOfCommulativeMean[k - 1] + (k * histogramValues[k]);
                temp = (float)(Math.Pow((mGlobal * commulativeProbability[k]) - commulativeSumOfCommulativeMean[k], 2) / (commulativeProbability[k] * (1 - commulativeProbability[k]) * 1.0));
                if (temp > sigmaSquare)
                {
                    equalSigmaMean = k;
                    numberOfEqualSigmas = 0;
                    sigmaSquare = temp;
                    kThanMaximizesTheVariance = k;
                }
                else if (temp == sigmaSquare)
                {
                    numberOfEqualSigmas++;
                    equalSigmaMean += k;

                }
            }
            if (numberOfEqualSigmas > 0)

                threshold = (int)(equalSigmaMean / (float)(numberOfEqualSigmas + 1f));
            else
                threshold = kThanMaximizesTheVariance;

            return Thresholding(threshold, image);
        }
        
        private static Bitmap Thresholding(int threshold, Bitmap Image)
        {
            UnsafeBitmap unSafeimage = new UnsafeBitmap(Image);

            unSafeimage.LockBitmap();

            for (int i = 0; i < Image.Height; i++)
            {
                for (int j = 0; j < Image.Width; j++)
                {
                    PixelData c = unSafeimage.GetPixel(j, i);
                    int color = (int)((c.Blue + c.Green + c.Red) / 3f);
                    if (color < (int)threshold)
                        unSafeimage.SetPixel(j, i, new PixelData(0, 0, 0));
                    else
                        unSafeimage.SetPixel(j, i, new PixelData(255, 255, 255));
                }
            }
            unSafeimage.UnlockBitmap();
            return unSafeimage.Bitmap;
        }
        
        public static Bitmap AdaptiveThresholding(int size, UnsafeBitmap image)
        {
            image.LockBitmap();
            UnsafeBitmap result = new UnsafeBitmap(image.Bitmap.Width, image.Bitmap.Height);
            result.LockBitmap();
            double[,] mean = new double[image.Bitmap.Width, image.Bitmap.Height];
            double[,] StandardDeviation = new double[image.Bitmap.Width, image.Bitmap.Height];

            int center = size / 2;

            for (int i = 0; i < image.Bitmap.Width; i++)
            {
                for (int j = 0; j < image.Bitmap.Height; j++)
                {
                    double Tempmean = 0;
                    double TempSigma = 0;
                    for (int k = -center; k <= center; k++)
                    {
                        for (int m = -center; m <= center; m++)
                        {
                            int x = i + k;
                            int y = j + m;

                            if (x >= 0 && x <= image.Bitmap.Width - 1 && y >= 0 && y <= image.Bitmap.Height - 1)
                            {
                                PixelData currentPixel = image.GetPixel(x, y);
                                Tempmean += ((currentPixel.Red + currentPixel.Green + currentPixel.Blue) / 3);
                            }
                        }
                    }
                    mean[i, j] = Tempmean / (size * size);

                    for (int k = -center; k <= center; k++)
                    {
                        for (int m = -center; m <= center; m++)
                        {
                            int x = i + k;
                            int y = j + m;

                            if (x >= 0 && x <= image.Bitmap.Width - 1 && y >= 0 && y >= 0 && y <= image.Bitmap.Height - 1)
                            {
                                PixelData currentPixel = image.GetPixel(x, y);
                                TempSigma += (Math.Pow(((currentPixel.Red + currentPixel.Green + currentPixel.Blue) / 3) - (mean[i, j]), 2));
                            }
                        }
                    }
                    StandardDeviation[i, j] = Math.Sqrt(TempSigma / (size * size));

                    double threshold = mean[i, j] * (1 + (0.2) * ((StandardDeviation[i, j] / (128)) - 1));

                    PixelData Pixel = image.GetPixel(i, j);
                    if (((Pixel.Red + Pixel.Green + Pixel.Blue) / 3) > threshold)
                        result.SetPixel(i, j, new PixelData(255, 255, 255));
                    else
                        result.SetPixel(i, j, new PixelData(0, 0, 0));
                }
            }
            image.UnlockBitmap();
            result.UnlockBitmap();
            return result.Bitmap;
        }
    }
}
