using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using BuenosDias.GUII.Component;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.GUII.User_controls
{
    public partial class UC_Courses : UserControl
    {
        private readonly CourseServices courseServices = new CourseServices();
        private readonly UserServices userServices = new UserServices();

        private List<KhoaHoc> khoaHocs = new List<KhoaHoc>();
        private List<KhoaHoc> allKhoaHoc = new List<KhoaHoc>();

        private User_ user;
        private string QuyenUser;

        public UC_Courses(User_ user)
        {
            this.user = user;
            QuyenUser = user.CacLoaiQuyens.ToList()[0].TenQuyen;

            allKhoaHoc = courseServices.GetKhoaHocs();
            if (QuyenUser == "LEARNER")
            {
                khoaHocs = user.KhoaHocs1.ToList();
            }
            else
            {
                khoaHocs = courseServices.GetKhoaHocByUserID(user.UserID);
            }
            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(0, 0),
                Width = 1550,
                MinimumSize = new Size (1550,800),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,

            };
            Label lbl_yourCourse = new Label
            {
                Location = new Point(15, 0),
                Text = "Khóa học của bạn",
                AutoSize = true,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),

            };
            FlowLayoutPanel Panel_YourCourse = new FlowLayoutPanel
            {
                Location = new Point(15, 35),
                Height =230,
                Width = this.Width +880,
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                
            };
            foreach(KhoaHoc k in khoaHocs)
            {
                CoursePanel guna2Panel = new CoursePanel(k, createCourseUC)
                {
                    Size = new Size(200, 180),
                };
                Panel_YourCourse.Controls.Add(guna2Panel);
            }
            Label lbl_NewCourse = new Label
            {
                Location = new Point(15, 0),
                Text = "Dành cho bạn",
                AutoSize = true,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),

            };
            FlowLayoutPanel Panel_NewCourse = new FlowLayoutPanel
            {
                AutoSize = false,
                AutoScroll = true,
                WrapContents = true,
                Width = 1200,
                Height = 1000,
                FlowDirection = FlowDirection.LeftToRight,
            };

            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(lbl_yourCourse);
            mainPanel.Controls.Add(Panel_YourCourse);
            mainPanel.Controls.Add(lbl_NewCourse);
            for (int i = 0; i < allKhoaHoc.Count ; i++)
            {
                CoursePanel guna2Panel = new CoursePanel(allKhoaHoc[i], createCourseUC)
                {
                    Size = new Size(200, 180),
                };
                Panel_NewCourse.Controls.Add(guna2Panel);
            }

            mainPanel.Controls.Add(Panel_NewCourse);

            Panel_YourCourse.HorizontalScroll.Enabled = true; 
            mainPanel.VerticalScroll.SmallChange = 20; // Set small change to a manageable value
            mainPanel.VerticalScroll.LargeChange = 50;
            this.Controls.Add(mainPanel);

        }

        private void UC_home_Load(object sender, EventArgs e)
        {

        }
        private void addUserControls(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }
        private void createCourseUC(KhoaHoc k)
        {
            UC_Course specificCourse = new UC_Course(k , user);
            addUserControls(specificCourse);
            MessageBox.Show("Open Successfully");
        }
    }
}

//public MainForm()
//{
//    InitializeComponent();

//    this.FormBorderStyle = FormBorderStyle.FixedSingle;
//    StartPosition = FormStartPosition.CenterScreen;

//    sideBar.BackColor = System.Drawing.ColorTranslator.FromHtml("#7c93c3");
//    menuStrip1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1e2a5e");


//    homePanel.AutoScroll = true;
//    homePanel.WrapContents = true;
//    homePanel.FlowDirection = FlowDirection.LeftToRight;

//    NewPost newBaiViet = new NewPost("what's on your mind")
//    {
//        Size = new System.Drawing.Size(160, 40),
//        Location = new Point(10, 100),
//        BackColor = Color.White,

//    };
//    sideBar.Controls.Add(newBaiViet);


//    this.ActiveControl = newBaiViet;
//}

//private void Form1_Load(object sender, EventArgs e)
//{
//    fetchBaiViet();
//}
//public void fetchBaiViet()
//{
//    recommend = postServices.GetBaiViets();

//    for (int i = recommend.Count - 1; i >= 0; i--)
//    {
//        BaiViet b = recommend[i];
//        DivPanel divPanel = new DivPanel(b)
//        {
//            Margin = new Padding(0, 0, 0, 30),
//            BackColor = Color.White,
//            BorderStyle = BorderStyle.None

//        };
//        homePanel.Controls.Add(divPanel);
//    }
//}

//private void sssToolStripMenuItem_Click(object sender, EventArgs e)
//{
//    homePanel.Controls.Clear();
//    fetchBaiViet();

//}

//private void guna2Button1_Click(object sender, EventArgs e)
//{

//}

//private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
//{

//}
//    }