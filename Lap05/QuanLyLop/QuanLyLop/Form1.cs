using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyLop
{
    public partial class Form1 : Form
    {
        TextBox txtMaKhoa = new TextBox();
        TextBox txtMaLop = new TextBox();
        TextBox txtTenLop = new TextBox();

        Button btnThem = new Button();
        Button btnXoa = new Button();
        Button btnSua = new Button();

        // Sửa tên server cho đúng máy của ông
        string chuoiKetNoi =
            @"Server=(localdb)\MSSQLLocalDB;Database=QLSinhVien;" +
            "Integrated Security=True;Encrypt=True;" +
            "TrustServerCertificate=True;";

        public Form1()
        {
            TaoGiaoDien();

            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
        }

        private void TaoGiaoDien()
        {
            this.Text = "Quản lý lớp";
            this.ClientSize = new Size(380, 210);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Label lblMaKhoa = new Label();
            lblMaKhoa.Text = "Mã khoa";
            lblMaKhoa.SetBounds(20, 25, 85, 25);
            this.Controls.Add(lblMaKhoa);

            txtMaKhoa.SetBounds(110, 22, 245, 28);
            txtMaKhoa.MaxLength = 20;
            this.Controls.Add(txtMaKhoa);

            Label lblMaLop = new Label();
            lblMaLop.Text = "Mã lớp";
            lblMaLop.SetBounds(20, 70, 85, 25);
            this.Controls.Add(lblMaLop);

            txtMaLop.SetBounds(110, 67, 245, 28);
            txtMaLop.MaxLength = 20;
            this.Controls.Add(txtMaLop);

            Label lblTenLop = new Label();
            lblTenLop.Text = "Tên lớp";
            lblTenLop.SetBounds(20, 115, 85, 25);
            this.Controls.Add(lblTenLop);

            txtTenLop.SetBounds(110, 112, 245, 28);
            txtTenLop.MaxLength = 100;
            this.Controls.Add(txtTenLop);

            btnThem.Text = "Thêm";
            btnThem.SetBounds(35, 165, 90, 30);
            this.Controls.Add(btnThem);

            btnXoa.Text = "Xóa";
            btnXoa.SetBounds(145, 165, 90, 30);
            this.Controls.Add(btnXoa);

            btnSua.Text = "Sửa";
            btnSua.SetBounds(255, 165, 90, 30);
            this.Controls.Add(btnSua);
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (txtMaKhoa.Text.Trim() == "" ||
                txtMaLop.Text.Trim() == "" ||
                txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ mã khoa, mã lớp và tên lớp!");
                return;
            }

            string sql =
                "INSERT INTO Lop (MaKhoa, MaLop, TenLop) " +
                "VALUES (@MaKhoa, @MaLop, @TenLop)";

            ThucHien(sql, "Thêm lớp thành công!");
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã lớp cần xóa!");
                txtMaLop.Focus();
                return;
            }

            // Theo đề, khi xóa chỉ nhập mã lớp
            if (txtMaKhoa.Text.Trim() != "" ||
                txtTenLop.Text.Trim() != "")
            {
                MessageBox.Show(
                    "Khi xóa, hãy để trống mã khoa và tên lớp!");
                return;
            }

            DialogResult traLoi = MessageBox.Show(
                "Bạn có muốn xóa lớp này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (traLoi == DialogResult.No)
                return;

            string sql = "DELETE FROM Lop WHERE MaLop = @MaLop";

            ThucHien(sql, "Xóa lớp thành công!");
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập mã lớp cần sửa!");
                txtMaLop.Focus();
                return;
            }

            if (txtMaKhoa.Text.Trim() == "" &&
                txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Hãy nhập mã khoa hoặc tên lớp cần thay đổi!");
                return;
            }

            // Nếu tham số là NULL thì giữ nguyên giá trị cũ
            string sql =
                "UPDATE Lop SET " +
                "MaKhoa = COALESCE(@MaKhoa, MaKhoa), " +
                "TenLop = COALESCE(@TenLop, TenLop) " +
                "WHERE MaLop = @MaLop";

            ThucHien(sql, "Sửa lớp thành công!");
        }

        private void ThucHien(string sql, string thongBao)
        {
            try
            {
                using (SqlConnection ketNoi =
                    new SqlConnection(chuoiKetNoi))
                {
                    ketNoi.Open();

                    using (SqlCommand lenh = new SqlCommand(sql, ketNoi))
                    {
                        lenh.Parameters.Add(
                            "@MaLop", System.Data.SqlDbType.NVarChar, 20
                        ).Value = txtMaLop.Text.Trim();

                        lenh.Parameters.Add(
                            "@MaKhoa", System.Data.SqlDbType.NVarChar, 20);

                        if (txtMaKhoa.Text.Trim() == "")
                            lenh.Parameters["@MaKhoa"].Value = DBNull.Value;
                        else
                            lenh.Parameters["@MaKhoa"].Value =
                                txtMaKhoa.Text.Trim();

                        lenh.Parameters.Add(
                            "@TenLop", System.Data.SqlDbType.NVarChar, 100);

                        if (txtTenLop.Text.Trim() == "")
                            lenh.Parameters["@TenLop"].Value = DBNull.Value;
                        else
                            lenh.Parameters["@TenLop"].Value =
                                txtTenLop.Text.Trim();

                        int soDong = lenh.ExecuteNonQuery();

                        if (soDong > 0)
                        {
                            MessageBox.Show(thongBao);

                            txtMaKhoa.Clear();
                            txtMaLop.Clear();
                            txtTenLop.Clear();
                            txtMaKhoa.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã lớp này!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Mã lớp đã tồn tại!");
                }
                else
                {
                    MessageBox.Show("Lỗi SQL Server: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}