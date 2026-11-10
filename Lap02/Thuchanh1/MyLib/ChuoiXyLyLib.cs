using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class ChuoiXyLyLib
    {
        public static string TolowerCase(string str)
        {
            return str.ToLower();
        }
        public static string ToupperCase(string str) { return str.ToUpper(); }
        public static int Demsotu(string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (char.IsLetter(c))
                {
                    count++;
                }
            }
            return count;
        }

    }
}
