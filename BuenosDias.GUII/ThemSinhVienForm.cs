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

namespace BuenosDias.GUII
{
    public partial class ThemSinhVienForm : Form
    {
        private readonly UserServices userServices = new UserServices();
        private readonly CourseServices courseServices = new CourseServices();
        private KhoaHoc k;

        public ThemSinhVienForm(KhoaHoc k)
        {
            this.k = k;
            InitializeComponent();
            lbl_TenCourse.Text = k.TenKhoaHoc;
            fetchDataAllUserdgv();
            fetchDataDSDKdgv();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void fetchDataDSDKdgv()
        {
            dgv_DanhSachDangKy.Rows.Clear();
            var userList = courseServices.GetUsersByKhoaHocId(k.MaKhoaHoc);
            foreach (var user in userList)
            {
                int index = dgv_DanhSachDangKy.Rows.Add();

                dgv_DanhSachDangKy.Rows[index].Cells[0].Value = user.UserID;
                dgv_DanhSachDangKy.Rows[index].Cells[1].Value = user.TenUser;
            }      

        }
        public void fetchDataAllUserdgv()
        {
            dgv_TatCaTaiKhoan.Rows.Clear();
            var userList = userServices.getAllUser().Where(user => user.UserID.Length >= 5).ToList();
            foreach (var user in userList)
            {
                int index = dgv_TatCaTaiKhoan.Rows.Add();

                dgv_TatCaTaiKhoan.Rows[index].Cells[0].Value = user.UserID;
                dgv_TatCaTaiKhoan.Rows[index].Cells[1].Value = user.TenUser;


            }

        }
        private void dgv_AllUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_TatCaTaiKhoan.Rows[e.RowIndex];

                txt_id.Text = row.Cells[0].Value.ToString();
                txt_ten.Text = row.Cells[1].Value.ToString();
            }
        }
        private void dgv_RegisteredUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_DanhSachDangKy.Rows[e.RowIndex];

                txt_id.Text = row.Cells[0].Value.ToString();
                txt_ten.Text = row.Cells[1].Value.ToString();
            }
        }
        private void btn_ThemStudent_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc muốn thêm học viên này?", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {

                    if (courseServices.GetUsersByKhoaHocId(k.MaKhoaHoc).Where(user => user.UserID == txt_id.Text).Any())
                    {
                        MessageBox.Show("Học viên này đã đăng ký!");
                        return;
                    }
                    else
                    {

                        User_ userr = new User_
                        {
                            UserID = txt_id.Text,
                            TenUser = txt_ten.Text,

                        };
                        userServices.RegisterStudentToCourse(k, userr);
                        MessageBox.Show("Thêm sinh viên thành công!");

                        fetchDataDSDKdgv();
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
            else { return; }
        }

        private void btn_RemoveStudent_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa học viên này?", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    User_ userr = new User_
                    {
                        UserID = txt_id.Text,
                        TenUser = txt_ten.Text,

                    };
                    userServices.RemoveStudentFromCourse(k, userr);
                    MessageBox.Show("Xóa sinh viên thành công!");
                    fetchDataDSDKdgv();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something happened O.o! " + ex.Message);

                }
            }
            else { return; }
        }

        private void btn_createNewUser_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc muốn thêm tài khoản này?", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {

                    if (userServices.checkExist(txt_id.Text))
                    {
                        MessageBox.Show("Tài khoản này đã tồn tại!");
                        return;
                    }
                    else
                    {

                        User_ userr = new User_
                        {
                            UserID = txt_id.Text,
                            TenUser = txt_ten.Text,

                        };
                        userServices.createNewUser2("3",userr);
                        MessageBox.Show("Thêm sinh viên thành công!");
                        fetchDataDSDKdgv();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong O.o");
                }
            }
            else { return; }
        }
    }
}
