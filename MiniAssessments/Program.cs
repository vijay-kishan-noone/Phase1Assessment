using System;
using System.Collections.Generic;
using System.IO;

namespace MiniAssessments
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ID\tName\tClassAndSection");
            Console.ForegroundColor = ConsoleColor.White;
            string filename = @"e:\data.txt";
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string s in lines)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
