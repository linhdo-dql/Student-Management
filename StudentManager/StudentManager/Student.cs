using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager
{
    class Student
    {  
        /// <summary>
        /// Id sinh viên
        /// </summary>
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Tên sinh viên
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Giới tính sinh viên
        /// </summary>
        private string _sx;

        public string Sx
        {
            get { return _sx; }
            set { _sx = value; }
        }

        /// <summary>
        /// Tuổi sinh viên
        /// </summary>
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        /// <summary>
        /// Điểm toán
        /// </summary>
        private double _mathScore;

        public double MathScore
        {
            get { return _mathScore; }
            set { _mathScore = value; }
        }
        
        /// <summary>
        /// Điểm lý
        /// </summary>
        private double _phisicalScore;

        public double PhisicalScore
        {
            get { return _phisicalScore; }
            set { _phisicalScore = value; }
        }

        /// <summary>
        /// Điểm hóa
        /// </summary>
        private double _chemistryScore;

        public double ChemistryScore
        {
            get { return _chemistryScore; }
            set { _chemistryScore = value; }
        }

        /// <summary>
        /// Điểm trung bình
        /// </summary>
        public double _avgScore;

        public double AvgScore
        {
            get { return _avgScore; }
            set { _avgScore = value; }
        }

        /// <summary>
        /// Học lực
        /// </summary>
        private string _academic;

        public string Academic
        {
            get { return _academic; }
            set { _academic = value; }
        }

    }
}
