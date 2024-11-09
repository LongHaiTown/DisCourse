using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.GUII.User_controls
{
    public partial class UC_Post : UserControl
    {
        public readonly ImageService imageService = new ImageService();
        public UC_Post(BaiViet b)
        {
            InitializeComponent();

            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(142, 50),
                Width = 1000,
                Height = this.Height,
                AutoScroll = true,
                WrapContents = false,

                FlowDirection = FlowDirection.TopDown,
            };


            Guna.UI2.WinForms.Guna2HtmlLabel cat1 = new Guna2HtmlLabel
            {
                Text = b.KhoaHoc.TenKhoaHoc +"/",
                Font = new Font("Segoe UI", 13F),
                Padding = new Padding(0, 0, 0, 5),
                ForeColor = Color.Gray

            };

            mainPanel.Controls.Add(cat1);

            Label lblTieude = new Label
            {
                Text = b.TIeuDe,
                Font = new Font ("Segoe UI", 25F,FontStyle.Bold),

                AutoSize = true,
                MaximumSize = new Size(800, 0),
                ForeColor = Color.Black,


            };
            mainPanel.Controls.Add(lblTieude);
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string prepostPath = Path.Combine(parentDirectory, "Resources/Posts/pre_" + b.IDBaiViet);
            TextBox preText = new TextBox
            {
                Padding = new Padding(5, 0, 0, 0),
                Size = new Size(800, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.Black,
                ReadOnly = true,
                Multiline = true,
                ScrollBars = ScrollBars.None,
                WordWrap = true,
                Enabled = false,
            };
            if (File.Exists(prepostPath))
            {
                preText.Text = File.ReadAllText(prepostPath);
            }
            mainPanel.Controls.Add(preText);

            FlowLayoutPanel description = new FlowLayoutPanel
            {
                Padding = new Padding(5, 10, 0, 10),
                Size = new Size(800, 50),
            };
          
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/PostImage/" + imageService.GetTenHinhAnhBaibyID(b.IDBaiViet));
            string imagePathDefault = Path.Combine(parentDirectory, "Resources/" + "default.png");
            Guna2CirclePictureBox author_img = new Guna2CirclePictureBox
            {
                Height = 30,
                Width = 30,
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
                Font = new Font("Segoe UI",10F,FontStyle.Bold),
                ForeColor = Color.Green,
                AutoSize = true,
                Padding = new Padding(0,5,0,0)
            };
            description.Controls.Add(author_name);

            mainPanel.Controls.Add(description);

            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxheight = 500;
                int calculatedWidth = (int)(maxheight * aspectRatio);

                Guna2PictureBox postImage = new Guna2PictureBox
                {
                    Width = calculatedWidth,
                    Height = maxheight,
                    Image = image,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderRadius = 12,

                    Margin = new Padding(0,0,0,20),
                };
                mainPanel.Controls.Add(postImage);

            }

            RichTextBox rtb_content = new RichTextBox
            {

                Width = 800,
                Height = 800,
                Multiline = true, 
                WordWrap = true,
                BorderStyle = BorderStyle.None, 
                Font = new Font("Segoe UI", 20F),
               
            };
            string postPath = Path.Combine(parentDirectory, "Resources/Posts/" +b.NoiDung);
            try
            {

                rtb_content.LoadFile(postPath, RichTextBoxStreamType.RichText);

                mainPanel.Controls.Add(rtb_content);
            }catch (Exception e)
            {
            }

            Panel blankSpace = new Panel
            {
                Width = 1000,
                Height = 200,
            };
           mainPanel.Controls.Add(blankSpace);

            this.Controls.Add(mainPanel);

        }

        private void UC_Post_Load(object sender, EventArgs e)
        {

        }

        
    }
}
