namespace iMago.Forms
{
    partial class NormalThreshold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NormalThreshold));
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.thresholdTextBox = new System.Windows.Forms.TextBox();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Parameters_gb = new DevExpress.XtraEditors.GroupControl();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Parameters_gb)).BeginInit();
            this.Parameters_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(10, 30);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(54, 13);
            this.ThresholdLabel.TabIndex = 0;
            this.ThresholdLabel.Text = "Threshold";
            // 
            // thresholdTextBox
            // 
            this.thresholdTextBox.Location = new System.Drawing.Point(162, 27);
            this.thresholdTextBox.Name = "thresholdTextBox";
            this.thresholdTextBox.Size = new System.Drawing.Size(129, 20);
            this.thresholdTextBox.TabIndex = 1;
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(164, 69);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(64, 23);
            this.Ok_btn.TabIndex = 3;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Parameters_gb
            // 
            this.Parameters_gb.Controls.Add(this.thresholdTextBox);
            this.Parameters_gb.Controls.Add(this.ThresholdLabel);
            this.Parameters_gb.Location = new System.Drawing.Point(2, 3);
            this.Parameters_gb.Name = "Parameters_gb";
            this.Parameters_gb.Size = new System.Drawing.Size(296, 60);
            this.Parameters_gb.TabIndex = 4;
            this.Parameters_gb.Text = "Parameters";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(234, 69);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(64, 23);
            this.cancel_btn.TabIndex = 5;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // NormalThreshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 98);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Parameters_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NormalThreshold";
            this.Text = "Normal Threshold(Binarization)";
            ((System.ComponentModel.ISupportInitialize)(this.Parameters_gb)).EndInit();
            this.Parameters_gb.ResumeLayout(false);
            this.Parameters_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.TextBox thresholdTextBox;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.GroupControl Parameters_gb;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
    }
}