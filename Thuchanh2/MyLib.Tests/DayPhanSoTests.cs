/*
* KIỂM THỬ TỰ ĐỘNG LỚP DAYPHANSO
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;
using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class DayPhanSoTests
    {
        [Fact]
        public void Test_PhanSo_CongHaiPhanSo()
        {
            PhanSo ps1 = new PhanSo(1, 2);
            PhanSo ps2 = new PhanSo(1, 3);
            PhanSo tong = ps1 + ps2;

            Assert.Equal(5, tong.TuSo);
            Assert.Equal(6, tong.MauSo);
        }

        [Fact]
        public void Test_DayPhanSo_TinhTong_ThanhCong()
        {
            DayPhanSo dayPS = new DayPhanSo();
            dayPS.Add(new PhanSo(1, 2)); // 1/2
            dayPS.Add(new PhanSo(1, 4)); // 1/4
            dayPS.Add(new PhanSo(1, 4)); // 1/4

            PhanSo tong = dayPS.TinhTong(); // 1/2 + 1/4 + 1/4 = 1/1 = 1

            Assert.Equal(1, tong.TuSo);
            Assert.Equal(1, tong.MauSo);
            Assert.Equal("1", tong.ToString());
        }

        [Fact]
        public void Test_DayPhanSo_Rong_TraVeKhong()
        {
            DayPhanSo dayPS = new DayPhanSo();
            PhanSo tong = dayPS.TinhTong();

            Assert.Equal(0, tong.TuSo);
            Assert.Equal(1, tong.MauSo);
        }

        [Fact]
        public void Test_PhanSo_MauSoBangKhong_NemLoi()
        {
            Assert.Throws<ArgumentException>(() => {
                var ps = new PhanSo(5, 0);
            });
        }
    }
}