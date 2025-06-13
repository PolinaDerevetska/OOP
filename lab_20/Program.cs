/* using System;
using System.Collections.Generic;

public abstract class Animal
{
    public abstract void MakeSound();

    public void Sleep()
    {
        Console.WriteLine("Тварина спить...");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Мяу!");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Гав!");
    }
}

public class Cow : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Мууу!");
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>
        {
            new Cat(),
            new Dog(),
            new Cow()
        };

        foreach (var animal in animals)
        {
            animal.MakeSound();
            animal.Sleep();
            Console.WriteLine();
        }
    }
}*/

// 2
using System;
using System.Collections.Generic;

public abstract class PaymentMethod
{
    public abstract void Pay(decimal amount);

    public void Confirm()
    {
        Console.WriteLine("Платіж підтверджено");
    }
}

public class CreditCard : PaymentMethod
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата кредитною карткою: {amount} грн");
    }
}

public class PayPal : PaymentMethod
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через PayPal: {amount} грн");
    }
}

public class ApplePay : PaymentMethod
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через ApplePay: {amount} грн");
    }
}

class Program
{
    static void Main()
    {
        List<PaymentMethod> payments = new List<PaymentMethod>
        {
            new CreditCard(),
            new PayPal(),
            new ApplePay()
        };

        decimal[] amounts = { 250, 99.99m, 150 };

        for (int i = 0; i < payments.Count; i++)
        {
            payments[i].Pay(amounts[i]);
            payments[i].Confirm();
            Console.WriteLine();
        }
    }
}