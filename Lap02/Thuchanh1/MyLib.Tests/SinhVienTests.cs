/*
* KIỂM THỬ TỰ ĐỘNG LỚP SINH VIÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class SinhVienTests
    {
        [Fact]
        public void Test_KhoiTaoSinhVien_ThanhCong()
        {
            SinhVien sv = new SinhVien("SV001", "Nguyễn Văn A", "TP.HCM", 2);

            Assert.Equal("SV001", sv.MaSV);
            Assert.Equal("Nguyễn Văn A", sv.HoTen);
            Assert.Equal("TP.HCM", sv.DiaChi);
            Assert.Equal(2, sv.NamThu);
        }

        [Theory]
        [InlineData(0, 1)]  // Nhập năm 0 tự chuyển thành 1
        [InlineData(-3, 1)] // Nhập năm âm tự chuyển thành 1
        [InlineData(3, 3)]  // Nhập đúng giữ nguyên
        public void Test_RangBuocNamThu(int inputNam, int expectedNam)
        {
            SinhVien sv = new SinhVien("SV002", "Trần Thị B", "Hà Nội", inputNam);
            Assert.Equal(expectedNam, sv.NamThu);
        }

        [Fact]
        public void Test_GetThongTin_XuatDungDinhDang()
        {
            SinhVien sv = new SinhVien("SV003", "Lê Văn C", "Đà Nẵng", 4);
            string expected = "Mã SV: SV003 | Họ tên: Lê Văn C | Địa chỉ: Đà Nẵng | Sinh viên năm thứ: 4";

            Assert.Equal(expected, sv.GetThongTin());
        }
    }
}