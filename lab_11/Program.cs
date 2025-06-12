/* using System;
using System.Collections.Generic;

class SupportQueueApp
{
    static void Main()
    {
        Queue<string> requests = new Queue<string>();
        int choice;

        do
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати заявку");
            Console.WriteLine("2. Обробити заявку");
            Console.WriteLine("3. Подивитися першу заявку");
            Console.WriteLine("4. Показати всі заявки");
            Console.WriteLine("5. Вийти");
            Console.Write("Виберіть опцію: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть текст заявки: ");
                    string request = Console.ReadLine();
                    requests.Enqueue(request);
                    Console.WriteLine("Заявку додано!");
                    break;

                case 2:
                    if (requests.Count > 0)
                    {
                        string processed = requests.Dequeue();
                        Console.WriteLine($"Заявка \"{processed}\" оброблена!");
                    }
                    else
                    {
                        Console.WriteLine("Черга порожня.");
                    }
                    break;

                case 3:
                    if (requests.Count > 0)
                    {
                        Console.WriteLine($"Перша заявка в черзі: \"{requests.Peek()}\"");
                    }
                    else
                    {
                        Console.WriteLine("Черга порожня.");
                    }
                    break;

                case 4:
                    if (requests.Count > 0)
                    {
                        Console.WriteLine("Усі заявки:");
                        foreach (var r in requests)
                        {
                            Console.WriteLine($"- {r}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Черга порожня.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Програма завершена.");
                    break;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

        } while (choice != 5);
    }
} */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class WordFrequencyCounter
{
    static void Main()
    {
        Console.WriteLine("Введіть текст:");
        string input = Console.ReadLine();
        string cleanedText = Regex.Replace(input.ToLower(), @"[^\w\s]", "");
        string[] words = cleanedText.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (wordCounts.ContainsKey(word))
                wordCounts[word]++;
            else
                wordCounts[word] = 1;
        }
        Console.WriteLine("\nЧастота слів (від більшого до меншого):");

        foreach (var pair in wordCounts.OrderByDescending(kv => kv.Value))
        {
            Console.WriteLine($"{pair.Key} — {pair.Value}");
        }
    }
}