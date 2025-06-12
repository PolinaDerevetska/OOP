using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // 1
            Console.WriteLine("Завдання 1");
            Console.Write("Введіть число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
                Console.WriteLine("Число парне.");
            else
                Console.WriteLine("Число непарне.");
            Console.WriteLine();

            // 2
            Console.WriteLine("Завдання 2");
            Console.Write("Введіть вашу оцінку (0-100): ");
            int grade = Convert.ToInt32(Console.ReadLine());
            if (grade >= 90 && grade <= 100)
                Console.WriteLine("Ваша оцінка: A");
            else if (grade >= 75 && grade <= 89)
                Console.WriteLine("Ваша оцінка: B");
            else if (grade >= 60 && grade <= 74)
                Console.WriteLine("Ваша оцінка: C");
            else if (grade >= 0 && grade < 60)
                Console.WriteLine("Ваша оцінка: F");
            else
                Console.WriteLine("Некоректна оцінка.");
            Console.WriteLine();

            // 3
            Console.WriteLine("Завдання 3");
            Console.Write("Введіть число (1-7): ");
            int day = Convert.ToInt32(Console.ReadLine());
            switch (day)
            {
                case 1: Console.WriteLine("Понеділок"); break;
                case 2: Console.WriteLine("Вівторок"); break;
                case 3: Console.WriteLine("Середа"); break;
                case 4: Console.WriteLine("Четвер"); break;
                case 5: Console.WriteLine("Пʼятниця"); break;
                case 6: Console.WriteLine("Субота"); break;
                case 7: Console.WriteLine("Неділя"); break;
                default: Console.WriteLine("Невірне число."); break;
            }
            Console.WriteLine();

            // 4
            Console.WriteLine("Завдання 4");
            Console.Write("Введіть марку авто (Toyota, BMW, Tesla): ");
            string car = Console.ReadLine();
            switch (car)
            {
                case "Toyota": Console.WriteLine("Країна: Японія"); break;
                case "BMW": Console.WriteLine("Країна: Німеччина"); break;
                case "Tesla": Console.WriteLine("Країна: США"); break;
                default: Console.WriteLine("Невідома марка авто."); break;
            }
            Console.WriteLine();

            // 5
            Console.WriteLine("Завдання 5");
            Console.Write("Введіть температуру: ");
            int temp = Convert.ToInt32(Console.ReadLine());
            string result = temp >= 0 ? "Погода тепла." : "Погода холодна.";
            Console.WriteLine(result);
            Console.WriteLine();

            // 6
            Console.WriteLine("Завдання 6");
            try
            {
                Console.Write("Введіть перше число: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введіть друге число: ");
                int y = Convert.ToInt32(Console.ReadLine());

                int division = x / y;
                Console.WriteLine($"Результат: {division}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Помилка: поділ на нуль!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: введено не число!");
            }
        }
    }
}