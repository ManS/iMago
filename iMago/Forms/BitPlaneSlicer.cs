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
    public partial class BitPlaneSlicer : DevExpress.XtraEditors.XtraForm
    {
        ImageManipulator m_manipulator;
        public BitPlaneSlicer(ImageManipulator p_manipulator)
        {
            InitializeComponent();
            m_manipulator = p_manipulator;
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
