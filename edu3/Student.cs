
using System;
using System.Collections.Generic;
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
}
