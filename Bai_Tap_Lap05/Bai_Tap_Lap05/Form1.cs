namespace Bai_Tap_Lap05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int n;

            if (int.TryParse(txtNhapSo.Text, out n) == false || n <= 0)
            {
                MessageBox.Show("Bạn phải nhập số nguyên dương!");
                txtNhapSo.Focus();
                return;
            }

            if (cboSo.Items.Contains(n))
            {
                MessageBox.Show("Số này đã có trong danh sách!");
                txtNhapSo.Focus();
                return;
            }

            cboSo.Items.Add(n);

            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }
        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSo.SelectedIndex == -1)
                return;

            int n = Convert.ToInt32(cboSo.SelectedItem);

            lstUocSo.Items.Clear();

            for (long i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    lstUocSo.Items.Add(i);
                }
            }
        }
        private void btnTong_Click(object sender, EventArgs e)
        {
            if (cboSo.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn hãy chọn một số trước!");
                return;
            }

            long tong = 0;

            for (int i = 0; i < lstUocSo.Items.Count; i++)
            {
                long uoc = Convert.ToInt64(lstUocSo.Items[i]);
                tong = tong + uoc;
            }

            MessageBox.Show("Tổng các ước số là: " + tong);
        }
        private void btnDemChan_Click(object sender, EventArgs e)
        {
            if (cboSo.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn hãy chọn một số trước!");
                return;
            }

            int dem = 0;

            for (int i = 0; i < lstUocSo.Items.Count; i++)
            {
                int uoc = Convert.ToInt32(lstUocSo.Items[i]);

                if (uoc % 2 == 0)
                {
                    dem++;
                }
            }

            MessageBox.Show("Số lượng ước chẵn là: " + dem);
        }
        private bool LaSoNguyenTo(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        private void btnDemNguyenTo_Click(object sender, EventArgs e)
        {
            if (cboSo.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn hãy chọn một số trước!");
                return;
            }

            int dem = 0;

            for (int i = 0; i < lstUocSo.Items.Count; i++)
            {
                int uoc = Convert.ToInt32(lstUocSo.Items[i]);

                if (LaSoNguyenTo(uoc))
                {
                    dem++;
                }
            }

            MessageBox.Show("Số lượng ước nguyên tố là: " + dem);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traLoi = MessageBox.Show(
                "Bạn có muốn thoát không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (traLoi == DialogResult.Yes)
            {
                Close();
            }
        }

    }
}      

