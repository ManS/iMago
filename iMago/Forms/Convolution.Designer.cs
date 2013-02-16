namespace iMago
{
    partial class Convolution
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Convolution));
            this.Original_grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.Modified_grp = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.Options_grp = new DevExpress.XtraEditors.GroupControl();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.LoadMaskButton = new DevExpress.XtraEditors.SimpleButton();
            this.SaveMaskButton = new DevExpress.XtraEditors.SimpleButton();
            this.MakeMaskButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelConHeightLabeltrol1 = new DevExpress.XtraEditors.LabelControl();
            this.WidthLabel = new DevExpress.XtraEditors.LabelControl();
            this.HeightTextBox = new DevExpress.XtraEditors.TextEdit();
            this.WidthTextBox = new DevExpress.XtraEditors.TextEdit();
            this.ApplyButton = new DevExpress.XtraEditors.SimpleButton();
            this.OKButton = new DevExpress.XtraEditors.SimpleButton();
            this.CancelButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).BeginInit();
            this.Original_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).BeginInit();
            this.Modified_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_grp)).BeginInit();
            this.Options_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Original_grp
            // 
            this.Original_grp.Controls.Add(this.OriginalPictureBox);
            this.Original_grp.Location = new System.Drawing.Point(12, 12);
            this.Original_grp.Name = "Original_grp";
            this.Original_grp.Size = new System.Drawing.Size(289, 247);
            this.Original_grp.TabIndex = 0;
            this.Original_grp.Text = "Original";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(6, 24);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(277, 217);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // Modified_grp
            // 
            this.Modified_grp.Controls.Add(this.ModifiedPictureBox);
            this.Modified_grp.Location = new System.Drawing.Point(316, 12);
            this.Modified_grp.Name = "Modified_grp";
            this.Modified_grp.Size = new System.Drawing.Size(289, 247);
            this.Modified_grp.TabIndex = 1;
            this.Modified_grp.Text = "Modified";
            // 
            // ModifiedPictureBox
            // 
            this.ModifiedPictureBox.Location = new System.Drawing.Point(6, 24);
            this.ModifiedPictureBox.Name = "ModifiedPictureBox";
            this.ModifiedPictureBox.Size = new System.Drawing.Size(277, 217);
            this.ModifiedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ModifiedPictureBox.TabIndex = 1;
            this.ModifiedPictureBox.TabStop = false;
            // 
            // Options_grp
            // 
            this.Options_grp.Controls.Add(this.dataGridView);
            this.Options_grp.Controls.Add(this.LoadMaskButton);
            this.Options_grp.Controls.Add(this.SaveMaskButton);
            this.Options_grp.Controls.Add(this.MakeMaskButton);
            this.Options_grp.Controls.Add(this.labelConHeightLabeltrol1);
            this.Options_grp.Controls.Add(this.WidthLabel);
            this.Options_grp.Controls.Add(this.HeightTextBox);
            this.Options_grp.Controls.Add(this.WidthTextBox);
            this.Options_grp.Location = new System.Drawing.Point(12, 275);
            this.Options_grp.Name = "Options_grp";
            this.Options_grp.Size = new System.Drawing.Size(499, 215);
            this.Options_grp.TabIndex = 2;
            this.Options_grp.Text = "Options";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Location = new System.Drawing.Point(186, 24);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(308, 172);
            this.dataGridView.TabIndex = 8;
            // 
            // LoadMaskButton
            // 
            this.LoadMaskButton.Location = new System.Drawing.Point(19, 148);
            this.LoadMaskButton.Name = "LoadMaskButton";
            this.LoadMaskButton.Size = new System.Drawing.Size(144, 21);
            this.LoadMaskButton.TabIndex = 6;
            this.LoadMaskButton.Text = "Load Mask";
            this.LoadMaskButton.Click += new System.EventHandler(this.LoadMaskButton_Click);
            // 
            // SaveMaskButton
            // 
            this.SaveMaskButton.Location = new System.Drawing.Point(19, 121);
            this.SaveMaskButton.Name = "SaveMaskButton";
            this.SaveMaskButton.Size = new System.Drawing.Size(144, 21);
            this.SaveMaskButton.TabIndex = 5;
            this.SaveMaskButton.Text = "Save Mask";
            this.SaveMaskButton.Click += new System.EventHandler(this.SaveMaskButton_Click);
            // 
            // MakeMaskButton
            // 
            this.MakeMaskButton.Location = new System.Drawing.Point(18, 94);
            this.MakeMaskButton.Name = "MakeMaskButton";
            this.MakeMaskButton.Size = new System.Drawing.Size(144, 21);
            this.MakeMaskButton.TabIndex = 4;
            this.MakeMaskButton.Text = "Make the Mask";
            this.MakeMaskButton.Click += new System.EventHandler(this.MakeMaskButton_Click);
            // 
            // labelConHeightLabeltrol1
            // 
            this.labelConHeightLabeltrol1.Location = new System.Drawing.Point(18, 66);
            this.labelConHeightLabeltrol1.Name = "labelConHeightLabeltrol1";
            this.labelConHeightLabeltrol1.Size = new System.Drawing.Size(31, 13);
            this.labelConHeightLabeltrol1.TabIndex = 3;
            this.labelConHeightLabeltrol1.Text = "Height";
            // 
            // WidthLabel
            // 
            this.WidthLabel.Location = new System.Drawing.Point(18, 41);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(28, 13);
            this.WidthLabel.TabIndex = 2;
            this.WidthLabel.Text = "Width";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(69, 63);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(94, 19);
            this.HeightTextBox.TabIndex = 1;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(68, 38);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(94, 19);
            this.WidthTextBox.TabIndex = 0;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(517, 289);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(87, 32);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(518, 327);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 32);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(518, 365);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 32);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Convolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 499);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.Options_grp);
            this.Controls.Add(this.Modified_grp);
            this.Controls.Add(this.Original_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Convolution";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convolution";
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).EndInit();
            this.Original_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).EndInit();
            this.Modified_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Options_grp)).EndInit();
            this.Options_grp.ResumeLayout(false);
            this.Options_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Original_grp;
        private DevExpress.XtraEditors.GroupControl Modified_grp;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private System.Windows.Forms.PictureBox ModifiedPictureBox;
        private DevExpress.XtraEditors.GroupControl Options_grp;
        private DevExpress.XtraEditors.TextEdit HeightTextBox;
        private DevExpress.XtraEditors.TextEdit WidthTextBox;
        private DevExpress.XtraEditors.LabelControl WidthLabel;
        private DevExpress.XtraEditors.LabelControl labelConHeightLabeltrol1;
        private DevExpress.XtraEditors.SimpleButton LoadMaskButton;
        private DevExpress.XtraEditors.SimpleButton SaveMaskButton;
        private DevExpress.XtraEditors.SimpleButton MakeMaskButton;
        private DevExpress.XtraEditors.SimpleButton ApplyButton;
        private DevExpress.XtraEditors.SimpleButton OKButton;
        private DevExpress.XtraEditors.SimpleButton CancelButton;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}