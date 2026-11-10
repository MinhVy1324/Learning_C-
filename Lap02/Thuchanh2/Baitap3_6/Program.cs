/*
* CHƯƠNG TRÌNH THỰC THI QUẢN LÝ TÍNH ĐIỂM CUỘC THI TIN HỌC (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using System.Globalization;
using MyLib;

namespace Baitap3_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 3.6: QUẢN LÝ VÀ TÍNH ĐIỂM CUỘC THI TIN HỌC ===");

            CuocThi cuocThi = new CuocThi();

            int n;
            while (true)
            {
                Console.Write("Nhập số lượng thí sinh tham gia cuộc thi (n > 0): ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0) break;
                Console.WriteLine("Lỗi: Số lượng thí sinh phải là số nguyên dương!");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin thí sinh thứ {i + 1} ---");
                Console.Write("Chọn đối tượng thí sinh (1 - Chuyên, 2 - Siêu cúp): ");
                string loai = Console.ReadLine()!;

                Console.Write("Nhập Số báo danh (SBD): ");
                string sbd = Console.ReadLine()!;

                Console.Write("Nhập Họ và tên: ");
                string hoTen = Console.ReadLine()!;

                double b1 = NhapDiem("Nhập điểm Bài 1 (0-10): ");
                double b2 = NhapDiem("Nhập điểm Bài 2 (0-10): ");
                double b3 = NhapDiem("Nhập điểm Bài 3 (0-10): ");

                if (loai == "1")
                {
                    double ta = NhapDiem("Nhập điểm Tiếng Anh (0-10): ");
                    cuocThi.ThemThiSinh(new ThiSinhChuyen(sbd, hoTen, b1, b2, b3, ta));
                }
                else
                {
                    double csdl = NhapDiem("Nhập điểm Cơ sở dữ liệu (0-10): ");
                    cuocThi.ThemThiSinh(new ThiSinhSieuCup(sbd, hoTen, b1, b2, b3, csdl));
                }
            }

            // Hiển thị kết quả cuộc thi
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------");
            Console.WriteLine($"BẢNG KẾT QUẢ {cuocThi.TenCuocThi.ToUpper()}:");
            foreach (var ts in cuocThi.DanhSachThiSinh)
            {
                Console.WriteLine(ts.GetThongTin());
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
        }

        private static double NhapDiem(string prompt)
        {
            double diem;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out diem) && diem >= 0 && diem <= 10)
                {
                    return diem;
                }
                Console.WriteLine("Lỗi: Điểm phải là số thực từ 0 đến 10!");
            }
        }
    }
}