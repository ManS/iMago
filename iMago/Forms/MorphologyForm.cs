using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Filters.Morphology;
using Utilities;
namespace iMago
{
    public partial class MorphologyForm : DevExpress.XtraEditors.XtraForm
    {
        public enum MorphologyType
        { Erosion, Dialation };
        MorphologyType type;
        public Bitmap image;
        byte[,] SE;
        short[,] se;
        int XOrigin;
        int YOrigin;
        public bool manipulated = false;

        public MorphologyForm(MorphologyType type, Bitmap image)
        {
            InitializeComponent();
            this.type = type;
            this.image = image;
            OriginalpictureBox.Image = image;
        }
        
        private void MakeMaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                int width = int.Parse(Width_txt.Text);
                int height = int.Parse(Height_txt.Text);
                XOrigin = int.Parse(OriginX_txt.Text);
                YOrigin = int.Parse(OriginY_txt.Text);
                se = new short[height,width];
                SE = new byte[height,width];
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                        se[i, j] = 1;
                grid.LoadData(se);

            }
            catch
            {
                MessageBox.Show("Wrong SE size or origin !");
                return;
            }
        }
        
        private void Apply_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < se.GetLength(0); i++)
            {
                for (int j = 0; j < se.GetLength(1); j++)
                {
                    SE[i, j] = (byte)se[i, j];
                }
            }
         ModifiedpictureBox.Image=   DoMorphologicalOperation(image, SE, new Point(XOrigin, YOrigin), this.type);

         //if (this.type == MorphologyType.Erosion)
         //{
         //    Erosion ER = new Erosion(SE, new Point(XOrigin, YOrigin));
         //    ModifiedpictureBox.Image = ER.ApplyMorphology(image);
         //}
         //else
         //{
         //    Dilatation DL = new Dilatation(SE, new Point(XOrigin, YOrigin));
         //    ModifiedpictureBox.Image = DL.ApplyMorphology(image);
         //}
            
        }



        # region Testing Erosion

        public static byte[,] ReflectSE(byte[,] SE, ref Point SECenter)
        {
            int rows = SE.GetLength(0);
            int columns = SE.GetLength(1);
            byte[,] newReflected = new byte[rows, columns];
            int tempColumn = columns - 1, tempRow = rows - 1;
            bool entered = false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j == SECenter.X && i == SECenter.Y && entered==false)
                    {
                        SECenter.X = tempColumn;
                        SECenter.Y = tempRow;
                        entered = true;
                    }
                    newReflected[tempRow, tempColumn] = SE[i, j];
                    tempColumn--;
                }
                tempColumn = columns - 1;
                tempRow--;
            }
            return newReflected;
        }

        public static Bitmap DoMorphologicalOperation(Bitmap image, byte[,] SE, Point SECenter, MorphologyType type)
        {    byte[,] reflectedSE;
        if (type == MorphologyType.Dialation)
            reflectedSE = ReflectSE(SE, ref SECenter);
        else
            reflectedSE = SE;
            Bitmap paddedImage = PaddingByZerosAndBinarization(image, SECenter, SE.GetLength(1), SE.GetLength(0));

            if (type == MorphologyType.Erosion)
                return Erosion(paddedImage, reflectedSE, SECenter, new Size(image.Width, image.Height));
            else if (type == MorphologyType.Dialation)
                return Dialation(paddedImage, reflectedSE, SECenter, new Size(image.Width, image.Height));
            return paddedImage;
        }
        public static Bitmap PaddingByZerosAndBinarization(Bitmap image, Point SECenter, int SEWidth, int SEHeight)
        {
            int noOfTopRowsToBedAdded = SECenter.Y;
            int noOfLeftColumnsToBeAdded = SECenter.X;
            int noOfBottomRowsToBeAdded = SEHeight - (SECenter.Y + 1);
            int noOfRightColumnsToBeAdded = SEWidth - (SECenter.X + 1);

            UnsafeBitmap oldImage = new UnsafeBitmap(image);
            oldImage.LockBitmap();
            UnsafeBitmap unsafeImage = new UnsafeBitmap(image.Width + noOfLeftColumnsToBeAdded + noOfRightColumnsToBeAdded, image.Height + noOfTopRowsToBedAdded + noOfBottomRowsToBeAdded);
            unsafeImage.LockBitmap();
            for (int i = noOfLeftColumnsToBeAdded; i < image.Width + noOfLeftColumnsToBeAdded; i++)
            {
                for (int j = noOfTopRowsToBedAdded; j < image.Height + noOfTopRowsToBedAdded; j++)
                {
                    PixelData pixelData = oldImage.GetPixel(i - noOfLeftColumnsToBeAdded, j - noOfTopRowsToBedAdded);
                    int gray = (int)((pixelData.Red + pixelData.Green + pixelData.Blue) / 3f);
                    if (gray >= 128)
                    {
                        unsafeImage.SetPixel(i, j, new PixelData((byte)255, (byte)255, (byte)255));
                    }

                    else { unsafeImage.SetPixel(i, j, new PixelData((byte)0, (byte)0, (byte)0)); }
                }
            }
            oldImage.UnlockBitmap();
            unsafeImage.UnlockBitmap();
            return unsafeImage.Bitmap;

        }
        public static Bitmap Dialation(Bitmap BinaryPaddedImage, byte[,] SE, Point SECenter, Size imageSize)
        {
            UnsafeBitmap unSafeImage = new UnsafeBitmap(BinaryPaddedImage);
            UnsafeBitmap newUnsafeImage = new UnsafeBitmap(imageSize.Width, imageSize.Height);
            unSafeImage.LockBitmap();
            newUnsafeImage.LockBitmap();
            int columns = SE.GetLength(1);
            int rows = SE.GetLength(0);
            int SECenterX = SECenter.X;
            int SECenterY = SECenter.Y;
            int noOfPointsAfterTheCenterX = columns - (SECenterX + 1);
            int noOfPointsAfterTheCentery = rows - (SECenterY + 1);
            bool entered = false;
            for (int i = SECenterX; i < BinaryPaddedImage.Width - noOfPointsAfterTheCenterX; i++)
            {
                for (int j = SECenterY; j < BinaryPaddedImage.Height - noOfPointsAfterTheCentery; j++)
                {
                    for (int k = -1 * SECenterX; k <= noOfPointsAfterTheCenterX; k++)
                    {
                        for (int h = -1 * SECenterY; h <= noOfPointsAfterTheCentery; h++)
                        {
                            PixelData pixelData = unSafeImage.GetPixel(i + k, j + h);
                            if ((byte)pixelData.Red != 0 && SE[h + SECenterY, k + SECenterX] == 1)
                            {
                                entered = true; break;
                            }

                        }
                        if (entered)
                        { newUnsafeImage.SetPixel(i - SECenterX, j - SECenterY, new PixelData((byte)255, (byte)255, (byte)255)); break; }


                    }
                    if (!entered)
                        newUnsafeImage.SetPixel(i - SECenterX, j - SECenterY, new PixelData((byte)0, (byte)0, (byte)0));
                    entered = false;

                }
            }


            unSafeImage.UnlockBitmap();
            newUnsafeImage.UnlockBitmap();
            return newUnsafeImage.Bitmap;

        }
        public static Bitmap Erosion(Bitmap BinaryPaddedImage, byte[,] SE, Point SECenter, Size imageSize)
        {
            UnsafeBitmap unSafeImage = new UnsafeBitmap(BinaryPaddedImage);
            UnsafeBitmap newUnsafeImage = new UnsafeBitmap(imageSize.Width, imageSize.Height);
            unSafeImage.LockBitmap();
            newUnsafeImage.LockBitmap();
            int columns = SE.GetLength(1);
            int rows = SE.GetLength(0);
            int SECenterX = SECenter.X;
            int SECenterY = SECenter.Y;
            int noOfPointsAfterTheCenterX = columns - (SECenterX + 1);
            int noOfPointsAfterTheCentery = rows - (SECenterY + 1);
            bool entered = true;
            for (int i = SECenterX; i < BinaryPaddedImage.Width - noOfPointsAfterTheCenterX; i++)
            {
                for (int j = SECenterY; j < BinaryPaddedImage.Height - noOfPointsAfterTheCentery; j++)
                {
                    for (int k = -1 * SECenterX; k <= noOfPointsAfterTheCenterX; k++)
                    {
                        for (int h = -1 * SECenterY; h <= noOfPointsAfterTheCentery; h++)
                        {
                            PixelData pixelData = unSafeImage.GetPixel(i + k, j + h);
                            if ((byte)pixelData.Red == 0 && SE[h + SECenterY, k + SECenterX] == 1)
                            {
                                entered = false; break;
                            }

                        }
                        if (!entered)
                        { break; }


                    }
                    if (entered)
                        newUnsafeImage.SetPixel(i - SECenterX, j - SECenterY, new PixelData((byte)255, (byte)255, (byte)255));
                    else newUnsafeImage.SetPixel(i - SECenterX, j - SECenterY, new PixelData((byte)0, (byte)0, (byte)0));
                    entered = true;

                }
            }


            unSafeImage.UnlockBitmap();
            newUnsafeImage.UnlockBitmap();
            return newUnsafeImage.Bitmap;

        }

        # endregion

        
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            manipulated = true;
            image = (Bitmap)ModifiedpictureBox.Image;
            this.Close();
        }
        
        private void Circle_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int raduis = int.Parse(R_txt.Text);
                XOrigin = raduis;
                YOrigin = raduis;
            se = new short[(raduis * 2)+1,( raduis * 2)+1];
            SE = new byte[(raduis * 2)+1, (raduis * 2)+1];

            for (int i = 0; i < (raduis * 2)+1; i++)
            {
                for (int j = 0; j <( raduis * 2)+1; j++)
                {
                    float distance = (float)Math.Sqrt((Math.Pow(Math.Abs(i - (raduis)), 2) + Math.Pow(Math.Abs(j - (raduis)), 2)));//garb
                    if (distance > raduis)
                        se[i, j] = 0;
                    else
                        se[i, j] = 1;
                }
            }
            grid.LoadData(se);
            }
            catch
            {
                MessageBox.Show("Wrong raduis !");
                return;
            }
        }

        private void Triangle_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = int.Parse(H_txt.Text);
                XOrigin = int.Parse(OriginX_txt.Text);
                YOrigin = int.Parse(OriginY_txt.Text);
                int width = (2 * height) - 1;
                se = new short[height, width];
                SE = new byte[height, width];
                int noOfSpaces = height - 1;
                int noOfStars = 1;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < noOfSpaces; j++)
                        se[i, j] = 0;
                    for (int j = noOfSpaces; j < noOfSpaces + noOfStars; j++)
                        se[i, j] = 1;
                    for (int j = noOfSpaces + noOfStars; j < width; j++)
                        se[i, j] = 0;
                    noOfSpaces--;
                    noOfStars += 2;
                }
                grid.LoadData(se);
            }
             catch
            {
                MessageBox.Show("Wrong height or origin !");
                return;
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "txt";
            ofd.Filter = "Text files (*.txt)|*.txt";
            ofd.Title = "Load structuring element from file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    short[,] array = (short[,])Serialize2DimArray.Load(ofd.FileName, typeof(short));
                    se = array;
                    grid.LoadData(se);
                }
                catch (ApplicationException)
                {
                    MessageBox.Show(this, "Failed loading structuring element from specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.FileName = "se.txt";
            sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.Title = "Save structuring element to file";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Serialize2DimArray.Save(sfd.FileName, se);
                }
                catch (ApplicationException)
                {
                    MessageBox.Show(this, "Failed saving structuring elemnt to specified file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        


    }
}
