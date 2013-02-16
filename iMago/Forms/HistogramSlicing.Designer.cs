namespace iMago
{
    partial class HistogramSlicing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramSlicing));
            this.Original_grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.Modified_grp = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.Old_grp = new DevExpress.XtraEditors.GroupControl();
            this.OldMin_txt = new DevExpress.XtraEditors.TextEdit();
            this.OldMax_txt = new DevExpress.XtraEditors.TextEdit();
            this.OldMax_lbl = new DevExpress.XtraEditors.LabelControl();
            this.OldMin_lbl = new DevExpress.XtraEditors.LabelControl();
            this.OldRange_bar = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.New_grp = new DevExpress.XtraEditors.GroupControl();
            this.NewMin_txt = new DevExpress.XtraEditors.TextEdit();
            this.NewMax_txt = new DevExpress.XtraEditors.TextEdit();
            this.NewRange_bar = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.NewMax_lbl = new DevExpress.XtraEditors.LabelControl();
            this.NewMin_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).BeginInit();
            this.Original_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).BeginInit();
            this.Modified_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Old_grp)).BeginInit();
            this.Old_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OldMin_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldMax_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldRange_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldRange_bar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.New_grp)).BeginInit();
            this.New_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewMin_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewMax_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewRange_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewRange_bar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Original_grp
            // 
            this.Original_grp.Controls.Add(this.OriginalPictureBox);
            this.Original_grp.Location = new System.Drawing.Point(7, 12);
            this.Original_grp.Name = "Original_grp";
            this.Original_grp.Size = new System.Drawing.Size(329, 278);
            this.Original_grp.TabIndex = 0;
            this.Original_grp.Text = "Original";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(9, 28);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(311, 238);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // Modified_grp
            // 
            this.Modified_grp.Controls.Add(this.ModifiedPictureBox);
            this.Modified_grp.Location = new System.Drawing.Point(345, 12);
            this.Modified_grp.Name = "Modified_grp";
            this.Modified_grp.Size = new System.Drawing.Size(329, 278);
            this.Modified_grp.TabIndex = 1;
            this.Modified_grp.Text = "Modified";
            // 
            // ModifiedPictureBox
            // 
            this.ModifiedPictureBox.Location = new System.Drawing.Point(9, 28);
            this.ModifiedPictureBox.Name = "ModifiedPictureBox";
            this.ModifiedPictureBox.Size = new System.Drawing.Size(311, 238);
            this.ModifiedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ModifiedPictureBox.TabIndex = 1;
            this.ModifiedPictureBox.TabStop = false;
            // 
            // Old_grp
            // 
            this.Old_grp.Controls.Add(this.OldMin_txt);
            this.Old_grp.Controls.Add(this.OldMax_txt);
            this.Old_grp.Controls.Add(this.OldMax_lbl);
            this.Old_grp.Controls.Add(this.OldMin_lbl);
            this.Old_grp.Controls.Add(this.OldRange_bar);
            this.Old_grp.Location = new System.Drawing.Point(8, 297);
            this.Old_grp.Name = "Old_grp";
            this.Old_grp.Size = new System.Drawing.Size(327, 125);
            this.Old_grp.TabIndex = 2;
            this.Old_grp.Text = "Old Range";
            // 
            // OldMin_txt
            // 
            this.OldMin_txt.Location = new System.Drawing.Point(76, 90);
            this.OldMin_txt.Name = "OldMin_txt";
            this.OldMin_txt.Size = new System.Drawing.Size(61, 19);
            this.OldMin_txt.TabIndex = 4;
            // 
            // OldMax_txt
            // 
            this.OldMax_txt.Location = new System.Drawing.Point(189, 90);
            this.OldMax_txt.Name = "OldMax_txt";
            this.OldMax_txt.Size = new System.Drawing.Size(61, 19);
            this.OldMax_txt.TabIndex = 3;
            // 
            // OldMax_lbl
            // 
            this.OldMax_lbl.Location = new System.Drawing.Point(164, 93);
            this.OldMax_lbl.Name = "OldMax_lbl";
            this.OldMax_lbl.Size = new System.Drawing.Size(20, 13);
            this.OldMax_lbl.TabIndex = 2;
            this.OldMax_lbl.Text = "Max";
            // 
            // OldMin_lbl
            // 
            this.OldMin_lbl.Location = new System.Drawing.Point(55, 93);
            this.OldMin_lbl.Name = "OldMin_lbl";
            this.OldMin_lbl.Size = new System.Drawing.Size(16, 13);
            this.OldMin_lbl.TabIndex = 1;
            this.OldMin_lbl.Text = "Min";
            // 
            // OldRange_bar
            // 
            this.OldRange_bar.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(0, 0);
            this.OldRange_bar.Location = new System.Drawing.Point(18, 39);
            this.OldRange_bar.Name = "OldRange_bar";
            this.OldRange_bar.Properties.Maximum = 255;
            this.OldRange_bar.Properties.TickFrequency = 5;
            this.OldRange_bar.Size = new System.Drawing.Size(289, 45);
            this.OldRange_bar.TabIndex = 0;
            this.OldRange_bar.EditValueChanged += new System.EventHandler(this.OldRange_bar_EditValueChanged);
            // 
            // New_grp
            // 
            this.New_grp.Controls.Add(this.NewMin_txt);
            this.New_grp.Controls.Add(this.NewMax_txt);
            this.New_grp.Controls.Add(this.NewRange_bar);
            this.New_grp.Controls.Add(this.NewMax_lbl);
            this.New_grp.Controls.Add(this.NewMin_lbl);
            this.New_grp.Location = new System.Drawing.Point(345, 297);
            this.New_grp.Name = "New_grp";
            this.New_grp.Size = new System.Drawing.Size(327, 125);
            this.New_grp.TabIndex = 3;
            this.New_grp.Text = "New Range";
            // 
            // NewMin_txt
            // 
            this.NewMin_txt.Location = new System.Drawing.Point(81, 90);
            this.NewMin_txt.Name = "NewMin_txt";
            this.NewMin_txt.Size = new System.Drawing.Size(61, 19);
            this.NewMin_txt.TabIndex = 8;
            // 
            // NewMax_txt
            // 
            this.NewMax_txt.Location = new System.Drawing.Point(194, 90);
            this.NewMax_txt.Name = "NewMax_txt";
            this.NewMax_txt.Size = new System.Drawing.Size(61, 19);
            this.NewMax_txt.TabIndex = 7;
            // 
            // NewRange_bar
            // 
            this.NewRange_bar.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(0, 0);
            this.NewRange_bar.Location = new System.Drawing.Point(17, 39);
            this.NewRange_bar.Name = "NewRange_bar";
            this.NewRange_bar.Properties.Maximum = 255;
            this.NewRange_bar.Properties.TickFrequency = 5;
            this.NewRange_bar.Size = new System.Drawing.Size(289, 45);
            this.NewRange_bar.TabIndex = 1;
            this.NewRange_bar.EditValueChanged += new System.EventHandler(this.NewRange_bar_EditValueChanged);
            // 
            // NewMax_lbl
            // 
            this.NewMax_lbl.Location = new System.Drawing.Point(169, 93);
            this.NewMax_lbl.Name = "NewMax_lbl";
            this.NewMax_lbl.Size = new System.Drawing.Size(20, 13);
            this.NewMax_lbl.TabIndex = 6;
            this.NewMax_lbl.Text = "Max";
            // 
            // NewMin_lbl
            // 
            this.NewMin_lbl.Location = new System.Drawing.Point(60, 93);
            this.NewMin_lbl.Name = "NewMin_lbl";
            this.NewMin_lbl.Size = new System.Drawing.Size(16, 13);
            this.NewMin_lbl.TabIndex = 5;
            this.NewMin_lbl.Text = "Min";
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(414, 442);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(82, 31);
            this.Apply_btn.TabIndex = 4;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(502, 442);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(82, 31);
            this.Ok_btn.TabIndex = 5;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(590, 442);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(82, 31);
            this.Cancel_btn.TabIndex = 6;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // HistogramSlicing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 485);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.New_grp);
            this.Controls.Add(this.Old_grp);
            this.Controls.Add(this.Modified_grp);
            this.Controls.Add(this.Original_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HistogramSlicing";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histogram Slicing";
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).EndInit();
            this.Original_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).EndInit();
            this.Modified_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Old_grp)).EndInit();
            this.Old_grp.ResumeLayout(false);
            this.Old_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OldMin_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldMax_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldRange_bar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldRange_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.New_grp)).EndInit();
            this.New_grp.ResumeLayout(false);
            this.New_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewMin_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewMax_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewRange_bar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewRange_bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Original_grp;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private DevExpress.XtraEditors.GroupControl Modified_grp;
        private System.Windows.Forms.PictureBox ModifiedPictureBox;
        private DevExpress.XtraEditors.GroupControl Old_grp;
        private DevExpress.XtraEditors.GroupControl New_grp;
        private DevExpress.XtraEditors.RangeTrackBarControl OldRange_bar;
        private DevExpress.XtraEditors.RangeTrackBarControl NewRange_bar;
        private DevExpress.XtraEditors.TextEdit OldMin_txt;
        private DevExpress.XtraEditors.TextEdit OldMax_txt;
        private DevExpress.XtraEditors.LabelControl OldMax_lbl;
        private DevExpress.XtraEditors.LabelControl OldMin_lbl;
        private DevExpress.XtraEditors.TextEdit NewMin_txt;
        private DevExpress.XtraEditors.TextEdit NewMax_txt;
        private DevExpress.XtraEditors.LabelControl NewMax_lbl;
        private DevExpress.XtraEditors.LabelControl NewMin_lbl;
        private DevExpress.XtraEditors.SimpleButton Apply_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
    }
}