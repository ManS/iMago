namespace iMago.Forms
{
    partial class ZeroCrossing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroCrossing));
            this.derivative1Label = new System.Windows.Forms.Label();
            this.derivative2Label = new System.Windows.Forms.Label();
            this.FilterSizeLabel = new System.Windows.Forms.Label();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.options = new DevExpress.XtraEditors.GroupControl();
            this.FilterSizeTextBox = new DevExpress.XtraEditors.TextEdit();
            this.derivative2TextBox = new DevExpress.XtraEditors.TextEdit();
            this.derivative1TextBox = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.options)).BeginInit();
            this.options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilterSizeTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivative2TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivative1TextBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // derivative1Label
            // 
            this.derivative1Label.AutoSize = true;
            this.derivative1Label.Location = new System.Drawing.Point(2, 31);
            this.derivative1Label.Name = "derivative1Label";
            this.derivative1Label.Size = new System.Drawing.Size(62, 13);
            this.derivative1Label.TabIndex = 0;
            this.derivative1Label.Text = "Derivative1";
            // 
            // derivative2Label
            // 
            this.derivative2Label.AutoSize = true;
            this.derivative2Label.Location = new System.Drawing.Point(2, 56);
            this.derivative2Label.Name = "derivative2Label";
            this.derivative2Label.Size = new System.Drawing.Size(62, 13);
            this.derivative2Label.TabIndex = 1;
            this.derivative2Label.Text = "Derivative2";
            // 
            // FilterSizeLabel
            // 
            this.FilterSizeLabel.AutoSize = true;
            this.FilterSizeLabel.Location = new System.Drawing.Point(2, 81);
            this.FilterSizeLabel.Name = "FilterSizeLabel";
            this.FilterSizeLabel.Size = new System.Drawing.Size(53, 13);
            this.FilterSizeLabel.TabIndex = 2;
            this.FilterSizeLabel.Text = "Filter Size";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(194, 113);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(113, 113);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 9;
            this.ok_btn.Text = "OK";
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // options
            // 
            this.options.Controls.Add(this.FilterSizeTextBox);
            this.options.Controls.Add(this.derivative2TextBox);
            this.options.Controls.Add(this.derivative1TextBox);
            this.options.Controls.Add(this.FilterSizeLabel);
            this.options.Controls.Add(this.derivative2Label);
            this.options.Controls.Add(this.derivative1Label);
            this.options.Location = new System.Drawing.Point(2, 2);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(272, 105);
            this.options.TabIndex = 10;
            this.options.Text = "Options";
            // 
            // FilterSizeTextBox
            // 
            this.FilterSizeTextBox.Location = new System.Drawing.Point(167, 78);
            this.FilterSizeTextBox.Name = "FilterSizeTextBox";
            this.FilterSizeTextBox.Size = new System.Drawing.Size(100, 19);
            this.FilterSizeTextBox.TabIndex = 10;
            // 
            // derivative2TextBox
            // 
            this.derivative2TextBox.Location = new System.Drawing.Point(167, 53);
            this.derivative2TextBox.Name = "derivative2TextBox";
            this.derivative2TextBox.Size = new System.Drawing.Size(100, 19);
            this.derivative2TextBox.TabIndex = 9;
            // 
            // derivative1TextBox
            // 
            this.derivative1TextBox.Location = new System.Drawing.Point(167, 28);
            this.derivative1TextBox.Name = "derivative1TextBox";
            this.derivative1TextBox.Size = new System.Drawing.Size(100, 19);
            this.derivative1TextBox.TabIndex = 8;
            // 
            // ZeroCrossing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 143);
            this.Controls.Add(this.options);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.cancel_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ZeroCrossing";
            this.Text = "Zero Crossing";
            ((System.ComponentModel.ISupportInitialize)(this.options)).EndInit();
            this.options.ResumeLayout(false);
            this.options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilterSizeTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivative2TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivative1TextBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label derivative1Label;
        private System.Windows.Forms.Label derivative2Label;
        private System.Windows.Forms.Label FilterSizeLabel;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton ok_btn;
        private DevExpress.XtraEditors.GroupControl options;
        private DevExpress.XtraEditors.TextEdit FilterSizeTextBox;
        private DevExpress.XtraEditors.TextEdit derivative2TextBox;
        private DevExpress.XtraEditors.TextEdit derivative1TextBox;
    }
}