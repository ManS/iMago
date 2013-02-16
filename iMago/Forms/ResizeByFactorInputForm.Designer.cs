namespace iMago
{
    partial class ResizeByFactorInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeByFactorInputForm));
            this.ResizingFactor_lbl = new DevExpress.XtraEditors.LabelControl();
            this.ResizingFactor_text = new DevExpress.XtraEditors.TextEdit();
            this.Resize_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ResizingFactor_text.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ResizingFactor_lbl
            // 
            this.ResizingFactor_lbl.Location = new System.Drawing.Point(14, 19);
            this.ResizingFactor_lbl.Name = "ResizingFactor_lbl";
            this.ResizingFactor_lbl.Size = new System.Drawing.Size(73, 13);
            this.ResizingFactor_lbl.TabIndex = 0;
            this.ResizingFactor_lbl.Text = "Resizing Factor";
            // 
            // ResizingFactor_text
            // 
            this.ResizingFactor_text.Location = new System.Drawing.Point(101, 15);
            this.ResizingFactor_text.Name = "ResizingFactor_text";
            this.ResizingFactor_text.Size = new System.Drawing.Size(113, 19);
            this.ResizingFactor_text.TabIndex = 1;
            // 
            // Resize_btn
            // 
            this.Resize_btn.Location = new System.Drawing.Point(54, 46);
            this.Resize_btn.Name = "Resize_btn";
            this.Resize_btn.Size = new System.Drawing.Size(77, 24);
            this.Resize_btn.TabIndex = 2;
            this.Resize_btn.Text = "Resize";
            this.Resize_btn.Click += new System.EventHandler(this.Resize_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(137, 46);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(77, 24);
            this.Cancel_btn.TabIndex = 3;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // ResizeByFactorInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 78);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Resize_btn);
            this.Controls.Add(this.ResizingFactor_text);
            this.Controls.Add(this.ResizingFactor_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResizeByFactorInputForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resize By Factor";
            ((System.ComponentModel.ISupportInitialize)(this.ResizingFactor_text.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl ResizingFactor_lbl;
        private DevExpress.XtraEditors.TextEdit ResizingFactor_text;
        private DevExpress.XtraEditors.SimpleButton Resize_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
    }
}