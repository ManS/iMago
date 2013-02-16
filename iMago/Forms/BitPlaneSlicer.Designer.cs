namespace iMago
{
    partial class BitPlaneSlicer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitPlaneSlicer));
            this.OriginalImage_Grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.BinaryImage_Grp = new DevExpress.XtraEditors.GroupControl();
            this.binary_PB = new System.Windows.Forms.PictureBox();
            this.ColoredImage_Grp = new DevExpress.XtraEditors.GroupControl();
            this.manipulatedImage = new System.Windows.Forms.PictureBox();
            this.Quantize_Grp = new DevExpress.XtraEditors.GroupControl();
            this.ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Quantize_slider = new DevExpress.XtraEditors.TrackBarControl();
            this.Depth_txt = new DevExpress.XtraEditors.TextEdit();
            this.planeNum_txt = new DevExpress.XtraEditors.TextEdit();
            this.Depth_lbl = new DevExpress.XtraEditors.LabelControl();
            this.PlaneNumber_lbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage_Grp)).BeginInit();
            this.OriginalImage_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryImage_Grp)).BeginInit();
            this.BinaryImage_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binary_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColoredImage_Grp)).BeginInit();
            this.ColoredImage_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manipulatedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantize_Grp)).BeginInit();
            this.Quantize_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantize_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantize_slider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Depth_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planeNum_txt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginalImage_Grp
            // 
            this.OriginalImage_Grp.Controls.Add(this.OriginalPictureBox);
            this.OriginalImage_Grp.Location = new System.Drawing.Point(9, 8);
            this.OriginalImage_Grp.Name = "OriginalImage_Grp";
            this.OriginalImage_Grp.Size = new System.Drawing.Size(230, 366);
            this.OriginalImage_Grp.TabIndex = 0;
            this.OriginalImage_Grp.Text = "Original Image";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(5, 22);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(221, 339);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // BinaryImage_Grp
            // 
            this.BinaryImage_Grp.Controls.Add(this.binary_PB);
            this.BinaryImage_Grp.Location = new System.Drawing.Point(249, 8);
            this.BinaryImage_Grp.Name = "BinaryImage_Grp";
            this.BinaryImage_Grp.Size = new System.Drawing.Size(230, 366);
            this.BinaryImage_Grp.TabIndex = 1;
            this.BinaryImage_Grp.Text = "Binary Image";
            // 
            // binary_PB
            // 
            this.binary_PB.Location = new System.Drawing.Point(5, 22);
            this.binary_PB.Name = "binary_PB";
            this.binary_PB.Size = new System.Drawing.Size(221, 339);
            this.binary_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.binary_PB.TabIndex = 1;
            this.binary_PB.TabStop = false;
            // 
            // ColoredImage_Grp
            // 
            this.ColoredImage_Grp.Controls.Add(this.manipulatedImage);
            this.ColoredImage_Grp.Location = new System.Drawing.Point(489, 8);
            this.ColoredImage_Grp.Name = "ColoredImage_Grp";
            this.ColoredImage_Grp.Size = new System.Drawing.Size(230, 366);
            this.ColoredImage_Grp.TabIndex = 1;
            this.ColoredImage_Grp.Text = "Colored Image";
            // 
            // manipulatedImage
            // 
            this.manipulatedImage.Location = new System.Drawing.Point(5, 22);
            this.manipulatedImage.Name = "manipulatedImage";
            this.manipulatedImage.Size = new System.Drawing.Size(221, 339);
            this.manipulatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.manipulatedImage.TabIndex = 2;
            this.manipulatedImage.TabStop = false;
            // 
            // Quantize_Grp
            // 
            this.Quantize_Grp.Controls.Add(this.ok_btn);
            this.Quantize_Grp.Controls.Add(this.cancel_btn);
            this.Quantize_Grp.Controls.Add(this.apply_btn);
            this.Quantize_Grp.Controls.Add(this.Quantize_slider);
            this.Quantize_Grp.Controls.Add(this.Depth_txt);
            this.Quantize_Grp.Controls.Add(this.planeNum_txt);
            this.Quantize_Grp.Controls.Add(this.Depth_lbl);
            this.Quantize_Grp.Controls.Add(this.PlaneNumber_lbl);
            this.Quantize_Grp.Location = new System.Drawing.Point(9, 392);
            this.Quantize_Grp.Name = "Quantize_Grp";
            this.Quantize_Grp.Size = new System.Drawing.Size(710, 118);
            this.Quantize_Grp.TabIndex = 2;
            this.Quantize_Grp.Text = "Quantize";
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(619, 55);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 7;
            this.ok_btn.Text = "OK";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(619, 84);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "Cancel";
            // 
            // apply_btn
            // 
            this.apply_btn.Location = new System.Drawing.Point(619, 26);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(75, 23);
            this.apply_btn.TabIndex = 5;
            this.apply_btn.Text = "Apply";
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // Quantize_slider
            // 
            this.Quantize_slider.EditValue = null;
            this.Quantize_slider.Location = new System.Drawing.Point(5, 68);
            this.Quantize_slider.Name = "Quantize_slider";
            this.Quantize_slider.Size = new System.Drawing.Size(318, 45);
            this.Quantize_slider.TabIndex = 4;
            // 
            // Depth_txt
            // 
            this.Depth_txt.Location = new System.Drawing.Point(196, 33);
            this.Depth_txt.Name = "Depth_txt";
            this.Depth_txt.Size = new System.Drawing.Size(55, 19);
            this.Depth_txt.TabIndex = 3;
            // 
            // planeNum_txt
            // 
            this.planeNum_txt.Location = new System.Drawing.Point(83, 33);
            this.planeNum_txt.Name = "planeNum_txt";
            this.planeNum_txt.Size = new System.Drawing.Size(47, 19);
            this.planeNum_txt.TabIndex = 2;
            // 
            // Depth_lbl
            // 
            this.Depth_lbl.Location = new System.Drawing.Point(157, 36);
            this.Depth_lbl.Name = "Depth_lbl";
            this.Depth_lbl.Size = new System.Drawing.Size(33, 13);
            this.Depth_lbl.TabIndex = 1;
            this.Depth_lbl.Text = "Depth:";
            // 
            // PlaneNumber_lbl
            // 
            this.PlaneNumber_lbl.Location = new System.Drawing.Point(8, 36);
            this.PlaneNumber_lbl.Name = "PlaneNumber_lbl";
            this.PlaneNumber_lbl.Size = new System.Drawing.Size(69, 13);
            this.PlaneNumber_lbl.TabIndex = 0;
            this.PlaneNumber_lbl.Text = "Plane number:";
            // 
            // BitPlaneSlicer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 522);
            this.Controls.Add(this.Quantize_Grp);
            this.Controls.Add(this.ColoredImage_Grp);
            this.Controls.Add(this.BinaryImage_Grp);
            this.Controls.Add(this.OriginalImage_Grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BitPlaneSlicer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BitPlane Slicer";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage_Grp)).EndInit();
            this.OriginalImage_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryImage_Grp)).EndInit();
            this.BinaryImage_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binary_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColoredImage_Grp)).EndInit();
            this.ColoredImage_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manipulatedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantize_Grp)).EndInit();
            this.Quantize_Grp.ResumeLayout(false);
            this.Quantize_Grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantize_slider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantize_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Depth_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planeNum_txt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl OriginalImage_Grp;
        private DevExpress.XtraEditors.GroupControl BinaryImage_Grp;
        private DevExpress.XtraEditors.GroupControl ColoredImage_Grp;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private System.Windows.Forms.PictureBox binary_PB;
        private System.Windows.Forms.PictureBox manipulatedImage;
        private DevExpress.XtraEditors.GroupControl Quantize_Grp;
        private DevExpress.XtraEditors.TrackBarControl Quantize_slider;
        private DevExpress.XtraEditors.TextEdit Depth_txt;
        private DevExpress.XtraEditors.TextEdit planeNum_txt;
        private DevExpress.XtraEditors.LabelControl Depth_lbl;
        private DevExpress.XtraEditors.LabelControl PlaneNumber_lbl;
        private DevExpress.XtraEditors.SimpleButton apply_btn;
        private DevExpress.XtraEditors.SimpleButton ok_btn;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
    }
}