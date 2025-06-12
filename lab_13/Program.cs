/* using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Predicate<int> isEven = n => n % 2 == 0;
        var evenNumbers = Filter(numbers, isEven);
        Console.WriteLine("Парні числа:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
    static int[] Filter(int[] numbers, Predicate<int> predicate)
    {
        var result = new List<int>();
        foreach (var number in numbers)
        {
            if (predicate(number))
                result.Add(number);
        }
        return result.ToArray();
    }
}*/

using System;

class Order
{
    public event EventHandler<string> OrderStatusChanged;

    private string status;
    public string Status
    {
        get => status;
        set
        {
            if (status != value)
            {
                status = value;
                OnOrderStatusChanged(status);
            }
        }
    }

    protected virtual void OnOrderStatusChanged(string newStatus)
    {
        OrderStatusChanged?.Invoke(this, newStatus);
    }
}

class Program
{
    static void Main()
    {
        Order order = new Order();
        order.OrderStatusChanged += OrderStatusChangedHandler;
        order.Status = "Замовлення отримано";
        order.Status = "Відправлено";
        order.Status = "Доставлено";
    }
    static void OrderStatusChangedHandler(object sender, string status)
    {
        Console.WriteLine($"Статус замовлення змінено на: {status}");
    }
}