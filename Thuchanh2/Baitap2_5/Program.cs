/*
* CHƯƠNG TRÌNH THỰC THI TÍNH TỔNG DÃY PHÂN SỐ (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using MyLib;

namespace Baitap2_4_PhanSo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 2.4: QUẢN LÝ VÀ TÍNH TỔNG DÃY PHÂN SỐ ===");

            // 1. Nhập dãy phân số
            DayPhanSo dayPS = DayPhanSo.Input();

            // 2. Biểu diễn phép tính
            Console.WriteLine("\n-------------------------------------------");
            Console.Write("Phép tính: ");
            dayPS.Output();

            // 3. Tính tổng n phân số
            PhanSo tong = dayPS.TinhTong();

            Console.WriteLine($"\n=> TỔNG CỦA {dayPS.Count} PHÂN SỐ = {tong}");
            Console.WriteLine("-------------------------------------------");
        }
    }
}