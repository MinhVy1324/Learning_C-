/*
* KIỂM THỬ TỰ ĐỘNG BÀI CHUYỂN ĐỔI CHUỖI VÀ ĐẾM TỪ
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class ChuoiXyLyTests
    {
        [Theory]
        [InlineData("Xin Chào C#", "xin chào c#")]
        [InlineData("HELLO WORLD", "hello world")]
        public void Test_ToLowerCase(string input, string expected)
        {
            string actual = ChuoiXyLyLib.TolowerCase(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("xin chào c#", "XIN CHÀO C#")]
        [InlineData("hello world", "HELLO WORLD")]
        public void Test_ToUpperCase(string input, string expected)
        {
            string actual = ChuoiXyLyLib.ToupperCase(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        
        // Kiểm tra chuỗi có khoảng trắng thừa
        [InlineData("OneWord", 1)]
        [InlineData("", 0)]
        [InlineData("   ", 0)]
        public void Test_DemSoTu(string input, int expected)
        {
            int actual = ChuoiXyLyLib.Demsotu(input);
            Assert.Equal(expected, actual);
        }
    }
}