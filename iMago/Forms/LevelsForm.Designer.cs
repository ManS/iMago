namespace iMago
{
    partial class LevelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelsForm));
            this.Options_grp = new DevExpress.XtraEditors.GroupControl();
            this.channelCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.allCheckBox = new DevExpress.XtraEditors.CheckEdit();
            this.Channel_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Input_grp = new DevExpress.XtraEditors.GroupControl();
            this.inSlider = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.histogram = new iMago.Histogram();
            this.inMaxBox = new DevExpress.XtraEditors.TextEdit();
            this.inMinBox = new DevExpress.XtraEditors.TextEdit();
            this.Max_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Min_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Output_grp = new DevExpress.XtraEditors.GroupControl();
            this.outSlider = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.outMaxBox = new DevExpress.XtraEditors.TextEdit();
            this.outMinBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Imgae_grp = new DevExpress.XtraEditors.GroupControl();
            this.filterPreview = new iMago.FilterPreview();
            this.OkButton = new DevExpress.XtraEditors.SimpleButton();
            this.CancelButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Options_grp)).BeginInit();
            this.Options_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allCheckBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_grp)).BeginInit();
            this.Input_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inSlider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inMaxBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inMinBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Output_grp)).BeginInit();
            this.Output_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outSlider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outMaxBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outMinBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imgae_grp)).BeginInit();
            this.Imgae_grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // Options_grp
            // 
            this.Options_grp.Controls.Add(this.channelCombo);
            this.Options_grp.Controls.Add(this.allCheckBox);
            this.Options_grp.Controls.Add(this.Channel_lbl);
            this.Options_grp.Location = new System.Drawing.Point(5, 7);
            this.Options_grp.Name = "Options_grp";
            this.Options_grp.Size = new System.Drawing.Size(292, 57);
            this.Options_grp.TabIndex = 0;
            this.Options_grp.Text = "Options";
            // 
            // channelCombo
            // 
            this.channelCombo.Location = new System.Drawing.Point(59, 26);
            this.channelCombo.Name = "channelCombo";
            this.channelCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.channelCombo.Size = new System.Drawing.Size(149, 20);
            this.channelCombo.TabIndex = 3;
            this.channelCombo.SelectedIndexChanged += new System.EventHandler(this.channelCombo_SelectedIndexChanged);
            // 
            // allCheckBox
            // 
            this.allCheckBox.Location = new System.Drawing.Point(222, 26);
            this.allCheckBox.Name = "allCheckBox";
            this.allCheckBox.Properties.Caption = "Sync";
            this.allCheckBox.Size = new System.Drawing.Size(58, 19);
            this.allCheckBox.TabIndex = 2;
            // 
            // Channel_lbl
            // 
            this.Channel_lbl.Location = new System.Drawing.Point(11, 29);
            this.Channel_lbl.Name = "Channel_lbl";
            this.Channel_lbl.Size = new System.Drawing.Size(39, 13);
            this.Channel_lbl.TabIndex = 0;
            this.Channel_lbl.Text = "Channel";
            // 
            // Input_grp
            // 
            this.Input_grp.Controls.Add(this.inSlider);
            this.Input_grp.Controls.Add(this.histogram);
            this.Input_grp.Controls.Add(this.inMaxBox);
            this.Input_grp.Controls.Add(this.inMinBox);
            this.Input_grp.Controls.Add(this.Max_lbl);
            this.Input_grp.Controls.Add(this.Min_lbl);
            this.Input_grp.Location = new System.Drawing.Point(5, 70);
            this.Input_grp.Name = "Input_grp";
            this.Input_grp.Size = new System.Drawing.Size(292, 271);
            this.Input_grp.TabIndex = 1;
            this.Input_grp.Text = "Input";
            // 
            // inSlider
            // 
            this.inSlider.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(0, 0);
            this.inSlider.Location = new System.Drawing.Point(9, 222);
            this.inSlider.Name = "inSlider";
            this.inSlider.Properties.Maximum = 255;
            this.inSlider.Properties.TickFrequency = 5;
            this.inSlider.Size = new System.Drawing.Size(269, 45);
            this.inSlider.TabIndex = 4;
            this.inSlider.ValueChanged += new System.EventHandler(this.inSlider_ValueChanged);
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(9, 55);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(271, 182);
            this.histogram.TabIndex = 0;
            this.histogram.Text = "histogram1";
            // 
            // inMaxBox
            // 
            this.inMaxBox.Location = new System.Drawing.Point(151, 29);
            this.inMaxBox.Name = "inMaxBox";
            this.inMaxBox.Size = new System.Drawing.Size(55, 20);
            this.inMaxBox.TabIndex = 3;
            this.inMaxBox.TextChanged += new System.EventHandler(this.inMaxBox_TextChanged);
            // 
            // inMinBox
            // 
            this.inMinBox.Location = new System.Drawing.Point(44, 30);
            this.inMinBox.Name = "inMinBox";
            this.inMinBox.Size = new System.Drawing.Size(55, 20);
            this.inMinBox.TabIndex = 2;
            this.inMinBox.TextChanged += new System.EventHandler(this.inMinBox_TextChanged);
            // 
            // Max_lbl
            // 
            this.Max_lbl.Location = new System.Drawing.Point(122, 31);
            this.Max_lbl.Name = "Max_lbl";
            this.Max_lbl.Size = new System.Drawing.Size(20, 13);
            this.Max_lbl.TabIndex = 1;
            this.Max_lbl.Text = "Max";
            // 
            // Min_lbl
            // 
            this.Min_lbl.Location = new System.Drawing.Point(17, 33);
            this.Min_lbl.Name = "Min_lbl";
            this.Min_lbl.Size = new System.Drawing.Size(16, 13);
            this.Min_lbl.TabIndex = 0;
            this.Min_lbl.Text = "Min";
            // 
            // Output_grp
            // 
            this.Output_grp.Controls.Add(this.outSlider);
            this.Output_grp.Controls.Add(this.outMaxBox);
            this.Output_grp.Controls.Add(this.outMinBox);
            this.Output_grp.Controls.Add(this.labelControl2);
            this.Output_grp.Controls.Add(this.labelControl1);
            this.Output_grp.Location = new System.Drawing.Point(5, 347);
            this.Output_grp.Name = "Output_grp";
            this.Output_grp.Size = new System.Drawing.Size(292, 108);
            this.Output_grp.TabIndex = 2;
            this.Output_grp.Text = "Output";
            // 
            // outSlider
            // 
            this.outSlider.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(0, 0);
            this.outSlider.Location = new System.Drawing.Point(11, 55);
            this.outSlider.Name = "outSlider";
            this.outSlider.Properties.Maximum = 255;
            this.outSlider.Properties.TickFrequency = 5;
            this.outSlider.Size = new System.Drawing.Size(267, 45);
            this.outSlider.TabIndex = 5;
            this.outSlider.ValueChanged += new System.EventHandler(this.outSlider_ValueChanged);
            // 
            // outMaxBox
            // 
            this.outMaxBox.Location = new System.Drawing.Point(151, 30);
            this.outMaxBox.Name = "outMaxBox";
            this.outMaxBox.Size = new System.Drawing.Size(55, 20);
            this.outMaxBox.TabIndex = 8;
            this.outMaxBox.TextChanged += new System.EventHandler(this.outMaxBox_TextChanged);
            // 
            // outMinBox
            // 
            this.outMinBox.Location = new System.Drawing.Point(44, 31);
            this.outMinBox.Name = "outMinBox";
            this.outMinBox.Size = new System.Drawing.Size(55, 20);
            this.outMinBox.TabIndex = 7;
            this.outMinBox.TextChanged += new System.EventHandler(this.outMinBox_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(16, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Min";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(122, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(20, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Max";
            // 
            // Imgae_grp
            // 
            this.Imgae_grp.Controls.Add(this.CancelButton);
            this.Imgae_grp.Controls.Add(this.OkButton);
            this.Imgae_grp.Controls.Add(this.filterPreview);
            this.Imgae_grp.Location = new System.Drawing.Point(307, 7);
            this.Imgae_grp.Name = "Imgae_grp";
            this.Imgae_grp.Size = new System.Drawing.Size(380, 448);
            this.Imgae_grp.TabIndex = 3;
            this.Imgae_grp.Text = "Image";
            // 
            // filterPreview
            // 
            this.filterPreview.Image = null;
            this.filterPreview.Location = new System.Drawing.Point(5, 23);
            this.filterPreview.Name = "filterPreview";
            this.filterPreview.Size = new System.Drawing.Size(370, 378);
            this.filterPreview.TabIndex = 0;
            this.filterPreview.Text = "filterPreview1";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(130, 407);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(119, 33);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(255, 407);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(119, 33);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 462);
            this.Controls.Add(this.Imgae_grp);
            this.Controls.Add(this.Output_grp);
            this.Controls.Add(this.Input_grp);
            this.Controls.Add(this.Options_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LevelsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Levels";
            ((System.ComponentModel.ISupportInitialize)(this.Options_grp)).EndInit();
            this.Options_grp.ResumeLayout(false);
            this.Options_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allCheckBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_grp)).EndInit();
            this.Input_grp.ResumeLayout(false);
            this.Input_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inSlider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inMaxBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inMinBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Output_grp)).EndInit();
            this.Output_grp.ResumeLayout(false);
            this.Output_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outSlider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outMaxBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outMinBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imgae_grp)).EndInit();
            this.Imgae_grp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Options_grp;
        private DevExpress.XtraEditors.CheckEdit allCheckBox;
        private DevExpress.XtraEditors.LabelControl Channel_lbl;
        private DevExpress.XtraEditors.GroupControl Input_grp;
        private Histogram histogram;
        private DevExpress.XtraEditors.TextEdit inMaxBox;
        private DevExpress.XtraEditors.TextEdit inMinBox;
        private DevExpress.XtraEditors.LabelControl Max_lbl;
        private DevExpress.XtraEditors.LabelControl Min_lbl;
        private DevExpress.XtraEditors.RangeTrackBarControl inSlider;
        private DevExpress.XtraEditors.GroupControl Output_grp;
        private DevExpress.XtraEditors.RangeTrackBarControl outSlider;
        private DevExpress.XtraEditors.TextEdit outMaxBox;
        private DevExpress.XtraEditors.TextEdit outMinBox;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl Imgae_grp;
        private DevExpress.XtraEditors.ComboBoxEdit channelCombo;
        private iMago.FilterPreview filterPreview;
        private DevExpress.XtraEditors.SimpleButton CancelButton;
        private DevExpress.XtraEditors.SimpleButton OkButton;
    }
}