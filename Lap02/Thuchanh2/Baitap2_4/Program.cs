/*
* CHƯƠNG TRÌNH THỰC THI QUẢN LÝ MẢNG 2 CHIỀU (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using MyLib;

namespace Baitap2_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 2.4: QUẢN LÝ MẢNG 2 CHIỀU (N x M) ===");

            // 1. Nhập mảng 2 chiều
            Console.WriteLine("\n--- 1. Nhập mảng 2 chiều ---");
            Mang2Chieu m2D = Mang2Chieu.Input();

            // 2. Xuất mảng 2 chiều
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine($"Mảng 2 chiều kích thước {m2D.Rows}x{m2D.Cols}:");
            m2D.Output();

            // 3. Minh họa Indexer 2D
            if (m2D.Rows > 0 && m2D.Cols > 0)
            {
                Console.WriteLine($"\n[Thử nghiệm Indexer 2D]");
                Console.WriteLine($"-> Phần tử tại m2D[0, 0] = {m2D[0, 0]}");
            }

            // 4. Tìm các số nguyên tố trong mảng
            int[] dsNguyenTo = m2D.TimSoNguyenTo();
            Console.WriteLine("\n[Danh sách các số nguyên tố trong mảng 2D]");
            if (dsNguyenTo.Length > 0)
            {
                Console.WriteLine($"-> [ {string.Join(", ", dsNguyenTo)} ]");
            }
            else
            {
                Console.WriteLine("-> Mảng không chứa số nguyên tố nào.");
            }

            // 5. Thử nghiệm Copy Constructor
            Console.WriteLine("\n[Thử nghiệm Copy Constructor]");
            Mang2Chieu m2DSaoChep = new Mang2Chieu(m2D);
            Console.WriteLine("Mảng 2 chiều bản sao:");
            m2DSaoChep.Output();

            Console.WriteLine("-------------------------------------------");
        }
    }
}