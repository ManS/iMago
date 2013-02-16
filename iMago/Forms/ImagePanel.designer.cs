namespace iMago
{
    partial class ImagePanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hScrollBar = new DevExpress.XtraEditors.HScrollBar();
            this.vScrollBar = new DevExpress.XtraEditors.VScrollBar();
            this.labelCover = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hScrollBar
            // 
            this.hScrollBar.Location = new System.Drawing.Point(38, 42);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(109, 19);
            this.hScrollBar.TabIndex = 1;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Location = new System.Drawing.Point(10, 46);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(22, 103);
            this.vScrollBar.TabIndex = 2;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll_1);
            // 
            // labelCover
            // 
            this.labelCover.Location = new System.Drawing.Point(65, 42);
            this.labelCover.Name = "labelCover";
            this.labelCover.Size = new System.Drawing.Size(100, 23);
            this.labelCover.TabIndex = 0;
            // 
            // ImagePanel
            // 
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.labelCover);
            this.Name = "ImagePanel";
            this.Size = new System.Drawing.Size(174, 167);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImagePanel_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImagePanel_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImagePanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImagePanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImagePanel_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HScrollBar hScrollBar;
        private DevExpress.XtraEditors.VScrollBar vScrollBar;
        private System.Windows.Forms.Label labelCover;

    }
}
