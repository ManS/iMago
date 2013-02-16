using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using Utilities;

namespace ImageManipulation
{
   public  class TextHidding
    {
        public static Bitmap HideText(Bitmap image, string Text)
        {
            int charnum = 0;
            int pos = 0;
            Text = ConvertFileToString(Text);
            byte[] letters = new byte[Text.Length];
            for (int i = 0; i < Text.Length; i++)
            {
                letters[i] = (byte)Text[i];
            }

            for (int i = 0; i < image.Height; i++)
            {
                if (charnum < Text.Length)
                {

                    for (int j = 0; j < image.Width; j++)
                    {
                        Color c = image.GetPixel(j, i);
                        string cR;
                        string cc;
                        cc = Convert.ToString(letters[charnum], 2);
                        cc = ConvertTo8Bits(cc);
                        char[] temp;
                        string temp2;
                        Color newC;
                        byte newR;

                        if (charnum < Text.Length)
                        {
                            if (i != 0 || j != 0)
                            {

                                cR = Convert.ToString(c.R, 2);

                                temp = ConvertTo8Bits(cR).ToCharArray();

                                temp[7] = cc[pos];
                                temp2 = new string(temp);
                                newR = Convert.ToByte(temp2, 2);
                                pos++;
                                if (pos == 8)
                                {
                                    pos = 0;
                                    charnum++;
                                    if (charnum == letters.Length)
                                    {

                                        newC = Color.FromArgb(newR, c.G, c.B);
                                        image.SetPixel(j, i, newC);
                                        break;
                                    }
                                    cc = Convert.ToString(letters[charnum], 2);
                                    cc = ConvertTo8Bits(cc);

                                }
                            }
                            else

                                newR = (byte)Text.Length;


                            string cG = Convert.ToString(c.G, 2);
                            temp = ConvertTo8Bits(cG).ToCharArray();
                            temp[7] = cc[pos];
                            temp2 = new string(temp);
                            byte newG = Convert.ToByte(temp2, 2);
                            pos++;
                            if (pos == 8)
                            {
                                pos = 0;
                                charnum++;
                                if (charnum == letters.Length)
                                {

                                    newC = Color.FromArgb(newR, newG, c.B);
                                    image.SetPixel(j, i, newC);
                                    break;
                                }
                                cc = Convert.ToString(letters[charnum], 2);
                                cc = ConvertTo8Bits(cc);

                            }

                            string cB = Convert.ToString(c.B, 2);
                            temp = ConvertTo8Bits(cB).ToCharArray();
                            temp[7] = cc[pos];
                            temp2 = new string(temp);
                            byte newB = Convert.ToByte(temp2, 2);
                            pos++;
                            if (pos == 8)
                            {
                                pos = 0;
                                charnum++;
                                if (charnum == letters.Length)
                                {

                                    newC = Color.FromArgb(newR, newG, newB);
                                    image.SetPixel(j, i, newC);
                                    break;
                                }
                            }
                            newC = Color.FromArgb(newR, newG, newB);
                            image.SetPixel(j, i, newC);
                        }

                        else
                            break;
                    }
                }
                else
                    break;
            }
            image.Tag = Text.Length.ToString();
            return image;
        }

        private static string ConvertTo8Bits(string x)
        {
            if (x.Length == 1)
                x = "0000000" + x;
            else if (x.Length == 2)
                x = "000000" + x;
            else if (x.Length == 3)
                x = "00000" + x;
            else if (x.Length == 4)
                x = "0000" + x;
            else if (x.Length == 5)
                x = "000" + x;
            else if (x.Length == 6)
                x = "00" + x;
            else if (x.Length == 7)
                x = "0" + x;

            return x;

        }

        private static string ConvertTo16Bits(string x)
        {
            for (int i = x.Length; i < 16; i++)
                x = "0" + x;
            return x;
        }

