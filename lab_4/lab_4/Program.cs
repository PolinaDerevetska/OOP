namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        // 1
        Console.WriteLine("Задача 1");
        int age = 18;
        double weight = 48.2;
        char grade = 'A';
        bool isStudent = true;
        string name = "Поліна";
        Console.WriteLine("Вік: " + age);
        Console.WriteLine("Вага: " + weight);
        Console.WriteLine("Оцінка: " + grade);
        Console.WriteLine("Студент: " + isStudent);
        Console.WriteLine("Ім'я: " + name);
        Console.WriteLine();

        // 2
        Console.WriteLine("Задача 2");
        Console.Write("Введіть число (типу double): ");
        string input = Console.ReadLine();
        double doubleValue = Convert.ToDouble(input);
        Console.WriteLine("Double: " + doubleValue);
        int intValue = (int)doubleValue;
        Console.WriteLine("Int: " + intValue);
        string stringValue = intValue.ToString();
        Console.WriteLine("String: " + stringValue);
        Console.WriteLine();

        // 3
        Console.WriteLine("Задача 3");
        Console.Write("Введіть ваше ім'я: ");
        string userName = Console.ReadLine();
        Console.Write("Введіть ваш вік: ");
        int userAge = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Привіт, {userName}! Твій вік: {userAge} років.");
        Console.WriteLine();

        // 4
        Console.WriteLine("Задача 4");
        Console.Write("Введіть відстань (км): ");
        double distance = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть час (год): ");
        double time = Convert.ToDouble(Console.ReadLine());
        double speed = distance / time;
        Console.WriteLine($"Середня швидкість: {speed} км/год");
        Console.WriteLine();

        // 5
        Console.WriteLine("Задача 5");
        Console.Write("Введіть речення: ");
        string sentence = Console.ReadLine();
        Console.WriteLine($"Довжина: {sentence.Length} символів");
        Console.WriteLine($"Верхній регістр: {sentence.ToUpper()}");
        Console.WriteLine($"Замінені пробіли: {sentence.Replace(" ", "_")}");
        Console.WriteLine($"Перші 5 символів: {sentence.Substring(0, 5)}");
    }
}

