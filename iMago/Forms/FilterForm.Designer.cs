namespace iMago.Forms
{
    partial class FilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.filtersize_txtbox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.paddingType_cb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.paddingtype_lbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.filtersize_txtbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingType_cb.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // filtersize_txtbox
            // 
            this.filtersize_txtbox.Location = new System.Drawing.Point(113, 12);
            this.filtersize_txtbox.Name = "filtersize_txtbox";
            this.filtersize_txtbox.Size = new System.Drawing.Size(100, 19);
            this.filtersize_txtbox.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Filter Size:";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(186, 77);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(105, 77);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 3;
            this.ok_btn.Text = "OK";
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // paddingType_cb
            // 
            this.paddingType_cb.Location = new System.Drawing.Point(113, 37);
            this.paddingType_cb.Name = "paddingType_cb";
            this.paddingType_cb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.paddingType_cb.Properties.Items.AddRange(new object[] {
            "By Replication",
            "By Zeros"});
            this.paddingType_cb.Size = new System.Drawing.Size(100, 19);
            this.paddingType_cb.TabIndex = 4;
            // 
            // paddingtype_lbl
            // 
            this.paddingtype_lbl.Location = new System.Drawing.Point(12, 43);
            this.paddingtype_lbl.Name = "paddingtype_lbl";
            this.paddingtype_lbl.Size = new System.Drawing.Size(69, 13);
            this.paddingtype_lbl.TabIndex = 5;
            this.paddingtype_lbl.Text = "Padding Type:";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 112);
            this.Controls.Add(this.paddingtype_lbl);
            this.Controls.Add(this.paddingType_cb);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.filtersize_txtbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterForm";
            this.Text = "Filter";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.filtersize_txtbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingType_cb.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit filtersize_txtbox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.SimpleButton ok_btn;
        private DevExpress.XtraEditors.ComboBoxEdit paddingType_cb;
        private DevExpress.XtraEditors.LabelControl paddingtype_lbl;
    }
}