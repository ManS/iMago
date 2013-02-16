using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace iMago.Forms
{
    public partial class FilterForm : DevExpress.XtraEditors.XtraForm
    {
        public bool IsPressed = false;
        public int filterSize;
        public PaddingType Padding;
        bool type = false;
        
        public FilterForm(bool p_formType)
        {
            InitializeComponent();
            type = p_formType;
            paddingType_cb.SelectedIndex = 0;
            if (!type)
            {
                paddingType_cb.Hide();
                paddingtype_lbl.Hide();
            }
        }
      
        private void ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                filterSize = int.Parse(filtersize_txtbox.Text);
                if (type)
                {
                    Padding = this.GetPaddingType();
                }
                IsPressed = true;
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Invalid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            IsPressed = true;
        }

        private PaddingType GetPaddingType()
        {
            if (this.paddingType_cb.SelectedIndex == 0)
            {
                return PaddingType.Replication;
            }
            else
            {
                return PaddingType.Zeros;
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            IsPressed = false;
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
