using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Utilities;

namespace Utilities.ImageFormats
{
    public class P3Writer : IImageWriter
    {
        public void SaveImage(Bitmap p_image, string p_imageSavePath)
        {
            string SavedFileName = p_imageSavePath;//Path.GetDirectoryName(p_filePath) + "\\" + Path.GetFileNameWithoutExtension(p_filePath) + ".ppm";
            FileStream fs = new FileStream(SavedFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            UnsafeBitmap tempUSbitmap = new UnsafeBitmap(p_image);
            tempUSbitmap.LockBitmap();
            string line = "";
            sw.WriteLine("P3");
            sw.WriteLine("# Created by Keep moving Forward IP Package !");
            sw.WriteLine(p_image.Width.ToString() + " " + p_image.Height.ToString());
            sw.WriteLine("255");
            int count = 0;
            for (int i = 0; i < p_image.Height; i++)
            {
                for (int j = 0; j < p_image.Width; j++)
                {
                    count++;
                    PixelData pixelColor = tempUSbitmap.GetPixel(j, i);
                    line += pixelColor.Red.ToString() + " " + pixelColor.Green.ToString() + " " + pixelColor.Blue.ToString() + " ";
                    if (count >= 6)
                    {
                        count = 0;
                        sw.WriteLine(line);
                        line = "";
                    }
                }
            }
            sw.Close();
            fs.Close();
            tempUSbitmap.UnlockBitmap();
        }
    }
}
