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
    public enum TypeOfNoise { SaltAndPepper, UniformNoise, GammaNoise, RayleighNoise };
    public partial class AddNoise : DevExpress.XtraEditors.XtraForm
    {
        public bool IsPressed = false;
        public double A;
        public double B;
        public double percentage;
        TypeOfNoise typeOfNoise;
        public AddNoise(TypeOfNoise typeOfNoise)
        {
            InitializeComponent();      this.typeOfNoise = typeOfNoise;
            InitializeForm();
      
        }

        private void InitializeForm()
        {
            if (typeOfNoise == TypeOfNoise.SaltAndPepper)
            {
                Nois_lbl.Visible = false;
                Nois_txt.Visible = false;
                Pr_lvl.Visible = false;
                label1.Text = "[Probability]";
                label2.Text = "[Probability]";
            }
            else if (typeOfNoise == TypeOfNoise.UniformNoise)
            {
                Nois_lbl.Visible = true;
                Nois_txt.Visible = true;
                Pr_lvl.Visible = true;
                label1.Text = "[0-255]";
                label2.Text = "[0-255]";

            }
            else if (typeOfNoise == TypeOfNoise.GammaNoise)
            {
                Nois_lbl.Visible = true;
                Nois_txt.Visible = true;
                Pr_lvl.Visible = true;
                label1.Text = ">0";
                label2.Text = "+ve integer";
            }
            else if (typeOfNoise == TypeOfNoise.RayleighNoise)
            {
                Nois_lbl.Visible = true;
                Nois_txt.Visible = true;
                Pr_lvl.Visible = false;
                label1.Text = "";
                label2.Text = "";
            }

        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                A = double.Parse(A_txt.Text);
                B = double.Parse(b_txt.Text);
                if (Nois_txt.Text.Trim() != string.Empty)
                {
                    percentage = double.Parse(Nois_txt.Text);
                }
                else
                    percentage = 0;
                IsPressed = true;
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            

        }
    }
}
