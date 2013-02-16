namespace iMago
{
    partial class ExponentialNoiseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExponentialNoiseForm));
            this.A_txt = new DevExpress.XtraEditors.TextEdit();
            this.Noise_txt = new DevExpress.XtraEditors.TextEdit();
            this.Noise_lbl = new DevExpress.XtraEditors.LabelControl();
            this.A_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Prs_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.A_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noise_txt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // A_txt
            // 
            this.A_txt.Location = new System.Drawing.Point(87, 12);
            this.A_txt.Name = "A_txt";
            this.A_txt.Size = new System.Drawing.Size(76, 19);
            this.A_txt.TabIndex = 0;
            // 
            // Noise_txt
            // 
            this.Noise_txt.Location = new System.Drawing.Point(87, 37);
            this.Noise_txt.Name = "Noise_txt";
            this.Noise_txt.Size = new System.Drawing.Size(76, 19);
            this.Noise_txt.TabIndex = 1;
            // 
            // Noise_lbl
            // 
            this.Noise_lbl.Location = new System.Drawing.Point(12, 39);
            this.Noise_lbl.Name = "Noise_lbl";
            this.Noise_lbl.Size = new System.Drawing.Size(26, 13);
            this.Noise_lbl.TabIndex = 2;
            this.Noise_lbl.Text = "Noise";
            // 
            // A_lbl
            // 
            this.A_lbl.Location = new System.Drawing.Point(12, 14);
            this.A_lbl.Name = "A_lbl";
            this.A_lbl.Size = new System.Drawing.Size(7, 13);
            this.A_lbl.TabIndex = 3;
            this.A_lbl.Text = "A";
            // 
            // Prs_lbl
            // 
            this.Prs_lbl.Location = new System.Drawing.Point(169, 40);
            this.Prs_lbl.Name = "Prs_lbl";
            this.Prs_lbl.Size = new System.Drawing.Size(11, 13);
            this.Prs_lbl.TabIndex = 4;
            this.Prs_lbl.Text = "%";
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(134, 66);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(61, 27);
            this.Ok_btn.TabIndex = 5;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // ExponentialNoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 98);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Prs_lbl);
            this.Controls.Add(this.A_lbl);
            this.Controls.Add(this.Noise_lbl);
            this.Controls.Add(this.Noise_txt);
            this.Controls.Add(this.A_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExponentialNoiseForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exponential Noise";
            ((System.ComponentModel.ISupportInitialize)(this.A_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noise_txt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit A_txt;
        private DevExpress.XtraEditors.TextEdit Noise_txt;
        private DevExpress.XtraEditors.LabelControl Noise_lbl;
        private DevExpress.XtraEditors.LabelControl A_lbl;
        private DevExpress.XtraEditors.LabelControl Prs_lbl;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
    }
}