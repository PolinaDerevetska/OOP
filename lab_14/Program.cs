using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string[] fileNames = { "log1.txt", "log2.txt", "log3.txt" };
        Task[] tasks = new Task[fileNames.Length];

        for (int i = 0; i < fileNames.Length; i++)
        {
            int index = i;
            tasks[i] = Task.Run(() => ProcessFile(fileNames[index]));
        }
        Task.WaitAll(tasks);

        Console.WriteLine("Обробка файлів завершена!");
    }
    static void ProcessFile(string fileName)
    {
        try
        {
            int errorCount = 0;
            var lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (line.Contains("ERROR"))
                    errorCount++;
            }

            Console.WriteLine($"Файл {fileName}: знайдено {errorCount} помилок.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при обробці файлу {fileName}: {ex.Message}");
        }
    }
}