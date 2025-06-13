/* using System;

class Transport
{
    public string Name { get; set; }

    public virtual void Move()
    {
        Console.WriteLine($"{Name} рухається...");
    }
}

class Car : Transport
{
    public override void Move()
    {
        Console.WriteLine($"{Name} їде дорогою");
    }
}

class Bicycle : Transport
{
    public override void Move()
    {
        Console.WriteLine($"{Name} їде по велодоріжці");
    }
}

class Train : Transport
{
    public override void Move()
    {
        Console.WriteLine($"{Name} їде по рейках");
    }
}

class Program
{
    static void Main()
    {
        Transport[] transports = new Transport[]
        {
            new Car { Name = "Автомобіль" },
            new Bicycle { Name = "Велосипед" },
            new Train { Name = "Потяг" }
        };

        foreach (var transport in transports)
        {
            transport.Move();
        }
    }
}*/

// 2
using System;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; }

    public virtual void Work()
    {
        Console.WriteLine($"{Name} працює");
    }
}

class Programmer : Employee
{
    public override void Work()
    {
        Console.WriteLine($"{Name} пише код");
    }
}

class Designer : Employee
{
    public override void Work()
    {
        Console.WriteLine($"{Name} створює дизайн");
    }
}

class Manager : Employee
{
    public override void Work()
    {
        Console.WriteLine($"{Name} керує проєктом");
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Programmer { Name = "Андрій" },
            new Designer { Name = "Олена" },
            new Manager { Name = "Марія" }
        };

        foreach (var employee in employees)
        {
            employee.Work();
        }
    }
}