using System;
using System.Collections.Generic;

namespace StudentManager
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu();
        }
        public static void Menu() 
        {
            StudentManagement s = new StudentManagement();
            Menu:
            Console.WriteLine("-----------------------------*** Quản lý sinh viên ***-------------------------------");
            Console.WriteLine("1. Thêm sinh viên. ");
            Console.WriteLine("2. Cập nhật thông tin sinh viên bởi ID. ");
            Console.WriteLine("3. Xóa sinh viên bởi ID. ");
            Console.WriteLine("4. Tìm kiếm sinh viên theo tên. ");
            Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA).");
            Console.WriteLine("6. Sắp xếp sinh viên theo tên. ");
            Console.WriteLine("7. Sắp xếp sinh viên theo ID. ");
            Console.WriteLine("8. Hiển thị danh sách sinh viên ");
            Console.WriteLine("0. Thoát.");
            Console.WriteLine("Mời chọn: ");
            dynamic choose = Console.ReadLine();
            while (!int.TryParse(choose, out int value))
            {
                Console.Write("Sai. Nhập lại: ");
                choose = Console.ReadLine();
            }
            switch (int.Parse(choose))
            {
                case 0: break;
                case 1:
                    students = s.InputListStudent(students);
                    s.ShowListStudent(students);
                    goto Menu;
                case 2:
                    if (Check())
                    {
                        s.UpdateStudentsById(students);
                        Console.WriteLine();
                    }
                    goto Menu;
                case 3:
                    if (Check())
                    {
                        s.DeleteStudentById(students);
                        Console.WriteLine();
                    }
                    goto Menu;
                case 4:
                    if (Check())
                    {
                        s.FindStudentByName(students);
                        Console.WriteLine();
                    }
                    goto Menu;
                case 5:
                    if (Check())
                    {
                        s.SortStudentsByGPA(students);
                        s.ShowListStudent(students);
                    }
                    goto Menu;
                case 6:
                    if (Check())
                    {
                        s.SortStudentsByName(students);
                        s.ShowListStudent(students);
                    }
                    goto Menu;
                case 7:
                    if (Check())
                    {
                        s.SortStudentsById(students);
                        s.ShowListStudent(students);
                    }
                    goto Menu;
                case 8:
                    if (Check())
                    {
                        s.ShowListStudent(students);
                    }
                    goto Menu;

                default: goto Menu;
            }
        }
        public static bool Check()
        {
            if(students.Count != 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Chưa tạo Collections.");
                return false;
            }
        }
    }
}