        public static string ShowText(Bitmap myimage)
        {

            int x = myimage.GetPixel(0, 0).R;
            char[,] temp = new char[x, 8];
            int numChar = 0;
            int pos = 0;
            int l = x;


            for (int i = 0; i < myimage.Height; i++)
            {
                if (numChar < l)
                {
                    for (int j = 0; j < myimage.Width; j++)
                    {
                        Color c = myimage.GetPixel(j, i);
                        if (i != 0 || j != 0)
                        {


                            string cR = Convert.ToString(c.R, 2);
                            cR = ConvertTo8Bits(cR);

                            temp[numChar, pos] = cR[7];
                            pos++;
                            if (pos == 8)
                            {
                                pos = 0;
                                numChar++;
                                if (numChar == l)
                                    break;

                            }
                        }


                        string cG = Convert.ToString(c.G, 2);
                        cG = ConvertTo8Bits(cG);
                        temp[numChar, pos] = cG[7];
                        pos++;
                        if (pos == 8)
                        {
                            pos = 0;
                            numChar++;
                            if (numChar == l)
                                break;

                        }


                        string cB = Convert.ToString(c.B, 2);
                        cB = ConvertTo8Bits(cB);
                        temp[numChar, pos] = cB[7];
                        pos++;
                        if (pos == 8)
                        {
                            pos = 0;
                            numChar++;
                            if (numChar == l)
                                break;

                        }
                    }
                }
                else
                    break;

            }
            return ProcessCharArray(temp, l);
        }

        private static string ProcessCharArray(char[,] x, int length)
        {
            string text = "";
            byte[] letters = new byte[length];
            for (int i = 0; i < length; i++)
            {
                string s = "";
                for (int j = 0; j < 8; j++)
                {
                    s += x[i, j];
                }
                letters[i] = Convert.ToByte(s, 2);

            }
            for (int i = 0; i < length; i++)
            {
                text += (char)letters[i];
            }
            return text;
        }

        private static string ConvertFileToString(string path)
        {
            string text = "";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                text += sr.ReadLine();
                text += "\n";
            }

            return text;
        }

