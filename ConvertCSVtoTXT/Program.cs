using System;
using System.Collections.Concurrent;
using System.IO;

namespace ConvertCSVtoTXT
{
    class Program
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Univercity { get; set; }
            public string Faculty { get; set; }
            public string Department { get; set; }
            public string Age { get; set; }
            public string Course { get; set; }
            public string Group { get; set; }
            public string City { get; set; }
        }

        static BlockingCollection<Student> students = new BlockingCollection<Student>();

        static void Main(string[] args)
        {
            ReadCSV();
        }

        private static void ReadCSV()
        {
            StreamReader sr = new StreamReader();
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    students.Add(new Student { FirstName = s[0], LastName = s[1], Univercity = s[2], Faculty = s[3], Department = s[4],
                        Age = s[5], Course = s[6], Group = s[7], City = s[8] });
                }
                catch { }
            }
        }
    }
}
