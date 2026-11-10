# Bài tập quản lý cửa hàng

Ứng dụng WinForms C# quản lý sản phẩm, tồn kho theo ngày và hóa đơn bán hàng. Ứng dụng tự tạo cơ sở dữ liệu `QLCuaHang` trên SQL Server LocalDB khi chạy lần đầu.

## Chạy chương trình

1. Mở `../Bai1_ThucHanh6c.slnx` bằng Visual Studio hoặc mở `Bai1_ThucHanh6c.csproj`.
2. Khôi phục gói NuGet `Microsoft.Data.SqlClient` nếu Visual Studio yêu cầu.
3. Chạy ứng dụng trên Windows có SQL Server LocalDB, instance `MSSQLLocalDB`.

Chuỗi kết nối mặc định là `(localdb)\MSSQLLocalDB`. Nếu chạy file `Database/QLCuaHang.sql` trong SQL Server Management Studio, hãy kết nối SSMS tới đúng instance `(localdb)\MSSQLLocalDB` để dùng cùng database với ứng dụng. Dữ liệu của LocalDB lưu trong profile Windows hiện tại.

## Chức năng

- Tạo tồn kho hôm nay cho tất cả sản phẩm. Tồn đầu ngày lấy từ số tồn cuối của ngày có dữ liệu gần nhất; số nhập và số bán bắt đầu bằng 0.
- Thêm sản phẩm mới và tạo dòng tồn kho hôm nay cho sản phẩm với các số lượng bằng 0.
- Lập hóa đơn mới với mã tự tăng, ngày hiện tại và trạng thái chưa thanh toán.
- Thêm sản phẩm vào hóa đơn, kiểm tra tồn kho và cập nhật số bán trong cùng transaction.
- Thanh toán hóa đơn hoặc hủy hóa đơn chưa thanh toán (hủy sẽ hoàn số lượng về tồn kho).

Dữ liệu mẫu ban đầu gồm Trà xanh, Mực dầu và Cafe; mỗi sản phẩm có tồn đầu 50 ở ngày 29/10/2016.
