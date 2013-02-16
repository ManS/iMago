using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMago.Forms
{
    public partial class Translation : DevExpress.XtraEditors.XtraForm
    {
        bool translated = false;
        ImageManipulator m_manipulator;


        public Translation(ImageManipulator p_manipulator)
        {
            InitializeComponent();
            m_manipulator = p_manipulator;

        }

        private void translate_btn_Click_1(object sender, EventArgs e)
        {
            translated = true;
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Translation_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (translated)
            {
                try
                {
                    int xfactor = int.Parse(xfactor_txtbox.Text);
                    int yfactor = int.Parse(yfactor_txtbox.Text);
                    this.m_manipulator.ImagePanel.Image = ImageManipulation.ImageOperation.Translate(this.m_manipulator.ImagePanel.Image, xfactor, yfactor);
                    this.m_manipulator.NotifyUpdated("Translate");
                }
                catch 
                {
                    MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }
            }
        }
    }
}
