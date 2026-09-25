/*
* THƯ VIỆN ĐẢO CHUỖI (STRING REVERSE)
* Tác giả : Võ Minh Vỹ
*
* Phát biểu đề bài:
*   Viết phương thức thành viên trả về chuỗi là đảo của một chuỗi.
*
* Ý tưởng:
*   - Sử dụng ToCharArray() để chuyển chuỗi thành mảng ký tự.
*   - Sử dụng Array.Reverse() để đảo ngược mảng ký tự.
*   - Khởi tạo chuỗi mới từ mảng đã đảo.
*
* Mã giả:
*   Hàm DaoChuoi(str):
*     Nếu str rỗng hoặc null: Trả về str
*     Tạo mảng charArray = str.ToCharArray()
*     Gọi Array.Reverse(charArray)
*     Trả về string mới từ charArray
*/
using System;
using MyLib;
namespace baitap11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Nhập chuỗi để đảo: ");
            string input = Console.ReadLine();
            string reversedString = DaoChuoiLib.DaoChuoi(input);
            Console.WriteLine($"Chuỗi đảo ngược của \"{input}\" là: \"{reversedString}\"");
        }
    }
}