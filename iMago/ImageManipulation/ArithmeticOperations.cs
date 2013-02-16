using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace ImageManipulation
{
   public class ArithmeticOperations
    {
        public static Bitmap NotOperation(Bitmap p_inputImage)
        {
            int Width = p_inputImage.Width;
            int Height = p_inputImage.Height;
            UnsafeBitmap currentImage = new UnsafeBitmap(p_inputImage);
            currentImage.LockBitmap();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    currentImage.SetPixel(i, j, new PixelData((byte)(255 - currentImage.GetPixel(i, j).Blue), (byte)(255 - currentImage.GetPixel(i, j).Red),
                        (byte)(255 - currentImage.GetPixel(i, j).Blue)));
                }
            }
            currentImage.UnlockBitmap();
            return currentImage.Bitmap;
        }
        public static Bitmap SubtractTwoImages(Bitmap p_firstImage, Bitmap p_secondImage)
        {
            int first_Width = p_firstImage.Width;
            int first_Height = p_firstImage.Height;
            UnsafeBitmap firstImage = new UnsafeBitmap(p_firstImage);
            UnsafeBitmap secondImage = new UnsafeBitmap(ImageResizer.Resize(p_secondImage, p_firstImage.Width, p_firstImage.Height, ResizeingMethod.Bilinear));

            RGB[,] Buffer = new RGB[p_firstImage.Width, p_firstImage.Height];

            firstImage.LockBitmap();
            secondImage.LockBitmap();
            for (int i = 0; i < first_Width; i++)
            {
                for (int j = 0; j < first_Height; j++)
                {
                    PixelData first = firstImage.GetPixel(i, j);
                    PixelData second = secondImage.GetPixel(i, j);
                    Buffer[i, j].Blue =first.Blue-second.Blue;
                    Buffer[i, j].Red = first.Red-second.Red;
                    Buffer[i, j].Green = first.Green-second.Green;
                }
            }

            firstImage.UnlockBitmap();
            secondImage.UnlockBitmap();


            return (PostProcessing.Normalization(Buffer, 255, 0));
        }
        public static Bitmap MultiplyImage(Bitmap p_firstImage, double val)
        {
            int first_Width = p_firstImage.Width;
            int first_Height = p_firstImage.Height;
            UnsafeBitmap firstImage = new UnsafeBitmap(p_firstImage);
          
            firstImage.LockBitmap();
           
            for (int i = 0; i < first_Width; i++)
            {
                for (int j = 0; j < first_Height; j++)
                {
                    PixelData c=firstImage.GetPixel(i, j);
                    double red=c.Red*val;
                    double green=c.Green*val;
                    double blue=c.Blue*val;
                    firstImage.SetPixel(i,j,new PixelData((byte)blue,(byte)red,(byte)green));
                }
            }
            firstImage.UnlockBitmap();
           
            return firstImage.Bitmap;
        }
        public static Bitmap AddTwoImages(Bitmap firstImage, Bitmap secondImage)
        {
            
            UnsafeBitmap unsafeFirst = new UnsafeBitmap(firstImage);

            UnsafeBitmap unsafeSecond = new UnsafeBitmap(ImageResizer.Resize(secondImage, firstImage.Width, firstImage.Height, ResizeingMethod.Bilinear));

            RGB[,] buffer= new RGB[firstImage.Width, firstImage.Height];
           


            unsafeFirst.LockBitmap();
            unsafeSecond.LockBitmap();

            //double maxB = double.MinValue;
            //double maxR = double.MinValue;
            //double maxG = double.MinValue;
            //double minR = double.MaxValue;
            //double minG = double.MaxValue;
            //double minB = double.MaxValue;

            for (int i = 0; i < firstImage.Width; i++)
            {
                for (int j = 0; j < firstImage.Height; j++)
                {
                    PixelData currentPixel1 = unsafeFirst.GetPixel(i, j);
                    PixelData currentPixel2 = unsafeSecond.GetPixel(i, j);

                    buffer[i, j] = new RGB(currentPixel1.Red + currentPixel2.Red, currentPixel1.Green + currentPixel2.Green, currentPixel1.Blue + currentPixel2.Blue);
                    //bufferG[i, j] = currentPixel1.Green + currentPixel2.Green;
                    //bufferR[i, j] = currentPixel1.Red + currentPixel2.Red;

                    //maxB = maxB < bufferB[i, j] ? bufferB[i, j] : maxB;
                    //maxR = maxR < bufferR[i, j] ? bufferR[i, j] : maxR;
                    //maxG = maxG < bufferG[i, j] ? bufferG[i, j] : maxG;

                    //minB = minB > bufferB[i, j] ? bufferB[i, j] : minB;
                    //minR = minR > bufferR[i, j] ? bufferR[i, j] : minR;
                    //minG = minG > bufferG[i, j] ? bufferG[i, j] : minG;
                }
            }



            //for (int i = 0; i < firstImage.Width; i++)
            //{
            //    for (int j = 0; j < firstImage.Height; j++)
            //    {
            //        double Blue = ((((bufferB[i, j] - minB) / (maxB - minB)) * (255.0 - 0)) + 0);
            //        double Green = ((((bufferG[i, j] - minG) / (maxG - minG)) * (255.0 - 0)) + 0);
            //        double Red = ((((bufferR[i, j] - minR) / (maxR - minR)) * (255.0 - 0)) + 0);

            //        unsafeFirst.SetPixel(i, j, new PixelData((byte)Blue, (byte)Red, (byte)Green));

            //    }
            //}

            unsafeFirst.UnlockBitmap();
            unsafeSecond.UnlockBitmap();

            return PostProcessing.Normalization(buffer,255,0);
        }
    }
}
