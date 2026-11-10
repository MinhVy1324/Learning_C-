/*
* KIỂM THỬ TỰ ĐỘNG PHƯƠNG THỨC SẮP XẾP BẰNG DELEGATE
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class DelegateSortTests
    {
        [Fact]
        public void Test_Sort_SoNguyen_TangDan()
        {
            int[] numbers = { 9, 3, 7, 1, 5 };
            int[] expected = { 1, 3, 5, 7, 9 };

            DelegateSortLib.Sort(numbers, (a, b) => a.CompareTo(b));

            Assert.Equal(expected, numbers);
        }

        [Fact]
        public void Test_Sort_SoNguyen_GiamDan()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            int[] expected = { 9, 7, 5, 3, 1 };

            DelegateSortLib.Sort(numbers, (a, b) => b.CompareTo(a));

            Assert.Equal(expected, numbers);
        }

        [Fact]
        public void Test_Sort_NhanVien_TheoLuongGiamDan()
        {
            NhanVien3_3[] list = new NhanVien3_3[]
            {
                new NhanVien3_3("NV01", "A", 1000m),
                new NhanVien3_3("NV02", "B", 5000m),
                new NhanVien3_3("NV03", "C", 3000m)
            };

            // Truyền delegate so sánh lương giảm dần
            DelegateSortLib.Sort(list, (x, y) => y.Luong.CompareTo(x.Luong));

            Assert.Equal(5000m, list[0].Luong);
            Assert.Equal(3000m, list[1].Luong);
            Assert.Equal(1000m, list[2].Luong);
        }

        [Fact]
        public void Test_Sort_NullArrayHoacNullDelegate_KhongVangLoi()
        {
            int[]? nullArr = null;
            int[] validArr = { 3, 1, 2 };

            DelegateSortLib.Sort(nullArr, (a, b) => a.CompareTo(b));
            DelegateSortLib.Sort(validArr, null!);

            Assert.Null(nullArr);
            Assert.Equal(3, validArr[0]); // Mảng không thay đổi do delegate null
        }
    }
}