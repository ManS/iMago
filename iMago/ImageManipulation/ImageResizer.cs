using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using Utilities;

namespace ImageManipulation
{
    #region Enums

    /// <summary>
    /// Enums represent all resizing methods.
    /// </summary>
   public enum ResizeingMethod
    {
       
        Bilinear,
        Bicubic,
        NearestNeighbors_0Order,
        NearestNeighbors_1Order
    };
    #endregion
  
    public class ImageResizer
    {
        #region StaticMethods

        /// <summary>
        /// Resizes the specified image.
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="p_NewWidth">New width of the p_.</param>
        /// <param name="p_NewHeight">New height of the p_.</param>
        /// <param name="p_ResizeMethod">The p_ resize method.</param>
        /// <returns></returns>
        static public Bitmap Resize(Bitmap Image, int p_NewWidth, int p_NewHeight, ResizeingMethod p_ResizeMethod)
        {
            //UnsafeBitmap tempUnsafeBitmap = new UnsafeBitmap(Image);
            //tempUnsafeBitmap.LockBitmap();
            float OldW = Image.Width;
            float OldH = Image.Height;
            switch (p_ResizeMethod)
            {
                case ResizeingMethod.Bilinear:
                    return ImageResizer.BilinearResizing(Image, p_NewWidth, p_NewHeight, OldW, OldH);
                case ResizeingMethod.Bicubic:
                    return ImageResizer.BicubicResizing(Image, p_NewWidth, p_NewHeight);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Do Bicubic resizing.
        /// </summary>
        /// <param name="OrigImg">The old image.</param>
        /// <param name="p_NewWidth">New width of the Image.</param>
        /// <param name="p_NewHeight">New height of the Image.</param>
        /// <returns>resized bitmap image</returns>
        private static Bitmap BicubicResizing(Bitmap Image, int p_NewWidth, int p_NewHeight)
        {
            if (p_NewHeight == Image.Height && p_NewWidth == Image.Width)
            {
                return Image;
            }

            UnsafeBitmap OrigImg = new UnsafeBitmap(Image);
            UnsafeBitmap newImg = new UnsafeBitmap(p_NewWidth, p_NewHeight);      // image after being resized
            newImg.LockBitmap();
            OrigImg.LockBitmap();
            double widthFract = (double)OrigImg.Bitmap.Width / p_NewWidth;   //The fraction by which width is resized
            double heightFract = (float)OrigImg.Bitmap.Height / p_NewHeight; //The fraction by which height is resized

            //BitmapData newImgData = newImg.LockBits(new Rectangle(0, 0, pNewWidth, pNewHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);  //The 2-D matrix of colors representing the new image 

            for (int i = 0; i < p_NewHeight; i++)
            {
                for (int j = 0; j < p_NewWidth; j++)
                {
                    double x = j * widthFract;
                    double y = i * heightFract;
                    int tempX = (int)(x);
                    int tempY = (int)(y);

                    double r = 0; //represet red component of pixel j,i after beeing inter polated
                    double g = 0; //represet red component of pixel j,i after beeing inter polated
                    double b = 0; //represet red component of pixel j,i after beeing inter polated

                    double dx = x - tempX; //the fractional part of x
                    double dy = y - tempY; //the fractional part of y

                    for (int m = -1; m < 3; m++)  //getting the 16 pixels around desired pixel  and interpolate their colors to get pixel's color
                    {
                        for (int n = -1; n < 3; n++)
                        {
                            int tempX2;   // to save x-component without ruining tempX and tempY for the next iterations
                            int tempY2;

                            PixelData tempC;
                            tempX2 = tempX + m; // m ranges frm -1 --> 2

                            if (tempX2 < 0) // to make sure x-component > 0
                                tempX2 = 0;

                            if (tempX2 > OrigImg.Bitmap.Width - 1) // to make sure x-component is not greater than original image's width
                                tempX2 = OrigImg.Bitmap.Width - 1;

                            tempY2 = tempY + n; // n ranges frm -1 --> 2

                            if (tempY2 < 0) // to make sure y-component > 0
                                tempY2 = 0;

                            if (tempY2 > OrigImg.Bitmap.Height - 1) // to make sure x-component is not greater than original image's width
                                tempY2 = OrigImg.Bitmap.Height - 1;

                            tempC = OrigImg.GetPixel(tempX2, tempY2);//origImgDataGetPixel(tempX2, tempY2, origImgData); //color of pixel around desired pixel
                            double Rx = GetR(m - dx) * GetR(dy - n);
                            r += ((double)tempC.Red * Rx); // getting percentage of red color taken from this pixel
                            g += ((double)tempC.Green * Rx); // getting percentage of green color taken from this pixel
                            b += ((double)tempC.Blue * Rx); //// getting percentage of blue color taken from this pixel
                        }
                    }

                    PixelData newPixelColor = new PixelData((byte)b, (byte)r, (byte)g); // color of current pixel after interpolation
                    newImg.SetPixel(j, i, newPixelColor);
                }
            }
            OrigImg.UnlockBitmap();
            newImg.UnlockBitmap();
            
            return newImg.Bitmap;
            ////Bitmap FilteredImage = ImageManipulations.ImageFiltering.LinearFilters(newImg.Bitmap, ImageManipulations.EnhancementType.Blurring, ImageManipulations.FilterName.MeanBlurringFilter, 3, 3, ImageManipulations.PaddingType.Zeros);
            ////////return FilteredImage;
            ////Bitmap sub = ArithmeticOperations.SubtractTwoImages(newImg.Bitmap, FilteredImage);
            //return (ArithmeticOperations.AddTwoImages(ImageAdjustment.AdjustContrast(newImg.Bitmap), sub));
            
        }
       
        /// <summary>
        /// Do Bilinear resizing.
        /// </summary>
        /// <param name="OldImage">The old image.</param>
        /// <param name="p_NewWidth">New width of the Image.</param>
        /// <param name="p_NewHeight">New height of the Image.</param>
        /// <param name="p_OldW">The old W.</param>
        /// <param name="p_OldH">The old H.</param>
        /// <returns></returns>
        private static Bitmap BilinearResizing(Bitmap Image, int p_NewWidth, int p_NewHeight, float p_OldW, float p_OldH)
        {
            if (p_NewHeight == Image.Height && p_NewWidth == Image.Width)
            {
                return Image;
            }
            UnsafeBitmap OldImage = new UnsafeBitmap(Image);
            OldImage.LockBitmap();
            UnsafeBitmap ResizedImage = new UnsafeBitmap(p_NewWidth, p_NewHeight);
            
            //Unlock bitmap data
            ResizedImage.LockBitmap();

            //Calculate WRatio & HRatio
            
            double WRatio = p_OldW / (double)p_NewWidth;
            double HRatio = p_OldH / (double)p_NewHeight;

            //For each empty location (New X, New Y) in the new buffer Do

            for (int NewX = 0; NewX < p_NewWidth; NewX++)
            {
                //1-	Calculate the corresponding location in the original buffer
                double OldX = (double)NewX * WRatio;
                for (int NewY = 0; NewY < p_NewHeight; NewY++)
                {
                
                    double OldY = (double)NewY * HRatio;

                    //2-	Find 4 adjacent pixels
                    int X1 = (int)Math.Floor(OldX), X2;
                      
                    int Y1 = (int)Math.Floor(OldY), Y2;
                    if (X1 < p_OldW - 1)
                        X2 = X1 + 1;
                    else
                        X2 = X1;
                    if (Y1 < p_OldH - 1)
                        Y2 = Y1 + 1;
                    else
                        Y2 = Y1;

                    PixelData P1 = OldImage.GetPixel(X1, Y1), P2 = OldImage.GetPixel(X2, Y1);
                    PixelData P3 = OldImage.GetPixel(X1, Y2), P4 = OldImage.GetPixel(X2, Y2);

                    //3-	Calculate X, Y fractions
                    double xFraction = OldX - X1;
                    double yFraction = OldY - Y1;

                    //4-	Interpolate in X-Direction
                    PixelData Z1 = new PixelData(), Z2 = new PixelData();
                    
                    Z1.Blue = (byte)(((double)P1.Blue * (1.0 - xFraction)) + ((double)P2.Blue * xFraction));
                    Z1.Green = (byte)(((float)P1.Green * (1.0 - xFraction)) + ((double)P2.Green * xFraction));
                    Z1.Red = (byte)(((double)P1.Red * (1.0 - xFraction)) + ((double)P2.Red * xFraction));


                    Z2.Blue = (byte)(((double)P3.Blue * (1.0 - xFraction)) + ((double)P4.Blue * xFraction));
                    Z2.Green = (byte)(((double)P3.Green * (1.0 - xFraction)) + ((double)P4.Green * xFraction));
                    Z2.Red = (byte)(((double)P3.Red * (1.0 - xFraction)) + ((double)P4.Red * xFraction));

                    //5-	Interpolate in Y-Direction

                    PixelData NewPixel = new PixelData();
                    NewPixel.Blue = (byte)(((double)Z1.Blue * (1.0 - yFraction)) + ((double)Z2.Blue * yFraction));
                    NewPixel.Green = (byte)(((float)Z1.Green * (1.0 - yFraction)) + ((double)Z2.Green * yFraction));
                    NewPixel.Red = (byte)(((double)Z1.Red * (1.0 - yFraction)) + ((double)Z2.Red * yFraction));

                    ResizedImage.SetPixel(NewX, NewY, new PixelData(NewPixel));

                }
            }
            OldImage.UnlockBitmap();
            ResizedImage.UnlockBitmap();

            return ResizedImage.Bitmap;
        }

        /// <summary>
        /// Resizes image by factor.
        /// </summary>
        /// <param name="OldImage">The old image.</param>
        /// <param name="p_resizeFactor">The resize factor.</param>
        /// <param name="p_ResizeMethod">The resize method.</param>
        /// <returns></returns>
        static public Bitmap ResizeByFactor(Bitmap OldImage, int p_resizeFactor, ResizeingMethod p_ResizeMethod)
        {

            UnsafeBitmap tempUnsafeBitmap = new UnsafeBitmap(OldImage);
            tempUnsafeBitmap.LockBitmap();

            switch (p_ResizeMethod)
            {
                case ResizeingMethod.NearestNeighbors_0Order:
                    return ImageResizer.NearestNighborsResize0Order(tempUnsafeBitmap, p_resizeFactor);
                case ResizeingMethod.Bicubic:
                    return ImageResizer.NearestNighborsResize1Order(tempUnsafeBitmap, p_resizeFactor);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Do Nearest the nighbors resizing [0-Order].
        /// </summary>
        /// <param name="OldImage">The old image.</param>
        /// <param name="p_resizeFactor">The resizing factor.</param>
        /// <returns></returns>
        private static Bitmap  NearestNighborsResize0Order(UnsafeBitmap OldImage, int p_resizeFactor)
        {
            int NewWidth = OldImage.Bitmap.Width * p_resizeFactor;
            int NewHeight = OldImage.Bitmap.Height * p_resizeFactor;
            UnsafeBitmap ResizedImage = new UnsafeBitmap(NewWidth, NewHeight);
            ResizedImage.LockBitmap();

            for (int i = 0; i < NewWidth; i++)
            {
                for (int j = 0; j < NewHeight; j++)
                {
                    ResizedImage.SetPixel(i, j, OldImage.GetPixel(i / p_resizeFactor, j / p_resizeFactor));
                }
            }

            ResizedImage.UnlockBitmap();
            return ResizedImage.Bitmap;
        }
        
        private static Bitmap NearestNighborsResize1Order(UnsafeBitmap tempUnsafeBitmap, int p_resizeFactor)
        {
            throw new NotImplementedException();
        }
        #endregion   

        #region Helper Functions
        private static double GetR(double pX)
        {

            double pX2 = GetP(pX + 2);
            double pX1 = GetP(pX + 1);
            double pX3 = GetP(pX);
            double pX4 = GetP(pX - 1);
            return (1.0 / 6.0 * ((pX2 * pX2 * pX2) - 4 * (pX1 * pX1 * pX1) + 6 * (pX3 * pX3 * pX3) - 4 * (pX4 * pX4 * pX4)));
        }
        private static double GetP(double x)
        {
            if (x > 0)
                return x;
            else
                return 0;
        }
        #endregion
    }
}
