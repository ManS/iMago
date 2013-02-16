using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Filters;
using Utilities;
namespace iMago
{
    public partial class Convolution : DevExpress.XtraEditors.XtraForm
    {
        public Bitmap modifiedImage;
        public bool manipulated = false;
        public Convolution(Bitmap image)
        {
            InitializeComponent();   OriginalPictureBox.Image = image;
        }
       
        private double [,]  GetDataFromDataGridView(int rows,int columns)
        {
            double[,] mask = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    mask[i, j] =double.Parse( dataGridView.Rows[i].Cells[j].Value.ToString());
                }
            }
            return mask;

        }

        private double [,] LoadMask()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            int width;
            int height;
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openDialog.Filter = "txt files (*.txt)|*.txt";
                StreamReader streamReader = new StreamReader(openDialog.FileName);
                width =int.Parse( streamReader.ReadLine());
                height = int.Parse(streamReader.ReadLine());
                dataGridView.RowCount = width;
                dataGridView.ColumnCount = height;
                double[,] mask = new double[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        mask[i, j] = double.Parse(streamReader.ReadLine());
                        dataGridView.Rows[i].Cells[j].Value = mask[i, j];
                    }
                }

             
              
                streamReader.Close();
                return mask;

            }
            return null;
            
        }
        
        private void SaveMask(double[,] mask)
        {
             int width = mask.GetLength(1);
             int height = mask.GetLength(0);



             StreamWriter streamWriter;
             SaveFileDialog saveFileDialog1 = new SaveFileDialog();



             saveFileDialog1.Filter = "txt files (*.txt)|*.txt";

             saveFileDialog1.FilterIndex = 2;

             saveFileDialog1.RestoreDirectory = true;
             if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
             {
                 streamWriter = new StreamWriter(saveFileDialog1.FileName);
                 streamWriter.WriteLine(width.ToString());
                 streamWriter.WriteLine(height.ToString());
                 for (int i = 0; i < height; i++)
                 {
                     for (int j = 0; j < width; j++)
                     {
                         streamWriter.WriteLine(mask[i, j]);
                     }
                 }
                 streamWriter.Close();
             }
         }

        private void ApplyButton_Click(object sender, EventArgs e)
        {  double [,]filter = GetDataFromDataGridView(dataGridView.RowCount, dataGridView.ColumnCount);
            CustomFilter Filter = new CustomFilter(dataGridView.RowCount, dataGridView.ColumnCount,filter,PostProcessingType.Normalization);

            ModifiedPictureBox.Image = Filter.Apply((Bitmap)OriginalPictureBox.Image, PaddingType.Replication);
            modifiedImage = (Bitmap)ModifiedPictureBox.Image;
        }

        private void MakeMaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                int width = int.Parse(WidthTextBox.Text);
                int height = int.Parse(HeightTextBox.Text);
                if (width % 2 == 0 || height % 2 == 0)
                {
                    MessageBox.Show("Data must be odd number and larger than zero ");
                    return;
                }
                DrawTheDataGridView(width, height);

            }
            catch
            {
                MessageBox.Show("Wrong Data");
                return;
            }
        
        }

        private void DrawTheDataGridView(int rows, int columns)
        {
            dataGridView.ColumnCount = columns;
            dataGridView.RowCount = rows;


        }

        private void SaveMaskButton_Click(object sender, EventArgs e)
        {
            double[,] mask = GetDataFromDataGridView(dataGridView.RowCount, dataGridView.ColumnCount);
            SaveMask(mask);
        }

        private void LoadMaskButton_Click(object sender, EventArgs e)
        {
            LoadMask();
        }

     

        private void OKButton_Click(object sender, EventArgs e)
        {
            manipulated = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            manipulated = false;
            this.Close();
        }
    }
}
