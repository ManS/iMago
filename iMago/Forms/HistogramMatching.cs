using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using ImageStatistics;


namespace iMago
{
    public enum ColorEnum { Grey, Red, Blue, Green };
    public partial class HistogramMatching : DevExpress.XtraEditors.XtraForm
    {

        # region Histograms
        public enum Histo
        {
          SourceHistogram,
          DestinationHistogram
        }
        private static Color[] colors = new Color[] {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),};

        private int SourceImageHash = 0;
        private int DestinationImageHash = 0;
        private AForge.Math.Histogram Source_activeHistogram = null;
        private AForge.Math.Histogram Destination_activeHistogram = null;
        private AForge.Imaging.ImageStatistics Source_stat;
        private AForge.Imaging.ImageStatistics Destination_stat;

        #endregion

        public bool OKButtonIsPressed = false;
        public Bitmap pictureAfterModification = null;
        
        List<Colors> colorsChecked = new List<Colors>();
        List<Colors> colorsChecked2 = new List<Colors>();

        Dictionary<int, ImageManipulator> Images;
        Dictionary<int, int> comboManipulatorMap;

        public HistogramMatching(Dictionary<int, ImageManipulator> images)
        {
            InitializeComponent();
            Images = new Dictionary<int, ImageManipulator>(images);
            comboManipulatorMap = new Dictionary<int, int>();
            initializeComboBox();
        }

        private void initializeComboBox()
        {
            int i = 0;
            foreach (KeyValuePair<int,ImageManipulator> manipulator  in Images)
            {
                Source_ComboBox.Properties.Items.Add(Images[manipulator.Key].ImagePanel.Name);
                Destination_ComboBox.Properties.Items.Add(Images[manipulator.Key].ImagePanel.Name);
                comboManipulatorMap.Add(i, manipulator.Key);
                i++;
            }


            Source_ComboBox.SelectedIndex = 0;
            Destination_ComboBox.SelectedIndex = 0;

            SourcePictureBox.Image = Images[comboManipulatorMap[0]].ImagePanel.Image;
            DestinationPictureBox.Image = Images[comboManipulatorMap[0]].ImagePanel.Image;
            DrawHistogram(Images[comboManipulatorMap[0]].ImagePanel.Image, Histo.SourceHistogram);
            DrawHistogram(Images[comboManipulatorMap[0]].ImagePanel.Image, Histo.DestinationHistogram);
        }

