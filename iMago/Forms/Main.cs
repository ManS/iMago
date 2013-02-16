using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.IO;
using AForge.Math;
using AForge.Imaging;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using iMago;
using Utilities;
using iMago.Forms;
using ImageManipulation;
using ImageStatistics;
using Filters.NoiseRemovers;
using Filters.EdgeDetectors;
using Filters.NoiseGenerators;
using Filters.Sharping;
using Filters.Blurring;

using Filters;
using System.Threading;
namespace iMago
{

    public partial class Main : DevExpress.XtraEditors.XtraForm, IManipulatorObserver
    {

        #region Properties
        bool AnImageLoaded = false;
        bool MatlabFnsIsLoaded = false;
        static int nextTabIndex = 0;
        static Queue<int> indicesQueue;
        public Dictionary<int, ImageManipulator> ImageDocks;
        public Dictionary<int, int> historyMap = new Dictionary<int, int>();
        List<Colors> colorsChecked = new List<Colors>();
        private float zoom;
        #endregion

        # region Histogram
        private static Color[] colors = new Color[] {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),};
        private int currentImageHash = 0;
        private AForge.Imaging.ImageStatistics stat;
        private AForge.Math.Histogram activeHistogram = null;
        #endregion

        public Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            indicesQueue = new Queue<int>();
            ImageDocks = new Dictionary<int, ImageManipulator>();
            indicesQueue.Enqueue(nextTabIndex);

            SplashScreen SplashScr = new SplashScreen();
            SplashScr.Show();
            InitializeComponent();
            #region Skin
            Skin.LookAndFeel.SetSkinStyle("Sharp Plus");
            #endregion
            SplashScr.Close();
            zoom = 1.0f;
            Menu_Enable(false);

