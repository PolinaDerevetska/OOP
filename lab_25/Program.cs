// Strategy
public interface ICalculationStrategy
{
    int Calculate(int a, int b);
}

public class AddStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a + b;
}

public class SubtractStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a - b;
}

public class MultiplyStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a * b;
}

public class Calculator
{
    private ICalculationStrategy _strategy;

    public void SetStrategy(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public int Execute(int a, int b)
    {
        return _strategy.Calculate(a, b);
    }
}

// Command
public interface ICommand
{
    void Execute();
}

public class OpenFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Відкрито файл.");
}

public class SaveFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл збережено.");
}

public class CloseFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл закрито.");
}

public class Editor
{
    public void RunCommand(ICommand command)
    {
        command.Execute();
    }
}


// Mediator
public class ChatMediator
{
    private List<User> _users = new();

    public void Register(User user)
    {
        _users.Add(user);
    }

    public void Send(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
                user.Receive(message);
        }
    }
}

public class User
{
    private string _name;
    private ChatMediator _mediator;

    public User(string name, ChatMediator mediator)
    {
        _name = name;
        _mediator = mediator;
        _mediator.Register(this);
    }

    public void Send(string message)
    {
        Console.WriteLine($"{_name} надсилає: {message}");
        _mediator.Send(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{_name} отримує: {message}");
    }
}

// Observer
public interface IObserver
{
    void Update(string message);
}

public class WeatherStation
{
    private List<IObserver> _observers = new();

    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}

public class PhoneApp : IObserver
{
    private string _id;
    public PhoneApp(string id) => _id = id;
    public void Update(string message) => Console.WriteLine($"App {_id}: {message}");
}

public class Billboard : IObserver
{
    private string _location;
    public Billboard(string location) => _location = location;
    public void Update(string message) => Console.WriteLine($"Billboard ({_location}): {message}");
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Strategy:");
        var calc = new Calculator();
        calc.SetStrategy(new AddStrategy());
        Console.WriteLine("5 + 3 = " + calc.Execute(5, 3));
        calc.SetStrategy(new MultiplyStrategy());
        Console.WriteLine("5 * 3 = " + calc.Execute(5, 3));

        Console.WriteLine("\nCommand:");
        var editor = new Editor();
        editor.RunCommand(new OpenFileCommand());
        editor.RunCommand(new SaveFileCommand());
        editor.RunCommand(new CloseFileCommand());

        Console.WriteLine("\nMediator:");
        var mediator = new ChatMediator();
        var user1 = new User("Аня", mediator);
        var user2 = new User("Богдан", mediator);
        var user3 = new User("Катя", mediator);
        user1.Send("Привіт усім!");

        Console.WriteLine("\nObserver:");
        var station = new WeatherStation();
        var phone1 = new PhoneApp("UA001");
        var phone2 = new PhoneApp("UA002");
        var board = new Billboard("Центр міста");

        station.Subscribe(phone1);
        station.Subscribe(phone2);
        station.Subscribe(board);

        station.Notify("Зміна погоди: +30°C, сонячно.");
    }
}