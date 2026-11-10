/*
* KIỂM THỬ TỰ ĐỘNG BÀI SẮP XẾP MẢNG HỌ TÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class MangHoTenTests
    {
        [Fact]
        public void Test_SapXepTangDan_MoiTenChuCaiStandard()
        {
            string[] input = { "David", "Alice", "Charlie", "Bob" };
            string[] expected = { "Alice", "Bob", "Charlie", "David" };

            string[] actual = MangHoTenLib.SapXepTangDan(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_SapXepTangDan_KhongPhanBietHoaThuong()
        {
            string[] input = { "nguyễn văn c", "An", "Bình" };
            string[] expected = { "An", "Bình", "nguyễn văn c" };

            string[] actual = MangHoTenLib.SapXepTangDan(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_SapXepTangDan_MangRong()
        {
            string[] input = System.Array.Empty<string>();
            string[] actual = MangHoTenLib.SapXepTangDan(input);

            Assert.Empty(actual);
        }
    }
}