namespace iMago
{
    partial class FrequencyDomainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrequencyDomainForm));
            this.pb_Red = new System.Windows.Forms.PictureBox();
            this.pb_Green = new System.Windows.Forms.PictureBox();
            this.pb_Blue = new System.Windows.Forms.PictureBox();
            this.Red_Grp = new DevExpress.XtraEditors.GroupControl();
            this.Green_grp = new DevExpress.XtraEditors.GroupControl();
            this.Blue_grp = new DevExpress.XtraEditors.GroupControl();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_Grp)).BeginInit();
            this.Red_Grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Green_grp)).BeginInit();
            this.Green_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_grp)).BeginInit();
            this.Blue_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Red
            // 
            this.pb_Red.Location = new System.Drawing.Point(9, 27);
            this.pb_Red.Name = "pb_Red";
            this.pb_Red.Size = new System.Drawing.Size(232, 394);
            this.pb_Red.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Red.TabIndex = 0;
            this.pb_Red.TabStop = false;
            // 
            // pb_Green
            // 
            this.pb_Green.Location = new System.Drawing.Point(11, 27);
            this.pb_Green.Name = "pb_Green";
            this.pb_Green.Size = new System.Drawing.Size(232, 394);
            this.pb_Green.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Green.TabIndex = 1;
            this.pb_Green.TabStop = false;
            // 
            // pb_Blue
            // 
            this.pb_Blue.Location = new System.Drawing.Point(9, 27);
            this.pb_Blue.Name = "pb_Blue";
            this.pb_Blue.Size = new System.Drawing.Size(232, 394);
            this.pb_Blue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Blue.TabIndex = 2;
            this.pb_Blue.TabStop = false;
            // 
            // Red_Grp
            // 
            this.Red_Grp.Controls.Add(this.pb_Red);
            this.Red_Grp.Location = new System.Drawing.Point(8, 6);
            this.Red_Grp.Name = "Red_Grp";
            this.Red_Grp.Size = new System.Drawing.Size(252, 435);
            this.Red_Grp.TabIndex = 3;
            this.Red_Grp.Text = "Red";
            // 
            // Green_grp
            // 
            this.Green_grp.Controls.Add(this.pb_Green);
            this.Green_grp.Location = new System.Drawing.Point(266, 6);
            this.Green_grp.Name = "Green_grp";
            this.Green_grp.Size = new System.Drawing.Size(253, 435);
            this.Green_grp.TabIndex = 4;
            this.Green_grp.Text = "Green";
            // 
            // Blue_grp
            // 
            this.Blue_grp.Controls.Add(this.pb_Blue);
            this.Blue_grp.Location = new System.Drawing.Point(525, 6);
            this.Blue_grp.Name = "Blue_grp";
            this.Blue_grp.Size = new System.Drawing.Size(250, 434);
            this.Blue_grp.TabIndex = 5;
            this.Blue_grp.Text = "Blue";
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(679, 449);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(96, 32);
            this.Ok_btn.TabIndex = 6;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // FrequencyDomainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 490);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Blue_grp);
            this.Controls.Add(this.Green_grp);
            this.Controls.Add(this.Red_Grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrequencyDomainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frequency Domain";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_Grp)).EndInit();
            this.Red_Grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Green_grp)).EndInit();
            this.Green_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Blue_grp)).EndInit();
            this.Blue_grp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Red;
        private System.Windows.Forms.PictureBox pb_Green;
        private System.Windows.Forms.PictureBox pb_Blue;
        private DevExpress.XtraEditors.GroupControl Red_Grp;
        private DevExpress.XtraEditors.GroupControl Green_grp;
        private DevExpress.XtraEditors.GroupControl Blue_grp;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
    }
}