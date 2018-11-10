using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileAsync
{
    class Program
    {
        static string path = "../../Files";
        static string[] files;
        static void Main(string[] args)
        {
            Result();
            Console.ReadKey();
        }

        public static async void Result()
        {
            files = Directory.GetFiles(path, "*.txt");
            foreach (string file in files)
            {
                double result = await ReadAsync(file);
                await Task.Delay(1000);
                WriteAsync(result);
            }
        }

        static Task<double> ReadAsync(string path)
        {
            double result = 1;
            return Task.Run(() =>
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string[] s = sr.ReadLine().Split(' ');
                            if (Convert.ToInt32(s[0]) == 1)
                            {
                                result = Convert.ToDouble(s[1]) * Convert.ToDouble(s[2]);
                            }
                            else if (Convert.ToInt32(s[0]) == 2)
                                result = Convert.ToDouble(s[1]) / Convert.ToDouble(s[2]);
                        }
                        catch { }
                    }
                }
                return result;
            });
        }

        static void WriteAsync(double x)
        {
            Task.Run(() =>
            {
                using(StreamWriter sw=new StreamWriter("result.dat", true))
                {
                    sw.WriteLine(x.ToString());
                }
            });
        }
    }
}
