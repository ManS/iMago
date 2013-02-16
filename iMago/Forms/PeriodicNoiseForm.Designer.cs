namespace iMago
{
    partial class PeriodicNoiseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodicNoiseForm));
            this.Amplitude_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Xfrequency_lbl = new DevExpress.XtraEditors.LabelControl();
            this.YFrequency_lbl = new DevExpress.XtraEditors.LabelControl();
            this.XPhase_lbl = new DevExpress.XtraEditors.LabelControl();
            this.YPhase_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Amplitude_txt = new DevExpress.XtraEditors.TextEdit();
            this.Xfrequency_txt = new DevExpress.XtraEditors.TextEdit();
            this.YFrequency_txt = new DevExpress.XtraEditors.TextEdit();
            this.XPhase_txt = new DevExpress.XtraEditors.TextEdit();
            this.YPhase_txt = new DevExpress.XtraEditors.TextEdit();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Parameters_gb = new DevExpress.XtraEditors.GroupControl();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Amplitude_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xfrequency_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YFrequency_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPhase_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPhase_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parameters_gb)).BeginInit();
            this.Parameters_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Amplitude_lbl
            // 
            this.Amplitude_lbl.Location = new System.Drawing.Point(9, 29);
            this.Amplitude_lbl.Name = "Amplitude_lbl";
            this.Amplitude_lbl.Size = new System.Drawing.Size(47, 13);
            this.Amplitude_lbl.TabIndex = 0;
            this.Amplitude_lbl.Text = "Amplitude";
            // 
            // Xfrequency_lbl
            // 
            this.Xfrequency_lbl.Location = new System.Drawing.Point(9, 55);
            this.Xfrequency_lbl.Name = "Xfrequency_lbl";
            this.Xfrequency_lbl.Size = new System.Drawing.Size(58, 13);
            this.Xfrequency_lbl.TabIndex = 1;
            this.Xfrequency_lbl.Text = "X frequency";
            // 
            // YFrequency_lbl
            // 
            this.YFrequency_lbl.Location = new System.Drawing.Point(9, 80);
            this.YFrequency_lbl.Name = "YFrequency_lbl";
            this.YFrequency_lbl.Size = new System.Drawing.Size(60, 13);
            this.YFrequency_lbl.TabIndex = 2;
            this.YFrequency_lbl.Text = "Y Frequency";
            // 
            // XPhase_lbl
            // 
            this.XPhase_lbl.Location = new System.Drawing.Point(9, 105);
            this.XPhase_lbl.Name = "XPhase_lbl";
            this.XPhase_lbl.Size = new System.Drawing.Size(38, 13);
            this.XPhase_lbl.TabIndex = 3;
            this.XPhase_lbl.Text = "X Phase";
            // 
            // YPhase_lbl
            // 
            this.YPhase_lbl.Location = new System.Drawing.Point(9, 130);
            this.YPhase_lbl.Name = "YPhase_lbl";
            this.YPhase_lbl.Size = new System.Drawing.Size(38, 13);
            this.YPhase_lbl.TabIndex = 4;
            this.YPhase_lbl.Text = "Y Phase";
            // 
            // Amplitude_txt
            // 
            this.Amplitude_txt.Location = new System.Drawing.Point(104, 27);
            this.Amplitude_txt.Name = "Amplitude_txt";
            this.Amplitude_txt.Size = new System.Drawing.Size(109, 19);
            this.Amplitude_txt.TabIndex = 5;
            // 
            // Xfrequency_txt
            // 
            this.Xfrequency_txt.Location = new System.Drawing.Point(104, 52);
            this.Xfrequency_txt.Name = "Xfrequency_txt";
            this.Xfrequency_txt.Size = new System.Drawing.Size(109, 19);
            this.Xfrequency_txt.TabIndex = 6;
            // 
            // YFrequency_txt
            // 
            this.YFrequency_txt.Location = new System.Drawing.Point(104, 77);
            this.YFrequency_txt.Name = "YFrequency_txt";
            this.YFrequency_txt.Size = new System.Drawing.Size(109, 19);
            this.YFrequency_txt.TabIndex = 7;
            // 
            // XPhase_txt
            // 
            this.XPhase_txt.Location = new System.Drawing.Point(104, 102);
            this.XPhase_txt.Name = "XPhase_txt";
            this.XPhase_txt.Size = new System.Drawing.Size(109, 19);
            this.XPhase_txt.TabIndex = 8;
            // 
            // YPhase_txt
            // 
            this.YPhase_txt.Location = new System.Drawing.Point(104, 127);
            this.YPhase_txt.Name = "YPhase_txt";
            this.YPhase_txt.Size = new System.Drawing.Size(109, 19);
            this.YPhase_txt.TabIndex = 9;
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(94, 159);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(62, 25);
            this.Ok_btn.TabIndex = 10;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Parameters_gb
            // 
            this.Parameters_gb.Controls.Add(this.YPhase_txt);
            this.Parameters_gb.Controls.Add(this.XPhase_txt);
            this.Parameters_gb.Controls.Add(this.YFrequency_txt);
            this.Parameters_gb.Controls.Add(this.Xfrequency_txt);
            this.Parameters_gb.Controls.Add(this.Amplitude_txt);
            this.Parameters_gb.Controls.Add(this.YPhase_lbl);
            this.Parameters_gb.Controls.Add(this.XPhase_lbl);
            this.Parameters_gb.Controls.Add(this.YFrequency_lbl);
            this.Parameters_gb.Controls.Add(this.Xfrequency_lbl);
            this.Parameters_gb.Controls.Add(this.Amplitude_lbl);
            this.Parameters_gb.Location = new System.Drawing.Point(6, 2);
            this.Parameters_gb.Name = "Parameters_gb";
            this.Parameters_gb.Size = new System.Drawing.Size(218, 151);
            this.Parameters_gb.TabIndex = 11;
            this.Parameters_gb.Text = "Parameters";
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(162, 159);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(62, 25);
            this.Cancel_btn.TabIndex = 12;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // PeriodicNoiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 190);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Parameters_gb);
            this.Controls.Add(this.Ok_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PeriodicNoiseForm";
            this.ShowIcon = false;
            this.Text = "Periodic Noise";
            ((System.ComponentModel.ISupportInitialize)(this.Amplitude_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xfrequency_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YFrequency_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPhase_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YPhase_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parameters_gb)).EndInit();
            this.Parameters_gb.ResumeLayout(false);
            this.Parameters_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl Amplitude_lbl;
        private DevExpress.XtraEditors.LabelControl Xfrequency_lbl;
        private DevExpress.XtraEditors.LabelControl YFrequency_lbl;
        private DevExpress.XtraEditors.LabelControl XPhase_lbl;
        private DevExpress.XtraEditors.LabelControl YPhase_lbl;
        private DevExpress.XtraEditors.TextEdit Amplitude_txt;
        private DevExpress.XtraEditors.TextEdit Xfrequency_txt;
        private DevExpress.XtraEditors.TextEdit YFrequency_txt;
        private DevExpress.XtraEditors.TextEdit XPhase_txt;
        private DevExpress.XtraEditors.TextEdit YPhase_txt;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.GroupControl Parameters_gb;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
    }
}