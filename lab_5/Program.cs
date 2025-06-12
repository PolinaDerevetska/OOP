using System;

namespace ConsoleApp1
{
    class Program
    {
        // 1
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // 2
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        static double Sum(double a, double b)
        {
            return a + b;
        }

        // 3
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Main()
        {
            Console.WriteLine("Завдання 1");
            Console.WriteLine(IsEven(8));
            Console.WriteLine(IsEven(7));
            Console.WriteLine();

            Console.WriteLine("Завдання 2");
            Console.WriteLine(Sum(5, 10));
            Console.WriteLine(Sum(2, 3, 4));
            Console.WriteLine(Sum(2.5, 3.1));
            Console.WriteLine();

            Console.WriteLine("Завдання 3");
            int a = 5, b = 10;
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");
        }
    }
}