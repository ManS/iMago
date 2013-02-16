using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using Utilities;

namespace ImageManipulation
{
    abstract public class ImageQuantization
    {
        public static Bitmap QuantizeTheImage(Bitmap image, int p_QuantizationMask)
        {
            byte maskValue = (byte)p_QuantizationMask;

            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    PixelData currentPixel = unsafeImage.GetPixel(i, j);
                    byte OldBlue = currentPixel.Blue;
                    byte OldRed = currentPixel.Red;
                    byte OldGreen = currentPixel.Green;

                    byte NewBlue = (byte)(OldBlue & maskValue);
                    byte NewRed = (byte)(OldRed & maskValue);
                    byte NewGreen = (byte)(OldGreen & maskValue);

                    unsafeImage.SetPixel(i, j, new PixelData(NewBlue, NewRed, NewGreen));
                }
            }
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
        }
        
        public static Bitmap QuantizeTheImage(Bitmap image, byte bpp)
        {
            int maskValue =( 255 - ((1 << (8 - bpp)) - 1));
            return QuantizeTheImage(image, maskValue);
        }

        public static Bitmap BitSliceQuantizeByColor(Bitmap image, int bitSlice, Colors color)
        {
            bitSlice = 255 - bitSlice;
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    PixelData currentPixel = unsafeImage.GetPixel(j, i);
                    byte OldBlue = currentPixel.Blue;
                    byte OldRed = currentPixel.Red;
                    byte OldGreen = currentPixel.Green;

                    switch (color)
                    {
                        case Colors.Red:
                            {
                                OldRed = (byte)(bitSlice & OldRed);
                            }
                            break;
                        case Colors.Blue:
                            {
                                OldBlue = (byte)(bitSlice & OldBlue);
                            }
                            break;
                        case Colors.Green:
                            {
                                OldGreen = (byte)(bitSlice & OldGreen);
                            }
                            break;
                        default:
                            break;
                    }
                    unsafeImage.SetPixel(j, i, new PixelData(OldBlue, OldRed, OldGreen));
                }
            }
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
        }

        public static Bitmap ReturnQuantizedBitSliceByColor(Bitmap Originalimage, Bitmap BitsliceImage, byte bitSlice, Colors color)
        {
            UnsafeBitmap unsafeOrigImage = new UnsafeBitmap(Originalimage);
            UnsafeBitmap unsafeBitsliceImage = new UnsafeBitmap(BitsliceImage);

            unsafeOrigImage.LockBitmap();
            unsafeBitsliceImage.LockBitmap();

            for (int i = 0; i < Originalimage.Height; i++)
            {
                for (int j = 0; j < Originalimage.Width; j++)
                {
                    PixelData currentOrigPixel = unsafeOrigImage.GetPixel(j, i);
                    PixelData currentBitslicePixel = unsafeBitsliceImage.GetPixel(j, i);
                    byte OldBlue = currentOrigPixel.Blue;
                    byte OldRed = currentOrigPixel.Red;
                    byte OldGreen = currentOrigPixel.Green;

                    switch (color)
                    {
                        case Colors.Red:
                            {
                                if (currentBitslicePixel.Blue == 0)
                                    OldRed = (byte)(bitSlice | OldRed);
                                
                            }
                            break;
                        case Colors.Blue:
                            {
                                if (currentBitslicePixel.Green == 0)
                                    OldBlue = (byte)(bitSlice | OldBlue);
                            }
                            break;
                        case Colors.Green:
                            {
                                if (currentBitslicePixel.Blue == 0)
                                 OldGreen = (byte)(bitSlice | OldGreen);
                            }
                            break;
                        default:
                            break;
                    }
                    unsafeOrigImage.SetPixel(j, i, new PixelData(OldBlue, OldRed, OldGreen));
                }
            }

            unsafeOrigImage.UnlockBitmap();
            unsafeBitsliceImage.UnlockBitmap();
            return unsafeOrigImage.Bitmap;
        }

        public static Bitmap GetQuantizedBitSliceByColor(Bitmap image, byte bitSlice, Colors color)
        {

            UnsafeBitmap tempBitmap = new UnsafeBitmap(image.Width, image.Height);
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();
            tempBitmap.LockBitmap();
            byte Red = 255;
            byte Green = 255;
            byte Blue = 255;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    PixelData currentPixel = unsafeImage.GetPixel(i, j);
                    Blue = currentPixel.Blue;
                    Green = currentPixel.Green;
                    Red = currentPixel.Red;

                    switch (color)
                    {
                        case Colors.Red:
                            {
                                byte check = (byte)(currentPixel.Red & bitSlice);
                                if (check == 0)
                                    tempBitmap.SetPixel(i, j, new PixelData(255, 255, 255));
                                else
                                    tempBitmap.SetPixel(i, j, new PixelData(0, 255, 0));
                            }
                            break;
                        case Colors.Blue:
                            {
                                byte check = (byte)(currentPixel.Red & bitSlice);
                                if (check == 0)
                                    tempBitmap.SetPixel(i, j, new PixelData(255, 255, 255));
                                else
                                    tempBitmap.SetPixel(i, j, new PixelData(255, 0, 0));
                            }
                            break;
                        case Colors.Green:
                            {
                                byte check = (byte)(currentPixel.Red & bitSlice);

                                if (check == 0)
                                    tempBitmap.SetPixel(i, j, new PixelData(255, 255, 255));
                                else
                                    tempBitmap.SetPixel(i, j, new PixelData(0, 0, 255));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            unsafeImage.UnlockBitmap();
            tempBitmap.UnlockBitmap();

            return tempBitmap.Bitmap;
        }

        public static List<List<UnsafeBitmap>> GetQuantizedImagesListByColor(Bitmap image)
        {
            List<List<UnsafeBitmap>> unsafeimagesList = new List<List<UnsafeBitmap>>();
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
            unsafeImage.LockBitmap();
            for (int i = 0; i < 3; i++)
            {
                unsafeimagesList.Add(new List<UnsafeBitmap>());
                for (int j = 0; j < 8; j++)
                {
                    unsafeimagesList[i].Add( new UnsafeBitmap(image.Width, image.Height));
                    unsafeimagesList[i][j].LockBitmap();
                }
            }

            byte Rcheck;
            byte Gcheck;
            byte Bcheck;
            byte bitSlice;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    PixelData currentPixel = unsafeImage.GetPixel(i,j);

                    
                    for (int u = 0; u < 3; u++)
                    {
                        
                        for (int k = 0; k < 8; k++)
                        {
                            bitSlice = (byte)Math.Pow(2,7-k);//calc mask

                            Rcheck = (byte)(currentPixel.Red & bitSlice);
                            Gcheck = (byte)(currentPixel.Green & bitSlice);
                            Bcheck = (byte)(currentPixel.Blue & bitSlice); 
                           
                            if (u == 0)//red
                            {
                                if (Rcheck == 0)
                                    unsafeimagesList[u][k].SetPixel(i, j, new PixelData(255, 255, 255));
                                else
                                    unsafeimagesList[u][k].SetPixel(i, j, new PixelData(0, 255, 0));
                            }
                            else if (u == 1)//green
                            {
                                if (Gcheck == 0)
                                    unsafeimagesList[u][k].SetPixel(i, j, new PixelData(255, 255, 255));
                                else
                                    unsafeimagesList[u][k].SetPixel(i, j, new PixelData(0, 0, 255));
                            }
                            else if (u == 2)//blue
                            {
                                if (Bcheck == 0)
                                    unsafeimagesList[u][k].SetPixel(i, j, new PixelData(255, 255, 255));
                                else
                                    unsafeimagesList[u][k].SetPixel(i, j, new PixelData(255, 0, 0));
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 8; j++)
                    unsafeimagesList[i][j].UnlockBitmap();
            unsafeImage.UnlockBitmap();

            return unsafeimagesList;
        }

        public static void SaveQuantizedImage(Bitmap p_image, string p_fileSavingPath,int p_bpp)
        {
            //FileStream quantizedImage = new FileStream(p_fileSavingPath, FileMode.Create ,FileAccess.Write);
           // StreamWriter strwriter = new StreamWriter(quantizedImage);
           // BinaryWriter binWriter = new BinaryWriter(quantizedImage);

           /* strwriter.WriteLine("kmf");
            strwriter.WriteLine("# Created By Keep Moving Forward IP Package !");
            strwriter.WriteLine(p_image.Width.ToString() + " " + p_image.Height.ToString());
            strwriter.WriteLine("225");
            strwriter.Close();*/

            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(p_fileSavingPath, FileMode.Create));
            UnsafeBitmap unsafeImage = new UnsafeBitmap(p_image);
            unsafeImage.LockBitmap();
            List<byte> data = new List<byte>();
            //byte[] data = new byte[p_image.Width * p_image.Height];
            

            for (int i = 0; i < p_image.Width; i++)
            {
                for (int j = 0; j < p_image.Height; j++)
                {
                    PixelData currentPixel = unsafeImage.GetPixel(i, j);
                    byte red = currentPixel.Red;
                    byte blue = currentPixel.Blue;
                    byte green = currentPixel.Green;
                    data.Add((byte)(red >> 8 - p_bpp));
                    data.Add((byte)(green >> 8 - p_bpp));
                    data.Add((byte)(blue >> 8 - p_bpp));
                }
            }
           // BitVector32 fa = new BitVector32(2);
           
            BitArray bits = new BitArray(data.ToArray());
            byte[] arr = new byte[data.Count];
            bits.CopyTo(arr, 0);
        }

    }
}