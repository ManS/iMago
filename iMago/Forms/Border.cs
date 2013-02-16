using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ImageManipulation;
using System.Resources;
using System.Globalization;
using System.Collections;

namespace iMago.Forms
{
    enum  BorderColor {BlackBorder,WhiteBorder};
    public partial class Border :  DevExpress.XtraEditors.XtraForm
    {

        int index = 0;
        public bool manipulated;
        public Image resultedImage;
        BorderColor borderColor;
        List<BorderColor> borderColorList;

        public Border(Image image)
        {
            InitializeComponent();
            borderColorList = new List<BorderColor>();
            imageSourcePictureBox.Image = image;
            FillImageList();
        }

        private void Border_Load(object sender, EventArgs e)
        {
     
     
        }

        private void bordersComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void bordersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            int borderIndex = bordersComboBox.SelectedIndex;
            Image temp = bordersComboBox.ICImageList.Images[borderIndex];
            if(borderColorList[borderIndex]==BorderColor.WhiteBorder)
                 resultedImage=  LogicalOperations.AndingTwoImages((Bitmap) imageSourcePictureBox.Image,(Bitmap) temp);
            else
                 resultedImage = LogicalOperations.OringTwoImages((Bitmap) imageSourcePictureBox.Image,(Bitmap)temp);

            imageDestinationPictureBox.Image = resultedImage;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void FillImageList()
        {
            ResourceSet resourceSet = global::iMago.Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = (string)entry.Key;
                object resource = entry.Value;
                bordersComboBox.ICImageList.Images.Add((Bitmap)resource);
                bordersComboBox.ICImageList.ImageSize = new Size(100, 100);
                bordersComboBox.Items.Add(new ImgCbo.ICItem(index.ToString(), index));
                index++;
                if (int.Parse(resourceKey.Split('_')[1]) < 11)
                     borderColorList.Add(BorderColor.BlackBorder);
                 else
                     borderColorList.Add(BorderColor.WhiteBorder);
                if (index ==21)
                {
                    break;
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            manipulated = true;
            this.Hide();
      
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
