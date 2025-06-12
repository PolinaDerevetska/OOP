using System;

namespace LAB3
{
    class Program
    {
        // 1: Виправлено неймінг за PascalCase та camelCase
        private static void Task1()
        {
            int userAge = 20; // Змінна для зберігання віку користувача
            string userName = "Андрій"; // Змінна для зберігання імені користувача
            Console.WriteLine("Привіт, " + userName + "! Твій вік: " + userAge);
        }
        // 2: Те саме, але перевірено, що імена не є зарезервованими словами
        private static void Task2()
        {
            int userAge = 20;
            string userName = "Андрій";
            Console.WriteLine("Привіт, " + userName + "! Твій вік: " + userAge);
        }
        // 3: Додано пояснювальні коментарі до кожного рядка
        private static void Task3()
        {
            string name = "Анна"; // Ініціалізація змінної з іменем
            int age = 25;         // Ініціалізація змінної з віком
                                  // Виведення повідомлення у консоль
            Console.WriteLine("Привіт, " + name + "! Твій вік: " + age);
        }
        // Головний метод Main для запуску програм
        static void Main(string[] args)
        {
            Task1(); // Виклик першого методу
            Task2(); // Виклик другого методу
            Task3(); // Виклик третього методу
        }
    }
}