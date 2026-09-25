/*
* KIỂM THỬ TỰ ĐỘNG BÀI TÍNH TUỔI SINH VIÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class SinhVienTuoiTests
    {
        [Fact]
        public void Test_KhoiTao_Va_TinhTuoi_ThanhCong()
        {
            SinhVienTuoi sv = new SinhVienTuoi("Nguyễn Văn A", 2004);
            int tuoi = sv.TinhTuoi(2026); // Giả lập năm 2026

            Assert.Equal("Nguyễn Văn A", sv.HoTen);
            Assert.Equal(2004, sv.NamSinh);
            Assert.Equal(22, tuoi);
        }

        [Theory]
        [InlineData(1800)] // Năm sinh quá khứ không hợp lệ
        [InlineData(2099)] // Năm sinh tương lai không hợp lệ
        public void Test_NamSinh_KhongHopLe_GanMacDinh(int namSinh)
        {
            SinhVienTuoi sv = new SinhVienTuoi("Test", namSinh);
            int current = DateTime.Now.Year;
            Assert.Equal(current, sv.NamSinh);
        }
    }
}
