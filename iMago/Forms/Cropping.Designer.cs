namespace iMago
{
    partial class Cropping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cropping));
            this.Original_image = new System.Windows.Forms.PictureBox();
            this.Clipped_image = new System.Windows.Forms.PictureBox();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Original_grp = new DevExpress.XtraEditors.GroupControl();
            this.Clipped_grp = new DevExpress.XtraEditors.GroupControl();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.histogram = new DevExpress.XtraEditors.GroupControl();
            this.Source_Log_check = new DevExpress.XtraEditors.CheckEdit();
            this.histogram_cropped = new iMago.Histogram();
            this.histogram_cropped_ComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clipped_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).BeginInit();
            this.Original_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clipped_grp)).BeginInit();
            this.Clipped_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            this.histogram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Source_Log_check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram_cropped_ComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Original_image
            // 
            this.Original_image.Location = new System.Drawing.Point(9, 28);
            this.Original_image.Name = "Original_image";
            this.Original_image.Size = new System.Drawing.Size(311, 277);
            this.Original_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Original_image.TabIndex = 0;
            this.Original_image.TabStop = false;
            this.Original_image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Original_image_MouseDown);
            this.Original_image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Original_image_MouseMove);
            this.Original_image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Original_image_MouseUp);
            // 
            // Clipped_image
            // 
            this.Clipped_image.Location = new System.Drawing.Point(11, 28);
            this.Clipped_image.Name = "Clipped_image";
            this.Clipped_image.Size = new System.Drawing.Size(311, 277);
            this.Clipped_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Clipped_image.TabIndex = 1;
            this.Clipped_image.TabStop = false;
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(813, 329);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(100, 29);
            this.Cancel_btn.TabIndex = 3;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Original_grp
            // 
            this.Original_grp.Controls.Add(this.Original_image);
            this.Original_grp.Location = new System.Drawing.Point(7, 6);
            this.Original_grp.Name = "Original_grp";
            this.Original_grp.Size = new System.Drawing.Size(331, 316);
            this.Original_grp.TabIndex = 4;
            this.Original_grp.Text = "Original Image";
            // 
            // Clipped_grp
            // 
            this.Clipped_grp.Controls.Add(this.Clipped_image);
            this.Clipped_grp.Location = new System.Drawing.Point(344, 6);
            this.Clipped_grp.Name = "Clipped_grp";
            this.Clipped_grp.Size = new System.Drawing.Size(331, 316);
            this.Clipped_grp.TabIndex = 5;
            this.Clipped_grp.Text = "Clipped Image";
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(707, 329);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(100, 29);
            this.Ok_btn.TabIndex = 6;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // histogram
            // 
            this.histogram.Controls.Add(this.Source_Log_check);
            this.histogram.Controls.Add(this.histogram_cropped);
            this.histogram.Controls.Add(this.histogram_cropped_ComboBox);
            this.histogram.Location = new System.Drawing.Point(681, 6);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(234, 316);
            this.histogram.TabIndex = 6;
            this.histogram.Text = "Histogram";
            // 
            // Source_Log_check
            // 
            this.Source_Log_check.Location = new System.Drawing.Point(185, 190);
            this.Source_Log_check.Name = "Source_Log_check";
            this.Source_Log_check.Properties.Caption = "Log";
            this.Source_Log_check.Size = new System.Drawing.Size(42, 19);
            this.Source_Log_check.TabIndex = 8;
            this.Source_Log_check.CheckedChanged += new System.EventHandler(this.Source_Log_check_CheckedChanged);
            // 
            // histogram_cropped
            // 
            this.histogram_cropped.HistogramWidth = 222;
            this.histogram_cropped.Location = new System.Drawing.Point(3, 28);
            this.histogram_cropped.Name = "histogram_cropped";
            this.histogram_cropped.Size = new System.Drawing.Size(229, 157);
            this.histogram_cropped.TabIndex = 0;
            this.histogram_cropped.Text = "histogram_cropped";
            // 
            // histogram_cropped_ComboBox
            // 
            this.histogram_cropped_ComboBox.Location = new System.Drawing.Point(5, 189);
            this.histogram_cropped_ComboBox.Name = "histogram_cropped_ComboBox";
            this.histogram_cropped_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.histogram_cropped_ComboBox.Properties.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Gray"});
            this.histogram_cropped_ComboBox.Size = new System.Drawing.Size(169, 19);
            this.histogram_cropped_ComboBox.TabIndex = 7;
            this.histogram_cropped_ComboBox.SelectedIndexChanged += new System.EventHandler(this.histogram_cropped_ComboBox_SelectedIndexChanged);
            // 
            // Cropping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 370);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Original_grp);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Clipped_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Cropping";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cropping";
            ((System.ComponentModel.ISupportInitialize)(this.Original_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Clipped_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).EndInit();
            this.Original_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Clipped_grp)).EndInit();
            this.Clipped_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).EndInit();
            this.histogram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Source_Log_check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram_cropped_ComboBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Original_image;
        private System.Windows.Forms.PictureBox Clipped_image;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private DevExpress.XtraEditors.GroupControl Original_grp;
        private DevExpress.XtraEditors.GroupControl Clipped_grp;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.GroupControl histogram;
        private Histogram histogram_cropped;
        private DevExpress.XtraEditors.CheckEdit Source_Log_check;
        private DevExpress.XtraEditors.ComboBoxEdit histogram_cropped_ComboBox;
    }
}