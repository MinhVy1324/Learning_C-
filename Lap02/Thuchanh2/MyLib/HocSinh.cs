using System;

namespace MyLib
{
    public class HocSinh : IComparable<HocSinh>
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public double DiemTB { get; set; }

        public HocSinh() { }

        public HocSinh(string maSV, string hoTen, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiemTB = diemTB;
        }

        // Thực thi phương thức của Interface IComparable<HocSinh>
        // Trả về < 0 nếu this < other, = 0 nếu bằng, > 0 nếu this > other
        public int CompareTo(HocSinh? other)
        {
            if (other == null) return 1;
            return this.DiemTB.CompareTo(other.DiemTB); // Sắp xếp tăng dần theo điểm trung bình
        }

        public override string ToString()
        {
            return $"[Mã: {MaSV} | Họ tên: {HoTen,-15} | ĐTB: {DiemTB:F1}]";
        }
    }

    public class ArraySortLib
    {
        // Gọi phương thức tĩnh Array.Sort(...)
        public static void SapXepHocSinh(HocSinh[]? danhSach)
        {
            if (danhSach != null && danhSach.Length > 0)
            {
                Array.Sort(danhSach);
            }
        }
    }
}