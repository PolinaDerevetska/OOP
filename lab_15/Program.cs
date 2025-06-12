/* using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static void PrintNumbers()
    {
        for (int i = 1; i <= 500; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

    static long CalculateFactorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine($"\nФакторіал {n} = {result}");
        return result;
    }

    static void Main()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Parallel.Invoke(
            () => PrintNumbers(),
            () => CalculateFactorial(10)
        );

        stopwatch.Stop();
        Console.WriteLine($"\nЧас виконання: {stopwatch.ElapsedMilliseconds} мс");
    }
}*/

// 1
/* using System;
using System.Threading.Tasks;

class Program
{
    static int counter = 0;
    static object locker = new object();

    static void Main()
    {
        Parallel.For(0, 1000, i =>
        {
            lock (locker)
            {
                counter++;
            }
        });

        Console.WriteLine($"Правильний результат (з lock): {counter}");
    }
}*/

// 2
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int counter = 0;

    static void Main()
    {
        Parallel.For(0, 1000, i =>
        {
            Interlocked.Increment(ref counter);
        });

        Console.WriteLine($"Правильний результат (з Interlocked): {counter}");
    }
}