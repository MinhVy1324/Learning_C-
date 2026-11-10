using System;
using System.Collections.Generic;
using System.Linq; // ⚠️ BẮT BUỘC phải có dòng này để dùng LINQ

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main()
        {
            // Gọi thực thi Bài 2.1
            Bai2_1();
        }

        static void Bai2_1()
        {
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            Console.WriteLine("=== BÀI 2.1: TRUY VẤN MẢNG SỐ NGUYÊN ===");
            Console.WriteLine("Mảng ban đầu: " + string.Join(", ", mangSo));
            
            // a. Liệt kê các phần tử chia hết cho 4 và 3 (tức chia hết cho 12)
          
            Console.WriteLine("\na. Các phần tử chia hết cho 4 và 3:");

            
            var cauA_Query = from x in mangSo
                             where x % 4 == 0 && x % 3 == 0
                             select x;

           

            Console.WriteLine("   - Query Syntax  : " + string.Join(", ", cauA_Query));
         

           
            Console.WriteLine("\nb. Các phần tử nhỏ hơn hoặc bằng 3:");

           
            var cauB_Query = from x in mangSo
                             where x <= 3
                             select x;

            

            Console.WriteLine("   - Query Syntax  : " + string.Join(", ", cauB_Query));
            

            
            Console.WriteLine("\nc. Dãy mới (chẵn chia đôi, lẻ giữ nguyên):");

         
            var cauC_Query = from x in mangSo
                             select (x % 2 == 0 ? x / 2 : x);

            

            Console.WriteLine("   - Query Syntax  : " + string.Join(", ", cauC_Query));
        
        }
    }
}