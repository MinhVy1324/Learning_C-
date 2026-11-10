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
            

           
            Console.WriteLine("=== BAI 7: KIEM TRA SO NGUYEN TO ===");
            int n = 17;
            bool isPrime = PhuongThucLib.KiemTraNguyenTo(n);
            Console.WriteLine($"{n} {(isPrime ? "la" : "khong phai la")} so nguyen to.\n");

           
        }
    }
}