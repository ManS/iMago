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
    public partial class Curves : DevExpress.XtraEditors.XtraForm
    {
        Channel channel;
        public Bitmap srcBmp, distBmp;
        public bool modified = false;
        public Curves()
        {
            InitializeComponent();
        }
        public Bitmap Image 
        {
            get { return srcBmp; }
            set { srcBmp = value; Image_Panel.Image = srcBmp;}
            
        }
        private void Image_Curve_LevelChangedEvent(object sender, LevelChangedEventArgs e)
        {
            if (Channel_ComboBox.SelectedItem == Channel_ComboBox.Properties.Items[0])
            {
                distBmp = ImageCurve.ChangeChannelLevel(srcBmp, Image_Panel.SelectedArea, Channel.All, e.LevelValue);
            }
            else if (Channel_ComboBox.SelectedItem == Channel_ComboBox.Properties.Items[1])
            {
                distBmp = ImageCurve.ChangeChannelLevel(srcBmp, Image_Panel.SelectedArea, Channel.Red, e.LevelValue);
            }
            else if (Channel_ComboBox.SelectedItem == Channel_ComboBox.Properties.Items[2])
            {
                distBmp = ImageCurve.ChangeChannelLevel(srcBmp, Image_Panel.SelectedArea, Channel.Green, e.LevelValue);
            }
            else if (Channel_ComboBox.SelectedItem == Channel_ComboBox.Properties.Items[3])
            {
                distBmp = ImageCurve.ChangeChannelLevel(srcBmp, Image_Panel.SelectedArea, Channel.Blue, e.LevelValue);
            }
            else
            {
                distBmp = ImageCurve.ChangeChannelLevel(srcBmp, Image_Panel.SelectedArea, Channel.All, e.LevelValue);
            }
            Image_Panel.Image = distBmp;
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            modified = true;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }

}
