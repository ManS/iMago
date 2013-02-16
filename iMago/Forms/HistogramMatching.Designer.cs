namespace iMago
{
    partial class HistogramMatching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramMatching));
            this.SourceImage_grp = new DevExpress.XtraEditors.GroupControl();
            this.Source_Log_check = new DevExpress.XtraEditors.CheckEdit();
            this.Source_Histogram_ComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Source_Histogram = new iMago.Histogram();
            this.Source_ComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.SourcePictureBox = new System.Windows.Forms.PictureBox();
            this.DestinationImage_grp = new DevExpress.XtraEditors.GroupControl();
            this.Destination_Log_check = new DevExpress.XtraEditors.CheckEdit();
            this.Destination_ComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Destination_Histogram_ComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.DestinationPictureBox = new System.Windows.Forms.PictureBox();
            this.Destination_Histogram = new iMago.Histogram();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.SourceImage_grp)).BeginInit();
            this.SourceImage_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Source_Log_check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_Histogram_ComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_ComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationImage_grp)).BeginInit();
            this.DestinationImage_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Destination_Log_check.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Destination_ComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Destination_Histogram_ComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceImage_grp
            // 
            this.SourceImage_grp.Controls.Add(this.Source_Log_check);
            this.SourceImage_grp.Controls.Add(this.Source_Histogram_ComboBox);
            this.SourceImage_grp.Controls.Add(this.Source_Histogram);
            this.SourceImage_grp.Controls.Add(this.Source_ComboBox);
            this.SourceImage_grp.Controls.Add(this.SourcePictureBox);
            this.SourceImage_grp.Location = new System.Drawing.Point(9, 8);
            this.SourceImage_grp.Name = "SourceImage_grp";
            this.SourceImage_grp.Size = new System.Drawing.Size(527, 220);
            this.SourceImage_grp.TabIndex = 0;
            this.SourceImage_grp.Text = "Source Image";
            // 
            // Source_Log_check
            // 
            this.Source_Log_check.Location = new System.Drawing.Point(455, 190);
            this.Source_Log_check.Name = "Source_Log_check";
            this.Source_Log_check.Properties.Caption = "Log";
            this.Source_Log_check.Size = new System.Drawing.Size(42, 19);
            this.Source_Log_check.TabIndex = 4;
            this.Source_Log_check.CheckedChanged += new System.EventHandler(this.Source_Log_check_CheckedChanged);
            // 
            // Source_Histogram_ComboBox
            // 
            this.Source_Histogram_ComboBox.Location = new System.Drawing.Point(239, 190);
            this.Source_Histogram_ComboBox.Name = "Source_Histogram_ComboBox";
            this.Source_Histogram_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Source_Histogram_ComboBox.Size = new System.Drawing.Size(206, 19);
            this.Source_Histogram_ComboBox.TabIndex = 3;
            this.Source_Histogram_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Source_Histogram_ComboBox_SelectedIndexChanged);
            // 
            // Source_Histogram
            // 
            this.Source_Histogram.Location = new System.Drawing.Point(217, 24);
            this.Source_Histogram.Name = "Source_Histogram";
            this.Source_Histogram.Size = new System.Drawing.Size(305, 165);
            this.Source_Histogram.TabIndex = 2;
            this.Source_Histogram.Text = "histogram1";
            // 
            // Source_ComboBox
            // 
            this.Source_ComboBox.Location = new System.Drawing.Point(9, 190);
            this.Source_ComboBox.Name = "Source_ComboBox";
            this.Source_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Source_ComboBox.Size = new System.Drawing.Size(202, 19);
            this.Source_ComboBox.TabIndex = 1;
            this.Source_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Source_ComboBox_SelectedIndexChanged);
            // 
            // SourcePictureBox
            // 
            this.SourcePictureBox.Location = new System.Drawing.Point(9, 28);
            this.SourcePictureBox.Name = "SourcePictureBox";
            this.SourcePictureBox.Size = new System.Drawing.Size(202, 152);
            this.SourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SourcePictureBox.TabIndex = 0;
            this.SourcePictureBox.TabStop = false;
            // 
            // DestinationImage_grp
            // 
            this.DestinationImage_grp.Controls.Add(this.Destination_Log_check);
            this.DestinationImage_grp.Controls.Add(this.Destination_ComboBox);
            this.DestinationImage_grp.Controls.Add(this.Destination_Histogram_ComboBox);
            this.DestinationImage_grp.Controls.Add(this.DestinationPictureBox);
            this.DestinationImage_grp.Controls.Add(this.Destination_Histogram);
            this.DestinationImage_grp.Location = new System.Drawing.Point(9, 237);
            this.DestinationImage_grp.Name = "DestinationImage_grp";
            this.DestinationImage_grp.Size = new System.Drawing.Size(527, 220);
            this.DestinationImage_grp.TabIndex = 1;
            this.DestinationImage_grp.Text = "Destination Image";
            // 
            // Destination_Log_check
            // 
            this.Destination_Log_check.Location = new System.Drawing.Point(455, 189);
            this.Destination_Log_check.Name = "Destination_Log_check";
            this.Destination_Log_check.Properties.Caption = "Log";
            this.Destination_Log_check.Size = new System.Drawing.Size(42, 19);
            this.Destination_Log_check.TabIndex = 7;
            this.Destination_Log_check.CheckedChanged += new System.EventHandler(this.Destination_Log_check_CheckedChanged);
            // 
            // Destination_ComboBox
            // 
            this.Destination_ComboBox.Location = new System.Drawing.Point(9, 190);
            this.Destination_ComboBox.Name = "Destination_ComboBox";
            this.Destination_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Destination_ComboBox.Size = new System.Drawing.Size(202, 19);
            this.Destination_ComboBox.TabIndex = 2;
            this.Destination_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Destination_ComboBox_SelectedIndexChanged);
            // 
            // Destination_Histogram_ComboBox
            // 
            this.Destination_Histogram_ComboBox.Location = new System.Drawing.Point(239, 189);
            this.Destination_Histogram_ComboBox.Name = "Destination_Histogram_ComboBox";
            this.Destination_Histogram_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Destination_Histogram_ComboBox.Size = new System.Drawing.Size(206, 19);
            this.Destination_Histogram_ComboBox.TabIndex = 6;
            this.Destination_Histogram_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Destination_Histogram_ComboBox_SelectedIndexChanged);
            // 
            // DestinationPictureBox
            // 
            this.DestinationPictureBox.Location = new System.Drawing.Point(9, 28);
            this.DestinationPictureBox.Name = "DestinationPictureBox";
            this.DestinationPictureBox.Size = new System.Drawing.Size(202, 152);
            this.DestinationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DestinationPictureBox.TabIndex = 1;
            this.DestinationPictureBox.TabStop = false;
            // 
            // Destination_Histogram
            // 
            this.Destination_Histogram.Location = new System.Drawing.Point(217, 23);
            this.Destination_Histogram.Name = "Destination_Histogram";
            this.Destination_Histogram.Size = new System.Drawing.Size(305, 165);
            this.Destination_Histogram.TabIndex = 5;
            this.Destination_Histogram.Text = "histogram1";
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(448, 463);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(88, 34);
            this.Cancel_btn.TabIndex = 2;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(354, 463);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(88, 34);
            this.Ok_btn.TabIndex = 3;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // HistogramMatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 506);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.DestinationImage_grp);
            this.Controls.Add(this.SourceImage_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HistogramMatching";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histogram Matching";
            ((System.ComponentModel.ISupportInitialize)(this.SourceImage_grp)).EndInit();
            this.SourceImage_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Source_Log_check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_Histogram_ComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Source_ComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationImage_grp)).EndInit();
            this.DestinationImage_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Destination_Log_check.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Destination_ComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Destination_Histogram_ComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl SourceImage_grp;
        private DevExpress.XtraEditors.GroupControl DestinationImage_grp;
        private System.Windows.Forms.PictureBox SourcePictureBox;
        private System.Windows.Forms.PictureBox DestinationPictureBox;
        private DevExpress.XtraEditors.ComboBoxEdit Source_ComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit Destination_ComboBox;
        private DevExpress.XtraEditors.CheckEdit Source_Log_check;
        private DevExpress.XtraEditors.ComboBoxEdit Source_Histogram_ComboBox;
        private Histogram Source_Histogram;
        private DevExpress.XtraEditors.CheckEdit Destination_Log_check;
        private DevExpress.XtraEditors.ComboBoxEdit Destination_Histogram_ComboBox;
        private Histogram Destination_Histogram;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
    }
}