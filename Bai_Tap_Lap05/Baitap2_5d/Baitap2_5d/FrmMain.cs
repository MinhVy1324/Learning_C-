using System;
using System.Drawing;
using System.Windows.Forms;

namespace Baitap2_5d
{
    public class FrmMain : Form
    {
        MenuStrip menu = new MenuStrip();

        public FrmMain()
        {
            this.Text = "Tổng hợp bài tập WinForms";
            this.ClientSize = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true;

            ToolStripMenuItem bai1 = new ToolStripMenuItem();
            bai1.Text = "Bài trong Bai_Tap_Lap05";
            bai1.Click += bai1_Click;

            ToolStripMenuItem bai2 = new ToolStripMenuItem();
            bai2.Text = "Bài trong Baitap2_5c";
            bai2.Click += bai2_Click;

            ToolStripMenuItem bai3 = new ToolStripMenuItem();
            bai3.Text = "Bài trong Baitap3_5c";
            bai3.Click += bai3_Click;

            ToolStripMenuItem bai4 = new ToolStripMenuItem();
            bai4.Text = "Bài trong Baitap1_5d";
            bai4.Click += bai4_Click;

            ToolStripMenuItem thoat = new ToolStripMenuItem();
            thoat.Text = "Thoát";
            thoat.Click += thoat_Click;

            menu.Items.Add(bai1);
            menu.Items.Add(bai2);
            menu.Items.Add(bai3);
            menu.Items.Add(bai4);
            menu.Items.Add(thoat);

            this.MainMenuStrip = menu;
            this.Controls.Add(menu);
        }

        private void bai1_Click(object? sender, EventArgs e)
        {
            Bai_Tap_Lap05.Form1 f = new Bai_Tap_Lap05.Form1();
            f.MdiParent = this;
            f.Show();
        }

        private void bai2_Click(object? sender, EventArgs e)
        {
            Baitap2_5c.Form1 f = new Baitap2_5c.Form1();
            f.MdiParent = this;
            f.Show();
        }

        private void bai3_Click(object? sender, EventArgs e)
        {
            Baitap3_5c.Form1 f = new Baitap3_5c.Form1();
            f.MdiParent = this;
            f.Show();
        }

        private void bai4_Click(object? sender, EventArgs e)
        {
            Baitap1_5d.Form1 f = new Baitap1_5d.Form1();
            f.MdiParent = this;
            f.Show();
        }

        private void thoat_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}