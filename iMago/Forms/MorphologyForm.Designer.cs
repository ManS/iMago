namespace iMago
{
    partial class MorphologyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MorphologyForm));
            this.Modified_grp = new DevExpress.XtraEditors.GroupControl();
            this.ModifiedpictureBox = new System.Windows.Forms.PictureBox();
            this.Original_grp = new DevExpress.XtraEditors.GroupControl();
            this.OriginalpictureBox = new System.Windows.Forms.PictureBox();
            this.Width_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Height_lbl = new DevExpress.XtraEditors.LabelControl();
            this.OriginX_lbl = new DevExpress.XtraEditors.LabelControl();
            this.OriginY_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Width_txt = new DevExpress.XtraEditors.TextEdit();
            this.Height_txt = new DevExpress.XtraEditors.TextEdit();
            this.OriginX_txt = new DevExpress.XtraEditors.TextEdit();
            this.OriginY_txt = new DevExpress.XtraEditors.TextEdit();
            this.MakeMaskButton = new DevExpress.XtraEditors.SimpleButton();
            this.SE_grp = new DevExpress.XtraEditors.GroupControl();
            this.H_txt = new DevExpress.XtraEditors.TextEdit();
            this.R_txt = new DevExpress.XtraEditors.TextEdit();
            this.H_lbl = new DevExpress.XtraEditors.LabelControl();
            this.R_lbl = new DevExpress.XtraEditors.LabelControl();
            this.Circle_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Triangle_btn = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new iMago.GridArrayInt();
            this.Apply_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Load_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Save_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).BeginInit();
            this.Modified_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).BeginInit();
            this.Original_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginX_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginY_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SE_grp)).BeginInit();
            this.SE_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.H_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_txt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Modified_grp
            // 
            this.Modified_grp.Controls.Add(this.ModifiedpictureBox);
            this.Modified_grp.Location = new System.Drawing.Point(333, 11);
            this.Modified_grp.Name = "Modified_grp";
            this.Modified_grp.Size = new System.Drawing.Size(309, 269);
            this.Modified_grp.TabIndex = 0;
            this.Modified_grp.Text = "Modified";
            // 
            // ModifiedpictureBox
            // 
            this.ModifiedpictureBox.Location = new System.Drawing.Point(4, 24);
            this.ModifiedpictureBox.Name = "ModifiedpictureBox";
            this.ModifiedpictureBox.Size = new System.Drawing.Size(301, 238);
            this.ModifiedpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ModifiedpictureBox.TabIndex = 1;
            this.ModifiedpictureBox.TabStop = false;
            // 
            // Original_grp
            // 
            this.Original_grp.Controls.Add(this.OriginalpictureBox);
            this.Original_grp.Location = new System.Drawing.Point(9, 11);
            this.Original_grp.Name = "Original_grp";
            this.Original_grp.Size = new System.Drawing.Size(309, 269);
            this.Original_grp.TabIndex = 1;
            this.Original_grp.Text = "Original";
            // 
            // OriginalpictureBox
            // 
            this.OriginalpictureBox.Location = new System.Drawing.Point(3, 25);
            this.OriginalpictureBox.Name = "OriginalpictureBox";
            this.OriginalpictureBox.Size = new System.Drawing.Size(301, 238);
            this.OriginalpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalpictureBox.TabIndex = 0;
            this.OriginalpictureBox.TabStop = false;
            // 
            // Width_lbl
            // 
            this.Width_lbl.Location = new System.Drawing.Point(13, 27);
            this.Width_lbl.Name = "Width_lbl";
            this.Width_lbl.Size = new System.Drawing.Size(28, 13);
            this.Width_lbl.TabIndex = 2;
            this.Width_lbl.Text = "Width";
            // 
            // Height_lbl
            // 
            this.Height_lbl.Location = new System.Drawing.Point(13, 48);
            this.Height_lbl.Name = "Height_lbl";
            this.Height_lbl.Size = new System.Drawing.Size(31, 13);
            this.Height_lbl.TabIndex = 3;
            this.Height_lbl.Text = "Height";
            // 
            // OriginX_lbl
            // 
            this.OriginX_lbl.Location = new System.Drawing.Point(13, 81);
            this.OriginX_lbl.Name = "OriginX_lbl";
            this.OriginX_lbl.Size = new System.Drawing.Size(37, 13);
            this.OriginX_lbl.TabIndex = 4;
            this.OriginX_lbl.Text = "Origin X";
            // 
            // OriginY_lbl
            // 
            this.OriginY_lbl.Location = new System.Drawing.Point(13, 102);
            this.OriginY_lbl.Name = "OriginY_lbl";
            this.OriginY_lbl.Size = new System.Drawing.Size(37, 13);
            this.OriginY_lbl.TabIndex = 5;
            this.OriginY_lbl.Text = "Origin Y";
            // 
            // Width_txt
            // 
            this.Width_txt.Location = new System.Drawing.Point(93, 25);
            this.Width_txt.Name = "Width_txt";
            this.Width_txt.Size = new System.Drawing.Size(100, 19);
            this.Width_txt.TabIndex = 6;
            // 
            // Height_txt
            // 
            this.Height_txt.Location = new System.Drawing.Point(93, 46);
            this.Height_txt.Name = "Height_txt";
            this.Height_txt.Size = new System.Drawing.Size(100, 19);
            this.Height_txt.TabIndex = 7;
            // 
            // OriginX_txt
            // 
            this.OriginX_txt.Location = new System.Drawing.Point(93, 79);
            this.OriginX_txt.Name = "OriginX_txt";
            this.OriginX_txt.Size = new System.Drawing.Size(100, 19);
            this.OriginX_txt.TabIndex = 8;
            // 
            // OriginY_txt
            // 
            this.OriginY_txt.Location = new System.Drawing.Point(93, 100);
            this.OriginY_txt.Name = "OriginY_txt";
            this.OriginY_txt.Size = new System.Drawing.Size(100, 19);
            this.OriginY_txt.TabIndex = 9;
            // 
            // MakeMaskButton
            // 
            this.MakeMaskButton.Location = new System.Drawing.Point(13, 127);
            this.MakeMaskButton.Name = "MakeMaskButton";
            this.MakeMaskButton.Size = new System.Drawing.Size(179, 25);
            this.MakeMaskButton.TabIndex = 10;
            this.MakeMaskButton.Text = "Make the SE";
            this.MakeMaskButton.Click += new System.EventHandler(this.MakeMaskButton_Click);
            // 
            // SE_grp
            // 
            this.SE_grp.Controls.Add(this.H_txt);
            this.SE_grp.Controls.Add(this.R_txt);
            this.SE_grp.Controls.Add(this.H_lbl);
            this.SE_grp.Controls.Add(this.R_lbl);
            this.SE_grp.Controls.Add(this.Circle_btn);
            this.SE_grp.Controls.Add(this.Triangle_btn);
            this.SE_grp.Controls.Add(this.grid);
            this.SE_grp.Controls.Add(this.MakeMaskButton);
            this.SE_grp.Controls.Add(this.OriginY_txt);
            this.SE_grp.Controls.Add(this.OriginX_txt);
            this.SE_grp.Controls.Add(this.Height_txt);
            this.SE_grp.Controls.Add(this.Width_txt);
            this.SE_grp.Controls.Add(this.OriginY_lbl);
            this.SE_grp.Controls.Add(this.OriginX_lbl);
            this.SE_grp.Controls.Add(this.Height_lbl);
            this.SE_grp.Controls.Add(this.Width_lbl);
            this.SE_grp.Location = new System.Drawing.Point(9, 285);
            this.SE_grp.Name = "SE_grp";
            this.SE_grp.Size = new System.Drawing.Size(505, 271);
            this.SE_grp.TabIndex = 12;
            this.SE_grp.Text = "SE";
            // 
            // H_txt
            // 
            this.H_txt.Location = new System.Drawing.Point(136, 246);
            this.H_txt.Name = "H_txt";
            this.H_txt.Size = new System.Drawing.Size(54, 19);
            this.H_txt.TabIndex = 22;
            // 
            // R_txt
            // 
            this.R_txt.Location = new System.Drawing.Point(34, 246);
            this.R_txt.Name = "R_txt";
            this.R_txt.Size = new System.Drawing.Size(54, 19);
            this.R_txt.TabIndex = 21;
            // 
            // H_lbl
            // 
            this.H_lbl.Location = new System.Drawing.Point(119, 249);
            this.H_lbl.Name = "H_lbl";
            this.H_lbl.Size = new System.Drawing.Size(7, 13);
            this.H_lbl.TabIndex = 20;
            this.H_lbl.Text = "H";
            // 
            // R_lbl
            // 
            this.R_lbl.Location = new System.Drawing.Point(20, 249);
            this.R_lbl.Name = "R_lbl";
            this.R_lbl.Size = new System.Drawing.Size(7, 13);
            this.R_lbl.TabIndex = 19;
            this.R_lbl.Text = "R";
            // 
            // Circle_btn
            // 
            this.Circle_btn.Image = global::iMago.Properties.Resources.circle;
            this.Circle_btn.Location = new System.Drawing.Point(13, 160);
            this.Circle_btn.Name = "Circle_btn";
            this.Circle_btn.Size = new System.Drawing.Size(76, 78);
            this.Circle_btn.TabIndex = 18;
            this.Circle_btn.Click += new System.EventHandler(this.Circle_btn_Click);
            // 
            // Triangle_btn
            // 
            this.Triangle_btn.Image = global::iMago.Properties.Resources.triangle;
            this.Triangle_btn.Location = new System.Drawing.Point(115, 161);
            this.Triangle_btn.Name = "Triangle_btn";
            this.Triangle_btn.Size = new System.Drawing.Size(77, 78);
            this.Triangle_btn.TabIndex = 17;
            this.Triangle_btn.Click += new System.EventHandler(this.Triangle_btn_Click);
            // 
            // grid
            // 
            this.grid.AutoSizeMinHeight = 10;
            this.grid.AutoSizeMinWidth = 10;
            this.grid.AutoStretchColumnsToFitWidth = false;
            this.grid.AutoStretchRowsToFitHeight = false;
            this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
            this.grid.CustomSort = false;
            this.grid.GridToolTipActive = true;
            this.grid.Location = new System.Drawing.Point(216, 28);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(275, 238);
            this.grid.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V)
                        | SourceGrid2.GridSpecialKeys.Ctrl_X)
                        | SourceGrid2.GridSpecialKeys.Delete)
                        | SourceGrid2.GridSpecialKeys.Arrows)
                        | SourceGrid2.GridSpecialKeys.Tab)
                        | SourceGrid2.GridSpecialKeys.PageDownUp)
                        | SourceGrid2.GridSpecialKeys.Enter)
                        | SourceGrid2.GridSpecialKeys.Escape)
                        | SourceGrid2.GridSpecialKeys.Control)
                        | SourceGrid2.GridSpecialKeys.Shift)));
            this.grid.TabIndex = 16;
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(529, 383);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(105, 33);
            this.Apply_btn.TabIndex = 13;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(529, 421);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(105, 33);
            this.Ok_btn.TabIndex = 14;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(529, 460);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(105, 33);
            this.Cancel_btn.TabIndex = 15;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Load_btn
            // 
            this.Load_btn.Location = new System.Drawing.Point(529, 305);
            this.Load_btn.Name = "Load_btn";
            this.Load_btn.Size = new System.Drawing.Size(105, 33);
            this.Load_btn.TabIndex = 16;
            this.Load_btn.Text = "Load SE";
            this.Load_btn.Click += new System.EventHandler(this.Load_btn_Click);
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(529, 344);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(105, 33);
            this.Save_btn.TabIndex = 17;
            this.Save_btn.Text = "Save SE";
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // MorphologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 563);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Load_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.SE_grp);
            this.Controls.Add(this.Original_grp);
            this.Controls.Add(this.Modified_grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MorphologyForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Morphology";
            ((System.ComponentModel.ISupportInitialize)(this.Modified_grp)).EndInit();
            this.Modified_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_grp)).EndInit();
            this.Original_grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Height_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginX_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginY_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SE_grp)).EndInit();
            this.SE_grp.ResumeLayout(false);
            this.SE_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.H_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R_txt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Modified_grp;
        private System.Windows.Forms.PictureBox ModifiedpictureBox;
        private DevExpress.XtraEditors.GroupControl Original_grp;
        private System.Windows.Forms.PictureBox OriginalpictureBox;
        private DevExpress.XtraEditors.LabelControl Width_lbl;
        private DevExpress.XtraEditors.LabelControl Height_lbl;
        private DevExpress.XtraEditors.LabelControl OriginX_lbl;
        private DevExpress.XtraEditors.LabelControl OriginY_lbl;
        private DevExpress.XtraEditors.TextEdit Width_txt;
        private DevExpress.XtraEditors.TextEdit Height_txt;
        private DevExpress.XtraEditors.TextEdit OriginX_txt;
        private DevExpress.XtraEditors.TextEdit OriginY_txt;
        private DevExpress.XtraEditors.SimpleButton MakeMaskButton;
        private DevExpress.XtraEditors.GroupControl SE_grp;
        private DevExpress.XtraEditors.SimpleButton Apply_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private GridArrayInt grid;//khalas sebny ashelhom ana :D:D tyb okaz ;d
        private DevExpress.XtraEditors.SimpleButton Circle_btn;
        private DevExpress.XtraEditors.SimpleButton Triangle_btn;
        private DevExpress.XtraEditors.TextEdit H_txt;
        private DevExpress.XtraEditors.TextEdit R_txt;
        private DevExpress.XtraEditors.LabelControl H_lbl;
        private DevExpress.XtraEditors.LabelControl R_lbl;
        private DevExpress.XtraEditors.SimpleButton Load_btn; 
        private DevExpress.XtraEditors.SimpleButton Save_btn;//brb//hwa ana shelt haga bs msh fakra eeeeeeeee l2 3di :D
    }
}