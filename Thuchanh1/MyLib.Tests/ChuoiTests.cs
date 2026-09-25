using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class ChuoiTests
    {
        [Theory]
        [InlineData("radar", true)]
        [InlineData("Madam", false)]
        [InlineData("hello", false)]
        [InlineData("12321", true)]
        [InlineData("123321", true)]
        [InlineData("a", true)]
        [InlineData("", false)]
        [InlineData("world", false)]
        public void Test_KiemTraDoiXung(string input, bool expected)
        {
            bool actual = ChuoiLib.Kiemtradoixung(input);
            Assert.Equal(expected, actual);
        }
    }
}