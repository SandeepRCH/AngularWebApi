using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int SchoolCode { get; set; }
        public int Age { get; set; }
        public int NumberOfBacklogs { get; set; }
        public int YearOfStudy { get; set; }
        public int Attendence { get; set; }
        public bool IsActive { get; set; }
    }
}
