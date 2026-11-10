/*
* KIỂM THỬ TỰ ĐỘNG LỚP POINT
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using Xunit;
using MyLib;

namespace MyLib.Tests
{
    public class PointTests
    {
        [Fact]
        public void Test_DefaultConstructor()
        {
            Point p = new Point();
            Assert.Equal(0, p.X);
            Assert.Equal(0, p.Y);
        }

        [Fact]
        public void Test_PhepToanCong()
        {
            Point p1 = new Point(2, 3);
            Point p2 = new Point(4, 1);
            Point pTong = p1 + p2;

            Assert.Equal(6, pTong.X);
            Assert.Equal(4, pTong.Y);
        }

        [Fact]
        public void Test_PhepToanTru()
        {
            Point p1 = new Point(5, 7);
            Point p2 = new Point(2, 3);
            Point pHieu = p1 - p2;

            Assert.Equal(3, pHieu.X);
            Assert.Equal(4, pHieu.Y);
        }

        [Fact]
        public void Test_PhepToanLayAm()
        {
            Point p = new Point(3, -5);
            Point pAm = -p;

            Assert.Equal(-3, pAm.X);
            Assert.Equal(5, pAm.Y);
        }

        [Fact]
        public void Test_KhoangCach()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 4);

            double kcThanhVien = p1.TinhKhoangCach(p2);
            double kcTinh = Point.TinhKhoangCach(p1, p2);

            Assert.Equal(5.0, kcThanhVien, precision: 4);
            Assert.Equal(5.0, kcTinh, precision: 4);
        }

        [Fact]
        public void Test_TrungDiem()
        {
            Point p1 = new Point(2, 4);
            Point p2 = new Point(6, 8);

            Point tdThanhVien = p1.TimTrungDiem(p2);
            Point tdTinh = Point.TimTrungDiem(p1, p2);

            Assert.Equal(4, tdThanhVien.X);
            Assert.Equal(6, tdThanhVien.Y);

            Assert.Equal(4, tdTinh.X);
            Assert.Equal(6, tdTinh.Y);
        }

        
    }
}