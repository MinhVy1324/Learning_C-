/*
* CHƯƠNG TRÌNH THỰC THI QUẢN LÝ PERSON (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using MyLib;

namespace Baitap1_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 1.3: QUẢN LÝ THÔNG TIN PERSON ===");

            // 1. Khởi tạo bằng Default Constructor và gọi hàm Input()
            Console.WriteLine("\n--- 1. Nhập thông tin Person A ---");
            Person pA = Person.Input();

            Console.WriteLine("\n--- Thông tin Person A vừa nhập ---");
            pA.Output();

            // 2. Sử dụng Copy Constructor để tạo Person B từ Person A
            Console.WriteLine("\n--- 2. Tạo Person B bằng Copy Constructor từ Person A ---");
            Person pB = new Person(pA);
            Console.Write("Thông tin Person B (Sao chép): ");
            pB.Output();

            // Thử nghiệm thay đổi thông tin Person B để chứng minh độc lập dữ liệu
            pB.Name = pA.Name + " (Sao chép)";
            Console.WriteLine("\nSau khi cập nhật tên Person B:");
            Console.WriteLine($"Person A: {pA.Name}");
            Console.WriteLine($"Person B: {pB.Name}");
            Console.WriteLine("-------------------------------------------");
        }
    }
}