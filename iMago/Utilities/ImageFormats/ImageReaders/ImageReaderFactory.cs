using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Utilities.ImageFormats
{
   public class ImageReaderFactory
    {
        public static IImageReader GetImageReader(string p_imagePath)
        {
            string extention = Path.GetExtension(p_imagePath);

            switch (extention.ToLower())
            {
                case ".ppm":
                    return GetPPMImageReader(p_imagePath);
                default:
                    return new OtherFormatsReader();
            }
        }

        private static IImageReader GetPPMImageReader(string p_imagePath)
        {
            FileStream fileHandler = new FileStream(p_imagePath, FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(fileHandler);
            string MagicNumber = fileReader.ReadLine();

            fileReader.Close();
            fileHandler.Close();

            switch (MagicNumber.ToLower())
            {
                case "p3":
                    return new P3Reader();
                case "p6":
                    return new P6Reader();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
