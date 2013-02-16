namespace iMago
{
    partial class ResizingInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizingInputForm));
            this.NewWidth_lbl = new DevExpress.XtraEditors.LabelControl();
            this.NewHeight_lbl = new DevExpress.XtraEditors.LabelControl();
            this.NewWidth_txtbox = new DevExpress.XtraEditors.TextEdit();
            this.NewHeight_txtbox = new DevExpress.XtraEditors.TextEdit();
            this.Resize_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.parameters_gb = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.NewWidth_txtbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewHeight_txtbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameters_gb)).BeginInit();
            this.parameters_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewWidth_lbl
            // 
            this.NewWidth_lbl.Location = new System.Drawing.Point(5, 24);
            this.NewWidth_lbl.Name = "NewWidth_lbl";
            this.NewWidth_lbl.Size = new System.Drawing.Size(52, 13);
            this.NewWidth_lbl.TabIndex = 0;
            this.NewWidth_lbl.Text = "New Width";
            // 
            // NewHeight_lbl
            // 
            this.NewHeight_lbl.Location = new System.Drawing.Point(5, 48);
            this.NewHeight_lbl.Name = "NewHeight_lbl";
            this.NewHeight_lbl.Size = new System.Drawing.Size(55, 13);
            this.NewHeight_lbl.TabIndex = 1;
            this.NewHeight_lbl.Text = "New Height";
            // 
            // NewWidth_txtbox
            // 
            this.NewWidth_txtbox.Location = new System.Drawing.Point(112, 22);
            this.NewWidth_txtbox.Name = "NewWidth_txtbox";
            this.NewWidth_txtbox.Size = new System.Drawing.Size(95, 19);
            this.NewWidth_txtbox.TabIndex = 2;
            // 
            // NewHeight_txtbox
            // 
            this.NewHeight_txtbox.Location = new System.Drawing.Point(112, 47);
            this.NewHeight_txtbox.Name = "NewHeight_txtbox";
            this.NewHeight_txtbox.Size = new System.Drawing.Size(95, 19);
            this.NewHeight_txtbox.TabIndex = 3;
            // 
            // Resize_btn
            // 
            this.Resize_btn.Location = new System.Drawing.Point(81, 89);
            this.Resize_btn.Name = "Resize_btn";
            this.Resize_btn.Size = new System.Drawing.Size(65, 30);
            this.Resize_btn.TabIndex = 4;
            this.Resize_btn.Text = "Resize";
            this.Resize_btn.Click += new System.EventHandler(this.Resize_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(152, 89);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(65, 30);
            this.Cancel_btn.TabIndex = 5;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // parameters_gb
            // 
            this.parameters_gb.Controls.Add(this.NewHeight_txtbox);
            this.parameters_gb.Controls.Add(this.NewWidth_txtbox);
            this.parameters_gb.Controls.Add(this.NewHeight_lbl);
            this.parameters_gb.Controls.Add(this.NewWidth_lbl);
            this.parameters_gb.Location = new System.Drawing.Point(5, 5);
            this.parameters_gb.Name = "parameters_gb";
            this.parameters_gb.Size = new System.Drawing.Size(212, 71);
            this.parameters_gb.TabIndex = 6;
            this.parameters_gb.Text = "Parameters";
            // 
            // ResizingInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 119);
            this.Controls.Add(this.parameters_gb);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Resize_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResizingInputForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resizing";
            ((System.ComponentModel.ISupportInitialize)(this.NewWidth_txtbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewHeight_txtbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameters_gb)).EndInit();
            this.parameters_gb.ResumeLayout(false);
            this.parameters_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl NewWidth_lbl;
        private DevExpress.XtraEditors.LabelControl NewHeight_lbl;
        private DevExpress.XtraEditors.TextEdit NewWidth_txtbox;
        private DevExpress.XtraEditors.TextEdit NewHeight_txtbox;
        private DevExpress.XtraEditors.SimpleButton Resize_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private DevExpress.XtraEditors.GroupControl parameters_gb;
    }
}