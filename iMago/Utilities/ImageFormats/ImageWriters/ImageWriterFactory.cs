using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Utilities.ImageFormats
{
    public enum ImageFormat
    {
        P1,P2,P3,P4,P5,P6,OtherFormats
    }
    
    public class ImageWriterFactory
    {
       public static IImageWriter GetImageWriter(ImageFormat p_imageFormat)
       {
           switch (p_imageFormat)
           {
               //case ImageFormat.P1:
                 //  return new
                  // break;
               //case ImageFormat.P2:
                 //  break;
               case ImageFormat.P3:
                   return new P3Writer();
                  // break;
               //case ImageFormat.P4:
                 //  break;
               //case ImageFormat.P5:
                 //  break;
               case ImageFormat.P6:
                   return new P6Writer();
                 //  break;
               //case ImageFormat.OtherFormats:
                   //break;
               default:
                   throw new NotImplementedException();
            }
 
       }
    }
}