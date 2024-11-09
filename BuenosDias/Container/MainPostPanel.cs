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
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BuenosDias.Container
{
    internal class MainPostPanel : FlowLayoutPanel
    {
        private readonly ImageService postImageService = new ImageService();
        public MainPostPanel( BaiViet b)
        {
            this.AutoScroll = true;
            this.WrapContents = true;
            this.FlowDirection = FlowDirection.TopDown;
            FlowLayoutPanel category = new FlowLayoutPanel { 
                Width = 1220,
                Height = 20,
                AutoSize = true,
            };
            //use loop here
            Guna.UI2.WinForms.Guna2HtmlLabel cat1 = new Guna2HtmlLabel
            {
                Text = "Đời sống /",
                Font = new Font("Segoe UI", 13F),
                Padding = new Padding(0, 0, 0, 0)
            };
            Guna.UI2.WinForms.Guna2HtmlLabel cat2 = new Guna2HtmlLabel
            {
                Text = "Đời sống /",
                Font = new Font("Segoe UI", 13F),
                Padding = new Padding(0, 0, 0, 0)
            };
            Guna.UI2.WinForms.Guna2HtmlLabel cat3 = new Guna2HtmlLabel {
                Text = "Đời sống /",
                Font = new Font("Segoe UI", 13F),
                Padding = new Padding(0, 0, 0, 0)
            };

            category.Controls.Add(cat1);
            category.Controls.Add(cat2);
            category.Controls.Add(cat3);

            this.Controls.Add(category);

            Label lbltieude = new Label
            {
                Margin = new Padding(0, 0, 50, 0),
                Text = b.TIeuDe,
                Font = new Font("Segoe UI", 30F, FontStyle.Bold),
                AutoSize = true
            };

            this.Controls.Add(lbltieude);
            string imagePath;
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            imagePath = Path.Combine(parentDirectory, "Resources/Images/Post/" + postImageService.GetTenHinhAnhBaibyID(b.IDBaiViet));

            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxHeight = 500;
                int calculatedWidth = (int)(maxHeight * aspectRatio);

                PictureBox pictureBox = new PictureBox
                {
                    Width = calculatedWidth,
                    Height = maxHeight,
                    Image = image,
                    Margin = new Padding((1220 - calculatedWidth) / 2, 0, 50, 0),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                this.Controls.Add(pictureBox);
            }

        }
        private void CenterControlInParent(Control control)
        {
            if (control.Parent != null)
            {
                control.Left = ( - control.Width) / 2;
                control.Top = (control.Parent.ClientSize.Height - control.Height) / 2;
            }
        }

    }
}
