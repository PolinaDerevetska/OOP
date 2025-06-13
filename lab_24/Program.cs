using System;

public interface INewPrinter
{
    void Print(string message);
}

public class OldPrinter
{
    public void OldPrint(string text)
    {
        Console.WriteLine($"[Старий принтер] {text}");
    }
}

public class PrinterAdapter : INewPrinter
{
    private readonly OldPrinter _oldPrinter;

    public PrinterAdapter(OldPrinter oldPrinter)
    {
        _oldPrinter = oldPrinter;
    }

    public void Print(string message)
    {
        _oldPrinter.OldPrint(message);
    }
}

public class Engine
{
    public void Start() => Console.WriteLine("Двигун запущено.");
}

public class Battery
{
    public void Start() => Console.WriteLine("Акумулятор працює.");
}

public class IgnitionSystem
{
    public void Start() => Console.WriteLine("Система запалювання активована.");
}

public class CarFacade
{
    private readonly Engine _engine;
    private readonly Battery _battery;
    private readonly IgnitionSystem _ignition;

    public CarFacade()
    {
        _engine = new Engine();
        _battery = new Battery();
        _ignition = new IgnitionSystem();
    }

    public void StartCar()
    {
        Console.WriteLine("Запуск автомобіля:");
        _battery.Start();
        _ignition.Start();
        _engine.Start();
    }
}

public interface IWriter
{
    void Write(string text);
}

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}

public class TimestampWriter : IWriter
{
    private readonly IWriter _inner;

    public TimestampWriter(IWriter inner)
    {
        _inner = inner;
    }

    public void Write(string text)
    {
        string timestamp = $"[{DateTime.Now:HH:mm:ss}] {text}";
        _inner.Write(timestamp);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Adapter:");
        INewPrinter printer = new PrinterAdapter(new OldPrinter());
        printer.Print("Це тестовий друк!");

        Console.WriteLine("\nFacade:");
        CarFacade car = new CarFacade();
        car.StartCar();

        Console.WriteLine("\nDecorator");
        IWriter writer = new TimestampWriter(new ConsoleWriter());
        writer.Write("Привіт, світ!");
    }
}