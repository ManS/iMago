using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Filters.FrequencyFilters;

using System.Threading;
using Utilities;
using Filters;

namespace iMago.Forms
{
    public partial class NotchFilterForm : DevExpress.XtraEditors.XtraForm
    {
        enum PreviewOption
        {
            MaskPreview,
            FrequencyDomainPreview,
            SpatialDomainPreview
        }

        #region Attributes
        private IFrequencyFilter MyFilter;
        private FrequencyDomainImage freqImage;
        private PreviewOption SelectedPreview;

        FilteringType filteringType;// = this.GetFilteringType();
        FrequencyFilterName filterName;// = this.GetFilterName();

        private Bitmap spatialImagePreview;
        public Bitmap originalImage;
        private Bitmap maskPreviewImage;
        private Bitmap frequencyImagePreview;
        private Thread workerThread;
        public bool Manipulated = false;
        private int ImageWidth;
        private int ImageHeight;
        ImageManipulator m_manipulator;
        private int notchx = 0;
        private int notchy = 0;
        #endregion
        
        #region Update Functions

        private void UpdateMaskPreview()
        {
            this.maskPreviewImage = this.MyFilter.GetMaskPreviewImage();
            this.Preview_picbox.Image = this.maskPreviewImage;
        }

        private void UpdateSpatialImagePreview()
        {
            //this.spatialImagePreview = this.MyFilter.ApplyFilter(this.freqImage, DomainType.SpatialDomain);
            this.Preview_picbox.Image = this.spatialImagePreview;
        }

        private void UpdateFrequencyImagePreview()
        {
            this.frequencyImagePreview = this.MyFilter.ApplyFilter(frequencyImagePreview);
            this.Preview_picbox.Image = this.frequencyImagePreview;

        }

        private void UpdatePreview()
        {
            switch (this.SelectedPreview)
            {
                case PreviewOption.MaskPreview:
                    {
                        if (workerThread != null && workerThread.ThreadState == ThreadState.Running)
                            workerThread.Join();
                        ThreadStart myThreadStart = delegate { UpdateMaskPreview(); };
                        workerThread = new Thread(myThreadStart);
                        workerThread.Start();
                    }
                    break;
                case PreviewOption.FrequencyDomainPreview:
                    {
                        if (workerThread != null && workerThread.ThreadState == ThreadState.Running)
                            workerThread.Join();
                        ThreadStart myThreadStart = delegate { UpdateFrequencyImagePreview(); };
                        workerThread = new Thread(myThreadStart);
                        workerThread.Start();
                    }
                    break;
                case PreviewOption.SpatialDomainPreview:
                    {
                        if (workerThread != null && workerThread.ThreadState == ThreadState.Running)
                            workerThread.Join();
                        ThreadStart myThreadStart = delegate { UpdateSpatialImagePreview(); };
                        workerThread = new Thread(myThreadStart);
                        workerThread.Start();
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        public NotchFilterForm(ImageManipulator p_manipulator)
        {
            InitializeComponent();
            m_manipulator = p_manipulator;
            Control.CheckForIllegalCrossThreadCalls = false;
            SelectedPreview = PreviewOption.SpatialDomainPreview;

            int xCenter = m_manipulator.Image.BitmapImage.Width / 2;
            int yCenter = m_manipulator.Image.BitmapImage.Height / 2;

            freqImage = FourierTransformer.FourierTransform(m_manipulator.Image.BitmapImage);

            this.MyFilter = new NotchFilter(this.freqImage, filterName, filteringType, 1,
                   1, notchx, notchy);
 
            int MaxRaduis = (int)Math.Sqrt((xCenter * xCenter) + (yCenter * yCenter));

            this.Radius_seeker.Properties.Maximum = MaxRaduis;
            this.Radius_updown.Properties.MaxValue = MaxRaduis;
            this.N_seeker.Properties.Maximum = 100;
            this.N_updown.Properties.MaxValue = 100;
            
            this.spatialImagePreview = m_manipulator.Image.BitmapImage;
            this.originalImage = m_manipulator.Image.BitmapImage;

           
            this.N_updown.Value = 1;
            this.N_seeker.Value = 1;


            this.frequencyImagePreview = freqImage.GetMagnitudeImage();
            
            this.maskPreviewImage = this.MyFilter.GetMaskPreviewImage();

            this.Preview_picbox.Image = this.maskPreviewImage;
            this.FilterType_combBox.SelectedIndex = 0;
            this.Filter_radioBox.SelectedIndex = 0;
            this.Preview_radioBox.SelectedIndex = 0;
            this.ImageWidth = p_manipulator.Image.Width;
            this.ImageHeight = p_manipulator.Image.Height;

            filteringType = this.GetFilteringType();
            filterName = this.GetFilterName();
        }

        #region Controls Event Handlers
        
        private void Preview_picbox_MouseHover(object sender, EventArgs e)
        {
            if (SelectedPreview == PreviewOption.FrequencyDomainPreview)
            {
                Cursor = Cursors.Cross;
            }
        }
        
        private void Preview_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Preview_radioBox.SelectedIndex == 0)
            {
                this.SelectedPreview = PreviewOption.MaskPreview;
            }
            else if (this.Preview_radioBox.SelectedIndex == 1)
            {
                this.SelectedPreview = PreviewOption.FrequencyDomainPreview;
            }
            else
                this.SelectedPreview = PreviewOption.SpatialDomainPreview;
            UpdatePreview();
        }

        private void FilterName_CheckedChanged(object sender, EventArgs e)
        {

            filterName = this.GetFilterName();

            this.UpdateFilter();
            UpdatePreview();
        }

        private void Radius_seeker_Scroll(object sender, EventArgs e)
        {
            this.Radius_updown.Value = this.Radius_seeker.Value;
            this.MyFilter.FilterRadius = Radius_seeker.Value;
            UpdatePreview();
        }

        private void N_seeker_Scroll(object sender, EventArgs e)
        {
            this.N_updown.Value = this.N_seeker.Value;
            this.MyFilter.N = this.N_seeker.Value;
            if (this.Filter_radioBox.SelectedIndex == 1)
            {
                UpdatePreview();
            }
        }

        private void FilterType_combBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filteringType = this.GetFilteringType();
            this.UpdateFilter();
        }

