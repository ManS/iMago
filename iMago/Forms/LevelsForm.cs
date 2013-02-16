using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;



namespace iMago
{
    public partial class LevelsForm : DevExpress.XtraEditors.XtraForm
    {
        public bool manipulated = false;
        public bool modified = false;
    
        private static Color[] colors = new Color[] {
														Color.FromArgb(192, 0, 0),
														Color.FromArgb(0, 192, 0),
														Color.FromArgb(0, 0, 192),
														Color.FromArgb(128, 128, 128),
		};
        

        private LevelsLinear filter = new LevelsLinear();
        private IntRange inRed = new IntRange(0, 255);
        private IntRange inGreen = new IntRange(0, 255);
        private IntRange inBlue = new IntRange(0, 255);
        private IntRange outRed = new IntRange(0, 255);
        private IntRange outGreen = new IntRange(0, 255);
        private IntRange outBlue = new IntRange(0, 255);

        private AForge.Imaging.ImageStatistics imgStat;
        //private Histogram histogram;

        public Bitmap Image
       {
           set { filterPreview.Image = value; }

           get { return filter.Apply(filterPreview.Image); }
        }

        public IFilter Filter
        {
            get { return filter; }
        }

        public LevelsForm(AForge.Imaging.ImageStatistics imgStat)
        {
            InitializeComponent();
            filterPreview.Image = filterPreview.Image;
            this.imgStat = imgStat;

            if (!imgStat.IsGrayscale)
            {
                // RGB picture
                channelCombo.Properties.Items.AddRange(new object[] { "Red", "Green", "Blue" });
                channelCombo.Enabled = true;
            }
            else
            {
                // grayscale picture
                channelCombo.Properties.Items.Add("Gray");
                channelCombo.Enabled = false;
                allCheckBox.Enabled = false;
            }
            channelCombo.SelectedIndex = 0;

            filterPreview.Filter = filter;
        }

        private void channelCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AForge.Math.Histogram h = null;
            Color color = Color.White;
            IntRange input = new IntRange(0, 255);
            IntRange output = new IntRange(0, 255);
            int index = channelCombo.SelectedIndex;

            if (!imgStat.IsGrayscale)
            {
                // RGB image
                histogram.Color = colors[index];

                switch (index)
                {
                    case 0:	// red
                        h = imgStat.Red;
                        input = inRed;
                        output = outRed;
                        color = Color.FromArgb(255, 0, 0);
                        break;
                    case 1:	// green
                        h = imgStat.Green;
                        input = inGreen;
                        output = outGreen;
                        color = Color.FromArgb(0, 255, 0);
                        break;
                    case 2:	// blue
                        h = imgStat.Blue;
                        input = inBlue;
                        output = outBlue;
                        color = Color.FromArgb(0, 0, 255);
                        break;
                }
            }
            else
            {
                // grayscale image
                histogram.Color = colors[3];
                h = imgStat.Gray;

                input = inGreen;
                output = outGreen;
            }
            histogram.Values = h.Values;

            inMinBox.Text = input.Min.ToString();
            inMaxBox.Text = input.Max.ToString();
            outMinBox.Text = output.Min.ToString();
            outMaxBox.Text = output.Max.ToString();
        }

        private void inMinBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                byte v = byte.Parse(inMinBox.Text);

                if (!imgStat.IsGrayscale)
                {
                    // RGB
                    if (allCheckBox.Checked)
                    {
                        // sync channels
                        inRed.Min = inGreen.Min = inBlue.Min = v;
                    }
                    else
                    {
                        switch (channelCombo.SelectedIndex)
                        {
                            case 0:
                                inRed.Min = v;
                                break;
                            case 1:
                                inGreen.Min = v;
                                break;
                            case 2:
                                inBlue.Min = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    inGreen.Min = v;
                }

                UpdateFilter();
            }
            catch (Exception)
            {
            }
        }

        private void inMaxBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                byte v = byte.Parse(inMaxBox.Text);

                if (!imgStat.IsGrayscale)
                {
                    // RGB
                    if (allCheckBox.Checked)
                    {
                        // sync channels
                        inRed.Max = inGreen.Max = inBlue.Max = v;
                    }
                    else
                    {
                        switch (channelCombo.SelectedIndex)
                        {
                            case 0:
                                inRed.Max = v;
                                break;
                            case 1:
                                inGreen.Max = v;
                                break;
                            case 2:
                                inBlue.Max = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    inGreen.Max = v;
                }

                UpdateFilter();
            }
            catch (Exception)
            {
            }
        }

        private void outMinBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                byte v = byte.Parse(outMinBox.Text);

                if (!imgStat.IsGrayscale)
                {
                    // RGB
                    if (allCheckBox.Checked)
                    {
                        // sync channels
                        outRed.Min = outGreen.Min = outBlue.Min = v;
                    }
                    else
                    {
                        switch (channelCombo.SelectedIndex)
                        {
                            case 0:
                                outRed.Min = v;
                                break;
                            case 1:
                                outGreen.Min = v;
                                break;
                            case 2:
                                outBlue.Min = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    outGreen.Min = v;
                }

                UpdateFilter();
            }
            catch (Exception)
            {
            }
        }

        private void outMaxBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                byte v = byte.Parse(outMaxBox.Text);

                if (!imgStat.IsGrayscale)
                {
                    // RGB
                    if (allCheckBox.Checked)
                    {
                        // sync channels
                        outRed.Max = outGreen.Max = outBlue.Max = v;
                    }
                    else
                    {
                        switch (channelCombo.SelectedIndex)
                        {
                            case 0:
                                outRed.Max = v;
                                break;
                            case 1:
                                outGreen.Max = v;
                                break;
                            case 2:
                                outBlue.Max = v;
                                break;
                        }
                    }
                }
                else
                {
                    // grayscale
                    outGreen.Max = v;
                }

                UpdateFilter();
            }
            catch (Exception)
            {
            }
        }

        private void inSlider_ValueChanged(object sender, EventArgs e)
        {
            inMinBox.Text = inSlider.Value.Minimum.ToString();
            inMaxBox.Text = inSlider.Value.Maximum.ToString();
        }

        private void outSlider_ValueChanged(object sender, EventArgs e)
        {
            outMinBox.Text = outSlider.Value.Minimum.ToString();
            outMaxBox.Text = outSlider.Value.Maximum.ToString();
        }

        private void UpdateFilter()
        {
            // input values
            filter.InRed = inRed;
            filter.InGreen = inGreen;
            filter.InBlue = inBlue;
            // output values
            filter.OutRed = outRed;
            filter.OutGreen = outGreen;
            filter.OutBlue = outBlue;
            filterPreview.RefreshFilter();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
          
            manipulated = true;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



    }
}
