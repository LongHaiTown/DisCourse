using BuenosDias.Container;
using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias
{
    public partial class BaiVietForm : Form
    {
        public BaiVietForm(BaiViet b)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;

            this.Size = new Size(1280, 720);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#e1d7b7");

            MainPostPanel Main = new MainPostPanel(b)
            {
                Location = new Point(20, 20),
                Size = new Size(1220,700),
            };
           

            this.Controls.Add(Main);
        }

        private void BaiVietForm_Load(object sender, EventArgs e)
        {

        }
    }
}
