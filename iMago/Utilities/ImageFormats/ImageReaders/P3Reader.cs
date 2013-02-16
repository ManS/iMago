using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;
using System.Text.RegularExpressions;
using System.IO;

namespace Utilities.ImageFormats
{
    public class P3Reader : IImageReader
    {
        public Bitmap ReadImage(string p_imagePath)
        {
            int width;
            int height;

            FileStream fileHander = new FileStream(p_imagePath, FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(fileHander);

            string tempString;
            //Read Comments
            tempString = fileReader.ReadLine();// Read magic number
            tempString = fileReader.ReadLine();
            while (Regex.Match(tempString, "^#.").Success)
            {
                tempString = fileReader.ReadLine();
            }
            
            //Read Width and height
            width = int.Parse(tempString.Split(' ')[0]);
            height = int.Parse(tempString.Split(' ')[1]);

            //Read the next usefulness line
            tempString = fileReader.ReadLine();

            tempString = fileReader.ReadToEnd();

            //Split into values
            UnsafeBitmap unsafeImage = new UnsafeBitmap(width, height);
            unsafeImage.LockBitmap();
            char[] param = { ' ', '\n', '\r' };
            string[] rawStringData = tempString.Split(param, StringSplitOptions.RemoveEmptyEntries);

            int currentPosition = 0;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    byte R = byte.Parse(rawStringData[currentPosition++]);
                    byte G = byte.Parse(rawStringData[currentPosition++]);
                    byte B = byte.Parse(rawStringData[currentPosition++]);
                    unsafeImage.SetPixel(i, j, new PixelData(B, R, G));
                }
            }
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;
            //UnsafeBitmap unsafeImage = new UnsafeBitmap
            throw new NotImplementedException();
        }
    }
}
