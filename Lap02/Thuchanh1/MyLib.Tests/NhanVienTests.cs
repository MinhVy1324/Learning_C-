/*
* KIỂM THỬ TỰ ĐỘNG LỚP NHÂN VIÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class NhanVienTests
    {
        [Theory]
        [InlineData(10000000, 0, 10000000)] // Không vắng ngày nào
        [InlineData(10000000, 2, 9800000)]  // Vắng 2 ngày (-200k)
        [InlineData(500000, 10, 0)]         // Phạt vượt mức lương -> về 0
        public void Test_TinhLuongThucNhan(decimal mucLuong, int soNgayVang, decimal expected)
        {
            NhanVien nv = new NhanVien("Nguyễn Văn A", mucLuong, soNgayVang);
            decimal actual = nv.TinhLuongThucNhan();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-5000000, 0)] // Lương âm tự động về 0
        public void Test_MucLuong_KhongAm(decimal inputLuong, decimal expectedLuong)
        {
            NhanVien nv = new NhanVien();
            nv.MucLuong = inputLuong;
            Assert.Equal(expectedLuong, nv.MucLuong);
        }

        [Theory]
        [InlineData(-3, 0)] // Ngày vắng âm tự động về 0
        public void Test_SoNgayVang_KhongAm(int inputVang, int expectedVang)
        {
            NhanVien nv = new NhanVien();
            nv.SoNgayVang = inputVang;
            Assert.Equal(expectedVang, nv.SoNgayVang);
        }
    }
}