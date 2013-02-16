namespace iMago
{
    partial class ImageCurve
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX0 = new System.Windows.Forms.Label();
            this.labelX1 = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.labelY2 = new System.Windows.Forms.Label();
            this.labelY1 = new System.Windows.Forms.Label();
            this.labelY0 = new System.Windows.Forms.Label();
            this.labelPt1 = new System.Windows.Forms.Label();
            this.labelPt3 = new System.Windows.Forms.Label();
            this.labelPt2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelX0
            // 
            this.labelX0.AutoSize = true;
            this.labelX0.Location = new System.Drawing.Point(31, 33);
            this.labelX0.Name = "labelX0";
            this.labelX0.Size = new System.Drawing.Size(13, 13);
            this.labelX0.TabIndex = 0;
            this.labelX0.Text = "0";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.Location = new System.Drawing.Point(31, 46);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(25, 13);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "127";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.Location = new System.Drawing.Point(34, 63);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(25, 13);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "255";
            // 
            // labelY2
            // 
            this.labelY2.AutoSize = true;
            this.labelY2.Location = new System.Drawing.Point(64, 84);
            this.labelY2.Name = "labelY2";
            this.labelY2.Size = new System.Drawing.Size(25, 13);
            this.labelY2.TabIndex = 5;
            this.labelY2.Text = "255";
            // 
            // labelY1
            // 
            this.labelY1.AutoSize = true;
            this.labelY1.Location = new System.Drawing.Point(61, 67);
            this.labelY1.Name = "labelY1";
            this.labelY1.Size = new System.Drawing.Size(25, 13);
            this.labelY1.TabIndex = 4;
            this.labelY1.Text = "127";
            // 
            // labelY0
            // 
            this.labelY0.AutoSize = true;
            this.labelY0.Location = new System.Drawing.Point(61, 54);
            this.labelY0.Name = "labelY0";
            this.labelY0.Size = new System.Drawing.Size(13, 13);
            this.labelY0.TabIndex = 3;
            this.labelY0.Text = "0";
            // 
            // labelPt1
            // 
            this.labelPt1.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelPt1.Location = new System.Drawing.Point(92, 54);
            this.labelPt1.Name = "labelPt1";
            this.labelPt1.Size = new System.Drawing.Size(4, 4);
            this.labelPt1.TabIndex = 6;
            this.labelPt1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseDown);
            this.labelPt1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseMove);
            this.labelPt1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseUp);
            // 
            // labelPt3
            // 
            this.labelPt3.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelPt3.Location = new System.Drawing.Point(105, 105);
            this.labelPt3.Name = "labelPt3";
            this.labelPt3.Size = new System.Drawing.Size(4, 4);
            this.labelPt3.TabIndex = 11;
            this.labelPt3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseDown);
            this.labelPt3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseMove);
            this.labelPt3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseUp);
            // 
            // labelPt2
            // 
            this.labelPt2.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelPt2.Location = new System.Drawing.Point(113, 113);
            this.labelPt2.Name = "labelPt2";
            this.labelPt2.Size = new System.Drawing.Size(4, 4);
            this.labelPt2.TabIndex = 12;
            this.labelPt2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseDown);
            this.labelPt2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseMove);
            this.labelPt2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelPt3_MouseUp);
            // 
            // ImageCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPt2);
            this.Controls.Add(this.labelPt3);
            this.Controls.Add(this.labelPt1);
            this.Controls.Add(this.labelY2);
            this.Controls.Add(this.labelY1);
            this.Controls.Add(this.labelY0);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX0);
            this.Name = "ImageCurve";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageCurve_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageCurve_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageCurve_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelX0;
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.Label labelY2;
        private System.Windows.Forms.Label labelY1;
        private System.Windows.Forms.Label labelY0;
        private System.Windows.Forms.Label labelPt1;
        private System.Windows.Forms.Label labelPt3;
        private System.Windows.Forms.Label labelPt2;
    }
}
