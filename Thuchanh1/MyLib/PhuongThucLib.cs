/*
* THƯ VIỆN CÁC PHƯƠNG THỨC TRUYỀN THAM SỐ (THAM TRỊ, REF, OUT, BOOL)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;

namespace MyLib
{
    public class PhuongThucLib
    {
        // Bài 6: Return giá trị - Tìm giá trị lớn nhất của 3 số nguyên
        public static int TimMax3So(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        // Bài 7: Phương thức bool - Kiểm tra n có phải số nguyên tố không
        public static bool KiemTraNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // Bài 8: Tham chiếu ref - Hoán vị hai số thực
        public static void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        // Bài 9: Tham chiếu out - Tìm max và min của ba số thực
        public static void TimMaxMin3SoThuc(double a, double b, double c, out double max, out double min)
        {
            max = Math.Max(a, Math.Max(b, c));
            min = Math.Min(a, Math.Min(b, c));
        }
    }
}