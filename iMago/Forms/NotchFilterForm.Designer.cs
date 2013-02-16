namespace iMago.Forms
{
    partial class NotchFilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotchFilterForm));
            this.Options = new DevExpress.XtraEditors.GroupControl();
            this.N_Group = new DevExpress.XtraEditors.GroupControl();
            this.N_updown = new DevExpress.XtraEditors.SpinEdit();
            this.N_seeker = new DevExpress.XtraEditors.TrackBarControl();
            this.Radius_Group = new DevExpress.XtraEditors.GroupControl();
            this.Radius_updown = new DevExpress.XtraEditors.SpinEdit();
            this.Radius_seeker = new DevExpress.XtraEditors.TrackBarControl();
            this.Filter = new DevExpress.XtraEditors.GroupControl();
            this.Filter_radioBox = new DevExpress.XtraEditors.RadioGroup();
            this.FilterType = new DevExpress.XtraEditors.GroupControl();
            this.FilterType_combBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Preview = new DevExpress.XtraEditors.GroupControl();
            this.Preview_radioBox = new DevExpress.XtraEditors.RadioGroup();
            this.Preview_panel = new System.Windows.Forms.Panel();
            this.Preview_picbox = new System.Windows.Forms.PictureBox();
            this.Cancel_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Ok_btn = new DevExpress.XtraEditors.SimpleButton();
            this.Apply_btn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Options)).BeginInit();
            this.Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.N_Group)).BeginInit();
            this.N_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.N_updown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_seeker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_seeker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_Group)).BeginInit();
            this.Radius_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_updown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_seeker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_seeker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter)).BeginInit();
            this.Filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_radioBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterType)).BeginInit();
            this.FilterType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilterType_combBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            this.Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_radioBox.Properties)).BeginInit();
            this.Preview_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // Options
            // 
            this.Options.Controls.Add(this.N_Group);
            this.Options.Controls.Add(this.Radius_Group);
            this.Options.Controls.Add(this.Filter);
            this.Options.Controls.Add(this.FilterType);
            this.Options.Controls.Add(this.Preview);
            this.Options.Location = new System.Drawing.Point(582, 10);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(191, 412);
            this.Options.TabIndex = 3;
            this.Options.Text = "Options";
            // 
            // N_Group
            // 
            this.N_Group.Controls.Add(this.N_updown);
            this.N_Group.Controls.Add(this.N_seeker);
            this.N_Group.Location = new System.Drawing.Point(7, 345);
            this.N_Group.Name = "N_Group";
            this.N_Group.Size = new System.Drawing.Size(179, 60);
            this.N_Group.TabIndex = 3;
            this.N_Group.Text = "N";
            // 
            // N_updown
            // 
            this.N_updown.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.N_updown.Location = new System.Drawing.Point(131, 26);
            this.N_updown.Name = "N_updown";
            this.N_updown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.N_updown.Size = new System.Drawing.Size(40, 19);
            this.N_updown.TabIndex = 1;
            this.N_updown.EditValueChanged += new System.EventHandler(this.N_updown_EditValueChanged);
            // 
            // N_seeker
            // 
            this.N_seeker.EditValue = null;
            this.N_seeker.Location = new System.Drawing.Point(3, 24);
            this.N_seeker.Name = "N_seeker";
            this.N_seeker.Size = new System.Drawing.Size(123, 45);
            this.N_seeker.TabIndex = 0;
            this.N_seeker.EditValueChanged += new System.EventHandler(this.N_seeker_Scroll);
            // 
            // Radius_Group
            // 
            this.Radius_Group.Controls.Add(this.Radius_updown);
            this.Radius_Group.Controls.Add(this.Radius_seeker);
            this.Radius_Group.Location = new System.Drawing.Point(7, 279);
            this.Radius_Group.Name = "Radius_Group";
            this.Radius_Group.Size = new System.Drawing.Size(179, 60);
            this.Radius_Group.TabIndex = 2;
            this.Radius_Group.Text = "Radius";
            // 
            // Radius_updown
            // 
            this.Radius_updown.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Radius_updown.Location = new System.Drawing.Point(131, 26);
            this.Radius_updown.Name = "Radius_updown";
            this.Radius_updown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Radius_updown.Size = new System.Drawing.Size(40, 19);
            this.Radius_updown.TabIndex = 1;
            this.Radius_updown.EditValueChanged += new System.EventHandler(this.Radius_updown_EditValueChanged);
            // 
            // Radius_seeker
            // 
            this.Radius_seeker.EditValue = null;
            this.Radius_seeker.Location = new System.Drawing.Point(3, 24);
            this.Radius_seeker.Name = "Radius_seeker";
            this.Radius_seeker.Size = new System.Drawing.Size(123, 45);
            this.Radius_seeker.TabIndex = 0;
            this.Radius_seeker.EditValueChanged += new System.EventHandler(this.Radius_seeker_Scroll);
            // 
            // Filter
            // 
            this.Filter.Controls.Add(this.Filter_radioBox);
            this.Filter.Location = new System.Drawing.Point(7, 179);
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(179, 94);
            this.Filter.TabIndex = 1;
            this.Filter.Text = "Filter";
            // 
            // Filter_radioBox
            // 
            this.Filter_radioBox.Location = new System.Drawing.Point(6, 22);
            this.Filter_radioBox.Name = "Filter_radioBox";
            this.Filter_radioBox.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Ideal Filter"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Butterworth Filter"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Gaussian Filter")});
            this.Filter_radioBox.Size = new System.Drawing.Size(165, 67);
            this.Filter_radioBox.TabIndex = 0;
            this.Filter_radioBox.SelectedIndexChanged += new System.EventHandler(this.FilterName_CheckedChanged);
            // 
            // FilterType
            // 
            this.FilterType.Controls.Add(this.FilterType_combBox);
            this.FilterType.Location = new System.Drawing.Point(7, 122);
            this.FilterType.Name = "FilterType";
            this.FilterType.Size = new System.Drawing.Size(179, 52);
            this.FilterType.TabIndex = 1;
            this.FilterType.Text = "Filter Type";
            // 
            // FilterType_combBox
            // 
            this.FilterType_combBox.Location = new System.Drawing.Point(6, 25);
            this.FilterType_combBox.Name = "FilterType_combBox";
            this.FilterType_combBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FilterType_combBox.Properties.Items.AddRange(new object[] {
            "Notch Pass",
            "Notch Reject"});
            this.FilterType_combBox.Size = new System.Drawing.Size(168, 19);
            this.FilterType_combBox.TabIndex = 0;
            this.FilterType_combBox.SelectedIndexChanged += new System.EventHandler(this.FilterType_combBox_SelectedIndexChanged);
            // 
            // Preview
            // 
            this.Preview.Controls.Add(this.Preview_radioBox);
            this.Preview.Location = new System.Drawing.Point(7, 24);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(179, 94);
            this.Preview.TabIndex = 0;
            this.Preview.Text = "Preview";
            // 
            // Preview_radioBox
            // 
            this.Preview_radioBox.Location = new System.Drawing.Point(5, 22);
            this.Preview_radioBox.Name = "Preview_radioBox";
            this.Preview_radioBox.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Mask Preview"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Fourier Image"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Filtered Image")});
            this.Preview_radioBox.Size = new System.Drawing.Size(165, 67);
            this.Preview_radioBox.TabIndex = 1;
            this.Preview_radioBox.SelectedIndexChanged += new System.EventHandler(this.Preview_CheckedChanged);
            // 
            // Preview_panel
            // 
            this.Preview_panel.AutoScroll = true;
            this.Preview_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Preview_panel.Controls.Add(this.Preview_picbox);
            this.Preview_panel.Location = new System.Drawing.Point(0, 0);
            this.Preview_panel.Name = "Preview_panel";
            this.Preview_panel.Size = new System.Drawing.Size(522, 412);
            this.Preview_panel.TabIndex = 2;
            // 
            // Preview_picbox
            // 
            this.Preview_picbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Preview_picbox.Location = new System.Drawing.Point(21, 15);
            this.Preview_picbox.Name = "Preview_picbox";
            this.Preview_picbox.Size = new System.Drawing.Size(480, 375);
            this.Preview_picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Preview_picbox.TabIndex = 1;
            this.Preview_picbox.TabStop = false;
            this.Preview_picbox.Click += new System.EventHandler(this.Preview_picbox_Click);
            this.Preview_picbox.MouseLeave += new System.EventHandler(this.Preview_picbox_MouseLeave);
            this.Preview_picbox.MouseHover += new System.EventHandler(this.Preview_picbox_MouseHover);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(676, 493);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(92, 23);
            this.Cancel_btn.TabIndex = 7;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Location = new System.Drawing.Point(676, 464);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(92, 23);
            this.Ok_btn.TabIndex = 6;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Apply_btn
            // 
            this.Apply_btn.Location = new System.Drawing.Point(676, 435);
            this.Apply_btn.Name = "Apply_btn";
            this.Apply_btn.Size = new System.Drawing.Size(92, 23);
            this.Apply_btn.TabIndex = 5;
            this.Apply_btn.Text = "Apply";
            this.Apply_btn.Click += new System.EventHandler(this.Apply_btn_Click);
            // 
            // NotchFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 530);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Apply_btn);
            this.Controls.Add(this.Options);
            this.Controls.Add(this.Preview_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NotchFilterForm";
            this.Text = "Notch Filter";
            ((System.ComponentModel.ISupportInitialize)(this.Options)).EndInit();
            this.Options.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.N_Group)).EndInit();
            this.N_Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.N_updown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_seeker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_seeker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_Group)).EndInit();
            this.Radius_Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Radius_updown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_seeker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Radius_seeker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter)).EndInit();
            this.Filter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Filter_radioBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilterType)).EndInit();
            this.FilterType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilterType_combBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            this.Preview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Preview_radioBox.Properties)).EndInit();
            this.Preview_panel.ResumeLayout(false);
            this.Preview_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_picbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl Options;
        private DevExpress.XtraEditors.GroupControl N_Group;
        private DevExpress.XtraEditors.SpinEdit N_updown;
        private DevExpress.XtraEditors.TrackBarControl N_seeker;
        private DevExpress.XtraEditors.GroupControl Radius_Group;
        private DevExpress.XtraEditors.SpinEdit Radius_updown;
        private DevExpress.XtraEditors.TrackBarControl Radius_seeker;
        private DevExpress.XtraEditors.GroupControl Filter;
        private DevExpress.XtraEditors.RadioGroup Filter_radioBox;
        private DevExpress.XtraEditors.GroupControl FilterType;
        private DevExpress.XtraEditors.ComboBoxEdit FilterType_combBox;
        private DevExpress.XtraEditors.GroupControl Preview;
        private DevExpress.XtraEditors.RadioGroup Preview_radioBox;
        private System.Windows.Forms.Panel Preview_panel;
        private System.Windows.Forms.PictureBox Preview_picbox;
        private DevExpress.XtraEditors.SimpleButton Cancel_btn;
        private DevExpress.XtraEditors.SimpleButton Ok_btn;
        private DevExpress.XtraEditors.SimpleButton Apply_btn;
    }
}