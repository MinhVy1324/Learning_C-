/*
* KIỂM THỬ TỰ ĐỘNG BÀI 6 ĐẾN BÀI 9
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class PhuongThucTests
    {
        // Test Bài 6
        [Theory]
        [InlineData(10, 20, 30, 30)]
        [InlineData(50, 10, 20, 50)]
        [InlineData(-5, -1, -10, -1)]
        public void Test_TimMax3So(int a, int b, int c, int expected)
        {
            Assert.Equal(expected, PhuongThucLib.TimMax3So(a, b, c));
        }

        // Test Bài 7
        [Theory]
        [InlineData(2, true)]
        [InlineData(17, true)]
        [InlineData(1, false)]
        [InlineData(4, false)]
        public void Test_KiemTraNguyenTo(int n, bool expected)
        {
            Assert.Equal(expected, PhuongThucLib.KiemTraNguyenTo(n));
        }

        // Test Bài 8 (ref)
        [Fact]
        public void Test_HoanVi()
        {
            double a = 3.5, b = 7.2;
            PhuongThucLib.HoanVi(ref a, ref b);

            Assert.Equal(7.2, a);
            Assert.Equal(3.5, b);
        }

        // Test Bài 9 (out)
        [Fact]
        public void Test_TimMaxMin3SoThuc()
        {
            double a = 10.5, b = 2.4, c = 18.9;
            PhuongThucLib.TimMaxMin3SoThuc(a, b, c, out double actualMax, out double actualMin);

            Assert.Equal(18.9, actualMax);
            Assert.Equal(2.4, actualMin);
        }
    }
}