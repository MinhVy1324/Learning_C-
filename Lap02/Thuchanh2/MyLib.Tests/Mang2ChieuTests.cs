/*
* KIỂM THỬ TỰ ĐỘNG LỚP MANG2CHIEU VỚI INDEXER 2D
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class Mang2ChieuTests
    {
        [Fact]
        public void Test_Constructors_Va_Dimensions()
        {
            Mang2Chieu mDefault = new Mang2Chieu();
            Assert.Equal(0, mDefault.Rows);
            Assert.Equal(0, mDefault.Cols);

            Mang2Chieu mSize = new Mang2Chieu(2, 3);
            Assert.Equal(2, mSize.Rows);
            Assert.Equal(3, mSize.Cols);

            int[,] raw = { { 1, 2 }, { 3, 4 } };
            Mang2Chieu mRaw = new Mang2Chieu(raw);
            Assert.Equal(2, mRaw.Rows);
            Assert.Equal(2, mRaw.Cols);
        }

        [Fact]
        public void Test_Indexer2D_GetSet_ThanhCong()
        {
            int[,] raw = {
                { 10, 20 },
                { 30, 40 }
            };
            Mang2Chieu m = new Mang2Chieu(raw);

            Assert.Equal(20, m[0, 1]);

            m[0, 1] = 99;
            Assert.Equal(99, m[0, 1]);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, 5)]
        [InlineData(3, 3)]
        public void Test_Indexer2D_ViTriKhongHopLe_NemLoi(int row, int col)
        {
            int[,] raw = { { 1, 2 }, { 3, 4 } };
            Mang2Chieu m = new Mang2Chieu(raw);

            Assert.Throws<IndexOutOfRangeException>(() => {
                var val = m[row, col];
            });
        }

        [Fact]
        public void Test_TimSoNguyenTo()
        {
            int[,] raw = {
                { 4, 7, 8 },
                { 11, 15, 13 }
            };
            Mang2Chieu m = new Mang2Chieu(raw);

            int[] expected = { 7, 11, 13 };
            int[] actual = m.TimSoNguyenTo();

            Assert.Equal(expected, actual);
        }
    }
}