using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    class StudentManagement
    {

        /// <summary>
        /// Thêm 1 sinh viên
        /// </summary>
        public Student InputStudent(List<Student> students)
        {
            Student student = new Student();
            //Set ID tự động tăng
            student.Id = students.Count != 0 ? IdStudentAutoIncreased(students) : 0;
            
            Console.Write("Nhập tên sinh viên: ");
            student.Name = Console.ReadLine();
            while (student.Name == "")
            {
                Console.Write("Sai. Nhập lại: ");
                student.Name = Console.ReadLine();
            }

            Console.Write("Nhập giới tính(1: nam/0: nữ): ");
            int sx = InputIntException();
            while (CheckSx(sx))
            {
                Console.WriteLine("Sai. Nhập lại: ");
                sx = InputIntException();
            }
            student.Sx = sx == 1 ? "Nam" : "Nữ";

            Console.Write("Nhập tuổi sinh viên: ");
            student.Age = InputIntException();
            while (!CheckAge(student.Age))
            {
                Console.Write("Sai. Nhập lại: ");
                student.Age = InputIntException();
            }

            Console.Write("Nhập điểm toán: ");
            student.MathScore = InputDoubleException();

            Console.Write("Nhập điểm lý: ");
            student.PhisicalScore = InputDoubleException();

            Console.Write("Nhập điểm hóa: ");
            student.ChemistryScore = InputDoubleException();

            student.AvgScore = CalAvgScore(student);

            student.Academic = SetAcedemic(student.AvgScore);

            return student;
        }

        /// <summary>
        /// Kiểm tra giá trị tuổi nhập vào
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public bool CheckAge(int age)
        {
            return age >= 18 && age <= 100 ? true : false;
        }

        /// <summary>
        /// Kiểm tra giá trị nhập vào
        /// </summary>
        /// <param name="sx"></param>
        /// <returns></returns>
        public bool CheckSx(int sx)
        {
            if (sx == 1 || sx == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu số nguyên nhập vào
        /// </summary>
        /// <returns></returns>
        public int InputIntException()
        {
            dynamic tmp = Console.ReadLine();
            while (!int.TryParse(tmp, out int value))
            {
                Console.Write("Sai. Nhập lại: ");
                tmp = Console.ReadLine();
            }
            return int.Parse(tmp);
        }

        /// <summary>
        /// Kiểm tra dữ liệu kiểu double
        /// </summary>
        /// <returns></returns>
        public double InputDoubleException()
        {
            dynamic tmp = Console.ReadLine();
            while (!double.TryParse(tmp, out double value))
            {
                Console.Write("Sai. Nhập lại: ");
                tmp = Console.ReadLine();
            }
            tmp = double.Parse(tmp);
            if (tmp < 0 || tmp > 10)
            {
                Console.Write("Sai. Nhập lại(0-10):");
                tmp = InputDoubleException();
            }
            return tmp;
        }

        /// <summary>
        /// Tính điểm trung bình
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public double CalAvgScore(Student s)
        {
            return Math.Round(((s.MathScore + s.PhisicalScore + s.ChemistryScore) / 3), 2);
        }

        /// <summary>
        /// Id tự động tăng
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int IdStudentAutoIncreased(List<Student> students)
        {
            int idMax = students.Max(s => s.Id);
            return idMax + 1;
        }

        /// <summary>
        /// Nhập 1 list sinh viên
        /// </summary>
        /// <returns></returns>
        public List<Student> InputListStudent(List<Student> students)
        {
            Console.WriteLine("Nhập số lượng sinh viên: ");
            int size = InputIntException();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                students.Add(InputStudent(students));
            }
            return students;
        }

        /// <summary>
        /// Hiện list sinh viên
        /// </summary>
        public void ShowListStudent(List<Student> students)
        {
            Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, -4} {4, -4} {5, -4} {6, -4} {7, -4} {8, -10}", "ID", "Họ tên", "GT", "Tuổi", "Toán", "Lý", "Hóa", "GPA", "Học lực");
            foreach (Student s in students)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, -4} {4, -4} {5, -4} {6, -4} {7, -4} {8, -10}", s.Id, s.Name, s.Sx, s.Age, s.MathScore, s.PhisicalScore, s.ChemistryScore, s.AvgScore, s.Academic);
            }
        }

        /// <summary>
        /// Cập nhật thông tin sinh viên bởi ID
        /// </summary>
        public void UpdateStudentsById(List<Student> students)
        {
            Console.WriteLine("Nhập id sinh viên: ");
            int id = InputIntException();

            Student student = students.Find(s => s.Id == id);

            if (student != null)
            {
                MenuUpdate(student);

                student.AvgScore = CalAvgScore(student);

                student.Academic = SetAcedemic(student.AvgScore);

                Console.WriteLine("Cập nhật thông tin thành công!");
            }
            else
            {
                Console.WriteLine($"Sinh viên có id = {id} không tồn tại trong danh sách.");
            }
        }

        /// <summary>
        /// Set học lực dựa trên điểm trung bình
        /// </summary>
        /// <param name="gpa"></param>
        /// <returns></returns>
        public string SetAcedemic(double gpa)
        {
            if (gpa >= 8)
            {
                return "Giỏi";
            }
            else if (gpa >= 6.5)
            {
                return "Khá";
            }
            else if (gpa >= 5)
            {
                return "Trung bình";
            }
            else
            {
                return "Yếu";
            }
        }

        /// <summary>
        /// Xóa sinh viên bởi ID.
        /// </summary>
        public void DeleteStudentById(List<Student> students)
        {
            Console.WriteLine("Nhập id sinh viên: ");
            int id = InputIntException();
            if (students.Find(s => s.Id == id) != null)
            {
                if (ConfirmDelete(id))
                {
                    students.RemoveAll(s => s.Id == id);
                    Console.WriteLine($"Đã xóa sinh viên có id = {id} khỏi danh sách.");
                }
                else
                {
                    Console.WriteLine("Đã hủy thao tác xóa.");
                }
            }
            else
            {
                Console.WriteLine($"Sinh viên có id = {id} không tồn tại trong danh sách.");
            }
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo tên
        /// </summary>
        public void FindStudentByName(List<Student> students)
        {
            Console.WriteLine("Nhập tên sinh viên: ");
            string name = Console.ReadLine();
            while (name == "")
            {

                Console.Write("Sai. Nhập lại: ");
                name = Console.ReadLine();
            }

            List<Student> tmp = students.FindAll(s => s.Name == name);
            if (tmp.Count != 0)
            {
                ShowListStudent(tmp);
            }
            else
            {
                Console.WriteLine($"Không có sinh viên nào tên {name}.");
            }

        }

        /// <summary>
        /// Sắp xếp sinh viên theo điểm trung bình (GPA).
        /// </summary>
        public void SortStudentsByGPA(List<Student> students)
        {
            students.Sort((s, s1) =>
            {
                if (s1.AvgScore < s.AvgScore)
                {
                    return -1;
                }
                else if (s.AvgScore < s1.AvgScore)
                {
                    return 1;
                }
                return 0;
            });
        }

        /// <summary>
        /// Sắp xếp sinh viên theo tên.
        /// </summary>
        public void SortStudentsByName(List<Student> students)
        {
            students.Sort((s, s1) =>
            {
                if (string.Compare(GetNameStudent(s.Name), GetNameStudent(s1.Name)) < 0)
                {
                    return -1;
                }
                else if (string.Compare(GetNameStudent(s.Name), GetNameStudent(s1.Name)) > 0)
                {
                    return 1;
                }
                return 0;
            });
        }

        /// <summary>
        /// Lấy tên sinh viên
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public string GetNameStudent(string fullName)
        {
            return fullName.Split(" ")[fullName.Split(" ").Length - 1];
        }

        /// <summary>
        /// Sắp xếp sinh viên theo ID.
        /// </summary>
        public void SortStudentsById(List<Student> students)
        {
            students.Sort((s, s1) =>
            {
                if (s1.Id > s.Id)
                {
                    return -1;
                }
                else if (s.Id > s1.Id)
                {
                    return 1;
                }
                return 0;
            });
        }

        /// <summary>
        /// Menu cập nhập sinh viên
        /// </summary>
        /// <param name="student"></param>
        public void MenuUpdate(Student student)
        {
            Console.WriteLine("Chọn thông tin bạn muốn cập nhật: ");
            Console.WriteLine("1. Tên     2. Giới tính     3. Tuổi     4. Điểm Toán     5. Điểm Lý      6. Điểm Hóa     0. Thoát");
            Console.WriteLine("Mời chọn...");
            int choose = InputIntException();
            switch (choose)
            {
                case 0: break;
                case 1:
                    Console.WriteLine("Nhập tên sinh viên: ");
                    string name = Console.ReadLine();
                    if (name != "")
                    {
                        student.Name = name;
                    }
                    Console.WriteLine("Đã cập nhật!");
                    MenuUpdate(student);
                    break;
                case 2:
                    Console.Write("Nhập giới tính(1: nam/ 0: nữ): ");
                    int sx = InputIntException();
                    while (CheckSx(sx))
                    {
                        Console.WriteLine("Sai. Nhập lại: ");
                        sx = InputIntException();
                    }
                    student.Sx = sx == 0 ? "Nữ" : "Nam";
                    Console.WriteLine("Đã cập nhật!");
                    MenuUpdate(student);
                    break;
                case 3:
                    Console.WriteLine("Nhập tuổi sinh viên: ");
                    string age = Console.ReadLine();
                    if (age != "")
                    {
                        while (!int.TryParse(age, out int value))
                        {
                            Console.Write("Sai. Nhập lại: ");
                            age = Console.ReadLine();
                        }
                        student.Age = int.Parse(age);
                        while (!CheckAge(student.Age))
                        {
                            Console.Write("Sai. Nhập lại: ");
                            student.Age = InputIntException();
                        }

                    }
                    Console.WriteLine("Đã cập nhật!");
                    MenuUpdate(student);
                    break;
                case 4:
                    Console.WriteLine("Nhập điểm toán: ");
                    string math = Console.ReadLine();
                    if (math != "")
                    {
                        while (!double.TryParse(math, out double value))
                        {
                            Console.Write("Sai. Nhập lại: ");
                            math = Console.ReadLine();
                        }
                        student.MathScore = double.Parse(math);
                    }
                    Console.WriteLine("Đã cập nhật!");
                    MenuUpdate(student);
                    break;
                case 5:
                    Console.WriteLine("Nhập điểm lý: ");
                    string phisical = Console.ReadLine();
                    if (phisical != "")
                    {
                        while (!double.TryParse(phisical, out double value))
                        {
                            Console.Write("Sai. Nhập lại: ");
                            phisical = Console.ReadLine();
                        }
                        student.PhisicalScore = double.Parse(phisical);
                    }
                    Console.WriteLine("Đã cập nhật!");
                    MenuUpdate(student);
                    break;
                case 6:
                    Console.WriteLine("Nhập điểm hóa: ");
                    string chemistry = Console.ReadLine();
                    if (chemistry != "")
                    {
                        while (!double.TryParse(chemistry, out double value))
                        {
                            Console.Write("Sai. Nhập lại: ");
                            chemistry = Console.ReadLine();
                        }
                        student.ChemistryScore = double.Parse(chemistry);
                    }
                    Console.WriteLine("Đã cập nhật!");
                    MenuUpdate(student);
                    break;
                default: MenuUpdate(student); break;
            }
        }

        /// <summary>
        /// Xác nhận việc xóa sinh viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ConfirmDelete(int id)
        {
            Console.WriteLine($"Xác nhận xóa sinh viên id = {id}? \n1. Đồng ý   0. Hủy");
            int choose = InputIntException();
            while (CheckSx(choose))
            {
                Console.Write("Sai. Nhập lại: ");
                choose = InputIntException();
            }
            return choose == 0 ? false : true;
        }
    }

}