        private void Radius_updown_EditValueChanged(object sender, EventArgs e)
        {
            this.Radius_seeker.Value = (int)this.Radius_updown.Value;
            MyFilter.FilterRadius = this.Radius_seeker.Value;
            UpdatePreview();
        }

        private void N_updown_EditValueChanged(object sender, EventArgs e)
        {
            this.N_seeker.Value = (int)this.N_updown.Value;
            this.MyFilter.N = this.N_seeker.Value;
            if (this.Filter_radioBox.SelectedIndex == 1)
                UpdatePreview();
        }

        #endregion
        
        private void UpdateFilter()
        {
            FilteringType filteringType = this.GetFilteringType();
            UpdatePreview();
        }

        private FilteringType GetFilteringType()
        {
            if (this.FilterType_combBox.SelectedIndex == 0)
                return FilteringType.Pass;
            return FilteringType.Reject;
        }

        private FrequencyFilterName GetFilterName()
        {
            if (this.Filter_radioBox.SelectedIndex == 0)
                return FrequencyFilterName.IdealFilter;
            else if (this.Filter_radioBox.SelectedIndex == 1)
                return FrequencyFilterName.ButterWorthFilter;
            else
                return FrequencyFilterName.GaussianFilter;
        }

        private void Preview_picbox_Click(object sender, EventArgs e)
        {
            if (this.SelectedPreview == PreviewOption.FrequencyDomainPreview)
            {
                Point myFormLocation = this.Location;
               
                Point origin = new Point();
                origin.X = myFormLocation.X + 27;
                origin.Y = myFormLocation.Y + 46;
 
                int xCursor = Cursor.Position.X - origin.X;
                int yCursor = Cursor.Position.Y - origin.Y;


                notchx = xCursor - this.ImageWidth / 2;

                if (xCursor < this.ImageWidth / 2) 
                {
                    notchx *= -1;
                }
                
                notchy = yCursor - this.ImageHeight / 2;
                if (yCursor < this.ImageHeight / 2)
                {
                    notchy *= -1;
                }

                this.MyFilter = new NotchFilter(this.freqImage, filterName, filteringType, this.N_seeker.Value,
                    this.Radius_seeker.Value, notchx, notchy);

                //this.frequencyImagePreview = this.MyFilter.ApplyFilter(this.freqImage.GetMagnitudeImage());
                //this.Preview_picbox.Image = this.frequencyImagePreview;
                //this.freqImage = this.MyFilter.ApplyFilter(this.freqImage);
               // this.frequencyImagePreview = this.MyFilter.ApplyFilter(this.freqImage, DomainType.FrequencyDomain);
                this.UpdatePreview();
                this.spatialImagePreview = this.MyFilter.ApplyFilter(this.freqImage, DomainType.SpatialDomain);
                this.freqImage = FourierTransformer.FourierTransform(this.spatialImagePreview);
            }
        }

        private void Preview_picbox_MouseLeave(object sender, EventArgs e)
        {
            if (Cursor != Cursors.Arrow)
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            this.originalImage = this.spatialImagePreview;
            this.freqImage = FourierTransformer.FourierTransform(this.originalImage);
            this.m_manipulator.ImagePanel.Image = this.originalImage;
            Manipulated = true;
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            this.m_manipulator.ImagePanel.Image = (Bitmap)this.Preview_picbox.Image;
            this.m_manipulator.NotifyUpdated("Notch Filter");
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Manipulated = false;
            this.m_manipulator.Reset();
            this.Close();
        }
    }
}
