/*
* THƯ VIỆN TÍNH LŨY THỪA X^Y
* Tác giả : Võ Minh Vỹ
*
* Ý tưởng:
*   Sử dụng hàm Math.Pow(x, y) để tính lũy thừa và ép kiểu về long.
*
* Mã giả:
*   Hàm TinhLuyThua(x, y):
*     Trả về (long)Math.Pow(x, y)
*/
using System;
using MyLib;
namespace Baitap2
{
    class LuyThua
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());
            long ketQua = LuyThuaLib.LuyThua(x, y);
            Console.WriteLine($"{x}^{y} = {ketQua}");
        }
    }
}