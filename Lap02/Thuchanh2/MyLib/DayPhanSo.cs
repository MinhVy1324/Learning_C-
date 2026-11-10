/*
* LỚP DAYPHANSO QUẢN LÝ DÃY N PHÂN SỐ VÀ TÍNH TỔNG
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Bài 2.4: Xây dựng lớp chứa n phân số. Hãy tính tổng của n phân số đó.
*/

using System;
using System.Collections.Generic;

namespace MyLib
{
    public class DayPhanSo
    {
        private readonly List<PhanSo> _danhSach;

        public int Count => _danhSach.Count;

        public DayPhanSo()
        {
            _danhSach = new List<PhanSo>();
        }

        public DayPhanSo(int n)
        {
            _danhSach = new List<PhanSo>(n < 0 ? 0 : n);
        }

        // Indexer truy cập phân số thứ i
        public PhanSo this[int index]
        {
            get
            {
                if (index < 0 || index >= _danhSach.Count)
                {
                    throw new IndexOutOfRangeException($"Chỉ số [{index}] nằm ngoài phạm vi dãy phân số.");
                }
                return _danhSach[index];
            }
            set
            {
                if (index < 0 || index >= _danhSach.Count)
                {
                    throw new IndexOutOfRangeException($"Chỉ số [{index}] nằm ngoài phạm vi dãy phân số.");
                }
                if (value != null)
                {
                    _danhSach[index] = value;
                }
            }
        }

        public void Add(PhanSo ps)
        {
            if (ps != null)
            {
                _danhSach.Add(ps);
            }
        }

        // Phương thức tính tổng n phân số trong dãy
        public PhanSo TinhTong()
        {
            PhanSo tong = new PhanSo(0, 1);
            foreach (var ps in _danhSach)
            {
                tong += ps;
            }
            return tong;
        }

        public static DayPhanSo Input()
        {
            int n;
            while (true)
            {
                Console.Write("Nhập số lượng phân số n (n > 0): ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0) break;
                Console.WriteLine("Lỗi: Số lượng phân số phải là số nguyên dương!");
            }

            DayPhanSo dayPS = new DayPhanSo(n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhập phân số thứ {i + 1} ---");
                int tu;
                while (true)
                {
                    Console.Write("  Nhập tử số: ");
                    if (int.TryParse(Console.ReadLine(), out tu)) break;
                    Console.WriteLine("  Lỗi: Tử số phải là số nguyên!");
                }

                int mau;
                while (true)
                {
                    Console.Write("  Nhập mẫu số (khác 0): ");
                    if (int.TryParse(Console.ReadLine(), out mau) && mau != 0) break;
                    Console.WriteLine("  Lỗi: Mẫu số phải là số nguyên khác 0!");
                }

                dayPS.Add(new PhanSo(tu, mau));
            }

            return dayPS;
        }

        public void Output()
        {
            if (_danhSach.Count == 0)
            {
                Console.WriteLine("Dãy phân số rỗng.");
                return;
            }

            Console.WriteLine(string.Join(" + ", _danhSach));
        }
    }
}