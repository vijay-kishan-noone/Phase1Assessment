using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiniAssessments
{
    class Teacher
    {
        public string Name { get; set; }
        public int Class { get; set; }
    }
    class Program2
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name\tClass");
            Console.ForegroundColor = ConsoleColor.White;
            string filename = @"e:\data.txt";
            List<Teacher> teachers = new List<Teacher>();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string s in lines)
                {
                    var teacher = new Teacher
                    {
                        Name = s.Substring(0, s.IndexOf(" ")),
                        Class = int.Parse(s.Substring(s.IndexOf(" ") + 1))
                    };
                    teachers.Add(teacher);
                }
                teachers.Sort((x, y) => x.Name.CompareTo(y.Name));
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"{teacher.Name}\t{teacher.Class}");
                }
                Console.WriteLine("Enter a Name to search");
                var name = Console.ReadLine();
                name = name.ToLower();
                var result = teachers.Find(x => x.Name.ToLower() == name);
                Console.WriteLine($"{result.Name}\t{result.Class}");
            }
        }
    }
}
