using System;
using System.Collections.Generic;

namespace BaiThucHanhLINQ
{
    // Lớp Hệ mô tả thông tin các hệ đào tạo
    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";
    }

    // Lớp Bai6_1 chứa phương thức khởi tạo dữ liệu và hàm chạy kiểm thử
    public class Bai6_1
    {
        // Phương thức trả về danh sách List<He>
        public static List<He> DS_He()
        {
            return new List<He>
            {
                new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
                new He { MaHe = "CD",  TenHe = "Chuyên đề" },
                new He { MaHe = "QT",  TenHe = "Chứng chỉ quốc tế" }
            };
        }

        public static void Run()
        {
            Console.WriteLine("=== BÀI 6.1: XÂY DỰNG LỚP HE & NGUỒN DỮ LIỆU DS_HE ===");
            var dsHe = DS_He();

            Console.WriteLine($"{"Mã hệ",-10} | {"Tên hệ",-30}");
            Console.WriteLine(new string('-', 45));

            foreach (var h in dsHe)
            {
                Console.WriteLine($"{h.MaHe,-10} | {h.TenHe,-30}");
            }
        }
    }
}