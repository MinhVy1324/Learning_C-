/*
* KIỂM THỬ TỰ ĐỘNG BÀI TÍNH LƯƠNG NHÂN VIÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class NhanVien3_5Tests
    {
        [Theory]
        [InlineData(5000000, 0, 5000000)]   // 0 hợp đồng
        [InlineData(8000000, 4, 10000000)]  // 4 hợp đồng (+2tr)
        public void Test_NhanVienKinhDoanh_TinhLuong(decimal luongCB, int soHD, decimal expected)
        {
            NhanVienKinhDoanh nvKD = new NhanVienKinhDoanh("KD01", "An", luongCB, soHD);
            Assert.Equal(expected, nvKD.TinhLuong());
        }

        [Theory]
        [InlineData(2000, 2000000)] // <= 3000 SP (không thưởng): 2000 * 1000 = 2tr
        [InlineData(3000, 3000000)] // Đúng 3000 SP (không thưởng): 3000 * 1000 = 3tr
        [InlineData(4000, 4200000)] // > 3000 SP (thưởng 5%): 4000 * 1000 * 1.05 = 4.2tr
        public void Test_NhanVienSanXuat_TinhLuong(int soSP, decimal expected)
        {
            NhanVienSanXuat nvSX = new NhanVienSanXuat("SX01", "Bình", soSP);
            Assert.Equal(expected, nvSX.TinhLuong());
        }

        [Fact]
        public void Test_TinhDaHinh_DanhSachNhanVien()
        {
            NhanVienCompany nv1 = new NhanVienKinhDoanh("KD01", "A", 5000000m, 2); // 6.000.000 VNĐ
            NhanVienCompany nv2 = new NhanVienSanXuat("SX01", "B", 4000);          // 4.200.000 VNĐ

            decimal tong = nv1.TinhLuong() + nv2.TinhLuong();

            Assert.Equal(10200000m, tong);
        }
    }
}
