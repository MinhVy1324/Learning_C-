/*
* HỆ THỐNG QUẢN LÝ LƯƠNG NHÂN VIÊN (KẾ THỪA & ĐA HÌNH)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Bài 3.5: Công ty X có 2 bộ phận nhân viên:
*   - Thông tin cơ bản: Mã nhân viên, Họ tên.
*   - Nhân viên Kinh doanh: Lương = Lương cơ bản + (Số hợp đồng * 500.000).
*   - Nhân viên Sản xuất: Lương = Số sản phẩm * 1.000. Nếu làm trên 3.000 sản phẩm thì được thưởng thêm 5% lương.
*/

using System;

namespace MyLib
{
    // Lớp cơ sở Abstract NhanVienCompany
    public abstract class NhanVienCompany
    {
        public string MaNV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;

        protected NhanVienCompany() { }

        protected NhanVienCompany(string maNV, string hoTen)
        {
            MaNV = maNV;
            HoTen = hoTen;
        }

        // Phương thức trừu tượng tính lương (Đa hình)
        public abstract decimal TinhLuong();

        public virtual string GetThongTin()
        {
            return $"[Mã NV: {MaNV}] Họ tên: {HoTen,-15}";
        }
    }

    // Lớp Nhân viên Kinh doanh (Kế thừa từ NhanVienCompany)
    public class NhanVienKinhDoanh : NhanVienCompany
    {
        public const decimal TIEN_THUONG_HOP_DONG = 500000m;

        private decimal _luongCoBan;
        private int _soHopDong;

        public decimal LuongCoBan
        {
            get => _luongCoBan;
            set => _luongCoBan = value < 0 ? 0 : value;
        }

        public int SoHopDong
        {
            get => _soHopDong;
            set => _soHopDong = value < 0 ? 0 : value;
        }

        public NhanVienKinhDoanh() { }

        public NhanVienKinhDoanh(string maNV, string hoTen, decimal luongCoBan, int soHopDong)
            : base(maNV, hoTen)
        {
            LuongCoBan = luongCoBan;
            SoHopDong = soHopDong;
        }

        public override decimal TinhLuong()
        {
            return LuongCoBan + (SoHopDong * TIEN_THUONG_HOP_DONG);
        }

        public override string GetThongTin()
        {
            return $"{base.GetThongTin()} | Bộ phận: Kinh Doanh | Lương CB: {LuongCoBan:N0} VNĐ | Số HĐ: {SoHopDong,-2} | LƯƠNG THỰC NHẬN: {TinhLuong():N0} VNĐ";
        }
    }

    // Lớp Nhân viên Sản xuất (Kế thừa từ NhanVienCompany)
    public class NhanVienSanXuat : NhanVienCompany
    {
        public const decimal DON_GIA_SAN_PHAM = 1000m;
        public const int NGUONG_THUONG = 3000;
        public const decimal TY_LE_THUONG = 0.05m;

        private int _soSanPham;

        public int SoSanPham
        {
            get => _soSanPham;
            set => _soSanPham = value < 0 ? 0 : value;
        }

        public NhanVienSanXuat() { }

        public NhanVienSanXuat(string maNV, string hoTen, int soSanPham)
            : base(maNV, hoTen)
        {
            SoSanPham = soSanPham;
        }

        public override decimal TinhLuong()
        {
            decimal luongCoBan = SoSanPham * DON_GIA_SAN_PHAM;
            if (SoSanPham > NGUONG_THUONG)
            {
                luongCoBan += luongCoBan * TY_LE_THUONG; // Thưởng thêm 5%
            }
            return luongCoBan;
        }

        public override string GetThongTin()
        {
            return $"{base.GetThongTin()} | Bộ phận: Sản Xuất  | Số SP: {SoSanPham,-6} | LƯƠNG THỰC NHẬN: {TinhLuong():N0} VNĐ";
        }
    }
}