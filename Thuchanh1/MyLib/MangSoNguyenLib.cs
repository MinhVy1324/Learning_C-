using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
   public  class MangSoNguyenLib
    {
        public static bool KiemTraSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static bool TimMaxMin(int[] arr, out int max, out int min)
        {
            if (arr == null || arr.Length == 0)
            {
                max = min = 0;
                return false;
            }
            max = min = arr[0];
            foreach (var item in arr)
            {
                if (item > max) max = item;
                if (item < min) min = item;
            }
            return true;
        }
        public static int[] LayDanhSachSoNguyenTo(int[] arr)
        {
            List<int> primeList = new List<int>();
            foreach (var item in arr)
            {
                if (KiemTraSoNguyenTo(item))
                {
                    primeList.Add(item);
                }
            }
            return primeList.ToArray();
        }
        public static string ChuyenMangThanhChuoi(int[] arr)
        {
            return string.Join(", ", arr);
        }
    }
}
