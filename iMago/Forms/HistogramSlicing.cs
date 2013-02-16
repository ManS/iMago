using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMago
{
    public partial class HistogramSlicing : DevExpress.XtraEditors.XtraForm
    {
        public Bitmap Image;
        int oldMin ;
        int oldMax ;
        int newMin ;
        int newMax ;
        public bool okButtonISPressed = false;
        public Bitmap imageAfterModification;
        public HistogramSlicing(Bitmap p_Image)
        {
            InitializeComponent();
            Image = p_Image;
            OriginalPictureBox.Image = Image;
        }
        private Bitmap InvokeSlicing()
        {
            try
            {
                oldMin = int.Parse(OldMin_txt.Text);
                oldMax = int.Parse(OldMax_txt.Text);
                newMin = int.Parse(NewMin_txt.Text);
                newMax = int.Parse(NewMax_txt.Text);
                if (oldMin < 0 || oldMin > 255 || oldMax < 0 || oldMax > 255 ||
                    newMin < 0 || newMin > 255 || newMax < 0 || newMax > 255)
                    MessageBox.Show("Data must be between 0 and 255 ");
                else if (oldMin > oldMax)
                    MessageBox.Show("old min must be less than old max ");
                else if (newMin > newMax)
                    MessageBox.Show("new min must be less than new max");
                return ImageStatistics.HistogramOperations.HistogramSlicing((Bitmap)Image, oldMin, oldMax, newMin, newMax);
            }
            catch
            {
                MessageBox.Show("Wrong Data");
                return null;
            }
        }

        private void OldRange_bar_EditValueChanged(object sender, EventArgs e)
        {
            oldMin = OldRange_bar.Value.Minimum;
            OldMin_txt.Text = OldRange_bar.Value.Minimum.ToString();

            oldMax = OldRange_bar.Value.Maximum;
            OldMax_txt.Text = OldRange_bar.Value.Maximum.ToString();
        }

        private void NewRange_bar_EditValueChanged(object sender, EventArgs e)
        {
            newMin = NewRange_bar.Value.Minimum;
            NewMin_txt.Text = NewRange_bar.Value.Minimum.ToString();
            newMax = NewRange_bar.Value.Maximum;
            NewMax_txt.Text = NewRange_bar.Value.Maximum.ToString();
        }

        private void Apply_btn_Click(object sender, EventArgs e)
        {
            ModifiedPictureBox.Image = InvokeSlicing();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            okButtonISPressed = true;
            imageAfterModification = (Bitmap)ModifiedPictureBox.Image;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

