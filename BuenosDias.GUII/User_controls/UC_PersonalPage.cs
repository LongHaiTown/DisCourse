using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using BuenosDias.GUII.Component;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.GUII.User_controls
{
    public partial class UC_PersonalPage : UserControl
    {
        private FlowLayoutPanel infomationPanel;

        private UserServices userServices = new UserServices();
        private postServices postServices = new postServices();
        private CourseServices courseServices = new CourseServices();
        private ImageService imageService = new ImageService();

        private List<BaiViet> PostsBythisUser = new List<BaiViet>();
        private List<KhoaHoc> CoursesOFthisUser = new List<KhoaHoc>();

        private User_ user;
        private string QuyenUser;

        public UC_PersonalPage(User_ user)
        {

            this.user = user;
            QuyenUser = user.CacLoaiQuyens.ToList()[0].TenQuyen;

            InitializeComponent();
            if (QuyenUser == "LEARNER")
            {
                CoursesOFthisUser = user.KhoaHocs1.ToList();
            }
            else
            {
                CoursesOFthisUser = courseServices.GetKhoaHocByUserID(user.UserID);
            }
            PostsBythisUser = postServices.GetBaiVietbyUserID(user.UserID);

            this.BackColor = Color.Gray;

            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(0, 0),
                Size = this.Size,
                BackColor = Color.DimGray,
                FlowDirection = FlowDirection.LeftToRight,

            };
            infomationPanel = new FlowLayoutPanel
            {
                Size = new Size(300, 650),
                FlowDirection = FlowDirection.TopDown,
                 BackColor = Color.White,


             };
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/User/" + "DokiDoki.jpg");
            string imageAvtPath = Path.Combine(parentDirectory, "Resources/Images/User/" + imageService.GetAvt(user.UserID));

            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxHeight = 180;
                int calculatedWidth = (int)(maxHeight * aspectRatio);
                int Centeringimage = (int)(infomationPanel.Width - calculatedWidth) / 2;
                Guna2PictureBox pageCover = new Guna2PictureBox()
                {
                    Margin = new Padding(Centeringimage, 5, 0, 0),
                    Width = calculatedWidth,
                    Height = maxHeight,
                    BorderRadius = 10,
                    ImageLocation = imagePath,
                    SizeMode = PictureBoxSizeMode.Zoom,
                };
                infomationPanel.Controls.Add(pageCover);
            }

            int CenteringimageAVT = (int)(infomationPanel.Width - 100) / 2;
            Guna2CirclePictureBox avt = new Guna2CirclePictureBox
            {
                Margin = new Padding(CenteringimageAVT, 20, 0, 0),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,

            };
            infomationPanel.Controls.Add(avt);

            string defaultImagePath = Path.Combine(parentDirectory, "Resources/default.png");
            try
            {
                string imagePathAVT = Path.Combine(parentDirectory, "Resources/Images/User/" + imageService.GetAvt(user.UserID));
                if (File.Exists(imagePathAVT))
                {
                    avt.ImageLocation = imagePathAVT;
                }
                else
                {
                    avt.ImageLocation = defaultImagePath;
                }
            }
            catch (Exception e) { }
           
            Label tenUser = new Label
            {
                Text = user.TenUser,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                MaximumSize = new Size(infomationPanel.Width,0),
                AutoSize = true,
            };


            infomationPanel.Controls.Add(tenUser);
            Label chucVu = new Label
            {
                Text = QuyenUser,
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                AutoSize = true,
            };
            infomationPanel.Controls.Add(chucVu);

            infomationPanel.Paint += FlowLayoutPanel_Paint;

            mainPanel.Controls.Add(infomationPanel);

            FlowLayoutPanel courseNPostPanels = new FlowLayoutPanel
            {
                BackColor = Color.White,
                Size = new Size(800 +2, mainPanel.Height -2),
                FlowDirection = FlowDirection.TopDown,

            };
            Label lbl_yourCourses = new Label
            {
                Text = "Các khóa học của bạn",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                AutoSize = true,
            };
            courseNPostPanels.Controls.Add(lbl_yourCourses);
            FlowLayoutPanel panel_yourCourses = new FlowLayoutPanel
            {
                Height = 200,
                Width = 1000,
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
            };
            courseNPostPanels.Controls.Add(panel_yourCourses);

            Label lbl_yourPosts = new Label
            {
                Text = "Các bài viết của bạn",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                AutoSize = true,
            };
            courseNPostPanels.Controls.Add(lbl_yourPosts);
            FlowLayoutPanel panel_yourPosts = new FlowLayoutPanel
            {
                Height = 300,
                Width = 800,

                AutoSize = false,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,

            };
            courseNPostPanels.Controls.Add(panel_yourPosts);
            mainPanel.Controls.Add(courseNPostPanels);

            this.Controls.Add(mainPanel);

            foreach (var khoaHoc in CoursesOFthisUser)
            {
                CoursePanel guna2Panel = new CoursePanel(khoaHoc, createCourseUC)
                {
                    Size = new Size(200, 180),

                };

                panel_yourCourses.Controls.Add(guna2Panel);

            };

            
            foreach (var baiviet in PostsBythisUser)
            {
                if (baiviet.IDBaiViet == "0")
                {
                    continue;
                }
                PostPanel_Small guna2Panel = new PostPanel_Small(baiviet,user, createPostUC)
                {
                    Size = new Size(200, 130),

                };

                panel_yourPosts.Controls.Add(guna2Panel);

            }
        }

        private void UC_PersonalPage_Load(object sender, EventArgs e)
        {
            
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
        private void createCourseUC(KhoaHoc k)
        {
            UC_Course specificCourse = new UC_Course(k,user);
            addUserControls(specificCourse);
            MessageBox.Show("Open Successfully");
        }
        private void FlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)sender;
            int borderRadius = 1; // Bán kính bo góc
            int borderThickness = 2; // Độ dày viền
            Color borderColor = Color.Gray; // Màu viền

            // Thiết lập chế độ vẽ chất lượng cao cho viền mịn hơn
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                // Tạo đường bo góc tròn cho viền
                path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
                path.AddArc(new Rectangle(panel.Width - borderRadius - 1, 0, borderRadius, borderRadius), 270, 90);
                path.AddArc(new Rectangle(panel.Width - borderRadius - 1, panel.Height - borderRadius - 1, borderRadius, borderRadius), 0, 90);
                path.AddArc(new Rectangle(0, panel.Height - borderRadius - 1, borderRadius, borderRadius), 90, 90);
                path.CloseFigure();

                // Tô nền bên trong với màu nền của panel
                using (SolidBrush brush = new SolidBrush(panel.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Vẽ viền
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

    }
}
