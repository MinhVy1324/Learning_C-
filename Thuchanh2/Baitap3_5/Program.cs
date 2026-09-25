/*
* CHƯƠNG TRÌNH THỰC THI TÍNH LƯƠNG NHÂN VIÊN CÔNG TY X (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using System.Collections.Generic;
using MyLib;

namespace Baitap3_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 3.5: TÍNH LƯƠNG NHÂN VIÊN CÔNG TY X (KẾ THỪA & ĐA HÌNH) ===");

            // Danh sách đa hình lưu trữ cả Nhân viên Kinh doanh và Sản xuất
            List<NhanVienCompany> danhSachNV = new List<NhanVienCompany>
            {
                new NhanVienKinhDoanh("KD01", "Nguyễn Văn A", 8000000m, 5), // 8tr + 5*500k = 10.500.000 VNĐ
                new NhanVienSanXuat("SX01", "Trần Thị B", 2500),           // 2500 * 1000 = 2.500.000 VNĐ
                new NhanVienSanXuat("SX02", "Lê Văn C", 3500),             // 3500 * 1000 * 1.05 = 3.675.000 VNĐ
                new NhanVienKinhDoanh("KD02", "Phạm Minh D", 10000000m, 0)  // 10.000.000 VNĐ
            };

            Console.WriteLine("\n--------------------------------------------------------------------------------------------------");
            Console.WriteLine("DANH SÁCH BẢNG LƯƠNG CÔNG TY X:");
            decimal tongChiTra = 0m;

            foreach (var nv in danhSachNV)
            {
                Console.WriteLine(nv.GetThongTin());
                tongChiTra += nv.TinhLuong();
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine($"=> TỔNG CHI PHÍ LƯƠNG CÔNG TY PHẢI CHI TRẢ: {tongChiTra:N0} VNĐ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
        }
    }
}