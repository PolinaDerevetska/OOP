/* using System;

public class Container<T>
{
    public T Value { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Значення: {Value}, Тип: {Value.GetType().Name}");
    }
}

class Program
{
    static void Main()
    {
        Container<int> intBox = new Container<int> { Value = 42 };
        Container<string> strBox = new Container<string> { Value = "Hello" };

        intBox.ShowInfo();
        strBox.ShowInfo();
    }
}*/

// 2
using System;

class Program
{
    // Узагальнений метод пошуку максимуму
    public static T FindMax<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Масив порожній або null");

        T max = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(max) > 0)
                max = array[i];
        }

        return max;
    }

    static void Main()
    {
        int[] intArray = { 5, 8, 2, 10, 3 };
        double[] doubleArray = { 3.5, 7.2, 1.8, 9.9 };
        string[] stringArray = { "apple", "banana", "cherry" };

        Console.WriteLine($"Максимум (int): {FindMax(intArray)}");
        Console.WriteLine($"Максимум (double): {FindMax(doubleArray)}");
        Console.WriteLine($"Максимум (string): {FindMax(stringArray)}");
    }
}