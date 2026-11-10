/*
* LỚP QUẢN LÝ PHÂN SỐ ĐƠN LẺ
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*/

using System;

namespace MyLib
{
    public class PhanSo
    {
        private int _tuSo;
        private int _mauSo;

        public int TuSo
        {
            get => _tuSo;
            set => _tuSo = value;
        }

        public int MauSo
        {
            get => _mauSo;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Mẫu số không thể bằng 0.");
                }
                _mauSo = value;
            }
        }

        public PhanSo()
        {
            _tuSo = 0;
            _mauSo = 1;
        }

        public PhanSo(int tuSo, int mauSo = 1)
        {
            if (mauSo == 0)
            {
                throw new ArgumentException("Mẫu số không thể bằng 0.");
            }
            _tuSo = tuSo;
            _mauSo = mauSo;
            RutGon();
        }

        private static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a == 0 ? 1 : a;
        }

        public void RutGon()
        {
            if (_mauSo < 0)
            {
                _tuSo = -_tuSo;
                _mauSo = -_mauSo;
            }

            int ucln = UCLN(_tuSo, _mauSo);
            _tuSo /= ucln;
            _mauSo /= ucln;
        }

        public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
        {
            if (ps1 == null) return ps2 ?? new PhanSo();
            if (ps2 == null) return ps1;

            int tu = ps1.TuSo * ps2.MauSo + ps2.TuSo * ps1.MauSo;
            int mau = ps1.MauSo * ps2.MauSo;
            return new PhanSo(tu, mau);
        }

        public override string ToString()
        {
            if (_mauSo == 1) return $"{_tuSo}";
            return $"{_tuSo}/{_mauSo}";
        }
    }
}