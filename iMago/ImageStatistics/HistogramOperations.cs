using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using Matlab;

namespace ImageStatistics
{
    public enum ColorEnum { Grey, Red, Blue, Green };
    public class HistogramOperations
    {
        public static Matlab.HistManipulator MatlabHisto = new Matlab.HistManipulator();

        public static float[] HistogramNormalization(Histogram histogram, int imageWidth, int imageHeight)
        {
            float[] NormalizedHistogram = new float[256];
            for (int i = 0; i < 256; i++)
            {
                NormalizedHistogram[i] = ((float)histogram.Values[i] / (imageHeight * imageWidth * 1f));
            }
            return NormalizedHistogram;
        }
        public static int[] CalculateCumulativeProb(Histogram NormalizedHistogram)
        {

            int[] CumulativeHistogram = new int[256];
            CumulativeHistogram[0] = NormalizedHistogram.Values[0];
            for (int i = 1; i < 256; i++)
            {
                CumulativeHistogram[i] += CumulativeHistogram[i - 1];
            }
            return CumulativeHistogram;
        }

        #region Histogram  Equlization
        public static Bitmap EqualizeHistogram(Bitmap image, Histogram targetHistogram, Colors targetColor)
        {
            targetHistogram.Values = EqualizeHistogram(targetHistogram);
            return EqualizeHistogram(image, targetHistogram.Values, targetColor);
        }
        private static int[] EqualizeHistogram(Histogram targetHistogram)
        {
            for (int currentColor = 1; currentColor < 256; currentColor++)
                targetHistogram.Values[currentColor] += targetHistogram.Values[currentColor - 1];

            int maxValue = targetHistogram.Values[255];

            for (int currentColor = 0; currentColor < 256; currentColor++)
                targetHistogram.Values[currentColor] = (int)((targetHistogram.Values[currentColor] * 1.0 / maxValue * 1.0) * (255 * 1.0));

            return targetHistogram.Values;
        }
        private static Bitmap EqualizeHistogram(Bitmap image, int[] histogramValues, Colors color)
        {
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();

            for (int currentRow = 0; currentRow < image.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < image.Width; currentColumn++)
                {
                    PixelData pixelData = unsafeImage.GetPixel(currentColumn, currentRow);
                    if (color == Colors.Gray)
                    {
                        int currentColor = (int)((pixelData.Red + pixelData.Green + pixelData.Blue) / 3f);
                        int newValue = histogramValues[currentColor];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)newValue, (byte)newValue, (byte)newValue));
                    }
                    else if (color == Colors.Red)
                    {
                        int newRedValue = histogramValues[(int)pixelData.Red];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)pixelData.Blue, (byte)newRedValue, (byte)pixelData.Green));
                    }
                    else if (color == Colors.Green)
                    {
                        int newGreenValue = histogramValues[(int)pixelData.Green];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)pixelData.Blue, (byte)pixelData.Red, (byte)newGreenValue));
                    }
                    else if (color == Colors.Blue)
                    {
                        int newBlueValue = histogramValues[(int)pixelData.Blue];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)newBlueValue, (byte)pixelData.Red, (byte)pixelData.Green));
                    }
                }
            }
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
        }
        public static Bitmap EqualizeRedGreenBlue(Bitmap image, ImageStatistics imageStatistics)
        {

            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();
            int size = image.Height * image.Width;

            int[] redHistogram = imageStatistics.Red.Values;
            int[] greenHistogram = imageStatistics.Green.Values;
            int[] blueHistogram = imageStatistics.Blue.Values;

            for (int currentColor = 1; currentColor < 256; currentColor++)
            {
                redHistogram[currentColor] += redHistogram[currentColor - 1];
                blueHistogram[currentColor] += blueHistogram[currentColor - 1];
                greenHistogram[currentColor] += greenHistogram[currentColor - 1];
            }
            int maxRedValue = redHistogram[255];
            int maxGreenValue = greenHistogram[255];
            int maxBlueValue = blueHistogram[255];

            for (int currentColor = 0; currentColor < 256; currentColor++)
            {
                redHistogram[currentColor] = (int)((redHistogram[currentColor] / (maxRedValue * 1.0)) * 255);
                greenHistogram[currentColor] = (int)((greenHistogram[currentColor] / (maxGreenValue * 1.0)) * 255);
                blueHistogram[currentColor] = (int)((blueHistogram[currentColor] / (maxBlueValue * 1.0)) * 255);
            }

            for (int currentRow = 0; currentRow < image.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < image.Width; currentColumn++)
                {

                    PixelData pixelData = unsafeImage.GetPixel(currentColumn, currentRow);

                    int newRedValue = redHistogram[(int)pixelData.Red];
                    int newGreenValue = greenHistogram[(int)pixelData.Green];
                    int newBlueValue = blueHistogram[(int)pixelData.Blue];

                    unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)newBlueValue, (byte)newRedValue, (byte)newGreenValue));
                }
            }
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
        }

        #endregion

        #region Histogram Matching
        public static Bitmap MatchHistogram(Bitmap firstImage, Bitmap secondImage, ImageStatistics firstImageStatistics, ImageStatistics secondImageStatistics, Colors color)
        {
            Histogram TargetHist1;
            Histogram TargetHist2;
            switch (color)
            {
                case Colors.Red:
                    TargetHist1 = firstImageStatistics.Red;
                    TargetHist2 = secondImageStatistics.Red;
                    break;
                case Colors.Green:
                    TargetHist1 = firstImageStatistics.Green;
                    TargetHist2 = secondImageStatistics.Green;
                    break;
                case Colors.Blue:
                    TargetHist1 = firstImageStatistics.Blue;
                    TargetHist2 = secondImageStatistics.Blue;
                    break;
                default:
                    TargetHist1 = firstImageStatistics.Gray;
                    TargetHist2 = secondImageStatistics.Gray;
                    break;
            }
            int[] newColor = MatchHistogram(TargetHist1, TargetHist2);
            return ApplyMatching(firstImage, newColor, color);
        }
        private static int[] MatchHistogram( Histogram firstHistogram, Histogram secondHistogram)
        {

            int[] firstHistogramValues = EqualizeHistogram(firstHistogram);
            int[] secondHistogramValues = EqualizeHistogram(secondHistogram);
            int[] newColor = new int[256];
            int lastIndex = 0; int min = 1000000;


            for (int currentIndex = 0; currentIndex < 256; currentIndex++)
            {
                min = 1000000;
                while (lastIndex < 256)
                {
                    int absDiff = Math.Abs(firstHistogramValues[currentIndex] - secondHistogramValues[lastIndex]);
                    if (min > absDiff)
                        min = absDiff;
                    else if (min != absDiff)
                    {
                        lastIndex--;
                        break;
                    }
                    lastIndex++;
                }
                newColor[currentIndex] = lastIndex;
            }
            return newColor;
        }
        private static Bitmap ApplyMatching(Bitmap firstImage, int[] newColor, Colors color)
        {
            UnsafeBitmap unsafeFirstImage = new UnsafeBitmap(firstImage);
            unsafeFirstImage.LockBitmap();
            for (int i = 0; i < firstImage.Width; i++)
            {
                for (int j = 0; j < firstImage.Height; j++)
                {
                    PixelData pixelData = unsafeFirstImage.GetPixel(i, j);
                    if (color == Colors.Gray)
                    {
                        int grey = (int)((pixelData.Blue + pixelData.Red + pixelData.Green) / 3f);
                        unsafeFirstImage.SetPixel(i, j, new PixelData((byte)newColor[grey], (byte)newColor[grey], (byte)newColor[grey]));
                    }
                    else if (color == Colors.Red)
                        unsafeFirstImage.SetPixel(i, j, new PixelData(pixelData.Blue, (byte)newColor[(int)pixelData.Red], pixelData.Green));
                    else if (color == Colors.Green)
                        unsafeFirstImage.SetPixel(i, j, new PixelData(pixelData.Blue, pixelData.Red, (byte)newColor[(int)pixelData.Green]));
                    else if (color == Colors.Blue)
                        unsafeFirstImage.SetPixel(i, j, new PixelData((byte)newColor[(int)pixelData.Blue], pixelData.Red, pixelData.Green));
                }
            }
            unsafeFirstImage.UnlockBitmap();
            return unsafeFirstImage.Bitmap;
        }
        public static Bitmap MatchHistogram(Bitmap firstImage, Bitmap secondImage, ImageStatistics firstImageStatistics, ImageStatistics secondImageStatistics)
        {
            int[] newRedColor = MatchHistogram(firstImageStatistics.Red, secondImageStatistics.Red);
            int[] newGreenColor = MatchHistogram(firstImageStatistics.Green, secondImageStatistics.Green);
            int[] newBlueColor = MatchHistogram(firstImageStatistics.Blue, secondImageStatistics.Blue);

            Bitmap afterModification = ApplyMatching(firstImage, newRedColor, Colors.Red);
            afterModification = ApplyMatching(afterModification, newGreenColor, Colors.Green);
            return ApplyMatching(afterModification, newBlueColor, Colors.Blue);
        }
        #endregion

        public static Bitmap HistogramSlicing(Bitmap image, int oldMin, int oldMax, int newMin, int newMax)
        {
            RGB[,] RGBImage = new RGB[image.Width, image.Height];
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();

            for (int currentColumn = 0; currentColumn < image.Width; currentColumn++)
            {
                for (int currentRow = 0; currentRow < image.Height; currentRow++)
                {
                    PixelData pixelData = new PixelData(unsafeImage.GetPixel(currentColumn, currentRow));
                    double newRedValue = pixelData.Red, newBlueValue = pixelData.Blue, newGreenValue = pixelData.Green;

                    if (pixelData.Red >= oldMin && pixelData.Red <= oldMax)
                        newRedValue = (((pixelData.Red - oldMin) / (double)(oldMax - oldMin)) * (double)(newMax - newMin)) + newMin;

                    if (pixelData.Green >= oldMin && pixelData.Green <= oldMax)
                        newGreenValue = (((pixelData.Green - oldMin) / (double)(oldMax - oldMin)) * (double)(newMax - newMin)) + newMin;

                    if (pixelData.Blue >= oldMin && pixelData.Blue <= oldMax)
                        newBlueValue = (((pixelData.Blue - oldMin) / (double)(oldMax - oldMin)) * (double)(newMax - newMin)) + newMin;
                    RGBImage[currentColumn, currentRow] = new RGB(newRedValue, newGreenValue, newBlueValue);
                }
            }
            unsafeImage.UnlockBitmap();

            return PostProcessing.CutOff(RGBImage, 225, 0);
        }

        public static Bitmap AdjustGamma(Bitmap Image, float Value)
        {
            
            UnsafeBitmap unsafeImage = new UnsafeBitmap(Image);
            unsafeImage.LockBitmap();

            RGB[,] resultBuffer = new RGB[Image.Width, Image.Height];

            for (int i = 0; i < Image.Height; i++)
            {
                for (int j = 0; j < Image.Width; j++)
                {
                    PixelData currentPixel = unsafeImage.GetPixel(j, i);
                    double blue = Math.Pow((double)currentPixel.Blue, Value);
                    double green = Math.Pow((double)currentPixel.Green, Value);
                    double red = Math.Pow((double)currentPixel.Red, Value);
                    resultBuffer[j, i] = new RGB(red, green, blue);
                }
            }

            return PostProcessing.Normalization(resultBuffer, 255, 0);
        }

        public static Bitmap LocalEnhanc(Bitmap image, double E, double K0, double k1, double K2, int winSize)
        {
           // MatlabImage matlabImage = new MatlabImage(image);
            //MWArray[] array = (MWArray[])e.ImageEnhance(3, (MWNumericArray)matlabImage.Red, (MWNumericArray)matlabImage.Green, (MWNumericArray)matlabImage.Blue, (MWNumericArray)E, (MWNumericArray)K0, (MWNumericArray)k1, (MWNumericArray)K2, (MWNumericArray)winSize);
            //return new MatlabImage(array[0], array[1], array[2]).Bitmap;
            throw new NotImplementedException();
        }

        public static Bitmap LocalHistogramEqulaization(Bitmap image, int winSize)
        {
            HistManipulator histManip = new HistManipulator();
            MatlabImage matlabImage = new MatlabImage(image);
            MWArray[] array = (MWArray[])histManip.LocalHistEqualization(3, new MWNumericArray(winSize), (MWNumericArray)matlabImage.Red, (MWNumericArray)matlabImage.Green, (MWNumericArray)matlabImage.Blue);
            byte [,] Red1=   (byte[,]) array[0].ToArray();
            byte[,] Green1 = (byte[,])array[1].ToArray();
            byte[,] Blue1 = (byte[,])array[2].ToArray();

            return  new MatlabImage(Red1, Green1,Blue1).Bitmap;
        }

        public static Bitmap retinex(Bitmap image, double sigma)
        {
            MatlabImage matlabImage = new MatlabImage(image);
            MWArray[] array = (MWArray[])MatlabHisto.SingleScaleRetinex(3, new MWNumericArray(sigma), (MWNumericArray)matlabImage.Red, (MWNumericArray)matlabImage.Green, (MWNumericArray)matlabImage.Blue);

            return PostProcessing.Normalization(new MatlabImage(array[0], array[1], array[2]), 255, 0).Bitmap;
        }

        public static Bitmap HistogramSlicing(Bitmap image, int oldMin, int oldMax, int NewValue)
        {

            MatlabImage matlabImage = new MatlabImage(image);

            MWArray[] array = (MWArray[])MatlabHisto.HistogramSlicing(3, (MWNumericArray)matlabImage.Red, (MWNumericArray)matlabImage.Green, (MWNumericArray)matlabImage.Blue, oldMin, oldMax, NewValue);

            return PostProcessing.Normalization(new MatlabImage(array[0], array[1], array[2]), 255, 0).Bitmap;
        }
 
        # region Equalization for one Color
        public static Bitmap EqualizeHistogram(Bitmap image, ColorEnum color)
        {
            int[] histogramValues = getValuesAfterEqualization(image, color);
            return ApplyChangesToThePictureAfterEquilization(image, histogramValues, color);
        }
        public static int[] getValuesAfterEqualization(Bitmap image, ColorEnum color)
        {

            int[] histogramValues = new int[256];
            int size = image.Height * image.Width;
            int[] imageValues = GetHistogramValues(image, color);
            for (int currentColor = 1; currentColor < 256; currentColor++)
                imageValues[currentColor] += imageValues[currentColor - 1];
                int maxValue = imageValues[255];

            for (int currentColor = 0; currentColor < 256; currentColor++)
            {
                histogramValues[currentColor] = (int)(((imageValues[currentColor] * 1.0 / maxValue * 1.0) * (255 * 1.0)));
                
            }

                
            return histogramValues;
        }
        public static Bitmap ApplyChangesToThePictureAfterEquilization(Bitmap image, int[] histogramValues, ColorEnum color)
        {
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();

            for (int currentRow = 0; currentRow < image.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < image.Width; currentColumn++)
                {
                    PixelData pixelData = unsafeImage.GetPixel(currentColumn, currentRow);
                    if (color == ColorEnum.Grey)
                    {
                        int currentColor = (int)((pixelData.Red + pixelData.Green + pixelData.Blue) / 3f);
                        int newValue = histogramValues[currentColor];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)newValue, (byte)newValue, (byte)newValue));
                    }
                    else if (color == ColorEnum.Red)
                    {
                        int newRedValue = histogramValues[(int)pixelData.Red];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)pixelData.Blue, (byte)newRedValue, (byte)pixelData.Green));
                    }
                    else if (color == ColorEnum.Green)
                    {
                        int newGreenValue = histogramValues[(int)pixelData.Green];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)pixelData.Blue, (byte)pixelData.Red, (byte)newGreenValue));
                    }
                    else if (color == ColorEnum.Blue)
                    {
                        int newBlueValue = histogramValues[(int)pixelData.Blue];
                        unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)newBlueValue, (byte)pixelData.Red, (byte)pixelData.Green));
                    }
                }
            }

            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
        }

        #endregion

        # region Get Histogram Values
        public static int[] GetHistogramValues(Bitmap image, ColorEnum color)
        {
            int[] histogramValues = new int[256];// from o to 255
            UnsafeBitmap unsafeImageBitmap = new UnsafeBitmap(image);
            unsafeImageBitmap.LockBitmap();
            int imageWidth = image.Width;
            int imageHeight = image.Height;
            for (int currentRow = 0; currentRow < imageWidth; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < imageHeight; currentColumn++)
                {

                    PixelData pixelData = unsafeImageBitmap.GetPixel(currentRow, currentColumn);
                    if (color == ColorEnum.Grey)
                    {
                        int greyColor = (int)((pixelData.Blue + pixelData.Green + pixelData.Red) / 3f);
                        histogramValues[greyColor]++;
                    }
                    else if (color == ColorEnum.Red)
                        histogramValues[(int)pixelData.Red]++;
                    else if (color == ColorEnum.Green)
                        histogramValues[(int)pixelData.Green]++;
                    else if (color == ColorEnum.Blue)
                        histogramValues[(int)pixelData.Blue]++;
                }
            }
            unsafeImageBitmap.UnlockBitmap();
            return histogramValues;
        }
        # endregion

        #region Equalization for the three colors at the same time
        public static Bitmap EqualizeRedGreenBlue(Bitmap image)
        {

            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();
            int size = image.Height * image.Width;
            int[] imageBlueValues = GetHistogramValues(image, ColorEnum.Blue);
            int[] imageRedValues = GetHistogramValues(image, ColorEnum.Red);
            int[] imageGreenValues = GetHistogramValues(image, ColorEnum.Green);

            int[] histogramRedValues = new int[256];
            int[] histogramGreenValues = new int[256];
            int[] histogramBlueValues = new int[256];

            for (int currentColor = 1; currentColor < 256; currentColor++)
            {
                imageRedValues[currentColor] += imageRedValues[currentColor - 1];
                imageGreenValues[currentColor] += imageGreenValues[currentColor - 1];
                imageBlueValues[currentColor] += imageBlueValues[currentColor - 1];
            }
            int maxRedValue = imageRedValues[255];
            int maxGreenValue = imageGreenValues[255];
            int maxBlueValue = imageBlueValues[255];
            for (int currentColor = 0; currentColor < 256; currentColor++)
            {
                histogramRedValues[currentColor] = (int)Math.Round(((imageRedValues[currentColor] / (maxRedValue * 1.0)) * 255));
                histogramGreenValues[currentColor] = (int)Math.Round(((imageGreenValues[currentColor] / (maxGreenValue * 1.0)) * 255));
                histogramBlueValues[currentColor] = (int)Math.Round((imageBlueValues[currentColor] / (maxBlueValue * 1.0)) * 255);
            }

            for (int currentRow = 0; currentRow < image.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < image.Width; currentColumn++)
                {

                    PixelData pixelData = unsafeImage.GetPixel(currentColumn, currentRow);

                    int newRedValue = histogramRedValues[(int)pixelData.Red];
                    int newGreenValue = histogramGreenValues[(int)pixelData.Green];
                    int newBlueValue = histogramBlueValues[(int)pixelData.Blue];

                    unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)newBlueValue, (byte)newRedValue, (byte)newGreenValue));
                }
            }

            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
        }
        #endregion

        #region Match Histogram for One Color
        public static Bitmap MatchHistogram(Bitmap firstImage, Bitmap secondImage, ColorEnum color)
        {
            int[] newColor = GetValuesAfterMatchingTheHistogram(firstImage, secondImage, color);
            return ApplyChangesTothePictureAfterMatching(firstImage, newColor, color);
        }
        public static int[] GetValuesAfterMatchingTheHistogram(Bitmap firstImage, Bitmap secondImage, ColorEnum color)
        {
            int[] firstHistogramValues = getValuesAfterEqualization(firstImage, color);
            int[] secondHistogramValues = getValuesAfterEqualization(secondImage, color);
            int[] newColor = new int[256];
         int min = 1000000;int lastIndex = 0;
            for (int currentIndex = 0; currentIndex < 256; currentIndex++)
            {
              //  lastIndex = 0;
                min = 1000000;
                while (lastIndex < 256)
                {
                    if (min > Math.Abs(firstHistogramValues[currentIndex] - secondHistogramValues[lastIndex]))
                        min = Math.Abs(firstHistogramValues[currentIndex] - secondHistogramValues[lastIndex]);
                    else if (min != Math.Abs(firstHistogramValues[currentIndex] - secondHistogramValues[lastIndex]))
                    {
                        lastIndex--;
                        break;
                    }
                    lastIndex++;
                }
                newColor[currentIndex] = lastIndex;
            }
            return newColor;
        }
        public static Bitmap ApplyChangesTothePictureAfterMatching(Bitmap firstImage, int[] newColor, ColorEnum color)
        {
            UnsafeBitmap unsafeFirstImage = new UnsafeBitmap(firstImage);
            unsafeFirstImage.LockBitmap();
            for (int i = 0; i < firstImage.Width; i++)
            {
                for (int j = 0; j < firstImage.Height; j++)
                {
                    PixelData pixelData = unsafeFirstImage.GetPixel(i, j);
                    if (color == ColorEnum.Grey)
                    {
                        int grey = (int)((pixelData.Blue + pixelData.Red + pixelData.Green) / 3f);
                        unsafeFirstImage.SetPixel(i, j, new PixelData((byte)newColor[grey], (byte)newColor[grey], (byte)newColor[grey]));
                    }
                    else if (color == ColorEnum.Red)
                        unsafeFirstImage.SetPixel(i, j, new PixelData(pixelData.Blue, (byte)newColor[(int)pixelData.Red], pixelData.Green));
                    else if (color == ColorEnum.Green)
                        unsafeFirstImage.SetPixel(i, j, new PixelData(pixelData.Blue, pixelData.Red, (byte)newColor[(int)pixelData.Green]));
                    else if (color == ColorEnum.Blue)
                        unsafeFirstImage.SetPixel(i, j, new PixelData((byte)newColor[(int)pixelData.Blue], pixelData.Red, pixelData.Green));
                }
            }
            unsafeFirstImage.UnlockBitmap();
            return unsafeFirstImage.Bitmap;
        }
        #endregion

        #region Match Three Colors
        public static Bitmap MatchingThreeColors(Bitmap firstImage, Bitmap secondImage)
        {
            int[] newRedColor = GetValuesAfterMatchingTheHistogram(firstImage, secondImage, ColorEnum.Red);
            int[] newGreenColor = GetValuesAfterMatchingTheHistogram(firstImage, secondImage, ColorEnum.Green);
            int[] newBlueColor = GetValuesAfterMatchingTheHistogram(firstImage, secondImage, ColorEnum.Blue);
            Bitmap afterRedModification = ApplyChangesTothePictureAfterMatching(firstImage, newRedColor, ColorEnum.Red);
            afterRedModification = ApplyChangesTothePictureAfterMatching(afterRedModification, newGreenColor, ColorEnum.Green);
            return ApplyChangesTothePictureAfterMatching(afterRedModification, newBlueColor, ColorEnum.Blue);
        }
        #endregion
    }
}