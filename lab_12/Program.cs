/* using System;

struct Point
{
    public double X;
    public double Y;
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
    public double DistanceTo(Point other)
    {
        double dx = other.X - X;
        double dy = other.Y - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(3, 4);
        Point p2 = new Point(0, 0);
        Console.WriteLine($"Відстань: {p1.DistanceTo(p2)}");
    }
}
*/

using System;

class Car
{
    public string Brand;
    public string Model;
    public int Year;
    public string Color;
    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
        Year = 0;
        Color = "невідомо";
    }
    public Car(string brand, string model, int year)
        : this(brand, model)
    {
        Year = year;
    }
    public Car(string brand, string model, int year, string color)
        : this(brand, model, year)
    {
        Color = color;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Марка: {Brand}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Рік: {(Year == 0 ? "невідомо" : Year)}");
        Console.WriteLine($"Колір: {Color}");
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Car("Toyota", "Corolla");
        Car car2 = new Car("Honda", "Civic", 2018);
        Car car3 = new Car("BMW", "X5", 2020, "Чорний");

        Console.WriteLine("Авто 1:");
        car1.ShowInfo();
        Console.WriteLine("\nАвто 2:");
        car2.ShowInfo();
        Console.WriteLine("\nАвто 3:");
        car3.ShowInfo();
    }
}