/*
* THƯ VIỆN XỬ LÝ CHUỖI (STRING & STRINGBUILDER)
* Tác giả : Võ Minh Vỹ
*
* Phát biểu đề bài:
*   Viết phương thức thành viên kiểm tra chuỗi có đối xứng (Palindrome) hay không.
*
* Ý tưởng:

*   -  (StringBuilder): Đảo ngược chuỗi bằng StringBuilder rồi so sánh với chuỗi ban đầu.
*

*/
using System;
using MyLib;
namespace Baitap10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Nhập chuỗi để kiểm tra đối xứng: ");
            string input = Console.ReadLine();
            bool isPalindrome = ChuoiLib.Kiemtradoixung(input);
            if (isPalindrome)
            {
                Console.WriteLine($"Chuỗi \"{input}\" là chuỗi đối xứng.");
            }
            else
            {
                Console.WriteLine($"Chuỗi \"{input}\" không phải là chuỗi đối xứng.");
            }
        }
    }
}
