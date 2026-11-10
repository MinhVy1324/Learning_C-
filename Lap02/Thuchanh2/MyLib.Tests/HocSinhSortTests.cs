/*
* KIỂM THỬ TỰ ĐỘNG SẮP XẾP MẢNG ĐỐI TƯỢNG BẰNG ARRAY.SORT
* Tác giả : Võ Minh Vỹ

*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class HocSinhSortTests
    {
        [Fact]
        public void Test_ArraySort_HocSinh_TheoDiemTBTangDan()
        {
            HocSinh[] list = new HocSinh[]
            {
                new HocSinh("SV01", "An", 8.5),
                new HocSinh("SV02", "Bình", 5.0),
                new HocSinh("SV03", "Cường", 9.2)
            };

            ArraySortLib.SapXepHocSinh(list);

            Assert.Equal("SV02", list[0].MaSV); // ĐTB 5.0 xếp đầu
            Assert.Equal("SV01", list[1].MaSV); // ĐTB 8.5 xếp giữa
            Assert.Equal("SV03", list[2].MaSV); // ĐTB 9.2 xếp cuối
        }

        [Fact]
        public void Test_CompareTo_KetQuaSoSanh()
        {
            HocSinh hs1 = new HocSinh("SV01", "A", 7.0);
            HocSinh hs2 = new HocSinh("SV02", "B", 8.0);

            Assert.True(hs1.CompareTo(hs2) < 0);
            Assert.True(hs2.CompareTo(hs1) > 0);
        }
    }
}