        public static Bitmap HideImage(UnsafeBitmap image, UnsafeBitmap ImageTobeHidden)
        {
            image.LockBitmap();
            ImageTobeHidden.LockBitmap();
            int size = (int)((image.Bitmap.Height * image.Bitmap.Width) / 8);
            int Xpos = 0;
            int Ypos = 2;
            PixelData imagePixel;
            int colorComponent = 1;

            if ((ImageTobeHidden.Bitmap.Width * ImageTobeHidden.Bitmap.Height) <= size)
            {
                PixelData FirstPixel = image.GetPixel(0, 0);

                string Width;
                Width = Convert.ToString(ImageTobeHidden.Bitmap.Width, 2);
                Width = ConvertTo16Bits(Width);
                string R1 = "";
                for (int i = 0; i < 8; i++)
                    R1 += Width[i];
                byte newRed = Convert.ToByte(R1, 2);
                string G = "";
                for (int i = 8; i < 16; i++)
                    G += Width[i];
                byte newGreen= Convert.ToByte(G, 2);

                image.SetPixel(0, 0, new PixelData(FirstPixel.Blue, newRed, newGreen));

                string Hight;
                Hight = Convert.ToString(ImageTobeHidden.Bitmap.Height, 2);
                Hight = ConvertTo16Bits(Hight);
                R1 = "";
                for (int i = 0; i < 8; i++)
                    R1 += Hight[i];
               newRed = Convert.ToByte(R1, 2);
                 G = "";
                for (int i = 8; i < 16; i++)
                    G += Hight[i];
                newGreen = Convert.ToByte(G, 2);

                image.SetPixel(0, 1, new PixelData(FirstPixel.Blue, newRed, newGreen));
                for (int i = 0; i < ImageTobeHidden.Bitmap.Width; i++)
                {
                    for (int j = 0; j < ImageTobeHidden.Bitmap.Height; j++)
                    {
                        PixelData CurrentPixel = ImageTobeHidden.GetPixel(i, j);

                        byte R = CurrentPixel.Red;
                        string Red;
                        Red = Convert.ToString(R, 2);
                        Red = ConvertTo8Bits(Red);

                        string Green;
                        Green = Convert.ToString(CurrentPixel.Green, 2);
                        Green = ConvertTo8Bits(Green);

                        string Blue; ;
                        Blue = Convert.ToString(CurrentPixel.Blue, 2);
                        Blue = ConvertTo8Bits(Blue);
                        int pos = 0;

                        char[] temp;
                        string temp2;
                        PixelData newC;
                        byte newR = 0;
                        byte newG = 0;
                        byte newB = 0;
                        imagePixel = image.GetPixel(Xpos, Ypos);
                        while (pos < 8)
                        {


                            if (colorComponent == 1)
                            {



                                string cR = Convert.ToString(imagePixel.Red, 2);
                                temp = ConvertTo8Bits(cR).ToCharArray();
                                temp[7] = Red[pos];
                                temp2 = new string(temp);
                                newR = Convert.ToByte(temp2, 2);
                                pos++;
                                colorComponent++;
                                if (pos == 8)
                                    break;
                            }

                            if (colorComponent == 2)
                            {
                                string cG = Convert.ToString(imagePixel.Green, 2);
                                colorComponent++;
                                temp = ConvertTo8Bits(cG).ToCharArray();
                                temp[7] = Red[pos];
                                temp2 = new string(temp);
                                newG = Convert.ToByte(temp2, 2);
                                pos++;
                                if (pos == 8)
                                {
                                    break;
                                }
                            }

                            if (colorComponent == 3)
                            {
                                colorComponent = 1;
                                string cB = Convert.ToString(imagePixel.Blue, 2);
                                temp = ConvertTo8Bits(cB).ToCharArray();
                                temp[7] = Red[pos];
                                temp2 = new string(temp);
                                newB = Convert.ToByte(temp2, 2);
                                pos++;
                                newC = new PixelData(newB, newR, newG);
                                image.SetPixel(Xpos, Ypos, newC);
                                Ypos++;
                                if (Ypos == image.Bitmap.Height)
                                {
                                    Xpos++;
                                    Ypos = 0;

                                }
                                imagePixel = image.GetPixel(Xpos, Ypos);
                                if (pos == 8)
                                {
                                    break;
                                }
                            }
                        }
                        pos = 0;
                        imagePixel = image.GetPixel(Xpos, Ypos);
                        while (pos < 8)
                        {

                            if (colorComponent == 1)
                            {



                                string cR = Convert.ToString(imagePixel.Red, 2);
                                temp = ConvertTo8Bits(cR).ToCharArray();
                                temp[7] = Green[pos];
                                temp2 = new string(temp);
                                newR = Convert.ToByte(temp2, 2);
                                pos++;
                                colorComponent++;
                                if (pos == 8)
                                    break;
                            }

                            if (colorComponent == 2)
                            {
                                string cG = Convert.ToString(imagePixel.Green, 2);
                                temp = ConvertTo8Bits(cG).ToCharArray();
                                temp[7] = Green[pos];
                                temp2 = new string(temp);
                                newG = Convert.ToByte(temp2, 2);
                                pos++;
                                colorComponent++;
                                if (pos == 8)
                                {
                                    break;
                                }
                            }

                            if (colorComponent == 3)
                            {
                                colorComponent = 1;
                                string cB = Convert.ToString(imagePixel.Blue, 2);
                                temp = ConvertTo8Bits(cB).ToCharArray();
                                temp[7] = Green[pos];
                                temp2 = new string(temp);
                                newB = Convert.ToByte(temp2, 2);
                                pos++;
                                newC = new PixelData(newB, newR, newG);
                                image.SetPixel(Xpos, Ypos, newC);
                                Ypos++;
                                if (Ypos == image.Bitmap.Height)
                                {
                                    Xpos++;
                                    Ypos = 0;
                                }
                                imagePixel = image.GetPixel(Xpos, Ypos);
                                if (pos == 8)
                                {
                                    break;
                                }
                            }
                        }


                        pos = 0;
                        imagePixel = image.GetPixel(Xpos, Ypos);
                        while (pos < 8)
                        {
                            if (colorComponent == 1)
                            {
                                colorComponent++;
                                string cR = Convert.ToString(imagePixel.Red, 2);
                                temp = ConvertTo8Bits(cR).ToCharArray();
                                temp[7] = Blue[pos];
                                temp2 = new string(temp);
                                newR = Convert.ToByte(temp2, 2);
                                pos++;
                                if (pos == 8)
                                    break;
                            }

                            if (colorComponent == 2)
                            {
                                colorComponent++;
                                string cG = Convert.ToString(imagePixel.Green, 2);
                                temp = ConvertTo8Bits(cG).ToCharArray();
                                temp[7] = Blue[pos];
                                temp2 = new string(temp);
                                newG = Convert.ToByte(temp2, 2);
                                pos++;
                                if (pos == 8)
                                {
                                    break;
                                }
                            }

                            if (colorComponent == 3)
                            {
                                colorComponent = 1;
                                string cB = Convert.ToString(imagePixel.Blue, 2);
                                temp = ConvertTo8Bits(cB).ToCharArray();
                                temp[7] = Blue[pos];
                                temp2 = new string(temp);
                                newB = Convert.ToByte(temp2, 2);
                                pos++;
                                newC = new PixelData(newB, newR, newG);
                                image.SetPixel(Xpos, Ypos, newC);
                                Ypos++;
                                if (Ypos == image.Bitmap.Height)
                                {
                                    Xpos++;
                                    Ypos = 0;
                                }
                                imagePixel = image.GetPixel(Xpos, Ypos);
                                if (pos == 8)
                                {
                                    break;
                                }
                            }
                        }

                    }
                }

                image.UnlockBitmap();
                ImageTobeHidden.UnlockBitmap();
                return image.Bitmap;
            }
            else
                return null;

        }

