using BuenosDias.BUS;
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
    public partial class MainForm : Form
    {
        public UserServices userServices = new UserServices();
        public postServices postServices = new postServices();
        public List<BaiViet> recommend = new List<BaiViet>();

        public MainForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#e1d7b7");
            sideBar.BackColor =  System.Drawing.ColorTranslator.FromHtml("#7c93c3");
            menuStrip1.BackColor = System.Drawing.ColorTranslator.FromHtml("#1e2a5e");
            

            homePanel.AutoScroll = true;
            homePanel.WrapContents = true;
            homePanel.FlowDirection = FlowDirection.LeftToRight;

            NewPost newBaiViet = new NewPost("what's on your mind")
            {
                Size = new System.Drawing.Size(160, 40),
                Location = new Point(10, 100),
                BackColor = Color.White,

            };
            sideBar.Controls.Add(newBaiViet);

            
            this.ActiveControl = newBaiViet;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fetchBaiViet();
        }
        public void fetchBaiViet()
        {
            recommend = postServices.GetBaiViets();

            for (int i = recommend.Count-1; i >=0 ; i--)
            {
                BaiViet b = recommend[i];
                DivPanel divPanel = new DivPanel(b)
                {
                    Margin = new Padding(0, 0, 0, 30),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None

                };
                homePanel.Controls.Add(divPanel);
            }
        }

        private void sssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            homePanel.Controls.Clear();
            fetchBaiViet();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
