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
            student.Id = students.Count != 0 ? IdStudentAutoIncreased(students) : 0;
            Console.WriteLine("Nhập tên sinh viên: ");
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
            
            Console.WriteLine("Nhập tuổi sinh viên: ");
            student.Age = InputIntException();
            Console.WriteLine("Nhập điểm toán: ");
            student.MathScore = InputDoubleException();
            Console.WriteLine("Nhập điểm lý: ");
            student.PhisicalScore = InputDoubleException();
            Console.WriteLine("Nhập điểm hóa: ");
            student.ChemistryScore = InputDoubleException();
            student.AvgScore = CalAvgScore(student);
            if (student.AvgScore >= 8)
            {
                student.Academic = "Giỏi";
            }
            else if (student.AvgScore >= 6.5)
            {
                student.Academic = "Khá";
            }
            else if (student.AvgScore >= 5)
            {
                student.Academic = "Trung bình";
            }
            else
            {
                student.Academic = "Yếu";
            }
            return student;
        }
        /// <summary>
        /// Kiểm tra giá trị nhập vào
        /// </summary>
        /// <param name="sx"></param>
        /// <returns></returns>
        public bool CheckSx(int sx)
        {
            if(sx==1||sx==0)
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
            return Math.Round(((s.MathScore + s.PhisicalScore + s.ChemistryScore) / 3),2);
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
                Console.WriteLine("Ấn enter để bỏ qua những trường không muốn thay đổi");
                Console.WriteLine("Nhập tên sinh viên: ");
                string name = Console.ReadLine();
                if (name != "")
                {
                    student.Name = name;
                }
                Console.Write("Nhập giới tính(1: nam/ 0: nữ): ");
                int sx = InputIntException();
                while (CheckSx(sx))
                {
                    Console.WriteLine("Sai. Nhập lại: ");
                    sx = InputIntException();
                }
                student.Sx = sx == 0 ? "Nữ" : "Nam";
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
                }
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
                student.AvgScore = CalAvgScore(student);
                if (student.AvgScore >= 8)
                {
                    student.Academic = "Giỏi";
                }
                else if (student.AvgScore >= 6.5)
                {
                    student.Academic = "Khá";
                }
                else if (student.AvgScore >= 5)
                {
                    student.Academic = "Trung bình";
                }
                else
                {
                    student.Academic = "Yếu";
                }
                Console.WriteLine("Cập nhật thông tin thành công!");
            }
            else
            {
                Console.WriteLine($"Sinh viên có id = {id} không tồn tại trong danh sách.");
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
                students.RemoveAll(s => s.Id == id);
                Console.WriteLine($"Đã xóa sinh viên có id = {id} khỏi danh sách.");
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
            ShowListStudent(students.FindAll(s => s.Name == name));
        }
        /// <summary>
        /// Sắp xếp sinh viên theo điểm trung bình (GPA).
        /// </summary>
        public void SortStudentsByGPA(List<Student> students)
        {
            students.Sort((s, s1) =>
            {
                if (s1.AvgScore > s.AvgScore)
                {
                    return -1;
                }
                else if (s.AvgScore > s1.AvgScore)
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
                if (string.Compare(s.Name, s1.Name) > 0)
                {
                    return -1;
                }
                else if (string.Compare(s.Name, s1.Name) < 0)
                {
                    return 1;
                }
                return 0;
            });
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
    }

}
