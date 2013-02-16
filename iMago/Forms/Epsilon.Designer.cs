namespace iMago.Forms
{
    partial class Epsilon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Epsilon));
            this.Mean_lbl = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.ok_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Mean_lbl
            // 
            this.Mean_lbl.Location = new System.Drawing.Point(12, 12);
            this.Mean_lbl.Name = "Mean_lbl";
            this.Mean_lbl.Size = new System.Drawing.Size(37, 13);
            this.Mean_lbl.TabIndex = 8;
            this.Mean_lbl.Text = "Epsilon:";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(140, 9);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 19);
            this.textEdit1.TabIndex = 9;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(177, 50);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 10;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(96, 50);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 11;
            this.ok_btn.Text = "OK";
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // Epsilon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 74);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.Mean_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Epsilon";
            this.Text = "Epsilon";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl Mean_lbl;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton ok_btn;
    }
}