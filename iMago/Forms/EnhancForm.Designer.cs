namespace iMago.Forms
{
    partial class EnhancForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnhancForm));
            this.WinsizeLabel = new System.Windows.Forms.Label();
            this.WinSizeTextBox = new System.Windows.Forms.TextBox();
            this.K0Label = new System.Windows.Forms.Label();
            this.K0TextBox = new System.Windows.Forms.TextBox();
            this.ETextBox = new System.Windows.Forms.TextBox();
            this.K2Label = new System.Windows.Forms.Label();
            this.K2TextBox = new System.Windows.Forms.TextBox();
            this.ELabel = new System.Windows.Forms.Label();
            this.K1TextBox = new System.Windows.Forms.TextBox();
            this.K1Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WinsizeLabel
            // 
            this.WinsizeLabel.AutoSize = true;
            this.WinsizeLabel.Location = new System.Drawing.Point(37, 26);
            this.WinsizeLabel.Name = "WinsizeLabel";
            this.WinsizeLabel.Size = new System.Drawing.Size(43, 13);
            this.WinsizeLabel.TabIndex = 0;
            this.WinsizeLabel.Text = "Winsize";
            // 
            // WinSizeTextBox
            // 
            this.WinSizeTextBox.Location = new System.Drawing.Point(110, 23);
            this.WinSizeTextBox.Name = "WinSizeTextBox";
            this.WinSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.WinSizeTextBox.TabIndex = 1;
            // 
            // K0Label
            // 
            this.K0Label.AutoSize = true;
            this.K0Label.Location = new System.Drawing.Point(37, 56);
            this.K0Label.Name = "K0Label";
            this.K0Label.Size = new System.Drawing.Size(19, 13);
            this.K0Label.TabIndex = 2;
            this.K0Label.Text = "K0";
            this.K0Label.Click += new System.EventHandler(this.K0Label_Click);
            // 
            // K0TextBox
            // 
            this.K0TextBox.Location = new System.Drawing.Point(110, 53);
            this.K0TextBox.Name = "K0TextBox";
            this.K0TextBox.Size = new System.Drawing.Size(100, 20);
            this.K0TextBox.TabIndex = 3;
            this.K0TextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ETextBox
            // 
            this.ETextBox.Location = new System.Drawing.Point(110, 137);
            this.ETextBox.Name = "ETextBox";
            this.ETextBox.Size = new System.Drawing.Size(100, 20);
            this.ETextBox.TabIndex = 5;
            // 
            // K2Label
            // 
            this.K2Label.AutoSize = true;
            this.K2Label.Location = new System.Drawing.Point(37, 112);
            this.K2Label.Name = "K2Label";
            this.K2Label.Size = new System.Drawing.Size(19, 13);
            this.K2Label.TabIndex = 4;
            this.K2Label.Text = "K2";
            // 
            // K2TextBox
            // 
            this.K2TextBox.Location = new System.Drawing.Point(110, 105);
            this.K2TextBox.Name = "K2TextBox";
            this.K2TextBox.Size = new System.Drawing.Size(100, 20);
            this.K2TextBox.TabIndex = 7;
            // 
            // ELabel
            // 
            this.ELabel.AutoSize = true;
            this.ELabel.Location = new System.Drawing.Point(37, 137);
            this.ELabel.Name = "ELabel";
            this.ELabel.Size = new System.Drawing.Size(13, 13);
            this.ELabel.TabIndex = 6;
            this.ELabel.Text = "E";
            // 
            // K1TextBox
            // 
            this.K1TextBox.Location = new System.Drawing.Point(110, 79);
            this.K1TextBox.Name = "K1TextBox";
            this.K1TextBox.Size = new System.Drawing.Size(100, 20);
            this.K1TextBox.TabIndex = 9;
            // 
            // K1Label
            // 
            this.K1Label.AutoSize = true;
            this.K1Label.Location = new System.Drawing.Point(37, 82);
            this.K1Label.Name = "K1Label";
            this.K1Label.Size = new System.Drawing.Size(19, 13);
            this.K1Label.TabIndex = 8;
            this.K1Label.Text = "K1";
            // 
            // EnhancForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 174);
            this.Controls.Add(this.K1TextBox);
            this.Controls.Add(this.K1Label);
            this.Controls.Add(this.K2TextBox);
            this.Controls.Add(this.ELabel);
            this.Controls.Add(this.ETextBox);
            this.Controls.Add(this.K2Label);
            this.Controls.Add(this.K0TextBox);
            this.Controls.Add(this.K0Label);
            this.Controls.Add(this.WinSizeTextBox);
            this.Controls.Add(this.WinsizeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnhancForm";
            this.Text = "EnhancForm";
            this.Load += new System.EventHandler(this.EnhancForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WinsizeLabel;
        private System.Windows.Forms.TextBox WinSizeTextBox;
        private System.Windows.Forms.Label K0Label;
        private System.Windows.Forms.TextBox K0TextBox;
        private System.Windows.Forms.TextBox ETextBox;
        private System.Windows.Forms.Label K2Label;
        private System.Windows.Forms.TextBox K2TextBox;
        private System.Windows.Forms.Label ELabel;
        private System.Windows.Forms.TextBox K1TextBox;
        private System.Windows.Forms.Label K1Label;
    }
}