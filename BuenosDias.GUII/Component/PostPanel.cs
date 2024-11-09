using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BuenosDias.GUII.Component
{
    public class PostPanel: Guna2Panel
    {
        private readonly Action<BaiViet> _switchToPostUC;
        private readonly ImageService imageService = new ImageService();
        private BaiViet baiViet;
        private object v;

        public PostPanel(BaiViet b, Action<BaiViet> switchToPostUC)
        {
            _switchToPostUC = switchToPostUC;  

            BorderRadius = 12;
            BorderThickness = 2;
            BorderColor = Color.DimGray;
            BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            baiViet = b;
        

            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 10),
                Width = 900 - 40,
                Height = 200 - 20,
            };

            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/PostImage/" + imageService.GetTenHinhAnhBaibyID(b.IDBaiViet));
            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxHeight = 150;
                int calculatedWidth = (int)(maxHeight * aspectRatio);
                
                Guna2PictureBox postImage = new Guna2PictureBox
                {
                    Width = 160,
                    Height = 160,
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    FillColor = Color.DimGray,
                    BorderRadius = 20,

                };
                postImage.Click += (sender, e) => _switchToPostUC?.Invoke(baiViet);
                mainPanel.Controls.Add(postImage);
            }
            FlowLayoutPanel noidungPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,

                Padding = new Padding(0, 0, 0, 0),
                Width = 675,
                Height = 200,
                WrapContents = false,

            };

            Label lbl_tieude = new Label
            {
                Text = b.TIeuDe,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(105, 105, 105),
                Left = 10,
                MaximumSize = new Size(675,0),
                AutoSize = true
            };
            lbl_tieude.Click += (sender, e) => _switchToPostUC?.Invoke(baiViet);

            noidungPanel.Controls.Add(lbl_tieude);

            FlowLayoutPanel description = new FlowLayoutPanel
            {
                MaximumSize = new Size(675,0),
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
            };

            string imagePathDefault = Path.Combine(parentDirectory, "Resources/" + "default.png");
            Guna2CirclePictureBox author_img = new Guna2CirclePictureBox
            {
                Height = 25,
                Width = 25,
                ImageLocation = imagePathDefault,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            description.Controls.Add(author_img);
            try
            {
                string imagePath1 = Path.Combine(parentDirectory, "Resources/Images/User/" + imageService.GetAvt(b.User_.UserID));
                if (File.Exists(imagePath1))
                {
                    author_img.ImageLocation = imagePath1;
                }
                else
                {
                    author_img.ImageLocation = imagePathDefault;
                }
            }
            catch (Exception e)
            {
                author_img.ImageLocation = imagePathDefault;
            }

            Label author_name = new Label
            {
                Text = b.User_.TenUser,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(0, 5, 0, 0)
            };
            description.Controls.Add(author_name);
            try
            {
                DateTime dateTime = DecodeTimestamp(b.IDBaiViet.Substring(2));
                string formattedDateTime = dateTime.ToString("MM/dd/yyyy hh:mm:ss tt"); // Định dạng chuỗi
                string postTime = formattedDateTime;

                Label postDate = new Label
                {
                    Text = postTime,
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    Dock = DockStyle.Bottom,
                    Padding = new Padding(0,0,0,10)

                };
                description.Controls.Add(postDate);
            }
            catch (Exception) { }
            this.Controls.Add(mainPanel);


            noidungPanel.Controls.Add(description);
            try { 
                string prepostPath = Path.Combine(parentDirectory, "Resources/Posts/pre_" + b.IDBaiViet + ".txt");
                string noidung = File.ReadAllText(prepostPath);

                if (noidung.Length > 200)
                {
                    noidung = noidung.Substring(0, 200) + "...";
                }
                Guna2TextBox txt_preNoiDung = new Guna2TextBox
                {
                    Width = 500,
                    Height = 50,
                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                    Text = noidung,
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.None,
                    WordWrap = true,
                    BorderColor = Color.White,
                    BorderThickness = 2,
                    ForeColor = Color.Black,
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

                noidungPanel.Controls.Add(txt_preNoiDung);
            } catch(Exception ex) { };
            mainPanel.Controls.Add(noidungPanel);
            this.Controls.Add(mainPanel);


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
