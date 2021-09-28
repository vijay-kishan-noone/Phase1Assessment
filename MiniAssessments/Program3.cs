using System;
using System.Collections.Generic;
using System.Text;

namespace MiniAssessments
{
    class StudentModel
    {
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }
    class TeacherModel
    {
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }
    class SubjectModel
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public string TeacherName  { get; set; }
    }
    class Program3
    {
        static void Main(string[] args)
        {
            List<StudentModel> students = new List<StudentModel>();
            List<TeacherModel> teachers = new List<TeacherModel>();
            List<SubjectModel> subjects = new List<SubjectModel>();
            while (true)
            {
                Console.WriteLine("1.Add Student \n2.Add Teacher\n3.Add Subject \n4.Students in a Class \n5.Subjects taught by a Teacher");
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Student Name");
                            var name = Console.ReadLine();
                            Console.WriteLine("Enter Student Class and Section");
                            var cas = Console.ReadLine();
                            students.Add(new StudentModel
                            {
                                Name = name,
                                ClassAndSection = cas
                            });
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter Teacher Name");
                            var name = Console.ReadLine();
                            Console.WriteLine("Enter Teacher Class and Section");
                            var cas = Console.ReadLine();
                            teachers.Add(new TeacherModel
                            {
                                Name = name,
                                ClassAndSection = cas
                            });
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter Subject Name");
                            var name = Console.ReadLine();
                            Console.WriteLine("Enter Subject Code");
                            var code = Console.ReadLine();
                            Console.WriteLine("Enter Teacher Name");
                            var tname = Console.ReadLine();
                            subjects.Add(new SubjectModel
                            {
                                Name = name,
                                SubjectCode = code,
                                TeacherName = tname
                            });
                        }
                        break;
                    case 4: 
                        {
                            Console.WriteLine("Enter the class and section");
                            var cas = Console.ReadLine();
                            Console.WriteLine("The students of this class are: ");
                            var result = students.FindAll(x => x.ClassAndSection == cas);
                            foreach (var student in result)
                            {
                                Console.WriteLine($"{student.Name}\t{student.ClassAndSection}");
                            }
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Enter Teacher Name");
                            var tname = Console.ReadLine();
                            Console.WriteLine("The subjects taught by this teacher are: ");
                            var result = subjects.FindAll(x => x.TeacherName == tname);
                            foreach (var subject in result)
                            {
                                Console.WriteLine($"{subject.Name}");
                            }
                        }
                        break;
                    default: Console.WriteLine("Wrong Choice");
                        break;
                }
            }
        }
    }
}
