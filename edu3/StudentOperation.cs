using System;
using System.Collections.Generic;

namespace edu3
{

    /// <summary>
    /// creating a seperate class for all methods to be used
    /// </summary>
    /// 
    public class StudentOperation
    {
        /// <summary>
        /// Declare a list of type students 
        /// </summary>
        public static List<Student> AllStudents = new List<Student>();
        /// <summary>
        /// create a method to Enter the student details
        /// Taking inputs as student details from user and Validating them using validation methods declared in validation
        /// </summary>
        public static void EnterStudentDetails()
        {
            #region EnterStudentDetails method

            bool EndAdding = false;
            while (!EndAdding)
            {
                try
                {
                    bool Continue_AcaDet_Adding = true;
                    bool Continue_FeesDet_Adding = true;

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
                    if(!ValidName)
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
                    if(!ValidID)
                    {
                        Console.WriteLine(ModelStatements.Invalid_ID_validation_statement);
                        goto restart112;
                    }
               
                restart14:
                    Console.WriteLine(ModelStatements.Enter_Gender);
                    Studenti.Gender = Console.ReadLine().Trim();
                    //Validate User input Gender 
                    bool ValidGender = re.ValidateGender(Studenti.Gender);
                    if(!ValidGender)
                    {
                        Console.WriteLine(ModelStatements.Invalid_Gender_validation_statement);
                        goto restart14;
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
                                    ;
                                    //Assign Semester Number as its Unique property
                                    Semesteri.SemNum = i;
                                Restart_Num_Subj:
                                    #region Academic details
                                    List<Subject> Subjects = new List<Subject>();
                                    try
                                    {
                                        bool EndAddingAcaDet = false;
                                        int WCount = 0;
                                        int StatusCount = 0;
                                        decimal[] SemMarks = new decimal[100];
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
                                            if (!ValidSubMarks)
                                            {
                                                Console.WriteLine(ModelStatements.Invalid_SubMarks_validation_statement);
                                                goto restartSubMarks;
                                            }
                                            Subjectj.DMarks = Convert.ToDecimal(Subjectj.Marks);
                                            //Add the Subject to the Subjects List
                                            Subjects.Add(Subjectj);
                                            //Dictionary<String, Subject> DictSubject = Subjects.ToDictionary(Sub=> Semesti.SemNum, Sem => Semesteri);
                                            SemMarks[WCount] = Convert.ToDecimal(Subjectj.DMarks);
                                            ++WCount;
                                            if (Subjectj.DMarks < 35)
                                            {
                                                StatusCount++;
                                            }

                                            Console.WriteLine("\n\tDetails of the Subject of Semester{0} of the student updated succesfully", Semesteri.SemNum);
                                            Console.WriteLine(ModelStatements.Adding_Subj_continue_close_staement, i);
                                            if (Console.ReadLine() != "n") EndAddingAcaDet = true;
                                            Console.WriteLine("\n");
                                        }
                                        Console.WriteLine("\n\tDetails of all the subjects in Semester{0} added Successfully", i);
                                        #endregion 
                                        //Asking User to continue with adding Students Fees details
                                        Console.WriteLine(ModelStatements.Ask_To_Add_FeesDet_continue_close_staement);
                                        Console.WriteLine("\n\tAdding Students Fees details is 'Recommended'\n\tIf you choose not to,you will not be able to access the features related to students Fees details\n\t");
                                        if (Console.ReadLine() != "n") Continue_FeesDet_Adding = false;
                                        Console.WriteLine("\n");
                                        if(Continue_FeesDet_Adding==true)
                                        {
                                            Semesteri.fees = new Fees();
                                            bool CorrectData;
                                            do
                                            {
                                                CorrectData = true;
                                                bool correctAnnFees;
                                                do
                                                {
                                                    correctAnnFees = true;
                                                    try
                                                    {
                                                        Console.WriteLine("Enter Annual Fees of the Student with ID:{0} and Name:{1} for Semester:{2}", Studenti.ID, Studenti.Name, Semesteri.SemNum);
                                                        Semesteri.fees.Annual_Fees = Console.ReadLine();
                                                        bool ValidAnnualFees = re.Validate_Annual_fees(Semesteri.fees.Annual_Fees);
                                                        if (!ValidAnnualFees)
                                                        {
                                                            Console.WriteLine("\n\tEntered Annual Fees is invalid\n\tValid Annual fees example :20000\n\tRange-[100 to 9999999]");
                                                            correctAnnFees = false;
                                                        }
                                                        else
                                                        {
                                                            Semesteri.fees.DAnnual_Fees = Convert.ToDecimal(Semesteri.fees.Annual_Fees);
                                                        }
                                                    }
                                                    catch (Exception es)
                                                    {
                                                        Console.WriteLine(ModelStatements.Exception_Statement, es.Message);
                                                        correctAnnFees = false;
                                                    }
                                                } while (!correctAnnFees);
                                                bool CorrectAmtPaid;
                                                do
                                                {
                                                    CorrectAmtPaid = true;
                                                    try
                                                    {
                                                        Console.WriteLine("Enter Amount paid by the Student:{0} for the Year", Studenti.Name);
                                                        Semesteri.fees.Amount_Paid = Console.ReadLine();
                                                        bool ValidAmountPaid = re.Validate_Amount_Paid(Semesteri.fees.Amount_Paid);
                                                        if (!ValidAmountPaid)
                                                        {
                                                            Console.WriteLine("\n\tEntered AmountPaid is invalid\n\tValid AmountPaid example :20000\n\tRange-[100 to 9999999]");
                                                            CorrectAmtPaid = false;
                                                        }
                                                        else
                                                        {
                                                            Semesteri.fees.DAmount_Paid = Convert.ToDecimal(Semesteri.fees.Amount_Paid);

                                                        }
                                                    }
                                                    catch (Exception esl)
                                                    {
                                                        Console.WriteLine(ModelStatements.Exception_Statement, esl.Message);
                                                        CorrectAmtPaid = false;
                                                    }
                                                } while (!CorrectAmtPaid);
                                                if (Semesteri.fees.DAmount_Paid > Semesteri.fees.DAnnual_Fees)
                                                {
                                                    Console.WriteLine("Entered Amount Paid is greater than Annual tution Fees please recheck and enter the Correct input");
                                                    CorrectData = false;
                                                }
                                            } while (!CorrectData);
                                            Console.WriteLine("\n\tFees Details of the Semester{0} added Successfully", i);
                                        }

                                        Semesteri.SubCount = WCount;
                                        Semesteri.Subjects.AddRange(Subjects);
                                        Semesteri.SemResult = SemTotal(SemMarks) / Semesteri.SubCount;
                                        if (StatusCount > 0)
                                        {
                                            Semesteri.Status = "Failed";
                                        }
                                        else
                                        {
                                            Semesteri.Status ="Passed";

                                        }
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
            #endregion
        }
        /// <summary>
        ///Creating a method to Get student details
        ///switch statement-based on type of information user wants to access
        /// </summary>
        public static void GetStudentDetails()
        {
            #region GetStudentDetails Method

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
                            #region AllStudents details
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
                            #endregion
                            break;
                        //for details students based on gender
                        case 2:
                            #region Perticular Gender Student details

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
                            #endregion
                            break;
                        case 3:
                            #region Perticular Branch Student details


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
                            #endregion
                            break;
                        case 4:
                            #region Perticular Student details

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
                            #endregion
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
            #endregion
        }

        /// <summary>
        /// Method to Get the academic details of the students
        /// Displays the Marks obtained and Result
        /// </summary>
        public static void GetResults()
        {
            #region GetResults Method
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
                            #region AllStudents Results
                            if (AllStudents.Count > 0)
                            {
                                foreach (Student s in AllStudents)
                                {
                                    Console.WriteLine("Name:{0}     ID:{1}", s.Name, s.ID);
                                    if (s.Semesters.Count == 0)
                                    {
                                        Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                    }
                                    foreach (Semester Sem in s.Semesters)
                                    {
                                        
                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                        {
                                            foreach (Subject sub in Sem.Subjects)
                                            {
                                                Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                            }
                                            Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);                                           
                                        }
                                    }
                                    Console.WriteLine("************************************************************");
                                }

                            }
                            else
                            {
                                Console.WriteLine("There are no students in the list ");
                            }
                            #endregion
                            break;
                        case 2:
                            #region Perticular Gender Results
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
                                        Console.WriteLine(ModelStatements.Res_Gender_choice_statement);
                                        SearchByGen = int.Parse(Console.ReadLine());
                                        if (SearchByGen == 1)
                                        {
                                            List<Student> MSL = AllStudents.FindAll(std => std.Gender == "Male");
                                            if (MSL.Count != 0)
                                            {
                                                foreach (Student S in MSL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", S.Name, S.ID);
                                                    if (S.Semesters.Count == 0)
                                                    {
                                                        Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                                    }
                                                    foreach (Semester Sem in S.Semesters)
                                                    {
                                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                                        {
                                                            foreach (Subject sub in Sem.Subjects)
                                                            {
                                                                Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                                            }
                                                            Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);
                                                        }                                                   
                                                    }
                                                    Console.WriteLine("************************************************************");
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
                                                foreach (Student St in FSL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", St.Name, St.ID);
                                                    if (St.Semesters.Count == 0)
                                                    {
                                                        Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                                    }
                                                    foreach (Semester Sem in St.Semesters)
                                                    {                                                        
                                                            Console.WriteLine("Semester={0}", Sem.SemNum);
                                                            {
                                                                foreach (Subject sub in Sem.Subjects)
                                                                {
                                                                    Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                                                }
                                                                Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);
                                                        }                                                        
                                                    }
                                                    Console.WriteLine("************************************************************");
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
                            #endregion
                            break;
                        case 3:
                            #region Perticular Branch Results
                            int SearchByBranch = -1;
                            bool EndGetBranch = false;
                            while (!EndGetBranch)
                            {
                                do
                                {
                                RestartBranchBy:
                                    try
                                    {
                                        //Details of list of Female students
                                        Console.WriteLine(ModelStatements.Res_Branch_choice_statement2);
                                        SearchByBranch = int.Parse(Console.ReadLine());
                                        if (SearchByBranch == 1)
                                        {
                                            #region Mechanical Branch Students Results

                                            List<Student> MCSL = AllStudents.FindAll(std => std.Branch == "ME");
                                            if (MCSL.Count != 0)
                                            {
                                                foreach (Student MS in MCSL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", MS.Name, MS.ID);
                                                    if (MS.Semesters.Count == 0)
                                                    {
                                                        Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                                    }
                                                    foreach (Semester Sem in MS.Semesters)
                                                    {
                                                      Console.WriteLine("Semester={0}", Sem.SemNum);
                                                            {
                                                                foreach (Subject sub in Sem.Subjects)
                                                                {
                                                                    Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                                                }
                                                                Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);
                                                            }
                                                    }
                                                    Console.WriteLine("************************************************************");
                                                }
                                            }
                                        
                                            else
                                            {
                                                 Console.WriteLine(ModelStatements.No_Student_ME);
                                            }
                                            #endregion
                                        }
                                        //Details of list of Female students
                                        else if (SearchByBranch == 2)
                                        {
                                            #region Electronics Branch Student Results

                                            List<Student> ESL = AllStudents.FindAll(std => std.Gender == "ECE");
                                            if (ESL.Count != 0)
                                            {
                                                foreach (Student ES in ESL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", ES.Name, ES.ID);
                                                    if (ES.Semesters.Count == 0)
                                                    {
                                                        Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                                    }
                                                    foreach (Semester Sem in ES.Semesters)
                                                    {
                                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                                            {
                                                                foreach (Subject sub in Sem.Subjects)
                                                                {
                                                                    Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                                                }
                                                                Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);
                                                        }

                                                    }
                                                    Console.WriteLine("************************************************************");
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_ECE);
                                            }
                                            #endregion
                                        }
                                        else if (SearchByBranch == 3)
                                        {
                                                #region Computer Science Branch Student Results


                                                List<Student> CSL = AllStudents.FindAll(std => std.Gender == "ECE");
                                                if (CSL.Count != 0)
                                                {
                                                    foreach (Student CS in CSL)
                                                    {
                                                        Console.WriteLine("Name:{0}     ID:{1}", CS.Name, CS.ID);
                                                    if (CS.Semesters.Count == 0)
                                                    {
                                                        Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                                    }
                                                    foreach (Semester Sem in CS.Semesters)
                                                        {
                                                            
                                                            Console.WriteLine("Semester={0}", Sem.SemNum);
                                                            {
                                                                foreach (Subject sub in Sem.Subjects)
                                                                {
                                                                    Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                                                }
                                                                Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);
                                                            }
                                                        
                                                        }
                                                    Console.WriteLine("************************************************************");

                                                }
                                            }
                                                else
                                                {
                                                    Console.WriteLine(ModelStatements.No_Student_CSE);
                                                }
                                                #endregion
                                        }           
                                        else
                                        {
                                            Console.WriteLine(ModelStatements.Invalid_statement);
                                        }
                                    }
                                    catch(Exception geSearchByGen)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, geSearchByGen.Message);
                                        goto RestartBranchBy;
                                    }
                                } while (SearchByBranch != 1 && SearchByBranch != 2);
                                Console.WriteLine(ModelStatements.Res_Get_Branch_std_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetBranch = true;
                                Console.WriteLine("\n");
                            }
                            #endregion
                            break;
                        case 4:
                            #region Perticular Student's Result
                            //Details of particular student
                            Validation Re_r = new Validation();
                            int SearchByChoice = -1;
                            bool EndGetRes_Name_ID = false;
                            while (!EndGetRes_Name_ID)
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine(ModelStatements.Res_Searchby_Name_Or_ID_statement);
                                        SearchByChoice = int.Parse(Console.ReadLine());
                                        //Based in Name
                                        if (SearchByChoice == 1)
                                        {
                                            bool EndGetting_ByName = false;
                                            if(!EndGetting_ByName)
                                            {
                                            restartSBC1:
                                                Console.WriteLine(ModelStatements.Enter_Name);
                                                string IpName = Console.ReadLine();
                                                bool ValidName = Re_r.ValidateName(IpName);
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
                                                        Console.WriteLine("Name:{0}     ID:{1}", S.Name, S.ID);
                                                        if (S.Semesters.Count == 0)
                                                        {
                                                            Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                                        }
                                                        foreach (Semester Sem in S.Semesters)
                                                        {
                                                             Console.WriteLine("Semester={0}", Sem.SemNum);
                                                                {
                                                                    foreach (Subject sub in Sem.Subjects)
                                                                    {
                                                                        Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                                                    }
                                                                    Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);
                                                                }
                                                            
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ModelStatements.No_Student_ID, IpName);
                                                }
                                                Console.WriteLine(ModelStatements.Res_Get_Std_ByName_continue_close_statement);
                                                if (Console.ReadLine() != "n") EndGetting_ByName = true;
                                                Console.WriteLine("\n");
                                            }
                                        }
                                        //Based on ID
                                        else if (SearchByChoice == 2)
                                        {
                                            bool EndGetting_ByID = false;
                                            if(!EndGetting_ByID)
                                            {
                                            restartSBC2:
                                                Console.WriteLine(ModelStatements.Enter_ID);
                                                string IpID = Console.ReadLine();
                                                bool ValidID = Re_r.ValidateID(IpID);
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
                                                        Console.WriteLine("Name:{0}     ID:{1}", S.Name, S.ID);
                                                        if (S.Semesters.Count == 0)
                                                        {
                                                            Console.WriteLine("Result of the student is not Available:Please Enter academic details of the student");
                                                        }
                                                        foreach (Semester Sem in S.Semesters)
                                                        {
                                                            Console.WriteLine("Semester={0}", Sem.SemNum);
                                                            {
                                                                foreach (Subject sub in Sem.Subjects)
                                                                {
                                                                    Console.WriteLine("Subject Name:{0}     Marks:{1}", sub.SubName, sub.DMarks);
                                                                }
                                                            Console.WriteLine("Semester Result:{0:##.00}      Semester Status:{1}", Sem.SemResult, Sem.Status);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ModelStatements.No_Student_ID, IpID);
                                                }
                                                Console.WriteLine(ModelStatements.Res_Get_Std_ByID_continue_close_statement);
                                                if (Console.ReadLine() != "n") EndGetting_ByID = true;
                                                Console.WriteLine("\n");
                                            }
                                        }
                                        else if (SearchByChoice > 2 || SearchByChoice<1)
                                        {
                                            Console.WriteLine(ModelStatements.Invalid_statement);
                                        }
                                    }
                                    catch (Exception eSearchBychoice)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eSearchBychoice.Message);
                                    }
                                } while (SearchByChoice != 1 && SearchByChoice != 2);
                                Console.WriteLine(ModelStatements.Res_Get_Name_ID_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetRes_Name_ID = true;
                                Console.WriteLine("\n");
                            }
                            #endregion
                            break;
                        default:
                            Console.WriteLine(ModelStatements.Invalid_statement);
                            goto Restartx;
                    }

                }
                catch (Exception eg)
                {
                    Console.WriteLine(ModelStatements.Exception_Statement, eg.Message);
                    goto Restartx;
                }
                Console.WriteLine(ModelStatements.Get_Result_continue_close_statement);
                if (Console.ReadLine() != "n") EndGetResults = true;
                Console.WriteLine("\n");
            }
            #endregion
        }
        /// <summary>
        /// Method to calculate and return Total Marks of a Semester
        /// </summary >
        public static decimal SemTotal(decimal[] arr1)
        {
            #region SemTotal Method
            decimal total = 0;
            for (int l = 0; l < arr1.Length; l++)
                total += arr1[l];
            return total;
            #endregion
        }
        /// <summary>
        /// Method to delete the student from the list
        /// user can delete a student based on information he possess(Name or ID)
        /// </summary>
        public static void DeleteStudent()
        {
            #region DeleteStudent Method

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
                        #region Search by Name And delete student

                        bool EndDel_byName = false;
                        if(!EndDel_byName)
                        {
                        restartSBC3:
                            Console.WriteLine(ModelStatements.Enter_Name);
                            string IpName = Console.ReadLine();
                            bool ValidName = rex.ValidateName(IpName);
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
                        #endregion

                    }
                    //Deleting Student from the list based on Students ID

                    else if (SearchByChoice1 == 2)

                    {
                        #region Search by ID And delete student

                        bool EndDel_byID = false;
                        if(!EndDel_byID)
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
                            if (IDL.Count != 0)
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
                        #endregion
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
            #endregion
        }
        public static void EnterFeesDetails()
        {
           
            //Details of particular student
            Validation Re_r = new Validation();
            int SearchByChoice = -1;
            bool End_Enter_Fee_Name_ID = false;
            while (!End_Enter_Fee_Name_ID)
            {
                do
                {
                    try
                    {
                        
                        Console.WriteLine(ModelStatements.Fees_Searchby_Name_Or_ID_statement);
                        SearchByChoice = int.Parse(Console.ReadLine());
                        //Based in Name
                        if (SearchByChoice == 1)
                        {
                            #region byName
                            bool EndGetting_ByName = false;
                            while(!EndGetting_ByName)
                            {
                            restartSBC1:
                                Console.WriteLine(ModelStatements.Enter_Name);
                                string IpName = Console.ReadLine();
                                bool ValidName = Re_r.ValidateName(IpName);
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
                                        if (S.Semesters.Count != 0)
                                        {
                                            foreach (Semester Sem in S.Semesters)
                                            {
                                                Console.WriteLine(S.Semesters);
                                                Sem.fees = new Fees();
                                                Validation Re_E = new Validation();
                                                {
                                                    Console.WriteLine("Fees details of Semester={0}", Sem.SemNum);
                                                    bool CorrectData;
                                                    do
                                                    {
                                                        CorrectData = true;
                                                        bool correctAnnFees;
                                                        do
                                                        {
                                                            correctAnnFees = true;
                                                            try
                                                            {
                                                                Console.WriteLine("Enter Annual Fees of the Student with ID:{0} and Name:{1} for Semester:{2}", S.ID, S.Name, Sem.SemNum);
                                                                Sem.fees.Annual_Fees = Console.ReadLine();
                                                                bool ValidAnnualFees = Re_E.Validate_Annual_fees(Sem.fees.Annual_Fees);
                                                                if (!ValidAnnualFees)
                                                                {
                                                                    Console.WriteLine("\n\tEntered Annual Fees is invalid\n\tValid Annual fees example :20000\n\tRange-[100 to 9999999]");
                                                                    correctAnnFees = false;
                                                                }
                                                                else
                                                                {
                                                                    Sem.fees.DAnnual_Fees = Convert.ToDecimal(Sem.fees.Annual_Fees);
                                                                }
                                                            }
                                                            catch (Exception es)
                                                            {
                                                                Console.WriteLine(ModelStatements.Exception_Statement, es.Message);
                                                                correctAnnFees = false;
                                                            }
                                                        } while (!correctAnnFees);
                                                        bool CorrectAmtPaid;
                                                        do
                                                        {
                                                            CorrectAmtPaid = true;
                                                            try
                                                            {
                                                                Console.WriteLine("Enter Amount paid by the Student:{0} for the Year", S.Name);
                                                                Sem.fees.Amount_Paid = Console.ReadLine();
                                                                bool ValidAmountPaid = Re_E.Validate_Amount_Paid(Sem.fees.Amount_Paid);
                                                                if (!ValidAmountPaid)
                                                                {
                                                                    Console.WriteLine("\n\tEntered AmountPaid is invalid\n\tValid AmountPaid example :20000\n\tRange-[100 to 9999999]");
                                                                    CorrectAmtPaid = false;
                                                                }
                                                                else
                                                                {
                                                                    Sem.fees.DAmount_Paid = Convert.ToDecimal(Sem.fees.Amount_Paid);

                                                                }
                                                            }
                                                            catch (Exception esl)
                                                            {
                                                                Console.WriteLine(ModelStatements.Exception_Statement, esl.Message);
                                                                CorrectAmtPaid = false;
                                                            }
                                                        } while (!CorrectAmtPaid);
                                                        if (Sem.fees.DAmount_Paid > Sem.fees.DAnnual_Fees)
                                                        {
                                                            Console.WriteLine("Entered Amount Paid is greater than Annual tution Fees please recheck and enter the Correct input");
                                                            CorrectData = false;
                                                        }
                                                    } while (!CorrectData);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n\tStudent:{0}'s Academic details are not available\n\tPlease update Academic details",S.Name);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(ModelStatements.No_Student_ID, IpName);
                                }
                                Console.WriteLine(ModelStatements.Res_Get_Std_ByName_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetting_ByName = true;
                                Console.WriteLine("\n");
                            }
                            #endregion 
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
                                bool ValidID = Re_r.ValidateID(IpID);
                                if(!ValidID)
                                {
                                    Console.WriteLine(ModelStatements.Invalid_ID_validation_statement);
                                    goto restartSBC2;
                                }
                                List<Student> IDL = AllStudents.FindAll(std => std.ID == IpID);
                                if (IDL.Count != 0)
                                {
                                    foreach (Student S in IDL)
                                    {
                                        if (S.Semesters.Count != 0)
                                        {
                                            foreach (Semester Sem in S.Semesters)
                                            {
                                                Sem.fees = new Fees();
                                                Validation Re_E = new Validation();
                                                {
                                                    Console.WriteLine("Fees details of Semester={0}", Sem.SemNum);
                                                    bool CorrectData;
                                                    do
                                                    {
                                                        CorrectData = true;
                                                        bool CorrectAnnFees;
                                                        do
                                                        {
                                                            CorrectAnnFees = true;
                                                            try
                                                            {
                                                                Console.WriteLine("Enter Annual Fees of the Student with ID:{0} and Name:{1} for Semester:{2}", S.ID, S.Name, Sem.SemNum);
                                                                Sem.fees.Annual_Fees = Console.ReadLine();
                                                                bool ValidAnnualFees = Re_E.Validate_Annual_fees(Sem.fees.Annual_Fees);
                                                                if (!ValidAnnualFees)
                                                                {
                                                                    Console.WriteLine("\n\tEntered Annual Fees is invalid\n\tValid Annual fees example :20000\n\tRange-[100 to 9999999]");
                                                                    CorrectAnnFees = false;
                                                                }
                                                                else
                                                                {
                                                                    Sem.fees.DAnnual_Fees = Convert.ToDecimal(Sem.fees.Annual_Fees);

                                                                }
                                                            }
                                                            catch (Exception es)
                                                            {
                                                                Console.WriteLine(ModelStatements.Exception_Statement, es.Message);
                                                                CorrectAnnFees = false;
                                                            }

                                                        } while (!CorrectAnnFees);
                                                        bool CorrectAmtPaid;
                                                        do
                                                        {
                                                            CorrectAmtPaid = true;

                                                            try
                                                            {
                                                                Console.WriteLine("Enter Amount paid by the Student:{0} for Semester:{1}", S.Name, Sem.SemNum);
                                                                Sem.fees.Amount_Paid = Console.ReadLine();
                                                                bool ValidAmountPaid = Re_E.Validate_Amount_Paid(Sem.fees.Amount_Paid);
                                                                if (!ValidAmountPaid)
                                                                {
                                                                    Console.WriteLine("\n\tEntered AmountPaid is invalid\n\tValid AmountPaid example :20000\n\tRange-[100 to 9999999]");
                                                                    CorrectAmtPaid = false;

                                                                }
                                                                else
                                                                {
                                                                    Sem.fees.DAmount_Paid = Convert.ToDecimal(Sem.fees.Amount_Paid);

                                                                }
                                                            }
                                                            catch (Exception es)
                                                            {
                                                                Console.WriteLine(ModelStatements.Exception_Statement, es.Message);
                                                                CorrectAmtPaid = false;
                                                            }

                                                        } while (!CorrectAmtPaid);
                                                        if (Sem.fees.DAmount_Paid > Sem.fees.DAnnual_Fees)
                                                        {
                                                            Console.WriteLine("Entered Amount Paid is greater than tution Fees please recheck and enter the Correct input");
                                                            CorrectData = false;
                                                        }
                                                    } while (!CorrectData);

                                                    Sem.fees.DBalance = Sem.fees.DAnnual_Fees - Sem.fees.DAmount_Paid;
                                                }
                                                Console.WriteLine("Annual_Fees:{0}      Amount_Paid:{1}      balance:{2}", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Sem.fees.DBalance);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n\tStudent:{0}'s Academic details are not available\n\tPlease update Academic details",S.Name);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(ModelStatements.No_Student_ID, IpID);
                                }
                                Console.WriteLine(ModelStatements.Res_Get_Std_ByID_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetting_ByID = true;
                                Console.WriteLine("\n");
                            }
                        }
                        else if (SearchByChoice > 2||SearchByChoice<1)
                        {
                            Console.WriteLine(ModelStatements.Invalid_statement);
                        }
                    }
                    catch (Exception eSearchBychoice)
                    {
                        Console.WriteLine(ModelStatements.Exception_Statement, eSearchBychoice.Message);
                    }
                } while (SearchByChoice != 1 && SearchByChoice != 2);
                Console.WriteLine(ModelStatements.Res_Get_Name_ID_continue_close_statement);
                if (Console.ReadLine() != "n") End_Enter_Fee_Name_ID = true;
                Console.WriteLine("\n");
            }
        }
        public static void GetScholarship()
        {
            Validation Re_GS = new Validation();
            bool End_Get_Sch_Name_ID = false;
            while (!End_Get_Sch_Name_ID)
            {
            RestartSch:
                try
                {
                    Console.WriteLine("Enter\n\t1-Student Elgible for Mahila_Vidhyarthi_Scholarship\n\t2-Students Eligible for Merit_Scholarship");
                    int USerchoice = int.Parse(Console.ReadLine());
                    switch(USerchoice)
                    {
                        case 1:
                            try
                            {

                                List<Student> MVSL = AllStudents.FindAll(Std => Std.Gender == "Female");
                                if (MVSL.Count != 0)
                                {
                                    foreach (Student S in MVSL)
                                    {
                                        if (S.Semesters.Count != 0)
                                        {
                                            foreach (Semester Sem in S.Semesters)
                                            {

                                                Sem.fees.Scholarships = new ScholarShip();
                                                Console.WriteLine("Name:{0}     ID:{1}   Ammount claimed through Mahila Vidhyarthi Scholarships for the Semester:{2} is = {3}", S.Name, S.ID, Sem.SemNum, GetScholarShipAmt(Sem, Sem.fees.Scholarships.MVS_Consession_percentage));
                                                //Console.WriteLine("Annual_Fees:{0}      Amount_Paid:{1}      Balance due:{2}", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, GetBalance(Sem));
                                                //Sem.fees.DBalance = GetBalance(Sem);
                                                Sem.fees.Scholarships.Approved_Scholarship_amount_MVS = GetScholarShipAmt(Sem, Sem.fees.Scholarships.MVS_Consession_percentage);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n\tStudent:{0}'s Academic details are not available\n\tPlease update Academic details",S.Name);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(ModelStatements.No_Student_MVSL);
                                }
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("\n\tStudents Fees details are not available\n\tPlease update Fees details");
                            }
                            break;
                        case 2:
                            try
                            {
                                if (AllStudents.Count != 0)
                                {
                                    foreach (Student S in AllStudents)
                                    {
                                        if (S.Semesters.Count != 0)
                                        {

                                            List<Semester> MSS = S.Semesters.FindAll(Se => Se.SemResult >= 85 && Se.Status == "Passed");
                                            if (MSS.Count != 0)
                                            {
                                                foreach (Semester Sem in MSS)
                                                {
                                                    Sem.fees.Scholarships = new ScholarShip();
                                                    Console.WriteLine("Name:{0}     ID:{1}    Ammount claimed through Merit Scholarships for the  Semester {2}is = {3}", S.Name, S.ID, Sem.SemNum, GetScholarShipAmt(Sem, Sem.fees.Scholarships.Merit_Consession_percentage));
                                                    //Console.WriteLine("Annual_Fees:{0}      Amount_Paid:{1}      Balance due:{2}", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, GetBalance(Sem));
                                                    //Sem.fees.DBalance = GetBalance(Sem);
                                                    Sem.fees.Scholarships.Approved_Scholarship_amount_Merit = GetScholarShipAmt(Sem, Sem.fees.Scholarships.MVS_Consession_percentage);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_Merit);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n\tStudent:{0}'s Academic details are not available\n\tPlease update Academic details", S.Name);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(ModelStatements.No_Student_Merit);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\n\tStudents Fees details are not available\n\tPlease update Fees details");

                            }
                            break;
                        default:
                            Console.WriteLine(ModelStatements.Invalid_statement);
                            goto RestartSch;
                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ModelStatements.Exception_Statement, ee.Message);
                    goto RestartSch;
                }
                Console.WriteLine(ModelStatements.Res_Get_Name_ID_continue_close_statement);
                if (Console.ReadLine() != "n") End_Get_Sch_Name_ID = true;
                Console.WriteLine("\n");
            }
        }
      
        public static void GetFeesDetails()
        {
            #region GetFeesDetails method
            bool EndGetFees = false;
            while (!EndGetFees)
            {
            Restartx:
                try
                {
                    Console.WriteLine(ModelStatements.Fees_Get_std_Userchoice_statement);
                    int UserChoice = int.Parse(Console.ReadLine());
                    switch (UserChoice)
                    {
                        case 1:
                            #region AllStudents Results
                            if (AllStudents.Count > 0)
                            {
                                foreach (Student s in AllStudents)
                                {
                                    Console.WriteLine("Name:{0}     ID:{1}", s.Name, s.ID);
                                    if (s.Semesters.Count != 0)
                                    {
                                        foreach (Semester Sem in s.Semesters)
                                        {
                                            Console.WriteLine("Semester={0}", Sem.SemNum);
                                            {
                                                Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(s,Sem));
                                                Sem.fees.DBalance = GetBalance(s,Sem);
                                                if (Sem.fees.DBalance <0)
                                                {
                                                    Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Balance due:{0}",Sem.fees.DBalance);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n\tStudents Academic details are not available\n\tPlease update Academic details");
                                    }
                                    Console.WriteLine("************************************************************");
                                }

                            }
                            else
                            {
                                Console.WriteLine("There are no students in the list ");
                            }
                            #endregion
                            break;
                        case 2:
                            #region Perticular Gender fees details
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
                                        Console.WriteLine(ModelStatements.Fees_Gender_choice_statement);
                                        SearchByGen = int.Parse(Console.ReadLine());
                                        if (SearchByGen == 1)
                                        {
                                            List<Student> MSL = AllStudents.FindAll(std => std.Gender == "Male");
                                            if (MSL.Count != 0)
                                            {
                                                foreach (Student S in MSL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", S.Name, S.ID);
                                                    foreach (Semester Sem in S.Semesters)
                                                    {
                                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                                        {
                                                            Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(S,Sem));
                                                            Sem.fees.DBalance = GetBalance(S,Sem);
                                                            if (Sem.fees.DBalance < 0)
                                                            {
                                                                Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Balance due:{0}", Sem.fees.DBalance);
                                                            }
                                                        }
                                                    }
                                                    
                                                }
                                                Console.WriteLine("************************************************************");
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
                                                foreach (Student St in FSL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", St.Name, St.ID);
                                                    foreach (Semester Sem in St.Semesters)
                                                    {
                                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                                        {
                                                            Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(St,Sem));
                                                            Sem.fees.DBalance = GetBalance(St,Sem);
                                                            if (Sem.fees.DBalance < 0)
                                                            {
                                                                Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Balance due:{0}", Sem.fees.DBalance);
                                                            }
                                                        }
                                                    
                                                    }
                                                    
                                                }
                                                Console.WriteLine("************************************************************");
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
                                Console.WriteLine(ModelStatements.Fees_Get_Gen_std_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetGen = true;
                                Console.WriteLine("\n");
                            }
                            #endregion
                            break;
                        case 3:
                            #region Perticular Branch Results
                            int SearchByBranch = -1;
                            bool EndGetBranch = false;
                            while (!EndGetBranch)
                            {
                                do
                                {
                                RestartBranchBy:
                                    try
                                    {
                                        //Details of list of Female students
                                        Console.WriteLine(ModelStatements.Fees_Branch_choice_statement2);
                                        SearchByBranch = int.Parse(Console.ReadLine());
                                        if (SearchByBranch == 1)
                                        {
                                            #region Mechanical Branch Students Results

                                            List<Student> MCSL = AllStudents.FindAll(std => std.Branch == "ME");
                                            if (MCSL.Count != 0)
                                            {
                                                foreach (Student MS in MCSL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", MS.Name, MS.ID);
                                                    foreach (Semester Sem in MS.Semesters)
                                                    {
                                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                                        {
                                                            Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(MS,Sem));
                                                            Sem.fees.DBalance = GetBalance(MS,Sem);
                                                            if (Sem.fees.DBalance < 0)
                                                            {
                                                                Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Balance due:{0}", Sem.fees.DBalance);
                                                            }
                                                        }
                                                    }
                                                }
                                                Console.WriteLine("************************************************************");
                                            }

                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_ME);
                                            }
                                            #endregion
                                        }
                                        //Details of list of Female students
                                        else if (SearchByBranch == 2)
                                        {
                                            #region Electronics Branch Student Results

                                            List<Student> ESL = AllStudents.FindAll(std => std.Branch == "ECE");
                                            if (ESL.Count != 0)
                                            {
                                                foreach (Student ES in ESL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", ES.Name, ES.ID);
                                                    foreach (Semester Sem in ES.Semesters)
                                                    {
                                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                                        {
                                                            Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(ES,Sem));
                                                            Sem.fees.DBalance = GetBalance(ES,Sem);
                                                            if (Sem.fees.DBalance < 0)
                                                            {
                                                                Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Balance due:{0}", Sem.fees.DBalance);
                                                            }
                                                        }
                                                    }
                                                }
                                                Console.WriteLine("************************************************************");

                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_ECE);
                                            }
                                            #endregion
                                        }
                                        else if (SearchByBranch == 3)
                                        {
                                            #region Computer Science Branch Student Results


                                            List<Student> CSL = AllStudents.FindAll(std => std.Branch == "CSE");
                                            if (CSL.Count != 0)
                                            {
                                                foreach (Student CS in CSL)
                                                {
                                                    Console.WriteLine("Name:{0}     ID:{1}", CS.Name, CS.ID);
                                                    foreach (Semester Sem in CS.Semesters)
                                                    {
                                                        Console.WriteLine("Semester={0}", Sem.SemNum);
                                                        {
                                                            Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(CS,Sem));
                                                            Sem.fees.DBalance = GetBalance(CS,Sem);
                                                            if (Sem.fees.DBalance < 0)
                                                            {
                                                                Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Balance due:{0}", Sem.fees.DBalance);
                                                            }
                                                        }
                                                    }
                                                }
                                                Console.WriteLine("************************************************************");
                                            }
                                            else
                                            {
                                                Console.WriteLine(ModelStatements.No_Student_CSE);
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            Console.WriteLine(ModelStatements.Invalid_statement);
                                        }
                                    }
                                    catch (Exception geSearchByGen)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, geSearchByGen.Message);
                                        goto RestartBranchBy;
                                    }
                                } while (SearchByBranch != 1 && SearchByBranch != 2);
                                Console.WriteLine(ModelStatements.Fees_Get_Branch_std_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetBranch = true;
                                Console.WriteLine("\n");
                            }
                            #endregion
                            break;
                        case 4:
                            #region Perticular Student's Result
                            //Details of particular student
                            Validation Re_r = new Validation();
                            int SearchByChoice = -1;
                            bool EndGetRes_Name_ID = false;
                            while (!EndGetRes_Name_ID)
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine(ModelStatements.Get_Fees_Searchby_Name_Or_ID_statement);
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
                                                bool ValidName = Re_r.ValidateName(IpName);
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
                                                        Console.WriteLine("Name:{0}     ID:{1}", S.Name, S.ID);
                                                        foreach (Semester Sem in S.Semesters)
                                                        {

                                                            Console.WriteLine("Semester={0}", Sem.SemNum);
                                                            {
                                                                Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(S,Sem));
                                                                Sem.fees.DBalance = GetBalance(S,Sem);
                                                                if (Sem.fees.DBalance < 0)
                                                                {
                                                                    Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Balance due:{0}", Sem.fees.DBalance);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ModelStatements.No_Student_ID, IpName);
                                                }
                                                Console.WriteLine(ModelStatements.Fees_Get_Std_ByName_continue_close_statement);
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
                                                bool ValidID = Re_r.ValidateID(IpID);
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
                                                        Console.WriteLine("Name:{0}     ID:{1}", S.Name, S.ID);
                                                        foreach (Semester Sem in S.Semesters)
                                                        {
                                                            Console.WriteLine("Semester={0}", Sem.SemNum);
                                                            {
                                                                Console.WriteLine("Annual_Fees{0}      Amount_Paid:{1}      Total_Claimed_scholarship_amount:{2} ", Sem.fees.Annual_Fees, Sem.fees.Amount_Paid, Get_Total_Scholarship_Amount(S,Sem));
                                                                Sem.fees.DBalance = GetBalance(S,Sem);
                                                                if (Sem.fees.DBalance < 0)
                                                                {
                                                                    Console.WriteLine("Refundable Amount:{0}", Sem.fees.DBalance * (-1));
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Balance due:{0}", Sem.fees.DBalance);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ModelStatements.No_Student_ID, IpID);
                                                }
                                                Console.WriteLine(ModelStatements.Fees_Get_Std_ByID_continue_close_statement);
                                                if (Console.ReadLine() != "n") EndGetting_ByID = true;
                                                Console.WriteLine("\n");
                                            }
                                        }
                                        else if (SearchByChoice > 2 && SearchByChoice <1)
                                        {
                                            Console.WriteLine(ModelStatements.Invalid_statement);
                                        }
                                    }
                                    catch (Exception eSearchBychoice)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eSearchBychoice.Message);
                                    }
                                } while (SearchByChoice != 1 && SearchByChoice != 2);
                                Console.WriteLine(ModelStatements.Fees_Get_Name_ID_continue_close_statement);
                                if (Console.ReadLine() != "n") EndGetRes_Name_ID = true;
                                Console.WriteLine("\n");
                            }
                            #endregion
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
                Console.WriteLine(ModelStatements.Get_Fees_continue_close_statement);
                if (Console.ReadLine() != "n") EndGetFees = true;
                Console.WriteLine("\n");
            }
            #endregion
        }
        public static decimal GetScholarShipAmt(Semester Sem, decimal Consession_Per)
        {
            decimal ScholarShipAmt = (Sem.fees.DAnnual_Fees) * (Consession_Per);
            return ScholarShipAmt;
        }
        public static decimal GetBalance(Student S,Semester Sem)
        {
            decimal Balance = Sem.fees.DAnnual_Fees - Sem.fees.DAmount_Paid -Get_Total_Scholarship_Amount(S,Sem);
            return Balance;
        }
        public static decimal Get_Total_Scholarship_Amount(Student S,Semester Sem)
        {
            if(S.Gender=="Female" && Sem.SemResult>=35 && Sem.SemResult < 85)
            {
                Sem.fees.Scholarships.Total_Scholarship_amount= GetScholarShipAmt(Sem,Sem.fees.Scholarships.MVS_Consession_percentage);
    
            }
            else if(S.Gender == "Female" && Sem.SemResult>=85)
            {
                Sem.fees.Scholarships.Total_Scholarship_amount = GetScholarShipAmt(Sem, Sem.fees.Scholarships.MVS_Consession_percentage) + GetScholarShipAmt(Sem, Sem.fees.Scholarships.Merit_Consession_percentage);
            }
            else if(Sem.SemResult>85 )
            {
                Sem.fees.Scholarships.Total_Scholarship_amount = GetScholarShipAmt(Sem, Sem.fees.Scholarships.Merit_Consession_percentage);
            }

            return Sem.fees.Scholarships.Total_Scholarship_amount;

        }
    }
}

