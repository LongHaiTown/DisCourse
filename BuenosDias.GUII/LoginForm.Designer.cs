namespace BuenosDias.GUII
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ptb_LoginScreen = new System.Windows.Forms.PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_QuenMatKhau = new System.Windows.Forms.Label();
            this.btn_Register = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Login = new Guna.UI2.WinForms.Guna2Button();
            this.txt_Password = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_UserName = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_LoginScreen)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ptb_LoginScreen
            // 
            this.ptb_LoginScreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptb_LoginScreen.Image = ((System.Drawing.Image)(resources.GetObject("ptb_LoginScreen.Image")));
            this.ptb_LoginScreen.Location = new System.Drawing.Point(0, 0);
            this.ptb_LoginScreen.Name = "ptb_LoginScreen";
            this.ptb_LoginScreen.Size = new System.Drawing.Size(679, 482);
            this.ptb_LoginScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_LoginScreen.TabIndex = 0;
            this.ptb_LoginScreen.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.guna2Panel1.Controls.Add(this.lbl_QuenMatKhau);
            this.guna2Panel1.Controls.Add(this.btn_Register);
            this.guna2Panel1.Controls.Add(this.btn_Login);
            this.guna2Panel1.Controls.Add(this.txt_Password);
            this.guna2Panel1.Controls.Add(this.txt_UserName);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(674, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(234, 482);
            this.guna2Panel1.TabIndex = 1;
            // 
            // lbl_QuenMatKhau
            // 
            this.lbl_QuenMatKhau.AutoSize = true;
            this.lbl_QuenMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuenMatKhau.ForeColor = System.Drawing.Color.Blue;
            this.lbl_QuenMatKhau.Location = new System.Drawing.Point(11, 220);
            this.lbl_QuenMatKhau.Name = "lbl_QuenMatKhau";
            this.lbl_QuenMatKhau.Size = new System.Drawing.Size(96, 16);
            this.lbl_QuenMatKhau.TabIndex = 6;
            this.lbl_QuenMatKhau.Text = "Quên mật khẩu";
            this.lbl_QuenMatKhau.Click += new System.EventHandler(this.lbl_QuenMatKhau_Click);
            // 
            // btn_Register
            // 
            this.btn_Register.BorderColor = System.Drawing.Color.White;
            this.btn_Register.BorderRadius = 5;
            this.btn_Register.BorderThickness = 2;
            this.btn_Register.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Register.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Register.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Register.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Register.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_Register.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Register.ForeColor = System.Drawing.Color.White;
            this.btn_Register.Location = new System.Drawing.Point(10, 308);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(221, 45);
            this.btn_Register.TabIndex = 5;
            this.btn_Register.Text = "Đăng ký";
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_Login.BorderColor = System.Drawing.Color.White;
            this.btn_Login.BorderRadius = 5;
            this.btn_Login.BorderThickness = 2;
            this.btn_Login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Login.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_Login.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(10, 259);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(221, 43);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Đăng nhập";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.BorderColor = System.Drawing.Color.White;
            this.txt_Password.BorderRadius = 5;
            this.txt_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Password.DefaultText = "";
            this.txt_Password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Password.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.txt_Password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Password.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_Password.ForeColor = System.Drawing.Color.White;
            this.txt_Password.HoverState.BorderColor = System.Drawing.Color.White;
            this.txt_Password.Location = new System.Drawing.Point(10, 175);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '●';
            this.txt_Password.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Password.PlaceholderText = "Mật khẩu";
            this.txt_Password.SelectedText = "";
            this.txt_Password.Size = new System.Drawing.Size(221, 36);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // txt_UserName
            // 
            this.txt_UserName.BorderColor = System.Drawing.Color.White;
            this.txt_UserName.BorderRadius = 5;
            this.txt_UserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_UserName.DefaultText = "";
            this.txt_UserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_UserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_UserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_UserName.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.txt_UserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_UserName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_UserName.ForeColor = System.Drawing.Color.White;
            this.txt_UserName.HoverState.BorderColor = System.Drawing.Color.White;
            this.txt_UserName.Location = new System.Drawing.Point(10, 129);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.PasswordChar = '\0';
            this.txt_UserName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_UserName.PlaceholderText = "Tên đăng nhập";
            this.txt_UserName.SelectedText = "";
            this.txt_UserName.Size = new System.Drawing.Size(221, 36);
            this.txt_UserName.TabIndex = 2;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 482);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.ptb_LoginScreen);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.ptb_LoginScreen)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ptb_LoginScreen;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txt_Password;
        private Guna.UI2.WinForms.Guna2TextBox txt_UserName;
        private System.Windows.Forms.Label lbl_QuenMatKhau;
        private Guna.UI2.WinForms.Guna2Button btn_Register;
        private Guna.UI2.WinForms.Guna2Button btn_Login;
    }
}