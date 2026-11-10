using System;
using System.Drawing;
using System.Windows.Forms;

namespace Baitap2_5c
{
    public partial class Form1 : Form
    {
        TextBox txtSo = new TextBox();
        ListBox lstSo = new ListBox();

        public Form1()
        {
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            this.Text = "Bài tập ListBox";
            this.ClientSize = new Size(460, 390);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "LISTBOX";
            lblTieuDe.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.DarkOrange;
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.SetBounds(10, 10, 440, 40);
            this.Controls.Add(lblTieuDe);

            Label lblSo = new Label();
            lblSo.Text = "Nhập số tự nhiên:";
            lblSo.SetBounds(20, 60, 170, 25);
            this.Controls.Add(lblSo);

            txtSo.SetBounds(20, 90, 170, 28);
            this.Controls.Add(txtSo);

            Button btnNhap = new Button();
            btnNhap.Text = "Nhập";
            btnNhap.SetBounds(20, 125, 170, 32);
            btnNhap.Click += btnNhap_Click;
            this.Controls.Add(btnNhap);

            lstSo.SetBounds(20, 165, 170, 175);

            // Cho phép chọn nhiều phần tử
            lstSo.SelectionMode = SelectionMode.MultiSimple;
            this.Controls.Add(lstSo);

            Label lblXuLy = new Label();
            lblXuLy.Text = "Xử lý ListBox:";
            lblXuLy.SetBounds(210, 60, 230, 25);
            this.Controls.Add(lblXuLy);

            Button btnTong = new Button();
            btnTong.Text = "Tổng các phần tử";
            btnTong.SetBounds(210, 90, 230, 30);
            btnTong.Click += btnTong_Click;
            this.Controls.Add(btnTong);

            Button btnXoaDauCuoi = new Button();
            btnXoaDauCuoi.Text = "Xóa phần tử đầu và cuối";
            btnXoaDauCuoi.SetBounds(210, 125, 230, 30);
            btnXoaDauCuoi.Click += btnXoaDauCuoi_Click;
            this.Controls.Add(btnXoaDauCuoi);

            Button btnXoaChon = new Button();
            btnXoaChon.Text = "Xóa phần tử đang chọn";
            btnXoaChon.SetBounds(210, 160, 230, 30);
            btnXoaChon.Click += btnXoaChon_Click;
            this.Controls.Add(btnXoaChon);

            Button btnTang = new Button();
            btnTang.Text = "Tăng mỗi phần tử lên 2";
            btnTang.SetBounds(210, 195, 230, 30);
            btnTang.Click += btnTang_Click;
            this.Controls.Add(btnTang);

            Button btnBinhPhuong = new Button();
            btnBinhPhuong.Text = "Thay bằng bình phương";
            btnBinhPhuong.SetBounds(210, 230, 230, 30);
            btnBinhPhuong.Click += btnBinhPhuong_Click;
            this.Controls.Add(btnBinhPhuong);

            Button btnChan = new Button();
            btnChan.Text = "Chọn số chẵn";
            btnChan.SetBounds(210, 265, 230, 30);
            btnChan.Click += btnChan_Click;
            this.Controls.Add(btnChan);

            Button btnLe = new Button();
            btnLe.Text = "Chọn số lẻ";
            btnLe.SetBounds(210, 300, 230, 30);
            btnLe.Click += btnLe_Click;
            this.Controls.Add(btnLe);

            Button btnThoat = new Button();
            btnThoat.Text = "KẾT THÚC";
            btnThoat.SetBounds(20, 350, 420, 30);
            btnThoat.Click += btnThoat_Click;
            this.Controls.Add(btnThoat);

            // Nhấn Enter để nhập số
            this.AcceptButton = btnNhap;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            int n;

            if (int.TryParse(txtSo.Text, out n) == false || n < 0)
            {
                MessageBox.Show("Hãy nhập số nguyên từ 0 đến 2.147.483.647!");
                txtSo.Focus();
                txtSo.SelectAll();
                return;
            }

            // Lưu bằng long để chứa được các số lớn hơn sau tính toán
            lstSo.Items.Add((long)n);

            txtSo.Clear();
            txtSo.Focus();
        }

        private void btnTong_Click(object sender, EventArgs e)
        {
            decimal tong = 0;

            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long n = Convert.ToInt64(lstSo.Items[i]);
                tong = tong + n;
            }

            MessageBox.Show("Tổng các phần tử là: " + tong);
        }

        private void btnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (lstSo.Items.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!");
                return;
            }

            // Xóa cuối trước để không làm thay đổi vị trí phần tử đầu
            int viTriCuoi = lstSo.Items.Count - 1;
            lstSo.Items.RemoveAt(viTriCuoi);

            // Nếu chỉ có một phần tử thì đã xóa xong
            if (lstSo.Items.Count > 0)
            {
                lstSo.Items.RemoveAt(0);
            }
        }

        private void btnXoaChon_Click(object sender, EventArgs e)
        {
            if (lstSo.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Hãy chọn phần tử cần xóa!");
                return;
            }

            // Duyệt ngược để không bỏ sót phần tử sau khi xóa
            for (int i = lstSo.Items.Count - 1; i >= 0; i--)
            {
                if (lstSo.GetSelected(i))
                {
                    lstSo.Items.RemoveAt(i);
                }
            }
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            // Kiểm tra trước để tránh vượt giới hạn của long
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long n = Convert.ToInt64(lstSo.Items[i]);

                if (n > long.MaxValue - 2)
                {
                    MessageBox.Show("Số quá lớn, không thể tăng thêm!");
                    return;
                }
            }

            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long n = Convert.ToInt64(lstSo.Items[i]);
                lstSo.Items[i] = n + 2;
            }
        }

        private void btnBinhPhuong_Click(object sender, EventArgs e)
        {
            // Kiểm tra toàn bộ danh sách trước khi thay đổi
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long n = Convert.ToInt64(lstSo.Items[i]);

                if (n > 3037000499L)
                {
                    MessageBox.Show("Số quá lớn để bình phương bằng kiểu long!");
                    return;
                }
            }

            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long n = Convert.ToInt64(lstSo.Items[i]);
                lstSo.Items[i] = n * n;
            }
        }

        private void btnChan_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();

            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long n = Convert.ToInt64(lstSo.Items[i]);

                if (n % 2 == 0)
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }

        private void btnLe_Click(object sender, EventArgs e)
        {
            lstSo.ClearSelected();

            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long n = Convert.ToInt64(lstSo.Items[i]);

                if (n % 2 != 0)
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}