using BuenosDias.BUS;
using BuenosDias.Container;
using BuenosDias.DALL.Models;
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

namespace BuenosDias
{
    public partial class NewBaiVietForm : Form
    {
        private readonly ImageService imageService = new ImageService();
        private string imagesName;

        MyTextBox txt_title;
        Label lbl_addImage;
        MyRTB rtb_mainContent;
        Button btn_postButton;
        Button btn_cancelButton;

        UserServices userServices = new UserServices();
        postServices postServices = new postServices();
        ImageService postImageService = new ImageService();
        public NewBaiVietForm()
        {
            InitializeComponent();
            
        }

        private void NewBaiVietForm_Load(object sender, EventArgs e)
        {

            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;

            Size = new Size(800, 500);
            BackColor = System.Drawing.ColorTranslator.FromHtml("#b7b7b7");

            txt_title = new MyTextBox
            {
                Location = new Point(10, 50),
                Size = new Size(750, 30),
                Font = new Font("Segoe UI", 12F,FontStyle.Bold),
                PlaceholderText = "Tiêu đề bài viết"
            };
            lbl_addImage = new Label
            {
                Location = new Point(10,80),
                AutoSize = true,
                Text = "Thêm hình ảnh",
                ForeColor = Color.Blue,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                 
            };
            lbl_addImage.Click += new EventHandler(AddImage_Click);


            rtb_mainContent = new MyRTB
            {
                Location = new Point(10, 100),
                Size = new Size(750, 310),
                PlaceholderText = "Ý tưởng của bạn"
            };

            btn_postButton = new Button
            {
                Location = new Point(550, 420),
                Size = new Size (100,30),
                Text = "Đăng"
            };
            btn_postButton.Click += new EventHandler(btn_post_Click);
            btn_cancelButton = new Button
            {
                Location = new Point(660, 420),
                Size = new Size(100, 30),
                Text = "Hủy"
            };

            this.Controls.Add(txt_title);
            this.Controls.Add(lbl_addImage);
            this.Controls.Add(rtb_mainContent);
            this.Controls.Add(btn_postButton);
            this.Controls.Add(btn_cancelButton);


        }
        private void btn_post_Click(object sender, EventArgs e)
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
                File.WriteAllText(sourceFilePath, rtb_mainContent.Text);

                BaiViet newBaiViet = new BaiViet
                {
                    IDBaiViet = postServices.GenerateFileID(),
                    TIeuDe = txt_title.Text,
                    NoiDung = dlg.FileName,
                    UserID = 1.ToString()
                };
                postServices.SendPost(newBaiViet);


                if (string.IsNullOrEmpty(imagesName))
                {
                    MessageBox.Show("Chua co hinh");
                }
                else
                {
                    HinhAnh hinhAnhBaiViet = new HinhAnh
                    {
                        MaHinhAnh = newBaiViet.IDBaiViet,
                        TenHinhAnh = imagesName,
                        IDBaiViet = newBaiViet.IDBaiViet,
                        UserID = "1",
                        LoaiHinhAnh = "P"

                    };
                    imageService.insertPostImages(hinhAnhBaiViet);

                }
                MessageBox.Show("Đăng thành công ^^");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong O.o " + ex.Message);
            }
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
                string targetFilePath = Path.Combine(projectDirectory, "Resources","Images","Post", Path.GetFileName(sourceFilePath));

                File.Copy(sourceFilePath, targetFilePath, true);

                string filename = targetFilePath.Replace(Path.Combine(projectDirectory, "Resources", "Images", "Post") + Path.DirectorySeparatorChar, "");
                lbl_addImage.Text = filename;
                this.imagesName=filename;

                }
            }catch (Exception)
            {
                MessageBox.Show("Something went wrong O.o");
            }
        }

    }
}
