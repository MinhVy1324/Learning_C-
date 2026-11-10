/*
* CHƯƠNG TRÌNH THỰC THI THIẾT KẾ LỚP ARRAYPOINT (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using MyLib;
using System;
using System.Drawing;
using Point = MyLib.Point;

namespace Baitap2_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 2.1: THIẾT KẾ LỚP ARRAYPOINT VỚI INDEXER ===");

            ArrayPoint listPoint = new ArrayPoint();

            int n;
            while (true)
            {
                Console.Write("Nhập số lượng điểm Point muốn thêm vào danh sách (n > 0): ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("Lỗi: Số lượng phải là số nguyên dương!");
            }

            // Nhập các điểm
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập điểm thứ {i + 1} ---");
                Point p = Point.Input();
                listPoint.Add(p);
            }

            // Hiển thị danh sách điểm
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("DANH SÁCH CÁC ĐIỂM TRONG ARRAYPOINT:");
            listPoint.Output();

            // Minh họa sử dụng INDEXER để truy cập phần tử
            Console.WriteLine("\n[Thử nghiệm truy cập thông qua Indexer]");
            Console.Write("Nhập chỉ số i cần kiểm tra: ");
            if (int.TryParse(Console.ReadLine(), out int idx))
            {
                try
                {
                    Point? pGet = listPoint[idx];
                    Console.WriteLine($"-> Điểm tại chỉ số listPoint[{idx}] = {pGet}");

                    // Cập nhật giá trị qua Indexer
                    Console.WriteLine($"\n[Thử nghiệm cập nhật giá trị tại listPoint[{idx}] thành (99, 99)]");
                    listPoint[idx] = new Point(99, 99);
                    Console.WriteLine($"-> Giá trị mới tại listPoint[{idx}] = {listPoint[idx]}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Lỗi Indexer: {ex.Message}");
                }
            }

            Console.WriteLine("-------------------------------------------");
        }
    }
}