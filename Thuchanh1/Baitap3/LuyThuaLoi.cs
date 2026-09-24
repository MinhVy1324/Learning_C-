/*
* THƯ VIỆN TÍNH LŨY THỪA VÀ KIỂM TRA DỮ LIỆU ĐẦU VÀO
* Tác giả : Võ Minh Vỹ
*
* Phát biểu đề bài:
*   Tính lũy thừa x^y và kiểm tra giá trị x, y nhập vào có phải số nguyên hay không.
*
* Ý tưởng:
*   - KiemTraSoNguyen(input, out val): Dùng int.TryParse để ép kiểu chuỗi nhập vào số nguyên.
*   - TinhLuyThua(x, y): Sử dụng Math.Pow(x, y) để tính kết quả.
*
* Mã giả:
*   Hàm KiemTraSoNguyen(strInput, out value):
*     Trả về kết quả của int.TryParse(strInput, out value)
*
*   Hàm TinhLuyThua(x, y):
*     Trả về (long)Math.Pow(x, y)
*/
   using System;
using MyLib;    
namespace Baitap3
{
    class LuyThuaLoi
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen x: ");
            string inputX = Console.ReadLine();
            if (!LuyThuaLoiLib.Kiemtrasonguyen(inputX, out int x))
            {
                Console.WriteLine("Gia tri x khong hop le. Vui long nhap so nguyen.");
                return;
            }
            Console.Write("Nhap so nguyen y: ");
            string inputY = Console.ReadLine();
            if (!LuyThuaLoiLib.Kiemtrasonguyen(inputY, out int y))
            {
                Console.WriteLine("Gia tri y khong hop le. Vui long nhap so nguyen.");
                return;
            }
            long ketQua = LuyThuaLoiLib.LuyThua(x, y);
            Console.WriteLine($"{x}^{y} = {ketQua}");
        }
    }
}