using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Utilities;
using System.Drawing;

namespace Utilities.ImageFormats
{
    class P6Writer : IImageWriter
    {
        public void SaveImage(Bitmap p_image ,string p_imageSavePath)
        {
            FileStream writeStream;
            string SavedFileName = p_imageSavePath;// Path.GetDirectoryName(p_filePath)+"\\"+Path.GetFileNameWithoutExtension(p_filePath) + ".ppm";
            writeStream = new FileStream(SavedFileName, FileMode.Create);
            StreamWriter SW = new StreamWriter(writeStream);

            SW.WriteLine("P6");
            SW.WriteLine("# Created By Keep Moving Forward IP Package !");
            SW.WriteLine(p_image.Width.ToString() + " " + p_image.Height.ToString());
            SW.WriteLine("225");
            SW.Close();
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(SavedFileName, FileMode.Append));
            UnsafeBitmap tempBitmap = new UnsafeBitmap(p_image);
            tempBitmap.LockBitmap();

            for (int i = 0; i < p_image.Height; i++)
            {
                for (int j = 0; j < p_image.Width; j++)
                {
                    PixelData pixelColor = tempBitmap.GetPixel(j, i);
                    binaryWriter.Write((pixelColor.Green));
                    binaryWriter.Write((pixelColor.Blue));
                    binaryWriter.Write((pixelColor.Red));
                }
            }
            tempBitmap.UnlockBitmap();
            binaryWriter.Close();
            writeStream.Close();
        }
    }
}
