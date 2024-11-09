using BuenosDias.BUS;
using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.GUII.User_controls
{
    public partial class NewBaiVietFrom_PostDescription : Form
    {
        private BaiViet bai;
        public NewBaiVietFrom_PostDescription(BaiViet baiviet)
        {
            InitializeComponent();
            bai = baiviet;
            this.guna2TextBox1.Text = baiviet.TIeuDe;
            this.guna2TextBox2.MaxLength = 180;
        }

        private void NewBaiVietFrom_PostDescription_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {

            
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string targetFilePath = Path.Combine(projectDirectory, "Resources", "Posts");

            SaveFileDialog dlg = new SaveFileDialog
            {
                InitialDirectory = targetFilePath, // Set your desired directory
                FileName = "pre_"+ bai.IDBaiViet+".txt" // Set the default file name
            };

            string sourceFilePath = Path.Combine(targetFilePath, dlg.FileName);
            File.WriteAllText(sourceFilePath, guna2TextBox2.Text);
                this.Close();
                MessageBox.Show("Đăng thành công ^^");
            }
            catch (Exception )
            {
                MessageBox.Show("Something went wrong O.o");
            }
        }
    }
}
