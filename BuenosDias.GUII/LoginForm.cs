using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BuenosDias.GUII
{
    public partial class LoginForm : Form
    {
        private readonly UserServices userServices = new UserServices();
        
        private List<String> imagesList = new List<String>();

        int count = 0;
        private string parentDirectory;
        private string ImagePath;
        public LoginForm()
        {
            InitializeComponent();

            imagesList.Add("Dont Chase.jpg");
            imagesList.Add("DontRush.jpg");
            imagesList.Add("QualityOfYourCharacter.jpg");
            imagesList.Add("strongmind.jpg");


            parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            ImagePath = Path.Combine(parentDirectory, "Resources/Images/LoginScreen/");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < 4)
            {
                ptb_LoginScreen.ImageLocation = ImagePath + imagesList[count];
                count++;
            }
            else
            {
                count = 0;
            }
        }

        private void lbl_QuenMatKhau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này hiện chưa có (╯︵╰,)");
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này hiện chưa có (╥﹏╥)");

        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            User_ LoggedIn = userServices.checkLogin(txt_UserName.Text, txt_Password.Text);
            if (LoggedIn != null )
            {
                MainForm mainForm = new MainForm(LoggedIn);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại thông tin.");
            }
        }
    }
}
