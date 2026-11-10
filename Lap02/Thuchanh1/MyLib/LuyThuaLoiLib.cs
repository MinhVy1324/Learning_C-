using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class LuyThuaLoiLib
    {
        public static bool Kiemtrasonguyen(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
        public static long LuyThua(int x, int y)
        {
            return (long)Math.Pow(x, y);
        }
    }
}
