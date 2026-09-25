using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class ArrayPoint
    {
        private readonly ArrayList _points;
        public ArrayPoint()
        {
            _points = new ArrayList();
        }
        public ArrayPoint(int capacity)
        {
            _points = new ArrayList(capacity);
        }
        public int Count => _points.Count;
        public Point? this[int index]
        {
            get
            {
                if (index < 0 || index >= _points.Count)
                {
                    throw new IndexOutOfRangeException($"Chỉ số [{index}] nằm ngoài phạm vi danh sách (0 -> {_points.Count - 1}).");
                }
                return (Point?)_points[index];
            }
            set
            {
                if (index < 0 || index >= _points.Count)
                {
                    throw new IndexOutOfRangeException($"Chỉ số [{index}] nằm ngoài phạm vi danh sách (0 -> {_points.Count - 1}).");
                }
                if (value != null)
                {
                    _points[index] = value;
                }
            }
        }
        public void Add(Point p)
        {
            if (p != null)
            {
                _points.Add(p);
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _points.Count)
            {
                _points.RemoveAt(index);
            }
        }

        public void Output()
        {
            if (_points.Count == 0)
            {
                Console.WriteLine("Danh sách điểm rỗng.");
                return;
            }

            for (int i = 0; i < _points.Count; i++)
            {
                Console.WriteLine($"  - Điểm thứ [{i}]: {_points[i]}");
            }
        }
    }
}
