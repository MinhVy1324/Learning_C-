/*
* CHƯƠNG TRÌNH THỰC THI BÀI 6 
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using MyLib;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // --- Bài 6 ---
            Console.WriteLine("=== BAI 6: TIM MAX 3 SO NGUYEN ===");
            int maxInt = PhuongThucLib.TimMax3So(15, 42, 28);
            Console.WriteLine($"Max(15, 42, 28) = {maxInt}\n");

        }
    }
}