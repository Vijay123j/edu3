using System;
namespace edu3
{
    /// <summary>
    /// Declaration of a model class and assigning hard coded statements
    /// accessing assigned statement format whenever needed for any number of time
    /// </summary>
    public class ModelStatements
    {
        public static string Greet1 = "Welcome....!";
        public static string Greet2 = "Thank You....!";

        public static string Student_Opertaion_userChoice_statement = "Please press \n\t1-Enter students details\n\t2-Enter student's Academic details\n\t3-Enter student's fees details\n\t4-Get students Personal details \n\t5-Get students Academic details\n\t6-Get students Fees details\n\t7-Get Students Scholarship details\n\t8-To Delete Student";
        public static string Enter_DetailType_userChoice_statement = "Please press \n\t1-Enter students Personal details\n\t2-Enter Students Academic Details";
        public static string Adding_std_continue_close_staement = "\n\tIf you prefer to continue adding another student's details press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Adding_stdPerDet_continue_close_staement = "\n\tIf you prefer to continue adding another student's personal details press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Ask_To_Add_AcaDet_continue_close_staement = "\n\tPress-> n and Enter to continue adding ACADEMIC details of the same student \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Adding_Subj_continue_close_staement = "\n\t press-> n and Enter-If you prefer to continue adding another Subject details of Semester{0} \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Ask_To_Add_Fees_continue_close_staement = "\n\tPress-> n and Enter to continue adding Fees details of the same student \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Ask_To_Add_FeesDet_continue_close_staement = "\n\tPress-> n and Enter to continue adding Fees details of the same Semester of the student \n\tOR ELSE\n\tPress->any other key and Enter";

        public static string Get_std_Userchoice_statement = "Enter \n\t1- Details of all the students \n\t2-Details of Students of particular Gender \n\t3- Details of students of a particular Branch \n\t4-Details of one particular student ";
        public static string Get_Std_ByID_continue_close_statement = "\n\tIf you prefer to continue getting student's details using search by ID press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Get_Std_ByName_continue_close_statement = "\n\tIf you prefer to continue getting student's details using search by Name press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Res_Get_Std_ByName_continue_close_statement = "\n\tIf you prefer to continue Enter the Fee details of the student using search by Name press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Res_Get_Std_ByID_continue_close_statement = "\n\tIf you prefer to continue Enter the Fee details of the student using search by ID press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Fees_Get_Std_ByName_continue_close_statement = "\n\tIf you prefer to continue get the Fee details of the student using search by Name press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Fees_Get_Std_ByID_continue_close_statement = "\n\tIf you prefer to continue get the Fee details of the student using search by ID press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";

        public static string Get_Std_continue_close_statement = "\n\tIf you prefer to continue getting student's details  press-> n and Enter \n\tOR ELSE\n\tTo quit getting student details Press->any other key and Enter";
        public static string Get_AllStd_continue_close_statement = "\n\tIf you prefer to continue getting details of all students press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Get_Gen_std_continue_close_statement = "\n\tIf you prefer to continue getting student's details of particular gender press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Get_Name_ID_continue_close_statement = "\n\tIf you prefer to continue getting details of particular student based on Name OR ID press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Res_Get_Name_ID_continue_close_statement = "\n\tIf you prefer to continue getting results of particular student based on Name OR ID press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Fees_Get_Gen_std_continue_close_statement = "\n\tIf you prefer to continue getting student's Fee details of particular gender press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Fees_Get_Name_ID_continue_close_statement = "\n\tIf you prefer to continue getting Fee details of particular student based on Name OR ID press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Sch_Get_MVS_Merit_continue_close_statement = "\n\tIf you prefer to continue getting Scholarship details of students press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";

