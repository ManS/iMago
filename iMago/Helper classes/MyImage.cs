using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Drawing.Imaging;
using Utilities;
using Utilities.ImageFormats;

namespace iMago
{
    public class MyImage
    {
        #region Attributes
        private int m_processNumber = -1;
        private int m_historyPointer = -1;  
        #endregion

        #region Properties
        public int HistoryPointer
        {
            get { return m_historyPointer; }
            set { m_historyPointer = value; }
        }
        public Bitmap BitmapImage { get;  set; }
        public ImageStatistics.ImageStatistics ImageStatistics { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public float RotatedBy { get; set; }
        public ImageProcessingLog ProcessingHistory { get; private set; }
        #endregion 

        #region Constructor
        public MyImage(string p_imageFile,bool readFileOnly)
        {
            this.BitmapImage = MyImage.FromFile(p_imageFile);
            this.ImageStatistics = new ImageStatistics.ImageStatistics();
            ProcessingHistory = new ImageProcessingLog();
        }
        public MyImage(string p_imageFile)
        {
            this.ProcessingHistory = new ImageProcessingLog();
            this.BitmapImage = MyImage.FromFile(p_imageFile);
            this.Width = this.BitmapImage.Width;
            this.Height = this.BitmapImage.Height;
            this.ImageStatistics = new ImageStatistics.ImageStatistics();
            this.ImageStatistics.CalculateStatistics(this.BitmapImage);
            this.AddImageToHistory("Open");
        }
        public MyImage(Bitmap p_image)
        {
            this.ProcessingHistory = new ImageProcessingLog();
            this.BitmapImage = p_image;
            this.ImageStatistics = new ImageStatistics.ImageStatistics();
            this.ImageStatistics.CalculateStatistics(this.BitmapImage);
            this.Width = this.BitmapImage.Width;
            this.Height = this.BitmapImage.Height;
            this.AddImageToHistory("Open");
        }
        #endregion

        #region Methods
        public void ClearHistory()
        {
            this.ProcessingHistory.Clear();
            m_processNumber = 0;
            m_historyPointer = 0;
        }
        public void AddImageToHistory(string p_operationName)
        {
            m_historyPointer = ++m_processNumber;
            this.ProcessingHistory.AddImage(m_processNumber,this.BitmapImage, p_operationName);
        }
        public Bitmap RetrieveImageFromHistory(int p_processesNumber)
        {
            if (this.ProcessingHistory.ProcessingLog.ContainsKey(p_processesNumber))
            {
                m_historyPointer = p_processesNumber;
                return this.ProcessingHistory.ProcessingLog[p_processesNumber].Image;
            }
            throw new IndexOutOfRangeException("This key is not present in the history..");
        }
        public void UpdateImageStatistics()
        {
            this.ImageStatistics.CalculateStatistics(this.BitmapImage);
        }
        public void Update(Bitmap p_image)
        {
            this.BitmapImage = p_image;
            this.UpdateImageStatistics();
        }
        #endregion
        
        #region Static Methods
        public static Bitmap FromFile(string p_Imagefile)
        {
            return ImageReaderFactory.GetImageReader(p_Imagefile).ReadImage(p_Imagefile);
        }
        public static bool IsGrayScale(Bitmap p_image)
        {
            bool ret = false;

            // check pixel format
            if (p_image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                ret = true;
                // check palette
                ColorPalette cp = p_image.Palette;
                Color c;
                // init palette
                for (int i = 0; i < 256; i++)
                {
                    c = cp.Entries[i];
                    if ((c.R != i) || (c.G != i) || (c.B != i))
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }
        #endregion
    }
}