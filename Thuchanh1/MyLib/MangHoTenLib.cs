using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class MangHoTenLib
    {
        public static string[] SapXepTangDan(string[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return Array.Empty<string>();
            }
            string[] sortedArr = (string[])arr.Clone();
            Array.Sort(sortedArr, StringComparer.OrdinalIgnoreCase);
            return sortedArr;
        }
        public static string ChuyenMangThanhChuoi(string[] arr)
        {
            if (arr == null || arr.Length == 0) return "Mảng rỗng";
            return string.Join(", ", arr);
        }
    }
}