        # region Histogram
        public void DrawHistogram(Bitmap image , Histo Type)
        {
            GatherStatistics(image,Type);
        }
        public void GatherStatistics(Bitmap image, Histo Type)
        {
            // avoid calculation in the case of the same image
            if (image != null)
            {
                if (Type == Histo.SourceHistogram)
                {
                    if (SourceImageHash == image.GetHashCode())
                        return;
                    SourceImageHash = image.GetHashCode();
                }
                else
                {
                    if (DestinationImageHash == image.GetHashCode())
                        return;
                    DestinationImageHash = image.GetHashCode();
                }
            }

            // busy
            Capture = true;
            Cursor = Cursors.WaitCursor;

            // get statistics
            if ( Type == Histo.SourceHistogram)
            Source_stat = (image == null) ? null : new AForge.Imaging.ImageStatistics(image);
            else
            Destination_stat = (image == null) ? null : new AForge.Imaging.ImageStatistics(image);
            // free
            Cursor = Cursors.Arrow;
            Capture = false;

            // clean combo
            Source_Histogram_ComboBox.Properties.Items.Clear();
            Destination_Histogram_ComboBox.Properties.Items.Clear();

            if (Source_stat != null )
            {
                if (!Source_stat.IsGrayscale)
                {
                    // RGB picture
                    Source_Histogram_ComboBox.Properties.Items.AddRange(new object[] { "Red", "Green", "Blue" });
                }
                else
                {
                    // grayscale picture
                    Source_Histogram_ComboBox.Properties.Items.Add("Gray");
                }
                Source_Histogram_ComboBox.SelectedIndex = 0;
                SwitchChannel((Source_stat.IsGrayscale) ? 3 : Source_Histogram_ComboBox.SelectedIndex,Histo.SourceHistogram);
            }
            else
                Source_Histogram.Values = null;

            if (Destination_stat != null)
            {
                if (!Destination_stat.IsGrayscale)
                {
                    // RGB picture
                    Destination_Histogram_ComboBox.Properties.Items.AddRange(new object[] { "Red", "Green", "Blue" });
                }
                else
                {
                    // grayscale picture
                    Destination_Histogram_ComboBox.Properties.Items.Add("Gray");
                }
                Destination_Histogram_ComboBox.SelectedIndex = 0;
                SwitchChannel((Destination_stat.IsGrayscale) ? 3 : Destination_Histogram_ComboBox.SelectedIndex,Histo.DestinationHistogram);
            }
            else
                Source_Histogram.Values = null;
        }
        public void SwitchChannel(int channel,Histo Type)
        {
            if (Type == Histo.SourceHistogram)
            {
                if ((channel >= 0) && (channel <= 2))
                {
                    if (!Source_stat.IsGrayscale)
                    {
                        Source_Histogram.Color = colors[channel];
                        Source_activeHistogram = (channel == 0) ? Source_stat.Red : (channel == 1) ? Source_stat.Green : Source_stat.Blue;
                    }
                }
                else if (channel == 3)
                {
                    if (Source_stat.IsGrayscale)
                    {
                        Source_Histogram.Color = colors[3];
                        Source_activeHistogram = Source_stat.Gray;
                    }
                }

                if (Source_activeHistogram != null)
                {
                    Source_Histogram.Values = Source_activeHistogram.Values;
                }
            }
            else
            {
                if ((channel >= 0) && (channel <= 2))
                {
                    if (!Destination_stat.IsGrayscale)
                    {
                        Destination_Histogram.Color = colors[channel];
                        Destination_activeHistogram = (channel == 0) ? Destination_stat.Red : (channel == 1) ? Destination_stat.Green : Destination_stat.Blue;
                    }
                }
                else if (channel == 3)
                {
                    if (Destination_stat.IsGrayscale)
                    {
                        Destination_Histogram.Color = colors[3];
                        Destination_activeHistogram = Destination_stat.Gray;
                    }
                }

                if (Destination_activeHistogram != null)
                {
                    Destination_Histogram.Values = Destination_activeHistogram.Values;
                }

            }
        }
        private void Source_Histogram_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Source_stat != null)
            {
                SwitchChannel((Source_stat.IsGrayscale) ? 3 : Source_Histogram_ComboBox.SelectedIndex,Histo.SourceHistogram);
            }
        }
        private void Destination_Histogram_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Destination_stat != null)
            {
                SwitchChannel((Destination_stat.IsGrayscale) ? 3 : Destination_Histogram_ComboBox.SelectedIndex,Histo.DestinationHistogram);
            }
        }
        private void Source_Log_check_CheckedChanged(object sender, EventArgs e)
        {
            Source_Histogram.LogView = Source_Log_check.Checked;
        }
        private void Destination_Log_check_CheckedChanged(object sender, EventArgs e)
        {
            Destination_Histogram.LogView = Destination_Log_check.Checked;
        }
        #endregion

        private void Source_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap SelectedImage = Images[comboManipulatorMap[Source_ComboBox.SelectedIndex]].ImagePanel.Image;
            SourcePictureBox.Image = SelectedImage;
            DrawHistogram(SelectedImage, Histo.SourceHistogram);
        }

        private void Destination_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap SelectedImage = Images[comboManipulatorMap[Destination_ComboBox.SelectedIndex]].ImagePanel.Image;
            DestinationPictureBox.Image = SelectedImage;
            DrawHistogram(SelectedImage, Histo.DestinationHistogram);
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            Bitmap sourceImage = Images[comboManipulatorMap[Source_ComboBox.SelectedIndex]].ImagePanel.Image;
            Bitmap destinationImage = Images[comboManipulatorMap[Destination_ComboBox.SelectedIndex]].ImagePanel.Image;

            DestinationPictureBox.Image = HistogramOperations.MatchingThreeColors(
                sourceImage, destinationImage);

            pictureAfterModification =(Bitmap)(DestinationPictureBox.Image);
            OKButtonIsPressed = true;
            this.Close();
        }

    }
}
