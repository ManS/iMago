namespace iMago.Forms
{
    partial class GaussianFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GaussianFilter));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SigmaTextBox = new DevExpress.XtraEditors.TextEdit();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.PaddedComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.SigmaTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaddedComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Sigma:";
            // 
            // SigmaTextBox
            // 
            this.SigmaTextBox.Location = new System.Drawing.Point(120, 7);
            this.SigmaTextBox.Name = "SigmaTextBox";
            this.SigmaTextBox.Size = new System.Drawing.Size(122, 19);
            this.SigmaTextBox.TabIndex = 6;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(189, 82);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(53, 32);
            this.cancel_btn.TabIndex = 5;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(120, 82);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(53, 32);
            this.ok_btn.TabIndex = 4;
            this.ok_btn.Text = "OK";
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // PaddedComboBox
            // 
            this.PaddedComboBox.Location = new System.Drawing.Point(120, 37);
            this.PaddedComboBox.Name = "PaddedComboBox";
            this.PaddedComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PaddedComboBox.Properties.Items.AddRange(new object[] {
            "Replication",
            "Zeros"});
            this.PaddedComboBox.Size = new System.Drawing.Size(122, 19);
            this.PaddedComboBox.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Padding Type:";
            // 
            // GaussianFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 115);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.PaddedComboBox);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.SigmaTextBox);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.ok_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GaussianFilter";
            this.Text = "Gaussian";
            ((System.ComponentModel.ISupportInitialize)(this.SigmaTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaddedComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit SigmaTextBox;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton ok_btn;
        private DevExpress.XtraEditors.ComboBoxEdit PaddedComboBox;
        private DevExpress.XtraEditors.LabelControl labelControl2;

    }
}