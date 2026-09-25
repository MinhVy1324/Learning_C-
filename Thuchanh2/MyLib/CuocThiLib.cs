/*
* QUẢN LÝ CUỘC THI TIN HỌC VÀ TÍNH ĐIỂM THÍ SINH
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Bài 3.6: Cuộc thi Tin học gồm 2 đối tượng thí sinh:
*   - Thí sinh Chuyên: Làm 3 bài lập trình + 1 bài Tiếng Anh.
*     Điểm tổng = (Bài 1 + Bài 2 + Bài 3) + Điểm thưởng Tiếng Anh (7-8: +1đ, 9-10: +2đ).
*   - Thí sinh Siêu cúp: Làm 3 bài lập trình + 1 bài CSDL.
*     Điểm tổng = Bài 1 + Bài 2 + Bài 3 + CSDL.
*/

using System;
using System.Collections.Generic;

namespace MyLib
{
    // Lớp cơ sở Abstract ThiSinh
    public abstract class ThiSinh
    {
        public string SBD { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public double Bai1 { get; set; }
        public double Bai2 { get; set; }
        public double Bai3 { get; set; }

        public double TongDiem => TinhTongDiem();

        protected ThiSinh() { }

        protected ThiSinh(string sbd, string hoTen, double bai1, double bai2, double bai3)
        {
            SBD = sbd;
            HoTen = hoTen;
            Bai1 = bai1;
            Bai2 = bai2;
            Bai3 = bai3;
        }

        // Phương thức trừu tượng tính điểm (Đa hình)
        public abstract double TinhTongDiem();

        public virtual string GetThongTin()
        {
            return $"SBD: {SBD,-6} | Họ tên: {HoTen,-15} | B1: {Bai1:F1} | B2: {Bai2:F1} | B3: {Bai3:F1}";
        }
    }

    // Thí sinh bảng Chuyên
    public class ThiSinhChuyen : ThiSinh
    {
        public double TiengAnh { get; set; }

        public ThiSinhChuyen() { }

        public ThiSinhChuyen(string sbd, string hoTen, double bai1, double bai2, double bai3, double tiengAnh)
            : base(sbd, hoTen, bai1, bai2, bai3)
        {
            TiengAnh = tiengAnh;
        }

        public override double TinhTongDiem()
        {
            double tongLapTrinh = Bai1 + Bai2 + Bai3;
            double diemThuong = 0;

            if (TiengAnh >= 7.0 && TiengAnh <= 8.0)
            {
                diemThuong = 1.0;
            }
            else if (TiengAnh >= 9.0 && TiengAnh <= 10.0)
            {
                diemThuong = 2.0;
            }

            return tongLapTrinh + diemThuong;
        }

        public override string GetThongTin()
        {
            return $"{base.GetThongTin()} | Tiếng Anh: {TiengAnh:F1} | BẢNG: Chuyên   | TỔNG ĐIỂM: {TongDiem:F1}";
        }
    }

    // Thí sinh bảng Siêu cúp
    public class ThiSinhSieuCup : ThiSinh
    {
        public double CSDL { get; set; }

        public ThiSinhSieuCup() { }

        public ThiSinhSieuCup(string sbd, string hoTen, double bai1, double bai2, double bai3, double csdl)
            : base(sbd, hoTen, bai1, bai2, bai3)
        {
            CSDL = csdl;
        }

        public override double TinhTongDiem()
        {
            return Bai1 + Bai2 + Bai3 + CSDL;
        }

        public override string GetThongTin()
        {
            return $"{base.GetThongTin()} | CSDL: {CSDL:F1}       | BẢNG: Siêu Cúp | TỔNG ĐIỂM: {TongDiem:F1}";
        }
    }

    // Lớp quản lý cuộc thi
    public class CuocThi
    {
        public string TenCuocThi { get; set; } = "Cuộc thi Tin học";
        private readonly List<ThiSinh> _danhSachThiSinh = new List<ThiSinh>();

        public IReadOnlyList<ThiSinh> DanhSachThiSinh => _danhSachThiSinh.AsReadOnly();

        public void ThemThiSinh(ThiSinh ts)
        {
            if (ts != null)
            {
                _danhSachThiSinh.Add(ts);
            }
        }
    }
}