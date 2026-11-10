using System.Drawing;

namespace Bai1_ThucHanh6c
{
    internal sealed class ProductForm : Form
    {
        private readonly TextBox nameTextBox = new();

        public ProductForm()
        {
            Text = "Thêm sản phẩm mới";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(450, 205);
            BackColor = Color.FromArgb(246, 248, 251);
            Font = new Font("Segoe UI", 10F);

            var title = new Label
            {
                Text = "THÊM SẢN PHẨM",
                Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 58, 82),
                AutoSize = true,
                Location = new Point(24, 18)
            };
            var nameLabel = new Label { Text = "Tên sản phẩm", AutoSize = true, Location = new Point(27, 78) };
            nameTextBox.Location = new Point(150, 73);
            nameTextBox.Size = new Size(270, 29);
            nameTextBox.MaxLength = 100;

            var addButton = new Button
            {
                Text = "Thêm",
                Location = new Point(150, 130),
                Size = new Size(110, 38),
                BackColor = Color.FromArgb(49, 135, 104),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += AddProduct;

            var closeButton = new Button
            {
                Text = "Thoát",
                Location = new Point(278, 130),
                Size = new Size(110, 38),
                DialogResult = DialogResult.Cancel
            };

            Controls.AddRange([title, nameLabel, nameTextBox, addButton, closeButton]);
            AcceptButton = addButton;
            CancelButton = closeButton;
        }

        private void AddProduct(object? sender, EventArgs e)
        {
            var name = nameTextBox.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập tên sản phẩm.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                return;
            }

            try
            {
                Database.AddProduct(name);
                MessageBox.Show(this, "Đã thêm sản phẩm và tạo tồn kho hôm nay với số lượng bằng 0.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTextBox.Clear();
                nameTextBox.Focus();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number is 2601 or 2627)
            {
                MessageBox.Show(this, "Tên sản phẩm này đã tồn tại.", "Sản phẩm trùng tên",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                nameTextBox.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Không thể thêm sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
