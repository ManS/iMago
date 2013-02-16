namespace iMago.Forms
{
    partial class Slicing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Slicing));
            this.minOldLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.OkButton = new DevExpress.XtraEditors.SimpleButton();
            this.parameters_gb = new DevExpress.XtraEditors.GroupControl();
            this.NewValueTextBox = new DevExpress.XtraEditors.TextEdit();
            this.maxOldTextBox = new DevExpress.XtraEditors.TextEdit();
            this.minOldTextBox = new DevExpress.XtraEditors.TextEdit();
            this.cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.parameters_gb)).BeginInit();
            this.parameters_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewValueTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxOldTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minOldTextBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // minOldLabel
            // 
            this.minOldLabel.Location = new System.Drawing.Point(5, 26);
            this.minOldLabel.Name = "minOldLabel";
            this.minOldLabel.Size = new System.Drawing.Size(32, 13);
            this.minOldLabel.TabIndex = 0;
            this.minOldLabel.Text = "minOld";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "maxOld";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "New Value";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(52, 128);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "OK";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // parameters_gb
            // 
            this.parameters_gb.Controls.Add(this.NewValueTextBox);
            this.parameters_gb.Controls.Add(this.maxOldTextBox);
            this.parameters_gb.Controls.Add(this.minOldTextBox);
            this.parameters_gb.Controls.Add(this.labelControl3);
            this.parameters_gb.Controls.Add(this.labelControl2);
            this.parameters_gb.Controls.Add(this.minOldLabel);
            this.parameters_gb.Location = new System.Drawing.Point(1, 3);
            this.parameters_gb.Name = "parameters_gb";
            this.parameters_gb.Size = new System.Drawing.Size(208, 119);
            this.parameters_gb.TabIndex = 7;
            this.parameters_gb.Text = "Parameters";
            // 
            // NewValueTextBox
            // 
            this.NewValueTextBox.Location = new System.Drawing.Point(103, 87);
            this.NewValueTextBox.Name = "NewValueTextBox";
            this.NewValueTextBox.Size = new System.Drawing.Size(100, 19);
            this.NewValueTextBox.TabIndex = 5;
            // 
            // maxOldTextBox
            // 
            this.maxOldTextBox.Location = new System.Drawing.Point(103, 55);
            this.maxOldTextBox.Name = "maxOldTextBox";
            this.maxOldTextBox.Size = new System.Drawing.Size(100, 19);
            this.maxOldTextBox.TabIndex = 4;
            // 
            // minOldTextBox
            // 
            this.minOldTextBox.Location = new System.Drawing.Point(103, 24);
            this.minOldTextBox.Name = "minOldTextBox";
            this.minOldTextBox.Size = new System.Drawing.Size(100, 19);
            this.minOldTextBox.TabIndex = 3;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(134, 128);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // Slicing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 158);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.parameters_gb);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Slicing";
            this.Text = "Slicing";
            ((System.ComponentModel.ISupportInitialize)(this.parameters_gb)).EndInit();
            this.parameters_gb.ResumeLayout(false);
            this.parameters_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewValueTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxOldTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minOldTextBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl minOldLabel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton OkButton;
        private DevExpress.XtraEditors.GroupControl parameters_gb;
        private DevExpress.XtraEditors.SimpleButton cancel_btn;
        private DevExpress.XtraEditors.TextEdit NewValueTextBox;
        private DevExpress.XtraEditors.TextEdit maxOldTextBox;
        private DevExpress.XtraEditors.TextEdit minOldTextBox;
    }
}