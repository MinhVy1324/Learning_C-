/*
* LỚP QUẢN LÝ THÔNG TIN SINH VIÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Xây dựng lớp SinhVien để lưu trữ thông tin (mã sinh viên, họ tên, địa chỉ, sinh viên năm thứ mấy).
*   Thực hiện nhập xuất 1 sinh viên.
*
* Ý tưởng:
*   - Tạo thuộc tính (Properties) auto-implemented cho MaSV, HoTen, DiaChi.
*   - Thuộc tính NamThu có ràng buộc dữ liệu (nếu nhập < 1 thì tự động đưa về 1).
*   - Định nghĩa Constructor không tham số và Constructor đầy đủ tham số.
*   - Phương thức GetThongTin(): Định dạng chuỗi thông tin sinh viên để xuất ra màn hình và phục vụ Unit Test.
*/
using System;
using MyLib;
namespace Baitap13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhập thông tin sinh viên:");
            Console.Write("Mã SV: ");
            string maSV = Console.ReadLine();
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();
            Console.Write("Địa chỉ: ");
            string diaChi = Console.ReadLine();
            Console.Write("Năm thứ (1-5): ");
            int namThu;
            while (!int.TryParse(Console.ReadLine(), out namThu) || namThu < 1 || namThu > 5)
            {
                Console.WriteLine("Vui lòng nhập năm thứ hợp lệ (1-5):");
            }
            SinhVien sv = new SinhVien(maSV, hoTen, diaChi, namThu);
            Console.WriteLine("\nThông tin sinh viên:");
            Console.WriteLine(sv.GetThongTin());
        }
    }
}