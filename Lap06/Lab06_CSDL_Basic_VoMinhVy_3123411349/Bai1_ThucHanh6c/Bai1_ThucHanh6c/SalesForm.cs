using System.Data;
using System.Drawing;

namespace Bai1_ThucHanh6c
{
    internal sealed class SalesForm : Form
    {
        private readonly Button newInvoiceButton = new();
        private readonly TextBox invoiceIdTextBox = new();
        private readonly TextBox dateTextBox = new();
        private readonly ComboBox productComboBox = new();
        private readonly NumericUpDown quantityInput = new();
        private readonly Label availableLabel = new();
        private readonly DataGridView detailsGrid = new();
        private readonly Button addButton = new();
        private readonly Button cancelButton = new();
        private readonly Button payButton = new();
        private int? invoiceId;
        private int availableQuantity;

        public SalesForm()
        {
            BuildInterface();
            Load += (_, _) => RefreshProducts();
        }

        private void BuildInterface()
        {
            Text = "Bán hàng";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(760, 560);
            Size = new Size(930, 670);
            BackColor = Color.FromArgb(245, 248, 251);
            Font = new Font("Segoe UI", 10F);

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                ColumnCount = 1,
                RowCount = 4
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 174));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));

            var heading = new Panel { Dock = DockStyle.Fill };
            var title = new Label
            {
                Text = "LẬP HÓA ĐƠN BÁN HÀNG",
                Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 58, 82),
                AutoSize = true,
                Location = new Point(0, 8)
            };
            newInvoiceButton.Text = "Tạo hóa đơn mới";
            newInvoiceButton.Size = new Size(170, 38);
            newInvoiceButton.Location = new Point(Width - 240, 2);
            newInvoiceButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newInvoiceButton.BackColor = Color.FromArgb(39, 116, 162);
            newInvoiceButton.ForeColor = Color.White;
            newInvoiceButton.FlatStyle = FlatStyle.Flat;
            newInvoiceButton.FlatAppearance.BorderSize = 0;
            newInvoiceButton.Click += CreateInvoice;
            heading.Controls.Add(title);
            heading.Controls.Add(newInvoiceButton);

            var entry = new GroupBox
            {
                Text = "Thông tin hóa đơn và sản phẩm",
                Dock = DockStyle.Fill,
                Padding = new Padding(15, 20, 15, 12),
                ForeColor = Color.FromArgb(44, 63, 79)
            };
            entry.Controls.Add(MakeLabel("Mã hóa đơn", 14, 29));
            entry.Controls.Add(MakeLabel("Ngày tạo", 355, 29));
            invoiceIdTextBox.Location = new Point(105, 25);
            invoiceIdTextBox.Size = new Size(215, 29);
            invoiceIdTextBox.ReadOnly = true;
            dateTextBox.Location = new Point(425, 25);
            dateTextBox.Size = new Size(210, 29);
            dateTextBox.ReadOnly = true;

            entry.Controls.Add(MakeLabel("Sản phẩm", 14, 73));
            productComboBox.Location = new Point(105, 69);
            productComboBox.Size = new Size(360, 30);
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.DisplayMember = "HienThi";
            productComboBox.ValueMember = "MaSP";
            productComboBox.SelectedIndexChanged += (_, _) => UpdateAvailableQuantity();
            entry.Controls.Add(MakeLabel("Số lượng", 490, 73));
            quantityInput.Location = new Point(570, 69);
            quantityInput.Size = new Size(110, 29);
            quantityInput.Minimum = 1;
            quantityInput.Maximum = int.MaxValue;
            availableLabel.Text = "Tồn: 0";
            availableLabel.Location = new Point(700, 73);
            availableLabel.AutoSize = true;
            entry.Controls.Add(invoiceIdTextBox);
            entry.Controls.Add(dateTextBox);
            entry.Controls.Add(productComboBox);
            entry.Controls.Add(quantityInput);
            entry.Controls.Add(availableLabel);

            addButton.Text = "Thêm sản phẩm";
            addButton.Size = new Size(150, 36);
            addButton.Location = new Point(570, 116);
            addButton.BackColor = Color.FromArgb(49, 135, 104);
            addButton.ForeColor = Color.White;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += AddProductToInvoice;
            cancelButton.Text = "Hủy hóa đơn";
            cancelButton.Size = new Size(130, 36);
            cancelButton.Location = new Point(730, 116);
            cancelButton.BackColor = Color.FromArgb(180, 76, 74);
            cancelButton.ForeColor = Color.White;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.Click += CancelInvoice;
            entry.Controls.Add(addButton);
            entry.Controls.Add(cancelButton);

            detailsGrid.Dock = DockStyle.Fill;
            detailsGrid.BackgroundColor = Color.White;
            detailsGrid.BorderStyle = BorderStyle.None;
            detailsGrid.ReadOnly = true;
            detailsGrid.AllowUserToAddRows = false;
            detailsGrid.AllowUserToDeleteRows = false;
            detailsGrid.AllowUserToResizeRows = false;
            detailsGrid.RowHeadersVisible = false;
            detailsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            detailsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            detailsGrid.ColumnHeadersHeight = 40;
            detailsGrid.EnableHeadersVisualStyles = false;
            detailsGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 234, 243);
            detailsGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            detailsGrid.RowTemplate.Height = 34;

            var footer = new Panel { Dock = DockStyle.Fill };
            var note = new Label
            {
                Text = "Số lượng bán được kiểm tra với tồn kho hiện tại.",
                ForeColor = Color.FromArgb(100, 113, 126),
                AutoSize = true,
                Location = new Point(3, 18)
            };
            payButton.Text = "Thanh toán";
            payButton.Size = new Size(160, 40);
            payButton.Location = new Point(Width - 260, 4);
            payButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            payButton.BackColor = Color.FromArgb(39, 116, 162);
            payButton.ForeColor = Color.White;
            payButton.FlatStyle = FlatStyle.Flat;
            payButton.FlatAppearance.BorderSize = 0;
            payButton.Click += PayInvoice;
            footer.Controls.Add(note);
            footer.Controls.Add(payButton);

            layout.Controls.Add(heading, 0, 0);
            layout.Controls.Add(entry, 0, 1);
            layout.Controls.Add(detailsGrid, 0, 2);
            layout.Controls.Add(footer, 0, 3);
            Controls.Add(layout);
            SetInvoiceControlsEnabled(false);
        }

        private void CreateInvoice(object? sender, EventArgs e)
        {
            try
            {
                Database.EnsureTodayInventory();
                invoiceId = Database.CreateInvoice();
                invoiceIdTextBox.Text = invoiceId.Value.ToString();
                dateTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                detailsGrid.DataSource = Database.GetInvoiceDetails(invoiceId.Value);
                newInvoiceButton.Enabled = false;
                SetInvoiceControlsEnabled(true);
                RefreshProducts();
                productComboBox.Focus();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void AddProductToInvoice(object? sender, EventArgs e)
        {
            if (invoiceId is null || productComboBox.SelectedValue is null) return;
            var productId = Convert.ToInt32(productComboBox.SelectedValue);
            var quantity = Decimal.ToInt32(quantityInput.Value);
            try
            {
                Database.AddInvoiceLine(invoiceId.Value, productId, quantity);
                RefreshDetails();
                RefreshProducts();
                quantityInput.Value = 1;
            }
            catch (Exception ex)
            {
                ShowError(ex);
                RefreshProducts();
            }
        }

        private void CancelInvoice(object? sender, EventArgs e)
        {
            if (invoiceId is null) return;
            var answer = MessageBox.Show(this,
                "Hủy hóa đơn này và hoàn lại số lượng đã trừ khỏi tồn kho?",
                "Xác nhận hủy hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            try
            {
                Database.CancelInvoice(invoiceId.Value);
                invoiceId = null;
                invoiceIdTextBox.Clear();
                dateTextBox.Clear();
                detailsGrid.DataSource = null;
                newInvoiceButton.Enabled = true;
                SetInvoiceControlsEnabled(false);
                RefreshProducts();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void PayInvoice(object? sender, EventArgs e)
        {
            if (invoiceId is null) return;
            try
            {
                Database.PayInvoice(invoiceId.Value);
                MessageBox.Show(this, $"Hóa đơn {invoiceId.Value} đã được thanh toán.", "Thanh toán",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                invoiceId = null;
                invoiceIdTextBox.Clear();
                dateTextBox.Clear();
                detailsGrid.DataSource = null;
                newInvoiceButton.Enabled = true;
                SetInvoiceControlsEnabled(false);
                RefreshProducts();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void RefreshProducts()
        {
            try
            {
                var selectedId = productComboBox.SelectedValue is null ? (int?)null : Convert.ToInt32(productComboBox.SelectedValue);
                productComboBox.DataSource = Database.GetProductsWithStock();
                productComboBox.DisplayMember = "HienThi";
                productComboBox.ValueMember = "MaSP";
                if (selectedId.HasValue)
                {
                    for (var i = 0; i < productComboBox.Items.Count; i++)
                    {
                        if (productComboBox.Items[i] is DataRowView row && row.Row.Field<int>("MaSP") == selectedId.Value)
                        {
                            productComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }
                UpdateAvailableQuantity();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void RefreshDetails()
        {
            if (invoiceId.HasValue)
                detailsGrid.DataSource = Database.GetInvoiceDetails(invoiceId.Value);
        }

        private void UpdateAvailableQuantity()
        {
            if (productComboBox.SelectedItem is DataRowView row)
                availableQuantity = row.Row.Field<int>("TonHienTai");
            else
                availableQuantity = 0;

            availableLabel.Text = $"Tồn: {availableQuantity:N0}";
            addButton.Enabled = invoiceId.HasValue && availableQuantity > 0;
        }

        private void SetInvoiceControlsEnabled(bool enabled)
        {
            productComboBox.Enabled = enabled;
            quantityInput.Enabled = enabled;
            cancelButton.Enabled = enabled;
            payButton.Enabled = enabled;
            addButton.Enabled = enabled && availableQuantity > 0;
        }

        private static Label MakeLabel(string text, int x, int y) => new()
        {
            Text = text,
            AutoSize = true,
            Location = new Point(x, y + 4)
        };

        private void ShowError(Exception ex) =>
            MessageBox.Show(this, ex.Message, "Thao tác thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
