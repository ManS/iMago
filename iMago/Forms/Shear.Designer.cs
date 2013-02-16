namespace iMago
{
    partial class Shear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shear));
            this.TheFactor_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Factor_txt = new DevExpress.XtraEditors.TextEdit();
            this.Apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Axis_Combo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Axis_lbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Factor_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Axis_Combo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TheFactor_lbl
            // 
            this.TheFactor_lbl.Location = new System.Drawing.Point(8, 35);
            this.TheFactor_lbl.Name = "TheFactor_lbl";
            this.TheFactor_lbl.Size = new System.Drawing.Size(31, 13);
            this.TheFactor_lbl.TabIndex = 0;
            this.TheFactor_lbl.Text = "Factor";
            // 
            // Factor_txt
            // 
            this.Factor_txt.Location = new System.Drawing.Point(73, 33);
            this.Factor_txt.Name = "Factor_txt";
            this.Factor_txt.Size = new System.Drawing.Size(121, 19);
            this.Factor_txt.TabIndex = 2;
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(38, 58);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(76, 27);
            this.Apply_btn.TabIndex = 4;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(118, 58);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(76, 27);
            this.Cancel_btn.TabIndex = 5;
            this.Cancel_btn.Text = "Cancel";
            // 
            // Axis_Combo
            // 
            this.Axis_Combo.Location = new System.Drawing.Point(73, 9);
            this.Axis_Combo.Name = "Axis_Combo";
            this.Axis_Combo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Axis_Combo.Properties.Items.AddRange(new object[] {
            "X-axis",
            "Y-axis"});
            this.Axis_Combo.Size = new System.Drawing.Size(121, 19);
            this.Axis_Combo.TabIndex = 7;
            // 
            // Axis_lbl
            // 
            this.Axis_lbl.Location = new System.Drawing.Point(9, 11);
            this.Axis_lbl.Name = "Axis_lbl";
            this.Axis_lbl.Size = new System.Drawing.Size(20, 13);
            this.Axis_lbl.TabIndex = 8;
            this.Axis_lbl.Text = "Axis";
            // 
            // Shear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 93);
            this.Controls.Add(this.Axis_lbl);
            this.Controls.Add(this.Axis_Combo);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.Factor_txt);
            this.Controls.Add(this.TheFactor_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Shear";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shear";
            ((System.ComponentModel.ISupportInitialize)(this.Factor_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Axis_Combo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl TheFactor_lbl;
        private DevExpress.XtraEditors.TextEdit Factor_txt;
        private DevExpress.XtraEditors.SimpleButton Apply_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private DevExpress.XtraEditors.ComboBoxEdit Axis_Combo;
        private DevExpress.XtraEditors.LabelControl Axis_lbl;
    }
}