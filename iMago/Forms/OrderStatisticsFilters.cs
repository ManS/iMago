using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Filters.NoiseRemovers;


namespace iMago.Forms
{

    public partial class OrderStatisticsFilters : DevExpress.XtraEditors.XtraForm
    {
        ImageManipulator m_manipulator;
        bool filtered = false;
        public bool manipulated = false;
        public Bitmap modifiedImage;
        public OrderStatisticsFilters(ImageManipulator p_imageManipulator)
        {
            InitializeComponent();
            m_manipulator = p_imageManipulator;
            OriginalPictureBox.Image = m_manipulator.ImagePanel.Image;
            filterstypes_cb.SelectedIndex = 0;
            ModifiedPicturebox.Image = m_manipulator.ImagePanel.Image;
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            int maxK = 0;
            int filtersize = 0;
            int d = 0;
            try
            {
                if (maxk_txt.Enabled)
                {
                    maxK = int.Parse(maxk_txt.Text);
                }

                if (d_txt.Enabled)
                {
                   d = int.Parse(d_txt.Text);
                }
                filtersize = int.Parse(filtersize_txtbox.Text);
            }
            catch
            {
                MessageBox.Show("Invalied data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            OrderStatisticsFiltersTypes filterType = this.GetFilterType();
            IOrderFilter OrderFilter = OrderFiltersFactory.GetOrderFilter(filterType, filtersize, maxK,d);
            ModifiedPicturebox.Image = OrderFilter.RemoveNoise(this.m_manipulator.ImagePanel.Image);
            filtered = true;
        }

        private OrderStatisticsFiltersTypes GetFilterType()
        {
            switch (filterstypes_cb.SelectedIndex)
            {
                case 0:
                    return OrderStatisticsFiltersTypes.Median;
                case 1:
                    return OrderStatisticsFiltersTypes.Minimum;
                case 2:
                    return OrderStatisticsFiltersTypes.Maximum;
                case 3:
                    return OrderStatisticsFiltersTypes.MidPoint;
                case 4:
                    return OrderStatisticsFiltersTypes.AlphaTrim;
                case 5:
                    return OrderStatisticsFiltersTypes.Adaptive;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            modifiedImage = (Bitmap)ModifiedPicturebox.Image;
            manipulated = true;
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            filtered = false;
            this.Close();
        }

        private void OrderStatisticsFilters_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (filtered)
            {
                m_manipulator.ImagePanel.Image = (Bitmap)ModifiedPicturebox.Image;
                m_manipulator.NotifyUpdated("Filtered by Order Statistics filters");
            }
        }

        private void filterstypes_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderStatisticsFiltersTypes filter = this.GetFilterType();
            if (filter != OrderStatisticsFiltersTypes.Adaptive)
            {
                maxk_txt.Enabled = false;
            }
            else
                maxk_txt.Enabled = true;

            if (filter != OrderStatisticsFiltersTypes.AlphaTrim)
            {
                d_txt.Enabled = false;
            }
            else
                d_txt.Enabled = true;
        }
    }
}
