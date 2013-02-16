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

namespace iMago
{
    enum PreviewOption
    {
        MaskPreview,
        FrequencyDomainPreview,
        SpatialDomainPreview
    }

    public partial class FrequencyDomainEnhancement : DevExpress.XtraEditors.XtraForm
    {
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
        ImageManipulator m_manipulator;

        #endregion

        public FrequencyDomainEnhancement(ImageManipulator p_manipulator)
        {
            InitializeComponent();
            m_manipulator = p_manipulator;
            Control.CheckForIllegalCrossThreadCalls = false;
            SelectedPreview = PreviewOption.SpatialDomainPreview;

            int xCenter = m_manipulator.Image.BitmapImage.Width / 2;
            int yCenter = m_manipulator.Image.BitmapImage.Height / 2;

            int MaxRaduis = (int)Math.Sqrt((xCenter * xCenter) + (yCenter * yCenter));

            this.Radius_seeker.Properties.Maximum = MaxRaduis;
            this.Radius_updown.Properties.MaxValue = MaxRaduis;
            this.N_seeker.Properties.Maximum = 100;
            this.N_updown.Properties.MaxValue = 100;
            this.bandWidth_trackbar.Properties.Maximum = MaxRaduis;
            this.bandwidth_updown.Properties.MaxValue = 100;

            this.spatialImagePreview = m_manipulator.Image.BitmapImage;
            this.originalImage = m_manipulator.Image.BitmapImage;

            freqImage = FourierTransformer.FourierTransform(m_manipulator.Image.BitmapImage);

            MyFilter = new IdealFilter(freqImage, this.Radius_seeker.Value, FilteringType.Pass,FrequencyFilterName.IdealFilter);
            this.maskPreviewImage = MyFilter.GetMaskPreviewImage();


            this.N_updown.Value = 1;
            this.N_seeker.Value = 1;
            this.frequencyImagePreview = freqImage.GetMagnitudeImage();
            this.Preview_picbox.Image = this.maskPreviewImage;
            this.FilterType_combBox.SelectedIndex = 0;
            this.Filter_radioBox.SelectedIndex = 0;
            this.Preview_radioBox.SelectedIndex = 0;


            filteringType = this.GetFilteringType();
            filterName = this.GetFilterName();

            this.notchGroubBox.Hide();
            this.BandWidthSeeker.Hide();
        }

        #region Update Functions
        
        private void UpdateMaskPreview()
        {
            this.maskPreviewImage = this.MyFilter.GetMaskPreviewImage();
            this.Preview_picbox.Image = this.maskPreviewImage;
        }

        private void UpdateSpatialImagePreview()
        {
            this.spatialImagePreview = this.MyFilter.ApplyFilter(this.freqImage, DomainType.SpatialDomain);
           this.Preview_picbox.Image = this.spatialImagePreview;
        }

        private void UpdateFrequencyImagePreview()
        {
            this.frequencyImagePreview = this.MyFilter.ApplyFilter(this.freqImage.GetMagnitudeImage());
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

        #region Controls Events Handlers

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

        private void OK_btn_Click(object sender, EventArgs e)
        {
            //Manipulated = true;
            this.m_manipulator.ImagePanel.Image = (Bitmap)this.Preview_picbox.Image;
            this.m_manipulator.NotifyUpdated("Frequency Filters");
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Manipulated = false;
            this.m_manipulator.Reset();
            this.Close();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            this.originalImage = this.spatialImagePreview;
            this.freqImage = FourierTransformer.FourierTransform(this.originalImage);
            //this.m_manipulator.ImagePanel.Image = this.originalImage;
            Manipulated = true;
        }
        
        private void FilterType_combBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            notchGroubBox.Hide();
            BandWidthSeeker.Hide();

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
      
        private void bandWidth_trackbar_EditValueChanged(object sender, EventArgs e)
        {
            bandwidth_updown.Value = bandWidth_trackbar.Value;
            if (this.band_preview.Checked)
            {
                this.MyFilter = new BandFilter(this.freqImage, filterName, filteringType, this.N_seeker.Value, this.bandWidth_trackbar.Value, this.Radius_seeker.Value);
                UpdatePreview();
            }
        }

        private void bandwidth_updown_EditValueChanged(object sender, EventArgs e)
        {
            bandWidth_trackbar.Value = (int)bandwidth_updown.Value;
            if (this.band_preview.Checked)
            {

                this.MyFilter = new BandFilter(this.freqImage, filterName, filteringType, this.N_seeker.Value, this.bandWidth_trackbar.Value, this.Radius_seeker.Value);
                UpdatePreview();
            }
        }

        private void preview_notch_Click(object sender, EventArgs e)
        {
            FilteringType filteringType = this.GetFilteringType();
            FrequencyFilterName filterName = this.GetFilterName();
            int xnotch;
            int ynotch;
            try
            {
                xnotch = int.Parse(NotchXTextBox.Text);
                ynotch = int.Parse(NotchYTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.MyFilter = new NotchFilter(this.freqImage, filterName, filteringType, this.N_seeker.Value,
                this.Radius_seeker.Value, xnotch, ynotch);
            UpdatePreview();
        }

        private void band_preview_CheckedChanged(object sender, EventArgs e)
        {
            if (band_preview.Checked)
            {
                this.MyFilter = new BandFilter(this.freqImage, filterName, filteringType, this.N_seeker.Value, this.bandWidth_trackbar.Value, this.Radius_seeker.Value);
                UpdatePreview();
            }
            else
            {

            }
        }
        
        #endregion
  
        private void UpdateFilter()
        {
            FilteringType filteringType = this.GetFilteringType();
            if (this.FilterType_combBox.SelectedIndex == 0 || this.FilterType_combBox.SelectedIndex == 1)//Low pass || high pass
            {
                if (filteringType == FilteringType.Pass)
                {
                    filteringType = FilteringType.Lowpass;
                }
                switch (this.Filter_radioBox.SelectedIndex)
                {
                    case 0:
                        this.MyFilter = new IdealFilter(this.freqImage, this.Radius_seeker.Value, filteringType, FrequencyFilterName.IdealFilter);
                        break;
                    case 1:
                        this.MyFilter = new ButterWorthFilter(this.freqImage, this.Radius_seeker.Value, this.N_seeker.Value, filteringType, FrequencyFilterName.ButterWorthFilter);
                        break;
                    default:
                        this.MyFilter = new GaussianFilter(this.freqImage, this.Radius_seeker.Value, filteringType, FrequencyFilterName.GaussianFilter);
                        break;
                }
            }
            else
            {
                if (FilterType_combBox.SelectedIndex == 2 || FilterType_combBox.SelectedIndex == 3)//Band pass || Band Reject
                    BandWidthSeeker.Show();
                else//notch pass || reject
                {
                    notchGroubBox.Show();
                }
            }
            UpdatePreview();
        }

        private FilteringType GetFilteringType()
        {
            if (this.FilterType_combBox.SelectedIndex == 0 || this.FilterType_combBox.SelectedIndex == 2 || this.FilterType_combBox.SelectedIndex == 4)
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
       
    }
}