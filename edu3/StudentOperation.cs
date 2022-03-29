using System;
using System.Collections.Generic;
using System.Linq;
using static edu3.Student;
//using static edu3.Student.Academics;
//using static edu3.Student.Semester;
//using static edu3.Student.Semester.Subject;

namespace edu3
{

    /// <summary>
    /// creating a seperate class for all methods to be used
    /// </summary>
    /// 
    public  class StudentOperation
    {
        /// <summary>
        /// Declare a list of type students 
        /// </summary>
        public static List<Student> AllStudents = new List<Student>();
  

        #region EnterStudentDetails method
        /// <summary>
        /// create a method to Enter the student details
        /// Taking inputs as student details from user and Validating them using validation methods declared in validation
        /// </summary>
        public static void EnterStudentDetails()
        {
            bool EndAdding = false;
            bool Continue_AcaDet_Adding = true;
            while (!EndAdding)
            {
                try
                {
                    //creating instance of student class and validation class
                    Student Studenti = new Student();
                    Studenti.Semesters = new List<Semester>();

                    Validation re = new Validation();


                restart11:
                    Console.WriteLine(ModelStatements.Enter_Name);
                    Studenti.Name = Console.ReadLine().Trim();
                    List<Student> Y = AllStudents.FindAll(std => std.Name == Studenti.Name);
                    //condition to validate duplication of input Names
                    if (Y.Count != 0)
                    {
                        Console.WriteLine(ModelStatements.Duplicate_Name_Entry);
                        goto restart11;
                    }
                    //Validate user input name
                    bool ValidName = re.ValidateName(Studenti.Name);
                    while (!ValidName)
                    {
                        Console.WriteLine(ModelStatements.Invalid_Name_validation_statement);
                        goto restart11;
                    }
                restart112:
                    Console.WriteLine(ModelStatements.Enter_ID);
                    Studenti.ID = Console.ReadLine().Trim();
                    List<Student> X = AllStudents.FindAll(std => std.ID == Studenti.ID);
                    //condition to validate duplication of input IDs
                    if (X.Count != 0)
                    {
                        Console.WriteLine(ModelStatements.Duplicate_ID_Entry);
                        goto restart112;
                    }
                    //Validate user input ID
                    bool ValidID = re.ValidateID(Studenti.ID);
                    while (!ValidID)
                    {
                        Console.WriteLine(ModelStatements.Invalid_ID_validation_statement);
                        goto restart112;
                    }
                restart13:
                    //User branch Input
                    Console.WriteLine(ModelStatements.Enter_Branch);
                    Studenti.Branch = Console.ReadLine().Trim();
                    //Validate User input Branch
                    bool ValidBranch = re.ValidateBranch(Studenti.Branch);
                    while (!ValidBranch)
                    {
                        Console.WriteLine(ModelStatements.Invalid_Branch_validation_statement);
                        goto restart13;
                    }
                restart14:
                    Console.WriteLine(ModelStatements.Enter_Gender);
                    Studenti.Gender = Console.ReadLine().Trim();
                    //Validate User input Gender 
                    bool ValidGender = re.ValidateGender(Studenti.Gender);
                    while (!ValidGender)
                    {
                        Console.WriteLine(ModelStatements.Invalid_Gender_validation_statement);
                        goto restart14;
                    }

                    Console.WriteLine("\n\tPersonal details of the student updated succesfully");
                        //Asking User to continue with adding Students adacemic details
                        Console.WriteLine(ModelStatements.Ask_To_Add_AcaDet_continue_close_staement);
                        Console.WriteLine("\n\tAdding Students academic details is 'Recommended'\n\tIf you choose not to,you will not be able to access the features related to students academics details");
                        if (Console.ReadLine() != "n") Continue_AcaDet_Adding = false;
                        Console.WriteLine("\n");
                        if (Continue_AcaDet_Adding == true)
                        {
                            int CurSem;
                        Restart_Cur_Sem:
                        List<Semester> Semesters = new List<Semester>();

                        try
                        {
                                //User Input for Students current Semester
                                Console.WriteLine(ModelStatements.Enter_Cur_sem);
                                CurSem = int.Parse(Console.ReadLine());
                                if (CurSem > 0 && CurSem <= 12)
                                {
                                    //For loop to create and populate the Details previous Semesters and Current Semesters
                                    for (int i = 1; i <= CurSem; i++)
                                    {
                                    //new Semester referance variable
                                    Semester Semesteri = new Semester();
                                    Semesteri.Subjects = new List<Subject>();
                                    //Assign Semester Number as its Unique property
                                    Semesteri.SemNum = i;
                                Restart_Num_Subj:
                                    List<Subject> Subjects = new List<Subject>();
                                    
                                        try
                                        {
                                            bool EndAddingAcaDet = false;
                                            int WCount=0;
                                            while (!EndAddingAcaDet)
                                            {
                                            restartSubName:
                                                //New Subject referance Variable
                                                Subject Subjectj = new Subject();
                                           
                                                Console.WriteLine(ModelStatements.Enter_SubjName, i);
                                                Subjectj.SubName = Console.ReadLine().Trim();
                                                //Checking For Duplicate Name Entry
                                                List<Subject> SN = Subjects.FindAll(sbj => sbj.SubName == Subjectj.SubName);
                                                if (SN.Count != 0)
                                                {
                                                Console.WriteLine(ModelStatements.Duplicate_SubName_Entry);
                                                goto restartSubName;
                                                }
                                                // Validate user input Name 
                                                bool ValidSubName = re.ValidateSubName(Subjectj.SubName);
                                                if (!ValidSubName)
                                                {
                                                    Console.WriteLine(ModelStatements.Invalid_SubName_validation_statement);
                                                    goto restartSubName;
                                                }

                                            restartSubMarks:
                                                Console.WriteLine(ModelStatements.Enter_SubjMarks, i);
                                                Subjectj.Marks = Console.ReadLine();
                                                // Validate user input ID
                                                bool ValidSubMarks = re.ValidateSubMarks(Subjectj.Marks);
                                                if(!ValidSubMarks)
                                                {
                                                    Console.WriteLine(ModelStatements.Invalid_SubMarks_validation_statement);
                                                    goto restartSubMarks;
                                                }
                                                Subjectj.DMarks = Convert.ToDecimal(Subjectj.Marks);
                                                //Add the Subject to the Subjects List
                                                Subjects.Add(Subjectj);
                                            //Dictionary<String, Subject> DictSubject = Subjects.ToDictionary(Sub=> Semesti.SemNum, Sem => Semesteri);

                                            ++WCount;
                                                Console.WriteLine("\n\tDetails of the Subject of Semester{0} of the student updated succesfully",Semesteri.SemNum);
                                                Console.WriteLine(ModelStatements.Adding_Subj_continue_close_staement, i);
                                                if (Console.ReadLine()!= "n") EndAddingAcaDet = true;
                                                Console.WriteLine("\n");
                                            }
                                            Semesteri.SubCount = WCount;
                                            Semesteri.Subjects.AddRange(Subjects);

                                        }
                                        catch (Exception eS)
                                        {
                                            Console.WriteLine(ModelStatements.Exception_Statement, eS.Message);
                                            goto Restart_Num_Subj;
                                        }
                                    //Add Semester to the Semesters List1

                                    Semesters.Add(Semesteri);

                                    //Dictionary<int, Semester> DictSemester = Semesters.ToDictionary(Sem => Semesteri.SemNum, Sem => Semesteri);

                                        Console.WriteLine("\n\tDetails of all the subjects in Semester{0} added Successfully", i);
                                    }
                                    Studenti.Semesters.AddRange(Semesters);
                                }
                                else
                                {
                                    Console.Write("\tYour Input current semester is out of Range\n\tPlease enter the Valid input");
                                    goto Restart_Cur_Sem;
                                }
                            }
                            catch (Exception eA)
                            {
                                Console.WriteLine(ModelStatements.Exception_Statement, eA.Message);
                                goto Restart_Cur_Sem;
                            }
                        }
                //Add student to the All Students List
                AllStudents.Add(Studenti);
                  //Dictionary<string, Student> DictStudents = AllStudents.ToDictionary(Std => Studenti.ID, Std => Studenti);
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ModelStatements.Exception_Statement, ee.Message);

                }
                Console.WriteLine("\n\tDetails of the student updated succesfully");
                Console.WriteLine(ModelStatements.Adding_std_continue_close_staement);
                if (Console.ReadLine() != "n") EndAdding = true;
                Console.WriteLine("\n");
            }
        }
        #endregion
        #region GetStudentDetails Method
        /// <summary>
        ///Creating a method to Get student details
        ///switch statement-based on type of information user wants to access
        /// </summary>
        public static void GetStudentDetails()
        {
          
            bool EndGetting = false;
            while (!EndGetting)
            {
                //new Referance variable of validation class
                Validation re_g = new Validation();
                int UserChoice2 = -1;
                do
                {
                    //USer choice based on information user wants to access
                    Console.WriteLine(ModelStatements.Get_std_Userchoice_statement);
                    UserChoice2 = int.Parse(Console.ReadLine());
                    switch (UserChoice2)
                    {
                        //For Details of all students
                        case 1:
                            if (AllStudents.Count != 0)
                            {
                                foreach (Student S in AllStudents)
                                {
                                    Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n\tThere are no students in the list");
                            }
                            break;
                        //for details students based on gender
                        case 2:
                            int SearchByGen = -1;
                            bool EndGetGen = false;
                            while (!EndGetGen)
                            {
                                do
                                {
                                    RestartGenBy:
                                    try
                                    {
                                        //Details of list of Female students
                                        Console.WriteLine(ModelStatements.Gender_choice_statement);
                                        SearchByGen = int.Parse(Console.ReadLine());
                                        if (SearchByGen == 1)
                                        {
                                            List<Student> MSL = AllStudents.FindAll(std => std.Gender == "Male");
                                            if (MSL.Count != 0)
                                            {
                                                foreach (Student S in MSL)
                                                {
                                                    Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_Male);
                                            }

                                        }
                                        //Details of list of Female students
                                        else if (SearchByGen == 2)
                                        {
                                            List<Student> FSL = AllStudents.FindAll(std => std.Gender == "Female");
                                            if (FSL.Count != 0)
                                            {
                                                foreach (Student S in FSL)
                                                {
                                                    Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_Female);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(ModelStatements.Invalid_statement);
                                        }
                                    }
                                    catch (Exception geSearchByGen)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, geSearchByGen.Message);
                                        goto RestartGenBy;
                                    }
                                } while (SearchByGen != 1 && SearchByGen != 2);
                                Console.WriteLine(ModelStatements.Get_Gen_std_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetGen = true;
                                Console.WriteLine("\n");
                            }
                            break;
                        case 3:
                            //for details of students based on there branch
                            int SearchByBranch = -1;
                            bool EndGetBranch = false;
                            while (!EndGetBranch)
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine(ModelStatements.Branch_choice_statement2);
                                        SearchByBranch = int.Parse(Console.ReadLine());
                                        //Mechanical Department Students details
                                        if (SearchByBranch == 1)
                                        {
                                            
                                            List<Student> MESL = AllStudents.FindAll(std => std.Branch == "ME");
                                            if (MESL.Count != 0)
                                            {
                                                foreach (Student S in MESL)
                                                {
                                                    Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_ME);
                                            }
                                        }
                                        //Electronics Department Students details
                                        else if (SearchByBranch == 2)
                                        {
                                            List<Student> ECSL = AllStudents.FindAll(std => std.Branch == "ECE");
                                            if (ECSL.Count != 0)
                                            {
                                                foreach (Student S in ECSL)
                                                {
                                                    Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_ECE);
                                            }
                                        }
                                        //Computers Science Department Students details
                                        else if (SearchByBranch == 3)
                                        {
                                            List<Student> CSSL = AllStudents.FindAll(std => std.Branch == "CSE");
                                            if (CSSL.Count != 0)
                                            {
                                                foreach (Student S in CSSL)
                                                {
                                                    Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_CSE);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(ModelStatements.Invalid_statement);
                                        }
                                    }
                                    catch (Exception beSearchByGen)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, beSearchByGen.Message);
                                    }
                                } while (SearchByBranch != 1 && SearchByBranch != 2 && SearchByBranch != 3);
                                Console.WriteLine(ModelStatements.Get_Branch_std_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetBranch = true;
                                Console.WriteLine("\n");
                            }
                            break;
                        case 4:
                            //Details of particular student
                            int SearchByChoice = -1;
                            bool EndGetName_ID = false;
                            while (!EndGetName_ID)
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine(ModelStatements.Searchby_Name_Or_ID_statement);
                                        SearchByChoice = int.Parse(Console.ReadLine());
                                        //Based in Name
                                        if (SearchByChoice == 1)
                                        {
                                            bool EndGetting_ByName = false;
                                            while (!EndGetting_ByName)
                                            {
                                            restartSBC1:
                                                Console.WriteLine(ModelStatements.Enter_Name);
                                                string IpName = Console.ReadLine();
                                                bool ValidName = re_g.ValidateName(IpName);
                                                while (!ValidName)
                                                {
                                                    Console.WriteLine(ModelStatements.Invalid_Name_validation_statement);
                                                    goto restartSBC1;
                                                }
                                                List<Student> NL = AllStudents.FindAll(std => std.Name == IpName);
                                                if (NL.Count != 0)
                                                {
                                                    foreach (Student S in NL)
                                                    {
                                                        Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ModelStatements.No_Student_ID, IpName);
                                                }
                                                Console.WriteLine(ModelStatements.Get_Std_ByName_continue_close_statement);
                                                if (Console.ReadLine() != "n") EndGetting_ByName = true;
                                                Console.WriteLine("\n");
                                            }
                                        }
                                        //Based on ID
                                        else if (SearchByChoice == 2)
                                        {
                                            bool EndGetting_ByID = false;
                                            while (!EndGetting_ByID)
                                            {
                                            restartSBC2:
                                                Console.WriteLine(ModelStatements.Enter_ID);
                                                string IpID = Console.ReadLine();
                                                bool ValidID = re_g.ValidateID(IpID);
                                                while (!ValidID)
                                                {
                                                    Console.WriteLine(ModelStatements.Invalid_ID_validation_statement);
                                                    goto restartSBC2;
                                                }
                                                List<Student> IDL = AllStudents.FindAll(std => std.ID == IpID);
                                                if (IDL.Count != 0)
                                                {
                                                    foreach (Student S in IDL)
                                                    {
                                                        Console.WriteLine(ModelStatements.Print_details_statement, S.Name, S.ID, S.Branch, S.Gender);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ModelStatements.No_Student_ID, IpID);
                                                }
                                                Console.WriteLine(ModelStatements.Get_Std_ByID_continue_close_statement);
                                                if (Console.ReadLine() != "n") EndGetting_ByID = true;
                                                Console.WriteLine("\n");
                                            }
                                        }
                                        else if (SearchByChoice > 2)
                                        {
                                            Console.WriteLine(ModelStatements.Invalid_statement);
                                        }
                                    }
                                    catch (Exception eSearchBychoice)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eSearchBychoice.Message);
                                    }
                                } while (SearchByChoice != 1 && SearchByChoice != 2);
                                Console.WriteLine(ModelStatements.Get_Name_ID_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetName_ID = true;
                                Console.WriteLine("\n");
                            }
                            break;
                        default:
                            {
                                Console.WriteLine(ModelStatements.Invalid_statement);
                            }
                            break;
                    }
                } while (UserChoice2 != 1 && UserChoice2 != 2 && UserChoice2 != 3 && UserChoice2 != 4);
                Console.WriteLine(ModelStatements.Get_Std_continue_close_statement);
                if (Console.ReadLine() != "n") EndGetting = true;
                Console.WriteLine("\n");
            }
        }
        #endregion
        #region GetResults Method
        /// <summary>
        /// Method to Get the academic details of the students
        /// Display the Marks obtained and Result
        /// </summary>

        public static void GetResults()
        {
            bool EndGetResults = false;
            while (!EndGetResults)
            {

            Restartx:
                try
                {
                    Console.WriteLine(ModelStatements.Get_std_Res_Userchoice_statement);
                    int UserChoice = int.Parse(Console.ReadLine());
                    switch (UserChoice)
                    {
                        case 1:
                            if (AllStudents.Count > 0)
                            {
                                var i = 0;
                                var j = 0;
                                foreach (Student s in AllStudents)
                                {
                                    Console.WriteLine("Name:{0}     ID:{1}", s.Name, s.ID);
                                    //List<Semester> semis = Semesters.FindAll(se=>se.SemNum);
                                    foreach(Semester Sem in s.Semesters)
                                    {
                                        
                                        Console.WriteLine("Semester={0}",Sem.SemNum);
                                        {
                                            foreach(Subject sub in Sem.Subjects)
                                            {
                                                Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);

                                            }
                                        }
                                    }
                                    Console.WriteLine("************************************************************");

                                }

                            }
                            else
                            {
                                Console.WriteLine("There are no students in the list ");
                            }
                            break;                        
                        default:
                            Console.WriteLine(ModelStatements.Invalid_statement);
                            goto Restartx;
                    }

                }
                catch (Exception eg)
                {
                    Console.WriteLine(ModelStatements.Exception_Statement, eg.Message);
                }
                Console.WriteLine(ModelStatements.Get_Result_continue_close_statement);
                if (Console.ReadLine() != "n") EndGetResults = true;
                Console.WriteLine("\n");
            }
        }
        #endregion
        #region SemTotal Method
        public static decimal SemTotal(decimal[] arr1)
        {
            decimal total = 0;
            for (int l = 0; l < arr1.Length; l++)
                total += arr1[l];
            return total;

        }
        #endregion

        #region DeleteStudent Method
        /// <summary>
        /// Method to delete the student from the list
        /// user can delete a student based on information he possess(Name or ID)
        /// </summary>
        public static void DeleteStudent()
        {
            Validation rex = new Validation();

            int SearchByChoice1;
            bool EndDelete = false;
            while (!EndDelete)
            {
                do
                {
                Restart_searchby_Delete_method:
                    //User choice Based delete Operation by Student Name or ID
                    Console.WriteLine(ModelStatements.Searchby_Name_Or_ID_statement_Delete);
                    SearchByChoice1 = int.Parse(Console.ReadLine());
                    //Deleting Student from the list based on Students Name
                    if (SearchByChoice1 == 1)
                    {
                        bool EndDel_byName = false;
                        while (!EndDel_byName)
                        {
                            restartSBC3:
                            Console.WriteLine(ModelStatements.Enter_Name);
                            string IpName = Console.ReadLine();
                            bool ValidName=rex.ValidateName(IpName);
                            if (!ValidName)
                            {
                                Console.WriteLine(ModelStatements.Invalid_ID_validation_statement);
                                goto restartSBC3;
                            }
                            List<Student> NL = AllStudents.FindAll(std => std.Name == IpName);
                            if (NL.Count != 0)
                            {
                                foreach (Student S in NL)
                                {
                                    Console.WriteLine("Student {0} (ID:{1}) Deleted successfully", S.Name, S.ID);
                                    AllStudents.Remove(S);
                                }
                            }
                            else
                            {
                                Console.WriteLine(ModelStatements.No_Student_Name, IpName);
                            }
                            Console.WriteLine(ModelStatements.Del_ByName_continue_close_statement);
                            if (Console.ReadLine() != "n") EndDel_byName = true;
                            Console.WriteLine("\n");
                        }
                    }
                    //Deleting Student from the list based on Students ID

                    else if (SearchByChoice1 == 2)
                    {
                        bool EndDel_byID = false;
                        while (!EndDel_byID)
                        {
                            restartSBC4:
                            Console.WriteLine(ModelStatements.Enter_ID);
                            string IpID = Console.ReadLine();
                            bool ValidID = rex.ValidateID(IpID);
                            if (!ValidID)
                            {
                                Console.WriteLine(ModelStatements.Invalid_ID_validation_statement);
                                goto restartSBC4;
                            }
                            List<Student> IDL = AllStudents.FindAll(std => std.ID == IpID);
                            if (IDL.Count!= 0)
                            {
                                foreach (Student S in IDL)
                                {
                                    Console.WriteLine("Student with ID:{0} (Name:{1}) deleted successfully", S.ID, S.Name);
                                    AllStudents.Remove(S);
                                }
                            }
                            else
                            {
                                Console.WriteLine(ModelStatements.No_Student_ID, IpID);
                            }
                            Console.WriteLine(ModelStatements.Del_ByID_continue_close_statement);
                            if (Console.ReadLine() != "n") EndDel_byID = true;
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine(ModelStatements.Invalid_statement);
                        goto Restart_searchby_Delete_method;
                    }
                } while (SearchByChoice1 != 1 && SearchByChoice1 != 2);
                Console.WriteLine(ModelStatements.Get_Std_continue_close_statement);
                if (Console.ReadLine() != "n") EndDelete = true;
                Console.WriteLine("\n");
            }
        }
        #endregion
    }
}