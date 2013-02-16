namespace iMago.Forms
{
    partial class OrderStatisticsFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderStatisticsFilters));
            this.apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Original_Grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedPicturebox = new System.Windows.Forms.PictureBox();
            this.filterstypes_cb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.filtersize_txtbox = new DevExpress.XtraEditors.TextEdit();
            this.maxk_lbl = new DevExpress.XtraEditors.LabelControl();
            this.maxk_txt = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.d_txt = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_Grp)).BeginInit();
            this.Original_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterstypes_cb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtersize_txtbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxk_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_txt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // apply_btn
            // 
            this.apply_btn.Location = new System.Drawing.Point(639, 322);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(75, 41);
            this.apply_btn.TabIndex = 1;
            this.apply_btn.Text = "Apply";
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // Original_Grp
            // 
            this.Original_Grp.Controls.Add(this.OriginalPictureBox);
            this.Original_Grp.Location = new System.Drawing.Point(12, 12);
            this.Original_Grp.Name = "Original_Grp";
            this.Original_Grp.Size = new System.Drawing.Size(345, 304);
            this.Original_Grp.TabIndex = 2;
            this.Original_Grp.Text = "Original Image";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(6, 24);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(333, 275);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ModifiedPicturebox);
            this.groupControl1.Location = new System.Drawing.Point(369, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(345, 304);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Filtered Image";
            // 
            // ModifiedPicturebox
            // 
            this.ModifiedPicturebox.Location = new System.Drawing.Point(6, 24);
            this.ModifiedPicturebox.Name = "ModifiedPicturebox";
            this.ModifiedPicturebox.Size = new System.Drawing.Size(333, 275);
            this.ModifiedPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ModifiedPicturebox.TabIndex = 0;
            this.ModifiedPicturebox.TabStop = false;
            // 
            // filterstypes_cb
            // 
            this.filterstypes_cb.Location = new System.Drawing.Point(145, 337);
            this.filterstypes_cb.Name = "filterstypes_cb";
            this.filterstypes_cb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.filterstypes_cb.Properties.Items.AddRange(new object[] {
            "Median",
            "Minimum",
            "Maximum",
            "MidPoint",
            "AlphaTrim",
            "Adaptive"});
            this.filterstypes_cb.Size = new System.Drawing.Size(100, 19);
            this.filterstypes_cb.TabIndex = 5;
            this.filterstypes_cb.SelectedIndexChanged += new System.EventHandler(this.filterstypes_cb_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 340);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Filter Type:";
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(639, 369);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 41);
            this.ok_btn.TabIndex = 0;
            this.ok_btn.Text = "OK";
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(640, 416);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 41);
            this.cancel_btn.TabIndex = 7;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 369);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Filter Size:";
            // 
            // filtersize_txtbox
            // 
            this.filtersize_txtbox.Location = new System.Drawing.Point(145, 366);
            this.filtersize_txtbox.Name = "filtersize_txtbox";
            this.filtersize_txtbox.Size = new System.Drawing.Size(100, 19);
            this.filtersize_txtbox.TabIndex = 9;
            // 
            // maxk_lbl
            // 
            this.maxk_lbl.Location = new System.Drawing.Point(18, 397);
            this.maxk_lbl.Name = "maxk_lbl";
            this.maxk_lbl.Size = new System.Drawing.Size(104, 13);
            this.maxk_lbl.TabIndex = 10;
            this.maxk_lbl.Text = "MaxK (for Adaptive): ";
            // 
            // maxk_txt
            // 
            this.maxk_txt.Location = new System.Drawing.Point(145, 394);
            this.maxk_txt.Name = "maxk_txt";
            this.maxk_txt.Size = new System.Drawing.Size(100, 19);
            this.maxk_txt.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 423);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "D (for AlphaTrim):";
            // 
            // d_txt
            // 
            this.d_txt.Location = new System.Drawing.Point(145, 420);
            this.d_txt.Name = "d_txt";
            this.d_txt.Size = new System.Drawing.Size(100, 19);
            this.d_txt.TabIndex = 13;
            // 
            // OrderStatisticsFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 461);
            this.Controls.Add(this.d_txt);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.maxk_txt);
            this.Controls.Add(this.maxk_lbl);
            this.Controls.Add(this.filtersize_txtbox);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.filterstypes_cb);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.Original_Grp);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.ok_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderStatisticsFilters";
            this.Text = "OrderStatisticsFilters";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderStatisticsFilters_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Original_Grp)).EndInit();
            this.Original_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterstypes_cb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtersize_txtbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxk_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_txt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton apply_btn;
        private DevExpress.XtraEditors.GroupControl Original_Grp;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox ModifiedPicturebox;
        private DevExpress.XtraEditors.ComboBoxEdit filterstypes_cb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton ok_btn;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit filtersize_txtbox;
        private DevExpress.XtraEditors.LabelControl maxk_lbl;
        private DevExpress.XtraEditors.TextEdit maxk_txt;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit d_txt;

    }
}