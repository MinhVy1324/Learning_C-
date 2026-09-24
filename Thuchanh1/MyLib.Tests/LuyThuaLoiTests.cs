/*
* KIỂM THỬ TỰ ĐỘNG BÀI TÍNH LŨY THỪA VÀ KIỂM TRA SỐ NGUYÊN
* Tác giả : Võ Minh Vỹ

*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class LuyThuaLoiTests
    {
        [Theory]
        [InlineData("7", true, 7)]
        [InlineData("abc", false, 0)]
        [InlineData("3.14", false, 0)]
        public void Test_KiemTraSoNguyen(string input, bool expectedValid, int expectedValue)
        {
            bool actualValid = LuyThuaLoiLib.Kiemtrasonguyen(input, out int actualValue);

            Assert.Equal(expectedValid, actualValid);
            if (expectedValid)
            {
                Assert.Equal(expectedValue, actualValue);
            }
        }

        [Theory]
        [InlineData(7, 3, 343)]
        [InlineData(2, 10, 1024)]
        public void Test_TinhLuyThua(int x, int y, long expected)
        {
            long actual = LuyThuaLoiLib.LuyThua(x, y);
            Assert.Equal(expected, actual);
        }
    }
}