/*
* THƯ VIỆN XỬ LÝ MẢNG HỌ TÊN (SẮP XẾP CHUỖI)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Nhập vào một mảng họ tên của n người. Hãy sắp xếp mảng đó theo thứ tự tăng dần (A-Z).
*
* Ý tưởng:
*   - SapXepTangDan(arr): Sử dụng Array.Sort kết hợp StringComparer.OrdinalIgnoreCase 
*     để sắp xếp danh sách chuỗi theo thứ tự bảng chữ cái A-Z (không phân biệt hoa/thường).
*   - Hàm trả về một mảng mới đã sắp xếp để bảo toàn mảng dữ liệu gốc.
*/
using System;
using MyLib;
public class Program {
    public static void Main(string[] args) {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int n;
        while (true)
        {
            Console.WriteLine("Nhập số lượng họ tên của mảng: ");
            string inputN = Console.ReadLine()!;
            if (int.TryParse(inputN, out n) && n > 0)
            {
                break;
            }
            Console.WriteLine("Lỗi: Số lượng phần tử phải là số nguyên dương!");
         }
        string[] dsHoTen = new string[n];
        Console.WriteLine($"\n--- Nhập họ tên cho {n} người ---");
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Nhập họ tên người thứ {i + 1}: ");
                string inputName = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(inputName))
                {
                    dsHoTen[i] = inputName.Trim();
                    break;
                }
                Console.WriteLine("Lỗi: Họ tên không được để trống!");
            }
        }

        // Gọi hàm sắp xếp từ thư viện MyLib
        string[] dsDaSapXep = MangHoTenLib.SapXepTangDan(dsHoTen);

        Console.WriteLine("\n-------------------------------------------");
        Console.WriteLine("DANH SÁCH HỌ TÊN SAU KHI SẮP XẾP TĂNG DẦN (A-Z):");
        for (int i = 0; i < dsDaSapXep.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {dsDaSapXep[i]}");
        }


    }
}