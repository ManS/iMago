namespace iMago
{
    partial class RotationInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotationInputForm));
            this.Angle_Selector = new AngleAltitudeControls.AngleSelector();
            this.Rotate_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Angle_TxtBox = new DevExpress.XtraEditors.TextEdit();
            this.Angle_grp = new DevExpress.XtraEditors.GroupControl();
            this.preview = new DevExpress.XtraEditors.CheckEdit();
            this.Deg_lbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Angle_TxtBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle_grp)).BeginInit();
            this.Angle_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Angle_Selector
            // 
            this.Angle_Selector.Location = new System.Drawing.Point(15, 27);
            this.Angle_Selector.Name = "Angle_Selector";
            this.Angle_Selector.Size = new System.Drawing.Size(62, 62);
            this.Angle_Selector.TabIndex = 0;
            this.Angle_Selector.AngleChanged += new AngleAltitudeControls.AngleSelector.AngleChangedDelegate(this.Angle_Selector_AngleChanged);
            this.Angle_Selector.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Angle_Selector_MouseUp);
            // 
            // Rotate_btn
            // 
            this.Rotate_btn.Location = new System.Drawing.Point(89, 108);
            this.Rotate_btn.Name = "Rotate_btn";
            this.Rotate_btn.Size = new System.Drawing.Size(71, 30);
            this.Rotate_btn.TabIndex = 1;
            this.Rotate_btn.Text = "Rotate";
            this.Rotate_btn.Click += new System.EventHandler(this.Rotate_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(166, 108);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(73, 30);
            this.Cancel_btn.TabIndex = 2;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Angle_TxtBox
            // 
            this.Angle_TxtBox.Location = new System.Drawing.Point(101, 48);
            this.Angle_TxtBox.Name = "Angle_TxtBox";
            this.Angle_TxtBox.Properties.ReadOnly = true;
            this.Angle_TxtBox.Size = new System.Drawing.Size(34, 19);
            this.Angle_TxtBox.TabIndex = 3;
            this.Angle_TxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Angle_TxtBox_KeyPress);
            this.Angle_TxtBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Angle_TxtBox_KeyUp);
            // 
            // Angle_grp
            // 
            this.Angle_grp.Controls.Add(this.preview);
            this.Angle_grp.Controls.Add(this.Deg_lbl);
            this.Angle_grp.Controls.Add(this.Angle_Selector);
            this.Angle_grp.Controls.Add(this.Angle_TxtBox);
            this.Angle_grp.Location = new System.Drawing.Point(6, 4);
            this.Angle_grp.Name = "Angle_grp";
            this.Angle_grp.Size = new System.Drawing.Size(233, 98);
            this.Angle_grp.TabIndex = 5;
            this.Angle_grp.Text = "Angle";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(158, 74);
            this.preview.Name = "preview";
            this.preview.Properties.Caption = "Preview";
            this.preview.Size = new System.Drawing.Size(75, 19);
            this.preview.TabIndex = 5;
            // 
            // Deg_lbl
            // 
            this.Deg_lbl.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deg_lbl.Appearance.Options.UseFont = true;
            this.Deg_lbl.Location = new System.Drawing.Point(139, 41);
            this.Deg_lbl.Name = "Deg_lbl";
            this.Deg_lbl.Size = new System.Drawing.Size(6, 16);
            this.Deg_lbl.TabIndex = 4;
            this.Deg_lbl.Text = "°";
            // 
            // RotationInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 146);
            this.Controls.Add(this.Angle_grp);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Rotate_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RotationInputForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rotation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RotationInputForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Angle_TxtBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle_grp)).EndInit();
            this.Angle_grp.ResumeLayout(false);
            this.Angle_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AngleAltitudeControls.AngleSelector Angle_Selector;
        private DevExpress.XtraEditors.SimpleButton Rotate_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private DevExpress.XtraEditors.TextEdit Angle_TxtBox;
        private DevExpress.XtraEditors.GroupControl Angle_grp;
        private DevExpress.XtraEditors.LabelControl Deg_lbl;
        private DevExpress.XtraEditors.CheckEdit preview;
    }
}