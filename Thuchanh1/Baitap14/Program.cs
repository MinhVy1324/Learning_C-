/*
* LỚP QUẢN LÝ VÀ TÍNH LƯƠNG NHÂN VIÊN
* Tác giả : Võ Minh Vỹ
*
* Phát biểu đề bài:
*   Nhập thông tin nhân viên (họ tên, mức lương, số ngày vắng).
*   Tính lương thực nhận với quy tắc mỗi ngày vắng trừ 100.000 VNĐ.
*
* Ý tưởng:
*   - Dùng kiểu decimal cho tiền lương để đảm bảo độ chính xác tính toán tài chính.
*   - Đặt hằng số TIEN_TRU_NGAY_VANG = 100000m.
*   - Công thức: LuongThucNhan = MucLuong - (SoNgayVang * 100000).
*   - Ràng buộc: Mức lương và số ngày vắng nếu âm sẽ tự chuyển về 0.
*/
using System;
using MyLib;
namespace Baitap14
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhập thông tin nhân viên:");
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();
            Console.Write("Mức lương: ");
            decimal mucLuong;
            while (!decimal.TryParse(Console.ReadLine(), out mucLuong) || mucLuong < 0)
            {
                Console.WriteLine("Vui lòng nhập mức lương hợp lệ (>= 0):");
            }
            Console.Write("Số ngày vắng: ");
            int soNgayVang;
            while (!int.TryParse(Console.ReadLine(), out soNgayVang) || soNgayVang < 0)
            {
                Console.WriteLine("Vui lòng nhập số ngày vắng hợp lệ (>= 0):");
            }
            NhanVien nv = new NhanVien(hoTen, mucLuong, soNgayVang);
            Console.WriteLine($"\nNhân viên: {nv.HoTen}");
            Console.WriteLine($"Mức lương: {nv.MucLuong:C}");
            Console.WriteLine($"Số ngày vắng: {nv.SoNgayVang}");
            Console.WriteLine($"Lương thực nhận: {nv.LuongThucNhan:C}");
        }
    }
}