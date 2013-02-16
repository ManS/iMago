using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.Morphology
{
    /// <summary>
    /// abstract Base class for Morphology filters
    /// </summary>
   abstract public class IMorphologyFilter
    {
  
       /// <summary>
        /// Gets or sets the Structure Element.
        /// </summary>
        /// <value>The Structure Element.</value>
       public byte[,] SE { get; private set; }
      
       /// <summary>
       /// Gets or sets the Structure Element center.
       /// </summary>
       /// <value>The Structure Element center.</value>
       public Point SECenter { get;  set; }

       /// <summary>
       /// Initializes a new instance of the <see cref="IMorphologyFilter"/> class.
       /// </summary>
       /// <param name="se">The se.</param>
       /// <param name="seCenter">The se center.</param>
       public IMorphologyFilter(byte[,] se, Point seCenter)
       {
            this.SE = se;
            this.SECenter = seCenter;
       }

       /// <summary>
       /// Applies the morphology.
       /// </summary>
       /// <param name="sourceImage">The source image.</param>
       /// <returns></returns>
       abstract public Bitmap ApplyMorphology(Bitmap sourceImage);
       
       /// <summary>
       /// Reflects the Structure Element.
       /// </summary>
       /// <param name="SE">The Structure Element.</param>
       /// <param name="SECenter">The Structure Element center.</param>
       /// <returns></returns>
       public  byte[,] ReflectSE(byte[,] SE, ref Point SECenter)
       {
           Point old = SECenter;
           int rows = SE.GetLength(0);
           int columns = SE.GetLength(1);
           byte[,] newReflected = new byte[rows, columns];
           int tempColumn = columns - 1, tempRow = rows - 1;

           for (int i = 0; i < rows; i++)
           {
               for (int j = 0; j < columns; j++)
               {
                   if (j == old.X && i == old.Y)
                   {
                       SECenter.X = tempColumn;
                       SECenter.Y = tempRow;
                   }
                   newReflected[tempRow, tempColumn] = SE[i, j];
                   tempColumn--;
               }
               tempColumn = columns - 1;
               tempRow--;
           }
           return newReflected;
       }

       /// <summary>
       /// Paddings the by zeros and binarization.
       /// </summary>
       /// <param name="image">The image.</param>
       /// <param name="SECenter">The SE center.</param>
       /// <param name="SEWidth">Width of the SE.</param>
       /// <param name="SEHeight">Height of the SE.</param>
       /// <returns></returns>
       protected static Bitmap PaddingByZerosAndBinarization(Bitmap image, Point SECenter, int SEWidth, int SEHeight)
       {
           int noOfTopRowsToBedAdded = SECenter.Y;
           int noOfLeftColumnsToBeAdded = SECenter.X;
           int noOfBottomRowsToBeAdded = SEHeight - (SECenter.Y + 1);
           int noOfRightColumnsToBeAdded = SEWidth - (SECenter.X + 1);

           UnsafeBitmap oldImage = new UnsafeBitmap(image);
           oldImage.LockBitmap();
           UnsafeBitmap unsafeImage = new UnsafeBitmap(image.Width + noOfLeftColumnsToBeAdded + noOfRightColumnsToBeAdded, image.Height + noOfTopRowsToBedAdded + noOfBottomRowsToBeAdded);
           unsafeImage.LockBitmap();
           for (int i = noOfLeftColumnsToBeAdded; i < image.Width + noOfLeftColumnsToBeAdded; i++)
           {
               for (int j = noOfTopRowsToBedAdded; j < image.Height + noOfTopRowsToBedAdded; j++)
               {
                   PixelData pixelData = oldImage.GetPixel(i - noOfLeftColumnsToBeAdded, j - noOfTopRowsToBedAdded);
                   int gray = (int)((pixelData.Red + pixelData.Green + pixelData.Blue) / 3f);
                   if (gray >= 128)
                   {
                       unsafeImage.SetPixel(i, j, new PixelData((byte)255, (byte)255, (byte)255));
                   }

                   else { unsafeImage.SetPixel(i, j, new PixelData((byte)0, (byte)0, (byte)0)); }
               }
           }
           oldImage.UnlockBitmap();
           unsafeImage.UnlockBitmap();
           return unsafeImage.Bitmap;

       }
   }
}
