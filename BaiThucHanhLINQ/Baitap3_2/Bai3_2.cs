using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Bai3_2
    {
        public static void Run()
        {
            string[] monAn = {
                "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang"
            };

            Console.WriteLine("=== BÀI 3.2: THỐNG KÊ MẢNG CHUỖI ===");
            Console.WriteLine("Mảng món ăn ban đầu: " + string.Join(", ", monAn));
            Console.WriteLine("--------------------------------------------------");

            // a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất
            int minLength = monAn.Min(s => s.Length);
            int maxLength = monAn.Max(s => s.Length);

            var monNganNhat = monAn.Where(s => s.Length == minLength);
            var monDaiNhat = monAn.Where(s => s.Length == maxLength);

            Console.WriteLine("\na. Phần tử có chiều dài ngắn nhất và dài nhất:");
            Console.WriteLine($"   - Ngắn nhất ({minLength} ký tự) : " + string.Join(", ", monNganNhat));
            Console.WriteLine($"   - Dài nhất ({maxLength} ký tự)  : " + string.Join(", ", monDaiNhat));

            // b. Phân nhóm theo từ đầu tiên của tên món và liệt kê các phần tử trong từng nhóm
            Console.WriteLine("\nb. Phân nhóm theo từ đầu tiên của tên món:");
            var nhomTuDau = monAn.GroupBy(s => s.Split(' ')[0]);

            foreach (var nhom in nhomTuDau)
            {
                Console.WriteLine($"   * Từ \"{nhom.Key}\": {string.Join(", ", nhom)}");
            }

            // c. Đếm số phần tử có từ đầu tiên là "Bánh"
            int soMonBanh = monAn.Count(s => s.StartsWith("Bánh"));
            Console.WriteLine($"\nc. Số phần tử có từ đầu tiên là \"Bánh\": {soMonBanh}");
        }
    }
}