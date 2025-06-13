using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
public interface IGreetingService
{
    void Greet(string name);
}

public class GreetingService : IGreetingService
{
    public void Greet(string name)
    {
        Console.WriteLine($"Привіт, {name}!");
    }
}
public class App
{
    private readonly IGreetingService _greetingService;

    public App(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public void Run()
    {
        Console.Write("Введіть ваше ім'я: ");
        string name = Console.ReadLine();
        _greetingService.Greet(name);
    }
}
class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IGreetingService, GreetingService>();
                services.AddTransient<App>();
            })
            .Build();

        var app = host.Services.GetRequiredService<App>();
        app.Run();

        await host.RunAsync();
    }
}