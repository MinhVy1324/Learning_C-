/*
* KIỂM THỬ TỰ ĐỘNG LỚP ARRAYPOINT VỚI INDEXER
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class ArrayPointTests
    {
        [Fact]
        public void Test_Add_Va_Count()
        {
            ArrayPoint arrayPoint = new ArrayPoint();
            arrayPoint.Add(new Point(1, 2));
            arrayPoint.Add(new Point(3, 4));

            Assert.Equal(2, arrayPoint.Count);
        }

        [Fact]
        public void Test_Indexer_Get_ThanhCong()
        {
            ArrayPoint arrayPoint = new ArrayPoint();
            Point p1 = new Point(2.5, 3.5);
            Point p2 = new Point(4.0, 5.0);

            arrayPoint.Add(p1);
            arrayPoint.Add(p2);

            Point? result = arrayPoint[1];

            Assert.NotNull(result);
            Assert.Equal(4.0, result.X);
            Assert.Equal(5.0, result.Y);
        }

        [Fact]
        public void Test_Indexer_Set_ThanhCong()
        {
            ArrayPoint arrayPoint = new ArrayPoint();
            arrayPoint.Add(new Point(1, 1));

            // Thay đổi qua Indexer
            arrayPoint[0] = new Point(10, 20);

            Assert.Equal(10, arrayPoint[0]!.X);
            Assert.Equal(20, arrayPoint[0]!.Y);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        public void Test_Indexer_VoiChiSoKhongHopLe_NemLoi(int invalidIndex)
        {
            ArrayPoint arrayPoint = new ArrayPoint();
            arrayPoint.Add(new Point(1, 1));

            Assert.Throws<IndexOutOfRangeException>(() => {
                var p = arrayPoint[invalidIndex];
            });
        }
    }
}