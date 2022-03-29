
using System;
using System.Collections.Generic;
//using static edu3.Student.Academics;

namespace edu3
{
    //Declaration of Student Class
    public class Student
    {
        //declaration and Implimentation of Student properties
        public string Name { get; set; }
        public string ID { get; set; }
        public string Branch { get; set; }
        public string Gender { get; set; }
        public List<Semester> Semesters { get; set; }
        //Student class's inner semester class

    }

    public class Semester
    {
        public int SemNum { get; set; }
        public List<Subject> Subjects { get; set; }
        public int SubCount { get; set; }
        public decimal SemResult { get; set; }

        public static explicit operator Semester(List<Semester> v)
        {
            throw new NotImplementedException();
        }
        //Semester class's inner Subject class

    }

    public class Subject
    {
        public string SubName;
        public string Marks;
        public decimal DMarks { get; set; }
    }
}
