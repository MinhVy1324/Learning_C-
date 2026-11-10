using System.Data;
using System.Drawing;

namespace Bai1_ThucHanh6c
{
    public partial class Form1 : Form
    {
        private readonly DataGridView inventoryGrid = new();
        private readonly Label dateLabel = new();
        private readonly Label openingLabel = new();
        private readonly Label receivedLabel = new();
        private readonly Label soldLabel = new();
        private readonly Label balanceLabel = new();

        public Form1()
        {
            InitializeComponent();
            BuildInterface();
            Shown += (_, _) => InitializeData();
        }

        private void BuildInterface()
        {
            Text = "Quản lý cửa hàng";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(900, 600);
            Size = new Size(1120, 720);
            BackColor = Color.FromArgb(244, 247, 251);
            Font = new Font("Segoe UI", 10F);

            var menu = new MenuStrip();
            var inventoryMenu = new ToolStripMenuItem("Tồn kho");
            inventoryMenu.DropDownItems.Add("Tạo tồn kho hôm nay", null, (_, _) => CreateTodayInventory());
            inventoryMenu.DropDownItems.Add("Làm mới", null, (_, _) => RefreshInventory());
            var productMenu = new ToolStripMenuItem("Sản phẩm", null, (_, _) => OpenProductForm());
            var salesMenu = new ToolStripMenuItem("Bán hàng", null, (_, _) => OpenSalesForm());
            menu.Items.AddRange([inventoryMenu, productMenu, salesMenu]);
            MainMenuStrip = menu;

            var content = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(22),
                ColumnCount = 1,
                RowCount = 4,
                BackColor = BackColor
            };
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 82));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 66));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 104));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            var heading = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(24, 55, 82) };
            var title = new Label
            {
                Text = "QUẢN LÝ CỬA HÀNG",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(18, 11)
            };
            dateLabel.Text = $"Tồn kho ngày {DateTime.Today:dd/MM/yyyy}";
            dateLabel.ForeColor = Color.FromArgb(205, 222, 237);
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(21, 49);
            heading.Controls.Add(title);
            heading.Controls.Add(dateLabel);

            var actions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(0, 12, 0, 0)
            };
            actions.Controls.Add(CreateButton("Tạo tồn kho hôm nay", Color.FromArgb(39, 116, 162), (_, _) => CreateTodayInventory()));
            actions.Controls.Add(CreateButton("Thêm sản phẩm", Color.FromArgb(49, 135, 104), (_, _) => OpenProductForm()));
            actions.Controls.Add(CreateButton("Bán hàng", Color.FromArgb(202, 126, 46), (_, _) => OpenSalesForm()));

            var summaries = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                Padding = new Padding(0, 5, 0, 10)
            };
            for (var i = 0; i < 4; i++) summaries.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            summaries.Controls.Add(CreateSummaryCard("Tồn đầu ngày", openingLabel, Color.FromArgb(50, 110, 158)), 0, 0);
            summaries.Controls.Add(CreateSummaryCard("Tổng nhập", receivedLabel, Color.FromArgb(49, 135, 104)), 1, 0);
            summaries.Controls.Add(CreateSummaryCard("Tổng bán", soldLabel, Color.FromArgb(202, 126, 46)), 2, 0);
            summaries.Controls.Add(CreateSummaryCard("Tồn hiện tại", balanceLabel, Color.FromArgb(99, 83, 153)), 3, 0);

            inventoryGrid.Dock = DockStyle.Fill;
            inventoryGrid.BackgroundColor = Color.White;
            inventoryGrid.BorderStyle = BorderStyle.None;
            inventoryGrid.ReadOnly = true;
            inventoryGrid.AllowUserToAddRows = false;
            inventoryGrid.AllowUserToDeleteRows = false;
            inventoryGrid.AllowUserToResizeRows = false;
            inventoryGrid.RowHeadersVisible = false;
            inventoryGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            inventoryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inventoryGrid.ColumnHeadersHeight = 42;
            inventoryGrid.EnableHeadersVisualStyles = false;
            inventoryGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 234, 243);
            inventoryGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(32, 53, 71);
            inventoryGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            inventoryGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(222, 238, 249);
            inventoryGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(25, 43, 58);
            inventoryGrid.RowTemplate.Height = 36;

            content.Controls.Add(heading, 0, 0);
            content.Controls.Add(actions, 0, 1);
            content.Controls.Add(summaries, 0, 2);
            content.Controls.Add(inventoryGrid, 0, 3);
            Controls.Add(content);
            Controls.Add(menu);
        }

        private void InitializeData()
        {
            try
            {
                Database.Initialize();
                RefreshInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "Không thể kết nối SQL Server LocalDB hoặc khởi tạo cơ sở dữ liệu QLCuaHang.\n\n" + ex.Message +
                    "\n\nHãy kiểm tra SQL Server LocalDB đã được cài đặt và instance MSSQLLocalDB có thể khởi động.",
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CreateTodayInventory()
        {
            try
            {
                var count = Database.EnsureTodayInventory();
                RefreshInventory();
                MessageBox.Show(this,
                    count > 0 ? $"Đã tạo tồn kho hôm nay cho {count} sản phẩm." : "Tồn kho hôm nay đã được tạo trước đó.",
                    "Tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private void RefreshInventory()
        {
            try
            {
                Database.EnsureTodayInventory();
                var table = Database.GetTodayInventory();
                inventoryGrid.DataSource = table;
                dateLabel.Text = $"Tồn kho ngày {DateTime.Today:dd/MM/yyyy}";
                var opening = Sum(table, "SLDau");
                var received = Sum(table, "SLNhap");
                var sold = Sum(table, "SLBan");
                openingLabel.Text = opening.ToString("N0");
                receivedLabel.Text = received.ToString("N0");
                soldLabel.Text = sold.ToString("N0");
                balanceLabel.Text = (opening + received - sold).ToString("N0");
                if (inventoryGrid.Columns["NgayTon"] is { } dateColumn)
                    dateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private static int Sum(DataTable table, string column) =>
            table.Rows.Cast<DataRow>().Sum(row => row.Field<int>(column));

        private void OpenProductForm()
        {
            using var form = new ProductForm();
            form.ShowDialog(this);
            RefreshInventory();
        }

        private void OpenSalesForm()
        {
            using var form = new SalesForm();
            form.ShowDialog(this);
            RefreshInventory();
        }

        private static Button CreateButton(string text, Color color, EventHandler click)
        {
            var button = new Button
            {
                Text = text,
                Width = 190,
                Height = 42,
                Margin = new Padding(0, 0, 12, 0),
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += click;
            return button;
        }

        private static Control CreateSummaryCard(string caption, Label value, Color accent)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 10, 0),
                BackColor = Color.White
            };
            var stripe = new Panel { Dock = DockStyle.Left, Width = 5, BackColor = accent };
            var title = new Label
            {
                Text = caption,
                AutoSize = true,
                ForeColor = Color.FromArgb(100, 113, 126),
                Location = new Point(15, 12)
            };
            value.AutoSize = true;
            value.Text = "0";
            value.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            value.ForeColor = Color.FromArgb(36, 53, 69);
            value.Location = new Point(13, 36);
            card.Controls.Add(stripe);
            card.Controls.Add(title);
            card.Controls.Add(value);
            return card;
        }

        private void ShowDatabaseError(Exception ex) =>
            MessageBox.Show(this, ex.Message, "Thao tác thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
