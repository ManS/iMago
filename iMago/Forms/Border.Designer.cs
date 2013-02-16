using iMago.Forms;
namespace iMago.Forms
{
    partial class Border
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Border));
            this.imageSourcePictureBox = new System.Windows.Forms.PictureBox();
            this.imageDestinationPictureBox = new System.Windows.Forms.PictureBox();
            this.ApplyButton = new DevExpress.XtraEditors.SimpleButton();
            this.OkButton = new DevExpress.XtraEditors.SimpleButton();
            this.CancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.bordersComboBox = new iMago.Forms.ImgCbo();
            ((System.ComponentModel.ISupportInitialize)(this.imageSourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDestinationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageSourcePictureBox
            // 
            this.imageSourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageSourcePictureBox.Location = new System.Drawing.Point(9, 12);
            this.imageSourcePictureBox.Name = "imageSourcePictureBox";
            this.imageSourcePictureBox.Size = new System.Drawing.Size(258, 214);
            this.imageSourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageSourcePictureBox.TabIndex = 0;
            this.imageSourcePictureBox.TabStop = false;
            // 
            // imageDestinationPictureBox
            // 
            this.imageDestinationPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageDestinationPictureBox.Location = new System.Drawing.Point(273, 12);
            this.imageDestinationPictureBox.Name = "imageDestinationPictureBox";
            this.imageDestinationPictureBox.Size = new System.Drawing.Size(258, 214);
            this.imageDestinationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageDestinationPictureBox.TabIndex = 1;
            this.imageDestinationPictureBox.TabStop = false;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(146, 233);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(110, 35);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(146, 274);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(110, 35);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(146, 315);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(110, 35);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // bordersComboBox
            // 
            this.bordersComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bordersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bordersComboBox.FormattingEnabled = true;
            this.bordersComboBox.ItemHeight = 100;
            this.bordersComboBox.Location = new System.Drawing.Point(12, 233);
            this.bordersComboBox.Margin = new System.Windows.Forms.Padding(100);
            this.bordersComboBox.MaximumSize = new System.Drawing.Size(258, 0);
            this.bordersComboBox.Name = "bordersComboBox";
            this.bordersComboBox.Size = new System.Drawing.Size(125, 106);
            this.bordersComboBox.TabIndex = 2;
            // 
            // Border
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 357);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.bordersComboBox);
            this.Controls.Add(this.imageDestinationPictureBox);
            this.Controls.Add(this.imageSourcePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Border";
            this.Text = "Border";
            this.Load += new System.EventHandler(this.Border_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageSourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDestinationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageSourcePictureBox;
        private System.Windows.Forms.PictureBox imageDestinationPictureBox;
        private ImgCbo bordersComboBox;
        private DevExpress.XtraEditors.SimpleButton ApplyButton;
        private DevExpress.XtraEditors.SimpleButton OkButton;
        private DevExpress.XtraEditors.SimpleButton CancelButton;
    }
}