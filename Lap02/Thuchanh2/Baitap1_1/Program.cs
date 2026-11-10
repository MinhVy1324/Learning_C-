/*
* LỚP QUẢN LÝ VÀ TÍNH TUỔI SINH VIÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Viết chương trình nhập thông tin sinh viên (họ tên, năm sinh). Tính và xuất tuổi sinh viên.
*   Yêu cầu đầy đủ thành phần: Field, Constructor, Property, Method.
*
* Ý tưởng:
*   - Fields: _hoTen, _namSinh (private).
*   - Constructors: Constructor mặc định và Constructor 2 tham số.
*   - Properties: HoTen, NamSinh (có kiểm tra ràng buộc năm sinh không hợp lệ).
*   - Methods: TinhTuoi(int namHienTai), GetThongTin().
*/
using System;
using MyLib;
namespace Baitap1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("nhap ho ten sinh vien: ");
            string hoTen = Console.ReadLine();
            int namSinh;
            int currentYear = DateTime.Now.Year;
            while (true) {
                Console.Write($"Nhập năm sinh (1900 - {currentYear}): ");
                string inputNam = Console.ReadLine()!;
                if (int.TryParse(inputNam, out namSinh) && namSinh >= 1900 && namSinh <= currentYear)
                {
                    break;
                }
                Console.WriteLine($"Lỗi: Năm sinh phải là số nguyên hợp lệ từ 1900 đến {currentYear}!");
            }
            SinhVienTuoi sinhVien = new SinhVienTuoi(hoTen, namSinh);
            Console.WriteLine(sinhVien.GetThongTin());
        }
    }
}