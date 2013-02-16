namespace iMago.Forms
{
    partial class QuantizeBy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuantizeBy));
            this.Min_lbl = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.QuantizeValue = new DevExpress.XtraEditors.TextEdit();
            this.Parameters = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.QuantizeValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parameters)).BeginInit();
            this.Parameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // Min_lbl
            // 
            this.Min_lbl.Location = new System.Drawing.Point(9, 27);
            this.Min_lbl.Name = "Min_lbl";
            this.Min_lbl.Size = new System.Drawing.Size(22, 13);
            this.Min_lbl.TabIndex = 5;
            this.Min_lbl.Text = "Bpp:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(149, 73);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Cancel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(68, 73);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "Quntize";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // QuantizeValue
            // 
            this.QuantizeValue.Location = new System.Drawing.Point(146, 24);
            this.QuantizeValue.Name = "QuantizeValue";
            this.QuantizeValue.Size = new System.Drawing.Size(75, 19);
            this.QuantizeValue.TabIndex = 8;
            // 
            // Parameters
            // 
            this.Parameters.Controls.Add(this.QuantizeValue);
            this.Parameters.Controls.Add(this.Min_lbl);
            this.Parameters.Location = new System.Drawing.Point(3, 1);
            this.Parameters.Name = "Parameters";
            this.Parameters.Size = new System.Drawing.Size(228, 66);
            this.Parameters.TabIndex = 9;
            this.Parameters.Text = "Parameters";
            // 
            // QuantizeBy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 107);
            this.Controls.Add(this.Parameters);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuantizeBy";
            this.Text = "QuantizeBy";
            ((System.ComponentModel.ISupportInitialize)(this.QuantizeValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parameters)).EndInit();
            this.Parameters.ResumeLayout(false);
            this.Parameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl Min_lbl;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit QuantizeValue;
        private DevExpress.XtraEditors.GroupControl Parameters;
    }
}