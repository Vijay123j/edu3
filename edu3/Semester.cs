using System;
using System.Collections.Generic;

namespace edu3
{
    //declare Semester class and  properties,fields of semester
    public class Semester
    {
        public int SemNum { get; set; }
        public List<Subject> Subjects { get; set; }
        public int SubCount { get; set; }
        public decimal SemResult { get; set; }
        public decimal SemTotal;
        public string Status;
        public decimal[] SemMarks;
        public Fees fees;
        

        //Semester class's inner Subject class
    }
}
