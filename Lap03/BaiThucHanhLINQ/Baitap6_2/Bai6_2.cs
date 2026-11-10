using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class Bai6_2
    {
        public static void Run()
        {
            var dsMon = DuLieu.DS_Mon();
            var dsHe = Bai6_1.DS_He();

            Console.WriteLine("=== BÀI 6.2: JOIN VÀ CÁC TOÁN TỬ TẬP HỢP ===");
            Console.WriteLine("--------------------------------------------------------------------------------");

            // a. Dùng join để liệt kê: Tên hệ, Mã môn, Tên môn
            Console.WriteLine("\na. Danh sách môn học kết hợp với Hệ (Inner Join):");
            var cauA = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He
                       select new { h.TenHe, m.MaMon, m.TenMon };

            foreach (var item in cauA)
            {
                Console.WriteLine($"   + [{item.TenHe,-18}] {item.MaMon,-8} | {item.TenMon}");
            }

            // b. Liệt kê cả những hệ chưa có môn học (Left Outer Join)
            Console.WriteLine("\nb. Danh sách hệ đào tạo bao gồm hệ chưa có môn (Left Outer Join):");
            var cauB = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into g
                       from m in g.DefaultIfEmpty()
                       select new
                       {
                           TenHe = h.TenHe,
                           MaMon = m != null ? m.MaMon : "(Trống)",
                           TenMon = m != null ? m.TenMon : "(Chưa có môn nào)"
                       };

            foreach (var item in cauB)
            {
                Console.WriteLine($"   + [{item.TenHe,-18}] {item.MaMon,-8} | {item.TenMon}");
            }

            // c. Liệt kê cả hệ chưa có môn học và môn học chưa khai báo hệ
            Console.WriteLine("\nc. Danh sách toàn bộ (Hệ chưa có môn + Môn chưa khai báo hệ):");
            var cauC_LeftJoin = from h in dsHe
                                join m in dsMon on h.MaHe equals m.He into g
                                from m in g.DefaultIfEmpty()
                                select new
                                {
                                    TenHe = h.TenHe,
                                    MaMon = m != null ? m.MaMon : "(Trống)",
                                    TenMon = m != null ? m.TenMon : "(Chưa có môn nào)"
                                };

            var cauC_MonKhongHe = from m in dsMon
                                  where !dsHe.Any(h => h.MaHe == m.He)
                                  select new
                                  {
                                      TenHe = "(Chưa khai báo hệ)",
                                      MaMon = m.MaMon,
                                      TenMon = m.TenMon
                                  };

            var cauC = cauC_LeftJoin.Concat(cauC_MonKhongHe);

            foreach (var item in cauC)
            {
                Console.WriteLine($"   + [{item.TenHe,-20}] {item.MaMon,-8} | {item.TenMon}");
            }

            // d. Chỉ liệt kê những hệ chưa có môn học và những môn học chưa khai báo hệ
            Console.WriteLine("\nd. Chỉ lấy hệ chưa có môn VÀ môn chưa khai báo hệ:");
            var heChuaCoMon = dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe))
                                  .Select(h => new { Loai = "Hệ chưa có môn", TenHe = h.TenHe, MaMon = "-", TenMon = "-" });

            var monChuaCoHe = dsMon.Where(m => !dsHe.Any(h => h.MaHe == m.He))
                                  .Select(m => new { Loai = "Môn chưa khai báo hệ", TenHe = "-", MaMon = m.MaMon, TenMon = m.TenMon });

            var cauD = heChuaCoMon.Concat(monChuaCoHe);

            foreach (var item in cauD)
            {
                Console.WriteLine($"   + [{item.Loai,-22}] Hệ: {item.TenHe,-18} | Mã: {item.MaMon,-6} | Môn: {item.TenMon}");
            }

            // e. Lấy 5 môn học đầu tiên có số tiết giảm dần; hiển thị Tên hệ, Mã môn, Tên môn, Số tiết
            Console.WriteLine("\ne. Top 5 môn học có số tiết cao nhất:");
            var cauE = (from m in dsMon
                        join h in dsHe on m.He equals h.MaHe into g
                        from h in g.DefaultIfEmpty()
                        orderby m.SoTiet descending
                        select new
                        {
                            TenHe = h != null ? h.TenHe : "(Chưa khai báo)",
                            MaMon = m.MaMon,
                            TenMon = m.TenMon,
                            SoTiet = m.SoTiet
                        }).Take(5);

            foreach (var item in cauE)
            {
                Console.WriteLine($"   + [{item.TenHe,-18}] {item.MaMon,-6} | {item.TenMon,-42} | {item.SoTiet} tiết");
            }

            // f. Cho biết tổng số môn học của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn
            Console.WriteLine("\nf. Tổng số môn học của mỗi hệ:");
            var cauF = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into g
                       select new
                       {
                           MaHe = h.MaHe,
                           TenHe = h.TenHe,
                           TongSoMon = g.Count()
                       };

            foreach (var item in cauF)
            {
                Console.WriteLine($"   + Mã hệ: {item.MaHe,-5} | Tên hệ: {item.TenHe,-18} | Tổng số môn: {item.TongSoMon}");
            }

            // g. Cho biết có bao nhiêu loại Số tiết khác nhau trong danh sách môn học
            int cauG = dsMon.Select(m => m.SoTiet).Distinct().Count();
            Console.WriteLine($"\ng. Số loại Số tiết khác nhau trong danh sách môn: {cauG}");

            // h. Tìm môn học đầu tiên có tên bắt đầu bằng "Lập trình"
            var cauH = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"\nh. Môn học đầu tiên bắt đầu bằng 'Lập trình':");
            if (cauH != null)
            {
                Console.WriteLine($"   + [{cauH.MaMon}] {cauH.TenMon} ({cauH.SoTiet} tiết)");
            }

            // i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm
            Console.WriteLine("\ni. Danh sách môn học theo từng hệ (có đánh số thứ tự STT):");
            var cauI = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into g
                       select new
                       {
                           TenHe = h.TenHe,
                           DanhSachMon = g.Select((m, index) => new { STT = index + 1, Mon = m })
                       };

            foreach (var nhom in cauI)
            {
                Console.WriteLine($"   === HỆ: {nhom.TenHe} ===");
                if (!nhom.DanhSachMon.Any())
                {
                    Console.WriteLine("       (Chưa có môn học)");
                    continue;
                }
                foreach (var item in nhom.DanhSachMon)
                {
                    Console.WriteLine($"       {item.STT}. [{item.Mon.MaMon}] {item.Mon.TenMon} ({item.Mon.SoTiet} tiết)");
                }
            }
        }
    }
}