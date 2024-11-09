using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace BuenosDias.Container
{
    internal class NewPost : Panel
    {
        //rounded corner in the Internet
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(this.Width - 21, 0, 20, 20, 270, 90);
                path.AddArc(this.Width - 21, this.Height - 21, 20, 20, 0, 90);
                path.AddArc(0, this.Height - 21, 20, 20, 90, 90);
                path.CloseAllFigures();
                this.Region = new Region(path);
            }
        }
        public NewPost(string text)
        {
            Label lbl = new Label
            {
                Text = text,
                ForeColor = Color.Black,
                Font = new Font("Arial", 12F, FontStyle.Italic),
                Location = new Point(8, 9),
                TextAlign = ContentAlignment.MiddleCenter,

                AutoSize = true

            };
            lbl.Click += new EventHandler(newBaiVietFormAppear);

            this.Click += new EventHandler(newBaiVietFormAppear);

            this.Controls.Add(lbl);
        }
        private void newBaiVietFormAppear(object sender, EventArgs e)
        {
            NewBaiVietForm newBaiVietForm = new NewBaiVietForm();
            newBaiVietForm.Show();
        }
    }
}

