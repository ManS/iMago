namespace iMago
{
    partial class SavingFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavingFormat));
            this.Formats_grp = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Formats_grp)).BeginInit();
            this.Formats_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Formats_grp
            // 
            this.Formats_grp.Controls.Add(this.radioGroup1);
            this.Formats_grp.Location = new System.Drawing.Point(7, 6);
            this.Formats_grp.Name = "Formats_grp";
            this.Formats_grp.Size = new System.Drawing.Size(148, 174);
            this.Formats_grp.TabIndex = 0;
            this.Formats_grp.Text = "Formats";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(6, 23);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "P1 Format"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "P2 Format"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "P3 Format"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "P4 Format"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "P5 Format"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "P6 Format")});
            this.radioGroup1.Size = new System.Drawing.Size(136, 147);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(161, 6);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(63, 27);
            this.Ok_btn.TabIndex = 1;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(161, 39);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(63, 27);
            this.Cancel_btn.TabIndex = 2;
            this.Cancel_btn.Text = "Cancel";
            // 
            // SavingFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 186);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Formats_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SavingFormat";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save As";
            ((System.ComponentModel.ISupportInitialize)(this.Formats_grp)).EndInit();
            this.Formats_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Formats_grp;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
    }
}