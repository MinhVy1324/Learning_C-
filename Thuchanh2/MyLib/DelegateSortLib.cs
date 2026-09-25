/*
* THƯ VIỆN SẮP XẾP MẢNG TỔNG QUÁT BẰNG DELEGATE
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Bài 3.3: Viết phương thức sắp xếp một mảng tổng quát bằng delegate.
*
* Ý tưởng:
*   - Định nghĩa Generic Delegate `SoSanhHandler<T>(T x, T y)` nhận vào 2 đối tượng kiểu T,
*     trả về số nguyên (> 0 nếu x > y, = 0 nếu x == y, < 0 nếu x < y).
*   - Phương thức Sort<T>(T[] array, SoSanhHandler<T> comparer) nhận delegate làm tham số.
*   - Người dùng có thể linh hoạt truyền phương thức so sánh, Lambda Expression hoặc Anonymous Method
*     để sắp xếp theo bất kỳ tiêu chí nào mà không cần sửa đổi kiểu dữ liệu T.
*/

using System;

namespace MyLib
{
    // Định nghĩa Generic Delegate dùng để so sánh 2 phần tử kiểu T
    public delegate int SoSanhHandler<T>(T x, T y);

    public class DelegateSortLib
    {
        // Phương thức sắp xếp tổng quát nhận Delegate làm quy tắc so sánh
        public static void Sort<T>(T[]? array, SoSanhHandler<T> comparer)
        {
            if (array == null || array.Length <= 1 || comparer == null) return;

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // Gọi Delegate để kiểm tra điều kiện hoán vị
                    if (comparer(array[i], array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }

    // Lớp mô hình mẫu để kiểm thử sắp xếp linh hoạt nhiều tiêu chí
    public class NhanVien3_3
    {
        public string MaNV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public decimal Luong { get; set; }

        public NhanVien3_3() { }

        public NhanVien3_3(string maNV, string hoTen, decimal luong)
        {
            MaNV = maNV;
            HoTen = hoTen;
            Luong = luong;
        }

        public override string ToString()
        {
            return $"[Mã: {MaNV} | Họ tên: {HoTen,-15} | Lương: {Luong:N0} VNĐ]";
        }
    }
}