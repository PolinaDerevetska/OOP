/* using System;
using System.Collections.Generic;

interface IAnimal
{
    void Speak();
    void Eat();
}

class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Собака каже: Гав-гав!");
    }

    public void Eat()
    {
        Console.WriteLine("Собака їсть те шо вкраде");
    }
}

class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Кішка каже: Няв-няв!");
    }

    public void Eat()
    {
        Console.WriteLine("Кішка їсть те шо дадуть.");
    }
}

class Program
{
    static void Main()
    {
        List<IAnimal> animals = new List<IAnimal>
        {
            new Dog(),
            new Cat()
        };

        foreach (var animal in animals)
        {
            animal.Speak();
            animal.Eat();
            Console.WriteLine();
        }
    }
}*/

// 2
using System;

interface IPaymentMethod
{
    void Pay(decimal amount);
}

class CreditCard : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата кредитною карткою: {amount} грн");
    }
}

class PayPal : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через PayPal: {amount} грн");
    }
}

class ApplePay : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через ApplePay: {amount} грн");
    }
}

class Order
{
    public IPaymentMethod PaymentMethod { get; set; }

    public void ProcessPayment(decimal amount)
    {
        PaymentMethod.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        Order order1 = new Order { PaymentMethod = new CreditCard() };
        Order order2 = new Order { PaymentMethod = new PayPal() };
        Order order3 = new Order { PaymentMethod = new ApplePay() };

        order1.ProcessPayment(250.00m);
        order2.ProcessPayment(150.50m);
        order3.ProcessPayment(499.99m);
    }
}