
using System;
using System.Collections.Generic;
//using static edu3.Student.Academics;

namespace edu3
{
    //Declaration of Student Class
    public class Student
    {
        //declaration and Implimentation of Student properties
        public String Name { get; set; }
        public String ID { get; set; }
        public String Branch { get; set; }
        public String Gender { get; set; }
        public List<Semester> Semesters { get; set; }
        //Student class's inner semester class

    }

    public class Semester
    {
        public int SemNum { get; set; }
        public List<Subject> Subjects { get; set; }
        public int SubCount { get; set; }
        public decimal SemResult { get; set; }
        //Semester class's inner Subject class

    }

    public class Subject
    {
        public String SubName;
        public string Marks;
        public decimal DMarks { get; set; }
    }
}
