/*
* KIỂM THỬ TỰ ĐỘNG BÀI TÍNH ĐIỂM THÍ SINH
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class CuocThiTests
    {
        [Theory]
        [InlineData(8.0, 8.0, 8.0, 6.5, 24.0)] // TA < 7: +0 điểm thưởng -> 24.0
        [InlineData(8.0, 8.0, 8.0, 7.5, 25.0)] // 7 <= TA <= 8: +1 điểm thưởng -> 25.0
        [InlineData(8.0, 8.0, 8.0, 9.5, 26.0)] // 9 <= TA <= 10: +2 điểm thưởng -> 26.0
        public void Test_ThiSinhChuyen_TinhTongDiem(double b1, double b2, double b3, double ta, double expected)
        {
            ThiSinhChuyen ts = new ThiSinhChuyen("C01", "Nguyễn Văn A", b1, b2, b3, ta);
            Assert.Equal(expected, ts.TongDiem);
        }

        [Fact]
        public void Test_ThiSinhSieuCup_TinhTongDiem()
        {
            ThiSinhSieuCup ts = new ThiSinhSieuCup("SC01", "Trần Văn B", 9.0, 8.5, 9.5, 8.0);
            // Tổng 4 bài: 9.0 + 8.5 + 9.5 + 8.0 = 35.0
            Assert.Equal(35.0, ts.TongDiem);
        }

        [Fact]
        public void Test_CuocThi_DanhSachDaHinh()
        {
            CuocThi ct = new CuocThi();
            ct.ThemThiSinh(new ThiSinhChuyen("C01", "A", 10, 10, 10, 10)); // 30 + 2 = 32
            ct.ThemThiSinh(new ThiSinhSieuCup("SC01", "B", 10, 10, 10, 10)); // 10*4 = 40

            Assert.Equal(2, ct.DanhSachThiSinh.Count);
            Assert.Equal(32.0, ct.DanhSachThiSinh[0].TongDiem);
            Assert.Equal(40.0, ct.DanhSachThiSinh[1].TongDiem);
        }
    }
}