using System;
using System.Text.RegularExpressions;
namespace edu3
{
    //Declaration of Validation Class 
    public class Validation
    {
        //Regular expressions format to validate the User inputs
        public static string Name_Regex = "^[A-Z]{1}[a-z]{2,}$";
        public static string ID_Regex = "^[4]{1}[6]{1}[0-9]{2,4}$";
        public static string Gender_Regex = "(^[M]{1}[a]{1}[l]{1}[e]{1}$)|(^[F]{1}[e]{1}[m]{1}[a]{1}[l]{1}[e]{1}$)";
        public static string Branch_Regex = "(^[M]{1}[E]{1}$)|(^[C]{1}[S]{1}[E]{1}$)|(^[E]{1}[C]{1}[E]{1}$)";
        public static string UserChoice_Regex = "^[0-9]{1,2}$";
        public static string SubName_Regex = "^[A-Z]{1}[a-z]{2,}$";
        public static string SubMarks_Regex = "(^[0]{1,3}$)|(^[0-9]{1,2}$)|(^[1]{1}[0]{1}[0]{1}$)";
        public static string Int_IP_Regex = "";
        public static string Admit_Year_Regex = "(^[2]{1}[0]{1}[0-2]{1}[0-2]{1}$)";
        public static string Annual_fees_Regex = "(^[1-9]{1}[0-9]{2,7}$)";
        public static string Amount_Paid_Regex = "(^[1-9]{1}[0-9]{2,7}$)";

        //Validation methods to validate user inputs returning boolean Value
        public bool ValidateName(string Student)
        {
            return Regex.IsMatch(Student, Name_Regex);
        }
        public bool ValidateID(string Student)
        {
            return Regex.IsMatch(Student, ID_Regex);
        }
        public bool ValidateGender(string Student)
        {

            return Regex.IsMatch(Student, Gender_Regex);
        }
        public bool ValidateBranch(string Student)
        {

            return Regex.IsMatch(Student, Branch_Regex);
        }
        public bool ValidateUserChoice(string Student)
        {

            return Regex.IsMatch(Student, Branch_Regex);
        }

        public bool ValidateSubName(string subName)
        {
            return Regex.IsMatch(subName, SubName_Regex);
        }
        public bool ValidateSubMarks(string Marks)
        {
            return Regex.IsMatch(Marks, SubMarks_Regex);
        }
        public bool Validate_Admit_Year(string Student)
        {
            return Regex.IsMatch(Student, Admit_Year_Regex);
        }
        public bool Validate_Annual_fees(string Fees)
        {
            return Regex.IsMatch(Fees,Annual_fees_Regex);
        }
        public bool Validate_Amount_Paid(string Fees)
        {
            return Regex.IsMatch(Fees,Amount_Paid_Regex);
        }
    }
}