        public static string Get_Branch_std_continue_close_statement = "\n\tIf you prefer to continue getting details of student's of a particular branch press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Duplicate_Name_Entry = "\n\tThe entered Name is already assigned to a student in the list\n\tPlease try a different Name";
        public static string Del_ByName_continue_close_statement = "\n\tIf you prefer to continue deleting student's using search by Name press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Del_ByID_continue_close_statement = "\n\tIf you prefer to continue deleting student's using search by ID press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string App_continue_close_staement = "\n\tTo continue Other features press->'n' and Enter \n\tOR ELSE\n\tTo close the app press->any other key and Enter ";
        public static string Get_Result_continue_close_statement = "\n\tPress-> n and Enter ->if you prefer to continue getting student's result   \n\tOR ELSE\n\tTo quit getting students results Press->any other key and Enter";
        public static string Get_std_Res_Userchoice_statement = "Enter \n\t1- Results of all the students \n\t2-Results of students of particular gender\n\t3-Results students of a particular Branch\n\t4-Result of a particular student ";
        public static string Res_Get_Branch_std_continue_close_statement = "\n\tIf you prefer to continue getting Results of student's of a particular branch press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Fees_Get_std_Userchoice_statement = "Enter \n\t1- Fees Details of all the students \n\t2-Fees Details of students of particular gender\n\t3-Fees Details students of a particular Branch\n\t4-Fees Details of a particular student ";
        public static string Fees_Get_Branch_std_continue_close_statement = "\n\tIf you prefer to continue getting Fees details of student's of a particular branch press-> n and Enter \n\tOR ELSE\n\tPress->any other key and Enter";
        public static string Get_Fees_continue_close_statement = "\n\tPress-> n and Enter ->if you prefer to continue getting student's Fees details   \n\tOR ELSE\n\tTo quit getting students Fees details Press->any other key and Enter";
        public static string Res_Searchby_Name_Or_ID_statement= "Enter \n\t1- to get the result of the student using search by Name\n\t2-to get Result of the student using search by ID";
        public static string Exception_Statement = "\tAn Exception has occured:{0}\n\tPlease Enter Valid input";
        public static string Enter_Academic_continue_close_statement = "\n\tPress-> n and Enter ->if you prefer to continue Enter Student's Academic details \n\tOR ELSE\n\tTo quit Press->any other key and Enter";
        public static string Enter_Fees_continue_close_statement = "\n\tPress-> n and Enter ->if you prefer to continue Enter Student's Fees details \n\tOR ELSE\n\tTo quit Press->any other key and Enter";


        public static string Enter_Name = "\tEnter Name of the student";
        public static string Enter_ID = "\tEnter ID of the student";
        public static string Enter_Branch = "\tEnter Branch of the student";
        public static string Enter_Gender = "\tEnter Gender of the student";
        public static string Enter_Adm_Year = "\tEnter Year of Admission of the student";

        public static string Enter_SemNum = "\tEnter Semester number of the student";
        public static string Enter_Cur_sem = "\tEnter the Latest Semester number which student has taken Final examination and corresponding subject marks are available";
        public static string Enter_SubjName = "\tEnter the Name of Subject of Semester {0} of the student";
        public static string Enter_SubjMarks = "\tEnter the  Marks of Subject of Semester {0}of the student";
        public static string Enter_Num_Subj = "\n\tEnter the number of the Subjects in semester{0}";
       
        public static string Invalid_statement = "\tYour input is invalid\n\tPlease enter the valid input";
        public static string Invalid_Sem_Entry_statement = "\tYour input Semester is invalid\n\tPlease enter the valid Semester Input";
        public static string Invalid_Name_validation_statement = "Your input Student name is not in the correct format\n\tValid Name-Starts with Uppercase Alphabetic character\n\t-Contains only Alphabetic characters\n\t-Has more than 2 Alphabetic characters";
        public static string Invalid_ID_validation_statement = "\tYour input Student ID is not in the correct format\n\tValid Student ID format-46XX OR 46XXX OR 46XXXX";
        public static string Invalid_Branch_validation_statement = "\tYour input Student Branch is not in the correct format\n\tPlease enter valid Student Branch\n\tEnter \n\tME -for Mechanical Department\n\tECE - for Electronics department\n\tCSE -for Computer Science Deparment student details";
        public static string Invalid_Gender_validation_statement = "\tYour input Student gender is not in the correct format\n\tPlease enter valid Student gender\n\tEnter \n\tMale -for male students Details\n\tFemale -for female student Details";
        public static string Invalid_Admit_year_validation_statement = "\tYour input Student's year of admission is not in the correct format\n\tPlease enter valid Studen's year of admission\n\tValid Student's year of admission format-20XX\n\t example:2020";

