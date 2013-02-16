using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing.Drawing2D;
using ImageStatistics;
using Utilities;

namespace ImageManipulation
{
   public class ImageOperation
    {
       #region Translation
         static public Bitmap Translate(Bitmap p_InputImage, int p_xFactor, int p_yFactor)
        {
            int Width = p_InputImage.Width;
            int Height = p_InputImage.Height;
            UnsafeBitmap OldImage = new UnsafeBitmap(p_InputImage);
            UnsafeBitmap FinalImage = new UnsafeBitmap(Width, Height);

            OldImage.LockBitmap();
            FinalImage.LockBitmap();

            for (int i = 0; i < p_xFactor; i++)
                for (int j = 0; j < p_yFactor; j++)
                    FinalImage.SetPixel(i, j, OldImage.GetPixel(i + Width - p_xFactor, j + Height - p_yFactor));

            for (int i = 0; i < Width - p_xFactor; i++)
                for (int j = 0; j < Height - p_yFactor; j++)
                    FinalImage.SetPixel(i + p_xFactor, j + p_yFactor, OldImage.GetPixel(i, j));

            for (int i = p_xFactor; i < Width; i++)
                for (int j = 0; j < p_yFactor; j++)
                    FinalImage.SetPixel(i, j, OldImage.GetPixel(i - p_xFactor, Height - p_yFactor + j));

            for (int i = 0; i < p_xFactor; i++)
                for (int j = p_yFactor; j < Height; j++)
                    FinalImage.SetPixel(i, j, OldImage.GetPixel((Width - p_xFactor) + i, j - p_yFactor));

            OldImage.UnlockBitmap();
            FinalImage.UnlockBitmap();

            return FinalImage.Bitmap;
        }
         #endregion
       
       #region Rotation

         public static Bitmap ImageRotateByPixels(Bitmap img, float angle)
         {
             double ThetaInRadians = (double)(angle * 2 * Math.PI) / 360f;
             double PIDivide2 = Math.PI / 2f;
             double oppositeBottom, oppositeTop, adjacentBottom, adjacentTop;
             if ((ThetaInRadians < PIDivide2 && ThetaInRadians >= 0) || (ThetaInRadians < PIDivide2 + Math.PI && ThetaInRadians >= Math.PI))
             {
                 oppositeBottom = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Height;
                 oppositeTop = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Width;
                 adjacentBottom = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Height;
                 adjacentTop = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Width;
             }
             else
             {
                 oppositeBottom = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Width;
                 oppositeTop = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Height;
                 adjacentBottom = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Width;
                 adjacentTop = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Height;

             }
             double newWidth, newHeight;
             newWidth = oppositeBottom + adjacentTop;
             newHeight = oppositeTop + adjacentBottom;
             int newIntegerWidth = (int)Math.Ceiling(newWidth);
             int newIntegerHeigh = (int)Math.Ceiling(newHeight);
             Bitmap newRotatedImage = new Bitmap(newIntegerWidth, newIntegerHeigh);
             UnsafeBitmap unsafeOldImage = new UnsafeBitmap(img);
             UnsafeBitmap newUnSafe = new UnsafeBitmap(newRotatedImage);
             unsafeOldImage.LockBitmap();
             newUnSafe.LockBitmap();
             int z = newIntegerWidth / 2;
             int w = newIntegerHeigh / 2;
             for (int i = 0; i < newIntegerWidth; i++)
             {
                 for (int j = 0; j < newIntegerHeigh; j++)
                 {
                     int x = (int)(((i -z) * Math.Cos(ThetaInRadians) + (j-w) * Math.Sin(  ThetaInRadians)))+(img.Width/2);
                     int y=(int)((-1*(i-z) *Math.Sin(  ThetaInRadians)+(j-w)* Math.Cos((ThetaInRadians))))+(img.Height/2);
                     if(x>=0&&y>=0&&x<img.Width&&y<img.Height)
                        
                         newUnSafe.SetPixel(i, j, unsafeOldImage.GetPixel(x, y));
                 }
             }
             unsafeOldImage.UnlockBitmap();
             newUnSafe.UnlockBitmap();
             return newUnSafe.Bitmap;
         }

