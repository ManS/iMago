namespace iMago.Forms
{
    partial class Translation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Translation));
            this.translate_btn = new DevExpress.XtraEditors.SimpleButton();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.xfactor = new DevExpress.XtraEditors.LabelControl();
            this.yfactor = new DevExpress.XtraEditors.LabelControl();
            this.xfactor_txtbox = new DevExpress.XtraEditors.TextEdit();
            this.yfactor_txtbox = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.xfactor_txtbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yfactor_txtbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translate_btn
            // 
            this.translate_btn.Location = new System.Drawing.Point(102, 118);
            this.translate_btn.Name = "translate_btn";
            this.translate_btn.Size = new System.Drawing.Size(75, 23);
            this.translate_btn.TabIndex = 0;
            this.translate_btn.Text = "Translate";
            this.translate_btn.Click += new System.EventHandler(this.translate_btn_Click_1);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(183, 118);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // xfactor
            // 
            this.xfactor.Location = new System.Drawing.Point(5, 39);
            this.xfactor.Name = "xfactor";
            this.xfactor.Size = new System.Drawing.Size(44, 13);
            this.xfactor.TabIndex = 2;
            this.xfactor.Text = "X Factor:";
            // 
            // yfactor
            // 
            this.yfactor.Location = new System.Drawing.Point(5, 64);
            this.yfactor.Name = "yfactor";
            this.yfactor.Size = new System.Drawing.Size(44, 13);
            this.yfactor.TabIndex = 3;
            this.yfactor.Text = "Y Factor:";
            // 
            // xfactor_txtbox
            // 
            this.xfactor_txtbox.Location = new System.Drawing.Point(142, 36);
            this.xfactor_txtbox.Name = "xfactor_txtbox";
            this.xfactor_txtbox.Size = new System.Drawing.Size(100, 19);
            this.xfactor_txtbox.TabIndex = 4;
            // 
            // yfactor_txtbox
            // 
            this.yfactor_txtbox.Location = new System.Drawing.Point(142, 61);
            this.yfactor_txtbox.Name = "yfactor_txtbox";
            this.yfactor_txtbox.Size = new System.Drawing.Size(100, 19);
            this.yfactor_txtbox.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.xfactor);
            this.groupControl1.Controls.Add(this.yfactor_txtbox);
            this.groupControl1.Controls.Add(this.yfactor);
            this.groupControl1.Controls.Add(this.xfactor_txtbox);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(247, 100);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Parameters";
            // 
            // Translation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 145);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.translate_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Lilian";
            this.MaximizeBox = false;
            this.Name = "Translation";
            this.Text = "Translation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Translation_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.xfactor_txtbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yfactor_txtbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton translate_btn;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.LabelControl xfactor;
        private DevExpress.XtraEditors.LabelControl yfactor;
        private DevExpress.XtraEditors.TextEdit xfactor_txtbox;
        private DevExpress.XtraEditors.TextEdit yfactor_txtbox;
        private DevExpress.XtraEditors.GroupControl groupControl1;

    }
}