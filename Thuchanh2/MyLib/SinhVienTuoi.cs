using System;
namespace MyLib
{
    public class SinhVienTuoi
    {
        // Fields
        private string _hoTen;
        private int _namSinh;
        // Constructor mặc định
        public SinhVienTuoi()
        {
            _hoTen = "Chưa xác định";
            _namSinh = 2000; // Giá trị mặc định
        }
        // Constructor 2 tham số
        public SinhVienTuoi(string hoTen, int namSinh)
        {
            HoTen = hoTen; // Sử dụng property để kiểm tra ràng buộc
            NamSinh = namSinh; // Sử dụng property để kiểm tra ràng buộc
        }
        // Properties
        public string HoTen
        {
            get => _hoTen;
            set => _hoTen = string.IsNullOrWhiteSpace(value) ? "Chưa xác định" : value.Trim();
        }

        public int NamSinh
        {
            get => _namSinh;
            set
            {
                int currentYear = DateTime.Now.Year;
                if (value < 1900 || value > currentYear)
                {
                    _namSinh = currentYear; // Nếu nhập sai quy định thì gán mặc định năm hiện tại
                }
                else
                {
                    _namSinh = value;
                }
            }
        }
        
        // Method tính tuổi sinh viên
        public int TinhTuoi(int namHienTai = 0)
        {
            if (namHienTai <= 0)
            {
                namHienTai = DateTime.Now.Year;
            }

            int tuoi = namHienTai - NamSinh;
            return tuoi < 0 ? 0 : tuoi;
        }
        // Method lấy thông tin sinh viên
        public string GetThongTin(int namHienTai = 0)
        {
            return $"Họ tên: {HoTen} | Năm sinh: {NamSinh} | Tuổi: {TinhTuoi(namHienTai)}";
        }
    }
}