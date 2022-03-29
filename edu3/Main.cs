using System;
using System.Collections.Generic;
using System.Linq;
using edu3;

namespace edu3
{
    //startup class-containing main method
    public static class Startup
    {
        //Main method/Entry Point of the programe
        public static void Main()
        {
            Console.WriteLine(ModelStatements.Greet1);
            int UserChoice1 = -1;
            bool End = false;
            while (!End)
            {
                do
                {
                    try
                    {
                        //Accessing the features based on user interest using switch statement
                        Console.WriteLine(ModelStatements.Student_Opertaion_userChoice_statement);
                        UserChoice1 = int.Parse(Console.ReadLine());
                        switch (UserChoice1)
                        {
                            case 1:
                                bool End1 = false;
                                while (!End1)
                                {
                                    try
                                    {
                                        StudentOperation.EnterStudentDetails();
                                        End1 = true;
                                    }
                                    catch(Exception eE)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eE.Message);

                                    }
                                }
                                break;
                            case 2:
                                bool End2 = false;
                                while (!End2)
                                {
                                    try
                                    {
                                        StudentOperation.GetStudentDetails();
                                        End2 = true;
                                    }
                                    catch (Exception ee)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, ee.Message);
                                    }
                                }
                                break;
                            case 3:
                                bool End3 = false;
                                while (!End3)
                                {
                                    try
                                    {
                                        StudentOperation.DeleteStudent();
                                        End3 = true;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, e.Message);
                                    }
                                }
                                break;
                            case 4:                                                               
                                    try
                                    {
                                        StudentOperation.GetResults();
                                    }
                                    catch (Exception eee)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eee.Message);

                                    }
                                
                                    break;
                            default:
                                Console.WriteLine(ModelStatements.Invalid_statement);
                                break;

                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(ModelStatements.Exception_Statement, e.Message);
                    }
                } while (UserChoice1 != 1 && UserChoice1 != 2 && UserChoice1 != 3);
                //User Choice to Close the application or to continue
                Console.Write(ModelStatements.App_continue_close_staement);
                if (Console.ReadLine() != "n") End = true;
                Console.WriteLine("\n");
            }
            Console.WriteLine(ModelStatements.Greet2);
        }
    }
}
