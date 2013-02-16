namespace iMago
{
    partial class BrightnessContrast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrightnessContrast));
            this.Original_Grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.Modified_Grp = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.Brightness_Grp = new DevExpress.XtraEditors.GroupControl();
            this.BrightnessNumericUpDown = new DevExpress.XtraEditors.SpinEdit();
            this.BrightnessTrackBar = new DevExpress.XtraEditors.TrackBarControl();
            this.Contrast_Grp = new DevExpress.XtraEditors.GroupControl();
            this.ContrastNumericUpDown = new DevExpress.XtraEditors.SpinEdit();
            this.ContrastTrackBar = new DevExpress.XtraEditors.TrackBarControl();
            this.Apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.Preview_check = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_Grp)).BeginInit();
            this.Original_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Grp)).BeginInit();
            this.Modified_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness_Grp)).BeginInit();
            this.Brightness_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessNumericUpDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast_Grp)).BeginInit();
            this.Contrast_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastNumericUpDown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_check.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Original_Grp
            // 
            this.Original_Grp.Controls.Add(this.OriginalPictureBox);
            this.Original_Grp.Location = new System.Drawing.Point(7, 6);
            this.Original_Grp.Name = "Original_Grp";
            this.Original_Grp.Size = new System.Drawing.Size(345, 304);
            this.Original_Grp.TabIndex = 0;
            this.Original_Grp.Text = "Original Image";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(6, 24);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(333, 275);
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // Modified_Grp
            // 
            this.Modified_Grp.Controls.Add(this.ModifiedPictureBox);
            this.Modified_Grp.Location = new System.Drawing.Point(364, 6);
            this.Modified_Grp.Name = "Modified_Grp";
            this.Modified_Grp.Size = new System.Drawing.Size(345, 304);
            this.Modified_Grp.TabIndex = 1;
            this.Modified_Grp.Text = "Modified Image";
            // 
            // ModifiedPictureBox
            // 
            this.ModifiedPictureBox.Location = new System.Drawing.Point(7, 24);
            this.ModifiedPictureBox.Name = "ModifiedPictureBox";
            this.ModifiedPictureBox.Size = new System.Drawing.Size(333, 275);
            this.ModifiedPictureBox.TabIndex = 1;
            this.ModifiedPictureBox.TabStop = false;
            // 
            // Brightness_Grp
            // 
            this.Brightness_Grp.Controls.Add(this.BrightnessNumericUpDown);
            this.Brightness_Grp.Controls.Add(this.BrightnessTrackBar);
            this.Brightness_Grp.Location = new System.Drawing.Point(7, 317);
            this.Brightness_Grp.Name = "Brightness_Grp";
            this.Brightness_Grp.Size = new System.Drawing.Size(405, 88);
            this.Brightness_Grp.TabIndex = 2;
            this.Brightness_Grp.Text = "Brightness";
            // 
            // BrightnessNumericUpDown
            // 
            this.BrightnessNumericUpDown.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BrightnessNumericUpDown.Location = new System.Drawing.Point(273, 38);
            this.BrightnessNumericUpDown.Name = "BrightnessNumericUpDown";
            this.BrightnessNumericUpDown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BrightnessNumericUpDown.Properties.MaxValue = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.BrightnessNumericUpDown.Properties.MinValue = new decimal(new int[] {
            150,
            0,
            0,
            -2147483648});
            this.BrightnessNumericUpDown.Size = new System.Drawing.Size(44, 19);
            this.BrightnessNumericUpDown.TabIndex = 1;
            // 
            // BrightnessTrackBar
            // 
            this.BrightnessTrackBar.EditValue = null;
            this.BrightnessTrackBar.Location = new System.Drawing.Point(6, 37);
            this.BrightnessTrackBar.Name = "BrightnessTrackBar";
            this.BrightnessTrackBar.Properties.Maximum = 150;
            this.BrightnessTrackBar.Properties.Minimum = -150;
            this.BrightnessTrackBar.Size = new System.Drawing.Size(232, 45);
            this.BrightnessTrackBar.TabIndex = 0;
            this.BrightnessTrackBar.EditValueChanged += new System.EventHandler(this.BrightnessTrackBar_EditValueChanged);
            // 
            // Contrast_Grp
            // 
            this.Contrast_Grp.Controls.Add(this.ContrastNumericUpDown);
            this.Contrast_Grp.Controls.Add(this.ContrastTrackBar);
            this.Contrast_Grp.Location = new System.Drawing.Point(7, 411);
            this.Contrast_Grp.Name = "Contrast_Grp";
            this.Contrast_Grp.Size = new System.Drawing.Size(405, 85);
            this.Contrast_Grp.TabIndex = 3;
            this.Contrast_Grp.Text = "Contrast";
            // 
            // ContrastNumericUpDown
            // 
            this.ContrastNumericUpDown.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ContrastNumericUpDown.Location = new System.Drawing.Point(273, 35);
            this.ContrastNumericUpDown.Name = "ContrastNumericUpDown";
            this.ContrastNumericUpDown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ContrastNumericUpDown.Properties.MaxValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ContrastNumericUpDown.Properties.MinValue = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.ContrastNumericUpDown.Size = new System.Drawing.Size(44, 19);
            this.ContrastNumericUpDown.TabIndex = 2;
            // 
            // ContrastTrackBar
            // 
            this.ContrastTrackBar.EditValue = null;
            this.ContrastTrackBar.Location = new System.Drawing.Point(6, 34);
            this.ContrastTrackBar.Name = "ContrastTrackBar";
            this.ContrastTrackBar.Properties.Maximum = 50;
            this.ContrastTrackBar.Properties.Minimum = -50;
            this.ContrastTrackBar.Size = new System.Drawing.Size(232, 45);
            this.ContrastTrackBar.TabIndex = 1;
            this.ContrastTrackBar.EditValueChanged += new System.EventHandler(this.ContrastTrackBar_EditValueChanged);
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(526, 356);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(83, 30);
            this.Apply_btn.TabIndex = 4;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(526, 392);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(83, 30);
            this.Ok_btn.TabIndex = 5;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(526, 428);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(83, 30);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Preview_check
            // 
            this.Preview_check.Location = new System.Drawing.Point(524, 331);
            this.Preview_check.Name = "Preview_check";
            this.Preview_check.Properties.Caption = "Preview";
            this.Preview_check.Size = new System.Drawing.Size(75, 19);
            this.Preview_check.TabIndex = 7;
            // 
            // BrightnessContrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 508);
            this.Controls.Add(this.Preview_check);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.Contrast_Grp);
            this.Controls.Add(this.Brightness_Grp);
            this.Controls.Add(this.Modified_Grp);
            this.Controls.Add(this.Original_Grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BrightnessContrast";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brightness\\Contrast";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrightnessContrast_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Original_Grp)).EndInit();
            this.Original_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Grp)).EndInit();
            this.Modified_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness_Grp)).EndInit();
            this.Brightness_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessNumericUpDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast_Grp)).EndInit();
            this.Contrast_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContrastNumericUpDown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_check.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Original_Grp;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private DevExpress.XtraEditors.GroupControl Modified_Grp;
        private System.Windows.Forms.PictureBox ModifiedPictureBox;
        private DevExpress.XtraEditors.GroupControl Brightness_Grp;
        private DevExpress.XtraEditors.SpinEdit BrightnessNumericUpDown;
        private DevExpress.XtraEditors.TrackBarControl BrightnessTrackBar;
        private DevExpress.XtraEditors.GroupControl Contrast_Grp;
        private DevExpress.XtraEditors.SpinEdit ContrastNumericUpDown;
        private DevExpress.XtraEditors.TrackBarControl ContrastTrackBar;
        private DevExpress.XtraEditors.SimpleButton Apply_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel;
        private DevExpress.XtraEditors.CheckEdit Preview_check;
    }
}