namespace iMago
{
    partial class GaussianNoiseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GaussianNoiseForm));
            this.Mu_txt = new DevExpress.XtraEditors.TextEdit();
            this.Sigma_txt = new DevExpress.XtraEditors.TextEdit();
            this.Noise_txt = new DevExpress.XtraEditors.TextEdit();
            this.Mu_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Sigma_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Noise_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Prs_lbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Mu_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sigma_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noise_txt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Mu_txt
            // 
            this.Mu_txt.Location = new System.Drawing.Point(98, 18);
            this.Mu_txt.Name = "Mu_txt";
            this.Mu_txt.Size = new System.Drawing.Size(114, 19);
            this.Mu_txt.TabIndex = 0;
            // 
            // Sigma_txt
            // 
            this.Sigma_txt.Location = new System.Drawing.Point(98, 43);
            this.Sigma_txt.Name = "Sigma_txt";
            this.Sigma_txt.Size = new System.Drawing.Size(114, 19);
            this.Sigma_txt.TabIndex = 1;
            // 
            // Noise_txt
            // 
            this.Noise_txt.Location = new System.Drawing.Point(98, 68);
            this.Noise_txt.Name = "Noise_txt";
            this.Noise_txt.Size = new System.Drawing.Size(114, 19);
            this.Noise_txt.TabIndex = 2;
            // 
            // Mu_lbl
            // 
            this.Mu_lbl.Location = new System.Drawing.Point(31, 20);
            this.Mu_lbl.Name = "Mu_lbl";
            this.Mu_lbl.Size = new System.Drawing.Size(14, 13);
            this.Mu_lbl.TabIndex = 3;
            this.Mu_lbl.Text = "Mu";
            // 
            // Sigma_lbl
            // 
            this.Sigma_lbl.Location = new System.Drawing.Point(31, 45);
            this.Sigma_lbl.Name = "Sigma_lbl";
            this.Sigma_lbl.Size = new System.Drawing.Size(28, 13);
            this.Sigma_lbl.TabIndex = 4;
            this.Sigma_lbl.Text = "Sigma";
            // 
            // Noise_lbl
            // 
            this.Noise_lbl.Location = new System.Drawing.Point(31, 70);
            this.Noise_lbl.Name = "Noise_lbl";
            this.Noise_lbl.Size = new System.Drawing.Size(26, 13);
            this.Noise_lbl.TabIndex = 5;
            this.Noise_lbl.Text = "Noise";
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(172, 104);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(86, 31);
            this.Ok_btn.TabIndex = 6;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Prs_lbl
            // 
            this.Prs_lbl.Location = new System.Drawing.Point(218, 71);
            this.Prs_lbl.Name = "Prs_lbl";
            this.Prs_lbl.Size = new System.Drawing.Size(11, 13);
            this.Prs_lbl.TabIndex = 7;
            this.Prs_lbl.Text = "%";
            // 
            // GaussianNoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 141);
            this.Controls.Add(this.Prs_lbl);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Noise_lbl);
            this.Controls.Add(this.Sigma_lbl);
            this.Controls.Add(this.Mu_lbl);
            this.Controls.Add(this.Noise_txt);
            this.Controls.Add(this.Sigma_txt);
            this.Controls.Add(this.Mu_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GaussianNoiseForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gaussian Noise";
            ((System.ComponentModel.ISupportInitialize)(this.Mu_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sigma_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noise_txt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit Mu_txt;
        private DevExpress.XtraEditors.TextEdit Sigma_txt;
        private DevExpress.XtraEditors.TextEdit Noise_txt;
        private DevExpress.XtraEditors.LabelControl Mu_lbl;
        private DevExpress.XtraEditors.LabelControl Sigma_lbl;
        private DevExpress.XtraEditors.LabelControl Noise_lbl;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.LabelControl Prs_lbl;
    }
}