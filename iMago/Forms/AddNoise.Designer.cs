namespace iMago
{
    partial class AddNoise
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
            this.A_txt = new DevExpress.XtraEditors.TextEdit();
            this.b_txt = new DevExpress.XtraEditors.TextEdit();
            this.Nois_txt = new DevExpress.XtraEditors.TextEdit();
            this.A_lbl = new DevExpress.XtraEditors.LabelControl();
            this.B_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Nois_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Pr_lvl = new DevExpress.XtraEditors.LabelControl();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.A_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nois_txt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // A_txt
            // 
            this.A_txt.Location = new System.Drawing.Point(98, 7);
            this.A_txt.Name = "A_txt";
            this.A_txt.Size = new System.Drawing.Size(59, 20);
            this.A_txt.TabIndex = 0;
            // 
            // b_txt
            // 
            this.b_txt.Location = new System.Drawing.Point(98, 32);
            this.b_txt.Name = "b_txt";
            this.b_txt.Size = new System.Drawing.Size(59, 20);
            this.b_txt.TabIndex = 1;
            // 
            // Nois_txt
            // 
            this.Nois_txt.Location = new System.Drawing.Point(98, 57);
            this.Nois_txt.Name = "Nois_txt";
            this.Nois_txt.Size = new System.Drawing.Size(59, 20);
            this.Nois_txt.TabIndex = 2;
            // 
            // A_lbl
            // 
            this.A_lbl.Location = new System.Drawing.Point(25, 10);
            this.A_lbl.Name = "A_lbl";
            this.A_lbl.Size = new System.Drawing.Size(7, 13);
            this.A_lbl.TabIndex = 3;
            this.A_lbl.Text = "A";
            // 
            // B_lbl
            // 
            this.B_lbl.Location = new System.Drawing.Point(25, 35);
            this.B_lbl.Name = "B_lbl";
            this.B_lbl.Size = new System.Drawing.Size(6, 13);
            this.B_lbl.TabIndex = 4;
            this.B_lbl.Text = "B";
            // 
            // Nois_lbl
            // 
            this.Nois_lbl.Location = new System.Drawing.Point(25, 60);
            this.Nois_lbl.Name = "Nois_lbl";
            this.Nois_lbl.Size = new System.Drawing.Size(26, 13);
            this.Nois_lbl.TabIndex = 5;
            this.Nois_lbl.Text = "Noise";
            // 
            // Pr_lvl
            // 
            this.Pr_lvl.Location = new System.Drawing.Point(163, 60);
            this.Pr_lvl.Name = "Pr_lvl";
            this.Pr_lvl.Size = new System.Drawing.Size(11, 13);
            this.Pr_lvl.TabIndex = 6;
            this.Pr_lvl.Text = "%";
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(81, 92);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(76, 31);
            this.Ok_btn.TabIndex = 7;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(163, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "[ probability ]";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(163, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "[ probability ]";
            // 
            // AddNoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 125);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Pr_lvl);
            this.Controls.Add(this.Nois_lbl);
            this.Controls.Add(this.B_lbl);
            this.Controls.Add(this.A_lbl);
            this.Controls.Add(this.Nois_txt);
            this.Controls.Add(this.b_txt);
            this.Controls.Add(this.A_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNoise";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Noise";
            ((System.ComponentModel.ISupportInitialize)(this.A_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nois_txt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit A_txt;
        private DevExpress.XtraEditors.TextEdit b_txt;
        private DevExpress.XtraEditors.TextEdit Nois_txt;
        private DevExpress.XtraEditors.LabelControl A_lbl;
        private DevExpress.XtraEditors.LabelControl B_lbl;
        private DevExpress.XtraEditors.LabelControl Nois_lbl;
        private DevExpress.XtraEditors.LabelControl Pr_lvl;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
    }
}