using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_Tap_Lap05
{
    public partial class Form1 : Form
    {
        // Các control dùng trong chương trình
        TabControl tab = new TabControl();
        TabPage tabAnhViet = new TabPage();
        TabPage tabVietAnh = new TabPage();

        ComboBox cboAnh = new ComboBox();
        ComboBox cboViet = new ComboBox();

        TextBox txtViet = new TextBox();
        TextBox txtAnh = new TextBox();

        Button btnThoat = new Button();

        // Hai từ cùng vị trí là một cặp dịch
        string[] tiengAnh =
        {
            "student", "teacher", "worker", "hat", "head",
            "mouse", "cat", "dog", "snake", "lamb",
            "loan", "frog", "sheep"
        };

        string[] tiengViet =
        {
            "sinh viên, học sinh", "giáo viên", "công nhân",
            "mũ", "đầu", "chuột", "mèo", "chó", "rắn",
            "cừu con", "khoản vay", "ếch", "cừu"
        };

        public Form1()
        {
            TaoGiaoDien();

            // Thêm các từ vào danh sách
            for (int i = 0; i < tiengAnh.Length; i++)
            {
                cboAnh.Items.Add(tiengAnh[i]);
                cboViet.Items.Add(tiengViet[i]);
            }

            // Gắn sự kiện bằng code
            cboAnh.KeyDown += cboAnh_KeyDown;
            cboViet.KeyDown += cboViet_KeyDown;

            cboAnh.DoubleClick += cboAnh_DoubleClick;
            cboViet.DoubleClick += cboViet_DoubleClick;

            btnThoat.Click += btnThoat_Click;
        }

        private void TaoGiaoDien()
        {
            // Cửa sổ chính
            this.Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            this.ClientSize = new Size(440, 365);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Khung chứa hai tab
            tab.Location = new Point(15, 15);
            tab.Size = new Size(410, 295);

            tabAnhViet.Text = "ANH - VIỆT";
            tabVietAnh.Text = "VIỆT - ANH";

            tab.TabPages.Add(tabAnhViet);
            tab.TabPages.Add(tabVietAnh);

            this.Controls.Add(tab);

            // ===== Tab Anh - Việt =====
            Label lblAnh = new Label();
            lblAnh.Text = "Tiếng Anh";
            lblAnh.Location = new Point(15, 15);
            lblAnh.AutoSize = true;
            tabAnhViet.Controls.Add(lblAnh);

            Label lblViet = new Label();
            lblViet.Text = "Tiếng Việt";
            lblViet.Location = new Point(205, 15);
            lblViet.AutoSize = true;
            tabAnhViet.Controls.Add(lblViet);

            cboAnh.Location = new Point(15, 40);
            cboAnh.DropDownStyle = ComboBoxStyle.Simple;
            cboAnh.Size = new Size(175, 210);
            cboAnh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAnh.AutoCompleteSource = AutoCompleteSource.ListItems;
            tabAnhViet.Controls.Add(cboAnh);

            txtViet.Location = new Point(205, 40);
            txtViet.Size = new Size(180, 210);
            txtViet.Multiline = true;
            txtViet.ReadOnly = true;
            txtViet.BackColor = Color.White;
            tabAnhViet.Controls.Add(txtViet);

            // ===== Tab Việt - Anh =====
            Label lblViet2 = new Label();
            lblViet2.Text = "Tiếng Việt";
            lblViet2.Location = new Point(15, 15);
            lblViet2.AutoSize = true;
            tabVietAnh.Controls.Add(lblViet2);

            Label lblAnh2 = new Label();
            lblAnh2.Text = "Tiếng Anh";
            lblAnh2.Location = new Point(205, 15);
            lblAnh2.AutoSize = true;
            tabVietAnh.Controls.Add(lblAnh2);

            cboViet.Location = new Point(15, 40);
            cboViet.DropDownStyle = ComboBoxStyle.Simple;
            cboViet.Size = new Size(175, 210);
            cboViet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboViet.AutoCompleteSource = AutoCompleteSource.ListItems;
            tabVietAnh.Controls.Add(cboViet);

            txtAnh.Location = new Point(205, 40);
            txtAnh.Size = new Size(180, 210);
            txtAnh.Multiline = true;
            txtAnh.ReadOnly = true;
            txtAnh.BackColor = Color.White;
            tabVietAnh.Controls.Add(txtAnh);

            // Nút thoát
            btnThoat.Text = "Thoát";
            btnThoat.Location = new Point(335, 320);
            btnThoat.Size = new Size(90, 30);
            this.Controls.Add(btnThoat);
        }

        private void TraAnhViet()
        {
            string tu = cboAnh.Text.Trim().ToLower();

            for (int i = 0; i < tiengAnh.Length; i++)
            {
                if (tu == tiengAnh[i].ToLower())
                {
                    txtViet.Text = tiengViet[i];
                    return;
                }
            }

            txtViet.Text = "Không tìm thấy từ!";
        }

        private void TraVietAnh()
        {
            string tu = cboViet.Text.Trim().ToLower();

            for (int i = 0; i < tiengViet.Length; i++)
            {
                if (tu == tiengViet[i].ToLower())
                {
                    txtAnh.Text = tiengAnh[i];
                    return;
                }
            }

            txtAnh.Text = "Không tìm thấy từ!";
        }

        private void cboAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraAnhViet();
                e.SuppressKeyPress = true;
            }
        }

        private void cboViet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraVietAnh();
                e.SuppressKeyPress = true;
            }
        }

        private void cboAnh_DoubleClick(object sender, EventArgs e)
        {
            TraAnhViet();
        }

        private void cboViet_DoubleClick(object sender, EventArgs e)
        {
            TraVietAnh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}