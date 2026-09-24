///*
//* THƯ VIỆN XỬ LÝ TOÁN HỌC VÀ ĐẦU VÀO CHO MENU
//* Tác giả : Võ Minh Vỹ

//*
//* Phát biểu đề bài:
//*   Cung cấp các hàm kiểm tra số thực, tính lũy thừa x^y và căn bậc 2 của số thực.
//*
//* Ý tưởng:
//*   - KiemTraSoThuc(input, out val): Dùng double.TryParse để ép kiểu dữ liệu nhập vào.
//*   - TinhLuyThua(x, y): Dùng Math.Pow(x, y).
//*   - TinhCanBacTwo(val): Dùng Math.Sqrt(val). Trả về double.NaN nếu val < 0.
//*
//*


using System;
using MyLib;

namespace Baitap5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double x = 0, y = 0;
            bool daNhap = false;
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                string chon = Console.ReadLine()!;

                switch (chon)
                {
                    case "1":
                        Console.Write("Nhap x: ");
                        string inputX = Console.ReadLine()!;
                        Console.Write("Nhap y: ");
                        string inputY = Console.ReadLine()!;

                        if (MenuLib.Kiemtrasothuc(inputX, out x) && MenuLib.Kiemtrasothuc(inputY, out y))
                        {
                            daNhap = true;
                            Console.WriteLine($"Da nhap thanh cong x = {x}, y = {y}");
                        }
                        else
                        {
                            Console.WriteLine("Loi: x hoac y khong phai la so thuc hop le!");
                        }
                        break;

                    case "2":
                        if (!daNhap)
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap x, y truoc!");
                        }
                        else
                        {
                            double kq = MenuLib.TinhLuyThua(x, y);
                            Console.WriteLine($"Ket qua {x}^{y} = {kq}");
                        }
                        break;

                    case "3":
                        if (!daNhap)
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap x, y truoc!");
                        }
                        else
                        {
                            double sqrtX = MenuLib.TinhCanBacTwo(x);
                            double sqrtY = MenuLib.TinhCanBacTwo(y);

                            if (double.IsNaN(sqrtX))
                                Console.WriteLine($"x = {x} < 0, khong tinh duoc can bac 2 trong so thuc.");
                            else
                                Console.WriteLine($"Can bac 2 cua x ({x}) = {sqrtX}");

                            if (double.IsNaN(sqrtY))
                                Console.WriteLine($"y = {y} < 0, khong tinh duoc can bac 2 trong so thuc.");
                            else
                                Console.WriteLine($"Can bac 2 cua y ({y}) = {sqrtY}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Da thoat chuong trinh.");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Lựa chon khong hop le! Vui long chon tu 1 den 4.");
                        break;
                }
            }
        }
    }
}