        public static Bitmap RetrieveImage(UnsafeBitmap image)
        {
            image.LockBitmap();
            PixelData FirstPixel = image.GetPixel(0, 0);
            string W =ConvertTo8Bits( Convert.ToString(FirstPixel.Red, 2))+ConvertTo8Bits( Convert.ToString(FirstPixel.Green,2));
            PixelData SecondPixel = image.GetPixel(0, 1);
            string H = ConvertTo8Bits(Convert.ToString(SecondPixel.Red, 2) )+ ConvertTo8Bits(Convert.ToString(SecondPixel.Green, 2));
            UnsafeBitmap HiddenImage = new UnsafeBitmap(Convert.ToInt32(W, 2), Convert.ToInt32(H, 2));
            HiddenImage.LockBitmap();
            int Xpos = 0;
            int Ypos = 2;
            int colorComponent = 1;
            for (int i = 0; i < HiddenImage.Bitmap.Width; i++)
            {
                for (int j = 0; j < HiddenImage.Bitmap.Height; j++)
                {
                    PixelData imagePixel;

                    string Red = "";
                    string Green = "";
                    string Blue = "";

                    int pos = 0;

                    char[] temp;

                    byte newR = 0;
                    byte newG = 0;
                    byte newB = 0;
                    imagePixel = image.GetPixel(Xpos, Ypos);
                    while (pos < 8)
                    {


                        if (colorComponent == 1)
                        {

                            string cR = Convert.ToString(imagePixel.Red, 2);
                            colorComponent++;
                            temp = ConvertTo8Bits(cR).ToCharArray();
                            Red += temp[7];

                            pos++;
                            if (pos == 8)
                            {
                                newR = Convert.ToByte(Red, 2);
                                Red = "";
                                break;
                            }
                        }

                        if (colorComponent == 2)
                        {
                            colorComponent++;
                            string cG = Convert.ToString(imagePixel.Green, 2);
                            temp = ConvertTo8Bits(cG).ToCharArray();
                            Red += temp[7];

                            pos++;
                            if (pos == 8)
                            {
                                newR = Convert.ToByte(Red, 2);
                                Red = "";
                                break;
                            }
                        }


                        if (colorComponent == 3)
                        {
                            colorComponent = 1;
                            string cB = Convert.ToString(imagePixel.Blue, 2);
                            temp = ConvertTo8Bits(cB).ToCharArray();
                            Red += temp[7];

                            pos++;

                            Ypos++;
                            if (Ypos == image.Bitmap.Height)
                            {
                                Xpos++;
                                Ypos = 0;
                            }
                            imagePixel = image.GetPixel(Xpos, Ypos);
                            if (pos == 8)
                            {
                                newR = Convert.ToByte(Red, 2);
                                Red = "";
                                break;
                            }
                        }
                    }
                    pos = 0;
                    imagePixel = image.GetPixel(Xpos, Ypos);
                    while (pos < 8)
                    {
                        imagePixel = image.GetPixel(Xpos, Ypos);

                        if (colorComponent == 1)
                        {

                            string cR = Convert.ToString(imagePixel.Red, 2);
                            temp = ConvertTo8Bits(cR).ToCharArray();
                            Green += temp[7];
                            colorComponent++;
                            pos++;
                            if (pos == 8)
                            {
                                newG = Convert.ToByte(Green, 2);
                                Green = "";
                                break;
                            }
                        }

                        if (colorComponent == 2)
                        {
                            string cG = Convert.ToString(imagePixel.Green, 2);
                            temp = ConvertTo8Bits(cG).ToCharArray();
                            Green += temp[7];
                            colorComponent++;
                            pos++;
                            if (pos == 8)
                            {
                                newG = Convert.ToByte(Green, 2);
                                Green = "";
                                break;
                            }
                        }

                        if (colorComponent == 3)
                        {
                            colorComponent = 1;
                            string cB = Convert.ToString(imagePixel.Blue, 2);
                            temp = ConvertTo8Bits(cB).ToCharArray();
                            Green += temp[7];

                            pos++;

                            Ypos++;
                            if (Ypos == image.Bitmap.Height)
                            {
                                Xpos++;
                                Ypos = 0;
                            }
                            imagePixel = image.GetPixel(Xpos, Ypos);

                            if (pos == 8)
                            {
                                newG = Convert.ToByte(Green, 2);
                                Green = "";
                                break;
                            }
                        }
                    }

                    pos = 0;
                    imagePixel = image.GetPixel(Xpos, Ypos);

                    while (pos < 8)
                    {

                        if (colorComponent == 1)
                        {

                            string cR = Convert.ToString(imagePixel.Red, 2);
                            temp = ConvertTo8Bits(cR).ToCharArray();
                            Blue += temp[7];
                            colorComponent++;
                            pos++;
                            if (pos == 8)
                            {
                                newB = Convert.ToByte(Blue, 2);
                                Blue = "";
                                break;
                            }
                        }

                        if (colorComponent == 2)
                        {
                            string cG = Convert.ToString(imagePixel.Green, 2);
                            temp = ConvertTo8Bits(cG).ToCharArray();
                            Blue += temp[7];
                            colorComponent++;
                            pos++;
                            if (pos == 8)
                            {
                                newB = Convert.ToByte(Blue, 2);
                                Blue = "";
                                break;
                            }
                        }

                        if (colorComponent == 3)
                        {
                            colorComponent = 1;
                            string cB = Convert.ToString(imagePixel.Blue, 2);
                            temp = ConvertTo8Bits(cB).ToCharArray();
                            Blue += temp[7];

                            pos++;

                            Ypos++;
                            if (Ypos == image.Bitmap.Height)
                            {
                                Xpos++;
                                Ypos = 0;
                            }
                            imagePixel = image.GetPixel(Xpos, Ypos);
                            if (pos == 8)
                            {
                                newB = Convert.ToByte(Blue, 2);
                                Blue = "";
                                break;
                            }
                        }
                    }
                    HiddenImage.SetPixel(i, j, new PixelData(newB, newR, newG));
                }
            }
            image.UnlockBitmap();
            HiddenImage.UnlockBitmap();
            return HiddenImage.Bitmap;
        }
    }
}