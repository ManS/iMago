using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;
using System.Collections;

namespace Filters.NoiseRemovers
{
   public abstract class IOrderFilter : INoiseRemover
   {
       public int FilterSize { get;  set; }
       protected int maxNumOfDigits;
       protected int[,] MixedPixels { get; set; }
       protected Dictionary<int, PixelData> reverseMixed { get; set; }
       public int Width { get; set; }
       public int Height { get; set; }


       public IOrderFilter(int filterSize)
       {
            this.FilterSize = filterSize;
            this.reverseMixed = new Dictionary<int, PixelData>();
       }

       public void RemoveNoise(Bitmap noiseImage, ref Bitmap destinationImage)
        {
            destinationImage = RemoveNoise(noiseImage);
        }
       
       public Bitmap RemoveNoise(Bitmap sourceImage)
       {
           this.Width = sourceImage.Width;
           this.Height = sourceImage.Height;
            
           this.FillMixedArrays(sourceImage);
           return this.ApplyFilter();
       }

       abstract protected Bitmap ApplyFilter();

       protected void FillMixedArrays(Bitmap SourceImage)
       {
           UnsafeBitmap unsafeImage = new UnsafeBitmap(SourceImage);
           MixedPixels = new int[SourceImage.Width, SourceImage.Height];

           reverseMixed = new Dictionary<int, PixelData>();
           unsafeImage.LockBitmap();
           for (int i = 0; i < SourceImage.Width; i++)
           {
               for (int j = 0; j < SourceImage.Height; j++)
               {
                   MixedPixels[i, j] = GetBitMixing(unsafeImage.GetPixel(i, j));
                   if (!reverseMixed.ContainsKey(MixedPixels[i, j]))
                       reverseMixed.Add(MixedPixels[i, j], unsafeImage.GetPixel(i, j));
               }
           }
           unsafeImage.UnlockBitmap();
       }
       
       protected static int GetBitMixing(PixelData Pixel)
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

               Bits.Add(BlueBit);
               Bits.Add(GreenBit);
               Bits.Add(RedBit);

           }
           value += ConstractInt(Bits);
           return value;
       }
       
       protected static int ConstractInt(List<byte> Bits)
       {
           int Value = 0;
           for (int i = 0; i < Bits.Count; i++)
           {
               Value += (int)(Bits[i] * Math.Pow(2, i));
           }
           return Value;
       }
       
       protected static PixelData ReverseBitMixing(int mixedValue)
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
       
       protected static byte[] ToBinary(Int64 Decimal, int length)
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

       protected int[] GetWindowPixels(int x, int y)
       {
           int iterator = 0;
           int BeginX, BeginY, EndX, EndY;

           BeginX = (x > this.FilterSize / 2) ? (x - this.FilterSize / 2) : 0;
           BeginY = (y > this.FilterSize / 2) ? (y - this.FilterSize / 2) : 0;
           EndX = ((this.Width - x) > (this.FilterSize / 2)) ? (x + this.FilterSize / 2) : this.Width - 1;
           EndY = ((this.Height - y) > (this.FilterSize / 2)) ? (y + this.FilterSize / 2) : this.Height - 1;


           int[] WindowPixels = new int[(EndX - BeginX + 1) * (EndY - BeginY + 1)];

           for (int i = BeginX; i <= EndX; i++)
           {
               for (int j = BeginY; j <= EndY; j++)
               {
                   WindowPixels[iterator++] = this.MixedPixels[ i,j];
               }
           }
           return WindowPixels;
       }

       public int[] GetWindowPixelsMedian(int x, int y, int size)
       {
           
           int iterator = 0;
           int a = (size ) / 2;
           int b = (size ) / 2;
           int Ix = x - a;
           int Jy = y - b;

           int BeginX, BeginY, EndX, EndY;

           BeginX = (x > size / 2) ? (x - size / 2) : 0;
           BeginY = (y > size / 2) ? (y - size / 2) : 0;
           EndX = ((this.Width - x) > (size / 2)) ? (x + size / 2) : this.Width - 1;
           EndY = ((this.Height - y) > (size / 2)) ? (y + size / 2) : this.Height - 1;

           int[] WindowPixels = new int[(EndX - BeginX + 1) * (EndY - BeginY + 1)];
           for (int i = BeginX; i <= EndX; i++)
           {
               for (int j = BeginY; j <= EndY; j++)
               {
                   WindowPixels[iterator++] = this.MixedPixels[i, j];
               }
           }
           return WindowPixels;
       }
   }
}
