using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using BuenosDias.GUII.Component;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.GUII.User_controls
{
    public partial class UC_Management2 : UserControl
    {
        private User_ user;

        private string imageName;

        private Guna2DataGridView dgv_khoaHoc;
        private Guna2PictureBox pageCover;
        private Guna2TextBox txt_MaKhoaHoc;
        private Guna2TextBox txt_TenKhoaHoc;
        private Label lbl_addImages;

        private CourseServices courseServices = new CourseServices();
        private ImageService imageService = new ImageService();
        public UC_Management2(User_ user)
        {
            InitializeComponent();

            this.user = user;

            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(0, 0),
                Size = this.Size,
                FlowDirection = FlowDirection.LeftToRight,

            };
            FlowLayoutPanel infomationPanel = new FlowLayoutPanel
            {
                Size = new Size(300, 650),
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.White,


            };
            Label lbl_heading2 = new Label
            {
                Text = "Thêm sửa xóa khóa học của bạn",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
            };
            infomationPanel.Controls.Add(lbl_heading2);

            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/User/" + "Target.jpeg");
            //string imageAvtPath = Path.Combine(parentDirectory, "Resources/Images/User/" + imageService.GetAvt(user.UserID));
            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxHeight = 196;
                int calculatedWidth = (int)(maxHeight * aspectRatio);
                int Centeringimage = (int)(infomationPanel.Width - calculatedWidth) / 2;
                pageCover = new Guna2PictureBox()
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
            Label lbl_ThongTinKhoaHoc = new Label
            {
                Margin = new Padding(0, 20, 0, 0),
                AutoSize = true,
                Width = infomationPanel.Width,
                Text = "Thông tin khóa học",
                Font = new Font("Segoe UI", 15F,FontStyle.Bold),

            };
            infomationPanel.Controls.Add(lbl_ThongTinKhoaHoc);
            //Panel panel_txt_MakhoaHoc = new Panel
            //{
            //    Size = new Size(infomationPanel.Width, 30),
            //};
            Label lbl_MaKhoaHoc = new Label
            {
                Padding = new Padding(0,3,0,0),
                Location = new Point(0, 0),
                AutoSize = true,
                Width = infomationPanel.Width,
                Text = "Mã khóa học",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 12F,FontStyle.Bold),


            };
            //panel_txt_MakhoaHoc.Controls.Add(lbl_MaKhoaHoc);
            infomationPanel.Controls.Add(lbl_MaKhoaHoc);

            txt_MaKhoaHoc = new Guna2TextBox 
            {
                Size = new Size(150, lbl_MaKhoaHoc.Height),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Black,

                BorderRadius = 2 ,
                BorderColor = Color.Gray,
                BorderThickness =1,
            };
            infomationPanel.Controls.Add(txt_MaKhoaHoc);
            Label lbl_TenKhoaHoc = new Label
            {
                Location = new Point(0, 0),
                AutoSize = true,
                Width = infomationPanel.Width,
                Text = "Tên khóa học",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),

            };
            infomationPanel.Controls.Add(lbl_TenKhoaHoc);

            txt_TenKhoaHoc = new Guna2TextBox
            {
                Size = new Size(infomationPanel.Width-10, lbl_TenKhoaHoc.Height),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Black,

                BorderRadius = 2,
                BorderColor = Color.Gray,
                BorderThickness = 1,
            };
            infomationPanel.Controls.Add(txt_TenKhoaHoc);
            Label lbl_Chonhinh = new Label
            {
                Padding = new Padding(0, 10, 0, 0),
                AutoSize = true,
                Width = infomationPanel.Width,
                Text = "Hình ảnh khóa học",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),

            };
            infomationPanel.Controls.Add(lbl_Chonhinh);
            lbl_addImages = new Label
            {
                Text = "Thêm hình ảnh",
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
            };
            lbl_addImages.Click += lbl_addImage_Click;
            lbl_addImages.TextChanged += (sender, e) => ShowAvatar(this.imageName);
            infomationPanel.Controls.Add(lbl_addImages);

            FlowLayoutPanel functions = new FlowLayoutPanel()
            {
                MaximumSize = new Size(infomationPanel.Width, 0),
                AutoSize = true,
                Padding = new Padding(0, 10, 2, 0),
                WrapContents = true
            };

            Guna2Button btn_addStudnentButton = new Guna2Button()
            {
                Size = new Size(infomationPanel.Width -52, 30),
                BackColor = Color.White,
                ForeColor = Color.White,
                Text = "Danh sách học viên",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 3,
                BorderThickness = 2,
                FillColor = Color.Gray,
                BorderColor = Color.Gray,
            };
            btn_addStudnentButton.Click += btn_AddStudent_Click;
            Guna2Button btn_addButton = new Guna2Button()
            {
                Size = new Size(120, 30),
                BackColor = Color.White,
                ForeColor = Color.White,
                Text = "Thêm",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 3,
                BorderThickness = 2,
                FillColor = Color.Gray,
                BorderColor = Color.Gray,
            };
            btn_addButton.Click += btn_Add_Click;
            Guna2Button btn_changeButton = new Guna2Button()
            {
                Size = new Size(120, 30),
                BackColor = Color.White,
                ForeColor = Color.White,
                Text = "Sửa",
                Font = new Font ("Segoe UI",10F,FontStyle.Bold),
                BorderRadius = 3,
                BorderThickness = 2,
                FillColor = Color.Gray,
                BorderColor = Color.Gray,
            };
            Guna2Button btn_DeleteContentButton = new Guna2Button()
            {
                Size = new Size(120, 30),
                BackColor = Color.White,
                ForeColor = Color.White,
                Text = "Xóa nội dung",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 3,
                BorderThickness = 2,
                FillColor = Color.Gray,
                BorderColor = Color.Gray,
            };
            btn_DeleteContentButton.Click += btn_DeleteContent_Click;
            Guna2Button btn_DeleteStudentButton = new Guna2Button()
            {
                Size = new Size(120, 30),
                BackColor = Color.White,
                ForeColor = Color.White,
                Text = "Xóa học viên",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 3,
                BorderThickness = 2,
                FillColor = Color.Gray,
                BorderColor = Color.Gray,
            };
            btn_DeleteStudentButton.Click += btn_DeleteStudentCourse_Click;
            Guna2Button btn_DeleteButton = new Guna2Button()
            {
                Size = new Size(120, 30),
                BackColor = Color.White,
                ForeColor = Color.White,
                Text = "Xóa",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 3,
                BorderThickness = 2,
                FillColor = Color.Gray,
                BorderColor = Color.Gray,
            };
            btn_DeleteButton.Click += btn_Delete_Click;
            
            functions.Controls.Add(btn_addStudnentButton);
            functions.Controls.Add(btn_addButton);
            functions.Controls.Add(btn_changeButton);
            functions.Controls.Add(btn_DeleteContentButton);
            functions.Controls.Add(btn_DeleteStudentButton);
            functions.Controls.Add(btn_DeleteButton);
            infomationPanel.Controls.Add(functions);


            mainPanel.Controls.Add(infomationPanel);

            Guna2Panel detailPanel = new Guna2Panel
            {
                BackColor = Color.White,
                Size = new Size(800 , 650 ),
            };
            Label lbl_Heading1 = new Label
            {
                Location = new Point(10, 10),
                Text = "Trang dành cho Nhân Viên",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                AutoSize = true,

            };
            detailPanel.Controls.Add(lbl_Heading1);

            dgv_khoaHoc = new Guna2DataGridView
            {
                Location = new Point(10, 20 + lbl_Heading1.Height),
                Size = new Size(detailPanel.Width - 20, detailPanel.Height - 100),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Auto size columns
                
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing,
                ColumnHeadersHeight = 50,
                GridColor = Color.Gray,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                
            };
            dgv_khoaHoc.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgv_khoaHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dgv_khoaHoc.CellClick += dgv_khoaHocs_CellClick;
            detailPanel.Controls.Add(dgv_khoaHoc);
            // Add columns
            dgv_khoaHoc.Columns.Add("MaKhoaHoc", "Mã khóa học");
            dgv_khoaHoc.Columns.Add("TenKhoaHoc", "Tên khóa học");
            dgv_khoaHoc.Columns.Add("Sobaihoc", "Tổng số bài ");
            dgv_khoaHoc.Columns.Add("SoHocVien", "Số lượng đăng ký");




            mainPanel.Controls.Add(detailPanel);


            this.Controls.Add(mainPanel);

            fetchDataDGV();
        }

        private void fetchDataDGV()
        {
            dgv_khoaHoc.Rows.Clear();
            var khoaHoc = courseServices.GetKhoaHocByUserID(user.UserID);
            foreach (var item in khoaHoc)
            {
                int index = dgv_khoaHoc.Rows.Add();

                dgv_khoaHoc.Rows[index].Cells[0].Value = item.MaKhoaHoc;
                dgv_khoaHoc.Rows[index].Cells[1].Value = item.TenKhoaHoc;
                dgv_khoaHoc.Rows[index].Cells[2].Value = item.BaiViets.Count.ToString();
                dgv_khoaHoc.Rows[index].Cells[3].Value = item.User_1.Count.ToString();

                if ( item.BaiViets.Count == 0) 
                {
                    dgv_khoaHoc.Rows[index].DefaultCellStyle.BackColor = Color.Gray;
                };

            }
        }
        private void lbl_addImage_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dlg = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*",
                    Title = "Select an Image"
                };

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = dlg.FileName;
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string targetFilePath = Path.Combine(projectDirectory, "Resources", "Images", "CourseCover", Path.GetFileName(sourceFilePath));

                    File.Copy(sourceFilePath, targetFilePath, true);

                    string filename = targetFilePath.Replace(Path.Combine(projectDirectory, "Resources", "Images", "CourseCover") + Path.DirectorySeparatorChar, "");
                    this.imageName = filename;
                    lbl_addImages.Text = filename;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong O.o");
            }
        }
        private void btn_AddStudent_Click(object sender, EventArgs e)
        {
            if (!courseServices.checkExist(txt_MaKhoaHoc.Text))
            {
                MessageBox.Show("Khóa học này không tồn tại");
                return;
            }
            else
            {

                KhoaHoc newCourse = new KhoaHoc
                {
                    MaKhoaHoc = txt_MaKhoaHoc.Text,
                    TenKhoaHoc = txt_TenKhoaHoc.Text,
                    UserID = user.UserID,

                };

                ThemSinhVienForm themSinhVienForm = new ThemSinhVienForm(newCourse);
                themSinhVienForm.Show();
            }
        }
            private void btn_Add_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc muốn tạo khóa học mới?", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string targetFilePath = Path.Combine(projectDirectory, "Resources", "Posts");

                    if (courseServices.checkExist(txt_MaKhoaHoc.Text))
                    {
                        MessageBox.Show("Khóa học này đã tồn tại! Không thể tạo thêm");
                        return;
                    }
                    else
                    {

                        KhoaHoc newCourse = new KhoaHoc
                        {
                            MaKhoaHoc = txt_MaKhoaHoc.Text,
                            TenKhoaHoc = txt_TenKhoaHoc.Text,
                            UserID = user.UserID,

                        };
                        MessageBox.Show(newCourse.MaKhoaHoc + " " + newCourse.TenKhoaHoc + " " + newCourse.UserID);
                        if (string.IsNullOrEmpty(imageName))
                        {
                            MessageBox.Show("Phải thêm ảnh cho khóa học");
                            return;
                        }
                        else
                        {
                            HinhAnh hinhAnhBaiViet = new HinhAnh
                            {
                                MaHinhAnh = newCourse.MaKhoaHoc,
                                TenHinhAnh = imageName,
                                IDBaiViet = "0",
                                UserID = newCourse.UserID,
                                LoaiHinhAnh = "CC",
                                MaKhoaHoc = newCourse.MaKhoaHoc,

                            };
                            courseServices.CreateNewCourse(newCourse);
                            imageService.insertCourseCover(hinhAnhBaiViet);
                            MessageBox.Show("Tạo khóa học thành công!");
                            fetchDataDGV();


                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);

                    Exception inner = ex.InnerException;
                    while (inner != null)
                    {
                        Console.WriteLine("Inner Exception: " + inner.ToString());
                        inner = inner.InnerException;
                    }
                }

            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            KhoaHoc newCourse = new KhoaHoc
            {
                MaKhoaHoc = txt_MaKhoaHoc.Text,
                TenKhoaHoc = txt_TenKhoaHoc.Text,
                UserID = user.UserID,

            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa khóa học này ?", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    courseServices.DeleteCourse(newCourse);
                    MessageBox.Show("Xóa khóa học thành công");
                    fetchDataDGV();

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa khóa học này!");
                }
            }
            else
            {
                return;
            }
        }
        private void btn_DeleteContent_Click(object sender, EventArgs e)
        {
            KhoaHoc newCourse = new KhoaHoc
            {
                MaKhoaHoc = txt_MaKhoaHoc.Text,
                TenKhoaHoc = txt_TenKhoaHoc.Text,
                UserID = user.UserID,

            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa nội dung khóa học (Các hình ảnh và bài học liên quan cũng sẽ bị xóa)", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    courseServices.DeleteCourseContent(newCourse);
                    fetchDataDGV();
                    MessageBox.Show("Xóa nội dung thành công");

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa!");
                }
                fetchDataDGV();

            }
            else
            {
                return;
            }
        }
        private void btn_DeleteStudentCourse_Click(object sender, EventArgs e)
        {
            KhoaHoc newCourse = new KhoaHoc
            {
                MaKhoaHoc = txt_MaKhoaHoc.Text,
                TenKhoaHoc = txt_TenKhoaHoc.Text,
                UserID = user.UserID,

            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa tất cả học viên", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    courseServices.DeleteRegisterdStunder(newCourse);
                    fetchDataDGV();
                    MessageBox.Show("Đã xóa tất cả học viên");
 
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa!");
                }
                fetchDataDGV();

            }
            else
            {
                return;
            }
        }
        private void UC_Management2_Load()
        {
            throw new NotImplementedException();
        }

        private void ShowAvatar(string ImageName)
        {
            lbl_addImages.Text = ImageName;
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/CourseCover/" + ImageName);
            pageCover.ImageLocation = imagePath;
            pageCover.Refresh();

        }
        private void dgv_khoaHocs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_khoaHoc.Rows[e.RowIndex];

                txt_MaKhoaHoc.Text = row.Cells[0].Value.ToString(); 
                txt_TenKhoaHoc.Text = row.Cells[1].Value.ToString();
                imageName = imageService.GetCourseCover(row.Cells[0].Value.ToString());
                
                ShowAvatar(imageName);
            }
        }

        private void UC_Management2_Load(object sender, EventArgs e)
        {

        }
    }
}
