using System;

class Program
{
    static void Main()
    {
        // 1
        Console.WriteLine("Завдання 1");
        int[] numbers = { 12, 15, 7, 20, 33, 50, 8, 11, 90, 45 };
        int sum = 0;

        Console.Write("Числа: ");
        foreach (int num in numbers)
        {
            if (num % 3 == 0 || num % 5 == 0)
            {
                Console.Write(num + " ");
                sum += num;
            }
        }
        Console.WriteLine($"\nСума: {sum}\n");

        // 2
        Console.WriteLine("Завдання 2");
        string[] productNames = { "Хліб", "Молоко", "Яблука", "Сир", "Шоколад", "Кава", "Чай" };
        double[] productPrices = { 25.5, 32.0, 45.3, 120.0, 80.0, 150.0, 75.5 };
        double total = 0;
        for (int i = 0; i < productPrices.Length; i++)
        {
            total += productPrices[i];
        }
        double average = total / productPrices.Length;
        Console.WriteLine($"Середня ціна: {average:F2}");
        Console.WriteLine("Товари, дорожчі за середню ціну:");
        for (int i = 0; i < productPrices.Length; i++)
        {
            if (productPrices[i] > average)
            {
                Console.WriteLine($"{productNames[i]} - {productPrices[i]} грн");
            }
        }
        int minIndex = 0, maxIndex = 0;
        for (int i = 1; i < productPrices.Length; i++)
        {
            if (productPrices[i] < productPrices[minIndex])
                minIndex = i;
            if (productPrices[i] > productPrices[maxIndex])
                maxIndex = i;
        }
        Console.WriteLine($"\nНайдешевший товар: {productNames[minIndex]} - {productPrices[minIndex]} грн");
        Console.WriteLine($"Найдорожчий товар: {productNames[maxIndex]} - {productPrices[maxIndex]} грн");
    }
}