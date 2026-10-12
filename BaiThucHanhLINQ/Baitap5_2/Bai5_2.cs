using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Bai5_2
    {
        public static void Run()
        {
            var dsMon = DuLieu.DS_Mon();

            Console.WriteLine("=== BÀI 5.2: THỐNG KÊ TRÊN LIST<MONHOC> ===");
            Console.WriteLine("------------------------------------------------------------------");

            // a. Cho biết tổng số môn hiện có
            int tongSoMon = dsMon.Count();
            Console.WriteLine($"a. Tổng số môn hiện có: {tongSoMon}");

            // b. Đếm số môn có tên bắt đầu bằng "Lập trình"
            int soMonLapTrinh = dsMon.Count(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"b. Số môn có tên bắt đầu bằng 'Lập trình': {soMonLapTrinh}");

            // c. Tính tổng số tiết của hệ Kỹ thuật viên (KTV)
            int tongSoTietKTV = dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet);
            Console.WriteLine($"c. Tổng số tiết của hệ KTV: {tongSoTietKTV}");

            // d. Cho biết tổng số môn của mỗi hệ: Hệ, Tổng số môn
            Console.WriteLine("\nd. Tổng số môn của mỗi hệ:");
            var cauD = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
                            .Select(g => new { He = g.Key, TongSoMon = g.Count() });
            foreach (var item in cauD)
            {
                Console.WriteLine($"   - Hệ {item.He,-5}: {item.TongSoMon} môn");
            }

            // e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết
            Console.WriteLine("\ne. Nhóm theo Số tiết (Sắp xếp giảm dần theo Số tiết):");
            var cauE = dsMon.GroupBy(m => m.SoTiet)
                            .OrderByDescending(g => g.Key)
                            .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() });
            foreach (var item in cauE)
            {
                Console.WriteLine($"   - Số tiết: {item.SoTiet,3} | Tổng số môn: {item.TongSoMon}");
            }

            // f. Cho biết thông tin môn học có số tiết cao nhất
            byte maxSoTiet = dsMon.Max(m => m.SoTiet);
            var cauF = dsMon.Where(m => m.SoTiet == maxSoTiet);
            Console.WriteLine($"\nf. Môn học có số tiết cao nhất ({maxSoTiet} tiết):");
            foreach (var m in cauF)
            {
                Console.WriteLine($"   - [{m.MaMon}] {m.TenMon} ({m.He})");
            }

            // g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, số tiết thấp nhất
            Console.WriteLine("\ng. Thống kê tổng hợp theo Hệ:");
            var cauG = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
                            .Select(g => new {
                                He = g.Key,
                                TongSoMon = g.Count(),
                                TongSoTiet = g.Sum(m => (int)m.SoTiet),
                                MaxSoTiet = g.Max(m => m.SoTiet),
                                MinSoTiet = g.Min(m => m.SoTiet)
                            });
            foreach (var item in cauG)
            {
                Console.WriteLine($"   - Hệ {item.He,-5}: {item.TongSoMon} môn | Tổng: {item.TongSoTiet} tiết | Max: {item.MaxSoTiet} tiết | Min: {item.MinSoTiet} tiết");
            }

            // h. Liệt kê các môn học được phân nhóm theo Hệ
            Console.WriteLine("\nh. Danh sách môn học phân nhóm theo Hệ:");
            var cauH = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He);
            foreach (var g in cauH)
            {
                Console.WriteLine($"   === HỆ: {g.Key} ===");
                foreach (var m in g)
                {
                    Console.WriteLine($"       + [{m.MaMon,-6}] {m.TenMon}");
                }
            }

            // i. Liệt kê các môn học được phân nhóm theo Số tiết và tăng dần theo Số tiết
            Console.WriteLine("\ni. Danh sách môn học phân nhóm theo Số tiết (tăng dần):");
            var cauI = dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key);
            foreach (var g in cauI)
            {
                Console.WriteLine($"   === SỐ TIẾT: {g.Key} ===");
                foreach (var m in g)
                {
                    Console.WriteLine($"       + [{m.MaMon,-6}] {m.TenMon} ({m.He})");
                }
            }

            // j. Với hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn
            Console.WriteLine("\nj. Hệ KTV - Phân nhóm theo học phần (sắp xếp theo Mã môn):");
            var cauJ = dsMon.Where(m => m.He == "KTV" && m.MaMon.Contains("_"))
                            .GroupBy(m => m.MaMon.Split('_')[0])
                            .OrderBy(g => g.Key);
            foreach (var g in cauJ)
            {
                Console.WriteLine($"   === HỌC PHẦN: {g.Key} ===");
                foreach (var m in g.OrderBy(m => m.MaMon))
                {
                    Console.WriteLine($"       + [{m.MaMon,-6}] {m.TenMon}");
                }
            }

            // k. Phân nhóm theo Hệ, chỉ lấy các môn có Số tiết > 40; trong mỗi nhóm sắp xếp theo Mã môn
            Console.WriteLine("\nk. Phân nhóm theo Hệ (chỉ lấy môn > 40 tiết, sắp xếp theo Mã môn):");
            var cauK = dsMon.Where(m => m.SoTiet > 40)
                            .GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He);
            foreach (var g in cauK)
            {
                Console.WriteLine($"   === HỆ: {g.Key} ===");
                foreach (var m in g.OrderBy(m => m.MaMon))
                {
                    Console.WriteLine($"       + [{m.MaMon,-6}] {m.TenMon} ({m.SoTiet} tiết)");
                }
            }
        }
    }
}