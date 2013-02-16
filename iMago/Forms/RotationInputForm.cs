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
    public partial class RotationInputForm : DevExpress.XtraEditors.XtraForm
    {
        ImageManipulator m_manipulator;
        bool rotated = false;
        float initialAngle = 0f;
        public RotationInputForm(ImageManipulator p_manipulator)
        {
            InitializeComponent();
            m_manipulator = p_manipulator;
            initialAngle = p_manipulator.Image.RotatedBy;
        }

        private void Angle_Selector_AngleChanged()
        {
            Angle_TxtBox.Text = Angle_Selector.Angle.ToString();
        }

        private void Angle_TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }

        private void Angle_TxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Angle_TxtBox.Text != string.Empty)
                Angle_Selector.Angle = int.Parse(Angle_TxtBox.Text);
        }

        private void Rotate_btn_Click(object sender, EventArgs e)
        {
            rotated = true;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RotationInputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (rotated)
            {
                float rotationAngle = float.Parse(Angle_TxtBox.Text);
                if (!preview.Checked)
                {
                    this.m_manipulator.ImagePanel.Image = ImageManipulation.ImageOperation.ImageRotate(this.m_manipulator.Image.BitmapImage, -rotationAngle);
                }
                this.m_manipulator.NotifyUpdated("Rotate by " + rotationAngle.ToString()+" "+((char)176));
                //float rotationAngle = float.Parse(Angle_TxtBox.Text) * -1;
                //this.m_manipulator.ImagePanel.Image = ImageManipulation.ImageOperation.ImageRotate(this.m_manipulator.ImagePanel.Image, (float)rotationAngle);
                //this.m_manipulator.NotifyUpdated("Rotate");
            }
            else
            {
                this.m_manipulator.ImagePanel.Image = this.m_manipulator.Image.BitmapImage;
            }
        }

        private void Angle_Selector_MouseUp(object sender, MouseEventArgs e)
        {
            if (preview.Checked)
            {
                float rotationAngle = float.Parse(Angle_TxtBox.Text)*-1;

                //this.m_manipulator.Image.RotatedBy += rotationAngle % 360; // += RotationForm.RotateAngle % 360;
                this.m_manipulator.ImagePanel.Image = ImageManipulation.ImageOperation.ImageRotate(this.m_manipulator.Image.BitmapImage, rotationAngle);
            }
        }
    }
}
