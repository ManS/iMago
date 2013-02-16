using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageManipulation;
using Utilities.ImageFormats;

namespace iMago
{
    public partial class ArithmeticAndLogicalOperations : DevExpress.XtraEditors.XtraForm
    {
        public enum ArithAndLogOperations
        {
            Add = 0,
            Not = 1,
            And = 2,
            Sub = 3,
            OR = 4
        }

        Dictionary<int, bool> manipulated = new Dictionary<int, bool>();
        int FirstSelectedImage = 0;
        int SecondSelectedImage = 0;
        public Bitmap ManipulatedImage;
        ArithAndLogOperations selectedOperation;
        Dictionary<int, Bitmap> Images = new Dictionary<int, Bitmap>();
        Dictionary<int, ArithAndLogOperations> Operations = new Dictionary<int, ArithAndLogOperations>();
        Dictionary<int, int> comboMap = new Dictionary<int, int>();
        public bool IsPressed = false;

        public ArithmeticAndLogicalOperations(Dictionary<int,ImageManipulator> m_imagesManipulators)
        {
            InitializeComponent();

            bool first = false;
            int i = 0;

            foreach (KeyValuePair<int, ImageManipulator> item in m_imagesManipulators)
            {
                if (!first)
                {
                    FirstSelectedImage = item.Key;
                    SecondSelectedImage = item.Key;
                    first = true;
                }
                manipulated.Add(item.Key, false);
                Images.Add(i, item.Value.ImagePanel.Image);
                string ImageName = m_imagesManipulators[item.Key].ImagePanel.Name;
                int j = 1;
                while (FirstImage_CB.Properties.Items.Contains(ImageName))
                {
                    ImageName = m_imagesManipulators[item.Key].ImagePanel.Name + "_"+j.ToString();
                    j++;
                }
                FirstImage_CB.Properties.Items.Add(ImageName);
                SecondImage_CB.Properties.Items.Add(ImageName);
                comboMap.Add(i, item.Key);
                i++;
            }

            FirstImage_CB.SelectedIndex =0;
            SecondImage_CB.SelectedIndex =0;

            Preview_PB.Image = Images[FirstSelectedImage];
            FirstImage_PB.Image = Images[FirstSelectedImage];
            SecondImage_PB.Image = Images[SecondSelectedImage];

            Operations.Add(0, ArithAndLogOperations.Add);
            Operations.Add(1, ArithAndLogOperations.And);
            Operations.Add(2, ArithAndLogOperations.Sub);
            Operations.Add(3, ArithAndLogOperations.OR);
            Operations.Add(4, ArithAndLogOperations.Not);

            Operations_CB.Properties.Items.Add(ArithAndLogOperations.Add);
            Operations_CB.Properties.Items.Add(ArithAndLogOperations.And);
            Operations_CB.Properties.Items.Add(ArithAndLogOperations.Sub);
            Operations_CB.Properties.Items.Add(ArithAndLogOperations.OR);
            Operations_CB.Properties.Items.Add(ArithAndLogOperations.Not);

            Operations_CB.SelectedIndex = 0;

            selectedOperation = ArithAndLogOperations.Add;
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            PerformOperation();
            ManipulatedImage = (Bitmap)Preview_PB.Image;
        }

        private void PerformOperation()
        {
            switch (selectedOperation)
            {
                case ArithAndLogOperations.Add:
                    {
                        Preview_PB.Image = ArithmeticOperations.AddTwoImages(Images[FirstSelectedImage], Images[SecondSelectedImage]);
                    }
                    break;
                case ArithAndLogOperations.Not:
                    {
                        Preview_PB.Image = ArithmeticOperations.NotOperation(Images[FirstSelectedImage]);
                    }
                    break;
                case ArithAndLogOperations.And:
                    {
                        Preview_PB.Image = LogicalOperations.AndingTwoImages(Images[FirstSelectedImage], Images[SecondSelectedImage]);
                    }
                    break;
                case ArithAndLogOperations.Sub:
                    {
                        Preview_PB.Image = ArithmeticOperations.SubtractTwoImages(Images[FirstSelectedImage], Images[SecondSelectedImage]);
                    }
                    break;
                case ArithAndLogOperations.OR:
                    {
                        Preview_PB.Image = LogicalOperations.OringTwoImages(Images[FirstSelectedImage], Images[SecondSelectedImage]);
                    }
                    break;
                default:
                    break;
            }
        }

       

        private void SecondImage_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecondSelectedImage = SecondImage_CB.SelectedIndex;
            SecondImage_PB.Image = Images[SecondSelectedImage];
        }

        private void Operations_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOperation = Operations[Operations_CB.SelectedIndex];
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            ManipulatedImage = (Bitmap)Preview_PB.Image;
            IsPressed = true;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "PPM Files |*.ppm";
            if (SaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SavingFormat SaveForm = new SavingFormat();
                SaveForm.ShowDialog();

                if (SaveForm.Selected)
                {
                    switch (SaveForm.selectedtype)
                    {
                        case PPMFileType.p1:
                            MessageBox.Show("Not Implemented yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case PPMFileType.p2:
                            MessageBox.Show("Not Implemented yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case PPMFileType.p3:
                            ImageWriterFactory.GetImageWriter(ImageFormat.P3).SaveImage(ManipulatedImage,SaveFile.FileName);
                            break;
                        case PPMFileType.p4:
                            MessageBox.Show("Not Implemented yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case PPMFileType.p5:
                            MessageBox.Show("Not Implemented yet!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case PPMFileType.p6: 
                            ImageWriterFactory.GetImageWriter(ImageFormat.P3).SaveImage(ManipulatedImage, SaveFile.FileName);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void FirstImage_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirstSelectedImage = FirstImage_CB.SelectedIndex;
            FirstImage_PB.Image = Images[FirstSelectedImage];
        }
    }
}