using System;
using MyLib;
namespace Baitap1
{
    class NhapTenXuat
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine();
            string ketQua = NhapTenXuatLib.XuatHoTen(hoTen);
            Console.WriteLine(ketQua);
        }
    }
}
