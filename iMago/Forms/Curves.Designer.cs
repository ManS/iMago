namespace iMago
{
    partial class Curves
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Curves));
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Channel_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Channel_ComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Image_Panel = new iMago.ImagePanel();
            this.Image_Curve = new iMago.ImageCurve();
            ((System.ComponentModel.ISupportInitialize)(this.Channel_ComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(542, 433);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(107, 31);
            this.Cancel_btn.TabIndex = 3;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(542, 396);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(107, 31);
            this.Ok_btn.TabIndex = 4;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Channel_lbl
            // 
            this.Channel_lbl.Location = new System.Drawing.Point(466, 231);
            this.Channel_lbl.Name = "Channel_lbl";
            this.Channel_lbl.Size = new System.Drawing.Size(39, 13);
            this.Channel_lbl.TabIndex = 5;
            this.Channel_lbl.Text = "Channel";
            // 
            // Channel_ComboBox
            // 
            this.Channel_ComboBox.EditValue = "RGB";
            this.Channel_ComboBox.Location = new System.Drawing.Point(465, 252);
            this.Channel_ComboBox.Name = "Channel_ComboBox";
            this.Channel_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Channel_ComboBox.Properties.Items.AddRange(new object[] {
            "RGB",
            "Red",
            "Green",
            "Blue"});
            this.Channel_ComboBox.Size = new System.Drawing.Size(166, 19);
            this.Channel_ComboBox.TabIndex = 6;
            // 
            // Image_Panel
            // 
            this.Image_Panel.CanvasSize = new System.Drawing.Size(60, 40);
            this.Image_Panel.Image = null;
            this.Image_Panel.ImagePath = null;
            this.Image_Panel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.Image_Panel.Location = new System.Drawing.Point(10, 17);
            this.Image_Panel.Name = "Image_Panel";
            this.Image_Panel.SelectedArea = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Image_Panel.Size = new System.Drawing.Size(422, 444);
            this.Image_Panel.TabIndex = 1;
            this.Image_Panel.Zoom = 1F;
            // 
            // Image_Curve
            // 
            this.Image_Curve.Location = new System.Drawing.Point(432, 5);
            this.Image_Curve.Name = "Image_Curve";
            this.Image_Curve.Size = new System.Drawing.Size(223, 219);
            this.Image_Curve.TabIndex = 0;
            this.Image_Curve.LevelChangedEvent += new iMago.LevelChangedEventHandler(this.Image_Curve_LevelChangedEvent);
            // 
            // Curves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 480);
            this.Controls.Add(this.Channel_ComboBox);
            this.Controls.Add(this.Channel_lbl);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Image_Panel);
            this.Controls.Add(this.Image_Curve);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Curves";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curves";
            ((System.ComponentModel.ISupportInitialize)(this.Channel_ComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageCurve Image_Curve;
        private ImagePanel Image_Panel;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.LabelControl Channel_lbl;
        private DevExpress.XtraEditors.ComboBoxEdit Channel_ComboBox;
    }
}