            ThreadStart MatlabFnsLoading = delegate { LoadMatlabFns(); };
            Thread LoadingMatlabFnsThread = new Thread(MatlabFnsLoading);
            LoadingMatlabFnsThread.Start();

        }

        private void Open_file_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "All Formats |*.*|Bitmap Files|*.bmp" +
                "|Enhanced Windows MetaFile|*.emf" + "PPM Files|*.PPM|" +
                "|Exchangeable Image File|*.exif" +
                "|Gif Files|*.gif|Icons|*.ico|JPEG Files|*.jpg" +
                "|PNG Files|*.png|TIFF Files|*.tif|Windows MetaFile|*.wmf|All Formats |*.*";

            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!AnImageLoaded)
                {
                    AnImageLoaded = true;
                }
                this.AddNewTabImage(OpenFile.FileName);
            }
        }

        private void AddNewTabImage(string p_fileName)
        {

            int index;
            if (indicesQueue.Count != 0)
            {
                index = indicesQueue.Dequeue();
            }
            else
            {
                nextTabIndex++;
                index = nextTabIndex;
            }
            string ImageName = Path.GetFileNameWithoutExtension(p_fileName);


            //TabPage
            DevExpress.XtraTab.XtraTabPage newtabpage = new DevExpress.XtraTab.XtraTabPage();
            newtabpage.Name = "tab*" + (index).ToString();
            newtabpage.Size = new System.Drawing.Size(448, 418);
            newtabpage.Text = ImageName;

            //ImagePanel
            iMago.ImagePanel NewimagePanel = new ImagePanel();
            NewimagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            NewimagePanel.CanvasSize = new System.Drawing.Size(60, 40);
            NewimagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            DateTime before = DateTime.Now;
            //MyImage
            MyImage newImage = new MyImage(p_fileName);

            NewimagePanel.Image = newImage.BitmapImage;

            DrawHistogram(NewimagePanel.Image);
            NewimagePanel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            NewimagePanel.Location = new System.Drawing.Point(0, 0);
            NewimagePanel.Name = Path.GetFileNameWithoutExtension(p_fileName);
            NewimagePanel.SelectedArea = new System.Drawing.Rectangle(0, 0, 0, 0);
            NewimagePanel.Size = new System.Drawing.Size(448, 418);
            NewimagePanel.TabIndex = nextTabIndex;
            NewimagePanel.Zoom = 1F;
            NewimagePanel.ImagePath = p_fileName;


            //ImageDock
            ImageManipulator newImageDock = new ImageManipulator(newImage, NewimagePanel, index);
            newImageDock.Image.UpdateImageStatistics();
            newImageDock.RegisterObserver(this);

            ImageDocks.Add(index, newImageDock);

            newtabpage.Controls.Add(NewimagePanel);

            this.ImageTabs.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            newtabpage});

            ImageTabs.SelectedTabPageIndex = ImageTabs.TabPages.IndexOf(newtabpage);
        }

        private void LoadMatlabFns()
        {
            FourierTransformer.FourierTransform(new Bitmap(10, 10));
        }

        private void ImageTabs_CloseButtonClick(object sender, EventArgs e)
        {
            XtraTabPage page = ((ClosePageButtonEventArgs)e).Page as XtraTabPage;
            int tabIndex = int.Parse(page.Name.Split('*')[1]);

            ImageTabs.TabPages.Remove(page);
            ImageDocks.Remove(tabIndex);
            indicesQueue.Enqueue(tabIndex);
            if (ImageDocks.Count == 0)
            {
                AnImageLoaded = false;
                Menu_Enable(false);
            }
        }

        private void ZoomIn_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            zoom = ImageDocks[tabIndex].ImagePanel.Zoom;
            zoom += 0.1f;
            ImageDocks[tabIndex].ImagePanel.Zoom = zoom;
        }

        private void ZoomOut_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            zoom = ImageDocks[tabIndex].ImagePanel.Zoom;
            zoom -= 0.1f;
            ImageDocks[tabIndex].ImagePanel.Zoom = zoom;
        }

        private void ActualSize_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            zoom = ImageDocks[tabIndex].ImagePanel.Zoom;
            zoom = 1.0f;
            ImageDocks[tabIndex].ImagePanel.Zoom = zoom;
        }

        private void ImageTabs_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (ImageTabs.TabPages.Count > 0)
            {
                int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
                Menu_Enable(true);
                zoom = ImageDocks[tabIndex].ImagePanel.Zoom;
                ImageResolution_lbl.Caption = "Resolution : " + ImageDocks[tabIndex].ImagePanel.Image.Width + " x " + ImageDocks[tabIndex].ImagePanel.Image.Height;
                ImageFormat_lbl.Caption = "Format : " + Path.GetExtension(ImageDocks[tabIndex].ImagePanel.ImagePath).ToUpper();
                DrawHistogram(ImageDocks[tabIndex].ImagePanel.Image);
                UpdateHistory(ImageDocks[tabIndex].Image.ProcessingHistory);
            }
            else
            {
                ImageResolution_lbl.Caption = " ";
                ImageFormat_lbl.Caption = " ";
                Menu_Enable(false);
                v.Items.Clear();
            }
        }

        private void Menu_Enable(bool Flag)
        {
            if (Flag)
            {
                EditTab.Enabled = true;
                ImageTab.Enabled = true;
                IlluminationTab.Enabled = true;
                FiltersTab.Enabled = true;
                FourierTab.Enabled = true;
                //TextHiding_btn.Enabled = true;
                Save_file.Enabled = true;
                SaveAs_file.Enabled = true;
                Covert_file.Enabled = true;
                Close_tab.Enabled = true;
                CloseAllTabs.Enabled = true;
                ImageResolution_lbl.Enabled = true;
                ImageFormat_lbl.Enabled = true;

                FourierTab.Enabled = true;
                TextHiding_btn.Enabled = true;
                Threshold.Enabled = true;
                barSubItem4.Enabled = true;
            }
            else
            {
                EditTab.Enabled = false;
                ImageTab.Enabled = false;
                IlluminationTab.Enabled = false;
                FiltersTab.Enabled = false;
                FourierTab.Enabled = false;
                // TextHiding_btn.Enabled = false;
                Save_file.Enabled = false;
                SaveAs_file.Enabled = false;
                Covert_file.Enabled = false;
                Close_tab.Enabled = false;
                CloseAllTabs.Enabled = false;
                ImageResolution_lbl.Enabled = false;
                ImageFormat_lbl.Enabled = false;
                FourierTab.Enabled = false;
                TextHiding_btn.Enabled = false;
                Threshold.Enabled = false;
                barSubItem4.Enabled = false;
            }
        }

        private void Close_tab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            ImageTabs.TabPages.Remove(ImageTabs.SelectedTabPage);
            ImageDocks.Remove(tabIndex);
            if (ImageDocks.Count == 0)
            {
                AnImageLoaded = false;
            }
        }

        private void CloseAllTabs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImageTabs.TabPages.Clear();
            ImageDocks.Clear();
            AnImageLoaded = false;
            Menu_Enable(false);
        }

        private void Rotate_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            RotationInputForm RF = new RotationInputForm(this.ImageDocks[tabIndex]);
            RF.ShowDialog();
        }

        private void Curves_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            Bitmap img = ImageDocks[tabIndex].ImagePanel.Image;
            Curves CF = new Curves();
            CF.Image = img;
            CF.ShowDialog();
            if (CF.modified)
            {
                ImageDocks[tabIndex].ImagePanel.Image = CF.distBmp;
                ImageDocks[tabIndex].NotifyUpdated("Curves");
            }
        }

        #region Drag Image
        private void ImageTabs_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void ImageTabs_DragDrop(object sender, DragEventArgs e)
        {
            try
            {

                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < fileNames.Length; i++)
                    this.AddNewTabImage(fileNames[i]);
            }
            catch
            {
                string[] directoryName = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < directoryName.Length; i++)
                {
                    //Get all the folders inside that folder
                    string[] dirs = Directory.GetDirectories(directoryName[i]);
                    //Get all the files inside that folder
                    string[] files = Directory.GetFiles(directoryName[i]);
                    foreach (string dir in dirs)
                        this.AddNewTabImage(dir);
                    foreach (string file in files)
                        this.AddNewTabImage(file);
                }
            }
        }
        #endregion

        private void Crop_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            Bitmap img = ImageDocks[tabIndex].ImagePanel.Image;
            Cropping CF = new Cropping(img);
            CF.ShowDialog();
            if (CF.cropped)
            {
                ImageDocks[tabIndex].ImagePanel.Image = CF.O_image;
                ImageDocks[tabIndex].NotifyUpdated("Cropped");

            }
        }

        # region Histogram
        public void DrawHistogram(Bitmap image)
        {
            GatherStatistics(image);
        }
        public void GatherStatistics(Bitmap image)
        {
            // avoid calculation in the case of the same image
            if (image != null)
            {
                if (currentImageHash == image.GetHashCode())
                    return;
                currentImageHash = image.GetHashCode();
            }

            // busy
            Capture = true;
            Cursor = Cursors.WaitCursor;

            // get statistics
            stat = (image == null) ? null : new AForge.Imaging.ImageStatistics(image);

            // free
            Cursor = Cursors.Arrow;
            Capture = false;

            // clean combo
            Channel_CB.Properties.Items.Clear();

            if (stat != null)
            {
                if (!stat.IsGrayscale)
                {
                    // RGB picture
                    Channel_CB.Properties.Items.AddRange(new object[] { "Red", "Green", "Blue", "Gray" });
                }
                else
                {
                    // grayscale picture
                    Channel_CB.Properties.Items.Add("Gray");
                }
                Channel_CB.SelectedIndex = 0;
                SwitchChannel((stat.IsGrayscale) ? 3 : Channel_CB.SelectedIndex);
            }
            else
            {
                Image_Histogram.Values = null;
                Mean_txt.Text = String.Empty;
                Std_txt.Text = String.Empty;
                Median_txt.Text = String.Empty;
                Min_txt.Text = String.Empty;
                Max_txt.Text = String.Empty;
                Level_txt.Text = String.Empty;
                Count_txt.Text = String.Empty;
            }
        }
        private void Channel_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Channel_CB.SelectedIndex == 3)
            {
                int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
                SwitchChannel(3, tabIndex);
            }
            else if (stat != null)
            {
                SwitchChannel((stat.IsGrayscale) ? 3 : Channel_CB.SelectedIndex);
            }
        }
        public void SwitchChannel(int channel)
        {
            if ((channel >= 0) && (channel <= 2))
            {
                if (!stat.IsGrayscale)
                {
                    Image_Histogram.Color = colors[channel];
                    activeHistogram = (channel == 0) ? stat.Red : (channel == 1) ? stat.Green : stat.Blue;
                }
            }
            else if (channel == 3)
            {
                if (stat.IsGrayscale)
                {
                    Image_Histogram.Color = colors[3];
                    activeHistogram = stat.Gray;
                }
            }

            if (activeHistogram != null)
            {
                Image_Histogram.Values = activeHistogram.Values;
                Mean_txt.Text = activeHistogram.Mean.ToString("F2");
                Std_txt.Text = activeHistogram.StdDev.ToString("F2");
                Median_txt.Text = activeHistogram.Median.ToString();
                Min_txt.Text = activeHistogram.Min.ToString();
                Max_txt.Text = activeHistogram.Max.ToString();
            }
        }
        public void SwitchChannel(int channel, int dock)
        {
            Image_Histogram.Color = colors[3];
            activeHistogram = new AForge.Math.Histogram(ImageDocks[dock].Image.ImageStatistics.Gray.Values);

            if (activeHistogram != null)
            {
                Image_Histogram.Values = activeHistogram.Values;
                Mean_txt.Text = activeHistogram.Mean.ToString("F2");
                Std_txt.Text = activeHistogram.StdDev.ToString("F2");
                Median_txt.Text = activeHistogram.Median.ToString();
                Min_txt.Text = activeHistogram.Min.ToString();
                Max_txt.Text = activeHistogram.Max.ToString();
            }
        }
        private void Image_Histogram_PositionChanged(object sender, iMago.HistogramEventArgs e)
        {
            int pos = e.Position;
            if (pos != -1)
            {
                Level_txt.Text = pos.ToString();
                Count_txt.Text = activeHistogram.Values[pos].ToString();
            }
            else
            {
                Level_txt.Text = "";
                Count_txt.Text = "";
            }
        }
        private void Image_Histogram_SelectionChanged(object sender, iMago.HistogramEventArgs e)
        {
            int min = e.Min;
            int max = e.Max;
            int count = 0;

            Level_txt.Text = min.ToString() + "..." + max.ToString();

            // count pixels
            for (int i = min; i <= max; i++)
            {
                count += activeHistogram.Values[i];
            }
            Count_txt.Text = count.ToString();
        }
        private void Log_Check_CheckedChanged(object sender, EventArgs e)
        {
            Image_Histogram.LogView = Log_Check.Checked;
        }
        #endregion

        private void BrightnessContrast_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            BrightnessContrast IlluminationForm = new BrightnessContrast(this.ImageDocks[tabIndex]);
            IlluminationForm.ShowDialog();
        }

        public void OnUpdateHistory(int tabNumber, ImageProcessingLog processingLog)
        {
            XtraTabPage page = ImageTabs.SelectedTabPage;
            int pageTabIndex = int.Parse(page.Name.Split('*')[1]);
            if (pageTabIndex == tabNumber)
            {
                this.UpdateHistory(processingLog);
                this.DrawHistogram(this.ImageDocks[tabNumber].ImagePanel.Image);
            }
        }

        private void UpdateHistory(ImageProcessingLog processingLog)
        {
            XtraTabPage page = ImageTabs.SelectedTabPage;
            int pageTabIndex = int.Parse(page.Name.Split('*')[1]);

            v.Items.Clear();
            historyMap.Clear();
            List<string> historyList = new List<string>();
            foreach (KeyValuePair<int, ImageLogEntry> LogEntry in processingLog.ProcessingLog)
            {
                historyList.Add(LogEntry.Value.OperationName);
            }
            v.Items.AddRange(historyList.ToArray());
            v.SelectedIndex = ImageDocks[pageTabIndex].Image.HistoryPointer;

        }

        private void historyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (v.Items.Count != 0)
            {
                XtraTabPage page = ImageTabs.SelectedTabPage;
                int pageTabIndex = int.Parse(page.Name.Split('*')[1]);
                this.ImageDocks[pageTabIndex].SetHistoryPointer(v.SelectedIndex);
                DrawHistogram(this.ImageDocks[pageTabIndex].ImagePanel.Image);
            }
        }

        private void ToGrayscale_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = ImageConversions.ConvertToGrayScale(this.ImageDocks[tabIndex].ImagePanel.Image);
            this.ImageDocks[tabIndex].NotifyUpdated("GrayScale");
        }

        private void FlipHorizontally_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = ImageManipulation.ImageOperation.FlippingTheImageHorizontally(this.ImageDocks[tabIndex].ImagePanel.Image);
            this.ImageDocks[tabIndex].NotifyUpdated("Flipped Horizontally");
        }

        private void FlipVertically_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = ImageManipulation.ImageOperation.FlippingTheImageVertically(this.ImageDocks[tabIndex].ImagePanel.Image);
            this.ImageDocks[tabIndex].NotifyUpdated("Flipped Vertically");
        }

        private void Translate_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Translation TranslateForm = new Translation(ImageDocks[tabIndex]);
            TranslateForm.ShowDialog();
            this.ImageDocks[tabIndex].NotifyUpdated("Translate");

        }

        private void Bilinear_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            ResizingInputForm ResizeForm = new ResizingInputForm();
            ResizeForm.ShowDialog();
            if (ResizeForm.IsPressed)
            {

                this.ImageDocks[tabIndex].ImagePanel.Image = ImageManipulation.ImageResizer.Resize
                    (this.ImageDocks[tabIndex].ImagePanel.Image, ResizeForm.newWidth, ResizeForm.newHeight, ResizeingMethod.Bilinear);

                this.ImageDocks[tabIndex].NotifyUpdated("Bilinear Resize");
            }
        }

        private void Bicubic_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            ResizingInputForm ResizeForm = new ResizingInputForm();
            ResizeForm.ShowDialog();
            if (ResizeForm.IsPressed)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = ImageManipulation.ImageResizer.Resize
                   (this.ImageDocks[tabIndex].ImagePanel.Image, ResizeForm.newWidth, ResizeForm.newHeight, ResizeingMethod.Bicubic);
                this.ImageDocks[tabIndex].NotifyUpdated("Bicubic Resize");
            }
        }

        private void NearestNeighbor_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            ResizeByFactorInputForm ResizeForm = new ResizeByFactorInputForm();
            ResizeForm.ShowDialog();
            if (ResizeForm.IsPressed)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = ImageManipulation.ImageResizer.ResizeByFactor(
                    this.ImageDocks[tabIndex].ImagePanel.Image, ResizeForm.ResizingFactor, ResizeingMethod.NearestNeighbors_0Order);
                this.ImageDocks[tabIndex].NotifyUpdated("Resize by Factor");

            }
        }

        private void ArithmeticLogical_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            ArithmeticAndLogicalOperations ArithLogicForm = new ArithmeticAndLogicalOperations(ImageDocks);
            ArithLogicForm.ShowDialog();
            if (ArithLogicForm.IsPressed)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = ArithLogicForm.ManipulatedImage;
                this.ImageDocks[tabIndex].NotifyUpdated("Arithmetic And Logical Operations");
            }
        }

        private void Quantization_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            QuantizationForm QuantizForm = new QuantizationForm(ImageDocks[tabIndex]);
            QuantizForm.Show();
        }

        public void OnUpdateHistogram(Bitmap newBitmap)
        {
            this.DrawHistogram(newBitmap);
        }

        private void HistogramSlicing_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            HistogramSlicing HistogramSlicingForm = new HistogramSlicing(ImageDocks[tabIndex].ImagePanel.Image);
            HistogramSlicingForm.ShowDialog();
            if (HistogramSlicingForm.okButtonISPressed)
            {
                ImageDocks[tabIndex].ImagePanel.Image = HistogramSlicingForm.imageAfterModification;
                ImageDocks[tabIndex].NotifyUpdated("Histogram Slicing");
            }
        }

        private void HistogramMatching_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            HistogramMatching HistogramMatchingForm = new HistogramMatching(this.ImageDocks);
            HistogramMatchingForm.ShowDialog();
            if (HistogramMatchingForm.OKButtonIsPressed)
            {
                ImageDocks[tabIndex].ImagePanel.Image = HistogramMatchingForm.pictureAfterModification;
                this.ImageDocks[tabIndex].NotifyUpdated("Histogram Matching");
            }
        }

        private void RedEqualization_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.EqualizeHistogram(
                this.ImageDocks[tabIndex].ImagePanel.Image, this.ImageDocks[tabIndex].Image.ImageStatistics.Red, Colors.Red);
            this.ImageDocks[tabIndex].NotifyUpdated("Red Histogram Equalization");
        }

        private void GreenEqualization_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.EqualizeHistogram(
                this.ImageDocks[tabIndex].ImagePanel.Image, this.ImageDocks[tabIndex].Image.ImageStatistics.Green, Colors.Green);
            this.ImageDocks[tabIndex].NotifyUpdated("Green Histogram Equalization");
        }

        private void BlueEqualization_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.EqualizeHistogram(
                this.ImageDocks[tabIndex].ImagePanel.Image, this.ImageDocks[tabIndex].Image.ImageStatistics.Blue, Colors.Blue);
            this.ImageDocks[tabIndex].NotifyUpdated("Blue Histogram Equalization");
        }

        private void RGBEqualization_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.EqualizeRedGreenBlue(ImageDocks[tabIndex].ImagePanel.Image);
            this.ImageDocks[tabIndex].NotifyUpdated("RGB Histogram Equalization");
        }

        private void GrayEqualization_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.EqualizeHistogram(
                this.ImageDocks[tabIndex].ImagePanel.Image, this.ImageDocks[tabIndex].Image.ImageStatistics.Gray, Colors.Gray);
            this.ImageDocks[tabIndex].NotifyUpdated("Gray Histogram Equalization");

        }

        private void LocalEqualization_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            //this.ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.LocalHistogramEqulaization
            //    (ImageDocks[tabIndex].ImagePanel.Image,3);
            //this.ImageDocks[tabIndex].NotifyUpdated("Local Histogram Equlaization");
        }

        private void GammaCorrection_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            GammaForm GammaForm = new GammaForm();
            GammaForm.ShowDialog();
            if (GammaForm.IsPressed)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.AdjustGamma(this.ImageDocks[tabIndex].ImagePanel.Image, GammaForm.value);
                this.ImageDocks[tabIndex].NotifyUpdated("Gamma Correction");
            }
        }

        private void OrderFilters_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            OrderStatisticsFilters orderForm = new OrderStatisticsFilters(this.ImageDocks[tabIndex]);
            orderForm.ShowDialog();
        }

        private void Geometricfilters_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm filterForm = new FilterForm(false);
            filterForm.ShowDialog();
            if (filterForm.IsPressed)
            {
                GeometricFilter GeomFilter = new GeometricFilter(filterForm.filterSize);
                this.ImageDocks[tabIndex].ImagePanel.Image = GeomFilter.RemoveNoise(this.ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].NotifyUpdated("Geometirc Filter");
            }
        }

        private void LaplacianFilter_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm filterForm = new FilterForm(true);
            filterForm.ShowDialog();
            if (filterForm.IsPressed)
            {
                LaplacianSharpening LaplacianSharpeningFilter = new LaplacianSharpening(filterForm.filterSize, filterForm.filterSize);
                this.ImageDocks[tabIndex].ImagePanel.Image = LaplacianSharpeningFilter.Apply(this.ImageDocks[tabIndex].ImagePanel.Image, filterForm.Padding);
                this.ImageDocks[tabIndex].NotifyUpdated("Laplacian Sharpening");
            }
        }

        private void ConvertToFrequencyDomain_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Bitmap bmp = this.ImageDocks[tabIndex].ImagePanel.Image;
            FrequencyDomainImage x = FourierTransformer.FourierTransform(bmp);
            this.ImageDocks[tabIndex].ImagePanel.Image = x.GetMagnitudeImage();
            this.ImageDocks[tabIndex].NotifyUpdated(" Convert To Frequency Domain");
        }

        private void SaltPepperNoise_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            AddNoise AddNoiseForm = new AddNoise(TypeOfNoise.SaltAndPepper);
            AddNoiseForm.ShowDialog();
            if (AddNoiseForm.IsPressed)
            {
                SaltAndPepperNoise noiseFilter = new SaltAndPepperNoise(AddNoiseForm.A, AddNoiseForm.B);
                this.ImageDocks[tabIndex].ImagePanel.Image = noiseFilter.AddNoise(this.ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].NotifyUpdated("Add Salt and Pepper Noise");
            }
        }


        private void GeometricFilter_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void UniformNoise_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            AddNoise AddNoiseForm = new AddNoise(TypeOfNoise.UniformNoise);
            AddNoiseForm.ShowDialog();
            if (AddNoiseForm.IsPressed)
            {
                UniformNoise noiseFilter = new UniformNoise((int)AddNoiseForm.A, (int)AddNoiseForm.B, AddNoiseForm.percentage);
                this.ImageDocks[tabIndex].ImagePanel.Image = noiseFilter.AddNoise(this.ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].NotifyUpdated("Add Uniform");
            }

        }

        private void Guassian2DFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            GaussianFilter form = new GaussianFilter();
            form.ShowDialog();
            if (form.manipulated)
            {
                GaussianBlurring2D gauss = new GaussianBlurring2D(form.sigma);
                this.ImageDocks[tabIndex].ImagePanel.Image = gauss.ApplyWithoutPostProcessing(ImageDocks[tabIndex].ImagePanel.Image, form.type);

                this.ImageDocks[tabIndex].NotifyUpdated("Gaussian Blurring 2D");
            }

        }

        private void QuntizeBy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            QuantizeBy quantizeForm = new QuantizeBy();
            quantizeForm.ShowDialog();

            if (quantizeForm.modified)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = ImageQuantization.QuantizeTheImage(this.ImageDocks[tabIndex].ImagePanel.Image, (byte)quantizeForm.bpp);
                this.ImageDocks[tabIndex].NotifyUpdated("Quantized");
            }
        }

        private void OTSU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            this.ImageDocks[tabIndex].ImagePanel.Image = ImageSegmentation.OTSUThreshold(this.ImageDocks[tabIndex].ImagePanel.Image, this.ImageDocks[tabIndex].Image.ImageStatistics.Gray);
            this.ImageDocks[tabIndex].NotifyUpdated("OTSU");
        }

        private void BasicThreshold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Epsilon formEpsilon = new Epsilon();
            formEpsilon.ShowDialog();
            if (formEpsilon.okPress)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = ImageSegmentation.BasicThreshold(this.ImageDocks[tabIndex].ImagePanel.Image, this.ImageDocks[tabIndex].Image.ImageStatistics.Gray, formEpsilon.epsilon);
                this.ImageDocks[tabIndex].NotifyUpdated("Basic Threshold");
            }
        }

        private void Erosion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            MorphologyForm Erosion = new MorphologyForm(MorphologyForm.MorphologyType.Erosion, ImageDocks[tabIndex].ImagePanel.Image);
            Erosion.ShowDialog();
            if (Erosion.manipulated)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = Erosion.image;
                this.ImageDocks[tabIndex].NotifyUpdated("Erosion");
            }
        }

        private void Dilatation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            MorphologyForm Dialation = new MorphologyForm(MorphologyForm.MorphologyType.Dialation, ImageDocks[tabIndex].ImagePanel.Image);
            Dialation.ShowDialog();
            if (Dialation.manipulated)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = Dialation.image;

                this.ImageDocks[tabIndex].NotifyUpdated("Dilatation");
            }

        }

        private void FastGaussian_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            GaussianFilter Blurring = new GaussianFilter();
            Blurring.ShowDialog();
            if (Blurring.manipulated)
            {

                GaussianBlurring1D Gaussian1D = new GaussianBlurring1D(Blurring.sigma);

                this.ImageDocks[tabIndex].ImagePanel.Image = Gaussian1D.Apply(this.ImageDocks[tabIndex].ImagePanel.Image, Blurring.type);

                this.ImageDocks[tabIndex].NotifyUpdated("Gaussian 1D");
            }
        }

        private void Fast1DMean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            if (form.IsPressed)
            {

                MeanBlurring1D MeanFilter1D = new MeanBlurring1D(form.filterSize);

                this.ImageDocks[tabIndex].ImagePanel.Image = MeanFilter1D.Apply(this.ImageDocks[tabIndex].ImagePanel.Image, form.Padding);

                this.ImageDocks[tabIndex].NotifyUpdated("Blurring Mean1D");
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FastMedian fastMedian = new FastMedian(3, this.ImageDocks[tabIndex].ImagePanel.Image.Width, this.ImageDocks[tabIndex].ImagePanel.Image.Height);
            this.ImageDocks[tabIndex].ImagePanel.Image = fastMedian.FastMedianFilter(this.ImageDocks[tabIndex].ImagePanel.Image, 15, OrderStatisticsFiltersTypes.MidPoint);
            this.ImageDocks[tabIndex].NotifyUpdated("Fast Median");
        }

        private void FrequencyDomain_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            FrequencyDomainEnhancement form = new FrequencyDomainEnhancement(this.ImageDocks[tabIndex]);
            form.Show();
        }

        private void Shear_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Shear shearForm = new Shear(this.ImageDocks[tabIndex].ImagePanel.Image);
            shearForm.ShowDialog();
            if (shearForm.ApplyButtonIsPressed)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = shearForm.Final;
                this.ImageDocks[tabIndex].NotifyUpdated("Shear");
            }
        }

        private void DisplayEachcolormagnitude_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            FrequencyDomainImage freqImage = FourierTransformer.FourierTransform(ImageDocks[tabIndex].ImagePanel.Image);
            FrequencyDomainForm FreqForm = new FrequencyDomainForm(freqImage);
            FreqForm.Show();
        }

        private void ExponentialNoise_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);

            ExponentialNoiseForm ExpoForm = new ExponentialNoiseForm();
            ExpoForm.ShowDialog();
            if (ExpoForm.Modified)
            {
                ExponentialNoise ExponentialFilter = new ExponentialNoise(ExpoForm.A, ExpoForm.noisePercentage);
                ImageDocks[tabIndex].ImagePanel.Image = ExponentialFilter.AddNoise(ImageDocks[tabIndex].ImagePanel.Image);
                ImageDocks[tabIndex].NotifyUpdated("Exponential Noise Added");
            }
        }

        private void Levels_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            LevelsForm form = new LevelsForm(new AForge.Imaging.ImageStatistics(ImageDocks[tabIndex].ImagePanel.Image));
            form.Image = ImageDocks[tabIndex].ImagePanel.Image;
            form.ShowDialog();
            if (form.manipulated)
            {
                ImageDocks[tabIndex].ImagePanel.Image = form.Image;
                ImageDocks[tabIndex].NotifyUpdated("Levels Manipulation");
            }
        }

        private void EdgeLaplacian_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm filterForm = new FilterForm(true);
            filterForm.ShowDialog();
            if (filterForm.IsPressed)
            {
                LaplacianEdgeDetector laplacianEdgeDetection = new LaplacianEdgeDetector(filterForm.filterSize, filterForm.filterSize);
                this.ImageDocks[tabIndex].ImagePanel.Image = laplacianEdgeDetection.Apply(this.ImageDocks[tabIndex].ImagePanel.Image, filterForm.Padding);
                ImageDocks[tabIndex].NotifyUpdated("Laplacian Edge detection");
            }

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            NormalThreshold form = new NormalThreshold();
            form.ShowDialog();
            if (form.manipulated)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = ImageOperation.Thresholding(form.threshold, this.ImageDocks[tabIndex].ImagePanel.Image);
                ImageDocks[tabIndex].NotifyUpdated("Normal Thresholding");
            }
        }

        private void MeanFilter_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            if (form.IsPressed)
            {
                MeanBlurring2D meanbluring = new MeanBlurring2D(form.filterSize, form.filterSize);
                this.ImageDocks[tabIndex].ImagePanel.Image = meanbluring.ApplyWithoutPostProcessing(this.ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
                ImageDocks[tabIndex].NotifyUpdated("Blurring Mean Filter");
            }
        }

        private void GaussianNoise_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            GaussianNoiseForm form = new GaussianNoiseForm();
            form.ShowDialog();
            if (form.manipulated)
            {
                GaussianNoise noise = new GaussianNoise(form.sigma, form.mu, form.noisePercent);
                this.ImageDocks[tabIndex].ImagePanel.Image = noise.AddNoise(ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].NotifyUpdated("Gaussian Noise");
            }
        }

        private void PeriodicNoise_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            PeriodicNoiseForm form = new PeriodicNoiseForm();
            form.ShowDialog();
            if (form.manipulated)
            {
                PeriodicNoise noise = new PeriodicNoise(new FrequencyDomainComponent(form.amplitude, form.frequencyX, form.frequencyY, form.phaseX, form.PhaseY));
                ImageDocks[tabIndex].ImagePanel.Image = noise.AddNoise(ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].NotifyUpdated("Periodic Noise");
            }

        }

        private void GammaNoise_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            AddNoise form = new AddNoise(TypeOfNoise.GammaNoise);
            form.ShowDialog();
            if (form.IsPressed)
            {
                GammaNoise noise = new GammaNoise((int)form.A, (int)form.B, form.percentage);
                this.ImageDocks[tabIndex].ImagePanel.Image = noise.AddNoise(ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].NotifyUpdated("Gamma Noise");
            }
        }

        private void CustomConvolution_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Convolution form = new Convolution((Bitmap)ImageDocks[tabIndex].ImagePanel.Image);
            form.ShowDialog();
            if (form.manipulated)
            {
                ImageDocks[tabIndex].ImagePanel.Image = form.modifiedImage;
                this.ImageDocks[tabIndex].NotifyUpdated("Custom Convolution");
            }
        }

        private void HorizontalFilter_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            if (form.IsPressed)
            {
                LineSharpening line = new LineSharpening(form.filterSize, form.filterSize, FilterDirection.Horizontal);
                ImageDocks[tabIndex].ImagePanel.Image = line.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
                this.ImageDocks[tabIndex].NotifyUpdated("Horizontal Sharpenning");
            }

        }

        private void EdgeHorizontal_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            PrewittCompassEdgeDetectors edge = new PrewittCompassEdgeDetectors(form.filterSize, form.filterSize, FilterDirection.Horizontal);
            ImageDocks[tabIndex].ImagePanel.Image = edge.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
            this.ImageDocks[tabIndex].NotifyUpdated("Horizontal Edge Detection");
        }

        private void EdgeVertical_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            PrewittCompassEdgeDetectors edge = new PrewittCompassEdgeDetectors(form.filterSize, form.filterSize, FilterDirection.Vertical);
            ImageDocks[tabIndex].ImagePanel.Image = edge.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
            this.ImageDocks[tabIndex].NotifyUpdated("Vertical Edge Detection");
        }

        private void EdgeRightDiagonal_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            PrewittCompassEdgeDetectors edge = new PrewittCompassEdgeDetectors(form.filterSize, form.filterSize, FilterDirection.RightDiagonal);
            ImageDocks[tabIndex].ImagePanel.Image = edge.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
            this.ImageDocks[tabIndex].NotifyUpdated("Right Diagonal Edge Detection");
        }

        private void EdgeLeftDiagonal_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            PrewittCompassEdgeDetectors edge = new PrewittCompassEdgeDetectors(form.filterSize, form.filterSize, FilterDirection.LeftDiagonal);
            ImageDocks[tabIndex].ImagePanel.Image = edge.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
            this.ImageDocks[tabIndex].NotifyUpdated("Left Diagonal Edge Detection");
        }

        private void VerticalFilter_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            if (form.IsPressed)
            {
                LineSharpening line = new LineSharpening(form.filterSize, form.filterSize, FilterDirection.Vertical);
                ImageDocks[tabIndex].ImagePanel.Image = line.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
                this.ImageDocks[tabIndex].NotifyUpdated("Vertical Sharpenning");
            }
        }

        private void LeftDiagonal_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            if (form.IsPressed)
            {
                LineSharpening line = new LineSharpening(form.filterSize, form.filterSize, FilterDirection.LeftDiagonal);
                ImageDocks[tabIndex].ImagePanel.Image = line.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
                this.ImageDocks[tabIndex].NotifyUpdated("Left Diagonal Sharpenning");
            }

        }

        private void RightDiagonal_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm form = new FilterForm(true);
            form.ShowDialog();
            if (form.IsPressed)
            {
                LineSharpening line = new LineSharpening(form.filterSize, form.filterSize, FilterDirection.RightDiagonal);
                ImageDocks[tabIndex].ImagePanel.Image = line.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
                this.ImageDocks[tabIndex].NotifyUpdated("Right Diagonal Sharpenning");
            }

        }

        private void WeightedFilter_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            WeightFilter filter = new WeightFilter();
            ImageDocks[tabIndex].ImagePanel.Image = filter.ApplyWithoutPostProcessing(ImageDocks[tabIndex].ImagePanel.Image, PaddingType.Replication);
            this.ImageDocks[tabIndex].NotifyUpdated("Weighted Filter");
        }

        private void Save_file_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void SaveAs_file_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SaveFileDialog dlgSave = new SaveFileDialog())
            {
                dlgSave.Title = "Save Image";
                dlgSave.Filter = "Bitmap Images (*.bmp)|*.bmp|All Files (*.*)|*.*";
                int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
                if (dlgSave.ShowDialog(this) == DialogResult.OK)
                {
                    ImageDocks[tabIndex].ImagePanel.Image.Save(dlgSave.FileName, ImageFormat.Jpeg);
                }
            }
        }

        private void RayleighNoise_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            AddNoise form = new AddNoise(TypeOfNoise.RayleighNoise);
            form.ShowDialog();
            if (form.IsPressed)
            {
                RayleighNoise noise = new RayleighNoise((int)form.A, (int)form.B, form.percentage);
                this.ImageDocks[tabIndex].ImagePanel.Image = noise.AddNoise(ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].NotifyUpdated("Rayleigh Noise");
            }

        }

        private void TextHiding_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Text_Hidding textHidingForm = new Text_Hidding();
            textHidingForm.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            AdaptiveThresholding form = new AdaptiveThresholding();
            form.ShowDialog();
            if (form.IsPressed)
            {
                UnsafeBitmap image = new UnsafeBitmap(this.ImageDocks[tabIndex].ImagePanel.Image);
                this.ImageDocks[tabIndex].ImagePanel.Image = ImageSegmentation.AdaptiveThresholding(form.winSize, image);
                this.ImageDocks[tabIndex].NotifyUpdated("Adaptive Thresholding");
            }
        }

        private void HighBoost_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            FilterForm filterForm = new FilterForm(true);
            filterForm.ShowDialog();
            if (filterForm.IsPressed)
            {
                HighBoostFilter HighBoostFilter = new HighBoostFilter(filterForm.filterSize, filterForm.filterSize);

                this.ImageDocks[tabIndex].ImagePanel.Image = HighBoostFilter.Apply(this.ImageDocks[tabIndex].ImagePanel.Image, filterForm.Padding);
                this.ImageDocks[tabIndex].NotifyUpdated("High Boost Sharpening");
            }
        }

        private void LaplacianGaussian_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            LaplacianOfGaussianForm form = new LaplacianOfGaussianForm();
            form.ShowDialog();
            LaplacianOfGaussian edge = new LaplacianOfGaussian(form.FilterSize, form.FilterSize, form.Sigma);
            ImageDocks[tabIndex].ImagePanel.Image = edge.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.Padding);
            this.ImageDocks[tabIndex].NotifyUpdated("Laplacian Of Gaussian Detection");
        }

        private void EdgeZeroCrossing_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            ZeroCrossing form = new ZeroCrossing();
            form.ShowDialog();
            if (form.manipulated)
            {
                ZeroCrossingEdgeDetector zerocrossing = new ZeroCrossingEdgeDetector(form.derivative1, form.derivative2, form.filterSize);
                ImageDocks[tabIndex].ImagePanel.Image = zerocrossing.Apply(ImageDocks[tabIndex].ImagePanel.Image, form.paddingType);
                this.ImageDocks[tabIndex].NotifyUpdated("Zero Crossing Edge Detection");

            }
        }

        private void Retinex_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            RetinexForm form = new RetinexForm();
            form.ShowDialog();
            if (form.PressedOk)
            {
                ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.retinex(ImageDocks[tabIndex].ImagePanel.Image, form.Sigma);
                this.ImageDocks[tabIndex].NotifyUpdated("Retinex");
            }
        }

        private void Clear_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AnImageLoaded)
            {
                XtraTabPage page = ImageTabs.SelectedTabPage;
                int pageTabIndex = int.Parse(page.Name.Split('*')[1]);
                ImageDocks[pageTabIndex].ClearHistory();
            }
        }

        private void Redo_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AnImageLoaded)
            {
                XtraTabPage page = ImageTabs.SelectedTabPage;
                int pageTabIndex = int.Parse(page.Name.Split('*')[1]);
                int historyPointer = ImageDocks[pageTabIndex].Image.HistoryPointer;
                if ((historyPointer + 1) < this.v.Items.Count)
                {
                    this.v.SelectedIndex = historyPointer + 1;
                }
            }
        }

        private void Undo_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (AnImageLoaded)
            {
                XtraTabPage page = ImageTabs.SelectedTabPage;
                int pageTabIndex = int.Parse(page.Name.Split('*')[1]);
                int historyPointer = ImageDocks[pageTabIndex].Image.HistoryPointer;
                if ((historyPointer - 1) >= 0)
                {
                    this.v.SelectedIndex = historyPointer - 1;
                }
            }
        }

        public void OnClearHistory()
        {
            this.v.Items.Clear();
            this.historyMap.Clear();
            this.v.Items.Add("Open");
        }

        private void NotchFilter_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            NotchFilterForm form = new NotchFilterForm(this.ImageDocks[tabIndex]);
            form.Show();
        }

        private void HomomorphicFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Homomorphic_Filtering form = new Homomorphic_Filtering(this.ImageDocks[tabIndex].ImagePanel.Image);
            form.ShowDialog();
            if (form.manipulated)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = form.image;
                this.ImageDocks[tabIndex].NotifyUpdated("Homomorphic Filter");
            }

        }

        private void HistogramSlicing_matlab_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Slicing form = new Slicing();
            form.ShowDialog();
            if (form.manipulated)
            {
                ImageDocks[tabIndex].ImagePanel.Image = HistogramOperations.HistogramSlicing(ImageDocks[tabIndex].ImagePanel.Image, form.minOld, form.maxOld, form.NewValue);
                this.ImageDocks[tabIndex].NotifyUpdated("Histogram Slicing");
            }

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            SobleEdgeDetector sobel = new SobleEdgeDetector(3, 3, FilterDirection.Horizontal);
            ImageDocks[tabIndex].ImagePanel.Image = sobel.Apply(ImageDocks[tabIndex].ImagePanel.Image, PaddingType.Replication);
            this.ImageDocks[tabIndex].NotifyUpdated("Sobel Horizontal");

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            SobleEdgeDetector sobel = new SobleEdgeDetector(3, 3, FilterDirection.Vertical);
            ImageDocks[tabIndex].ImagePanel.Image = sobel.Apply(ImageDocks[tabIndex].ImagePanel.Image, PaddingType.Replication);
            this.ImageDocks[tabIndex].NotifyUpdated("Sobel Vertical");
        }

        private void About_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            About AboutForm = new About();
            AboutForm.Show();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);
            Border form = new Border(this.ImageDocks[tabIndex].ImagePanel.Image);
            form.ShowDialog();
            if (form.manipulated)
            {
                this.ImageDocks[tabIndex].ImagePanel.Image = (Bitmap)form.resultedImage;
                this.ImageDocks[tabIndex].NotifyUpdated("Add Border");
                form.Close();
            }
        }



        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);


            FilterForm filterForm = new FilterForm(true);
            filterForm.ShowDialog();
            if (filterForm.IsPressed)
            {
                FastMedian fastMedian = new FastMedian(3, this.ImageDocks[tabIndex].ImagePanel.Image.Width, this.ImageDocks[tabIndex].ImagePanel.Image.Height);
                this.ImageDocks[tabIndex].ImagePanel.Image = fastMedian.FastMedianFilter(this.ImageDocks[tabIndex].ImagePanel.Image, filterForm.filterSize, OrderStatisticsFiltersTypes.MidPoint);
                this.ImageDocks[tabIndex].NotifyUpdated("Fast Mid Point Filter");

            }
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);


            FilterForm filterForm = new FilterForm(true);
            filterForm.ShowDialog();
            if (filterForm.IsPressed)
            {
                FastMedian fastMedian = new FastMedian(3, this.ImageDocks[tabIndex].ImagePanel.Image.Width, this.ImageDocks[tabIndex].ImagePanel.Image.Height);
                this.ImageDocks[tabIndex].ImagePanel.Image = fastMedian.FastMedianFilter(this.ImageDocks[tabIndex].ImagePanel.Image, filterForm.filterSize, OrderStatisticsFiltersTypes.Minimum);
                this.ImageDocks[tabIndex].NotifyUpdated("Fast Min Filter ");

            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tabIndex = int.Parse(ImageTabs.SelectedTabPage.Name.Split('*')[1]);


            FilterForm filterForm = new FilterForm(true);
            filterForm.ShowDialog();
            if (filterForm.IsPressed)
            {
                FastMedian fastMedian = new FastMedian(3, this.ImageDocks[tabIndex].ImagePanel.Image.Width, this.ImageDocks[tabIndex].ImagePanel.Image.Height);
                this.ImageDocks[tabIndex].ImagePanel.Image = fastMedian.FastMedianFilter(this.ImageDocks[tabIndex].ImagePanel.Image, filterForm.filterSize, OrderStatisticsFiltersTypes.Maximum);
                this.ImageDocks[tabIndex].NotifyUpdated("Fast Max Filter");

            }
        }

        private void Documentation_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("iMago User guide.pdf");
        }
    }
}