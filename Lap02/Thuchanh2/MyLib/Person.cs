/*
* LỚP QUẢN LÝ THÔNG TIN MỘT NGƯỜI (PERSON)
* Tác giả : Võ Minh Vỹ
* Ngày viết: 25/09/2026
*
* Phát biểu đề bài:
*   Định nghĩa lớp Person gồm dữ liệu thành viên: id, name, yob (năm sinh), yod (năm mất).
*   Các phương thức: Default Constructor, Copy Constructor, Input(), Output(), IsLiving().
*
* Ý tưởng:
*   - Fields/Properties: Id, Name, Yob, Yod.
*   - Default Constructor: Khởi tạo giá trị mặc định (yob = 0, yod = 0 nghĩa là còn sống).
*   - Copy Constructor: Person(Person other) sao chép dữ liệu từ một đối tượng Person khác.
*   - IsLiving(): Trả về true nếu yod == 0 (hoặc yod <= 0), ngược lại trả về false.
*/

using System;

namespace MyLib
{
    public class Person
    {
        // 1. FIELDS & PROPERTIES
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Yob { get; set; } // Year of Birth
        public int Yod { get; set; } // Year of Death (0 nghĩa là còn sống)

        // 2. CONSTRUCTORS
        // Default Constructor
        public Person()
        {
            Id = string.Empty;
            Name = string.Empty;
            Yob = 0;
            Yod = 0;
        }

        // Parameterized Constructor
        public Person(string id, string name, int yob, int yod = 0)
        {
            Id = id;
            Name = name;
            Yob = yob;
            Yod = yod;
        }

        // Copy Constructor
        public Person(Person other)
        {
            if (other != null)
            {
                Id = other.Id;
                Name = other.Name;
                Yob = other.Yob;
                Yod = other.Yod;
            }
        }

        // 3. METHODS
        // Kiểm tra xem còn sống hay không
        public bool IsLiving()
        {
            return Yod == 0;
        }

        // Phương thức nhập dữ liệu từ Console
        public static Person Input()
        {
            Person p = new Person();

            Console.Write("Nhập ID: ");
            p.Id = Console.ReadLine()!;

            Console.Write("Nhập Họ và Tên: ");
            p.Name = Console.ReadLine()!;

            int yob;
            while (true)
            {
                Console.Write("Nhập Năm sinh (YOB): ");
                if (int.TryParse(Console.ReadLine(), out yob) && yob >= 0)
                {
                    p.Yob = yob;
                    break;
                }
                Console.WriteLine("Lỗi: Năm sinh phải là số nguyên không âm!");
            }

            int yod;
            while (true)
            {
                Console.Write("Nhập Năm mất (YOD - Nhập 0 nếu còn sống): ");
                if (int.TryParse(Console.ReadLine(), out yod) && yod >= 0)
                {
                    p.Yod = yod;
                    break;
                }
                Console.WriteLine("Lỗi: Năm mất phải là số nguyên không âm!");
            }

            return p;
        }

        // Phương thức xuất thông tin ra Console
        public void Output()
        {
            Console.WriteLine($"[ID: {Id}] - Tên: {Name} | Năm sinh: {Yob} | Trạng thái: {(IsLiving() ? "Còn sống" : $"Đã mất ({Yod})")}");
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, YOB: {Yob}, YOD: {Yod}, IsLiving: {IsLiving()}";
        }
    }
}