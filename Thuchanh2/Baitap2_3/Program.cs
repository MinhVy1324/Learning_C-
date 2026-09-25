/*
* CHƯƠNG TRÌNH THỰC THI QUẢN LÝ DÃY SỐ (CONSOLE APP)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using MyLib;

namespace Baitap2_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 2.3: LỚP DÃY SỐ (MẢNG 1 CHIỀU) ===");

            // 1. Nhập dãy số
            Console.WriteLine("\n--- 1. Nhập thông tin dãy số ---");
            DaySo daySo = DaySo.Input();

            // 2. Xuất dãy số
            Console.WriteLine("\n-------------------------------------------");
            Console.Write("Dãy số vừa nhập: ");
            daySo.Output();

            // 3. Minh họa Indexer
            if (daySo.Length > 0)
            {
                Console.WriteLine($"\n[Thử nghiệm truy cập qua Indexer]");
                Console.WriteLine($"-> Phần tử đầu tiên daySo[0] = {daySo[0]}");
                Console.WriteLine($"-> Phần tử cuối cùng daySo[{daySo.Length - 1}] = {daySo[daySo.Length - 1]}");
            }

            // 4. Tìm các số chẵn
            int[] soChan = daySo.TimSoChan();
            Console.WriteLine("\n[Danh sách các số chẵn trong dãy]");
            if (soChan.Length > 0)
            {
                Console.WriteLine($"-> [ {string.Join(", ", soChan)} ]");
            }
            else
            {
                Console.WriteLine("-> Dãy số không chứa số chẵn nào.");
            }

            // 5. Thử nghiệm Copy Constructor
            Console.WriteLine("\n[Thử nghiệm Copy Constructor]");
            DaySo daySoSaoChep = new DaySo(daySo);
            Console.Write("Dãy số bản sao: ");
            daySoSaoChep.Output();

            Console.WriteLine("-------------------------------------------");
        }
    }
}