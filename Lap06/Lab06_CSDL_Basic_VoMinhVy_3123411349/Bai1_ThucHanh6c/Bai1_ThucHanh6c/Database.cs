using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai1_ThucHanh6c
{
    internal static class Database
    {
        private const string MasterConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=true;TrustServerCertificate=true;Connect Timeout=30";
        private const string ConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=QLCuaHang;Integrated Security=true;TrustServerCertificate=true;Connect Timeout=30";

        public static void Initialize()
        {
            using (var master = new SqlConnection(MasterConnectionString))
            {
                master.Open();
                using var command = master.CreateCommand();
                command.CommandText = "IF DB_ID(N'QLCuaHang') IS NULL CREATE DATABASE [QLCuaHang];";
                command.ExecuteNonQuery();
            }

            using (var connection = OpenConnection())
            {
                Execute(connection, @"
IF OBJECT_ID(N'dbo.SANPHAM', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SANPHAM
    (
        MaSP INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_SANPHAM PRIMARY KEY,
        TenSP NVARCHAR(100) NOT NULL CONSTRAINT UQ_SANPHAM_TenSP UNIQUE
    );
END;

IF OBJECT_ID(N'dbo.TONKHO', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.TONKHO
    (
        MaSP INT NOT NULL,
        NgayTon DATE NOT NULL,
        SLDau INT NOT NULL CONSTRAINT DF_TONKHO_SLDau DEFAULT (0),
        SLNhap INT NOT NULL CONSTRAINT DF_TONKHO_SLNhap DEFAULT (0),
        SLBan INT NOT NULL CONSTRAINT DF_TONKHO_SLBan DEFAULT (0),
        CONSTRAINT PK_TONKHO PRIMARY KEY (MaSP, NgayTon),
        CONSTRAINT FK_TONKHO_SANPHAM FOREIGN KEY (MaSP) REFERENCES dbo.SANPHAM(MaSP),
        CONSTRAINT CK_TONKHO_SoLuong CHECK (SLDau >= 0 AND SLNhap >= 0 AND SLBan >= 0 AND SLBan <= SLDau + SLNhap)
    );
END;

IF OBJECT_ID(N'dbo.HOADON', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HOADON
    (
        MaHD INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HOADON PRIMARY KEY,
        NgayTao DATETIME NOT NULL CONSTRAINT DF_HOADON_NgayTao DEFAULT (GETDATE()),
        TinhTrangThanhToan BIT NOT NULL CONSTRAINT DF_HOADON_ThanhToan DEFAULT (0)
    );
END;

IF OBJECT_ID(N'dbo.CHITIET_HOADON', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CHITIET_HOADON
    (
        MaHD INT NOT NULL,
        MaSP INT NOT NULL,
        SoLuong INT NOT NULL,
        CONSTRAINT PK_CHITIET_HOADON PRIMARY KEY (MaHD, MaSP),
        CONSTRAINT FK_CHITIET_HOADON_HOADON FOREIGN KEY (MaHD) REFERENCES dbo.HOADON(MaHD) ON DELETE CASCADE,
        CONSTRAINT FK_CHITIET_HOADON_SANPHAM FOREIGN KEY (MaSP) REFERENCES dbo.SANPHAM(MaSP),
        CONSTRAINT CK_CHITIET_HOADON_SoLuong CHECK (SoLuong > 0)
    );
END;");

                Execute(connection, @"
INSERT INTO dbo.SANPHAM(TenSP)
SELECT seed.TenSP
FROM (VALUES (N'Trà xanh'), (N'Mực dầu'), (N'Cafe')) AS seed(TenSP)
WHERE NOT EXISTS (SELECT 1 FROM dbo.SANPHAM AS sp WHERE sp.TenSP = seed.TenSP);

INSERT INTO dbo.TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan)
SELECT sp.MaSP, CONVERT(date, '20161029', 112), 50, 0, 0
FROM dbo.SANPHAM AS sp
WHERE sp.TenSP IN (N'Trà xanh', N'Mực dầu', N'Cafe')
  AND NOT EXISTS
  (
      SELECT 1 FROM dbo.TONKHO AS tk
      WHERE tk.MaSP = sp.MaSP AND tk.NgayTon = CONVERT(date, '20161029', 112)
  );");
            }

            EnsureTodayInventory();
        }

        public static int EnsureTodayInventory()
        {
            using var connection = OpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
INSERT INTO dbo.TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan)
SELECT sp.MaSP,
       @NgayTon,
       COALESCE(previousStock.SLTon, 0),
       0,
       0
FROM dbo.SANPHAM AS sp
OUTER APPLY
(
    SELECT TOP (1) tk.SLDau + tk.SLNhap - tk.SLBan AS SLTon
    FROM dbo.TONKHO AS tk
    WHERE tk.MaSP = sp.MaSP AND tk.NgayTon < @NgayTon
    ORDER BY tk.NgayTon DESC
) AS previousStock
WHERE NOT EXISTS
(
    SELECT 1 FROM dbo.TONKHO AS currentStock
    WHERE currentStock.MaSP = sp.MaSP AND currentStock.NgayTon = @NgayTon
);
SELECT @@ROWCOUNT;";
            command.Parameters.Add("@NgayTon", SqlDbType.Date).Value = DateTime.Today;
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static DataTable GetTodayInventory()
        {
            using var connection = OpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT sp.MaSP, sp.TenSP, tk.NgayTon, tk.SLDau, tk.SLNhap, tk.SLBan,
       tk.SLDau + tk.SLNhap - tk.SLBan AS SLTon
FROM dbo.SANPHAM AS sp
LEFT JOIN dbo.TONKHO AS tk ON tk.MaSP = sp.MaSP AND tk.NgayTon = @NgayTon
ORDER BY sp.MaSP;";
            command.Parameters.Add("@NgayTon", SqlDbType.Date).Value = DateTime.Today;
            var result = new DataTable();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(result);
            return result;
        }

        public static void AddProduct(string name)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                using (var addProduct = new SqlCommand(
                    "INSERT INTO dbo.SANPHAM(TenSP) VALUES (@TenSP); SELECT CAST(SCOPE_IDENTITY() AS int);",
                    connection, transaction))
                {
                    addProduct.Parameters.Add("@TenSP", SqlDbType.NVarChar, 100).Value = name;
                    var productId = Convert.ToInt32(addProduct.ExecuteScalar());
                    using var addStock = new SqlCommand(@"
INSERT INTO dbo.TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan)
VALUES (@MaSP, @NgayTon, 0, 0, 0);", connection, transaction);
                    addStock.Parameters.Add("@MaSP", SqlDbType.Int).Value = productId;
                    addStock.Parameters.Add("@NgayTon", SqlDbType.Date).Value = DateTime.Today;
                    addStock.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public static DataTable GetProductsWithStock()
        {
            using var connection = OpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT sp.MaSP, sp.TenSP, CONCAT(sp.MaSP, N' - ', sp.TenSP) AS HienThi,
       COALESCE(tk.SLDau + tk.SLNhap - tk.SLBan, 0) AS TonHienTai
FROM dbo.SANPHAM AS sp
LEFT JOIN dbo.TONKHO AS tk ON tk.MaSP = sp.MaSP AND tk.NgayTon = @NgayTon
ORDER BY sp.TenSP;";
            command.Parameters.Add("@NgayTon", SqlDbType.Date).Value = DateTime.Today;
            var result = new DataTable();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(result);
            return result;
        }

        public static int CreateInvoice()
        {
            using var connection = OpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
INSERT INTO dbo.HOADON(NgayTao, TinhTrangThanhToan)
VALUES (GETDATE(), 0);
SELECT CAST(SCOPE_IDENTITY() AS int);";
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static DataTable GetInvoiceDetails(int invoiceId)
        {
            using var connection = OpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT sp.MaSP, sp.TenSP, ct.SoLuong
FROM dbo.CHITIET_HOADON AS ct
INNER JOIN dbo.SANPHAM AS sp ON sp.MaSP = ct.MaSP
WHERE ct.MaHD = @MaHD
ORDER BY sp.TenSP;";
            command.Parameters.Add("@MaHD", SqlDbType.Int).Value = invoiceId;
            var result = new DataTable();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(result);
            return result;
        }

        public static void AddInvoiceLine(int invoiceId, int productId, int quantity)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                using (var checkInvoice = new SqlCommand(
                    "SELECT TinhTrangThanhToan FROM dbo.HOADON WITH (UPDLOCK, HOLDLOCK) WHERE MaHD = @MaHD;",
                    connection, transaction))
                {
                    checkInvoice.Parameters.Add("@MaHD", SqlDbType.Int).Value = invoiceId;
                    var status = checkInvoice.ExecuteScalar();
                    if (status is null || status == DBNull.Value)
                        throw new InvalidOperationException("Không tìm thấy hóa đơn.");
                    if (Convert.ToBoolean(status))
                        throw new InvalidOperationException("Hóa đơn đã thanh toán, không thể thêm sản phẩm.");
                }

                using (var updateStock = new SqlCommand(@"
UPDATE dbo.TONKHO
SET SLBan = SLBan + @SoLuong
WHERE MaSP = @MaSP AND NgayTon = @NgayTon
  AND SLDau + SLNhap - SLBan >= @SoLuong;", connection, transaction))
                {
                    updateStock.Parameters.Add("@SoLuong", SqlDbType.Int).Value = quantity;
                    updateStock.Parameters.Add("@MaSP", SqlDbType.Int).Value = productId;
                    updateStock.Parameters.Add("@NgayTon", SqlDbType.Date).Value = DateTime.Today;
                    if (updateStock.ExecuteNonQuery() != 1)
                        throw new InvalidOperationException("Số lượng phải lớn hơn 0 và không được vượt quá số lượng tồn kho.");
                }

                using (var addLine = new SqlCommand(@"
IF EXISTS (SELECT 1 FROM dbo.CHITIET_HOADON WHERE MaHD = @MaHD AND MaSP = @MaSP)
    UPDATE dbo.CHITIET_HOADON SET SoLuong = SoLuong + @SoLuong WHERE MaHD = @MaHD AND MaSP = @MaSP;
ELSE
    INSERT INTO dbo.CHITIET_HOADON(MaHD, MaSP, SoLuong) VALUES (@MaHD, @MaSP, @SoLuong);",
                    connection, transaction))
                {
                    addLine.Parameters.Add("@MaHD", SqlDbType.Int).Value = invoiceId;
                    addLine.Parameters.Add("@MaSP", SqlDbType.Int).Value = productId;
                    addLine.Parameters.Add("@SoLuong", SqlDbType.Int).Value = quantity;
                    addLine.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public static void PayInvoice(int invoiceId)
        {
            using var connection = OpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
IF NOT EXISTS (SELECT 1 FROM dbo.CHITIET_HOADON WHERE MaHD = @MaHD)
    THROW 50001, N'Hóa đơn chưa có sản phẩm.', 1;
UPDATE dbo.HOADON SET TinhTrangThanhToan = 1
WHERE MaHD = @MaHD AND TinhTrangThanhToan = 0;
IF @@ROWCOUNT = 0
    THROW 50002, N'Hóa đơn không tồn tại hoặc đã được thanh toán.', 1;";
            command.Parameters.Add("@MaHD", SqlDbType.Int).Value = invoiceId;
            command.ExecuteNonQuery();
        }

        public static void CancelInvoice(int invoiceId)
        {
            using var connection = OpenConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                using (var checkInvoice = new SqlCommand(
                    "SELECT TinhTrangThanhToan, CONVERT(date, NgayTao) FROM dbo.HOADON WITH (UPDLOCK, HOLDLOCK) WHERE MaHD = @MaHD;",
                    connection, transaction))
                {
                    checkInvoice.Parameters.Add("@MaHD", SqlDbType.Int).Value = invoiceId;
                    using var reader = checkInvoice.ExecuteReader();
                    if (!reader.Read()) throw new InvalidOperationException("Không tìm thấy hóa đơn.");
                    if (reader.GetBoolean(0)) throw new InvalidOperationException("Không thể hủy hóa đơn đã thanh toán.");
                }

                using (var restoreStock = new SqlCommand(@"
UPDATE tk
SET tk.SLBan = tk.SLBan - ct.SoLuong
FROM dbo.TONKHO AS tk
INNER JOIN dbo.CHITIET_HOADON AS ct ON ct.MaSP = tk.MaSP
INNER JOIN dbo.HOADON AS hd ON hd.MaHD = ct.MaHD AND tk.NgayTon = CONVERT(date, hd.NgayTao)
WHERE ct.MaHD = @MaHD;", connection, transaction))
                {
                    restoreStock.Parameters.Add("@MaHD", SqlDbType.Int).Value = invoiceId;
                    restoreStock.ExecuteNonQuery();
                }

                using (var deleteInvoice = new SqlCommand(
                    "DELETE FROM dbo.HOADON WHERE MaHD = @MaHD;", connection, transaction))
                {
                    deleteInvoice.Parameters.Add("@MaHD", SqlDbType.Int).Value = invoiceId;
                    deleteInvoice.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        private static void Execute(SqlConnection connection, string sql)
        {
            using var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
    }
}
