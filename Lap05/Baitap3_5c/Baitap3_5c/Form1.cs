using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Baitap3_5c
{
    public partial class Form1 : Form
    {
        TreeView treeDanhBa = new TreeView();

        TextBox txtFirstName = new TextBox();
        TextBox txtLastName = new TextBox();

        Button btnAdd = new Button();
        Button btnExit = new Button();

        public Form1()
        {
            TaoGiaoDien();

            this.Load += Form1_Load;
            btnAdd.Click += btnAdd_Click;
            btnExit.Click += btnExit_Click;
        }

        private void TaoGiaoDien()
        {
            this.Text = "Danh bạ";
            this.ClientSize = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Times New Roman", 12);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Danh sách bên trái
            treeDanhBa.SetBounds(10, 10, 235, 380);
            treeDanhBa.HideSelection = false;
            this.Controls.Add(treeDanhBa);

            // Khung nhập thông tin bên phải
            GroupBox grpNhap = new GroupBox();
            grpNhap.Text = "Thông tin";
            grpNhap.SetBounds(260, 20, 325, 165);
            this.Controls.Add(grpNhap);

            Label lblFirstName = new Label();
            lblFirstName.Text = "First Name";
            lblFirstName.SetBounds(15, 35, 105, 25);
            grpNhap.Controls.Add(lblFirstName);

            txtFirstName.SetBounds(130, 32, 180, 28);
            grpNhap.Controls.Add(txtFirstName);

            Label lblLastName = new Label();
            lblLastName.Text = "Last Name";
            lblLastName.SetBounds(15, 80, 105, 25);
            grpNhap.Controls.Add(lblLastName);

            txtLastName.SetBounds(130, 77, 180, 28);
            grpNhap.Controls.Add(txtLastName);

            btnAdd.Text = "Add";
            btnAdd.SetBounds(220, 120, 90, 30);
            grpNhap.Controls.Add(btnAdd);

            btnExit.Text = "Exit";
            btnExit.SetBounds(495, 205, 90, 30);
            this.Controls.Add(btnExit);

            // Nhấn Enter để thêm người
            this.AcceptButton = btnAdd;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Tạo các nhánh từ A đến Z
            for (char chu = 'A'; chu <= 'Z'; chu++)
            {
                treeDanhBa.Nodes.Add(chu.ToString());
            }

            txtFirstName.Focus();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string ten = txtFirstName.Text.Trim();
            string ho = txtLastName.Text.Trim();

            if (ten == "" || ho == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ tên và họ!");

                if (ten == "")
                    txtFirstName.Focus();
                else
                    txtLastName.Focus();

                return;
            }

            // Lấy chữ đầu của tên và chuyển thành chữ không dấu
            string chuDau = BoDau(ten.Substring(0, 1)).ToUpperInvariant();

            if (chuDau.Length != 1 ||
                chuDau[0] < 'A' || chuDau[0] > 'Z')
            {
                MessageBox.Show("Tên phải bắt đầu bằng chữ cái A đến Z hoặc chữ Việt có dấu!");
                txtFirstName.Focus();
                return;
            }

            string hoTen = ten + ", " + ho;

            // Tìm nhánh tương ứng với chữ đầu
            for (int i = 0; i < treeDanhBa.Nodes.Count; i++)
            {
                if (treeDanhBa.Nodes[i].Text == chuDau)
                {
                    TreeNode nguoiMoi = new TreeNode(hoTen);

                    treeDanhBa.Nodes[i].Nodes.Add(nguoiMoi);
                    treeDanhBa.Nodes[i].Expand();

                    treeDanhBa.SelectedNode = nguoiMoi;
                    nguoiMoi.EnsureVisible();

                    break;
                }
            }

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        private string BoDau(string chu)
        {
            // Đ và đ không được tách dấu bằng Normalize
            chu = chu.Replace('Đ', 'D').Replace('đ', 'd');

            string chuTachDau = chu.Normalize(NormalizationForm.FormD);
            string ketQua = "";

            for (int i = 0; i < chuTachDau.Length; i++)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(chuTachDau[i])
                    != UnicodeCategory.NonSpacingMark)
                {
                    ketQua = ketQua + chuTachDau[i];
                }
            }

            return ketQua;
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}