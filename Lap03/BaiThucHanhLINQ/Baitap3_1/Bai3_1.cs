using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Bai3_1
    {
        public static void Run()
        {
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            Console.WriteLine("=== BÀI 3.1: THỐNG KÊ MẢNG SỐ ===");
            Console.WriteLine("Mảng ban đầu: " + string.Join(", ", mangSo));
            Console.WriteLine("--------------------------------------------------");

            // a. Cho biết tổng số phần tử, số phần tử chẵn và số phần tử lẻ
            int tongSoPhanTu = mangSo.Count();
            int soSoChan = mangSo.Count(x => x % 2 == 0);
            int soSoLe = mangSo.Count(x => x % 2 != 0);

            Console.WriteLine("\na. Thống kê số lượng:");
            Console.WriteLine($"   - Tổng số phần tử : {tongSoPhanTu}");
            Console.WriteLine($"   - Số phần tử chẵn : {soSoChan}");
            Console.WriteLine($"   - Số phần tử lẻ   : {soSoLe}");

            // b. Tính tổng các giá trị, giá trị lớn nhất và giá trị nhỏ nhất
            int tongGiaTri = mangSo.Sum();
            int max = mangSo.Max();
            int min = mangSo.Min();

            Console.WriteLine("\nb. Giá trị thống kê:");
            Console.WriteLine($"   - Tổng các giá trị : {tongGiaTri}");
            Console.WriteLine($"   - Giá trị lớn nhất : {max}");
            Console.WriteLine($"   - Giá trị nhỏ nhất : {min}");

            // c. Cho biết có bao nhiêu giá trị khác nhau trong mảng
            int soGiaTriKhacNhau = mangSo.Distinct().Count();
            Console.WriteLine($"\nc. Số giá trị khác nhau: {soGiaTriKhacNhau}");

            // d. Phân nhóm các phần tử theo số dư khi chia cho 5
            Console.WriteLine("\nd. Phân nhóm các phần tử theo số dư khi chia cho 5:");

            // Cách 1: Method Syntax (GroupBy)
            var nhomSoDu = mangSo.GroupBy(x => x % 5);

            foreach (var nhom in nhomSoDu)
            {
                Console.WriteLine($"   * Số dư {nhom.Key}: {string.Join(", ", nhom)}");
            }
        }
    }
}