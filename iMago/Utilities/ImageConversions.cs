using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace Utilities
{
   public  class ImageConversions
    {
       public static double[,] ConvertFromByteArraytoDouble(Byte[,] byteArray)
       {
           int width = byteArray.GetLength(0);
           int height = byteArray.GetLength(1);
           double[,] doubleArray = new double[width, height];
           for (int i = 0; i < width; i++)
           {
               for (int j = 0; j < height; j++)
               {
                   doubleArray[i,j]=Convert.ToDouble(byteArray[i,j]);
               }
           }
           return doubleArray;
       }
   public     static double[,] BytesToEpicDoubles(byte[,] bytes)
       {
       int rows=bytes.GetLength(0);
       int columns=bytes.GetLength(1);
    
       double [,] Bytes=new double [rows,columns];
           for (int x = 0; x <rows ; x++)
           {
               for (int j = 0; j <columns ; j++)
               {
                  Bytes[x,j]= Convert.ToDouble(bytes[x, j]);
               }
           }
           return Bytes;
       }

       public static Bitmap ConvertToGrayScale(Bitmap image)
       {
           UnsafeBitmap unsafeImage = new UnsafeBitmap(image);
           unsafeImage.LockBitmap();
           int size = image.Height * image.Width;

           for (int currentRow = 0; currentRow < image.Height; currentRow++)
           {
               for (int currentColumn = 0; currentColumn < image.Width; currentColumn++)
               {
                   PixelData pixelData = unsafeImage.GetPixel(currentColumn, currentRow);
                   int grey = (int)(((int)pixelData.Red + (int)pixelData.Green + (int)pixelData.Blue) / 3f);
                   unsafeImage.SetPixel(currentColumn, currentRow, new PixelData((byte)grey, (byte)grey, (byte)grey));
               }
           }
           unsafeImage.UnlockBitmap();
           return unsafeImage.Bitmap;
       }

       public static int[] GetWindowPixels(ref UnsafeBitmap Image, int x, int y, int size)
       {
           int[] Result = new int[size * size];
           int iterator = 0;

           int a = (size - 1) / 2;
           int b = (size - 1) / 2;

           for (int i = -a; i <= a; i++)
           {
               for (int j = -b; j <= b; j++)
               {
                   PixelData pixel = Image.GetPixel(x + a + i, y + b + j);
                   Result[iterator++] = GetBitMixing(pixel);
               }
           }

           return Result;
       }

       public static int[] GetWindowPixelsMedian(ref UnsafeBitmap Image, int x, int y, int size)
       {
           int[] Result = new int[size * size];
           int iterator = 0;
           int a = (size - 1) / 2;
           int b = (size - 1) / 2;
           int Ix = x - a;
           int Jy = y - b;
           for (int i = x - a; i < Ix + size; i++)
           {
               for (int j = y - b; j < Jy + size; j++)
               {
                   PixelData pixel = Image.GetPixel(i, j);
                   Result[iterator++] = GetBitMixing(pixel);
               }
           }
           return Result;
       }

       public static int GetBitMixing(PixelData Pixel)
       {
           byte[] Red = { Pixel.Red };
           byte[] Blue = { Pixel.Blue };
           byte[] Green = { Pixel.Green };

           BitArray RedBitArray = new BitArray(Red);
           BitArray GreenBitArray = new BitArray(Green);
           BitArray BlueBitArray = new BitArray(Blue);

           int value = 0;
           List<byte> Bits = new List<byte>();
           for (int i = 0; i < 8; i++)
           {
               byte RedBit = (byte)(RedBitArray.Get(i) ? 1 : 0);
               byte GreenBit = (byte)(GreenBitArray.Get(i) ? 1 : 0);
               byte BlueBit = (byte)(BlueBitArray.Get(i) ? 1 : 0);

               //byte[] Bites = { BlueBit, GreenBit, RedBit };
               Bits.Add(BlueBit);
               Bits.Add(GreenBit);
               Bits.Add(RedBit);

           }
           value += ConstractInt(Bits);
           return value;
       }

       private static int ConstractInt(List<byte> Bits)
       {
           int Value = 0;
           for (int i = 0; i < Bits.Count; i++)
           {
               Value += (int)(Bits[i] * Math.Pow(2, i));
           }
           return Value;
       }

       public static byte[] ToBinary(Int64 Decimal, int length)
       {
           // Declare a few variables we're going to need
           Int64 BinaryHolder;
           char[] BinaryArray;
           string BinaryResult = "";

           while (Decimal > 0)
           {
               BinaryHolder = Decimal % 2;
               BinaryResult += BinaryHolder;
               Decimal = Decimal / 2;
           }

           // The algorithm gives us the binary number in reverse order (mirrored)
           // We store it in an array so that we can reverse it back to normal
           BinaryArray = BinaryResult.ToCharArray();
           //Array.Reverse(BinaryArray);
           byte[] Binary = new byte[length];
           int i;
           for (i = 0; i < BinaryArray.Length; i++)
           {
               Binary[i] = (byte)(BinaryArray[i] == '1' ? 1 : 0);
           }
           for (; i < length; i++)
           {
               Binary[i] = 0;
           }
           return Binary;
       }

       public static PixelData ReverseBitMixing(int mixedValue)
       {
           byte[] bitArray = ToBinary(mixedValue, 24);


           byte Red = 0;
           byte Green = 0;
           byte Blue = 0;
           int j = 0;
           for (int i = 0; i < 8; i++)
           {
               Blue += (byte)(bitArray[j++] * Math.Pow(2, i));
               Green += (byte)(bitArray[j++] * Math.Pow(2, i));
               Red += (byte)(bitArray[j++] * Math.Pow(2, i));
           }

           return new PixelData(Blue, Red, Green);
       }
   }
}