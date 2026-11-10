using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
   public class Mang2Chieu
    {
        private int[,] _data;
        
        public Mang2Chieu()
        {
            _data = new int[0,0 ];

        }   
        public Mang2Chieu(int rows, int cols)
        {
            int r = rows < 0 ? 0 : rows;
            int c = cols < 0 ? 0 : cols;
            _data = new int[r, c];
        }
        public Mang2Chieu(int[,]? matrix)
        {
            if (matrix == null)
            {
                _data = new int[0, 0];
            }
            else
            {
                _data = (int[,])matrix.Clone();
            }
        }

        // Copy Constructor (Sao chép từ đối tượng Mang2Chieu khác)
        public Mang2Chieu(Mang2Chieu? other)
        {
            if (other == null || other._data == null)
            {
                _data = new int[0, 0];
            }
            else
            {
                _data = (int[,])other._data.Clone();
            }
        }

        // Properties lấy số dòng và số cột
        public int Rows => _data.GetLength(0);
        public int Cols => _data.GetLength(1);

        // b. INDEXER TRUY CẬP PHẦN TỬ TẠI VỊ TRÍ (i, j)
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Cols)
                {
                    throw new IndexOutOfRangeException($"Vị trí [{i}, {j}] nằm ngoài phạm vi mảng 2D ({Rows}x{Cols}).");
                }
                return _data[i, j];
            }
            set
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Cols)
                {
                    throw new IndexOutOfRangeException($"Vị trí [{i}, {j}] nằm ngoài phạm vi mảng 2D ({Rows}x{Cols}).");
                }
                _data[i, j] = value;
            }
        }

        // c. NHẬP / XUẤT MẢNG 2 CHIỀU
        public static Mang2Chieu Input()
        {
            int rows, cols;
            while (true)
            {
                Console.Write("Nhập số dòng (n >= 0): ");
                if (int.TryParse(Console.ReadLine(), out rows) && rows >= 0) break;
                Console.WriteLine("Lỗi: Số dòng phải là số nguyên không âm!");
            }

            while (true)
            {
                Console.Write("Nhập số cột (m >= 0): ");
                if (int.TryParse(Console.ReadLine(), out cols) && cols >= 0) break;
                Console.WriteLine("Lỗi: Số cột phải là số nguyên không âm!");
            }

            Mang2Chieu m2D = new Mang2Chieu(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    while (true)
                    {
                        Console.Write($"  - Nhập phần tử [{i}, {j}]: ");
                        if (int.TryParse(Console.ReadLine(), out int val))
                        {
                            m2D[i, j] = val;
                            break;
                        }
                        Console.WriteLine("  Lỗi: Vui lòng nhập số nguyên hợp lệ!");
                    }
                }
            }

            return m2D;
        }

        public void Output()
        {
            if (Rows == 0 || Cols == 0)
            {
                Console.WriteLine("Mảng 2 chiều rỗng.");
                return;
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"{_data[i, j],6}");
                }
                Console.WriteLine();
            }
        }

        // d. TÌM CÁC SỐ NGUYÊN TỐ TRONG MẢNG
        public static bool KiemTraNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public int[] TimSoNguyenTo()
        {
            List<int> dsNguyenTo = new List<int>();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (KiemTraNguyenTo(_data[i, j]))
                    {
                        dsNguyenTo.Add(_data[i, j]);
                    }
                }
            }
            return dsNguyenTo.ToArray();
        }
    }
}

