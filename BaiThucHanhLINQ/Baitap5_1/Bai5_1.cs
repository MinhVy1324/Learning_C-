using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Bai5_1
    {
        public static void Run()
        {
            var dsMon = DuLieu.DS_Mon();

            Console.WriteLine("=== BÀI 5.1: TRUY VẤN CƠ BẢN TRÊN LIST<MONHOC> ===");
            Console.WriteLine("------------------------------------------------------------------");

            // a. Liệt kê tên các môn học bắt đầu bằng "Lập trình"
            Console.WriteLine("\na. Tên các môn học bắt đầu bằng 'Lập trình':");
            var cauA_Query = from m in dsMon
                             where m.TenMon.StartsWith("Lập trình")
                             select m.TenMon;

            var cauA_Method = dsMon.Where(m => m.TenMon.StartsWith("Lập trình"))
                                   .Select(m => m.TenMon);

            foreach (var ten in cauA_Method)
            {
                Console.WriteLine($"   + {ten}");
            }

            // b. Liệt kê các môn thuộc hệ "CD", sắp xếp số tiết giảm dần rồi mã môn tăng dần
            Console.WriteLine("\nb. Các môn thuộc hệ 'CD' (Số tiết giảm dần, Mã môn tăng dần):");
            var cauB_Query = from m in dsMon
                             where m.He == "CD"
                             orderby m.SoTiet descending, m.MaMon ascending
                             select m;

            var cauB_Method = dsMon.Where(m => m.He == "CD")
                                   .OrderByDescending(m => m.SoTiet)
                                   .ThenBy(m => m.MaMon);

            foreach (var m in cauB_Method)
            {
                Console.WriteLine($"   + [{m.MaMon,-6}] {m.TenMon,-45} | Số tiết: {m.SoTiet}");
            }

            // c. Liệt kê các môn có tên chứa từ "web", chỉ lấy Tên môn và Hệ
            Console.WriteLine("\nc. Các môn có tên chứa từ 'web' (Tên môn & Hệ):");
            var cauC_Query = from m in dsMon
                             where m.TenMon.ToLower().Contains("web")
                             select new { m.TenMon, m.He };

            var cauC_Method = dsMon.Where(m => m.TenMon.ToLower().Contains("web"))
                                   .Select(m => new { m.TenMon, m.He });

            foreach (var item in cauC_Method)
            {
                Console.WriteLine($"   + {item.TenMon,-45} | Hệ: {item.He}");
            }

            // d. Liệt kê các môn thuộc hệ "KTV", sắp xếp tăng dần theo Mã môn
            Console.WriteLine("\nd. Các môn thuộc hệ 'KTV' (Sắp xếp tăng dần theo Mã môn):");
            var cauD_Query = from m in dsMon
                             where m.He == "KTV"
                             orderby m.MaMon ascending
                             select m;

            var cauD_Method = dsMon.Where(m => m.He == "KTV")
                                   .OrderBy(m => m.MaMon);

            foreach (var m in cauD_Method)
            {
                Console.WriteLine($"   + [{m.MaMon,-6}] {m.TenMon,-45} | Số tiết: {m.SoTiet}");
            }
        }
    }
}