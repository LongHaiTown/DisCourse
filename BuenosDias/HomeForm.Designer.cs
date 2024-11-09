namespace BuenosDias
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sideBar = new System.Windows.Forms.Panel();
            this.homePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sssToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1582, 47);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sssToolStripMenuItem
            // 
            this.sssToolStripMenuItem.Name = "sssToolStripMenuItem";
            this.sssToolStripMenuItem.Size = new System.Drawing.Size(41, 43);
            this.sssToolStripMenuItem.Text = "sss";
            this.sssToolStripMenuItem.Click += new System.EventHandler(this.sssToolStripMenuItem_Click);
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sideBar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.sideBar.Location = new System.Drawing.Point(1300, 40);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(300, 1047);
            this.sideBar.TabIndex = 2;
            // 
            // homePanel
            // 
            this.homePanel.Location = new System.Drawing.Point(0, 40);
            this.homePanel.Name = "homePanel";
            this.homePanel.Padding = new System.Windows.Forms.Padding(40, 40, 50, 50);
            this.homePanel.Size = new System.Drawing.Size(1300, 868);
            this.homePanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.homePanel);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Buenos Dias";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel sideBar;
        private System.Windows.Forms.FlowLayoutPanel homePanel;
        private System.Windows.Forms.ToolStripMenuItem sssToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}

