namespace iMago
{
    partial class ThresholdForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThresholdForm));
            this.Original_grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.Modified_grp = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.WindowSize_txt = new DevExpress.XtraEditors.TextEdit();
            this.Epsilon_txt = new DevExpress.XtraEditors.TextEdit();
            this.WindowSize_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Epsilon_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.parameters_gb = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).BeginInit();
            this.Original_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).BeginInit();
            this.Modified_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowSize_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Epsilon_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameters_gb)).BeginInit();
            this.parameters_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Original_grp
            // 
            this.Original_grp.Controls.Add(this.OriginalPictureBox);
            this.Original_grp.Location = new System.Drawing.Point(8, 8);
            this.Original_grp.Name = "Original_grp";
            this.Original_grp.Size = new System.Drawing.Size(289, 270);
            this.Original_grp.TabIndex = 0;
            this.Original_grp.Text = "Original";
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(9, 28);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(271, 230);
            this.OriginalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // Modified_grp
            // 
            this.Modified_grp.Controls.Add(this.ModifiedPictureBox);
            this.Modified_grp.Location = new System.Drawing.Point(303, 8);
            this.Modified_grp.Name = "Modified_grp";
            this.Modified_grp.Size = new System.Drawing.Size(289, 270);
            this.Modified_grp.TabIndex = 1;
            this.Modified_grp.Text = "Modified";
            // 
            // ModifiedPictureBox
            // 
            this.ModifiedPictureBox.Location = new System.Drawing.Point(9, 28);
            this.ModifiedPictureBox.Name = "ModifiedPictureBox";
            this.ModifiedPictureBox.Size = new System.Drawing.Size(271, 230);
            this.ModifiedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ModifiedPictureBox.TabIndex = 1;
            this.ModifiedPictureBox.TabStop = false;
            // 
            // WindowSize_txt
            // 
            this.WindowSize_txt.Location = new System.Drawing.Point(88, 26);
            this.WindowSize_txt.Name = "WindowSize_txt";
            this.WindowSize_txt.Size = new System.Drawing.Size(93, 19);
            this.WindowSize_txt.TabIndex = 2;
            // 
            // Epsilon_txt
            // 
            this.Epsilon_txt.Location = new System.Drawing.Point(88, 51);
            this.Epsilon_txt.Name = "Epsilon_txt";
            this.Epsilon_txt.Size = new System.Drawing.Size(93, 19);
            this.Epsilon_txt.TabIndex = 3;
            // 
            // WindowSize_lbl
            // 
            this.WindowSize_lbl.Location = new System.Drawing.Point(6, 29);
            this.WindowSize_lbl.Name = "WindowSize_lbl";
            this.WindowSize_lbl.Size = new System.Drawing.Size(59, 13);
            this.WindowSize_lbl.TabIndex = 4;
            this.WindowSize_lbl.Text = "Window size";
            // 
            // Epsilon_lbl
            // 
            this.Epsilon_lbl.Location = new System.Drawing.Point(6, 54);
            this.Epsilon_lbl.Name = "Epsilon_lbl";
            this.Epsilon_lbl.Size = new System.Drawing.Size(33, 13);
            this.Epsilon_lbl.TabIndex = 5;
            this.Epsilon_lbl.Text = "Epsilon";
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(497, 287);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(95, 33);
            this.Apply_btn.TabIndex = 6;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(497, 326);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(95, 33);
            this.Ok_btn.TabIndex = 7;
            this.Ok_btn.Text = "Ok";
            // 
            // parameters_gb
            // 
            this.parameters_gb.Controls.Add(this.Epsilon_lbl);
            this.parameters_gb.Controls.Add(this.WindowSize_lbl);
            this.parameters_gb.Controls.Add(this.Epsilon_txt);
            this.parameters_gb.Controls.Add(this.WindowSize_txt);
            this.parameters_gb.Location = new System.Drawing.Point(8, 284);
            this.parameters_gb.Name = "parameters_gb";
            this.parameters_gb.Size = new System.Drawing.Size(190, 75);
            this.parameters_gb.TabIndex = 8;
            this.parameters_gb.Text = "Parameters";
            // 
            // ThresholdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 366);
            this.Controls.Add(this.parameters_gb);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.Modified_grp);
            this.Controls.Add(this.Original_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ThresholdForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Threshold";
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).EndInit();
            this.Original_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).EndInit();
            this.Modified_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowSize_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Epsilon_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parameters_gb)).EndInit();
            this.parameters_gb.ResumeLayout(false);
            this.parameters_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Original_grp;
        private System.Windows.Forms.PictureBox OriginalPictureBox;
        private DevExpress.XtraEditors.GroupControl Modified_grp;
        private System.Windows.Forms.PictureBox ModifiedPictureBox;
        private DevExpress.XtraEditors.TextEdit WindowSize_txt;
        private DevExpress.XtraEditors.TextEdit Epsilon_txt;
        private DevExpress.XtraEditors.LabelControl WindowSize_lbl;
        private DevExpress.XtraEditors.LabelControl Epsilon_lbl;
        private DevExpress.XtraEditors.SimpleButton Apply_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.GroupControl parameters_gb;
    }
}