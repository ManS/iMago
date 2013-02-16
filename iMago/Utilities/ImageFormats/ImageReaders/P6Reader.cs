using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Utilities;

namespace Utilities.ImageFormats
{
    public class P6Reader : IImageReader
    {
        public Bitmap ReadImage(string p_imagePath)
        {
            FileStream fileStream = new FileStream(p_imagePath, FileMode.Open);
            int headerItemNumber = 0;
            int width = 0, height = 0;
            BinaryReader binaryReader = new BinaryReader(fileStream);

            while (headerItemNumber < 4)
            {
                char nextCharacter = (char)binaryReader.PeekChar();
                if (char.IsWhiteSpace(nextCharacter))
                    binaryReader.ReadChar();
                else if (nextCharacter == '#')
                    while (binaryReader.ReadChar() != '\n') ;
                else
                {
                    if (headerItemNumber == 0)//Read Magic Number :D
                    {
                        binaryReader.ReadChars(2);
                        headerItemNumber++;
                    }
                    else if (headerItemNumber == 1)
                    {
                        width = ReadValue(binaryReader);
                        headerItemNumber++;
                    }
                    else if (headerItemNumber == 2)
                    {
                        height = ReadValue(binaryReader);
                        headerItemNumber++;
                    }
                    else if (headerItemNumber == 3)
                    {
                        ReadValue(binaryReader);
                        headerItemNumber++;
                    }
                    else
                    {
                        throw new Exception("The file is corrupted ");
                    }
                }
            }
            //then start reading the image data 
            byte[] ImageData = new byte[width * height * 3];

            int bytesLeft = (int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position);
            ImageData = binaryReader.ReadBytes(bytesLeft);

            binaryReader.Close();
            fileStream.Close();
            return this.ReturnBitmapImage(ImageData, width, height);
        }
        private Bitmap ReturnBitmapImage(byte[] ImageData, int width, int height)
        {
            UnsafeBitmap newBitMap = new UnsafeBitmap(width, height);
            newBitMap.LockBitmap();

            byte red, green, blue;
            int index = 0;
            PixelData pixelData;
            for (int y = 0; y <height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    blue = (byte)ImageData[index++];
                    red = (byte)ImageData[index++];
                    green = (byte)ImageData[index++];
                    pixelData = new PixelData(blue, red, green);
                    newBitMap.SetPixel(x, y, pixelData);
                }
            }
            newBitMap.UnlockBitmap();
            return newBitMap.Bitmap;
        }
        private int ReadValue(BinaryReader binaryReader)
        {
            string value = string.Empty;
            while (!char.IsWhiteSpace((char)binaryReader.PeekChar()))
                value += (char)binaryReader.ReadChar();

            return int.Parse(value);

        }
    }
}