         public static Bitmap ImageRotate(Bitmap img, float angle)
        {

            /*
            * first :
            * --------
            * i need to find the new width and the new height of the new image after rotation 
            * so that i could make a new bitmap withe new width and the new height 
            * the question now is how i could get the new width and the new heigh well open the image in the attached mail
            * u will find theta ( the angle of rotation)
            * from (thanawia 3ama :D ) 
            * cos (theta)=adjacent/hypotenos
            * sin(theta)=opposite/hypotenos
            * so we can get the new width by (hypotenos of the bottom triangle *sin(theta)   )+(hypotnos of the top triangle * cos (theta))
            * and the height by (hypotenos of the bottom triangle * cos (Theta)) +(hypotonos of the top triangle * sin(theta)
            * 
            * now we could make a new bitmap ;D
            * but there is a problem i need to know what specifically is the hypotons of the bottom and top triangle
            * see the 4 attached pictures in the 4 cases (we can know specifically the length of the hyp of the bottom and top)
            */

            double ThetaInRadians = (double)(angle * 2 * Math.PI) / 360f;
            while (ThetaInRadians < 0.0)
                ThetaInRadians += 2 * Math.PI;

             
            double PIDivide2 = Math.PI / 2f;
            double oppositeBottom, oppositeTop, adjacentBottom, adjacentTop;
            if ((ThetaInRadians < PIDivide2 && ThetaInRadians >= 0) || (ThetaInRadians < PIDivide2 + Math.PI && ThetaInRadians >= Math.PI))
            {
                oppositeBottom = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Height;
                oppositeTop = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Width;
                adjacentBottom = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Height;
                adjacentTop = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Width;
            }
            else
            {
                oppositeBottom = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Width;
                oppositeTop = Math.Abs(Math.Cos(ThetaInRadians)) * img.Size.Height;
                adjacentBottom = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Width;
                adjacentTop = Math.Abs(Math.Sin(ThetaInRadians)) * img.Size.Height;

            }
            double newWidth, newHeight;
            newWidth = oppositeBottom + adjacentTop;
            newHeight = oppositeTop + adjacentBottom;
            int newIntegerWidth = (int)Math.Ceiling(newWidth);
            int newIntegerHeigh = (int)Math.Ceiling(newHeight);
            Bitmap newRotatedImage = new Bitmap(newIntegerWidth, newIntegerHeigh);
            Graphics g = Graphics.FromImage(newRotatedImage);
            Point[] points;

            if (ThetaInRadians >= 0.0 && ThetaInRadians < PIDivide2)
            {
                points = new Point[] { 
                                             new Point( (int) oppositeBottom, 0 ), 
                                             new Point( newIntegerWidth, (int) oppositeTop ),
                                             new Point( 0, (int) adjacentBottom )
                                         };

            }
            else if (ThetaInRadians >= PIDivide2 && ThetaInRadians < Math.PI)
            {
                points = new Point[] { 
                                             new Point( newIntegerWidth, (int) oppositeTop ),
                                             new Point( (int) adjacentTop, newIntegerHeigh ),
                                        	new Point( (int) oppositeBottom, 0 )		
                                          
                                         };
            }
            else if (ThetaInRadians >= Math.PI && ThetaInRadians < (Math.PI + PIDivide2))
            {
                points = new Point[] { 
                                             new Point( (int) adjacentTop, newIntegerHeigh ), 
                                             new Point( 0, (int) adjacentBottom ),
                                             new Point( newIntegerWidth, (int) oppositeTop ),
                                          
                                         };
            }
            else
            {
                points = new Point[] { 
                                             new Point( 0, (int) adjacentBottom ), 
                                             new Point( (int) oppositeBottom, 0 ),
                                             new Point( (int) adjacentTop, newIntegerHeigh )		
                                         };
            }
            g.DrawImage(img, points);
            return newRotatedImage;


        }
        #endregion
       
       #region Flipping
        public static Bitmap FlippingTheImageHorizontally(Bitmap image)
        {
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            UnsafeBitmap newUnsafeImage = new UnsafeBitmap(image.Width, image.Height);
            unsafeImage.LockBitmap();
            newUnsafeImage.LockBitmap();
            for (int i = 0,k=image.Width-1; i < image.Width; i++,k--)
            {
                for (int j = 0; j < image.Height; j++)
                {
                 PixelData pixelData=  new PixelData( unsafeImage.GetPixel(i, j));
                 newUnsafeImage.SetPixel(k, j, pixelData);
                }
            }
            unsafeImage.UnlockBitmap();
            newUnsafeImage.UnlockBitmap();
            return newUnsafeImage.Bitmap;
        }
        public static Bitmap FlippingTheImageVertically(Bitmap image)
        {
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            UnsafeBitmap newUnsafeImage = new UnsafeBitmap(image.Width, image.Height);
            unsafeImage.LockBitmap();
            newUnsafeImage.LockBitmap();
            for (int i = 0;i < image.Width; i++)
            {
                for (int j = 0,k=image.Height-1; j < image.Height; j++,k--)
                {
                    PixelData pixelData = new PixelData(unsafeImage.GetPixel(i, j));
                    newUnsafeImage.SetPixel(i, k, pixelData);
                }
            }
            unsafeImage.UnlockBitmap();
            newUnsafeImage.UnlockBitmap();
            return newUnsafeImage.Bitmap;
        }
        #endregion

       #region Image Bordering
       public static Bitmap BordarizeTheImage(Bitmap image,Bitmap border)
        {

            //Bitmap ResizedImage = ImageResizer.Resize(image, border.Width, border.Height, ResizeingMethod.Bilinear);

            return ArithmeticOperations.AddTwoImages(border, image);
            /* ResizedImage.LockBitmap();
            unsafeImage.LockBitmap();
            for (int i = -yBorder; i < image.Width + yBorder; i++)
            {
                for (int j = -xBorder; j < image.Height + xBorder; j++)
                {
                    if (i < 0 && j <0)
                    {
                        ResizedImage.SetPixel((i + yBorder),( j + xBorder), new PixelData(0, 0, 0));
                    }
                    else if (i <0 )
                    {
                        ResizedImage.SetPixel((i + yBorder), j , new PixelData(0, 0, 0));
                    }
                    else if (j < 0)
                    {
                        ResizedImage.SetPixel(i ,( j+ xBorder) , new PixelData(0, 0, 0));
                    }
                    else if(i < image.Width && j < image.Height)
                    {
                        ResizedImage.SetPixel(i+yBorder, j+xBorder , unsafeImage.GetPixel(i,j));
                    }
                    else if (i < image.Width)
                    {
                        ResizedImage.SetPixel(i + yBorder, j, new PixelData(0,0,0));
                    }
                    else if (j < image.Height)
                    {
                        ResizedImage.SetPixel(i, j + yBorder, new PixelData(0, 0, 0));
                    }
                }
            }
            ResizedImage.UnlockBitmap();
            unsafeImage.UnlockBitmap();

            return ResizedImage.Bitmap;*/
        }
       #endregion



        #region funs
       public static Bitmap Thresholding(int threshold, Bitmap Image)
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
        #endregion
    }
}