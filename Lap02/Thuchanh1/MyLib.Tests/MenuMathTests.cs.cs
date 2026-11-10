/*
* KIỂM THỬ TỰ ĐỘNG BÀI MENU TOÁN HỌC
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class MenuMathTests
    {
        [Theory]
        [InlineData("3.14", true, 3.14)]
        [InlineData("abc", false, 0)]
        public void Test_KiemTraSoThuc(string input, bool expectedValid, double expectedValue)
        {
            bool actualValid = MenuLib.Kiemtrasothuc (input, out double actualValue);
            Assert.Equal(expectedValid, actualValid);
            if (expectedValid)
            {
                Assert.Equal(expectedValue, actualValue);
            }
        }

        [Theory]
        [InlineData(2.0, 3.0, 8.0)]
        [InlineData(4.0, 0.5, 2.0)]
        public void Test_TinhLuyThua(double x, double y, double expected)
        {
            double actual = MenuLib.TinhLuyThua(x, y);
            Assert.Equal(expected, actual, precision: 4);
        }

        [Theory]
        [InlineData(9.0, 3.0)]
        [InlineData(0.0, 0.0)]
        public void Test_TinhCanBacTwo_HopLe(double val, double expected)
        {
            double actual = MenuLib.TinhCanBacTwo(val);
            Assert.Equal(expected, actual, precision: 4);
        }

        [Fact]
        public void Test_TinhCanBacTwo_SoAm()
        {
            double actual = MenuLib.TinhCanBacTwo(-4.0);
            Assert.True(double.IsNaN(actual));
        }
    }
}