/*
* KIỂM THỬ TỰ ĐỘNG BÀI XỬ LÝ MẢNG SỐ NGUYÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class MangSoNguyenTests
    {
        [Fact]
        public void Test_TimMaxMin_MangHopLe()
        {
            int[] arr = { 5, 2, 9, 1, 7, 3 };
            bool result = MangSoNguyenLib.TimMaxMin(arr, out int max, out int min);

            Assert.True(result);
            Assert.Equal(9, max);
            Assert.Equal(1, min);
        }

        [Fact]
        public void Test_TimMaxMin_MangRong()
        {
            int[] arr = System.Array.Empty<int>();
            bool result = MangSoNguyenLib.TimMaxMin(arr, out int max, out int min);

            Assert.False(result);
            Assert.Equal(0, max);
            Assert.Equal(0, min);
        }

        [Fact]
        public void Test_LayDanhSachSoNguyenTo_CoSoNguyenTo()
        {
            int[] arr = { 4, 7, 10, 13, 1, 0, 19, 21 };
            int[] expected = { 7, 13, 19 };

            int[] actual = MangSoNguyenLib.LayDanhSachSoNguyenTo(arr);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_LayDanhSachSoNguyenTo_KhongCoSoNguyenTo()
        {
            int[] arr = { 4, 6, 8, 9, 10 };
            int[] actual = MangSoNguyenLib.LayDanhSachSoNguyenTo(arr);

            Assert.Empty(actual);
        }
    }
}