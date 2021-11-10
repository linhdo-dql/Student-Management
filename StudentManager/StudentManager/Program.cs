using System;
using System.Collections.Generic;

namespace StudentManager
{
    class Program
    {
        List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program p = new Program();
            p.Menu();
        }
        public void Menu() 
        {
            
            StudentManagement s = new StudentManagement();
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
                    Menu();
                    break;
                case 2:
                    if (students.Count != 0)
                    {
                        s.UpdateStudentsById(students);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Chưa tạo Collections.");
                    }
                    Menu();
                    break;
                case 3:
                    if (students.Count != 0)
                    {
                        s.DeleteStudentById(students);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Chưa tạo Collections.");
                    }
                    Menu();
                    break;
                case 4:
                    if (students.Count != 0)
                    {
                        s.FindStudentByName(students);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Chưa tạo Collections.");
                    }
                    Menu();
                    break;
                case 5:
                    if (students.Count != 0)
                    {
                        s.SortStudentsByGPA(students);
                        s.ShowListStudent(students);
                    }
                    else
                    {
                        Console.WriteLine("Chưa tạo Collections.");
                    }
                    Menu();
                    break;
                case 6:
                    if (students.Count != 0)
                    {
                        s.SortStudentsByName(students);
                        s.ShowListStudent(students);
                    }
                    else
                    {
                        Console.WriteLine("Chưa tạo Collections.");
                    }
                    Menu();
                    break;
                case 7:
                    if (students.Count != 0)
                    {
                        s.SortStudentsById(students);
                        s.ShowListStudent(students);
                    }
                    else
                    {
                        Console.WriteLine("Chưa tạo Collections.");
                    }
                    Menu();
                    break;
                case 8:
                    if (students.Count != 0)
                    {
                        s.ShowListStudent(students);
                    }
                    else
                    {
                        Console.WriteLine("Chưa tạo Collections.");
                    }
                    Menu();
                    break;

                default: Menu(); break;
            }
        }
    }
}
