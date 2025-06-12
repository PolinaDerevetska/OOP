using System;
using System.Collections.Generic;

class MortgageApp
{
    class Application
    {
        public decimal Principal { get; set; }
        public decimal AnnualRate { get; set; }
        public int Years { get; set; }

        public decimal CalculateMonthlyPayment()
        {
            decimal r = AnnualRate / 12 / 100;
            int n = Years * 12;

            if (r == 0)
                return Math.Round(Principal / n, 2);

            decimal factor = (decimal)Math.Pow((double)(1 + r), n);
            decimal payment = Principal * r * factor / (factor - 1);
            return Math.Round(payment, 2);
        }

        public override string ToString()
        {
            return $"Сума: {Principal}, Ставка: {AnnualRate}%, Роки: {Years}, Щомісячний платіж: {CalculateMonthlyPayment()}";
        }
    }

    static void Main()
    {
        Queue<Application> queue = new Queue<Application>();
        int choice;

        do
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Додати нову заявку");
            Console.WriteLine("2. Обробити першу заявку");
            Console.WriteLine("3. Переглянути першу заявку");
            Console.WriteLine("4. Переглянути всі заявки");
            Console.WriteLine("5. Вийти");
            Console.Write("Ваш вибір: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть суму кредиту (грн): ");
                    decimal p = decimal.Parse(Console.ReadLine());

                    Console.Write("Введіть річну відсоткову ставку (%): ");
                    decimal rate = decimal.Parse(Console.ReadLine());

                    Console.Write("Введіть кількість років: ");
                    int years = int.Parse(Console.ReadLine());

                    queue.Enqueue(new Application { Principal = p, AnnualRate = rate, Years = years });
                    Console.WriteLine("Заявку додано!");
                    break;

                case 2:
                    if (queue.Count > 0)
                    {
                        var app = queue.Dequeue();
                        Console.WriteLine("Оброблено: " + app);
                    }
                    else
                    {
                        Console.WriteLine("Черга порожня.");
                    }
                    break;

                case 3:
                    if (queue.Count > 0)
                    {
                        var first = queue.Peek();
                        Console.WriteLine("Перша заявка: " + first);
                    }
                    else
                    {
                        Console.WriteLine("Черга порожня.");
                    }
                    break;

                case 4:
                    if (queue.Count > 0)
                    {
                        Console.WriteLine("Усі заявки:");
                        foreach (var app in queue)
                            Console.WriteLine(app);
                    }
                    else
                    {
                        Console.WriteLine("Черга порожня.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Вихід");
                    break;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

        } while (choice != 5);
    }
}