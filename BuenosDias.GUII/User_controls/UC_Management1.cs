using BuenosDias.BUS;
using BuenosDias.DALL.Models;
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
    public partial class UC_Management1 : UserControl
    {
        private readonly CourseServices courseServices = new CourseServices();
        private readonly postServices postServices = new postServices();
        private readonly UserServices userServices = new UserServices();
        private readonly ImageService imageService = new ImageService();

        private User_ user;
        public UC_Management1(User_ user)
        {
            InitializeComponent();

            this.user = user;

            dgv_allCourse.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgv_allCourse.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_allPost.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgv_allPost.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_allUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dgv_allUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);



        }

        public void fetchAllCourseDGV()
        {
            dgv_allCourse.Rows.Clear();
            var courseList = courseServices.GetKhoaHocs() ;
            foreach (var course in courseList)
            {
                int index = dgv_allCourse.Rows.Add();

                dgv_allCourse.Rows[index].Cells[0].Value = course.MaKhoaHoc;
                dgv_allCourse.Rows[index].Cells[1].Value = course.TenKhoaHoc;
                dgv_allCourse.Rows[index].Cells[2].Value = course.User_.TenUser;
                dgv_allCourse.Rows[index].Cells[3].Value = course.BaiViets.Count;
                dgv_allCourse.Rows[index].Cells[4].Value = course.User_1.Count;

            }

        }
        public void fetchAllPostDGV()
        {
            dgv_allPost.Rows.Clear();
            var postList = postServices.GetBaiViets();
            foreach (var post in postList)
            {
                int index = dgv_allPost.Rows.Add();

                dgv_allPost.Rows[index].Cells[0].Value = post.IDBaiViet;
                dgv_allPost.Rows[index].Cells[1].Value = post.TIeuDe;
                dgv_allPost.Rows[index].Cells[2].Value = post.User_.TenUser;
                dgv_allPost.Rows[index].Cells[3].Value = post.NoiDung;
                try
                {
                    dgv_allPost.Rows[index].Cells[4].Value = post.HinhAnhs.ToList()[0].TenHinhAnh;
                }catch (Exception ex) { }

            }

        }
        public void fetchAllUser()
        {
            dgv_allUsers.Rows.Clear();
            var userList = userServices.getAllUser();
            foreach (var user in userList)
            {
                int index = dgv_allUsers.Rows.Add();

                dgv_allUsers.Rows[index].Cells[0].Value = user.UserID;
                dgv_allUsers.Rows[index].Cells[1].Value = user.TenUser;
                try
                {
                    dgv_allUsers.Rows[index].Cells[2].Value = user.CacLoaiQuyens.ToList()[0].TenQuyen;
                }catch(Exception e) { };
                dgv_allUsers.Rows[index].Cells[3].Value = Math.Max(user.KhoaHocs.Count(), user.KhoaHocs1.Count);
                dgv_allUsers.Rows[index].Cells[4].Value = user.BaiViets.Count();

            }

        }

        private void UC_Management1_Load(object sender, EventArgs e)
        {
            fetchAllCourseDGV();
            fetchAllUser();
            fetchAllPostDGV();
        }

        private void dgv_allCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_allCourse.Rows[e.RowIndex];

                txt_allCourseSelect.Text = row.Cells[0].Value.ToString();
            }
        }

        private void dgv_allPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_allPost.Rows[e.RowIndex];

                txt_allPostSelect.Text = row.Cells[0].Value.ToString();
            }
        }

        private void dgv_allUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_allUsers.Rows[e.RowIndex];

                txt_AllUserSelect.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            KhoaHoc newCourse = new KhoaHoc
            {
                MaKhoaHoc = txt_allCourseSelect.Text,

            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa khóa học này ?", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    courseServices.DeleteCourse(newCourse);
                    MessageBox.Show("Xóa khóa học thành công");

                    fetchAllCourseDGV();
                    fetchAllUser();
                    fetchAllPostDGV();
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            KhoaHoc newCourse = new KhoaHoc
            {
                MaKhoaHoc = txt_allCourseSelect.Text,
            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa nội dung khóa học (Các hình ảnh và bài học liên quan cũng sẽ bị xóa)", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    courseServices.DeleteCourseContent(newCourse);

                    fetchAllCourseDGV();
                    fetchAllUser();
                    fetchAllPostDGV();
                    MessageBox.Show("Xóa nội dung thành công");

                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa!");
                }

            }
            else
            {
                return;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            KhoaHoc newCourse = new KhoaHoc
            {
                MaKhoaHoc = txt_allCourseSelect.Text,

            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa tất cả học viên", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    courseServices.DeleteRegisterdStunder(newCourse);
                    MessageBox.Show("Đã xóa tất cả học viên");
                    fetchAllCourseDGV();
                    fetchAllUser();
                    fetchAllPostDGV();
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa!" );
                }



            }
            else
            {
                return;
            }
        }

        private void btn_XoaPost_Click(object sender, EventArgs e)
        {
            BaiViet baiviet = new BaiViet
            {
                IDBaiViet = txt_allPostSelect.Text,

            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa bài viết này", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    imageService.DeleteImagesByPostID(baiviet);
                    postServices.DeletePost(baiviet);
                    MessageBox.Show("Đã xóa bài viết!");
                    fetchAllCourseDGV();
                    fetchAllUser();
                    fetchAllPostDGV();
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa!" +ex.Message);
                }



            }
            else
            {
                return;
            }
        }

        private void btn_XoaHinhAnh_Click(object sender, EventArgs e)
        {
            BaiViet baiviet = new BaiViet
            {
                IDBaiViet = txt_allPostSelect.Text,

            };
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa hình ảnh bài viết này", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    imageService.DeleteImagesByPostID(baiviet);
                    MessageBox.Show("Đã xóa hình ảnh bài viết!");
                    fetchAllCourseDGV();
                    fetchAllUser();
                    fetchAllPostDGV();
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa!");
                }



            }
            else
            {
                return;
            }
        }

        private void btn_XoaUser_Click(object sender, EventArgs e)
        {
            User_ user = new User_
            {
                UserID = txt_AllUserSelect.Text,

            };
            MessageBox.Show(txt_AllUserSelect.Text);

            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa User này " + txt_AllUserSelect.Text, "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                if (userServices.GetQuyenUser(user) == "LEARNER")
                {
                    if (userServices.checkValidDeleteStudent(user) == false) { MessageBox.Show("Phải xóa bài viết của học viên!"); return; };
                }
                if (userServices.GetQuyenUser(user) == "NHANVIEN")
                {
                    if (userServices.checkValidDeleteNhanVien(user) == false) { MessageBox.Show("Phải xóa bài viết / khóa học của user!"); return; };
                }
                try
                {
                    userServices.DeleteUser(user);
                    MessageBox.Show("Đã xóa thành công!");
                    fetchAllCourseDGV();
                    fetchAllUser();
                    fetchAllPostDGV();
                }

                catch (Exception ex)
                {

                    MessageBox.Show("Không thể xóa!");
                }



            }
            else
            {
                return;
            }
        }
    }
}
