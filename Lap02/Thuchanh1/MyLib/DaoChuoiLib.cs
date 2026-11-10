using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class DaoChuoiLib
    {
        public static string DaoChuoi(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return str;
            }
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

        }
    }
}
