using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.Container
{

    public class DivPanel : Panel
    {
        TextBox noidung;
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
        public DivPanel(BaiViet b)
        {
            this.Size = new System.Drawing.Size(900, 175);
            this.AutoScroll = true;
            this.BorderStyle = BorderStyle.FixedSingle; // Optional, for visual reference

            Label label = new Label
            {
                Text = b.TIeuDe,
                Font = new Font("Arial", 20F, FontStyle.Bold),
                Location = new System.Drawing.Point(15, 10),
                Padding = new Padding(0, 0, 0, 0),
                AutoSize = false,
                Size = new System.Drawing.Size(850, 30),

            };
            label.Click += (sender, e) => createPostForm(b);
            avt_name info = new avt_name(b.User_)
            {
                Location = new System.Drawing.Point(22, 45),
                Size = new System.Drawing.Size(200, 20),

            };
            TextBox noidung = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.None,
                Font = new Font("Roboto", 11F), // Adjust the font as needed
                Size = new System.Drawing.Size(850, 69), // Adjust the size as needed

                ForeColor = ColorTranslator.FromHtml("#333333"), // Use your chosen color code
                Location = new System.Drawing.Point(20, 70),
                BackColor = Color.White, // Make the background transparent
                BorderStyle = BorderStyle.None,
                WordWrap = true,

            };

            string parentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(parentDirectory, "Resources/Posts/" + b.NoiDung);
            string text = File.ReadAllText(filePath);

            AdjustHeights(noidung, text, 5);

            this.Controls.Add(label);
            this.Controls.Add(info);
            this.Controls.Add(noidung);
        }


        private int CalculateLineCount(string text, Font font, int width)
        {
            using (Graphics g = this.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(text, font, width);
                return (int)Math.Ceiling(textSize.Height / font.GetHeight());
            }
        }

        private void AdjustHeights(TextBox noidung, string text, int maxLines)
        {
            int lineHeight = (int)noidung.Font.GetHeight() + 2; // Adjust line height to account for padding
            int lineCount = CalculateLineCount(text, noidung.Font, noidung.Width);
            lineCount = Math.Min(lineCount, maxLines); // Limit to max lines

            int textHeight = lineCount * lineHeight;
            noidung.Text = text.Length > 500 ? text.Substring(0, 500) + " ..." : text;
            noidung.Height = textHeight;
            this.Height = textHeight + 100; // Adjust panel height for other controls and padding
        }

        private void createPostForm(BaiViet b)
        {
            BaiVietForm postform = new BaiVietForm(b);
            postform.Show();
        }
    }
}
