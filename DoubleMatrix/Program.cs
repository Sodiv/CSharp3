using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleMatrix
{
    class Program
    {
        static int l = 100;
        static int m = 100;
        static int n = 100;
        static int[][] a = new int[l][];
        static int[][] b = new int[m][];
        static int[][] c = new int[l][];
        static Random rnd = new Random();

        public static void CreateMatrix()
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new int[m];
                for(int j = 0; j < a[i].Length; j++)
                {
                    a[i][j] = rnd.Next(0, 10);
                }
            }
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = new int[n];
                for (int j = 0; j < b[i].Length; j++)
                {
                    b[i][j] = rnd.Next(0, 10);
                }
            }
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = new int[n];
                for (int j = 0; j < c[i].Length; j++)
                {
                    c[i][j] = 0;
                }
            }
        }

        public static void DoubleMatrix(int i)
        {
            Console.WriteLine($"Iteration: {i} start");
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < m; k++)
                {
                    c[i][j] += a[i][k] * b[k][j];
                }
            }
            Console.WriteLine($"Iteration: {i} done");
        }
        static void Main(string[] args)
        {
            CreateMatrix();
            Parallel.For(0, l, DoubleMatrix);
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
