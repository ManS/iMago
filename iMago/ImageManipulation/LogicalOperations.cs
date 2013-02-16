using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;
using ImageManipulation;

namespace ImageManipulation
{
    public class LogicalOperations
    {
           public static Bitmap OringTwoImages (Bitmap firstImage,Bitmap secondImage)
           {
               UnsafeBitmap newImage=new UnsafeBitmap(firstImage.Width,firstImage.Height);
               UnsafeBitmap unsafeFirst=new UnsafeBitmap(firstImage);
               UnsafeBitmap unsafeSecond=new UnsafeBitmap(ImageResizer.Resize(secondImage,firstImage.Width,firstImage.Height,ResizeingMethod.Bilinear));
               unsafeFirst.LockBitmap();
               unsafeSecond.LockBitmap();
               newImage.LockBitmap();
               for(int i=0;i<firstImage.Width;i++)
               {
                   for(int j=0;j<firstImage.Height;j++)
                   {
                       PixelData firstPixelData=unsafeFirst.GetPixel(i,j);
                       PixelData secondPixelData=unsafeSecond.GetPixel(i,j);
                       newImage.SetPixel(i,j,new PixelData((byte)(firstPixelData.Blue|secondPixelData.Blue),(byte)(firstPixelData.Red|secondPixelData.Red),(byte)(firstPixelData.Green|secondPixelData.Green)));
                   }
               }
               unsafeFirst.UnlockBitmap();
               unsafeSecond.UnlockBitmap();
               newImage.UnlockBitmap();
              
               return newImage.Bitmap;
               
           }
           public static Bitmap AndingTwoImages (Bitmap firstImage,Bitmap secondImage)
           {
               UnsafeBitmap newImage=new UnsafeBitmap(firstImage.Width,firstImage.Height);
               UnsafeBitmap unsafeFirst=new UnsafeBitmap(firstImage);
               UnsafeBitmap unsafeSecond=new UnsafeBitmap(ImageResizer.Resize(secondImage,firstImage.Width,firstImage.Height,ResizeingMethod.Bilinear));
               unsafeFirst.LockBitmap();
               unsafeSecond.LockBitmap();
               newImage.LockBitmap();
               for(int i=0;i<firstImage.Width;i++)
               {
                   for(int j=0;j<firstImage.Height;j++)
                   {
                       PixelData firstPixelData=unsafeFirst.GetPixel(i,j);
                       PixelData secondPixelData=unsafeSecond.GetPixel(i,j);

                       newImage.SetPixel(i,j,new PixelData((byte)(firstPixelData.Blue&secondPixelData.Blue),(byte)(firstPixelData.Red&secondPixelData.Red),(byte)(firstPixelData.Green&secondPixelData.Green)));
                   }
               }
               unsafeFirst.UnlockBitmap();
               unsafeSecond.UnlockBitmap();
               newImage.UnlockBitmap();
              

               return newImage.Bitmap;
               
           }
    }
}

