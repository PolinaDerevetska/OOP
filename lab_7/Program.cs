using System;

class Program
{
    static void Main()
    {
        // 1
        Console.WriteLine("Завдання 1");
        for (int i = 2; i <= 20; i += 2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // 2
        Console.WriteLine("Завдання 2");
        int sum = 0;
        int number;
        while (true)
        {
            Console.Write("Введіть число: ");
            number = Convert.ToInt32(Console.ReadLine());
            if (number == 0)
                break;
            sum += number;
        }
        Console.WriteLine("Сума: " + sum);
        Console.WriteLine();

        // 3
        Console.WriteLine("Завдання 3");
        string password;
        do
        {
            Console.Write("Введіть пароль: ");
            password = Console.ReadLine();
            if (password != "1234")
            {
                Console.WriteLine("Неправильний пароль!");
            }
        } while (password != "1234");

        Console.WriteLine("Доступ дозволено!");
    }
}