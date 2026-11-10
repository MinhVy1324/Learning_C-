/*
* LỚP DAYSO QUẢN LÝ MẢNG 1 CHIỀU CÁC SỐ NGUYÊN
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Bài 2.3: Xây dựng lớp dãy số chứa n số nguyên:
*   a. Các loại Constructor (Mặc định, Theo độ dài, Từ mảng, Copy Constructor)
*   b. Indexer để truy cập phần tử thứ i trong dãy
*   c. Nhập / Xuất dãy số
*   d. Tìm các số chẵn
*/

using System;
using System.Collections.Generic;

namespace MyLib
{
    public class DaySo
    {
        // Field lưu dữ liệu mảng 1 chiều
        private int[] _data;

        // a. CÁC LOẠI CONSTRUCTOR
        // Default Constructor
        public DaySo()
        {
            _data = Array.Empty<int>();
        }

        // Parameterized Constructor (Khởi tạo theo số lượng phần tử n)
        public DaySo(int n)
        {
            if (n < 0) n = 0;
            _data = new int[n];
        }

        // Parameterized Constructor (Khởi tạo từ một mảng số nguyên có sẵn)
        public DaySo(int[]? arr)
        {
            if (arr == null)
            {
                _data = Array.Empty<int>();
            }
            else
            {
                _data = (int[])arr.Clone();
            }
        }

        // Copy Constructor (Sao chép từ một đối tượng DaySo khác)
        public DaySo(DaySo? other)
        {
            if (other == null || other._data == null)
            {
                _data = Array.Empty<int>();
            }
            else
            {
                _data = (int[])other._data.Clone();
            }
        }

        // Property lấy số lượng phần tử trong dãy
        public int Length => _data.Length;

        // b. INDEXER TRUY CẬP PHẦN TỬ THỨ I
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= _data.Length)
                {
                    throw new IndexOutOfRangeException($"Chỉ số [{index}] nằm ngoài phạm vi dãy số (0 -> {_data.Length - 1}).");
                }
                return _data[index];
            }
            set
            {
                if (index < 0 || index >= _data.Length)
                {
                    throw new IndexOutOfRangeException($"Chỉ số [{index}] nằm ngoài phạm vi dãy số (0 -> {_data.Length - 1}).");
                }
                _data[index] = value;
            }
        }

        // c. NHẬP / XUẤT DÃY SỐ
        public static DaySo Input()
        {
            int n;
            while (true)
            {
                Console.Write("Nhập số lượng phần tử n (n >= 0): ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 0)
                {
                    break;
                }
                Console.WriteLine("Lỗi: Số lượng phần tử phải là số nguyên không âm!");
            }

            DaySo daySo = new DaySo(n);
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"  - Nhập phần tử thứ [{i}]: ");
                    if (int.TryParse(Console.ReadLine(), out int val))
                    {
                        daySo[i] = val;
                        break;
                    }
                    Console.WriteLine("  Lỗi: Vui lòng nhập số nguyên hợp lệ!");
                }
            }

            return daySo;
        }

        public void Output()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            if (_data.Length == 0) return "Dãy số rỗng";
            return $"[ {string.Join(", ", _data)} ]";
        }

        // d. TÌM CÁC SỐ CHẴN
        public int[] TimSoChan()
        {
            List<int> dsChan = new List<int>();
            foreach (int item in _data)
            {
                if (item % 2 == 0)
                {
                    dsChan.Add(item);
                }
            }
            return dsChan.ToArray();
        }
    }
}