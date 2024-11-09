using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace BuenosDias.GUII.Component
{
    public class PostPanel_Small : Guna2Panel
    {
        private readonly Action<BaiViet> _switchToPostUC;
        private readonly ImageService imageService = new ImageService();
        private readonly postServices postServices = new postServices();

        private BaiViet baiViet;
        private User_ user;

        public PostPanel_Small(BaiViet b, User_ user , Action<BaiViet> switchToPostUC)
        {
            _switchToPostUC = switchToPostUC;
            this.user = user;
            BorderRadius = 2;
            BorderThickness = 1;
            BorderColor = Color.DimGray;

            baiViet = b;


            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(2, 2),
                Width = 195,
                Height = 110,
                
            };

            FlowLayoutPanel removePanel = new FlowLayoutPanel
            {
                Location = new Point(2, 2),
                Width = 193,
                Height = 15,
                FlowDirection = FlowDirection.LeftToRight,
            };
            Guna2Button removeButton = new Guna2Button
            {
                Size = new Size(20, 12),
                BackColor = Color.White,
                FillColor = Color.White,

                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Segoe UI",5F,FontStyle.Bold),

                BorderRadius = 2,
                BorderColor = Color.Gray,
                BorderThickness = 1,

            };
            removeButton.Visible = removeButton.Enabled = user.UserID == baiViet.UserID;
            removeButton.Click += Remove_Click;
            removePanel.Controls.Add(removeButton);

            mainPanel.Controls.Add(removePanel);
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/PostImage/" + imageService.GetTenHinhAnhBaibyID(b.IDBaiViet));
            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxHeight = 50;
                int calculatedWidth = (int)(maxHeight * aspectRatio);

                Guna2PictureBox postImage = new Guna2PictureBox
                {
                    Width = calculatedWidth,
                    Height = maxHeight,
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    FillColor = Color.DimGray,
                    BorderRadius = 20,
                    
                };
                postImage.Click += (sender, e) => _switchToPostUC?.Invoke(baiViet);
                mainPanel.Controls.Add(postImage);
            }

            Label lbl_tieude = new Label
            {
                Text = b.TIeuDe,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.Black,
                MaximumSize = new Size(90,0),
                AutoSize = true
            };
            lbl_tieude.Click += (sender, e) => _switchToPostUC?.Invoke(baiViet);
            mainPanel.Controls.Add(lbl_tieude);

            try
            { 
            DateTime dateTime = DecodeTimestamp(b.IDBaiViet.Substring(2));
                string formattedDateTime = dateTime.ToString("MM/dd/yyyy hh:mm:ss tt");
                string postTime = formattedDateTime; 

                Label postDate = new Label
                {
                    Padding = new Padding (0,2,0,0),
                    Text = postTime,
                    ForeColor = Color.DimGray,
                    Width = this.Width - 3,
                    Height = 14,
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),

                    
                };
                    mainPanel.Controls.Add(postDate);
            } catch (Exception ) { }
                this.Controls.Add(mainPanel);

        }
        public PostPanel_Small(BaiViet b, KhoaHoc k, User_ user, Action<BaiViet> switchToPostUC)
        {
            _switchToPostUC = switchToPostUC;
            this.user = user;
            BorderRadius = 2;
            BorderThickness = 1;
            BorderColor = Color.DimGray;

            baiViet = b;


            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(2, 2),
                Width = 195,
                Height = 110,

            };

            FlowLayoutPanel removePanel = new FlowLayoutPanel
            {
                Location = new Point(2, 2),
                Width = 193,
                Height = 15,
                FlowDirection = FlowDirection.LeftToRight,
            };
            Guna2Button removeButton = new Guna2Button
            {
                Size = new Size(20, 12),
                BackColor = Color.White,
                FillColor = Color.White,

                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Segoe UI", 5F, FontStyle.Bold),

                BorderRadius = 2,
                BorderColor = Color.Gray,
                BorderThickness = 1,

            };
            removeButton.Visible = removeButton.Enabled = (user.UserID == baiViet.UserID || user.UserID == k.UserID);
            removeButton.Click += Remove_Click;
            removePanel.Controls.Add(removeButton);

            mainPanel.Controls.Add(removePanel);
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/PostImage/" + imageService.GetTenHinhAnhBaibyID(b.IDBaiViet));
            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxHeight = 50;
                int calculatedWidth = (int)(maxHeight * aspectRatio);

                Guna2PictureBox postImage = new Guna2PictureBox
                {
                    Width = calculatedWidth,
                    Height = maxHeight,
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    FillColor = Color.DimGray,
                    BorderRadius = 20,

                };
                postImage.Click += (sender, e) => _switchToPostUC?.Invoke(baiViet);
                mainPanel.Controls.Add(postImage);
            }

            Label lbl_tieude = new Label
            {
                Text = b.TIeuDe,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.Black,
                MaximumSize = new Size(90, 0),
                AutoSize = true
            };
            lbl_tieude.Click += (sender, e) => _switchToPostUC?.Invoke(baiViet);
            mainPanel.Controls.Add(lbl_tieude);

            try
            {
                DateTime dateTime = DecodeTimestamp(b.IDBaiViet.Substring(2));
                string formattedDateTime = dateTime.ToString("MM/dd/yyyy hh:mm:ss tt");
                string postTime = formattedDateTime;

                Label postDate = new Label
                {
                    Padding = new Padding(0, 2, 0, 0),
                    Text = postTime,
                    ForeColor = Color.DimGray,
                    Width = this.Width - 3,
                    Height = 14,
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),


                };
                mainPanel.Controls.Add(postDate);
            }
            catch (Exception) { }
            this.Controls.Add(mainPanel);

        }
        private void Remove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn xóa bài viết này?");
            try
            {
                if (baiViet.UserID == user.UserID)
                {
                    postServices.DeletePost(baiViet);
                    MessageBox.Show("Xóa bài viết thành công! Vui lòng tải lại trang");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Something went wrong O.o" +ex.Message);
            };
        }
        public DateTime DecodeTimestamp(string timestamp)
        {
            try
            {
                return DateTime.ParseExact(timestamp, "yyyyMMdd_HHmmss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Timestamp format is invalid. Expected format: yyyyMMdd_HHmmss.");
            }
        }

    }
}
