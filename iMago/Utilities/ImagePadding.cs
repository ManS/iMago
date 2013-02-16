using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilities
{
    public enum PaddingType { Replication, Zeros };

    public abstract class ImagePadding
    {
        public static Bitmap PaddingImage(Bitmap image, int xMaskSize, int yMaskSize, PaddingType typeOfPadding)
        {
            switch (typeOfPadding)
            {
                case PaddingType.Replication:
                    return PaddingByReplicating(image, xMaskSize, yMaskSize);
                case PaddingType.Zeros:
                    return PaddingByZeros(image, xMaskSize, yMaskSize);
                default:
                    throw new NotImplementedException();
            }
        }
        private static Bitmap PaddingByReplicating(Bitmap image, int maskWidth, int maskHeight)
        {
            int noOfRowsAdded = maskHeight / 2;
            int noOfColumnsAdded = maskWidth / 2;
            UnsafeBitmap oldImage = new UnsafeBitmap(image);
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image.Width + 2 * noOfColumnsAdded, image.Height + 2 * noOfRowsAdded);
            unsafeImage.LockBitmap();
            oldImage.LockBitmap();

            for (int i = noOfColumnsAdded; i < image.Width + noOfColumnsAdded; i++)
            {
                for (int j = noOfRowsAdded; j < image.Height + noOfRowsAdded; j++)
                {
                    PixelData pixelData = oldImage.GetPixel(i - noOfColumnsAdded, j - noOfRowsAdded);
                    unsafeImage.SetPixel(i, j, pixelData);
                }
            }


            for (int i = 0; i < noOfColumnsAdded; i++)
                for (int j = noOfRowsAdded; j < image.Height + noOfRowsAdded; j++)
                {
                    PixelData pixelData = oldImage.GetPixel(i, j - noOfRowsAdded);
                    unsafeImage.SetPixel(i, j, pixelData);
                }

            for (int i = image.Width + noOfColumnsAdded; i < image.Width + 2 * noOfColumnsAdded; i++)
                for (int j = noOfRowsAdded; j < image.Height + noOfRowsAdded; j++)
                {
                    PixelData pixelData = oldImage.GetPixel(i - 2 * noOfColumnsAdded, j - noOfRowsAdded);
                    unsafeImage.SetPixel(i, j, pixelData);

                }

            for (int i = 0; i < image.Width + 2 * noOfColumnsAdded; i++)
                for (int j = 0; j < noOfRowsAdded; j++)
                {
                    PixelData pixelData = unsafeImage.GetPixel(i, j + noOfRowsAdded);
                    unsafeImage.SetPixel(i, j, pixelData);
                }

            for (int i = 0; i < image.Width + 2 * noOfColumnsAdded; i++)
                for (int j = image.Height + noOfRowsAdded; j < image.Height + 2 * noOfRowsAdded; j++)
                {
                    PixelData pixelData = unsafeImage.GetPixel(i, j - noOfRowsAdded);
                    unsafeImage.SetPixel(i, j, pixelData);
                }

            oldImage.UnlockBitmap();
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;

        }
        private static Bitmap PaddingByZeros(Bitmap image, int maskWidth, int maskHeight)
        {
            int noOFRowTobeAdded = maskHeight / 2;
            int noOfColumnsToBeAdded = maskWidth / 2;
            UnsafeBitmap oldImage = new UnsafeBitmap(image);
            oldImage.LockBitmap();
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image.Width + 2 * noOfColumnsToBeAdded, image.Height + 2 * noOFRowTobeAdded);
            unsafeImage.LockBitmap();

            for (int i = 0; i < image.Width + 2 * noOfColumnsToBeAdded; i++)
                for (int j = 0; j < noOFRowTobeAdded; j++)
                    unsafeImage.SetPixel(i, j, new PixelData(0, 0, 0));

            for (int i = 0; i < image.Width + 2 * noOfColumnsToBeAdded; i++)
                for (int j = image.Height + noOFRowTobeAdded; j < image.Height + 2 * noOFRowTobeAdded; j++)
                    unsafeImage.SetPixel(i, j, new PixelData(0, 0, 0));

            for (int i = 0; i < noOfColumnsToBeAdded; i++)
                for (int j = image.Height + noOFRowTobeAdded; j < image.Height + 2 * noOFRowTobeAdded; j++)
                    unsafeImage.SetPixel(i, j, new PixelData(0, 0, 0));

            for (int i = image.Width + noOfColumnsToBeAdded; i < image.Width + 2 * noOfColumnsToBeAdded; i++)
                for (int j = 0; j < image.Height + 2 * noOFRowTobeAdded; j++)
                    unsafeImage.SetPixel(i, j, new PixelData(0, 0, 0));

            for (int i = noOfColumnsToBeAdded; i < image.Width + noOfColumnsToBeAdded; i++)
            {
                for (int j = noOFRowTobeAdded; j < image.Height + noOFRowTobeAdded; j++)
                {
                    PixelData pixelData = oldImage.GetPixel(i - noOfColumnsToBeAdded, j - noOFRowTobeAdded);
                    unsafeImage.SetPixel(i, j, pixelData);
                }
            }


            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;

        }
    }
}