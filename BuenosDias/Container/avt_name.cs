using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuenosDias.Properties;
using System.IO;
using BuenosDias.DALL.Models;

namespace BuenosDias.Container
{

    public class avt_name : Panel
    {
        //rounded corner in the Internet
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //    using (GraphicsPath path = new GraphicsPath())
        //    {
        //        path.AddArc(0, 0, 20, 20, 180, 90);
        //        path.AddArc(this.Width - 21, 0, 20, 20, 270, 90);
        //        path.AddArc(this.Width - 21, this.Height - 21, 20, 20, 0, 90);
        //        path.AddArc(0, this.Height - 21, 20, 20, 90, 90);
        //        path.CloseAllFigures();
        //        this.Region = new Region(path);
        //    }
        //}
        public avt_name(User_ u)
        {
            // Avatar setup
            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string imagePath = Path.Combine(parentDirectory, "Resources/Images/Avt/OIP.jpg");
           

            PictureBox avatar = new PictureBox
            {
                Size = new System.Drawing.Size(20, 20),
                Location = new System.Drawing.Point(0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(imagePath)
            };

            // Make avatar round
            avatar.Paint += (sender, e) =>
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0, 0, avatar.Width - 1, avatar.Height - 1);
                avatar.Region = new Region(gp);
            };

            this.Controls.Add(avatar);
            Label lbl = new Label
            {
                Text = u.TenUser,
                Font = new Font("Arial", 8F, FontStyle.Italic),
                Location = new System.Drawing.Point(20, 0),
                Padding = new Padding(0, 2, 0,5),
                AutoSize = false,
                Size = new System.Drawing.Size(200, 30),
            };

            this.Controls.Add(lbl);
          
        }
    }
}
