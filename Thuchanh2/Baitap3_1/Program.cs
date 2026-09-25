using MyLib;
namespace Baitap3_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 3.1: SẮP XẾP MẢNG ĐỐI TƯỢNG BẰNG ARRAY.SORT ===");

            HocSinh[] danhSach = new HocSinh[]
            {
                new HocSinh("SV03", "Trần Thị B", 7.5),
                new HocSinh("SV01", "Nguyễn Văn A", 9.0),
                new HocSinh("SV04", "Lê Văn C", 6.2),
                new HocSinh("SV02", "Phạm Thị D", 8.8)
            };

            Console.WriteLine("\n--- Danh sách trước khi sắp xếp ---");
            foreach (var hs in danhSach)
            {
                Console.WriteLine(hs);
            }

            // Gọi hàm thực thi Array.Sort(...)
            ArraySortLib.SapXepHocSinh(danhSach);

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("DANH SÁCH SAU KHI SẮP XẾP (TĂNG DẦN THEO ĐIỂM TB):");
            foreach (var hs in danhSach)
            {
                Console.WriteLine(hs);
            }
        }
    }
}