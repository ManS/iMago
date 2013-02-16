namespace ImageProcessingAssignment1
{
    partial class TimeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TestNameLBL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RunTimeLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Square721 BT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "We are Testing:";
            // 
            // TestNameLBL
            // 
            this.TestNameLBL.AutoSize = true;
            this.TestNameLBL.Font = new System.Drawing.Font("Square721 BT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestNameLBL.ForeColor = System.Drawing.Color.Snow;
            this.TestNameLBL.Location = new System.Drawing.Point(293, 22);
            this.TestNameLBL.Name = "TestNameLBL";
            this.TestNameLBL.Size = new System.Drawing.Size(396, 40);
            this.TestNameLBL.TabIndex = 1;
            this.TestNameLBL.Text = "What we are testing...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Square721 BT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time:";
            // 
            // RunTimeLBL
            // 
            this.RunTimeLBL.AutoSize = true;
            this.RunTimeLBL.Font = new System.Drawing.Font("Square721 BT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunTimeLBL.ForeColor = System.Drawing.Color.Snow;
            this.RunTimeLBL.Location = new System.Drawing.Point(293, 89);
            this.RunTimeLBL.Name = "RunTimeLBL";
            this.RunTimeLBL.Size = new System.Drawing.Size(127, 40);
            this.RunTimeLBL.TabIndex = 3;
            this.RunTimeLBL.Text = "Time...";
            // 
            // TimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(701, 153);
            this.Controls.Add(this.RunTimeLBL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TestNameLBL);
            this.Controls.Add(this.label1);
            this.Name = "TimeForm";
            this.Text = "Time View";
            this.Load += new System.EventHandler(this.TimeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TestNameLBL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RunTimeLBL;
    }
}