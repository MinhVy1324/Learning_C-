/*
* THƯ VIỆN XỬ LÝ MẢNG SỐ NGUYÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Viết các phương thức thành viên:
*   - Nhập / In mảng số nguyên.
*   - Tìm phần tử lớn nhất (Max) và nhỏ nhất (Min) trong mảng.
*   - Trả về mảng chứa các số nguyên tố.
*
* Ý tưởng:
*   - TimMaxMin(arr, out max, out min): Duyệt mảng 1 lần để tìm max và min.
*   - LayDanhSachSoNguyenTo(arr): Lọc các phần tử là số nguyên tố đưa vào List<int>, sau đó gọi ToArray().
*   - ChuyenMangThanhChuoi(arr): Dùng string.Join để tạo chuỗi in ra màn hình.
*/
using System;
using MyLib;
namespace Baitap15
{
    public class Program {
        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n;
            while (true) { 
                Console.WriteLine("nhap so luong phan tu cua mang: ");
                string inputN = Console.ReadLine()!;
                if (int.TryParse(inputN, out n) && n > 0)
                {
                    break;
                }
                Console.WriteLine("Lỗi: Số lượng phần tử phải là số nguyên dương!");
            }

            int[] arr = new int[n];
            Console.WriteLine($"\n--- Nhập {n} phần tử cho mảng ---");
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Nhập phần tử thứ arr[{i}]: ");
                    string inputVal = Console.ReadLine()!;
                    if (int.TryParse(inputVal, out arr[i]))
                    {
                        break;
                    }
                    Console.WriteLine("Lỗi: Giá trị nhập vào phải là số nguyên!");
                }
            }

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine($"Mảng vừa nhập: [ {MangSoNguyenLib.ChuyenMangThanhChuoi(arr)} ]");

            if (MangSoNguyenLib.TimMaxMin(arr, out int max, out int min))
            {
                Console.WriteLine($"Phần tử lớn nhất (Max): {max}");
                Console.WriteLine($"Phần tử nhỏ nhất (Min): {min}");
            }

            int[] dsNguyenTo = MangSoNguyenLib.LayDanhSachSoNguyenTo(arr);
            if (dsNguyenTo.Length > 0)
            {
                Console.WriteLine($"Mảng các số nguyên tố: [ {MangSoNguyenLib.ChuyenMangThanhChuoi(dsNguyenTo)} ]");
            }
            else
            {
                Console.WriteLine("Mảng không chứa số nguyên tố nào.");
            }
        }
        }
    
        
    }
