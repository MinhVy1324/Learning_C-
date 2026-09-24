/*
* CHƯƠNG TRÌNH THỰC THI BÀI 6 ĐẾN BÀI 9 (CONSOLE APP)
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
            
            Console.WriteLine("=== BAI 9: TIM MAX VA MIN 3 SO THUC (OUT) ===");
            double a = 12.5, b = 3.8, c = 25.4;
            PhuongThucLib.TimMaxMin3SoThuc(a, b, c, out double maxVal, out double minVal);
            Console.WriteLine($"Danh sach: {a}, {b}, {c}");
            Console.WriteLine($"Max = {maxVal}, Min = {minVal}");
        }
    }
}