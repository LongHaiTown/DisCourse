using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using BuenosDias.GUII.User_controls;
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

namespace BuenosDias.GUII
{
    public partial class NewCourseForm : Form
    {
        private readonly CourseServices courseServices = new CourseServices();
        private readonly ImageService imageService = new ImageService();
        private string imageName;
        private User_ user;
        public NewCourseForm(User_ user)
        {
            InitializeComponent();

            this.user = user;
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
                    lbl_addImage.Text = filename;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong O.o");
            }
        }

        private void NewCourseForm_Load(object sender, EventArgs e)
        {

        }

        private void lbl_addImage_TextChanged(object sender, EventArgs e)
        {
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/CourseCover/" + this.imageName);
            ptb_CourseCover.ImageLocation = imagePath;

        }

        private void btn_TaoCourse_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc muốn tạo khóa học mới?", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string targetFilePath = Path.Combine(projectDirectory, "Resources", "Posts");

                    SaveFileDialog dlg = new SaveFileDialog
                    {
                        InitialDirectory = targetFilePath, // Set your desired directory
                        FileName = "preCourse_" + courseServices.GetCourseMaxQuantity().ToString() + ".txt"
                    };

                    string sourceFilePath = Path.Combine(targetFilePath, dlg.FileName);
                    File.WriteAllText(sourceFilePath, txt_MoTa.Text);

                    KhoaHoc newCourse = new KhoaHoc
                    {
                        MaKhoaHoc = "10",
                        TenKhoaHoc = txt_TenCourse.Text,
                        UserID = user.UserID,

                    };
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
                        MessageBox.Show("Tạo khóa học thành công!!");

                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    // Duyệt qua từng lỗi
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        // Lấy tên của thực thể
                        var entityType = validationErrors.Entry.Entity.GetType().Name;

                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            // Hiển thị thông báo lỗi chi tiết
                            Console.WriteLine($"Entity: {entityType}, Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }
                }

            }
        }
    }
}
