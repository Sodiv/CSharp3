using System;
using System.Threading;

namespace MathThread
{
    class Program
    {
        static int n;
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            n = Convert.ToInt32(Console.ReadLine());
            Thread threadFactorial = new Thread(Factorial);
            Thread threadSumm = new Thread(Summ);
            threadFactorial.Start();
            threadSumm.Start();
            Console.WriteLine("Ждем оконачания работы потоков");
            Console.ReadKey();
        }

        static void Factorial()
        {
            long res = 1;
            for (int i = 2; i <= n; i++)
            {
                res *= i;
            }
            Console.WriteLine($"Факториал числа {n}: {res}");
        }

        static void Summ()
        {
            int res = 1;
            for (int i = 2; i <= n; i++)
            {
                res += i;
            }
            Console.WriteLine($"Сумма всех чисел до числа {n}: {res}");
        }
    }
}
