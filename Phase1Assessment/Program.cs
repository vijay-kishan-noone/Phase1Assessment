using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Phase1Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            TeacherBO context = new TeacherBO();

            Console.WriteLine("Hello User!!!\n");     
            string filename = @"C:\teachersinfo.txt";
            while (flag)
            {
                Console.WriteLine("1.Add Teacher\n2.Edit Teacher\n3.Delete Teacher\n4.Display Teacher By ID\n5.Display All Teachers(In Text File)\n6.Display All Teachers(In Console App)\n7.Exit\nPlease enter a choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            TeacherModel t = new TeacherModel();
                            Console.WriteLine("Please provide the ID of the Teacher");
                            t.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please provide the Name of the Teacher");
                            t.Name = Console.ReadLine();
                            Console.WriteLine("Please provide the ClassAndSection of the Teacher");
                            t.ClassAndSection = Console.ReadLine();
                            context.AddTeacher(t);
                            Console.WriteLine("Teacher added successfully");
                        }
                        break;
                    case 2:
                        {
                            TeacherModel t = new TeacherModel();
                            Console.WriteLine("Please provide the ID of the Teacher");
                            t.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please provide the Name of the Teacher");
                            t.Name = Console.ReadLine();
                            Console.WriteLine("Please provide the ClassAndSection of the Teacher");
                            t.ClassAndSection = Console.ReadLine();
                            if (context.GetTeacherById(t.ID) == null)
                                Console.WriteLine("The teacher ID is not found, Please try again!!");
                            else
                            {
                                context.EditTeacher(t);
                                Console.WriteLine("Updated the teacher details successfully");
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Please enter the ID of the teacher you want to Delete");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            TeacherModel t = context.GetTeacherById(ID);
                            context.DeleteTeacher(t);
                            Console.WriteLine("Deleted the teacher details successfully");
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Please enter the Id of the teacher");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            TeacherModel ?teacher = context.GetTeacherById(ID);
                            if (teacher == null)
                                Console.WriteLine("The given ID is not found, Please try again!!");
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("ID\tName\tClassAndSection");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine($"{teacher.ID}\t{teacher.Name}\t{teacher.ClassAndSection}");
                            }
                        }
                        break;
                    case 5:
                        {
                            using (StreamWriter wrt = File.CreateText(filename))
                            {
                                List<TeacherModel> teachers = context.GetAllTeachers();
                                wrt.WriteLine("ID\tName\tClassAndSection");
                                foreach (var teacher in teachers)
                                {
                                    wrt.WriteLine($"{teacher.ID}\t{teacher.Name}\t{teacher.ClassAndSection}");
                                }
                                Console.WriteLine($"The details have been displayed on the file {filename}");
                            }
                        }
                        break;
                    case 6:
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("ID\tName\tClassAndSection");
                            Console.ForegroundColor = ConsoleColor.White;
                            List<TeacherModel> teachers = context.GetAllTeachers();
                            foreach (var teacher in teachers)
                            {
                                Console.WriteLine($"{teacher.ID}\t{teacher.Name}\t{teacher.ClassAndSection}");
                            }
                        }
                        break;
                    case 7:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
