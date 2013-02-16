namespace iMago
{
    partial class QuantizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantizationForm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.OriginalImage_PB = new System.Windows.Forms.PictureBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedImage_PB = new System.Windows.Forms.PictureBox();
            this.imagesPanal = new System.Windows.Forms.Panel();
            this.apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Preview_checkbox = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedImage_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_checkbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.OriginalImage_PB);
            this.groupControl1.Location = new System.Drawing.Point(151, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(228, 235);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Original";
            // 
            // OriginalImage_PB
            // 
            this.OriginalImage_PB.Location = new System.Drawing.Point(8, 25);
            this.OriginalImage_PB.Name = "OriginalImage_PB";
            this.OriginalImage_PB.Size = new System.Drawing.Size(211, 205);
            this.OriginalImage_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OriginalImage_PB.TabIndex = 0;
            this.OriginalImage_PB.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ModifiedImage_PB);
            this.groupControl2.Location = new System.Drawing.Point(398, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(228, 235);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Modified";
            // 
            // ModifiedImage_PB
            // 
            this.ModifiedImage_PB.Location = new System.Drawing.Point(8, 25);
            this.ModifiedImage_PB.Name = "ModifiedImage_PB";
            this.ModifiedImage_PB.Size = new System.Drawing.Size(211, 205);
            this.ModifiedImage_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ModifiedImage_PB.TabIndex = 1;
            this.ModifiedImage_PB.TabStop = false;
            // 
            // imagesPanal
            // 
            this.imagesPanal.AutoScroll = true;
            this.imagesPanal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagesPanal.Location = new System.Drawing.Point(-2, 248);
            this.imagesPanal.Name = "imagesPanal";
            this.imagesPanal.Size = new System.Drawing.Size(804, 331);
            this.imagesPanal.TabIndex = 2;
            // 
            // apply_btn
            // 
            this.apply_btn.Location = new System.Drawing.Point(15, 63);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(75, 23);
            this.apply_btn.TabIndex = 3;
            this.apply_btn.Text = "Apply";
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(15, 139);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(15, 101);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 5;
            this.ok_btn.Text = "OK";
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // Preview_checkbox
            // 
            this.Preview_checkbox.Location = new System.Drawing.Point(13, 26);
            this.Preview_checkbox.Name = "Preview_checkbox";
            this.Preview_checkbox.Properties.Caption = "Preview";
            this.Preview_checkbox.Size = new System.Drawing.Size(75, 19);
            this.Preview_checkbox.TabIndex = 6;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.Preview_checkbox);
            this.groupControl3.Controls.Add(this.ok_btn);
            this.groupControl3.Controls.Add(this.apply_btn);
            this.groupControl3.Controls.Add(this.cancel_btn);
            this.groupControl3.Location = new System.Drawing.Point(698, 37);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(104, 173);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Options";
            // 
            // QuantizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 544);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.imagesPanal);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QuantizationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuantizationForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImage_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedImage_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_checkbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.PictureBox OriginalImage_PB;
        private System.Windows.Forms.PictureBox ModifiedImage_PB;
        private System.Windows.Forms.Panel imagesPanal;
        private DevExpress.XtraEditors.SimpleButton apply_btn;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton ok_btn;
        private DevExpress.XtraEditors.CheckEdit Preview_checkbox;
        private DevExpress.XtraEditors.GroupControl groupControl3;
    }
}