/*
* CHƯƠNG TRÌNH THỰC THI SẮP XẾP TỔNG QUÁT BẰNG DELEGATE (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using MyLib;

namespace Baitap3_3
{
    public class Program
    {
        // Hàm so sánh nguyên bản (Named Method) truyền vào Delegate
        public static int SoSanhGiamDan(int a, int b)
        {
            return b.CompareTo(a);
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 3.3: SẮP XẾP MẢNG TỔNG QUÁT BẰNG DELEGATE ===");

            // 1. Sắp xếp mảng số nguyên giảm dần bằng Named Method Delegate
            int[] numbers = { 15, 3, 42, 8, 23, 90 };
            Console.WriteLine("\n1. Mảng số nguyên ban đầu: [ " + string.Join(", ", numbers) + " ]");

            DelegateSortLib.Sort(numbers, SoSanhGiamDan);
            Console.WriteLine("   Sau khi sắp xếp giảm dần: [ " + string.Join(", ", numbers) + " ]");

            // 2. Sắp xếp mảng chuỗi theo độ dài chuỗi tăng dần bằng Lambda Expression
            string[] names = { "Nguyễn Văn Anh", "Lê Bình", "Trần Thu Cúc", "An" };
            Console.WriteLine("\n2. Mảng chuỗi ban đầu: [ " + string.Join(", ", names) + " ]");

            DelegateSortLib.Sort(names, (x, y) => x.Length.CompareTo(y.Length));
            Console.WriteLine("   Sau khi sắp xếp theo độ dài chuỗi: [ " + string.Join(", ", names) + " ]");

            // 3. Sắp xếp mảng NhanVien3_3 linh hoạt theo Lương / Tên
            NhanVien3_3[] dsNhanVien = new NhanVien3_3[]
            {
                new NhanVien3_3("NV01", "Trần Văn B", 15000000m),
                new NhanVien3_3("NV02", "Nguyễn Văn A", 25000000m),
                new NhanVien3_3("NV03", "Lê Thị C", 12000000m)
            };

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("3a. Danh sách nhân viên (Tăng dần theo Lương):");
            DelegateSortLib.Sort(dsNhanVien, (nv1, nv2) => nv1.Luong.CompareTo(nv2.Luong));
            foreach (var nv in dsNhanVien) Console.WriteLine("   " + nv);

            Console.WriteLine("\n3b. Danh sách nhân viên (Tăng dần theo Họ tên A-Z):");
            DelegateSortLib.Sort(dsNhanVien, (nv1, nv2) => string.Compare(nv1.HoTen, nv2.HoTen, StringComparison.OrdinalIgnoreCase));
            foreach (var nv in dsNhanVien) Console.WriteLine("   " + nv);

            Console.WriteLine("-------------------------------------------");
        }
    }
}