/*
* KIỂM THỬ TỰ ĐỘNG LỚP DAYSO
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class DaySoTests
    {
        [Fact]
        public void Test_Constructors_Va_Length()
        {
            DaySo dsDefault = new DaySo();
            Assert.Equal(0, dsDefault.Length);

            DaySo dsSize = new DaySo(5);
            Assert.Equal(5, dsSize.Length);

            int[] arr = { 1, 3, 5 };
            DaySo dsArr = new DaySo(arr);
            Assert.Equal(3, dsArr.Length);

            DaySo dsCopy = new DaySo(dsArr);
            Assert.Equal(3, dsCopy.Length);
        }

        [Fact]
        public void Test_Indexer_GetSet_ThanhCong()
        {
            int[] arr = { 10, 20, 30 };
            DaySo ds = new DaySo(arr);

            Assert.Equal(20, ds[1]);

            ds[1] = 99;
            Assert.Equal(99, ds[1]);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        public void Test_Indexer_ChiSoKhongHopLe_NemLoi(int invalidIndex)
        {
            DaySo ds = new DaySo(3);
            Assert.Throws<IndexOutOfRangeException>(() => {
                var val = ds[invalidIndex];
            });
        }

        [Fact]
        public void Test_TimSoChan()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            DaySo ds = new DaySo(arr);

            int[] expected = { 2, 4, 6 };
            int[] actual = ds.TimSoChan();

            Assert.Equal(expected, actual);
        }
    }
}