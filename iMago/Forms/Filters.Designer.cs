namespace iMago
{
    partial class Filters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filters));
            this.Original_Grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.Modified_Grp = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.WidthTextBox = new DevExpress.XtraEditors.TextEdit();
            this.HeightTextBox = new DevExpress.XtraEditors.TextEdit();
            this.SigmatextBox = new DevExpress.XtraEditors.TextEdit();
            this.Width_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Height_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Sigma_lbl = new DevExpress.XtraEditors.LabelControl();
            this.PaddingType_lbl = new DevExpress.XtraEditors.LabelControl();
            this.PaddingComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Original_Grp)).BeginInit();
            this.Original_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Grp)).BeginInit();
            this.Modified_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SigmatextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaddingComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Original_Grp
            // 
            this.Original_Grp.Controls.Add(this.OriginalPictureBox);
            this.Original_Grp.Location = new System.Drawing.Point(5, 7);
            this.Original_Grp.Name = "Original_Grp";
            this.Original_Grp.Size = new System.Drawing.Size(311, 275);
            this.Original_Grp.TabIndex = 0;
            this.Original_Grp.Text = "Original Image";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(4, 23);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(302, 246);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // Modified_Grp
            // 
            this.Modified_Grp.Controls.Add(this.ModifiedPictureBox);
            this.Modified_Grp.Location = new System.Drawing.Point(322, 7);
            this.Modified_Grp.Name = "Modified_Grp";
            this.Modified_Grp.Size = new System.Drawing.Size(311, 275);
            this.Modified_Grp.TabIndex = 1;
            this.Modified_Grp.Text = "Modified Image";
            // 
            // ModifiedPictureBox
            // 
            this.ModifiedPictureBox.Location = new System.Drawing.Point(5, 23);
            this.ModifiedPictureBox.Name = "ModifiedPictureBox";
            this.ModifiedPictureBox.Size = new System.Drawing.Size(302, 246);
            this.ModifiedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ModifiedPictureBox.TabIndex = 1;
            this.ModifiedPictureBox.TabStop = false;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(150, 297);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(63, 19);
            this.WidthTextBox.TabIndex = 2;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(150, 322);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(63, 19);
            this.HeightTextBox.TabIndex = 3;
            // 
            // SigmatextBox
            // 
            this.SigmatextBox.Location = new System.Drawing.Point(150, 347);
            this.SigmatextBox.Name = "SigmatextBox";
            this.SigmatextBox.Size = new System.Drawing.Size(63, 19);
            this.SigmatextBox.TabIndex = 4;
            // 
            // Width_lbl
            // 
            this.Width_lbl.Location = new System.Drawing.Point(48, 300);
            this.Width_lbl.Name = "Width_lbl";
            this.Width_lbl.Size = new System.Drawing.Size(28, 13);
            this.Width_lbl.TabIndex = 5;
            this.Width_lbl.Text = "Width";
            // 
            // Height_lbl
            // 
            this.Height_lbl.Location = new System.Drawing.Point(48, 324);
            this.Height_lbl.Name = "Height_lbl";
            this.Height_lbl.Size = new System.Drawing.Size(31, 13);
            this.Height_lbl.TabIndex = 6;
            this.Height_lbl.Text = "Height";
            // 
            // Sigma_lbl
            // 
            this.Sigma_lbl.Location = new System.Drawing.Point(48, 348);
            this.Sigma_lbl.Name = "Sigma_lbl";
            this.Sigma_lbl.Size = new System.Drawing.Size(28, 13);
            this.Sigma_lbl.TabIndex = 7;
            this.Sigma_lbl.Text = "Sigma";
            // 
            // PaddingType_lbl
            // 
            this.PaddingType_lbl.Location = new System.Drawing.Point(341, 300);
            this.PaddingType_lbl.Name = "PaddingType_lbl";
            this.PaddingType_lbl.Size = new System.Drawing.Size(65, 13);
            this.PaddingType_lbl.TabIndex = 8;
            this.PaddingType_lbl.Text = "Padding Type";
            // 
            // PaddingComboBox
            // 
            this.PaddingComboBox.Location = new System.Drawing.Point(412, 297);
            this.PaddingComboBox.Name = "PaddingComboBox";
            this.PaddingComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PaddingComboBox.Properties.Items.AddRange(new object[] {
            "By Replicationg",
            "By Zeros "});
            this.PaddingComboBox.Size = new System.Drawing.Size(129, 19);
            this.PaddingComboBox.TabIndex = 9;
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(412, 348);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(66, 28);
            this.Apply_btn.TabIndex = 10;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(484, 348);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(66, 28);
            this.Ok_btn.TabIndex = 11;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(556, 349);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(66, 28);
            this.Cancel_btn.TabIndex = 12;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 388);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.PaddingComboBox);
            this.Controls.Add(this.PaddingType_lbl);
            this.Controls.Add(this.Sigma_lbl);
            this.Controls.Add(this.Height_lbl);
            this.Controls.Add(this.Width_lbl);
            this.Controls.Add(this.SigmatextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.Modified_Grp);
            this.Controls.Add(this.Original_Grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Filters";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filters";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Filters_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Original_Grp)).EndInit();
            this.Original_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_Grp)).EndInit();
            this.Modified_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SigmatextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaddingComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Original_Grp;
        private DevExpress.XtraEditors.GroupControl Modified_Grp;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private System.Windows.Forms.PictureBox ModifiedPictureBox;
        private DevExpress.XtraEditors.TextEdit WidthTextBox;
        private DevExpress.XtraEditors.TextEdit HeightTextBox;
        private DevExpress.XtraEditors.TextEdit SigmatextBox;
        private DevExpress.XtraEditors.LabelControl Width_lbl;
        private DevExpress.XtraEditors.LabelControl Height_lbl;
        private DevExpress.XtraEditors.LabelControl Sigma_lbl;
        private DevExpress.XtraEditors.LabelControl PaddingType_lbl;
        private DevExpress.XtraEditors.ComboBoxEdit PaddingComboBox;
        private DevExpress.XtraEditors.SimpleButton Apply_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
    }
}