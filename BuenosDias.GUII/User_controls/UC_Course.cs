using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using BuenosDias.GUII.Component;
using Guna.UI2.WinForms;
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

namespace BuenosDias.GUII.User_controls
{
    public partial class UC_Course : UserControl
    {
        private readonly ImageService imageService = new ImageService();
        private readonly postServices postServices  = new postServices();
        private List<BaiViet> relevantPostbyCourse;
        private List<BaiViet> relevantPostbyCoursebyAuthor;
        private List<BaiViet> relevantPostbyCoursenotbyAuthor;

        private User_ user;
        private string QuyenUser;
        public UC_Course(KhoaHoc k , User_ user)
        {

            InitializeComponent();

            this.user = user;
            QuyenUser = user.CacLoaiQuyens.ToList()[0].TenQuyen;

            this.BackColor = Color.White;

            relevantPostbyCourse = postServices.GetBaiVietbyCourseID(k.MaKhoaHoc);

            relevantPostbyCoursebyAuthor = relevantPostbyCourse.Where(x => x.UserID == k.UserID).ToList();
            relevantPostbyCoursenotbyAuthor = relevantPostbyCourse.Where(x => x.UserID != k.UserID).ToList();

            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string courseImage = Path.Combine(parentDirectory, "Resources/Images/CourseCover/" + imageService.GetCourseCover(k.MaKhoaHoc));
            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location =new Point(20,20),
                MaximumSize = new Size(1200,0),
                AutoSize = true,
            };
            System.Drawing.Image image = System.Drawing.Image.FromFile(courseImage);
            float aspectRatio = (float)image.Width / image.Height;
            int maxHeight = 200;
            int calculatedWidth = (int)(maxHeight * aspectRatio);

            Guna2PictureBox courseCover = new Guna2PictureBox
            {
                Location = new Point(20, 5),
                Width = calculatedWidth,
                Height = maxHeight,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderRadius = 12,

            };

            mainPanel.Controls.Add(courseCover);


            FlowLayoutPanel detaisPanel = new FlowLayoutPanel()
            {
                MaximumSize = new Size(700,0),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,

            };
            Label lbl_Course = new Label
            {
                Text = k.TenKhoaHoc,
                Font = new Font("Segoe UI", 25F, FontStyle.Bold),
                Width = 850,
                Height = 50,

            };
            detaisPanel.Controls.Add(lbl_Course);
            FlowLayoutPanel description = new FlowLayoutPanel
            {
                Padding = new Padding(0, 5, 0, 5),
                Size = new Size(800, 50),
            };

            string imagePath1 = Path.Combine(parentDirectory, "Resources/Images/User/" + imageService.GetAvt(k.User_.UserID));

            Guna2CirclePictureBox author_img = new Guna2CirclePictureBox
            {
                Height = 30,
                Width = 30,
                ImageLocation = imagePath1,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            description.Controls.Add(author_img);
            Label author_name = new Label
            {
                Text = k.User_.TenUser,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Green,
                AutoSize = true,
                Padding = new Padding(0, 5, 0, 0)
            };
            description.Controls.Add(author_name);
            detaisPanel.Controls.Add(description);
            try
            {
                string preCourseIntro = Path.Combine(parentDirectory, "Resources/Posts/" + "preCourse_"+ k.MaKhoaHoc+".txt");
                string noidung = File.ReadAllText(preCourseIntro);

                Label lbl_gioithieu = new Label
                {
                    Size = new Size(700, 21),
                    Text = "Giới thiệu khóa học:",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.DimGray,

                };
                detaisPanel.Controls.Add(lbl_gioithieu);
                Guna2TextBox CourseIntroduction = new Guna2TextBox
                {
                    Padding = new Padding(0, 0, 0, 0),
                    Size = new Size(700, 80),
                    Text = noidung,
                    Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                    Multiline = true,
                    ForeColor = Color.DimGray,
                    BorderColor = Color.White,
                    HoverState =
                    {
                        BorderColor = Color.White,
                        FillColor = Color.Transparent,
                        ForeColor = Color.Black,
                        Parent = null
                    },
                    FocusedState =
                {
                    BorderColor = Color.White,
                     Parent = null,
                },
                };
                detaisPanel.Controls.Add(CourseIntroduction);
            } catch (Exception e) { }
           
            mainPanel.Controls.Add(detaisPanel);


            this.Controls.Add(mainPanel);
            FlowLayoutPanel discussesPanel = new FlowLayoutPanel
            {
                Width = 1550,
                Height = 350,
                Location = new Point(20, mainPanel.Height + 20),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
            };
            this.Controls.Add(discussesPanel);
            Label lbl_yourCourse = new Label
            {
                Text = "Các bài học",
                MinimumSize = new Size (1550,0),
                Height = 25,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),

            };

            discussesPanel.Controls.Add(lbl_yourCourse);

            FlowLayoutPanel panel_mainLessons = new FlowLayoutPanel
            {
                Height = 155,
                Width = 1000,
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,


            };

            discussesPanel.Controls.Add(panel_mainLessons);

            Label lbl_relevantDisscuss = new Label
            {
                Size = new Size(1550,25),
                Text = "Các thảo luận liên quan",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),

            };

            discussesPanel.Controls.Add(lbl_relevantDisscuss);

            FlowLayoutPanel panel_relevantDisscuss = new FlowLayoutPanel
            {
                Height = 155,
                Width = 1000,
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,

            };
            discussesPanel.Controls.Add(panel_relevantDisscuss);


            foreach (var baiviet in relevantPostbyCoursebyAuthor)
            {
                if (baiviet.IDBaiViet == "0")
                {
                    continue;
                }
                PostPanel_Small guna2Panel = new PostPanel_Small(baiviet,k, user, createPostUC)
                {
                    Size = new Size(200, 130),

                };
                panel_mainLessons.Controls.Add(guna2Panel);
            }
            foreach (var baiviet in relevantPostbyCoursenotbyAuthor)
            {
                PostPanel_Small guna2Panel = new PostPanel_Small(baiviet,k,user, createPostUC)
                {
                    Size = new Size(200, 130),

                };
                panel_relevantDisscuss.Controls.Add(guna2Panel);
            }
        }
        private void addUserControls(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }
        private void createPostUC(BaiViet b)
        {
            UC_Post SpecificPost = new UC_Post(b);
            addUserControls(SpecificPost);
            MessageBox.Show("Open Successfully");
        }

        private void UC_Course_Load(object sender, EventArgs e)
        {
        }
    }
}
