using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public  class ChuoiLib
    {
        public static bool Kiemtradoixung(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return false;
            }
            StringBuilder stringBuilder = new StringBuilder();
               for(int i = str.Length - 1; i >= 0; i--)
            {
                stringBuilder.Append(str[i]);
            }
            return str == stringBuilder.ToString();
        }
    }
}
