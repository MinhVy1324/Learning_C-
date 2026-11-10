/*
* KIỂM THỬ TỰ ĐỘNG BÀI ĐẢO CHUỖI
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class DaoChuoiTests
    {
        [Theory]
        [InlineData("hello", "olleh")]
        [InlineData("Visual Studio", "oidutS lausiV")]
        [InlineData("12345", "54321")]
        [InlineData("a", "a")]
        [InlineData("", "")]
        public void Test_DaoChuoi(string input, string expected)
        {
            string actual = DaoChuoiLib.DaoChuoi(input);
            Assert.Equal(expected, actual);
        }

    
        
    }
}