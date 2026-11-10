using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace MyLib
{
    public class MenuLib
    {
        public static bool Kiemtrasothuc(string input, out double result)
        {
            return double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
        }
        public static double TinhLuyThua( double a,double b)
        {
            return Math.Pow(a, b);
        }
        public static double TinhCanBacTwo(double val)
        {
            if (val < 0) return double.NaN;
            return Math.Sqrt(val);
        }
    }
}
