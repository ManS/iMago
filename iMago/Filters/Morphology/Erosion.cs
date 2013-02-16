using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.Morphology
{
    /// <summary>
    /// Erosion Filter
    /// </summary>
    public class Erosion : IMorphologyFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Erosion"/> class.
        /// </summary>
        /// <param name="se">The se.</param>
        /// <param name="seCenter">The se center.</param>
        public Erosion(byte[,] se, Point seCenter)
            : base(se, seCenter)
        { }

        /// <summary>
        /// Applies the morphology.
        /// </summary>
        /// <param name="sourceImage">The source image.</param>
        /// <returns></returns>
        public override Bitmap ApplyMorphology(Bitmap sourceImage)
        {    
            Point SeCenter = this.SECenter;
            byte[,] reflectedSE = ReflectSE(SE, ref SeCenter);

            int Width = sourceImage.Width;
            int Height = sourceImage.Height;

            
 
            Bitmap BinaryPaddedImage = PaddingByZerosAndBinarization(sourceImage, SeCenter, this.SE.GetLength(1), this.SE.GetLength(0));

            UnsafeBitmap unSafeImage = new UnsafeBitmap(BinaryPaddedImage);
            UnsafeBitmap newUnsafeImage = new UnsafeBitmap(Width, Height);

            unSafeImage.LockBitmap();
            newUnsafeImage.LockBitmap();

            int columns = reflectedSE.GetLength(1);
            int rows = reflectedSE.GetLength(0);
            int SECenterX = SeCenter.X;
            int SECenterY = SeCenter.Y;
            int noOfPointsAfterTheCenterX = columns - (SECenterX + 1);
            int noOfPointsAfterTheCentery = rows - (SECenterY + 1);
            bool entered = true;
            for (int i = SECenterX; i < BinaryPaddedImage.Width - noOfPointsAfterTheCenterX; i++)
            {
                for (int j = SECenterY; j < BinaryPaddedImage.Height - noOfPointsAfterTheCentery; j++)
                {
                    for (int k = -1 * SECenterX; k <= noOfPointsAfterTheCenterX; k++)
                    {
                        for (int h = -1 * SECenterY; h <= noOfPointsAfterTheCentery; h++)
                        {
                            PixelData pixelData = unSafeImage.GetPixel(i + k, j + h);
                            if ((byte)pixelData.Red == 0 && reflectedSE[h + SECenterY, k + SECenterX] == 1)
                            {
                                entered = false; break;
                            }

                        }
                        if (!entered)
                        { break; }


                    }
                    if (entered)
                        newUnsafeImage.SetPixel(i - SECenterX, j - SECenterY, new PixelData((byte)255, (byte)255, (byte)255));
                    else newUnsafeImage.SetPixel(i - SECenterX, j - SECenterY, new PixelData((byte)0, (byte)0, (byte)0));
                    entered = true;

                }
            }


            unSafeImage.UnlockBitmap();
            newUnsafeImage.UnlockBitmap();
            return newUnsafeImage.Bitmap;

        }
    }
}
