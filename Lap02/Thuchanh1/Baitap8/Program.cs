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
            
            
            Console.WriteLine("=== BAI 8: HOAN VI HAI SO THUC (REF) ===");
            double x = 5.5, y = 9.9;
            Console.WriteLine($"Truoc hoan vi: x = {x}, y = {y}");
            PhuongThucLib.HoanVi(ref x, ref y);
            Console.WriteLine($"Sau hoan vi:   x = {x}, y = {y}\n");

           
        }
    }
}