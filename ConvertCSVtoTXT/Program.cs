using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

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
            Thread threadCSV = new Thread(ReadCSV);
            Thread threadTXT = new Thread(WriteToTXT);
            threadCSV.Start();
            threadTXT.Start();
            threadTXT.Join();
            Console.WriteLine("Завершено");
            Console.ReadKey();
        }

        private static void ReadCSV()
        {
            StreamReader sr = new StreamReader("../../../students_4.csv");
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
            students.CompleteAdding();
            sr.Close();
        }

        private static void WriteToTXT()
        {
            StreamWriter sw = new StreamWriter("student.txt");
            foreach(var item in students.GetConsumingEnumerable())
            {
                sw.WriteLine($"{item.FirstName} {item.LastName} {item.Univercity} {item.Faculty} {item.Department} " +
                    $"{item.Age} {item.Course} {item.Group} {item.City}");
            }
            sw.Close();
        }
    }
}
