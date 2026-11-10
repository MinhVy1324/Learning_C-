using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MyLib
{
   public class Point
    {
        private double _x; private double _y;
        public double X
        {
            get => _x;
            set => _x = value;
        }
        public double Y
        {
            get => _y;
            set => _y = value;
        }
        public Point()
        {
            _x = 0; _y = 0;
        }
        public Point(double x, double y)
        {
            _x = x; _y = y;
        }
        public static Point Input()
        {
            Console.Write("Nhập x: ");
            double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double x);

            Console.Write("Nhập y: ");
            double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double y);

            return new Point(x, y);
        }
        public void Output()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point operator -(Point p)
        {
            return new Point(-p.X, -p.Y);
        }
        public double TinhKhoangCach(Point p)
        {
            if (p == null) return 0;
            double dx = p.X - this.X;
            double dy = p.Y - this.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        // Phương thức tĩnh
        public static double TinhKhoangCach(Point p1, Point p2)
        {
            if (p1 == null || p2 == null) return 0;
            return p1.TinhKhoangCach(p2);
        }

        // 8. (b) TRUNG ĐIỂM CỦA 2 ĐIỂM
        // Phương thức thành viên
        public Point TimTrungDiem(Point p)
        {
            if (p == null) return new Point(this.X, this.Y);
            return new Point((this.X + p.X) / 2.0, (this.Y + p.Y) / 2.0);
        }

        // Phương thức tĩnh
        public static Point TimTrungDiem(Point p1, Point p2)
        {
            if (p1 == null || p2 == null) return new Point();
            return p1.TimTrungDiem(p2);
        }
    }
}