        public static string Invalid_SubName_validation_statement = "\tYour input Subject Name is not in the correct format\n\t Valid Subject Name example and format-Maths\n\t'Starts with Uppercase Alphabetic Character,remaining all characters will be Smaller case alphabetis and will have more than 3 characters'";
        public static string Invalid_SubMarks_validation_statement = "\tYour input Subject Marks is not in the correct format\n\t Valid Subject Marks Will be in the Range(0 to 100)";

        public static string Print_details_statement = "Name:{0},   ID :{1},  Branch:{2},   Gender:{3}";
        public static string Gender_choice_statement = "Enter \n\t1-for male students Details\n\t2-for female student Details";
        public static string Res_Gender_choice_statement = "Enter \n\t1-for male students results\n\t2-for female students results";
        public static string Fees_Gender_choice_statement = "Enter \n\t1-for male students Fees details\n\t2-for female students Fees details";

        public static string Branch_choice_statement = "Enter \n\tME-for Mechanical Department students Details\n\tECE - for Electronics department student Details\n\tCSE -for Computer Science Deparment student details";
        public static string Searchby_Name_Or_ID_statement = "Enter \n\t1- to get details using search by Name\n\t2-to get details using search by ID";
        public static string Fees_Searchby_Name_Or_ID_statement = "Enter \n\t1- to Enter the Fee details of the student using search by Name\n\t2-to Enter the Fee details of the student using search by ID";
        public static string Get_Fees_Searchby_Name_Or_ID_statement = "Enter \n\t1- to get the Fee details of the student using search by Name\n\t2-to get the Fee details of the student using search by ID";
        public static string Aca_Searchby_Name_Or_ID_statement = "Enter \n\t1- to Enter the Academic details of the student using search by Name\n\t2-to Enter the Academic details of the student using search by ID";

        public static string Branch_choice_statement2 = "Enter \n\t1-for Mechanical Department students Details\n\t2- for Electronics department student Details\n\t3-for Computer Science Deparment student details";
        public static string Res_Branch_choice_statement2 = "Enter \n\t1-for Mechanical Department students Results\n\t2- for Electronics department student Results\n\t3-for Computer Science Deparment student Results";
        public static string Fees_Branch_choice_statement2 = "Enter \n\t1-for Mechanical Department students Fees Details\n\t2- for Electronics department student Fees Details\n\t3-for Computer Science Deparment student Fees Details";

        public static string Searchby_Name_Or_ID_statement_Delete = "Enter \n\t1- to Delete student using search by Name\n\t2-to delete student using search by ID";
        public static string Duplicate_ID_Entry = "\n\tThe entered ID is already assigned to a student in the list\n\tPlease try a different ID";
        public static string Duplicate_SubName_Entry = "\n\tThe entered Subject is matching your Previous Subject entry\n\tPlease Enter other Subject of the semester";

        public static string No_Student = "\n\tThere is no student with your Input Name or ID";
        public static string No_Student_Name = "\n\tThere is no student with Name:{0}";
        public static string No_Student_ID = "\n\tThere is no student with ID:{0}";
        public static string No_Student_CSE = "\n\tThere is no student belonging to computer science engineering department in the list";
        public static string No_Student_ME = "\n\tThere is no student belonging to mechanical engineering department in the list";
        public static string No_Student_ECE = "\n\tThere is no student belonging to electronics and communication engineering department in the list";
        public static string No_Student_Male = "\n\tThere are no Male Students";
        public static string No_Student_Female = "\n\tThere are no Female Students";
        public static string No_Student_MVSL = "\n\tNo Student in the list is eligible for Mahila_Vidhyarthi_Scholarship";
        public static string No_Student_Merit = "\n\tNo Student in the list is eligible for Merit Schoalarship";
        public static string No_Student_AllStudents = "\n\tThere is No Student in the list";


    }
}
