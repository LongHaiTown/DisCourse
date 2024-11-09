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

namespace BuenosDias.GUII.Component
{
    public class CoursePanel : Guna2Panel
    {
        private readonly ImageService imageService = new ImageService();
        private readonly Action<KhoaHoc> _switchToCourseUC;

        public CoursePanel(KhoaHoc k, Action<KhoaHoc> switchToCourseUC)
        {
            _switchToCourseUC = switchToCourseUC;

            BorderRadius = 12;
            BorderThickness = 2;
            BorderColor = Color.Gray;
            BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            Padding = new Padding(0, 0, 5, 0);
            
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/CourseCover/" + imageService.GetCourseCover(k.MaKhoaHoc));
            if (System.IO.File.Exists(imagePath))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);
                float aspectRatio = (float)image.Width / image.Height;
                int maxHeight = this.Height;
                int calculatedWidth = (int)(maxHeight * aspectRatio);

                Guna2PictureBox courseCover = new Guna2PictureBox
                {
                    Location = new Point(5, 5),
                    Width = this.Width - 10,
                    Height = this.Height,
                    Image = image,
                    SizeMode = PictureBoxSizeMode.StretchImage, 
                    FillColor = Color.Gray,
                    BorderRadius = 12,

                };
                courseCover.Click += (sender, e) => switchToCourseUC?.Invoke(k);

                this.Controls.Add(courseCover);
            }

            Label courseName = new Label()
            {
                Location = new Point(5, this.Height +10),
                Text = k.TenKhoaHoc,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                AutoSize = true,
                MaximumSize = new Size(this.Width,this.Height),
               
            };
            courseName.Click += (sender, e) => switchToCourseUC?.Invoke(k);

            this.Controls.Add(courseName);
            Label userCreated = new Label
            {
                Location = new Point(5, this.Height + 30),
                Text = k.User_.TenUser,
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.DimGray,
                AutoSize = true,

            };
            this.Controls.Add(userCreated);


        }
    }
}
