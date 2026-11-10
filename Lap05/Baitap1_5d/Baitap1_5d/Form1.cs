using System;
using System.Drawing;
using System.Windows.Forms;

namespace Baitap1_5d
{
    public partial class Form1 : Form
    {
        Label lblThoiGian = new Label();
        Button btnBatDau = new Button();

        System.Windows.Forms.Timer timer =
            new System.Windows.Forms.Timer();

        int tongGiay = 30 * 60;

        public Form1()
        {
            // Tạo cửa sổ
            this.Text = "Đồng hồ";
            this.ClientSize = new Size(220, 100);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Hiển thị thời gian
            lblThoiGian.Text = "30:00";
            lblThoiGian.Font = new Font(
                "Consolas", 14, FontStyle.Bold);
            lblThoiGian.TextAlign = ContentAlignment.MiddleCenter;
            lblThoiGian.SetBounds(60, 10, 100, 30);
            this.Controls.Add(lblThoiGian);

            // Nút bắt đầu
            btnBatDau.Text = "Bắt đầu";
            btnBatDau.SetBounds(70, 45, 80, 35);
            this.Controls.Add(btnBatDau);

            // Timer chạy mỗi 1.000 mili giây = 1 giây
            timer.Interval = 1000;

            btnBatDau.Click += btnBatDau_Click;
            timer.Tick += timer_Tick;
        }

        private void btnBatDau_Click(object? sender, EventArgs e)
        {
            tongGiay = 30 * 60;
            lblThoiGian.Text = "30:00";

            btnBatDau.Enabled = false;
            timer.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            tongGiay--;

            int phut = tongGiay / 60;
            int giay = tongGiay % 60;

            lblThoiGian.Text =
                phut.ToString("00") + ":" + giay.ToString("00");

            if (tongGiay == 0)
            {
                timer.Stop();
                btnBatDau.Enabled = true;

                MessageBox.Show("Hết giờ!");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timer.Dispose();
            base.OnFormClosed(e);
        }
    }
}