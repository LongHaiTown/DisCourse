using System;
using Guna;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using BuenosDias.GUII.User_controls;
using BuenosDias.DALL.Models;
using BuenosDias.BUS;
using System.IO;
namespace BuenosDias.GUII
{
    public partial class MainForm : Form
    {
        private UserControl currentUserControl;
        private readonly ImageService imageService = new ImageService();
        private User_ user;
        private string QuyenUser ;
        public MainForm(User_ loggedInUser)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;

            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/" + "default.png");

            user = loggedInUser;
            QuyenUser = user.CacLoaiQuyens.ToList()[0].TenQuyen;

            lbl_username.Text = user.TenUser;

            btn_QuanLy.Visible = btn_QuanLy.Enabled = QuyenUser != "LEARNER";

            
            try
            {
                string imagePathAVT = Path.Combine(parentDirectory, "Resources/Images/User/" + imageService.GetAvt(user.UserID));
                if (File.Exists(imagePathAVT))
                {
                    ptb_Avt.ImageLocation = imagePathAVT;
                }
                else
                {
                    ptb_Avt.ImageLocation = imagePath;
                }
            }
            catch (Exception e) {
                ptb_Avt.ImageLocation = imagePath;
            }

            UC_Courses HOME = new UC_Courses(user);
            addUserControls(HOME);

            HideNewButton();

        }
        private void Form1_Load(object sender, EventArgs e)
        {



        }
        private void addUserControls(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(uc);
            currentUserControl = uc;
            uc.BringToFront();
        }
        private void button_HomeUC_Click(object sender, EventArgs e)
        {
            UC_Courses HOME = new UC_Courses(user);
            addUserControls(HOME);
        }

        private void btn_KhoaHocUC_Click(object sender, EventArgs e)
        {
            UC_Courses Course = new UC_Courses(user);
            addUserControls(Course);
            HideNewButton();
        }

        private void btn_BaiVietUC_Click(object sender, EventArgs e)
        {
            UC_Posts post = new UC_Posts(user);
            addUserControls(post);
            btn_newThing.Show();
            btn_newThing.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (currentUserControl is UC_Posts)
            {
                NewBaiVietFrom newBaiVietFrom = new NewBaiVietFrom(user);
                newBaiVietFrom.Show();
            }else if (currentUserControl is UC_Courses)
            {
                NewCourseForm newCourseForm = new NewCourseForm(user);
                newCourseForm.Show();
            }
            else 
            {
            }
        }
        private void HideNewButton()
        {
            if (this.QuyenUser == "LEARNER" )
            {

                if (this.currentUserControl is UC_Courses)
                {
                    btn_newThing.Hide();
                    btn_newThing.Enabled = false;
                }else
                {
                    btn_newThing.Show();
                    btn_newThing.Enabled = true;
                }
   
            }
           

        }
        private void btn_TrangCaNhan_Click(object sender, EventArgs e)
        {
            UC_PersonalPage personalPage = new UC_PersonalPage(user);
            addUserControls(personalPage);
            btn_newThing.Hide();

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_QuanLy_Click(object sender, EventArgs e)
        {
            if (QuyenUser == "ADMIN")
            {
                MessageBox.Show("Welcome aboard, Captain");
                UC_Management1 UCQuanLy = new UC_Management1(user);
                addUserControls(UCQuanLy);
            }
            else if (QuyenUser == "NHANVIEN")
            {
                MessageBox.Show("Welcome aboard, vice Captain");
                UC_Management2 UCQuanLy = new UC_Management2(user);
                addUserControls(UCQuanLy);
            }
        }
    }
}
