using BuenosDias.DALL.Models;
using BuenosDias.GUII.Component;
using BuenosDias.GUII.User_controls;
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

namespace BuenosDias.GUII
{
    public partial class TestingDelete : Form
    {
        public TestingDelete()
        {
            InitializeComponent();
            BaiViet b = new BaiViet
            {
                IDBaiViet = "0_20241031_123107",
                TIeuDe = "Bài 1: Nhập Môn Ấn Độ Giáo – Khám Phá Một Nền Văn Hóa và Tôn Giáo Cổ Đại",
                NoiDung = "Post_20241031_123107.rtf",
                UserID = "1",
                MaKhoaHoc = "0",

            };
            User_ user = new User_
            {
                UserID = "2",
                TenUser = "Thân Huỳnh",

            };
            PostPanel_Small ondelete = new PostPanel_Small(b, user, createPostUC) {
                Size = new Size(200, 130),
                Location = new Point (100,100),
            };

            this.Controls.Add(ondelete);
        }

        private void TestingDelete_Load(object sender, EventArgs e)
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
    }
}
