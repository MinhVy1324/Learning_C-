/*
* KIỂM THỬ TỰ ĐỘNG LỚP PERSON
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Test_DefaultConstructor()
        {
            Person p = new Person();
            Assert.Equal(string.Empty, p.Id);
            Assert.Equal(string.Empty, p.Name);
            Assert.Equal(0, p.Yob);
            Assert.Equal(0, p.Yod);
            Assert.True(p.IsLiving());
        }

        [Fact]
        public void Test_CopyConstructor()
        {
            Person original = new Person("P01", "Nguyễn Văn A", 1990, 0);
            Person copy = new Person(original);

            Assert.Equal(original.Id, copy.Id);
            Assert.Equal(original.Name, copy.Name);
            Assert.Equal(original.Yob, copy.Yob);
            Assert.Equal(original.Yod, copy.Yod);

            // Kiểm tra thay đổi bản sao không ảnh hưởng bản gốc
            copy.Name = "Trần Văn B";
            Assert.Equal("Nguyễn Văn A", original.Name);
        }

        [Theory]
        [InlineData(0, true)]     // yod = 0 -> Còn sống (true)
        [InlineData(2020, false)] // yod = 2020 -> Đã mất (false)
        public void Test_IsLiving(int yod, bool expectedIsLiving)
        {
            Person p = new Person("P02", "Lê Thị C", 1950, yod);
            Assert.Equal(expectedIsLiving, p.IsLiving());
        }
    }
}