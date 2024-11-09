namespace BuenosDias.GUII
{
    partial class NewBaiVietFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewBaiVietFrom));
            this.txt_TieuDe = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmb_KhoaHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl_addImage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_mainContent = new System.Windows.Forms.RichTextBox();
            this.btn_send = new Guna.UI2.WinForms.Guna2Button();
            this.btn_thoat = new Guna.UI2.WinForms.Guna2Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmb_fontSIze = new System.Windows.Forms.ToolStripComboBox();
            this.btn_Bold = new System.Windows.Forms.ToolStripButton();
            this.btn_Italic = new System.Windows.Forms.ToolStripButton();
            this.btn_Underline = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_TieuDe
            // 
            this.txt_TieuDe.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txt_TieuDe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TieuDe.DefaultText = "";
            this.txt_TieuDe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TieuDe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TieuDe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TieuDe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TieuDe.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txt_TieuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_TieuDe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TieuDe.Location = new System.Drawing.Point(12, 40);
            this.txt_TieuDe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TieuDe.Name = "txt_TieuDe";
            this.txt_TieuDe.PasswordChar = '\0';
            this.txt_TieuDe.PlaceholderText = "Tiêu đề bài viết";
            this.txt_TieuDe.SelectedText = "";
            this.txt_TieuDe.Size = new System.Drawing.Size(958, 48);
            this.txt_TieuDe.TabIndex = 0;
            // 
            // cmb_KhoaHoc
            // 
            this.cmb_KhoaHoc.BackColor = System.Drawing.Color.Transparent;
            this.cmb_KhoaHoc.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.cmb_KhoaHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_KhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_KhoaHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_KhoaHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmb_KhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_KhoaHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmb_KhoaHoc.ItemHeight = 30;
            this.cmb_KhoaHoc.Location = new System.Drawing.Point(672, 95);
            this.cmb_KhoaHoc.Name = "cmb_KhoaHoc";
            this.cmb_KhoaHoc.Size = new System.Drawing.Size(298, 36);
            this.cmb_KhoaHoc.TabIndex = 1;
            // 
            // lbl_addImage
            // 
            this.lbl_addImage.AutoSize = true;
            this.lbl_addImage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_addImage.Location = new System.Drawing.Point(13, 104);
            this.lbl_addImage.Name = "lbl_addImage";
            this.lbl_addImage.Size = new System.Drawing.Size(94, 16);
            this.lbl_addImage.TabIndex = 2;
            this.lbl_addImage.Text = "Thêm hình ảnh";
            this.lbl_addImage.TextChanged += new System.EventHandler(this.lbl_addImage_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Khóa học";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // rtb_mainContent
            // 
            this.rtb_mainContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_mainContent.Location = new System.Drawing.Point(16, 174);
            this.rtb_mainContent.Name = "rtb_mainContent";
            this.rtb_mainContent.Size = new System.Drawing.Size(954, 507);
            this.rtb_mainContent.TabIndex = 9;
            this.rtb_mainContent.Text = "";
            // 
            // btn_send
            // 
            this.btn_send.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_send.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_send.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_send.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_send.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_send.ForeColor = System.Drawing.Color.White;
            this.btn_send.Location = new System.Drawing.Point(672, 696);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(140, 36);
            this.btn_send.TabIndex = 14;
            this.btn_send.Text = "Gửi ";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_thoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_thoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_thoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_thoat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btn_thoat.ForeColor = System.Drawing.Color.White;
            this.btn_thoat.Location = new System.Drawing.Point(830, 696);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(140, 36);
            this.btn_thoat.TabIndex = 15;
            this.btn_thoat.Text = "Hủy";
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmb_fontSIze,
            this.btn_Bold,
            this.btn_Italic,
            this.btn_Underline});
            this.toolStrip1.Location = new System.Drawing.Point(16, 143);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(278, 31);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 28);
            this.toolStripLabel1.Text = "Cỡ chữ";
            // 
            // cmb_fontSIze
            // 
            this.cmb_fontSIze.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmb_fontSIze.Name = "cmb_fontSIze";
            this.cmb_fontSIze.Size = new System.Drawing.Size(121, 31);
            this.cmb_fontSIze.SelectedIndexChanged += new System.EventHandler(this.cmb_fontSIze_SelectedIndexChanged);
            // 
            // btn_Bold
            // 
            this.btn_Bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Bold.Image = ((System.Drawing.Image)(resources.GetObject("btn_Bold.Image")));
            this.btn_Bold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Bold.Name = "btn_Bold";
            this.btn_Bold.Size = new System.Drawing.Size(29, 28);
            this.btn_Bold.Text = "toolStripButton1";
            this.btn_Bold.Click += new System.EventHandler(this.btn_Bold_Click);
            // 
            // btn_Italic
            // 
            this.btn_Italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Italic.Image = ((System.Drawing.Image)(resources.GetObject("btn_Italic.Image")));
            this.btn_Italic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Italic.Name = "btn_Italic";
            this.btn_Italic.Size = new System.Drawing.Size(29, 28);
            this.btn_Italic.Text = "btn_Italic";
            this.btn_Italic.Click += new System.EventHandler(this.btn_Italic_Click);
            // 
            // btn_Underline
            // 
            this.btn_Underline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_Underline.Image = ((System.Drawing.Image)(resources.GetObject("btn_Underline.Image")));
            this.btn_Underline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Underline.Name = "btn_Underline";
            this.btn_Underline.Size = new System.Drawing.Size(29, 28);
            this.btn_Underline.Text = "toolStripButton3";
            // 
            // NewBaiVietFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.rtb_mainContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_addImage);
            this.Controls.Add(this.cmb_KhoaHoc);
            this.Controls.Add(this.txt_TieuDe);
            this.Name = "NewBaiVietFrom";
            this.Text = "NewBaiVietFrom";
            this.Load += new System.EventHandler(this.NewBaiVietFrom_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txt_TieuDe;
        private Guna.UI2.WinForms.Guna2ComboBox cmb_KhoaHoc;
        private System.Windows.Forms.Label lbl_addImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_mainContent;
        private Guna.UI2.WinForms.Guna2Button btn_send;
        private Guna.UI2.WinForms.Guna2Button btn_thoat;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cmb_fontSIze;
        private System.Windows.Forms.ToolStripButton btn_Bold;
        private System.Windows.Forms.ToolStripButton btn_Italic;
        private System.Windows.Forms.ToolStripButton btn_Underline;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}