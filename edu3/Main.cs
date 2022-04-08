using System;
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
                                        //StudentOperation.GetStudentDetails();
                                        StudentOperation.EnterAcademic_Details();
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
                                        StudentOperation.EnterFeesDetails();
                                        End3 = true;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, e.Message);
                                    }
                                }
                                break;
                            case 4:
                                bool End4 = false;
                                while(!End4)
                                    try
                                    {
                                        StudentOperation.GetStudentDetails();
                                        End4 = true;
                                          
                                    }
                                    catch (Exception eee)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eee.Message);

                                    }
                                
                                    break;
                            case 5:
                                bool End5 = false;
                                while (!End5)
                                {
                                    try
                                    {
                                        StudentOperation.GetResults();
                                        End5 = true;
                                    }
                                    catch (Exception eee)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eee.Message);

                                    }
                                }
                                break;
                            case 6:
                                bool End6 = false;
                                while (!End6)
                                {
                                    try
                                    {
                                        StudentOperation.GetFeesDetails();
                                        End6 = true;
                                    }
                                    catch (Exception eee)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eee.Message);

                                    }
                                }
                                break;
                            case 7:
                                bool End7 = false;
                                while (!End7)
                                {
                                    try
                                    {
                                        StudentOperation.GetScholarship();
                                        End4 = true;
                                    }
                                    catch (Exception eee)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eee.Message);
                                    }
                                }
                                break;
                            case 8:
                                bool End8 = false;
                                while (!End8)
                                {
                                    try
                                    {
                                        StudentOperation.DeleteStudent();
                                        End4 = true;
                                    }
                                    catch (Exception eee)
                                    {
                                        Console.WriteLine(ModelStatements.Exception_Statement, eee.Message);
                                    }
                                }

                                break;
                            default:
                                Console.WriteLine(ModelStatements.Invalid_statement);
                                break;

                        }
                    }
                    catch
                    {
                        Console.WriteLine(ModelStatements.Invalid_statement);
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
