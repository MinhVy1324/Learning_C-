using System;
using MyLib;    
namespace Baitap12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhập chuỗi: ");
            string str = Console.ReadLine();
            Console.WriteLine("Chuỗi in thường: " + ChuoiXyLyLib.TolowerCase(str));
            Console.WriteLine("Chuỗi in hoa: " + ChuoiXyLyLib.ToupperCase(str));
            Console.WriteLine("Số ký tự trong chuỗi: " + ChuoiXyLyLib.Demsotu(str));

            string chuoiThuong = ChuoiXyLyLib.TolowerCase(str);
            string chuoiHoa = ChuoiXyLyLib.ToupperCase(str);
            int soTu = ChuoiXyLyLib.Demsotu(str);

            Console.WriteLine($"\nChuoi chu thuong: {chuoiThuong}");
            Console.WriteLine($"Chuoi chu hoa   : {chuoiHoa}");
            Console.WriteLine($"So tu trong chuoi: {soTu}");
        }
    }
}