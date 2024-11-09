namespace BuenosDias.GUII
{
    partial class NewCourseForm
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
            this.txt_TenCourse = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_addImage = new System.Windows.Forms.Label();
            this.txt_MoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ptb_CourseCover = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btn_TaoCourse = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Cancel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_CourseCover)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_TenCourse
            // 
            this.txt_TenCourse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TenCourse.DefaultText = "";
            this.txt_TenCourse.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TenCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TenCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenCourse.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenCourse.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenCourse.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txt_TenCourse.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenCourse.Location = new System.Drawing.Point(320, 51);
            this.txt_TenCourse.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_TenCourse.Name = "txt_TenCourse";
            this.txt_TenCourse.PasswordChar = '\0';
            this.txt_TenCourse.PlaceholderText = "";
            this.txt_TenCourse.SelectedText = "";
            this.txt_TenCourse.Size = new System.Drawing.Size(621, 50);
            this.txt_TenCourse.TabIndex = 1;
            // 
            // lbl_addImage
            // 
            this.lbl_addImage.AutoSize = true;
            this.lbl_addImage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_addImage.Location = new System.Drawing.Point(12, 232);
            this.lbl_addImage.Name = "lbl_addImage";
            this.lbl_addImage.Size = new System.Drawing.Size(152, 16);
            this.lbl_addImage.TabIndex = 2;
            this.lbl_addImage.Text = "Thêm hình ảnh khóa học";
            this.lbl_addImage.TextChanged += new System.EventHandler(this.lbl_addImage_TextChanged);
            this.lbl_addImage.Click += new System.EventHandler(this.lbl_addImage_Click);
            // 
            // txt_MoTa
            // 
            this.txt_MoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MoTa.DefaultText = "";
            this.txt_MoTa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MoTa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MoTa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MoTa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MoTa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_MoTa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MoTa.Location = new System.Drawing.Point(321, 146);
            this.txt_MoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_MoTa.Multiline = true;
            this.txt_MoTa.Name = "txt_MoTa";
            this.txt_MoTa.PasswordChar = '\0';
            this.txt_MoTa.PlaceholderText = "";
            this.txt_MoTa.SelectedText = "";
            this.txt_MoTa.Size = new System.Drawing.Size(620, 79);
            this.txt_MoTa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(318, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên khóa học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(318, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mô tả khóa học";
            // 
            // ptb_CourseCover
            // 
            this.ptb_CourseCover.FillColor = System.Drawing.Color.Silver;
            this.ptb_CourseCover.ImageRotate = 0F;
            this.ptb_CourseCover.Location = new System.Drawing.Point(12, 25);
            this.ptb_CourseCover.Name = "ptb_CourseCover";
            this.ptb_CourseCover.Size = new System.Drawing.Size(300, 200);
            this.ptb_CourseCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_CourseCover.TabIndex = 0;
            this.ptb_CourseCover.TabStop = false;
            // 
            // btn_TaoCourse
            // 
            this.btn_TaoCourse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_TaoCourse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_TaoCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_TaoCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_TaoCourse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaoCourse.ForeColor = System.Drawing.Color.White;
            this.btn_TaoCourse.Location = new System.Drawing.Point(719, 232);
            this.btn_TaoCourse.Name = "btn_TaoCourse";
            this.btn_TaoCourse.Size = new System.Drawing.Size(108, 31);
            this.btn_TaoCourse.TabIndex = 7;
            this.btn_TaoCourse.Text = "Tạo";
            this.btn_TaoCourse.Click += new System.EventHandler(this.btn_TaoCourse_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(833, 232);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(108, 31);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Hủy";
            // 
            // NewCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 275);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_TaoCourse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MoTa);
            this.Controls.Add(this.lbl_addImage);
            this.Controls.Add(this.txt_TenCourse);
            this.Controls.Add(this.ptb_CourseCover);
            this.Name = "NewCourseForm";
            this.Text = "NewCourseForm";
            this.Load += new System.EventHandler(this.NewCourseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_CourseCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox ptb_CourseCover;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenCourse;
        private System.Windows.Forms.Label lbl_addImage;
        private Guna.UI2.WinForms.Guna2TextBox txt_MoTa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_TaoCourse;
        private Guna.UI2.WinForms.Guna2Button btn_Cancel;
    }
}