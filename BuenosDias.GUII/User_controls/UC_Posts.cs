using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using BuenosDias.GUII.Component;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.GUII.User_controls
{
    public partial class UC_Posts : UserControl
    {
        private readonly postServices postServices = new postServices();
        private FlowLayoutPanel mainPanel;
        private List<BaiViet> loadedBaiViet;
        public UC_Posts(User_ user)
        {
            InitializeComponent();
            this.BackColor = Color.White;
            FlowLayoutPanel mainPanel = new FlowLayoutPanel
            {
                Location = new Point(50, 35),
                Width = 1550,
                Height = this.Height,
                AutoScroll = true,
                WrapContents = false,

                FlowDirection = FlowDirection.TopDown,
            };
            loadedBaiViet = postServices.GetBaiViets();
            for (int i = loadedBaiViet.Count-1; i >=0; i--)
            {
                if (i >0) { 
                    PostPanel postPanel = new PostPanel(loadedBaiViet[i], createPostUC)
                    {
                        Size = new Size(900, 200),

                    };
                   
                    mainPanel.Controls.Add(postPanel);
                    this.Controls.Add(mainPanel);
                }else
                {
                    PostPanel postPanel = new PostPanel(loadedBaiViet[i], null)
                    {
                        Size = new Size(900, 200),
                        BackColor = Color.Red,
                        Visible = false

                    };

                    mainPanel.Controls.Add(postPanel);
                    this.Controls.Add(mainPanel);
                }
            }
        }
        private void addUserControls(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(uc);
            uc.BringToFront();
        }
        private void createPostUC(BaiViet b)
        {
            UC_Post SpecificPost = new UC_Post(b);
            addUserControls(SpecificPost);
            MessageBox.Show("Open Successfully");
        }

        private void UC_Posts_Load(object sender, EventArgs e)
        {
        }
    }
}
