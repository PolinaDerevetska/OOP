/* using System;

class Student
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; } 
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value <= 120)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Вік повинен бути від 0 до 120!");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student();
        student.Name = "Поліна";
        student.Age = 18;
        Console.WriteLine($"Ім'я: {student.Name}");
        Console.WriteLine($"Вік: {student.Age}");
        student.Age = 150;
        Console.WriteLine($"Спроба встановити вік 150: {student.Age}");
    }
}*/

using System;

class Car
{
    private int speed = 0;

    public void Accelerate(int amount)
    {
        speed += amount;
        Console.WriteLine($"Прискорення: +{amount} км/год → Швидкість: {Speed} км/год");
    }

    public void Brake(int amount)
    {
        if (amount >= speed)
        {
            speed = 0;
            Console.WriteLine($"Сильне гальмування: -{amount} км/год → Швидкість: 0 км/год");
        }
        else
        {
            speed -= amount;
            Console.WriteLine($"Гальмування: -{amount} км/год → Швидкість: {Speed} км/год");
        }
    }

    public int Speed
    {
        get { return speed; }
    }
}

class Program
{
    static void Main()
    {
        Car car = new Car();

        car.Accelerate(50);
        car.Accelerate(30);
        car.Brake(60);
        car.Brake(50);
    }
}