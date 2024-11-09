using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using BuenosDias.GUII.User_controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.GUII
{
    public partial class NewBaiVietFrom : Form
    {
        private string imageName;
        private readonly postServices postServices = new postServices();
        private readonly ImageService imageService = new ImageService();
        private readonly CourseServices courseServices = new CourseServices();
        private readonly UserServices userServices = new UserServices();

        private User_ user;
        private string QuyenUser;
        public NewBaiVietFrom(User_ user)
        {
            InitializeComponent();

            this.user = user;

            LoadSystemFontSize();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;

            txt_TieuDe.PlaceholderForeColor = Color.Gray;
            txt_TieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
           
            lbl_addImage.Click += new EventHandler(AddImage_Click);

            QuyenUser = user.CacLoaiQuyens.ToList()[0].TenQuyen;
            List<KhoaHoc> khoaHocs  = new List<KhoaHoc>();
            if (QuyenUser == "LEARNER")
            {
                khoaHocs = user.KhoaHocs1.ToList();
            }
            else
            {
                khoaHocs = courseServices.GetKhoaHocByUserID(user.UserID);
            };
            fetchKhoaHocCMB(khoaHocs);
        }
        public void fetchKhoaHocCMB(List<KhoaHoc> khoaHocs)
        {
            cmb_KhoaHoc.DataSource = khoaHocs;
            cmb_KhoaHoc.ValueMember = "MaKhoaHoc";
            cmb_KhoaHoc.DisplayMember = "TenKhoaHoc";
        }
        private void NewBaiVietFrom_Load(object sender, EventArgs e)
        {
        }
        private void AddImage_Click(object sender, EventArgs e)
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
                    string targetFilePath = Path.Combine(projectDirectory, "Resources", "Images", "PostImage", Path.GetFileName(sourceFilePath));

                    File.Copy(sourceFilePath, targetFilePath, true);

                    string filename = targetFilePath.Replace(Path.Combine(projectDirectory, "Resources", "Images", "PostImage") + Path.DirectorySeparatorChar, "");
                    lbl_addImage.Text = filename;
                    this.imageName = filename;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong O.o");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            DialogResult re= MessageBox.Show("Bạn có chắc muốn gửi", "Double check", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (re == DialogResult.Yes)
            {
                try
                {
                    string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string targetFilePath = Path.Combine(projectDirectory, "Resources", "Posts");

                    SaveFileDialog dlg = new SaveFileDialog
                    {
                        InitialDirectory = targetFilePath, // Set your desired directory
                        FileName = postServices.GenerateFileName() // Set the default file name
                    };

                    string sourceFilePath = Path.Combine(targetFilePath, dlg.FileName);
                    rtb_mainContent.SaveFile(sourceFilePath, RichTextBoxStreamType.RichText); // Lưu với định dạng RTF

                    string makhoaHoc =(cmb_KhoaHoc.SelectedItem as KhoaHoc).MaKhoaHoc;
                    BaiViet newBaiViet = new BaiViet
                    {
                        IDBaiViet = makhoaHoc+"_"+postServices.GenerateFileID(),
                        TIeuDe = txt_TieuDe.Text,
                        NoiDung = dlg.FileName,
                        UserID = user.UserID,
                        MaKhoaHoc = makhoaHoc,

                    };
                    postServices.SendPost(newBaiViet);

                    string userId = user.UserID;

                    if (string.IsNullOrEmpty(imageName))
                    {
                        MessageBox.Show("Chua co hinh");
                    }
                    else
                    {
                        HinhAnh hinhAnhBaiViet = new HinhAnh
                        {
                            MaHinhAnh = newBaiViet.IDBaiViet,
                            TenHinhAnh = imageName,
                            IDBaiViet = newBaiViet.IDBaiViet,
                            UserID = userId,
                            LoaiHinhAnh = "P",
                            MaKhoaHoc = (cmb_KhoaHoc.SelectedItem as KhoaHoc).MaKhoaHoc

                        };
                        imageService.insertPostImages(hinhAnhBaiViet);

                    }

                    NewBaiVietFrom_PostDescription description = new NewBaiVietFrom_PostDescription(newBaiViet);
                    description.Show();
                    this.txt_TieuDe.Clear();
                    this.rtb_mainContent.Clear();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong O.o " + ex.Message);
                }
            }
        }
        private void LoadSystemFontSize()
        {
            float[] sizes = { 15, 25,30,35 };
            foreach (float size in sizes)
            {
                cmb_fontSIze.Items.Add(size.ToString());
            }
            if (cmb_fontSIze.Items.Count > 0)
            {
                cmb_fontSIze.SelectedIndex = 1;
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void cmb_fontSIze_SelectedIndexChanged(object sender, EventArgs e)
        {
            float newSize = float.Parse(cmb_fontSIze.SelectedItem.ToString());
            rtb_mainContent.SelectionFont = new Font("Segoe UI", newSize, rtb_mainContent.Font.Style);
        }

        private void btn_Bold_Click(object sender, EventArgs e)
        {
            if (rtb_mainContent.SelectionFont != null)
            {
                // Lấy kiểu chữ hiện tại
                FontStyle currentStyle = rtb_mainContent.SelectionFont.Style;

                // Nếu đang là Bold, thì bỏ Bold, ngược lại thì thêm Bold
                if (currentStyle.HasFlag(FontStyle.Bold))
                {
                    // Loại bỏ Bold bằng cách bỏ cờ FontStyle.Bold
                    currentStyle &= ~FontStyle.Bold;
                }
                else
                {
                    // Thêm Bold bằng cách đặt cờ FontStyle.Bold
                    currentStyle |= FontStyle.Bold;
                }

                // Tạo Font mới với kiểu chữ đã chỉnh sửa
                rtb_mainContent.SelectionFont = new Font("Segoe UI", rtb_mainContent.SelectionFont.Size, currentStyle);
            }
        }
        private void btn_Underline_Click(object sender, EventArgs e)
        {
            if (rtb_mainContent.SelectionFont != null)
            {
                // Lấy kiểu chữ hiện tại
                FontStyle currentStyle = rtb_mainContent.SelectionFont.Style;

                if (currentStyle.HasFlag(FontStyle.Underline))
                {
                    // Loại bỏ Bold bằng cách bỏ cờ FontStyle.Bold
                    currentStyle &= ~FontStyle.Underline;
                }
                else
                {
                    // Thêm Bold bằng cách đặt cờ FontStyle.Bold
                    currentStyle |= FontStyle.Underline;
                }

                // Tạo Font mới với kiểu chữ đã chỉnh sửa
                rtb_mainContent.SelectionFont = new Font("Segoe UI", rtb_mainContent.SelectionFont.Size, currentStyle);
            }
        }

        private void btn_Italic_Click(object sender, EventArgs e)
        {
            if (rtb_mainContent.SelectionFont != null)
            {
                // Lấy kiểu chữ hiện tại
                FontStyle currentStyle = rtb_mainContent.SelectionFont.Style;

                if (currentStyle.HasFlag(FontStyle.Italic))
                {
                    // Loại bỏ Bold bằng cách bỏ cờ FontStyle.Bold
                    currentStyle &= ~FontStyle.Italic;
                }
                else
                {
                    // Thêm Bold bằng cách đặt cờ FontStyle.Bold
                    currentStyle |= FontStyle.Italic;
                }

                // Tạo Font mới với kiểu chữ đã chỉnh sửa
                rtb_mainContent.SelectionFont = new Font("Segoe UI", rtb_mainContent.SelectionFont.Size, currentStyle);
            }
        }

        private void lbl_addImage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
