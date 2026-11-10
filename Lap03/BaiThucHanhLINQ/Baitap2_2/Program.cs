using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập hiển thị tiếng Việt có dấu trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Bai2_2();
        }

        static void Bai2_2()
        {
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            Console.WriteLine("=== BÀI 2.2: TRUY VẤN MẢNG CHUỖI ===");
            Console.WriteLine("Mảng ban đầu: " + string.Join(", ", mangChuoi));
            Console.WriteLine("--------------------------------------------------");

            
            Console.WriteLine("\na. Có 4 ký tự và sắp xếp tăng dần theo ký tự đầu:");

           
            var cauA_Query = from s in mangChuoi
                             where s.Length == 4
                             orderby s[0]
                             select s;


            Console.WriteLine("   - Query Syntax  : " + string.Join(", ", cauA_Query));
               Console.WriteLine("\nb. Biến đổi dạng <chữ thường> - <CHỮ HOA>:");

            
            var cauB_Query = from s in mangChuoi
                             select $"{s.ToLower()} - {s.ToUpper()}";

            Console.WriteLine("   - Query Syntax  : " + string.Join(", ", cauB_Query));
          

            
            Console.WriteLine("\nc. Các phần tử có chứa ký tự \"u\":");

            
            var cauC_Query = from s in mangChuoi
                             where s.Contains("u")
                             select s;

            

            Console.WriteLine("   - Query Syntax  : " + string.Join(", ", cauC_Query));
            

            
            Console.WriteLine("\nd. Các phần tử bắt đầu bằng chữ in hoa:");

            
            var cauD_Query = from s in mangChuoi
                             where char.IsUpper(s[0])
                             select s;

           

            Console.WriteLine("   - Query Syntax  : " + string.Join(", ", cauD_Query));
          
        }
    }
}